using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018FE RID: 6398
	public class MouseYearRedPackageItem : ActivityItemBase
	{
		// Token: 0x0600F95A RID: 63834 RVA: 0x00441034 File Offset: 0x0043F434
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			this.mGotoBtn.SafeAddOnClickListener(new UnityAction(this._OnGoToBtnClick));
			this.mReceiveBtn.SafeAddOnClickListener(new UnityAction(this._OnReciveBtnClick));
			this.mDesTxt.SafeSetText(data.Desc);
			if (data != null && data.AwardDataList != null)
			{
				for (int i = 0; i < data.AwardDataList.Count; i++)
				{
					ComItem comItem = ComItemManager.Create(this.mItemRoot.gameObject);
					if (comItem != null)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)data.AwardDataList[i].id, 100, 0);
						itemData.Count = (int)data.AwardDataList[i].num;
						ComItem comItem2 = comItem;
						ItemData item = itemData;
						if (MouseYearRedPackageItem.<>f__mg$cache0 == null)
						{
							MouseYearRedPackageItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem2.Setup(item, MouseYearRedPackageItem.<>f__mg$cache0);
						this.mComItems.Add(comItem);
						(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
					}
				}
			}
		}

		// Token: 0x0600F95B RID: 63835 RVA: 0x00441144 File Offset: 0x0043F544
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			this.mGotoBtn.CustomActive(false);
			this.mReceiveBtn.CustomActive(false);
			this.mHaskTakenGo.CustomActive(false);
			switch (data.State)
			{
			case OpActTaskState.OATS_INIT:
			case OpActTaskState.OATS_UNFINISH:
				this.mGotoBtn.CustomActive(true);
				break;
			case OpActTaskState.OATS_FINISHED:
				this.mReceiveBtn.CustomActive(true);
				break;
			case OpActTaskState.OATS_OVER:
				this.mHaskTakenGo.CustomActive(true);
				break;
			}
		}

		// Token: 0x0600F95C RID: 63836 RVA: 0x004411D4 File Offset: 0x0043F5D4
		public override void Dispose()
		{
			base.Dispose();
			this.mGotoBtn.SafeRemoveOnClickListener(new UnityAction(this._OnGoToBtnClick));
			this.mReceiveBtn.SafeRemoveOnClickListener(new UnityAction(this._OnReciveBtnClick));
			if (this.mComItems != null)
			{
				for (int i = this.mComItems.Count - 1; i >= 0; i--)
				{
					ComItemManager.Destroy(this.mComItems[i]);
				}
				this.mComItems.Clear();
			}
		}

		// Token: 0x0600F95D RID: 63837 RVA: 0x0044125A File Offset: 0x0043F65A
		private void _OnReciveBtnClick()
		{
			base._OnItemClick();
		}

		// Token: 0x0600F95E RID: 63838 RVA: 0x00441264 File Offset: 0x0043F664
		private void _OnGoToBtnClick()
		{
			VipFrame vipFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, null, string.Empty) as VipFrame;
			vipFrame.SwitchPage(VipTabType.PAY, true);
		}

		// Token: 0x0600F95F RID: 63839 RVA: 0x00441290 File Offset: 0x0043F690
		private void _OnCommandLCKBtnClick()
		{
			DataManager<ActiveManager>.GetInstance().OpenActiveFrame(9380, 8600);
		}

		// Token: 0x04009B21 RID: 39713
		[SerializeField]
		private Button mGotoBtn;

		// Token: 0x04009B22 RID: 39714
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x04009B23 RID: 39715
		[SerializeField]
		private GameObject mHaskTakenGo;

		// Token: 0x04009B24 RID: 39716
		[SerializeField]
		private Text mDesTxt;

		// Token: 0x04009B25 RID: 39717
		[SerializeField]
		private Transform mItemRoot;

		// Token: 0x04009B26 RID: 39718
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x04009B27 RID: 39719
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009B28 RID: 39720
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
