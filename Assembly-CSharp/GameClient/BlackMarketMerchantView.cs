using System;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A42 RID: 6722
	internal class BlackMarketMerchantView : MonoBehaviour
	{
		// Token: 0x06010826 RID: 67622 RVA: 0x004A5FE8 File Offset: 0x004A43E8
		public void InitView(BlackMarketMerchantDataModel mModel, OnApplyTradDelegate mOnApplyTradDelegate, OnCancelApplyDelegate mOnCancelApplyDelegate)
		{
			this.mDataModel = mModel;
			this.mOnApplyTradDelegate = mOnApplyTradDelegate;
			this.mOnCancelApplyDelegate = mOnCancelApplyDelegate;
			BlackMarketTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BlackMarketTable>((int)this.mDataModel.mBlackMarketType, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("[BlackMarketTable] 黑市商人表中未找到ID id={0}", new object[]
				{
					(int)this.mDataModel.mBlackMarketType
				});
			}
			this.UpdatePeopleDesc();
			ETCImageLoader.LoadSprite(ref this.mMerchantImage, tableItem.NpcPortrait, true);
			this.mMerchantImage.SetNativeSize();
			this.InitComUIListScript();
			this.InitBtnCloseClick();
			this.SetElementAmount(this.mDataModel.mBlackMarketAuctionInfoList.Count);
		}

		// Token: 0x06010827 RID: 67623 RVA: 0x004A6099 File Offset: 0x004A4499
		public void RefreshItemInfoList(BlackMarketMerchantDataModel mModel)
		{
			this.mDataModel = mModel;
			this.SetElementAmount(this.mDataModel.mBlackMarketAuctionInfoList.Count);
		}

		// Token: 0x06010828 RID: 67624 RVA: 0x004A60B8 File Offset: 0x004A44B8
		private void InitComUIListScript()
		{
			if (this.mComUIListScript)
			{
				this.mComUIListScript.Initialize();
				ComUIListScript comUIListScript = this.mComUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mComUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x06010829 RID: 67625 RVA: 0x004A6130 File Offset: 0x004A4530
		private void UnInitComUIListScript()
		{
			if (this.mComUIListScript)
			{
				ComUIListScript comUIListScript = this.mComUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mComUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				this.mComUIListScript = null;
			}
		}

		// Token: 0x0601082A RID: 67626 RVA: 0x004A61A2 File Offset: 0x004A45A2
		private void SetElementAmount(int Count)
		{
			if (this.mComUIListScript)
			{
				this.mComUIListScript.SetElementAmount(Count);
			}
		}

		// Token: 0x0601082B RID: 67627 RVA: 0x004A61C0 File Offset: 0x004A45C0
		private BlackMarketMerchantItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<BlackMarketMerchantItem>();
		}

		// Token: 0x0601082C RID: 67628 RVA: 0x004A61C8 File Offset: 0x004A45C8
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			BlackMarketMerchantItem blackMarketMerchantItem = item.gameObjectBindScript as BlackMarketMerchantItem;
			if (blackMarketMerchantItem != null && item.m_index >= 0 && item.m_index < this.mDataModel.mBlackMarketAuctionInfoList.Count)
			{
				BlackMarketAuctionInfo mItemInfo = this.mDataModel.mBlackMarketAuctionInfoList[item.m_index];
				blackMarketMerchantItem.UpdateBlackMarketMerchantItem(mItemInfo, this.mDataModel.mBlackMarketType, this.mOnApplyTradDelegate, this.mOnCancelApplyDelegate);
			}
		}

		// Token: 0x0601082D RID: 67629 RVA: 0x004A624C File Offset: 0x004A464C
		public void UpdatePeopleDesc()
		{
			OpActivityData opActivityData = DataManager<ActivityDataManager>.GetInstance()._GetBlackMarketMerchantOpActivityData();
			if (opActivityData != null)
			{
				BlackMarketTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BlackMarketTable>((int)this.mDataModel.mBlackMarketType, string.Empty, string.Empty);
				if (tableItem != null)
				{
					NpcTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(tableItem.NpcID, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						this.mPeopleDesc.text = string.Format("{0}:\n{1}", tableItem2.NpcName, opActivityData.ruleDesc);
					}
					this.mTransactionTypeDesc.text = tableItem.TransactionTypeDescribe;
				}
			}
		}

		// Token: 0x0601082E RID: 67630 RVA: 0x004A62E3 File Offset: 0x004A46E3
		private void InitBtnCloseClick()
		{
			this.mCloseBtn.onClick.RemoveAllListeners();
			this.mCloseBtn.onClick.AddListener(new UnityAction(this.OnCloseClick));
		}

		// Token: 0x0601082F RID: 67631 RVA: 0x004A6311 File Offset: 0x004A4711
		private void OnCloseClick()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<BlackMarketMerchantFrame>(null, false);
		}

		// Token: 0x06010830 RID: 67632 RVA: 0x004A631F File Offset: 0x004A471F
		private void OnDestroy()
		{
			this.mDataModel = null;
			this.mOnApplyTradDelegate = null;
			this.mOnCancelApplyDelegate = null;
			this.UnInitComUIListScript();
		}

		// Token: 0x0400A7E2 RID: 42978
		[SerializeField]
		private Text mPeopleDesc;

		// Token: 0x0400A7E3 RID: 42979
		[SerializeField]
		private Image mMerchantImage;

		// Token: 0x0400A7E4 RID: 42980
		[SerializeField]
		private Button mCloseBtn;

		// Token: 0x0400A7E5 RID: 42981
		[SerializeField]
		private ComUIListScript mComUIListScript;

		// Token: 0x0400A7E6 RID: 42982
		[SerializeField]
		private Text mTransactionTypeDesc;

		// Token: 0x0400A7E7 RID: 42983
		private BlackMarketMerchantDataModel mDataModel;

		// Token: 0x0400A7E8 RID: 42984
		private OnApplyTradDelegate mOnApplyTradDelegate;

		// Token: 0x0400A7E9 RID: 42985
		private OnCancelApplyDelegate mOnCancelApplyDelegate;
	}
}
