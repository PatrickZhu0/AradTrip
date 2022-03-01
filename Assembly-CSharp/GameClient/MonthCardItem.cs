using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018FD RID: 6397
	public class MonthCardItem : DailyLoginItem
	{
		// Token: 0x0600F956 RID: 63830 RVA: 0x00440FAB File Offset: 0x0043F3AB
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			base.OnInit(data);
			this.mButtonGoToBuy.SafeAddOnClickListener(new UnityAction(this._OnButtonGoToBuyClick));
		}

		// Token: 0x0600F957 RID: 63831 RVA: 0x00440FCB File Offset: 0x0043F3CB
		public override void Dispose()
		{
			base.Dispose();
			this.mButtonGoToBuy.SafeAddOnClickListener(new UnityAction(this._OnButtonGoToBuyClick));
		}

		// Token: 0x0600F958 RID: 63832 RVA: 0x00440FEA File Offset: 0x0043F3EA
		private void _OnButtonGoToBuyClick()
		{
			if (this.mOnItemClick != null)
			{
				this.mOnItemClick((int)this.mId, 1, 0UL);
			}
		}

		// Token: 0x04009B20 RID: 39712
		[SerializeField]
		private Button mButtonGoToBuy;
	}
}
