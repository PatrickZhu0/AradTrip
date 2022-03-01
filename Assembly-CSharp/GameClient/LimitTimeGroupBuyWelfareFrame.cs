using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001852 RID: 6226
	public class LimitTimeGroupBuyWelfareFrame : ClientFrame
	{
		// Token: 0x0600F45E RID: 62558 RVA: 0x0041F6C4 File Offset: 0x0041DAC4
		protected sealed override void _bindExUI()
		{
			this.mBottomContent = this.mBind.GetCom<ComUIListScript>("BottomContent");
			this.mMiddleContent = this.mBind.GetCom<ComUIListScript>("MiddleContent");
			this.mTopContent = this.mBind.GetCom<ComUIListScript>("TopContent");
			this.mClose = this.mBind.GetCom<Button>("Close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
		}

		// Token: 0x0600F45F RID: 62559 RVA: 0x0041F745 File Offset: 0x0041DB45
		protected sealed override void _unbindExUI()
		{
			this.mBottomContent = null;
			this.mMiddleContent = null;
			this.mTopContent = null;
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
		}

		// Token: 0x0600F460 RID: 62560 RVA: 0x0041F77F File Offset: 0x0041DB7F
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<LimitTimeGroupBuyWelfareFrame>(this, false);
		}

		// Token: 0x0600F461 RID: 62561 RVA: 0x0041F78E File Offset: 0x0041DB8E
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/LimitTimeGroupBuyWelfareFrame";
		}

		// Token: 0x0600F462 RID: 62562 RVA: 0x0041F795 File Offset: 0x0041DB95
		protected sealed override void _OnOpenFrame()
		{
			this.InitmTopComUIList();
			this.InitmMiddleComUIList();
			this.InitmBottomComUIList();
			this.OnSetElementAmount();
		}

		// Token: 0x0600F463 RID: 62563 RVA: 0x0041F7AF File Offset: 0x0041DBAF
		protected sealed override void _OnCloseFrame()
		{
			this.UnInitmTopComUIList();
			this.UnInitmMiddleComUIList();
			this.UnInitmBottomComUIList();
		}

		// Token: 0x0600F464 RID: 62564 RVA: 0x0041F7C4 File Offset: 0x0041DBC4
		private void InitmTopComUIList()
		{
			if (this.mTopContent != null)
			{
				this.mTopContent.Initialize();
				ComUIListScript comUIListScript = this.mTopContent;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnTopBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mTopContent;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnTopItemVisiableDelegate));
			}
		}

		// Token: 0x0600F465 RID: 62565 RVA: 0x0041F83C File Offset: 0x0041DC3C
		private void UnInitmTopComUIList()
		{
			if (this.mTopContent != null)
			{
				ComUIListScript comUIListScript = this.mTopContent;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnTopBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mTopContent;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnTopItemVisiableDelegate));
			}
		}

		// Token: 0x0600F466 RID: 62566 RVA: 0x0041F8A8 File Offset: 0x0041DCA8
		private ComCommonBind OnTopBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComCommonBind>();
		}

		// Token: 0x0600F467 RID: 62567 RVA: 0x0041F8B0 File Offset: 0x0041DCB0
		private void OnTopItemVisiableDelegate(ComUIListElementScript item)
		{
			ComCommonBind comCommonBind = item.gameObjectBindScript as ComCommonBind;
			if (comCommonBind != null && item.m_index >= 0 && item.m_index < this.mMayDayList.Count)
			{
				this.UpdateTopItemInfo(comCommonBind, this.mMayDayList[item.m_index]);
			}
		}

		// Token: 0x0600F468 RID: 62568 RVA: 0x0041F910 File Offset: 0x0041DD10
		private void UpdateTopItemInfo(ComCommonBind bind, ActivityDataManager.LimitTimeGroupBuyPreviewDataModel data)
		{
			if (bind == null || data == null)
			{
				return;
			}
			Text com = bind.GetCom<Text>("DijingCount");
			Text com2 = bind.GetCom<Text>("Price");
			Text com3 = bind.GetCom<Text>("itemName");
			Image com4 = bind.GetCom<Image>("backgroud");
			Image com5 = bind.GetCom<Image>("Icon");
			Button com6 = bind.GetCom<Button>("IconBtn");
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(data.itemId, 100, 0);
			if (itemData != null)
			{
				if (com3 != null)
				{
					com3.text = itemData.GetColorName(string.Empty, false);
				}
				if (com4 != null)
				{
					ETCImageLoader.LoadSprite(ref com4, itemData.GetQualityInfo().Background, true);
				}
				if (com5 != null)
				{
					ETCImageLoader.LoadSprite(ref com5, itemData.Icon, true);
				}
				if (com6 != null)
				{
					com6.onClick.RemoveAllListeners();
					com6.onClick.AddListener(delegate()
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
					});
				}
			}
			if (com != null)
			{
				com.text = data.goblinCoin.ToString();
			}
			if (com2 != null)
			{
				com2.text = string.Format("{0}点券", data.price);
			}
		}

		// Token: 0x0600F469 RID: 62569 RVA: 0x0041FA88 File Offset: 0x0041DE88
		private void InitmMiddleComUIList()
		{
			if (this.mMiddleContent != null)
			{
				this.mMiddleContent.Initialize();
				ComUIListScript comUIListScript = this.mMiddleContent;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnMiddleBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mMiddleContent;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnMiddleItemVisiableDelegate));
			}
		}

		// Token: 0x0600F46A RID: 62570 RVA: 0x0041FB00 File Offset: 0x0041DF00
		private void UnInitmMiddleComUIList()
		{
			if (this.mMiddleContent != null)
			{
				ComUIListScript comUIListScript = this.mMiddleContent;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnMiddleBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mMiddleContent;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnMiddleItemVisiableDelegate));
			}
		}

		// Token: 0x0600F46B RID: 62571 RVA: 0x0041FB6C File Offset: 0x0041DF6C
		private ComCommonBind OnMiddleBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComCommonBind>();
		}

		// Token: 0x0600F46C RID: 62572 RVA: 0x0041FB74 File Offset: 0x0041DF74
		private void OnMiddleItemVisiableDelegate(ComUIListElementScript item)
		{
			ComCommonBind comCommonBind = item.gameObjectBindScript as ComCommonBind;
			if (comCommonBind != null && item.m_index >= 0 && item.m_index < this.mGoblinChamberList.Count)
			{
				this.UpdateMiddleOrBottomItemInfo(comCommonBind, this.mGoblinChamberList[item.m_index]);
			}
		}

		// Token: 0x0600F46D RID: 62573 RVA: 0x0041FBD4 File Offset: 0x0041DFD4
		private void UpdateMiddleOrBottomItemInfo(ComCommonBind bind, ActivityDataManager.LimitTimeGroupBuyPreviewDataModel data)
		{
			if (bind == null || data == null)
			{
				return;
			}
			Text com = bind.GetCom<Text>("Count");
			Text com2 = bind.GetCom<Text>("itemName");
			Image com3 = bind.GetCom<Image>("backgroud");
			Image com4 = bind.GetCom<Image>("Icon");
			Button com5 = bind.GetCom<Button>("IconBtn");
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(data.itemId, 100, 0);
			if (itemData != null)
			{
				if (com2 != null)
				{
					com2.text = itemData.GetColorName(string.Empty, false);
				}
				if (com3 != null)
				{
					ETCImageLoader.LoadSprite(ref com3, itemData.GetQualityInfo().Background, true);
				}
				if (com4 != null)
				{
					ETCImageLoader.LoadSprite(ref com4, itemData.Icon, true);
				}
				if (com5 != null)
				{
					com5.onClick.RemoveAllListeners();
					com5.onClick.AddListener(delegate()
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
					});
				}
			}
			if (com != null)
			{
				com.text = data.goblinCoin.ToString();
			}
		}

		// Token: 0x0600F46E RID: 62574 RVA: 0x0041FD14 File Offset: 0x0041E114
		private void InitmBottomComUIList()
		{
			if (this.mBottomContent != null)
			{
				this.mBottomContent.Initialize();
				ComUIListScript comUIListScript = this.mBottomContent;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBottomBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mBottomContent;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnBottomItemVisiableDelegate));
			}
		}

		// Token: 0x0600F46F RID: 62575 RVA: 0x0041FD8C File Offset: 0x0041E18C
		private void UnInitmBottomComUIList()
		{
			if (this.mBottomContent != null)
			{
				ComUIListScript comUIListScript = this.mBottomContent;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBottomBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mBottomContent;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnBottomItemVisiableDelegate));
			}
		}

		// Token: 0x0600F470 RID: 62576 RVA: 0x0041FDF8 File Offset: 0x0041E1F8
		private ComCommonBind OnBottomBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComCommonBind>();
		}

		// Token: 0x0600F471 RID: 62577 RVA: 0x0041FE00 File Offset: 0x0041E200
		private void OnBottomItemVisiableDelegate(ComUIListElementScript item)
		{
			ComCommonBind comCommonBind = item.gameObjectBindScript as ComCommonBind;
			if (comCommonBind != null && item.m_index >= 0 && item.m_index < this.mGoblinChamberNewList.Count)
			{
				this.UpdateMiddleOrBottomItemInfo(comCommonBind, this.mGoblinChamberNewList[item.m_index]);
			}
		}

		// Token: 0x0600F472 RID: 62578 RVA: 0x0041FE60 File Offset: 0x0041E260
		private void OnSetElementAmount()
		{
			this.mMayDayList = ActivityDataManager.GetLimitTimeGroupBuyPrevieDataList(ActivityDataManager.LimitTimeGroupBuyPreviewType.MayDay);
			this.mTopContent.SetElementAmount(this.mMayDayList.Count);
			this.mGoblinChamberList = ActivityDataManager.GetLimitTimeGroupBuyPrevieDataList(ActivityDataManager.LimitTimeGroupBuyPreviewType.GoblinChamber);
			this.mMiddleContent.SetElementAmount(this.mGoblinChamberList.Count);
			this.mGoblinChamberNewList = ActivityDataManager.GetLimitTimeGroupBuyPrevieDataList(ActivityDataManager.LimitTimeGroupBuyPreviewType.GoblinChamberNew);
			this.mBottomContent.SetElementAmount(this.mGoblinChamberNewList.Count);
		}

		// Token: 0x04009618 RID: 38424
		private ComUIListScript mBottomContent;

		// Token: 0x04009619 RID: 38425
		private ComUIListScript mMiddleContent;

		// Token: 0x0400961A RID: 38426
		private ComUIListScript mTopContent;

		// Token: 0x0400961B RID: 38427
		private Button mClose;

		// Token: 0x0400961C RID: 38428
		private List<ActivityDataManager.LimitTimeGroupBuyPreviewDataModel> mMayDayList = new List<ActivityDataManager.LimitTimeGroupBuyPreviewDataModel>();

		// Token: 0x0400961D RID: 38429
		private List<ActivityDataManager.LimitTimeGroupBuyPreviewDataModel> mGoblinChamberList = new List<ActivityDataManager.LimitTimeGroupBuyPreviewDataModel>();

		// Token: 0x0400961E RID: 38430
		private List<ActivityDataManager.LimitTimeGroupBuyPreviewDataModel> mGoblinChamberNewList = new List<ActivityDataManager.LimitTimeGroupBuyPreviewDataModel>();
	}
}
