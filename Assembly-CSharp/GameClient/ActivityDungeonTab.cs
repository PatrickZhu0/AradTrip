using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001392 RID: 5010
	public class ActivityDungeonTab : IComparable<ActivityDungeonTab>
	{
		// Token: 0x0600C264 RID: 49764 RVA: 0x002E50C8 File Offset: 0x002E34C8
		public void AddOneSub(int id)
		{
			if (this.subs.Find((ActivityDungeonSub x) => x.id == id) == null)
			{
				this.subs.Add(new ActivityDungeonSub(id, this.name));
				this.subs.Sort();
			}
		}

		// Token: 0x0600C265 RID: 49765 RVA: 0x002E5127 File Offset: 0x002E3527
		public int CompareTo(ActivityDungeonTab other)
		{
			return this.priority - other.priority;
		}

		// Token: 0x04006E1C RID: 28188
		public int priority;

		// Token: 0x04006E1D RID: 28189
		public string name;

		// Token: 0x04006E1E RID: 28190
		public List<ActivityDungeonSub> subs = new List<ActivityDungeonSub>();
	}
}
