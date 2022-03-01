using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200173E RID: 5950
	public class LimitTimePetGiftFrameView : MonoBehaviour
	{
		// Token: 0x0600E9CD RID: 59853 RVA: 0x003DE970 File Offset: 0x003DCD70
		public void InitData(List<MallItemInfo> data, OnBuyClickDelegate onBuyClickDelegate)
		{
			this.mData = data;
			this.mOnBuyClickDelegate = onBuyClickDelegate;
			if (this.mCloseBtn)
			{
				this.mCloseBtn.onClick.RemoveAllListeners();
				this.mCloseBtn.onClick.AddListener(new UnityAction(this.OnCloseClick));
			}
			if (this.mData.Count > 1)
			{
				uint endTime = (uint)Mathf.Max(this.mData[0].endtime, this.mData[1].endtime);
				this.InitSimpleTime(endTime);
			}
			else
			{
				this.InitSimpleTime(this.mData[0].endtime);
			}
			this.InitComUIListScript();
		}

		// Token: 0x0600E9CE RID: 59854 RVA: 0x003DEA2E File Offset: 0x003DCE2E
		public void RefreshItemInfo(List<MallItemInfo> data)
		{
			this.mData = new List<MallItemInfo>();
			this.mData = data;
			this.SetElementAmount();
		}

		// Token: 0x0600E9CF RID: 59855 RVA: 0x003DEA48 File Offset: 0x003DCE48
		private void InitComUIListScript()
		{
			this.mItemsUIList.Initialize();
			ComUIListScript comUIListScript = this.mItemsUIList;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
			ComUIListScript comUIListScript2 = this.mItemsUIList;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			this.SetElementAmount();
		}

		// Token: 0x0600E9D0 RID: 59856 RVA: 0x003DEAB4 File Offset: 0x003DCEB4
		private ComCommonBind OnBindItemDelegate(GameObject itemObject)
		{
			ComCommonBind component = itemObject.GetComponent<ComCommonBind>();
			if (component != null)
			{
				return component;
			}
			return null;
		}

		// Token: 0x0600E9D1 RID: 59857 RVA: 0x003DEAD8 File Offset: 0x003DCED8
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			ComCommonBind comCommonBind = item.gameObjectBindScript as ComCommonBind;
			if (comCommonBind != null && item.m_index >= 0 && item.m_index < this.mData.Count)
			{
				MallItemInfo info = this.mData[item.m_index];
				int num = 0;
				if (info.giftItems.Length > 0)
				{
					num = (int)info.giftItems[0].id;
				}
				Button com = comCommonBind.GetCom<Button>("TipsBtn");
				Text com2 = comCommonBind.GetCom<Text>("price");
				Button com3 = comCommonBind.GetCom<Button>("Buy");
				UIGray com4 = comCommonBind.GetCom<UIGray>("Gray");
				Image com5 = comCommonBind.GetCom<Image>("BG");
				Image com6 = comCommonBind.GetCom<Image>("Icon");
				ItemData mItemData = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(num);
				if (mItemData != null)
				{
					ETCImageLoader.LoadSprite(ref com5, mItemData.GetQualityInfo().Background, true);
				}
				int petID = this.GetPetID(num);
				PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>(petID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ETCImageLoader.LoadSprite(ref com6, tableItem.IconPath, true);
				}
				if (com != null)
				{
					com.onClick.RemoveAllListeners();
					com.onClick.AddListener(delegate()
					{
						if (mItemData != null)
						{
							DataManager<ItemTipManager>.GetInstance().ShowTip(mItemData, null, 4, true, false, true);
						}
					});
				}
				if (com2 != null)
				{
					Text text = com2;
					int discountprice = (int)info.discountprice;
					text.text = discountprice.ToString();
				}
				if (com3 != null)
				{
					com3.onClick.RemoveAllListeners();
					com3.onClick.AddListener(delegate()
					{
						if (this.mOnBuyClickDelegate != null)
						{
							this.mOnBuyClickDelegate(info);
						}
					});
				}
				if (com3 != null && com4 != null)
				{
					com3.image.raycastTarget = (info.limittotalnum > 0);
					com4.enabled = (info.limittotalnum <= 0);
				}
			}
		}

		// Token: 0x0600E9D2 RID: 59858 RVA: 0x003DECFE File Offset: 0x003DD0FE
		private void SetElementAmount()
		{
			this.mItemsUIList.SetElementAmount(this.mData.Count);
		}

		// Token: 0x0600E9D3 RID: 59859 RVA: 0x003DED18 File Offset: 0x003DD118
		private void InitSimpleTime(uint endTime)
		{
			int countdown = (int)(endTime - DataManager<TimeManager>.GetInstance().GetServerTime());
			if (this.mSimpleTimer)
			{
				this.mSimpleTimer.SetCountdown(countdown);
				this.mSimpleTimer.StartTimer();
			}
		}

		// Token: 0x0600E9D4 RID: 59860 RVA: 0x003DED59 File Offset: 0x003DD159
		private void OnCloseClick()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LimitTimePetGiftFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimePetGiftFrame>(null, false);
			}
		}

		// Token: 0x0600E9D5 RID: 59861 RVA: 0x003DED78 File Offset: 0x003DD178
		private int GetPetID(int petEggID)
		{
			int result = 0;
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<PetTable>())
			{
				PetTable petTable = keyValuePair.Value as PetTable;
				if (petTable.PetEggID == petEggID)
				{
					return petTable.ID;
				}
			}
			return result;
		}

		// Token: 0x0600E9D6 RID: 59862 RVA: 0x003DEDD8 File Offset: 0x003DD1D8
		private void OnDestroy()
		{
			if (this.mSimpleTimer)
			{
				this.mSimpleTimer.StopTimer();
				this.mSimpleTimer = null;
			}
			if (this.mItemsUIList)
			{
				ComUIListScript comUIListScript = this.mItemsUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mItemsUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				this.mItemsUIList = null;
			}
			this.mData = null;
			this.mOnBuyClickDelegate = null;
		}

		// Token: 0x04008DCB RID: 36299
		[SerializeField]
		private ComUIListScript mItemsUIList;

		// Token: 0x04008DCC RID: 36300
		[SerializeField]
		private Button mCloseBtn;

		// Token: 0x04008DCD RID: 36301
		[SerializeField]
		private SimpleTimer mSimpleTimer;

		// Token: 0x04008DCE RID: 36302
		private List<MallItemInfo> mData;

		// Token: 0x04008DCF RID: 36303
		private OnBuyClickDelegate mOnBuyClickDelegate;
	}
}
