using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014DA RID: 5338
	public class ChampionshipGiftbagActivityView : MonoBehaviour
	{
		// Token: 0x0600CF0C RID: 53004 RVA: 0x003311F8 File Offset: 0x0032F5F8
		private void Awake()
		{
			if (this.mQuizzesActivityBtn != null)
			{
				this.mQuizzesActivityBtn.onClick.RemoveAllListeners();
				this.mQuizzesActivityBtn.onClick.AddListener(new UnityAction(this.OnQuizzesActivityBtnClick));
			}
			if (this.mShopBtn != null)
			{
				this.mShopBtn.onClick.RemoveAllListeners();
				this.mShopBtn.onClick.AddListener(new UnityAction(this.OnShopBtnClick));
			}
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.onClick.RemoveAllListeners();
				this.mReceiveBtn.onClick.AddListener(new UnityAction(this.OnReceiveBtnClick));
			}
			if (this.mGiftBuyBtn != null)
			{
				this.mGiftBuyBtn.onClick.RemoveAllListeners();
				this.mGiftBuyBtn.onClick.AddListener(new UnityAction(this.OnGiftBuyBtnClick));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeTaskDataUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityLimitTimeTaskDataUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityCounterUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipStatusMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipStatusMessage));
		}

		// Token: 0x0600CF0D RID: 53005 RVA: 0x00331368 File Offset: 0x0032F768
		private void OnDestroy()
		{
			this.ClearData();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeTaskDataUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityLimitTimeTaskDataUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityCounterUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipStatusMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipStatusMessage));
		}

		// Token: 0x0600CF0E RID: 53006 RVA: 0x003313E8 File Offset: 0x0032F7E8
		private void ClearData()
		{
			this.mDataModel = null;
			this.mMallType = MallTypeTable.eMallType.MallType_None;
			if (this.mMallItemInfoList != null)
			{
				this.mMallItemInfoList.Clear();
			}
			this.mMallItemInfoList = null;
			this.mMallItemInfo = null;
			this.mTaskDataModel = null;
			this.mOnItemClick = null;
			if (this.mQuizzesActivityBtn != null)
			{
				this.mQuizzesActivityBtn.onClick.RemoveListener(new UnityAction(this.OnQuizzesActivityBtnClick));
			}
			if (this.mShopBtn != null)
			{
				this.mShopBtn.onClick.RemoveListener(new UnityAction(this.OnShopBtnClick));
			}
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.onClick.RemoveListener(new UnityAction(this.OnReceiveBtnClick));
			}
			if (this.mGiftBuyBtn != null)
			{
				this.mGiftBuyBtn.onClick.RemoveListener(new UnityAction(this.OnGiftBuyBtnClick));
			}
		}

		// Token: 0x0600CF0F RID: 53007 RVA: 0x003314E9 File Offset: 0x0032F8E9
		private void OnQuizzesActivityBtnClick()
		{
			ChampionshipUtility.OnOpenChampionshipGuessFrame();
		}

		// Token: 0x0600CF10 RID: 53008 RVA: 0x003314F0 File Offset: 0x0032F8F0
		private void OnShopBtnClick()
		{
			ChampionshipUtility.OnOpenChampionshipGuessShop();
		}

		// Token: 0x0600CF11 RID: 53009 RVA: 0x003314F8 File Offset: 0x0032F8F8
		public void InitView(ILimitTimeActivityModel dataModel, MallTypeTable.eMallType mallType, List<MallItemInfo> mallItemInfo, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			this.mDataModel = dataModel;
			this.mMallType = mallType;
			this.mMallItemInfoList = mallItemInfo;
			this.mOnItemClick = onItemClick;
			if (this.mGiftbagTime != null)
			{
				this.mGiftbagTime.text = Function.GetTimeWithoutYearMonthDay((int)this.mDataModel.StartTime, (int)this.mDataModel.EndTime);
			}
			ChampionTimeTable championshipSignUpTime = ChampionshipUtility.GetChampionshipSignUpTime();
			if (championshipSignUpTime != null)
			{
				int timeStamp = Function.GetTimeStamp(Function.GetDateTime(championshipSignUpTime.StartTime, "yyyy-MM-dd HH:mm:ss"));
				int timeStamp2 = Function.GetTimeStamp(Function.GetDateTime(championshipSignUpTime.EndTime, "yyyy-MM-dd HH:mm:ss"));
				if (this.mSignupTime != null)
				{
					this.mSignupTime.text = Function.GetTimeWithoutYearMonthDay(timeStamp, timeStamp2);
				}
			}
			if (this.mCommonMoneyControl != null)
			{
				this.mCommonMoneyControl.InitMoneyItem(330000271, true, CounterKeys.COUNTER_CHAMPIONSHIP_GUESS_ITEM);
			}
			this.InitQuizzesActivityBtnStatus();
			this.InitBigRewardControl();
			this.InitLeftItemInfo();
			this.InitElementLeftTimes();
			this.UpdateRightGiftItemInfo();
		}

		// Token: 0x0600CF12 RID: 53010 RVA: 0x003315FC File Offset: 0x0032F9FC
		private void InitQuizzesActivityBtnStatus()
		{
			bool flag = ChampionshipUtility.IsChampionshipCanGuess();
			if (this.mOngoingGo != null)
			{
				this.mOngoingGo.CustomActive(false);
			}
			if (this.mNotStartGo != null)
			{
				this.mNotStartGo.CustomActive(false);
			}
			if (flag)
			{
				if (this.mOngoingGo != null)
				{
					this.mOngoingGo.CustomActive(true);
				}
				if (this.mQuizzesActivityBtn != null)
				{
					this.mQuizzesActivityBtn.enabled = true;
				}
			}
			else
			{
				if (this.mNotStartGo != null)
				{
					this.mNotStartGo.CustomActive(true);
				}
				if (this.mQuizzesActivityBtn != null)
				{
					this.mQuizzesActivityBtn.enabled = false;
				}
			}
		}

		// Token: 0x0600CF13 RID: 53011 RVA: 0x003316C8 File Offset: 0x0032FAC8
		private void InitBigRewardControl()
		{
			if (this.mBigRewardControl != null)
			{
				this.mBigRewardControl.InitControl();
				this.mBigRewardControl.SetScheduleId(DataManager<ChampionshipDataManager>.GetInstance().ChampionshipScheduleId);
			}
		}

		// Token: 0x0600CF14 RID: 53012 RVA: 0x003316FC File Offset: 0x0032FAFC
		private void InitLeftItemInfo()
		{
			if (this.mDataModel == null)
			{
				return;
			}
			if (this.mDataModel.TaskDatas.Count > 0)
			{
				this.mTaskDataModel = this.mDataModel.TaskDatas[0];
				if (this.mTaskDataModel == null)
				{
					return;
				}
				if (this.mTaskName != null)
				{
					this.mTaskName.text = this.mTaskDataModel.taskName;
				}
				if (this.mTaskDataModel.AwardDataList.Count > 0)
				{
					OpTaskReward opTaskReward = this.mTaskDataModel.AwardDataList[0];
					if (opTaskReward == null)
					{
						return;
					}
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)opTaskReward.id, 100, 0);
					itemData.Count = (int)opTaskReward.num;
					if (this.mTaskItemBackground != null)
					{
						ETCImageLoader.LoadSprite(ref this.mTaskItemBackground, itemData.GetQualityInfo().Background, true);
					}
					if (this.mTaskItemIcon != null)
					{
						ETCImageLoader.LoadSprite(ref this.mTaskItemIcon, itemData.Icon, true);
					}
					if (this.mTaskItemCount != null)
					{
						this.mTaskItemCount.text = itemData.Count.ToString();
					}
					if (this.mTaskItemIconBtn != null)
					{
						this.mTaskItemIconBtn.onClick.RemoveAllListeners();
						this.mTaskItemIconBtn.onClick.AddListener(delegate()
						{
							DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
						});
					}
				}
				this.UpdateLeftItemReceiveState();
				this.OnSendSceneOpActivityGetCounterReq();
			}
		}

		// Token: 0x0600CF15 RID: 53013 RVA: 0x003318A4 File Offset: 0x0032FCA4
		private void UpdateLeftItemReceiveState()
		{
			if (this.mTaskDataModel == null)
			{
				return;
			}
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.enabled = false;
			}
			if (this.mReceiveUIGray != null)
			{
				this.mReceiveUIGray.enabled = true;
			}
			OpActTaskState state = this.mTaskDataModel.State;
			if (state != OpActTaskState.OATS_UNFINISH && state != OpActTaskState.OATS_OVER)
			{
				if (state == OpActTaskState.OATS_FINISHED)
				{
					if (this.mReceiveBtn != null)
					{
						this.mReceiveBtn.enabled = true;
					}
					if (this.mReceiveUIGray != null)
					{
						this.mReceiveUIGray.enabled = false;
					}
				}
			}
		}

		// Token: 0x0600CF16 RID: 53014 RVA: 0x00331961 File Offset: 0x0032FD61
		private void OnReceiveBtnClick()
		{
			if (this.mTaskDataModel != null)
			{
				if (this.mOnItemClick != null)
				{
					this.mOnItemClick((int)this.mTaskDataModel.DataId, 0, 0UL);
				}
				this.OnSendSceneOpActivityGetCounterReq();
			}
		}

		// Token: 0x0600CF17 RID: 53015 RVA: 0x00331998 File Offset: 0x0032FD98
		private void OnSendSceneOpActivityGetCounterReq()
		{
			if (this.mTaskDataModel != null && this.mTaskDataModel.AccountDailySubmitLimit > 0)
			{
				DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq((int)this.mTaskDataModel.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_SUBMIT_TASK);
			}
		}

		// Token: 0x0600CF18 RID: 53016 RVA: 0x003319D0 File Offset: 0x0032FDD0
		private void OnActivityLimitTimeTaskDataUpdate(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			LimitTimeActivityTaskUpdateData limitTimeActivityTaskUpdateData = uiEvent.Param1 as LimitTimeActivityTaskUpdateData;
			if (limitTimeActivityTaskUpdateData == null)
			{
				return;
			}
			if (limitTimeActivityTaskUpdateData.ActivityId != 50005)
			{
				return;
			}
			OpActivityData limitTimeActivityData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(50005U);
			if (limitTimeActivityData != null)
			{
				this.mDataModel = new LimitTimeActivityModel(limitTimeActivityData, string.Empty, null, null, null);
				if (this.mDataModel.TaskDatas.Count > 0)
				{
					this.mTaskDataModel = this.mDataModel.TaskDatas[0];
					this.UpdateLeftItemReceiveState();
					this.OnSendSceneOpActivityGetCounterReq();
				}
			}
		}

		// Token: 0x0600CF19 RID: 53017 RVA: 0x00331A76 File Offset: 0x0032FE76
		private void OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mTaskDataModel != null && (uint)uiEvent.Param1 == this.mTaskDataModel.DataId)
			{
				this.ShowAccountDailySubmitLimitNumState(this.mTaskDataModel);
			}
		}

		// Token: 0x0600CF1A RID: 53018 RVA: 0x00331AAA File Offset: 0x0032FEAA
		private void OnReceiveChampionshipStatusMessage(UIEvent uiEvent)
		{
			this.UpdateBuyButtonStatue();
		}

		// Token: 0x0600CF1B RID: 53019 RVA: 0x00331AB4 File Offset: 0x0032FEB4
		private void ShowAccountDailySubmitLimitNumState(ILimitTimeActivityTaskDataModel taskData)
		{
			if (taskData != null)
			{
				int num = 0;
				int num2 = 0;
				if (taskData.AccountDailySubmitLimit > 0)
				{
					num2 = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(taskData.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_SUBMIT_TASK);
					num = taskData.AccountDailySubmitLimit;
				}
				int num3 = num - num2;
				if (num3 <= 0 && num > 0)
				{
					if (this.mReceiveBtn != null)
					{
						this.mReceiveBtn.enabled = false;
					}
					if (this.mReceiveUIGray != null)
					{
						this.mReceiveUIGray.enabled = true;
					}
					num3 = 0;
				}
				if (this.mTaskDesc != null)
				{
					this.mTaskDesc.text = string.Format("{0}：{1}/{2}", taskData.Desc, num3, num);
				}
			}
		}

		// Token: 0x0600CF1C RID: 53020 RVA: 0x00331B7A File Offset: 0x0032FF7A
		public void UpdateRightGiftItemStatus(List<MallItemInfo> mallItemInfoList)
		{
			this.mMallItemInfoList = mallItemInfoList;
			this.UpdateRightGiftItemInfo();
		}

		// Token: 0x0600CF1D RID: 53021 RVA: 0x00331B8C File Offset: 0x0032FF8C
		private void UpdateRightGiftItemInfo()
		{
			if (this.mMallItemInfoList != null && this.mMallItemInfoList.Count > 0)
			{
				this.mMallItemInfo = this.mMallItemInfoList[0];
			}
			if (this.mMallItemInfo != null)
			{
				if (this.mGiftName != null)
				{
					this.mGiftName.text = this.mMallItemInfo.giftName;
				}
				if (this.mMallItemInfo.giftItems.Length > 0)
				{
					ItemReward itemReward = this.mMallItemInfo.giftItems[0];
					if (itemReward != null)
					{
						ItemData itemdata = ItemDataManager.CreateItemDataFromTable((int)itemReward.id, 100, 0);
						itemdata.Count = (int)itemReward.num;
						if (this.mGiftBackground != null)
						{
							ETCImageLoader.LoadSprite(ref this.mGiftBackground, itemdata.GetQualityInfo().Background, true);
						}
						if (this.mGiftIcon != null)
						{
							ETCImageLoader.LoadSprite(ref this.mGiftIcon, itemdata.Icon, true);
						}
						if (this.mGiftIconBtn != null)
						{
							this.mGiftIconBtn.onClick.RemoveAllListeners();
							this.mGiftIconBtn.onClick.AddListener(delegate()
							{
								DataManager<ItemTipManager>.GetInstance().ShowTip(itemdata, null, 4, true, false, true);
							});
						}
						string value = "购买即得";
						string value2 = "，";
						int num = this.mMallItemInfo.giftDesc.IndexOf(value);
						int num2 = this.mMallItemInfo.giftDesc.IndexOf(value2);
						int length = num2 - (num + 4);
						string text = this.mMallItemInfo.giftDesc.Substring(num + 4, length);
						if (this.mGiftCoinCount != null)
						{
							this.mGiftCoinCount.text = text;
						}
					}
				}
				this.UpdateAccountNumberLimit(-1);
				this.InitGiftBuyButtonContent();
				this.UpdateBuyButtonStatue();
			}
		}

		// Token: 0x0600CF1E RID: 53022 RVA: 0x00331D64 File Offset: 0x00330164
		private void InitGiftBuyButtonContent()
		{
			if (this.mMallItemInfo == null)
			{
				return;
			}
			int mallRealPrice = Utility.GetMallRealPrice(this.mMallItemInfo);
			if (this.mPrice.text != null)
			{
				this.mPrice.text = mallRealPrice.ToString();
			}
			if (this.mConsumeIcon != null)
			{
				ItemTable costItemTableByCostType = DataManager<MallNewDataManager>.GetInstance().GetCostItemTableByCostType(this.mMallItemInfo.moneytype);
				if (costItemTableByCostType != null)
				{
					ETCImageLoader.LoadSprite(ref this.mConsumeIcon, costItemTableByCostType.Icon, true);
				}
				else
				{
					Logger.LogErrorFormat("CostItemTable is null and moneyType is {0}", new object[]
					{
						this.mMallItemInfo.moneytype
					});
				}
			}
		}

		// Token: 0x0600CF1F RID: 53023 RVA: 0x00331E1C File Offset: 0x0033021C
		private void UpdateBuyButtonStatue()
		{
			bool flag = ChampionshipUtility.IsChampionshipStart();
			if (flag)
			{
				if (this.mBuyDescGo != null)
				{
					this.mBuyDescGo.CustomActive(false);
				}
				this.UpdateBuyButton(true);
			}
			else
			{
				if (this.mBuyDescGo != null)
				{
					this.mBuyDescGo.CustomActive(true);
				}
				this.UpdateBuyButton(false);
			}
		}

		// Token: 0x0600CF20 RID: 53024 RVA: 0x00331E84 File Offset: 0x00330284
		private void UpdateBuyButton(bool flag)
		{
			if (this.mGiftBuyGray != null)
			{
				this.mGiftBuyGray.enabled = !flag;
			}
			if (this.mGiftBtnGrayGo != null)
			{
				this.mGiftBtnGrayGo.CustomActive(!flag);
			}
			if (this.mGiftBuyBtn != null)
			{
				this.mGiftBuyBtn.enabled = flag;
			}
		}

		// Token: 0x0600CF21 RID: 53025 RVA: 0x00331EF0 File Offset: 0x003302F0
		private void UpdateAccountNumberLimit(int accountLimitNum = -1)
		{
			this.UpdateBuyButton(true);
			if (this.mMallItemInfo.accountLimitBuyNum > 0U)
			{
				int accountLimitBuyNum = (int)this.mMallItemInfo.accountLimitBuyNum;
				int num;
				if (accountLimitNum == -1)
				{
					num = (int)this.mMallItemInfo.accountRestBuyNum;
				}
				else
				{
					num = accountLimitNum;
				}
				if (num <= 0)
				{
					this.UpdateBuyButton(false);
				}
				switch (this.mMallItemInfo.accountRefreshType)
				{
				case 0:
					this.mGiftLimtNumberDesc.text = string.Format(TR.Value("count_limittime_mall_limit_number_everyday"), num, accountLimitBuyNum);
					break;
				case 1:
					this.mGiftLimtNumberDesc.text = string.Format(TR.Value("count_limittime_mall_limit_number_month"), num, accountLimitBuyNum);
					break;
				case 2:
					this.mGiftLimtNumberDesc.text = string.Format(TR.Value("count_limittime_mall_limit_number_week"), num, accountLimitBuyNum);
					break;
				case 3:
					this.mGiftLimtNumberDesc.text = string.Format(TR.Value("count_limittime_mall_limit_number_today"), num, accountLimitBuyNum);
					break;
				}
			}
		}

		// Token: 0x0600CF22 RID: 53026 RVA: 0x0033201C File Offset: 0x0033041C
		private void OnSyncWorldMallBuySucceed(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			if (uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			uint num = (uint)uiEvent.Param1;
			int num2 = (int)uiEvent.Param2;
			int accountLimitNum = (int)uiEvent.Param3;
			if (this.mMallItemInfo == null)
			{
				return;
			}
			this.UpdateAccountNumberLimit(accountLimitNum);
		}

		// Token: 0x0600CF23 RID: 53027 RVA: 0x00332080 File Offset: 0x00330480
		private void InitElementLeftTimes()
		{
			if (this.mTimer == null || this.mDataModel == null)
			{
				return;
			}
			int num = (int)(this.mDataModel.EndTime - DataManager<TimeManager>.GetInstance().GetServerTime());
			int num2 = num / 86400;
			if (num2 <= 3)
			{
				this.mTimer.CustomActive(true);
				this.mTimer.SetCountdown(num);
				this.mTimer.StartTimer();
			}
			else
			{
				this.mTimer.CustomActive(false);
			}
		}

		// Token: 0x0600CF24 RID: 53028 RVA: 0x00332104 File Offset: 0x00330504
		private void OnGiftBuyBtnClick()
		{
			if (this.mMallItemInfo == null)
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MallBuyFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MallBuyFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<MallBuyFrame>(FrameLayer.Middle, this.mMallItemInfo, string.Empty);
		}

		// Token: 0x040078F2 RID: 30962
		[SerializeField]
		private Text mSignupTime;

		// Token: 0x040078F3 RID: 30963
		[SerializeField]
		private Text mGiftbagTime;

		// Token: 0x040078F4 RID: 30964
		[SerializeField]
		private ChampionshipBigRewardControl mBigRewardControl;

		// Token: 0x040078F5 RID: 30965
		[SerializeField]
		private Text mQuizzesCoinsCount;

		// Token: 0x040078F6 RID: 30966
		[SerializeField]
		private GameObject mOngoingGo;

		// Token: 0x040078F7 RID: 30967
		[SerializeField]
		private GameObject mNotStartGo;

		// Token: 0x040078F8 RID: 30968
		[SerializeField]
		private Button mQuizzesActivityBtn;

		// Token: 0x040078F9 RID: 30969
		[SerializeField]
		private Button mShopBtn;

		// Token: 0x040078FA RID: 30970
		[SerializeField]
		private CommonMoneyControl mCommonMoneyControl;

		// Token: 0x040078FB RID: 30971
		[Space(10f)]
		[Header("leftItem")]
		[SerializeField]
		private Text mTaskName;

		// Token: 0x040078FC RID: 30972
		[SerializeField]
		private Image mTaskItemBackground;

		// Token: 0x040078FD RID: 30973
		[SerializeField]
		private Image mTaskItemIcon;

		// Token: 0x040078FE RID: 30974
		[SerializeField]
		private Button mTaskItemIconBtn;

		// Token: 0x040078FF RID: 30975
		[SerializeField]
		private Text mTaskItemCount;

		// Token: 0x04007900 RID: 30976
		[SerializeField]
		private Text mTaskDesc;

		// Token: 0x04007901 RID: 30977
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x04007902 RID: 30978
		[SerializeField]
		private UIGray mReceiveUIGray;

		// Token: 0x04007903 RID: 30979
		[Space(10f)]
		[Header("RightItem")]
		[SerializeField]
		private Text mGiftName;

		// Token: 0x04007904 RID: 30980
		[SerializeField]
		private Image mGiftBackground;

		// Token: 0x04007905 RID: 30981
		[SerializeField]
		private Image mGiftIcon;

		// Token: 0x04007906 RID: 30982
		[SerializeField]
		private Button mGiftIconBtn;

		// Token: 0x04007907 RID: 30983
		[SerializeField]
		private Text mGiftCoinCount;

		// Token: 0x04007908 RID: 30984
		[SerializeField]
		private Text mGiftLimtNumberDesc;

		// Token: 0x04007909 RID: 30985
		[SerializeField]
		private Image mConsumeIcon;

		// Token: 0x0400790A RID: 30986
		[SerializeField]
		private Text mPrice;

		// Token: 0x0400790B RID: 30987
		[SerializeField]
		private Button mGiftBuyBtn;

		// Token: 0x0400790C RID: 30988
		[SerializeField]
		private UIGray mGiftBuyGray;

		// Token: 0x0400790D RID: 30989
		[SerializeField]
		private GameObject mGiftBtnGrayGo;

		// Token: 0x0400790E RID: 30990
		[SerializeField]
		private SimpleTimer mTimer;

		// Token: 0x0400790F RID: 30991
		[SerializeField]
		private GameObject mBuyDescGo;

		// Token: 0x04007910 RID: 30992
		private ILimitTimeActivityModel mDataModel;

		// Token: 0x04007911 RID: 30993
		private MallTypeTable.eMallType mMallType;

		// Token: 0x04007912 RID: 30994
		private List<MallItemInfo> mMallItemInfoList;

		// Token: 0x04007913 RID: 30995
		private MallItemInfo mMallItemInfo;

		// Token: 0x04007914 RID: 30996
		private ILimitTimeActivityTaskDataModel mTaskDataModel;

		// Token: 0x04007915 RID: 30997
		private ActivityItemBase.OnActivityItemClick<int> mOnItemClick;
	}
}
