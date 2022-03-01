using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200136C RID: 4972
	internal class ActiveSpecialFrame : ActiveFrame
	{
		// Token: 0x0600C100 RID: 49408 RVA: 0x002DD06B File Offset: 0x002DB46B
		public void Intialize(IClientFrame parent, GameObject frame, int iActiveId)
		{
			this.parent = parent;
			this.frame = frame;
			this.iActiveId = iActiveId;
		}

		// Token: 0x0600C101 RID: 49409 RVA: 0x002DD082 File Offset: 0x002DB482
		public void UnInitialize()
		{
			this.parent = null;
			this.frame = null;
			this.iActiveId = 0;
		}

		// Token: 0x17001BAE RID: 7086
		// (get) Token: 0x0600C102 RID: 49410 RVA: 0x002DD099 File Offset: 0x002DB499
		public int ActiveID
		{
			get
			{
				return this.iActiveId;
			}
		}

		// Token: 0x0600C103 RID: 49411 RVA: 0x002DD0A1 File Offset: 0x002DB4A1
		public virtual void OnUpdate()
		{
		}

		// Token: 0x0600C104 RID: 49412 RVA: 0x002DD0A3 File Offset: 0x002DB4A3
		public virtual void OnCreate()
		{
		}

		// Token: 0x0600C105 RID: 49413 RVA: 0x002DD0A5 File Offset: 0x002DB4A5
		public virtual void OnDestroy()
		{
		}

		// Token: 0x04006D11 RID: 27921
		private IClientFrame parent;

		// Token: 0x04006D12 RID: 27922
		protected GameObject frame;

		// Token: 0x04006D13 RID: 27923
		private int iActiveId;

		// Token: 0x04006D14 RID: 27924
		public ActiveManager.ActiveData data;

		// Token: 0x04006D15 RID: 27925
		public ActivityInfo activityInfo;
	}
}
