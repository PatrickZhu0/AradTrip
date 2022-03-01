using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A41 RID: 6721
	internal class BlackMarketMerchantTradeView : MonoBehaviour
	{
		// Token: 0x0601080F RID: 67599 RVA: 0x004A57F4 File Offset: 0x004A3BF4
		private void Awake()
		{
			if (this.mInputBtn)
			{
				this.mInputBtn.onClick.RemoveAllListeners();
				this.mInputBtn.onClick.AddListener(delegate()
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<VirtualKeyboardFrame>(FrameLayer.Middle, null, string.Empty);
					this.ReenterPrice = true;
				});
			}
			if (this.mConFirmBtn)
			{
				this.mConFirmBtn.onClick.RemoveAllListeners();
				this.mConFirmBtn.onClick.AddListener(delegate()
				{
					if (this.mOnConfirmClick != null)
					{
						this.mOnConfirmClick.Invoke();
					}
				});
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChangeNum, new ClientEventSystem.UIEventHandler(this.OnChangeNumber));
		}

		// Token: 0x06010810 RID: 67600 RVA: 0x004A5894 File Offset: 0x004A3C94
		private void OnChangeNumber(UIEvent uiEvent)
		{
			ChangeNumType changeNumType = (ChangeNumType)uiEvent.Param1;
			if (changeNumType == ChangeNumType.EnSure)
			{
				this.iInputNumber = this.Clamp(this.iInputNumber, this.iMinPrice, this.iMaxPrice);
				this.UpdateInputPriceText(this.iInputNumber);
				if (this.mOnSetPrice != null)
				{
					this.mOnSetPrice(this.iInputNumber);
				}
			}
			else
			{
				uint num = this.iInputNumber;
				if (changeNumType == ChangeNumType.Add)
				{
					int addNum = (int)uiEvent.Param2;
					num = this.AddInputNumber(num, (uint)addNum);
				}
				else if (changeNumType == ChangeNumType.BackSpace)
				{
					num = this.BackSpaceInputNumber(num);
				}
				if (num <= 0U || num.ToString().Length > 9)
				{
					return;
				}
				this.iInputNumber = Math.Min(num, this.iMaxPrice);
				this.UpdateInputPriceText(this.iInputNumber);
			}
		}

		// Token: 0x06010811 RID: 67601 RVA: 0x004A5978 File Offset: 0x004A3D78
		private uint AddInputNumber(uint currentNum, uint addNum)
		{
			if (addNum < 0U || addNum > 9U)
			{
				Logger.LogErrorFormat("传入数字不合法，请控制在0-9之间", new object[0]);
				return currentNum;
			}
			uint num;
			if (this.ReenterPrice)
			{
				if (addNum != 0U)
				{
					num = addNum;
					this.ReenterPrice = false;
				}
				else
				{
					num = 1U;
					this.ReenterPrice = true;
				}
			}
			else
			{
				num = currentNum * 10U + addNum;
			}
			if (num < 1U)
			{
				Logger.LogErrorFormat("userInputPrice is error", new object[0]);
			}
			return num;
		}

		// Token: 0x06010812 RID: 67602 RVA: 0x004A59F4 File Offset: 0x004A3DF4
		private uint BackSpaceInputNumber(uint currentNum)
		{
			if (currentNum < 10U)
			{
				currentNum = 1U;
			}
			else
			{
				uint num = currentNum / 10U;
				currentNum = num;
			}
			return currentNum;
		}

		// Token: 0x06010813 RID: 67603 RVA: 0x004A5A1A File Offset: 0x004A3E1A
		private uint Clamp(uint value, uint min, uint max)
		{
			return Math.Min(Math.Max(value, min), max);
		}

		// Token: 0x06010814 RID: 67604 RVA: 0x004A5A2C File Offset: 0x004A3E2C
		public void InitView(ApplyTradData mData, OnItemSelect onItemSelect, OnSetPrice onSetPrice, UnityAction OnConFirmClick)
		{
			this.mApplyTradData = mData;
			this.mOnItemSelect = onItemSelect;
			this.mOnSetPrice = onSetPrice;
			this.mOnConfirmClick = OnConFirmClick;
			this.iMinPrice = this.mApplyTradData.mInfo.price_lower_limit;
			this.iMaxPrice = this.mApplyTradData.mInfo.price_upper_limit;
			this.InitInfo();
			this.UpdateStateShow();
			this.InitComUIListScript();
			this.InitBtnCloseClick();
		}

		// Token: 0x06010815 RID: 67605 RVA: 0x004A5A9A File Offset: 0x004A3E9A
		private void UpdateStateShow()
		{
			if (this.mApplyTradData.mInfo.back_buy_type == 1)
			{
				this.mStateControl.Key = this.mBmtFixedPriceState;
			}
			else
			{
				this.mStateControl.Key = this.mBmtAuctionPriceState;
			}
		}

		// Token: 0x06010816 RID: 67606 RVA: 0x004A5ADC File Offset: 0x004A3EDC
		private void InitInfo()
		{
			BlackMarketTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BlackMarketTable>((int)this.mApplyTradData.mInfo.back_buy_type, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("[BlackMarketTable] 黑市商人表中未找到ID id={0}", new object[]
				{
					(int)this.mApplyTradData.mInfo.back_buy_type
				});
			}
			NpcTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(tableItem.NpcID, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				Logger.LogErrorFormat("[BlackMarketTable] npc表中未找到ID id={0}", new object[]
				{
					tableItem.NpcID
				});
			}
			this.mBlackMarketMerchanName.text = string.Format("{0}:", tableItem2.NpcName);
			this.mPeopleDesc.text = tableItem.NPCDialogue;
			ETCImageLoader.LoadSprite(ref this.mMerchantImage, tableItem.NpcPortrait, true);
			this.mMerchantImage.SetNativeSize();
			this.mPrice.text = this.mApplyTradData.mInfo.price.ToString();
			this.mRecommendPrice.text = this.mApplyTradData.mInfo.recommend_price.ToString();
			this.mGoRecommendedRoot.CustomActive(this.mApplyTradData.mInfo.recommend_price > 0U);
		}

		// Token: 0x06010817 RID: 67607 RVA: 0x004A5C30 File Offset: 0x004A4030
		private void InitComUIListScript()
		{
			if (this.mComUIListScript)
			{
				this.mComUIListScript.Initialize();
				ComUIListScript comUIListScript = this.mComUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mComUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mComUIListScript;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mComUIListScript;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
				this.LoadAllEquip();
			}
		}

		// Token: 0x06010818 RID: 67608 RVA: 0x004A5CFC File Offset: 0x004A40FC
		private void UnInitComUIListScript()
		{
			if (this.mComUIListScript)
			{
				ComUIListScript comUIListScript = this.mComUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mComUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mComUIListScript;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mComUIListScript;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
				this.mComUIListScript = null;
			}
		}

		// Token: 0x06010819 RID: 67609 RVA: 0x004A5DBC File Offset: 0x004A41BC
		private void LoadAllEquip()
		{
			this.mAllEquips = DataManager<BlackMarketMerchantDataManager>.GetInstance().GetBackPackAllItem((int)this.mApplyTradData.mInfo.back_buy_item_id);
			this.SetElementAmount(this.mAllEquips.Count);
		}

		// Token: 0x0601081A RID: 67610 RVA: 0x004A5DEF File Offset: 0x004A41EF
		private void SetElementAmount(int Count)
		{
			if (this.mComUIListScript)
			{
				this.mComUIListScript.SetElementAmount(Count);
			}
		}

		// Token: 0x0601081B RID: 67611 RVA: 0x004A5E0D File Offset: 0x004A420D
		private BlackMarketMerchantTradeItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<BlackMarketMerchantTradeItem>();
		}

		// Token: 0x0601081C RID: 67612 RVA: 0x004A5E18 File Offset: 0x004A4218
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			BlackMarketMerchantTradeItem blackMarketMerchantTradeItem = item.gameObjectBindScript as BlackMarketMerchantTradeItem;
			if (blackMarketMerchantTradeItem != null && item.m_index >= 0 && item.m_index < this.mAllEquips.Count)
			{
				blackMarketMerchantTradeItem.OnItemVisiable(this.mAllEquips[item.m_index]);
			}
		}

		// Token: 0x0601081D RID: 67613 RVA: 0x004A5E78 File Offset: 0x004A4278
		private void OnItemSelectedDelegate(ComUIListElementScript item)
		{
			BlackMarketMerchantTradeItem blackMarketMerchantTradeItem = item.gameObjectBindScript as BlackMarketMerchantTradeItem;
			if (blackMarketMerchantTradeItem != null && this.mOnItemSelect != null)
			{
				this.mOnItemSelect(blackMarketMerchantTradeItem.GUID);
			}
		}

		// Token: 0x0601081E RID: 67614 RVA: 0x004A5EBC File Offset: 0x004A42BC
		private void OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			BlackMarketMerchantTradeItem blackMarketMerchantTradeItem = item.gameObjectBindScript as BlackMarketMerchantTradeItem;
			if (blackMarketMerchantTradeItem != null)
			{
				blackMarketMerchantTradeItem.OnItemChangeDisplay(bSelected);
			}
		}

		// Token: 0x0601081F RID: 67615 RVA: 0x004A5EE8 File Offset: 0x004A42E8
		private void UpdateInputPriceText(uint price)
		{
			this.mInputPrice.text = price.ToString();
		}

		// Token: 0x06010820 RID: 67616 RVA: 0x004A5F02 File Offset: 0x004A4302
		private void InitBtnCloseClick()
		{
			this.mCloseBtn.onClick.RemoveAllListeners();
			this.mCloseBtn.onClick.AddListener(new UnityAction(this.OnCloseClick));
		}

		// Token: 0x06010821 RID: 67617 RVA: 0x004A5F30 File Offset: 0x004A4330
		private void OnCloseClick()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<BlackMarketMerchantTradeFrame>(null, false);
		}

		// Token: 0x06010822 RID: 67618 RVA: 0x004A5F40 File Offset: 0x004A4340
		private void OnDestroy()
		{
			this.mApplyTradData = null;
			this.mOnItemSelect = null;
			this.mOnSetPrice = null;
			this.mOnConfirmClick = null;
			this.mAllEquips.Clear();
			this.iMinPrice = 0U;
			this.iMaxPrice = 0U;
			this.iInputNumber = 0U;
			this.UnInitComUIListScript();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChangeNum, new ClientEventSystem.UIEventHandler(this.OnChangeNumber));
		}

		// Token: 0x0400A7CB RID: 42955
		[Header("状态控制器")]
		[SerializeField]
		private StateController mStateControl;

		// Token: 0x0400A7CC RID: 42956
		[Header("固定价格状态")]
		[SerializeField]
		private string mBmtFixedPriceState;

		// Token: 0x0400A7CD RID: 42957
		[Header("竞拍价格状态")]
		[SerializeField]
		private string mBmtAuctionPriceState;

		// Token: 0x0400A7CE RID: 42958
		[SerializeField]
		private Text mBlackMarketMerchanName;

		// Token: 0x0400A7CF RID: 42959
		[SerializeField]
		private Text mPeopleDesc;

		// Token: 0x0400A7D0 RID: 42960
		[SerializeField]
		private Image mMerchantImage;

		// Token: 0x0400A7D1 RID: 42961
		[SerializeField]
		private Button mCloseBtn;

		// Token: 0x0400A7D2 RID: 42962
		[SerializeField]
		private Text mPrice;

		// Token: 0x0400A7D3 RID: 42963
		[SerializeField]
		private Text mRecommendPrice;

		// Token: 0x0400A7D4 RID: 42964
		[SerializeField]
		private Text mInputPrice;

		// Token: 0x0400A7D5 RID: 42965
		[SerializeField]
		private Button mInputBtn;

		// Token: 0x0400A7D6 RID: 42966
		[SerializeField]
		private Button mConFirmBtn;

		// Token: 0x0400A7D7 RID: 42967
		[SerializeField]
		private ComUIListScript mComUIListScript;

		// Token: 0x0400A7D8 RID: 42968
		[SerializeField]
		private GameObject mGoRecommendedRoot;

		// Token: 0x0400A7D9 RID: 42969
		private ApplyTradData mApplyTradData;

		// Token: 0x0400A7DA RID: 42970
		private OnItemSelect mOnItemSelect;

		// Token: 0x0400A7DB RID: 42971
		private OnSetPrice mOnSetPrice;

		// Token: 0x0400A7DC RID: 42972
		private UnityAction mOnConfirmClick;

		// Token: 0x0400A7DD RID: 42973
		private List<ItemData> mAllEquips = new List<ItemData>();

		// Token: 0x0400A7DE RID: 42974
		private uint iMinPrice;

		// Token: 0x0400A7DF RID: 42975
		private uint iMaxPrice;

		// Token: 0x0400A7E0 RID: 42976
		private uint iInputNumber;

		// Token: 0x0400A7E1 RID: 42977
		private bool ReenterPrice = true;
	}
}
