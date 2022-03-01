using System;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A3B RID: 6715
	internal class BlackMarketMerchantItem : MonoBehaviour
	{
		// Token: 0x060107E7 RID: 67559 RVA: 0x004A4F10 File Offset: 0x004A3310
		private void Awake()
		{
			this.mApplyTradBtn.onClick.RemoveAllListeners();
			this.mApplyTradBtn.onClick.AddListener(new UnityAction(this.OnApplyTradClick));
			this.mCancelApplyBtn.onClick.RemoveAllListeners();
			this.mCancelApplyBtn.onClick.AddListener(new UnityAction(this.OnCancelApplyClick));
		}

		// Token: 0x060107E8 RID: 67560 RVA: 0x004A4F75 File Offset: 0x004A3375
		public void UpdateBlackMarketMerchantItem(BlackMarketAuctionInfo mItemInfo, BlackMarketType type, OnApplyTradDelegate mOnApplyTradDelegate, OnCancelApplyDelegate mOnCancelApplyDelegate)
		{
			this.mItemInfo = mItemInfo;
			this.mBlackMarketMerchantType = type;
			this.mOnApplyTradDelegate = mOnApplyTradDelegate;
			this.mOnCancelApplyDelegate = mOnCancelApplyDelegate;
			this.InitItemInfo();
			this.UpdateState();
		}

		// Token: 0x060107E9 RID: 67561 RVA: 0x004A4FA0 File Offset: 0x004A33A0
		private void InitItemInfo()
		{
			if (this.mItemInfo == null)
			{
				Logger.LogErrorFormat("黑市商人回购道具信息[BlackMarketBackBuyItemInfo] 为空", new object[0]);
				return;
			}
			ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID((int)this.mItemInfo.back_buy_item_id);
			if (commonItemTableDataByID == null)
			{
				Logger.LogErrorFormat("脚本[BlackMarketMerchantItem] 中 [InitItemInfo]函数创建道具Itemdata为空", new object[0]);
			}
			if (this.mComItem == null)
			{
				this.mComItem = ComItemManager.Create(this.mItemParent);
			}
			ComItem comItem = this.mComItem;
			ItemData item = commonItemTableDataByID;
			if (BlackMarketMerchantItem.<>f__mg$cache0 == null)
			{
				BlackMarketMerchantItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(item, BlackMarketMerchantItem.<>f__mg$cache0);
			this.mName.text = commonItemTableDataByID.GetColorName(string.Empty, false);
			if (this.mItemInfo.back_buy_type == 1)
			{
				this.mPrice.text = this.mItemInfo.price.ToString();
			}
			else if (this.mItemInfo.recommend_price > 0U)
			{
				this.mPrice.text = DataManager<BlackMarketMerchantDataManager>.GetInstance().SwichQuestionMarkCharacter(this.mItemInfo.recommend_price.ToString().Length);
			}
			else
			{
				this.mPrice.text = DataManager<BlackMarketMerchantDataManager>.GetInstance().SwichQuestionMarkCharacter(this.mItemInfo.price_upper_limit.ToString().Length);
			}
			this.mQuotedPrice.text = this.mItemInfo.auction_price.ToString();
			Text text = this.mHaveAppliedName;
			string text2 = string.Format("({0})", this.mItemInfo.auctioner_name);
			this.mHaveBeenTradName.text = text2;
			text.text = text2;
		}

		// Token: 0x060107EA RID: 67562 RVA: 0x004A5154 File Offset: 0x004A3554
		private void UpdateState()
		{
			switch (this.mItemInfo.state)
			{
			case 1:
			{
				bool flag = DataManager<BlackMarketMerchantDataManager>.GetInstance().FindBackPackBuyBackItem((int)this.mItemInfo.back_buy_item_id);
				if (flag)
				{
					this.mStateContrl.Key = this.mCanApplyFor;
				}
				else
				{
					this.mStateContrl.Key = this.mBackpackNoacQuisitionProps;
				}
				break;
			}
			case 2:
				if (DataManager<PlayerBaseData>.GetInstance().RoleID == this.mItemInfo.auctioner_guid)
				{
					if (this.mItemInfo.back_buy_type == 1)
					{
						this.mStateContrl.Key = this.mFixedPriceCancelApplyFor;
					}
					else
					{
						this.mStateContrl.Key = this.mCancelApplyFor;
					}
				}
				else
				{
					this.mStateContrl.Key = this.mHaveApplied;
				}
				break;
			case 3:
				this.mStateContrl.Key = this.mHaveBeenTrading;
				break;
			}
		}

		// Token: 0x060107EB RID: 67563 RVA: 0x004A5268 File Offset: 0x004A3668
		private void OnApplyTradClick()
		{
			ApplyTradData applyTradData = new ApplyTradData();
			applyTradData.mInfo = this.mItemInfo;
			applyTradData.mMerchantType = this.mBlackMarketMerchantType;
			if (this.mOnApplyTradDelegate != null)
			{
				this.mOnApplyTradDelegate(applyTradData);
			}
		}

		// Token: 0x060107EC RID: 67564 RVA: 0x004A52AA File Offset: 0x004A36AA
		private void OnCancelApplyClick()
		{
			if (this.mOnCancelApplyDelegate != null)
			{
				this.mOnCancelApplyDelegate(this.mItemInfo);
			}
		}

		// Token: 0x060107ED RID: 67565 RVA: 0x004A52C8 File Offset: 0x004A36C8
		private void OnDestroy()
		{
			this.mItemInfo = null;
			this.mBlackMarketMerchantType = BlackMarketType.BmtInvalid;
			this.mOnApplyTradDelegate = null;
			this.mOnCancelApplyDelegate = null;
		}

		// Token: 0x0400A7A5 RID: 42917
		[Header("状态控制器")]
		[SerializeField]
		private StateController mStateContrl;

		// Token: 0x0400A7A6 RID: 42918
		[Header("背包里无收购道具")]
		[SerializeField]
		private string mBackpackNoacQuisitionProps;

		// Token: 0x0400A7A7 RID: 42919
		[Space(2f)]
		[Header("可申请交易")]
		[SerializeField]
		private string mCanApplyFor;

		// Token: 0x0400A7A8 RID: 42920
		[Space(2f)]
		[Header("取消申请")]
		[SerializeField]
		private string mCancelApplyFor;

		// Token: 0x0400A7A9 RID: 42921
		[Space(2f)]
		[Header("固定价格取消申请")]
		[SerializeField]
		private string mFixedPriceCancelApplyFor;

		// Token: 0x0400A7AA RID: 42922
		[Space(2f)]
		[Header("已申请")]
		[SerializeField]
		private string mHaveApplied;

		// Token: 0x0400A7AB RID: 42923
		[Space(2f)]
		[Header("已交易")]
		[SerializeField]
		private string mHaveBeenTrading;

		// Token: 0x0400A7AC RID: 42924
		[Space(5f)]
		[SerializeField]
		private Text mName;

		// Token: 0x0400A7AD RID: 42925
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400A7AE RID: 42926
		[SerializeField]
		private Image mTickIcon;

		// Token: 0x0400A7AF RID: 42927
		[SerializeField]
		private Text mPrice;

		// Token: 0x0400A7B0 RID: 42928
		[SerializeField]
		private Image mQuotedPriceIcon;

		// Token: 0x0400A7B1 RID: 42929
		[SerializeField]
		private Text mQuotedPrice;

		// Token: 0x0400A7B2 RID: 42930
		[SerializeField]
		private Button mApplyTradBtn;

		// Token: 0x0400A7B3 RID: 42931
		[SerializeField]
		private Button mCancelApplyBtn;

		// Token: 0x0400A7B4 RID: 42932
		[Header("已申请的名字")]
		[SerializeField]
		private Text mHaveAppliedName;

		// Token: 0x0400A7B5 RID: 42933
		[Header("已交易的名字")]
		[SerializeField]
		private Text mHaveBeenTradName;

		// Token: 0x0400A7B6 RID: 42934
		private BlackMarketAuctionInfo mItemInfo;

		// Token: 0x0400A7B7 RID: 42935
		private BlackMarketType mBlackMarketMerchantType;

		// Token: 0x0400A7B8 RID: 42936
		private OnApplyTradDelegate mOnApplyTradDelegate;

		// Token: 0x0400A7B9 RID: 42937
		private OnCancelApplyDelegate mOnCancelApplyDelegate;

		// Token: 0x0400A7BA RID: 42938
		private ComItem mComItem;

		// Token: 0x0400A7BB RID: 42939
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
