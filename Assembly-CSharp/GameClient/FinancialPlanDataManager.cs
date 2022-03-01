using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001357 RID: 4951
	public class FinancialPlanDataManager : DataManager<FinancialPlanDataManager>
	{
		// Token: 0x17001B9C RID: 7068
		// (get) Token: 0x0600BFDC RID: 49116 RVA: 0x002D2DDF File Offset: 0x002D11DF
		// (set) Token: 0x0600BFDD RID: 49117 RVA: 0x002D2DE7 File Offset: 0x002D11E7
		public int ItemId { get; private set; }

		// Token: 0x17001B9D RID: 7069
		// (get) Token: 0x0600BFDE RID: 49118 RVA: 0x002D2DF0 File Offset: 0x002D11F0
		// (set) Token: 0x0600BFDF RID: 49119 RVA: 0x002D2DF8 File Offset: 0x002D11F8
		public int ItemPrice { get; private set; }

		// Token: 0x17001B9E RID: 7070
		// (get) Token: 0x0600BFE0 RID: 49120 RVA: 0x002D2E01 File Offset: 0x002D1201
		// (set) Token: 0x0600BFE1 RID: 49121 RVA: 0x002D2E09 File Offset: 0x002D1209
		public int BuyRewardItemId { get; private set; }

		// Token: 0x17001B9F RID: 7071
		// (get) Token: 0x0600BFE2 RID: 49122 RVA: 0x002D2E12 File Offset: 0x002D1212
		// (set) Token: 0x0600BFE3 RID: 49123 RVA: 0x002D2E1A File Offset: 0x002D121A
		public int BuyRewardItemNumber { get; private set; }

		// Token: 0x17001BA0 RID: 7072
		// (get) Token: 0x0600BFE4 RID: 49124 RVA: 0x002D2E23 File Offset: 0x002D1223
		// (set) Token: 0x0600BFE5 RID: 49125 RVA: 0x002D2E2B File Offset: 0x002D122B
		public int BuyReceivedItemNumber { get; private set; }

		// Token: 0x17001BA1 RID: 7073
		// (get) Token: 0x0600BFE6 RID: 49126 RVA: 0x002D2E34 File Offset: 0x002D1234
		// (set) Token: 0x0600BFE7 RID: 49127 RVA: 0x002D2E3C File Offset: 0x002D123C
		public int ItemRateNumber { get; private set; }

		// Token: 0x17001BA2 RID: 7074
		// (get) Token: 0x0600BFE8 RID: 49128 RVA: 0x002D2E45 File Offset: 0x002D1245
		// (set) Token: 0x0600BFE9 RID: 49129 RVA: 0x002D2E4D File Offset: 0x002D124D
		public int PreReceivedRewardIndex { get; set; }

		// Token: 0x17001BA3 RID: 7075
		// (get) Token: 0x0600BFEA RID: 49130 RVA: 0x002D2E56 File Offset: 0x002D1256
		// (set) Token: 0x0600BFEB RID: 49131 RVA: 0x002D2E5E File Offset: 0x002D125E
		public bool IsCanBuyFinancialPlan { get; private set; }

		// Token: 0x17001BA4 RID: 7076
		// (get) Token: 0x0600BFEC RID: 49132 RVA: 0x002D2E67 File Offset: 0x002D1267
		// (set) Token: 0x0600BFED RID: 49133 RVA: 0x002D2E6F File Offset: 0x002D126F
		public bool IsAlreadyBuyFinancialPlan { get; private set; }

		// Token: 0x17001BA5 RID: 7077
		// (get) Token: 0x0600BFEE RID: 49134 RVA: 0x002D2E78 File Offset: 0x002D1278
		// (set) Token: 0x0600BFEF RID: 49135 RVA: 0x002D2E80 File Offset: 0x002D1280
		public int TotalRewardNumber { get; private set; }

		// Token: 0x17001BA6 RID: 7078
		// (get) Token: 0x0600BFF0 RID: 49136 RVA: 0x002D2E89 File Offset: 0x002D1289
		// (set) Token: 0x0600BFF1 RID: 49137 RVA: 0x002D2E91 File Offset: 0x002D1291
		public int CurrentRewardNumber { get; private set; }

		// Token: 0x17001BA7 RID: 7079
		// (get) Token: 0x0600BFF2 RID: 49138 RVA: 0x002D2E9A File Offset: 0x002D129A
		// (set) Token: 0x0600BFF3 RID: 49139 RVA: 0x002D2EA2 File Offset: 0x002D12A2
		public bool FirstRedPointTipFlag
		{
			get
			{
				return this._firstRedPointTipFlag;
			}
			set
			{
				if (this._firstRedPointTipFlag != value)
				{
					this._firstRedPointTipFlag = value;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FinancialPlanRedPointTips, null, null, null, null);
				}
			}
		}

		// Token: 0x0600BFF4 RID: 49140 RVA: 0x002D2ECA File Offset: 0x002D12CA
		public override void Initialize()
		{
			this.InitializeFinancialPlanData();
			this.BindNetEvents();
		}

		// Token: 0x0600BFF5 RID: 49141 RVA: 0x002D2ED8 File Offset: 0x002D12D8
		private void InitializeFinancialPlanData()
		{
			this._firstRedPointTipFlag = true;
			this._isAlreadyReceivedAllReward = false;
			this.IsCanBuyFinancialPlan = true;
			this.IsAlreadyBuyFinancialPlan = false;
			this.CurrentRewardNumber = 0;
			this.TotalRewardNumber = 0;
			this.PreReceivedRewardIndex = -1;
			this._rewardModelList.Clear();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<MoneyManageTable>();
			if (table != null)
			{
				List<KeyValuePair<int, object>> list = table.ToList<KeyValuePair<int, object>>();
				int num = 0;
				foreach (KeyValuePair<int, object> keyValuePair in list)
				{
					MoneyManageTable moneyManageTable = keyValuePair.Value as MoneyManageTable;
					if (moneyManageTable != null)
					{
						FinancialPlanRewardModel financialPlanRewardModel = new FinancialPlanRewardModel();
						financialPlanRewardModel.Index = num++;
						financialPlanRewardModel.Id = moneyManageTable.ID;
						financialPlanRewardModel.LevelLimit = moneyManageTable.Level;
						foreach (string text in ((IEnumerable<string>)moneyManageTable.ItemReward))
						{
							string[] array = text.Split(new char[]
							{
								'_'
							});
							int itemID = -1;
							int num2 = -1;
							if (int.TryParse(array[0], out itemID) && int.TryParse(array[1], out num2))
							{
								ItemSimpleData item = new ItemSimpleData
								{
									ItemID = itemID,
									Count = num2
								};
								this.TotalRewardNumber += num2;
								financialPlanRewardModel.RewardItemList.Add(item);
							}
						}
						financialPlanRewardModel.RewardState = FinancialPlanState.UnBuy;
						financialPlanRewardModel.ShowRewardState = FinancialPlanState.UnBuy;
						this._rewardModelList.Add(financialPlanRewardModel);
					}
				}
			}
			if (this._rewardModelList != null && this._rewardModelList.Count > 1)
			{
				this._rewardModelList.Sort((FinancialPlanRewardModel x, FinancialPlanRewardModel y) => x.LevelLimit.CompareTo(y.LevelLimit));
				for (int i = 0; i < this._rewardModelList.Count; i++)
				{
					if (this._rewardModelList[i] != null)
					{
						this._rewardModelList[i].Index = i;
					}
				}
			}
			ChargeMallTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChargeMallTable>(this._chargeMallTableId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.ItemId = tableItem.ID;
				this.ItemPrice = tableItem.ChargeMoney;
				this.BuyRewardItemNumber = tableItem.itemNum;
				this.BuyRewardItemId = tableItem.itemID;
			}
			else
			{
				this.ItemId = 4;
				this.ItemPrice = 198;
				this.BuyRewardItemNumber = 1980;
				this.BuyRewardItemId = 600000002;
			}
			this.BuyReceivedItemNumber = this.BuyRewardItemNumber;
			this.ItemRateNumber = (int)((double)((float)this.TotalRewardNumber / (float)this.BuyRewardItemNumber) + 0.5);
		}

		// Token: 0x0600BFF6 RID: 49142 RVA: 0x002D31FC File Offset: 0x002D15FC
		public override void Clear()
		{
			this._rewardModelList.Clear();
			this.IsAlreadyBuyFinancialPlan = false;
			this.IsCanBuyFinancialPlan = false;
			this._financialPlanButtonState = FinancialPlanButtonState.Invalid;
			this.UnBindNetEvents();
		}

		// Token: 0x0600BFF7 RID: 49143 RVA: 0x002D3224 File Offset: 0x002D1624
		private void BindNetEvents()
		{
			NetProcess.AddMsgHandler(503304U, new Action<MsgDATA>(this.OnReceivedRewardItemResp));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			ActiveManager instance2 = DataManager<ActiveManager>.GetInstance();
			instance2.onAddMainActivity = (ActiveManager.OnAddMainActivity)Delegate.Combine(instance2.onAddMainActivity, new ActiveManager.OnAddMainActivity(this.OnAddMainActivity));
		}

		// Token: 0x0600BFF8 RID: 49144 RVA: 0x002D3294 File Offset: 0x002D1694
		private void UnBindNetEvents()
		{
			NetProcess.RemoveMsgHandler(503304U, new Action<MsgDATA>(this.OnReceivedRewardItemResp));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			ActiveManager instance2 = DataManager<ActiveManager>.GetInstance();
			instance2.onAddMainActivity = (ActiveManager.OnAddMainActivity)Delegate.Remove(instance2.onAddMainActivity, new ActiveManager.OnAddMainActivity(this.OnAddMainActivity));
		}

		// Token: 0x0600BFF9 RID: 49145 RVA: 0x002D3304 File Offset: 0x002D1704
		private void OnAddMainActivity(ActiveManager.ActiveData data)
		{
			if (data.mainItem.ActiveTypeID == this.ActivityConfigId && data.mainItem.ID == this.ActivityTemplateId)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FinancialPlanButtonUpdateByLevel, null, null, null, null);
			}
		}

		// Token: 0x0600BFFA RID: 49146 RVA: 0x002D3350 File Offset: 0x002D1750
		public void SyncBuyFinancialPlanBoughtStatus(byte status)
		{
			switch (status)
			{
			case 0:
				this.IsCanBuyFinancialPlan = true;
				this.IsAlreadyBuyFinancialPlan = false;
				break;
			case 1:
				this.IsCanBuyFinancialPlan = false;
				this.IsAlreadyBuyFinancialPlan = false;
				break;
			case 2:
				this.IsCanBuyFinancialPlan = true;
				this.IsAlreadyBuyFinancialPlan = true;
				break;
			case 3:
				this.IsCanBuyFinancialPlan = true;
				this.IsAlreadyBuyFinancialPlan = true;
				break;
			default:
				this.IsCanBuyFinancialPlan = true;
				this.IsAlreadyBuyFinancialPlan = false;
				break;
			}
			this.OnBuySyncFinancialPlanBoughtStatus();
		}

		// Token: 0x0600BFFB RID: 49147 RVA: 0x002D33DF File Offset: 0x002D17DF
		private void OnBuySyncFinancialPlanBoughtStatus()
		{
			this.UpdateShowRewardState();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FinancialPlanBuyRes, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FinancialPlanRedPointTips, null, null, null, null);
		}

		// Token: 0x0600BFFC RID: 49148 RVA: 0x002D3410 File Offset: 0x002D1810
		public void SyncFinancialPlanMaskProperty(MoneyManageMaskProperty property)
		{
			this.CurrentRewardNumber = 0;
			foreach (FinancialPlanRewardModel financialPlanRewardModel in this._rewardModelList)
			{
				int id = financialPlanRewardModel.Id;
				if (property.CheckMask((uint)id))
				{
					financialPlanRewardModel.RewardState = FinancialPlanState.Received;
					this.CurrentRewardNumber += financialPlanRewardModel.GetRewardItemCount();
				}
			}
			this._isAlreadyReceivedAllReward = true;
			foreach (FinancialPlanRewardModel financialPlanRewardModel2 in this._rewardModelList)
			{
				if (financialPlanRewardModel2.RewardState != FinancialPlanState.Received)
				{
					this._isAlreadyReceivedAllReward = false;
				}
			}
			this.OnSyncFinancialPlanMaskProperty();
		}

		// Token: 0x0600BFFD RID: 49149 RVA: 0x002D3500 File Offset: 0x002D1900
		private void OnSyncFinancialPlanMaskProperty()
		{
			if (this.IsCanBuyFinancialPlan && this.IsAlreadyBuyFinancialPlan)
			{
				this.UpdateShowRewardState();
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FinancialPlanReceivedRes, null, null, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FinancialPlanRedPointTips, null, null, null, null);
			}
		}

		// Token: 0x0600BFFE RID: 49150 RVA: 0x002D3550 File Offset: 0x002D1950
		private void OnLevelChanged(int preLevel, int curLevel)
		{
			if (this.IsCanBuyFinancialPlan && this.IsAlreadyBuyFinancialPlan)
			{
				bool flag = false;
				foreach (FinancialPlanRewardModel financialPlanRewardModel in this._rewardModelList)
				{
					if (financialPlanRewardModel.ShowRewardState != FinancialPlanState.UnReceived && financialPlanRewardModel.ShowRewardState != FinancialPlanState.UnBuy && financialPlanRewardModel.ShowRewardState != FinancialPlanState.Received && preLevel < financialPlanRewardModel.LevelLimit && curLevel >= financialPlanRewardModel.LevelLimit)
					{
						flag = true;
						financialPlanRewardModel.ShowRewardState = FinancialPlanState.Finished;
					}
				}
				this.UpdateShowRewardState();
				if (flag)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FinancialPlanLevelSync, null, null, null, null);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FinancialPlanRedPointTips, null, null, null, null);
			}
			if (preLevel < this.ActivityFinancialPlanUnlockLevel && curLevel >= this.ActivityFinancialPlanUnlockLevel)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FinancialPlanButtonUpdateByLevel, null, null, null, null);
				return;
			}
			foreach (FinancialPlanRewardModel financialPlanRewardModel2 in this._rewardModelList)
			{
				if (preLevel < financialPlanRewardModel2.LevelLimit && curLevel >= financialPlanRewardModel2.LevelLimit)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.FinancialPlanButtonUpdateByLevel, null, null, null, null);
					break;
				}
			}
		}

		// Token: 0x0600BFFF RID: 49151 RVA: 0x002D36D4 File Offset: 0x002D1AD4
		public void SendReceivedRewardItemReq(int rewardId)
		{
			SceneGiveMoneyManageRewardReq cmd = new SceneGiveMoneyManageRewardReq
			{
				rewardId = (byte)rewardId
			};
			NetManager.Instance().SendCommand<SceneGiveMoneyManageRewardReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600C000 RID: 49152 RVA: 0x002D3700 File Offset: 0x002D1B00
		private void OnReceivedRewardItemResp(MsgDATA data)
		{
			SceneGiveMoneyManageRewardRes sceneGiveMoneyManageRewardRes = new SceneGiveMoneyManageRewardRes();
			sceneGiveMoneyManageRewardRes.decode(data.bytes);
			if (sceneGiveMoneyManageRewardRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneGiveMoneyManageRewardRes.result, string.Empty);
				return;
			}
			SystemNotifyManager.SystemNotify(1266, string.Empty);
		}

		// Token: 0x0600C001 RID: 49153 RVA: 0x002D374A File Offset: 0x002D1B4A
		public void SendBuyFinancialPlanReq()
		{
			Singleton<PayManager>.GetInstance().DoPay(this.ItemId, this.ItemPrice, ChargeMallType.FinancialPlan);
		}

		// Token: 0x0600C002 RID: 49154 RVA: 0x002D3763 File Offset: 0x002D1B63
		public FinancialPlanRewardModel GetRewardModelByIndex(int index)
		{
			if (index < 0 || index >= this._rewardModelList.Count)
			{
				return null;
			}
			return this._rewardModelList[index];
		}

		// Token: 0x0600C003 RID: 49155 RVA: 0x002D378C File Offset: 0x002D1B8C
		public int GetFirstReceivedRewardModelIndex()
		{
			if (!this.IsCanBuyFinancialPlan)
			{
				return 0;
			}
			if (!this.IsAlreadyBuyFinancialPlan)
			{
				return 0;
			}
			for (int i = 0; i < this._rewardModelList.Count; i++)
			{
				FinancialPlanRewardModel financialPlanRewardModel = this._rewardModelList[i];
				if (financialPlanRewardModel.ShowRewardState == FinancialPlanState.Finished)
				{
					return i;
				}
			}
			if (this.PreReceivedRewardIndex != -1)
			{
				return this.PreReceivedRewardIndex;
			}
			for (int j = 0; j < this._rewardModelList.Count; j++)
			{
				FinancialPlanRewardModel financialPlanRewardModel2 = this._rewardModelList[j];
				if (financialPlanRewardModel2.LevelLimit > (int)DataManager<PlayerBaseData>.GetInstance().Level)
				{
					return j;
				}
			}
			return this._rewardModelList.Count - 1;
		}

		// Token: 0x0600C004 RID: 49156 RVA: 0x002D384A File Offset: 0x002D1C4A
		public int GetRewardModelCount()
		{
			return this._rewardModelList.Count;
		}

		// Token: 0x0600C005 RID: 49157 RVA: 0x002D3858 File Offset: 0x002D1C58
		public void UpdateShowRewardState()
		{
			if (this._rewardModelList == null || this._rewardModelList.Count <= 0)
			{
				return;
			}
			if (!this.IsCanBuyFinancialPlan)
			{
				foreach (FinancialPlanRewardModel financialPlanRewardModel in this._rewardModelList)
				{
					financialPlanRewardModel.ShowRewardState = FinancialPlanState.UnReceived;
				}
			}
			else if (!this.IsAlreadyBuyFinancialPlan)
			{
				foreach (FinancialPlanRewardModel financialPlanRewardModel2 in this._rewardModelList)
				{
					financialPlanRewardModel2.ShowRewardState = FinancialPlanState.UnBuy;
				}
			}
			else
			{
				foreach (FinancialPlanRewardModel financialPlanRewardModel3 in this._rewardModelList)
				{
					if (financialPlanRewardModel3.RewardState == FinancialPlanState.Received)
					{
						financialPlanRewardModel3.ShowRewardState = financialPlanRewardModel3.RewardState;
					}
					else if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= financialPlanRewardModel3.LevelLimit)
					{
						financialPlanRewardModel3.ShowRewardState = FinancialPlanState.Finished;
					}
					else
					{
						financialPlanRewardModel3.ShowRewardState = FinancialPlanState.UnAcommpolished;
					}
				}
			}
		}

		// Token: 0x0600C006 RID: 49158 RVA: 0x002D39D0 File Offset: 0x002D1DD0
		public bool IsAlreadyReceivedAllReward()
		{
			return !this.IsCanBuyFinancialPlan || this._isAlreadyReceivedAllReward;
		}

		// Token: 0x0600C007 RID: 49159 RVA: 0x002D39F0 File Offset: 0x002D1DF0
		private bool IsExistRewardItemCanReceived()
		{
			foreach (FinancialPlanRewardModel financialPlanRewardModel in this._rewardModelList)
			{
				if (financialPlanRewardModel.ShowRewardState == FinancialPlanState.Finished)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600C008 RID: 49160 RVA: 0x002D3A5C File Offset: 0x002D1E5C
		public bool IsShowRedPoint()
		{
			if (!this.IsCanBuyFinancialPlan)
			{
				return false;
			}
			if (this.IsAlreadyBuyFinancialPlan)
			{
				return this.IsExistRewardItemCanReceived();
			}
			if (DataManager<PlayerBaseData>.GetInstance().Level >= 30)
			{
				this._firstRedPointTipFlag = false;
				return false;
			}
			return this.FirstRedPointTipFlag;
		}

		// Token: 0x0600C009 RID: 49161 RVA: 0x002D3AA8 File Offset: 0x002D1EA8
		public void ResetRedPointTip()
		{
			if (this.FirstRedPointTipFlag)
			{
				this.FirstRedPointTipFlag = false;
			}
		}

		// Token: 0x0600C00A RID: 49162 RVA: 0x002D3ABC File Offset: 0x002D1EBC
		public bool IsShowFinancialPlanButton()
		{
			return (int)DataManager<PlayerBaseData>.GetInstance().Level >= this.ActivityFinancialPlanUnlockLevel && DataManager<PlayerBaseData>.GetInstance().VipLevel > 0 && this.IsCanBuyFinancialPlan && !this.IsAlreadyBuyFinancialPlan && this.IsExistFinancialPlanActivity();
		}

		// Token: 0x0600C00B RID: 49163 RVA: 0x002D3B1C File Offset: 0x002D1F1C
		public bool IsExistFinancialPlanActivity()
		{
			List<ActiveManager.ActiveData> list = DataManager<ActiveManager>.GetInstance().ActiveDictionary.Values.ToList<ActiveManager.ActiveData>();
			foreach (ActiveManager.ActiveData activeData in list)
			{
				if (activeData.iActiveID == this.ActivityTemplateId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600C00C RID: 49164 RVA: 0x002D3B9C File Offset: 0x002D1F9C
		public void ShowFinancialPlanActivity()
		{
			DataManager<ActiveManager>.GetInstance().OpenActiveFrame(this.ActivityConfigId, this.ActivityTemplateId);
		}

		// Token: 0x0600C00D RID: 49165 RVA: 0x002D3BB4 File Offset: 0x002D1FB4
		public bool IsPlayerAlreadyShowOnceFinancialPlanInLogin()
		{
			string text = DataManager<PlayerBaseData>.GetInstance().RoleID.ToString() + this._financialPlanStr;
			return PlayerPrefs.HasKey(text) && PlayerPrefs.GetInt(text) >= 1;
		}

		// Token: 0x0600C00E RID: 49166 RVA: 0x002D3C08 File Offset: 0x002D2008
		public void SetPlayerAlreadyShowFinancialPlanInLogin()
		{
			string text = DataManager<PlayerBaseData>.GetInstance().RoleID.ToString() + this._financialPlanStr;
			PlayerPrefs.SetInt(text, 1);
		}

		// Token: 0x0600C00F RID: 49167 RVA: 0x002D3C40 File Offset: 0x002D2040
		public void SetFinancialPlanButtonState(FinancialPlanButtonState buttonState)
		{
			this._financialPlanButtonState = buttonState;
		}

		// Token: 0x0600C010 RID: 49168 RVA: 0x002D3C49 File Offset: 0x002D2049
		public FinancialPlanButtonState GetFinancialPlanButtonShowState()
		{
			return this._financialPlanButtonState;
		}

		// Token: 0x04006C4D RID: 27725
		private readonly string _financialPlanStr = "FinancialPlan";

		// Token: 0x04006C4E RID: 27726
		private readonly int _chargeMallTableId = 4;

		// Token: 0x04006C4F RID: 27727
		public readonly int ActivityConfigId = 9380;

		// Token: 0x04006C50 RID: 27728
		public readonly int ActivityTemplateId = 8600;

		// Token: 0x04006C51 RID: 27729
		public readonly int ActivityFinancialPlanUnlockLevel = 8;

		// Token: 0x04006C5D RID: 27741
		private bool _isAlreadyReceivedAllReward;

		// Token: 0x04006C5E RID: 27742
		private bool _isClickFinancialPlanButton;

		// Token: 0x04006C5F RID: 27743
		private List<FinancialPlanRewardModel> _rewardModelList = new List<FinancialPlanRewardModel>();

		// Token: 0x04006C60 RID: 27744
		private bool _firstRedPointTipFlag = true;

		// Token: 0x04006C61 RID: 27745
		private FinancialPlanButtonState _financialPlanButtonState = FinancialPlanButtonState.Invalid;
	}
}
