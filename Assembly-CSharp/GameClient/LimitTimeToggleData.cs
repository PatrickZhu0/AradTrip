using System;

namespace GameClient
{
	// Token: 0x020011BE RID: 4542
	public class LimitTimeToggleData : ITwoLevelToggleData
	{
		// Token: 0x0600AE80 RID: 44672 RVA: 0x00261158 File Offset: 0x0025F558
		public LimitTimeToggleData(IActivity activity)
		{
			if (activity != null)
			{
				this.Name = activity.GetName();
				this.IsShowRedPoint = activity.IsHaveRedPoint();
				this.Activity = activity;
				this.SelectName = string.Format(TR.Value("activity_tab_selected"), this.Name);
			}
		}

		// Token: 0x0600AE81 RID: 44673 RVA: 0x002611AB File Offset: 0x0025F5AB
		public LimitTimeToggleData(string name, bool isShowRedPoint, IActivity activity)
		{
			this.Name = name;
			this.IsShowRedPoint = isShowRedPoint;
			this.Activity = activity;
			this.SelectName = string.Format(TR.Value("activity_tab_selected"), name);
		}

		// Token: 0x17001A94 RID: 6804
		// (get) Token: 0x0600AE82 RID: 44674 RVA: 0x002611DE File Offset: 0x0025F5DE
		// (set) Token: 0x0600AE83 RID: 44675 RVA: 0x002611E6 File Offset: 0x0025F5E6
		public string Name { get; private set; }

		// Token: 0x17001A95 RID: 6805
		// (get) Token: 0x0600AE84 RID: 44676 RVA: 0x002611EF File Offset: 0x0025F5EF
		// (set) Token: 0x0600AE85 RID: 44677 RVA: 0x002611F7 File Offset: 0x0025F5F7
		public string SelectName { get; private set; }

		// Token: 0x17001A96 RID: 6806
		// (get) Token: 0x0600AE86 RID: 44678 RVA: 0x00261200 File Offset: 0x0025F600
		// (set) Token: 0x0600AE87 RID: 44679 RVA: 0x00261208 File Offset: 0x0025F608
		public bool IsShowRedPoint { get; private set; }

		// Token: 0x17001A97 RID: 6807
		// (get) Token: 0x0600AE88 RID: 44680 RVA: 0x00261211 File Offset: 0x0025F611
		// (set) Token: 0x0600AE89 RID: 44681 RVA: 0x00261219 File Offset: 0x0025F619
		public IActivity Activity { get; private set; }
	}
}
