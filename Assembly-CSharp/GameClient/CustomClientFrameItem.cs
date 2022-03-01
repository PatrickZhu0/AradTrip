using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001BC7 RID: 7111
	public abstract class CustomClientFrameItem
	{
		// Token: 0x17001DAC RID: 7596
		// (get) Token: 0x06011633 RID: 71219 RVA: 0x005097D8 File Offset: 0x00507BD8
		public bool BShowed
		{
			get
			{
				return this.bShowed;
			}
		}

		// Token: 0x06011634 RID: 71220
		protected abstract void _Init();

		// Token: 0x06011635 RID: 71221
		protected abstract void _Clear();

		// Token: 0x06011636 RID: 71222 RVA: 0x005097E0 File Offset: 0x00507BE0
		protected void _ClearBase()
		{
			this._mParentGo = null;
			this._mBind = null;
			this._mSelfGo = null;
			this.bInited = false;
			this.bShowed = false;
		}

		// Token: 0x0400B472 RID: 46194
		protected bool bInited;

		// Token: 0x0400B473 RID: 46195
		protected bool bShowed;

		// Token: 0x0400B474 RID: 46196
		protected GameObject _mParentGo;

		// Token: 0x0400B475 RID: 46197
		protected GameObject _mSelfGo;

		// Token: 0x0400B476 RID: 46198
		protected ComCommonBind _mBind;
	}
}
