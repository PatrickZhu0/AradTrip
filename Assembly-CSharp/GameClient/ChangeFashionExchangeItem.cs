using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018DA RID: 6362
	public class ChangeFashionExchangeItem : ActivityItemBase
	{
		// Token: 0x0600F862 RID: 63586 RVA: 0x00437D70 File Offset: 0x00436170
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			OpActTaskState state = data.State;
			if (state != OpActTaskState.OATS_OVER)
			{
				if (state != OpActTaskState.OATS_FINISHED)
				{
					if (state == OpActTaskState.OATS_UNFINISH)
					{
						this.mFinishedGO.CustomActive(false);
						this.mNotFinishGO.CustomActive(true);
						this.mHasTakenReward.CustomActive(false);
					}
				}
				else
				{
					this.mFinishedGO.CustomActive(true);
					this.mNotFinishGO.CustomActive(false);
					this.mHasTakenReward.CustomActive(false);
				}
			}
			else
			{
				this.mNotFinishGO.CustomActive(false);
				this.mHasTakenReward.CustomActive(true);
				this.mFinishedGO.CustomActive(false);
			}
			if (data.State == OpActTaskState.OATS_OVER)
			{
				this.mTextExchangeCount.SafeSetText(string.Format(TR.Value("activity_coin_exchange_item_exchange_count"), 0, data.TotalNum));
			}
			else
			{
				this.mTextExchangeCount.SafeSetText(string.Format(TR.Value("activity_coin_exchange_item_exchange_count"), data.DoneNum, data.TotalNum));
			}
			int num = -1;
			int num2 = -1;
			int num3 = -1;
			if (data.ParamNums.Count > 1)
			{
				num = (int)data.ParamNums[0];
				num2 = (int)data.ParamNums[1];
				num3 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(num, true);
			}
			else if (data.CountParamNums.Count != 0)
			{
				num = (int)data.CountParamNums[0].currencyId;
				num2 = (int)data.CountParamNums[0].value;
				num3 = DataManager<CountDataManager>.GetInstance().GetCount(data.CountParamNums[0].name);
			}
			if (Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num, string.Empty, string.Empty) == null)
			{
				Logger.LogErrorFormat("扩展参数{0}在道具表中无法被找到", new object[0]);
				return;
			}
			ComItem comItem = this.mCoinRoot.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				ComItem comItem2 = ComItemManager.Create(this.mCoinRoot);
				comItem = comItem2;
			}
			ItemData ItemDetailData = ItemDataManager.CreateItemDataFromTable(num, 100, 0);
			if (ItemDetailData == null)
			{
				return;
			}
			ItemDetailData.Count = 1;
			comItem.Setup(ItemDetailData, delegate(GameObject Obj, ItemData sitem)
			{
				this._OnShowTips(ItemDetailData);
			});
			this.mTextCoinCount.SafeSetText(string.Format("/{0}", num2));
			this.mTextCoinOwnNum.SafeSetText(num3.ToString());
			if (num3 < num2)
			{
				this.mTextCoinOwnNum.color = Color.red;
			}
			else
			{
				this.mTextCoinOwnNum.color = Color.green;
			}
		}

		// Token: 0x0600F863 RID: 63587 RVA: 0x00438024 File Offset: 0x00436424
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
			this.mButtonExchange.SafeRemoveOnClickListener(new UnityAction(this._OnItemClick));
			this.mButtonExchangeBlue.SafeRemoveOnClickListener(new UnityAction(this._OnItemClick));
			this.mLookUpFashionBtn.SafeRemoveAllListener();
		}

		// Token: 0x0600F864 RID: 63588 RVA: 0x004380B8 File Offset: 0x004364B8
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data != null && data.AwardDataList != null)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)data.AwardDataList[0].id, string.Empty, string.Empty);
				if (tableItem.SubType != ItemTable.eSubType.GiftPackage)
				{
					this.mLookUpFashionBtn.CustomActive(false);
				}
				else
				{
					int rewardFirstId = (int)data.AwardDataList[0].id;
					this.mLookUpFashionBtn.CustomActive(true);
					this.mLookUpFashionBtn.SafeRemoveAllListener();
					this.mLookUpFashionBtn.SafeAddOnClickListener(delegate
					{
						this._ShowAvartar(rewardFirstId);
					});
				}
				for (int i = 0; i < data.AwardDataList.Count; i++)
				{
					ComItem comItem = ComItemManager.Create(this.mRewardItemRoot.gameObject);
					if (comItem != null)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)data.AwardDataList[i].id, 100, 0);
						itemData.Count = (int)data.AwardDataList[i].num;
						ComItem comItem2 = comItem;
						ItemData item = itemData;
						if (ChangeFashionExchangeItem.<>f__mg$cache0 == null)
						{
							ChangeFashionExchangeItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem2.Setup(item, ChangeFashionExchangeItem.<>f__mg$cache0);
						this.mComItems.Add(comItem);
						(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
					}
				}
				this.mAwardsScrollRect.enabled = (data.AwardDataList.Count > this.mScrollCount);
			}
			this.mButtonExchange.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
			this.mButtonExchangeBlue.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
		}

		// Token: 0x0600F865 RID: 63589 RVA: 0x0043826D File Offset: 0x0043666D
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x0600F866 RID: 63590 RVA: 0x00438288 File Offset: 0x00436688
		private void _ShowAvartar(int id)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PlayerTryOnFrame>(null))
			{
				PlayerTryOnFrame playerTryOnFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(PlayerTryOnFrame)) as PlayerTryOnFrame;
				if (playerTryOnFrame != null)
				{
					playerTryOnFrame.Reset(id);
				}
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<PlayerTryOnFrame>(FrameLayer.Middle, id, string.Empty);
			}
		}

		// Token: 0x04009993 RID: 39315
		[SerializeField]
		private Text mTextExchangeCount;

		// Token: 0x04009994 RID: 39316
		[SerializeField]
		private Image mImageCoinIcon;

		// Token: 0x04009995 RID: 39317
		[SerializeField]
		private Text mTextCoinCount;

		// Token: 0x04009996 RID: 39318
		[SerializeField]
		private Text mTextCoinOwnNum;

		// Token: 0x04009997 RID: 39319
		[SerializeField]
		private GameObject mCoinRoot;

		// Token: 0x04009998 RID: 39320
		[SerializeField]
		private Button mButtonExchange;

		// Token: 0x04009999 RID: 39321
		[SerializeField]
		private Button mButtonExchangeBlue;

		// Token: 0x0400999A RID: 39322
		[SerializeField]
		private RectTransform mRewardItemRoot;

		// Token: 0x0400999B RID: 39323
		[SerializeField]
		private ScrollRect mAwardsScrollRect;

		// Token: 0x0400999C RID: 39324
		[SerializeField]
		private GameObject mHasTakenReward;

		// Token: 0x0400999D RID: 39325
		[SerializeField]
		private GameObject mNotFinishGO;

		// Token: 0x0400999E RID: 39326
		[SerializeField]
		private GameObject mFinishedGO;

		// Token: 0x0400999F RID: 39327
		[SerializeField]
		private Button mLookUpFashionBtn;

		// Token: 0x040099A0 RID: 39328
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x040099A1 RID: 39329
		[SerializeField]
		private int mScrollCount = 5;

		// Token: 0x040099A2 RID: 39330
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x040099A3 RID: 39331
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
