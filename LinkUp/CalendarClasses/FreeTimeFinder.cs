using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace LinkUp.CalendarClasses
{
	internal class FreeTimeBlock
	{
		public int rank = 0;
		public List<string> availibilityList;
		public DateTime dStart;
		public DateTime dEnd;
	}


	internal class FreeTimeFinder
	{
		public List<FreeTimeBlock> blocks { get; }

		DateTime RoundUp(DateTime dt, TimeSpan d)
			{ return new DateTime((dt.Ticks + d.Ticks - 1) / d.Ticks * d.Ticks, dt.Kind); }

		DateTime RoundDown(DateTime dt, TimeSpan d)
			{ return new DateTime(((dt.Ticks + d.Ticks - 1) / d.Ticks) * d.Ticks); }


		public FreeTimeFinder(Group group)
		{
			
			// get date range of included availibilities
			DateTime dateMin = DateTime.MaxValue;
			DateTime dateMax = DateTime.MinValue;

			foreach (GroupMember m in group.members)
			{
				foreach(CalendarEvent e in m.events)
				{
					if (e.dStart > dateMax) { dateMax = e.dStart; }
					if (e.dEnd   < dateMin) { dateMin = e.dEnd;   }
				}
			}
			dateMin = RoundDown(dateMin, TimeSpan.FromMinutes(15));

			// make list of availibility blocks
			/*
			 * get first rank
			 * loop until rank changes
			 * create block
			 * repeat
			 */
			int lastRank = 0;
			List<string> lastAvailibilityList = new();
			DateTime lastStart = DateTime.MinValue;

			for(DateTime timeslot = dateMin; timeslot <= dateMax; timeslot.AddMinutes(15))
			{
				// get rank & availibilities for this timeslot
				int thisRank = 0;
				List<string> thisAvailibilityList = new();

				foreach(GroupMember m in group.members)
					foreach (CalendarEvent e in m.events)
					{
						if(e.dStart <= timeslot &&  e.dEnd >= timeslot && !thisAvailibilityList.Contains(m.uid))
						{
							if (thisRank == 0 && lastRank == 0) // rising edge
								lastStart = timeslot;

							thisRank++;
							thisAvailibilityList.Add(m.uid);
						}
					}

				// compare with previous timeslot
				if(thisRank != lastRank || thisAvailibilityList != lastAvailibilityList)
				{
					// lastrank was zero - rising edge
					// this rank > last rank
					// this rank < last rank

					// close last? if last != 0
					// open new? if this != 0
					if(lastRank != 0) // clsoe last
					{
						var newTimeBlock = new FreeTimeBlock
						{
							rank = lastRank,
							availibilityList = lastAvailibilityList,
							dStart = lastStart,
							dEnd = timeslot,
						};

						blocks.Add(newTimeBlock);
					}
					if(thisRank !=0) // open new
					{
						lastRank = thisRank;
						lastAvailibilityList = thisAvailibilityList;
					}
				}
			} // end for timeslot
		}
	}
}
