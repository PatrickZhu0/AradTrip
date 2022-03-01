using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200188A RID: 6282
	public class EquipmentUpgradeActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F5E2 RID: 62946 RVA: 0x00425929 File Offset: 0x00423D29
		public void SetCallBack(EquipmentUpgradeActivityView.BuyCallBack callback)
		{
			this.mGoToGoblinShopCallback = callback;
		}

		// Token: 0x0600F5E3 RID: 62947 RVA: 0x00425934 File Offset: 0x00423D34
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mOnItemClick = onItemClick;
			this.mNote.Init(model, true, base.GetComponent<ComCommonBind>());
			this.mGoToGloblinBtn.onClick.RemoveAllListeners();
			this.mGoToGloblinBtn.onClick.AddListener(delegate()
			{
				if (this.mGoToGoblinShopCallback != null)
				{
					this.mGoToGoblinShopCallback();
				}
			});
			if (model.ParamArray != null && model.ParamArray.Length > 1)
			{
				MallLimitTimeActivity tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallLimitTimeActivity>((int)model.ParamArray[1], string.Empty, string.Empty);
				if (tableItem != null && this.mBg != null)
				{
					ETCImageLoader.LoadSprite(ref this.mBg, tableItem.BackgroundImgPath, true);
				}
			}
		}

		// Token: 0x0600F5E4 RID: 62948 RVA: 0x004259F8 File Offset: 0x00423DF8
		public override void Dispose()
		{
			base.Dispose();
			if (this.mComItems != null)
			{
				for (int i = this.mComItems.Count - 1; i >= 0; i--)
				{
					ComItemManager.Destroy(this.mComItems[i]);
				}
				this.mComItems.Clear();
			}
		}

		// Token: 0x0600F5E5 RID: 62949 RVA: 0x00425A50 File Offset: 0x00423E50
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x040096D0 RID: 38608
		[SerializeField]
		private Button mGoToGloblinBtn;

		// Token: 0x040096D1 RID: 38609
		[SerializeField]
		private Image mBg;

		// Token: 0x040096D2 RID: 38610
		private EquipmentUpgradeActivityView.BuyCallBack mGoToGoblinShopCallback;

		// Token: 0x040096D3 RID: 38611
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x0200188B RID: 6283
		// (Invoke) Token: 0x0600F5E8 RID: 62952
		public delegate void BuyCallBack();
	}
}
