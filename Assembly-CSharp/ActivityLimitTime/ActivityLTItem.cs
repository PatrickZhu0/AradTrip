using System;
using GameClient;
using UnityEngine;

namespace ActivityLimitTime
{
	// Token: 0x020018C5 RID: 6341
	public class ActivityLTItem<T> : ActivityLTObject<T>
	{
		// Token: 0x0600F7BF RID: 63423 RVA: 0x00433F69 File Offset: 0x00432369
		public virtual void Init(GameObject parent, ActivityLimitTimeFrame frame, ActivityLimitTimeData data)
		{
		}

		// Token: 0x0600F7C0 RID: 63424 RVA: 0x00433F6B File Offset: 0x0043236B
		protected virtual void SetDataToView()
		{
		}

		// Token: 0x0600F7C1 RID: 63425 RVA: 0x00433F6D File Offset: 0x0043236D
		public virtual void RefreshView(ActivityLimitTimeData data)
		{
		}

		// Token: 0x0600F7C2 RID: 63426 RVA: 0x00433F6F File Offset: 0x0043236F
		public override void Create()
		{
			base.Create();
		}

		// Token: 0x0600F7C3 RID: 63427 RVA: 0x00433F77 File Offset: 0x00432377
		public override void Destory()
		{
			base.Destory();
		}

		// Token: 0x0600F7C4 RID: 63428 RVA: 0x00433F7F File Offset: 0x0043237F
		public virtual void Reset()
		{
			this.goSelf = null;
			this.goParent = null;
			this.currFrame = null;
			this.currActivityData = null;
			this.mBind = null;
		}

		// Token: 0x040098F4 RID: 39156
		protected GameObject goParent;

		// Token: 0x040098F5 RID: 39157
		protected ActivityLimitTimeData currActivityData;

		// Token: 0x040098F6 RID: 39158
		protected ActivityLimitTimeFrame currFrame;

		// Token: 0x040098F7 RID: 39159
		protected ComCommonBind mBind;
	}
}
