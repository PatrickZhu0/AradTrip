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
	// Token: 0x020018D9 RID: 6361
	public class BuyPresentationItem : ActivityItemBase
	{
		// Token: 0x0600F85A RID: 63578 RVA: 0x0043754C File Offset: 0x0043594C
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			if (!this.mIsLeftMinus0)
			{
				this.mCanTakeReward.CustomActive(false);
				this.mButtonUnFinish.CustomActive(false);
				this.mHasTakenReward.CustomActive(false);
				switch (data.State)
				{
				case OpActTaskState.OATS_UNFINISH:
					this.mButtonUnFinish.CustomActive(true);
					break;
				case OpActTaskState.OATS_FINISHED:
					this.mCanTakeReward.CustomActive(true);
					break;
				case OpActTaskState.OATS_OVER:
					this.mHasTakenReward.CustomActive(true);
					break;
				}
			}
			else
			{
				this.mCanTakeReward.CustomActive(false);
				this.mButtonUnFinish.CustomActive(false);
				this.mHasTakenReward.CustomActive(true);
			}
			if (data.ParamNums.Count > 0 && data.ParamNums.Count == data.ParamNums2.Count && data.ParamNums2.Count == data.ParamProgress.Count)
			{
				for (int i = 0; i < this.mMaterialItemList.Count; i++)
				{
					ComCommonBind component = this.mMaterialItemList[i].GetComponent<ComCommonBind>();
					if (!(component == null))
					{
						Text com = component.GetCom<Text>("ItemCount");
						GameObject gameObject = component.GetGameObject("ItemFinished");
						int num = 0;
						for (int j = 0; j < data.ParamProgressList.Count; j++)
						{
							if (data.ParamProgressList[j].key == data.ParamProgress[i])
							{
								num = (int)data.ParamProgressList[j].value;
							}
						}
						int num2 = (int)data.ParamNums2[i];
						if (num >= num2)
						{
							gameObject.CustomActive(true);
							num = num2;
							com.color = Color.green;
						}
						else
						{
							gameObject.CustomActive(false);
							com.color = Color.white;
						}
						com.text = string.Format("{0}/{1}", num, num2);
					}
				}
			}
		}

		// Token: 0x0600F85B RID: 63579 RVA: 0x00437774 File Offset: 0x00435B74
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
			this.mIsLeftMinus0 = false;
			this.mData = null;
			this.mButtonTakeReward.SafeRemoveOnClickListener(new UnityAction(this._OnMyItemClick));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
		}

		// Token: 0x0600F85C RID: 63580 RVA: 0x0043780C File Offset: 0x00435C0C
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data.AwardDataList != null)
			{
				for (int i = 0; i < data.AwardDataList.Count; i++)
				{
					ComItem comItem = ComItemManager.Create(this.mRewardItemRoot.gameObject);
					if (comItem != null)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)data.AwardDataList[i].id, 100, 0);
						itemData.Count = (int)data.AwardDataList[i].num;
						ComItem comItem2 = comItem;
						ItemData item = itemData;
						if (BuyPresentationItem.<>f__mg$cache0 == null)
						{
							BuyPresentationItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem2.Setup(item, BuyPresentationItem.<>f__mg$cache0);
						this.mComItems.Add(comItem);
						(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
					}
				}
				this.mAwardsScrollRect.enabled = (data.AwardDataList.Count > this.mScrollCount);
			}
			this.mTextDescription.SafeSetText(data.Desc);
			this.mButtonTakeReward.SafeAddOnClickListener(new UnityAction(this._OnMyItemClick));
			this.mButtonUnFinish.onClick.RemoveAllListeners();
			this.mButtonUnFinish.onClick.AddListener(delegate()
			{
				MallNewFrame mallNewFrame = Singleton<ClientSystemManager>.instance.OpenFrame<MallNewFrame>(FrameLayer.Middle, new MallNewFrameParamData
				{
					MallNewType = MallNewType.LimitTimeMall
				}, string.Empty) as MallNewFrame;
			});
			if (data.ParamNums.Count > 0 && data.ParamNums.Count == data.ParamNums2.Count && data.ParamNums2.Count == data.ParamProgress.Count)
			{
				this.mMaterialItemList.Clear();
				for (int j = 0; j < data.ParamNums.Count; j++)
				{
					GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("UIFlatten/Prefabs/OperateActivity/LimitTime/Items/BuyPresentationMaterialItem", true, 0U);
					if (gameObject != null)
					{
						ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
						if (component == null)
						{
							Logger.LogErrorFormat("11111111", new object[0]);
						}
						else
						{
							GameObject gameObject2 = component.GetGameObject("ItemRoot");
							ComItem comItem3 = ComItemManager.Create(gameObject2);
							if (comItem3 == null)
							{
								Logger.LogErrorFormat("22222222222", new object[0]);
							}
							else
							{
								MallItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallItemTable>((int)data.ParamNums[j], string.Empty, string.Empty);
								if (tableItem == null)
								{
									Logger.LogErrorFormat("33333333333333", new object[0]);
								}
								else
								{
									string s = tableItem.giftpackitems.Split(new char[]
									{
										':'
									})[0];
									int num = -1;
									int.TryParse(s, out num);
									if (num == -1)
									{
										Logger.LogErrorFormat("4444444444444444", new object[0]);
									}
									else
									{
										ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(num, 100, 0);
										if (itemData2 == null)
										{
											Logger.LogErrorFormat("5555555555555", new object[0]);
										}
										else
										{
											ComItem comItem4 = comItem3;
											ItemData item2 = itemData2;
											if (BuyPresentationItem.<>f__mg$cache1 == null)
											{
												BuyPresentationItem.<>f__mg$cache1 = new ComItem.OnItemClicked(Utility.OnItemClicked);
											}
											comItem4.Setup(item2, BuyPresentationItem.<>f__mg$cache1);
											this.mComItems.Add(comItem3);
											(comItem3.transform as RectTransform).sizeDelta = this.mComItemSize;
											Utility.AttachTo(gameObject, this.mMaterialRoot, false);
											this.mMaterialItemList.Add(gameObject);
										}
									}
								}
							}
						}
					}
				}
			}
			this.mData = data;
			this.ShowHaveUsedNumState(data);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
		}

		// Token: 0x0600F85D RID: 63581 RVA: 0x00437B84 File Offset: 0x00435F84
		private void _OnMyItemClick()
		{
			this._OnItemClick();
			if (this.mData != null)
			{
				if (this.mData.AccountDailySubmitLimit > 0)
				{
					DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq((int)this.mData.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_SUBMIT_TASK);
				}
				if (this.mData.AccountTotalSubmitLimit > 0)
				{
					DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq((int)this.mData.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK);
				}
			}
		}

		// Token: 0x0600F85E RID: 63582 RVA: 0x00437BF8 File Offset: 0x00435FF8
		private void _OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mData != null && (uint)uiEvent.Param1 == this.mData.DataId)
			{
				this.ShowHaveUsedNumState(this.mData);
			}
		}

		// Token: 0x0600F85F RID: 63583 RVA: 0x00437C2C File Offset: 0x0043602C
		private void ShowHaveUsedNumState(ILimitTimeActivityTaskDataModel data)
		{
			if (data != null)
			{
				int num = 0;
				int num2 = 0;
				if (data.AccountDailySubmitLimit > 0)
				{
					num2 = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(data.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_SUBMIT_TASK);
					num = data.AccountDailySubmitLimit;
				}
				else if (data.AccountTotalSubmitLimit > 0)
				{
					num2 = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(data.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK);
					num = data.AccountTotalSubmitLimit;
				}
				int num3 = num - num2;
				if (num3 <= 0 && num > 0)
				{
					this.mCanTakeReward.CustomActive(false);
					this.mButtonUnFinish.CustomActive(false);
					this.mHasTakenReward.CustomActive(true);
					this.mIsLeftMinus0 = true;
					num3 = 0;
				}
				this.mAccountLimitTxt.CustomActive(num > 0);
				this.mAccountLimitTxt.SafeSetText(string.Format(TR.Value("ConsumeRebate_AccountLimt_Content"), num3, num));
			}
		}

		// Token: 0x0400997E RID: 39294
		[SerializeField]
		private Text mTextDescription;

		// Token: 0x0400997F RID: 39295
		[SerializeField]
		private RectTransform mRewardItemRoot;

		// Token: 0x04009980 RID: 39296
		[SerializeField]
		private GameObject mMaterialRoot;

		// Token: 0x04009981 RID: 39297
		[SerializeField]
		private Button mButtonUnFinish;

		// Token: 0x04009982 RID: 39298
		[SerializeField]
		private Button mButtonTakeReward;

		// Token: 0x04009983 RID: 39299
		[SerializeField]
		private GameObject mHasTakenReward;

		// Token: 0x04009984 RID: 39300
		[SerializeField]
		private GameObject mUnFinish;

		// Token: 0x04009985 RID: 39301
		[SerializeField]
		private GameObject mCanTakeReward;

		// Token: 0x04009986 RID: 39302
		[SerializeField]
		private ScrollRect mAwardsScrollRect;

		// Token: 0x04009987 RID: 39303
		[SerializeField]
		private Text mBuyDes;

		// Token: 0x04009988 RID: 39304
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x04009989 RID: 39305
		[SerializeField]
		private int mScrollCount = 5;

		// Token: 0x0400998A RID: 39306
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x0400998B RID: 39307
		private const string buyPresentationMaterialItemPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/BuyPresentationMaterialItem";

		// Token: 0x0400998C RID: 39308
		private List<GameObject> mMaterialItemList = new List<GameObject>();

		// Token: 0x0400998D RID: 39309
		[SerializeField]
		private Text mAccountLimitTxt;

		// Token: 0x0400998E RID: 39310
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x0400998F RID: 39311
		private bool mIsLeftMinus0;

		// Token: 0x04009990 RID: 39312
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;

		// Token: 0x04009991 RID: 39313
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache1;
	}
}
