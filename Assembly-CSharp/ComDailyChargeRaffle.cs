using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02001379 RID: 4985
public class ComDailyChargeRaffle : MonoBehaviour
{
	// Token: 0x0600C152 RID: 49490 RVA: 0x002E0A01 File Offset: 0x002DEE01
	private void Awake()
	{
	}

	// Token: 0x0600C153 RID: 49491 RVA: 0x002E0A03 File Offset: 0x002DEE03
	private void OnEnable()
	{
		Singleton<PluginManager>.GetInstance().TryGetIOSAppstoreProductIds();
		DataManager<DailyChargeRaffleDataManager>.GetInstance().ResetRedPoint();
		Singleton<GameStatisticManager>.GetInstance().DoStartFuilDailChargeRaffle();
	}

	// Token: 0x0600C154 RID: 49492 RVA: 0x002E0A23 File Offset: 0x002DEE23
	private void Start()
	{
		this.InitData();
		this.InitTRDesc();
		this.InitView();
		this.BindEvent();
	}

	// Token: 0x0600C155 RID: 49493 RVA: 0x002E0A3D File Offset: 0x002DEE3D
	private void Update()
	{
	}

	// Token: 0x0600C156 RID: 49494 RVA: 0x002E0A3F File Offset: 0x002DEE3F
	private void OnDestroy()
	{
		this.Clear();
		this.UnBindEvent();
	}

	// Token: 0x0600C157 RID: 49495 RVA: 0x002E0A4D File Offset: 0x002DEE4D
	private void BindEvent()
	{
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DailyChargeResultNotify, new ClientEventSystem.UIEventHandler(this.OnDailyChargeResultNotify));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DailyChargeCounterChanged, new ClientEventSystem.UIEventHandler(this._DailyChargeCounterChanged));
	}

	// Token: 0x0600C158 RID: 49496 RVA: 0x002E0A85 File Offset: 0x002DEE85
	private void UnBindEvent()
	{
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DailyChargeResultNotify, new ClientEventSystem.UIEventHandler(this.OnDailyChargeResultNotify));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DailyChargeCounterChanged, new ClientEventSystem.UIEventHandler(this._DailyChargeCounterChanged));
	}

	// Token: 0x0600C159 RID: 49497 RVA: 0x002E0AC0 File Offset: 0x002DEEC0
	private void OnDailyChargeResultNotify(UIEvent _uiEvent)
	{
		if (_uiEvent == null)
		{
			return;
		}
		try
		{
			int num = (int)_uiEvent.Param1;
			int status = (int)_uiEvent.Param2;
			ComDailyChargeRaffle.DailyChargeTaskStatus taskStatus = this.GetTaskStatus(status);
			bool flag = false;
			if (this.mTaskItemList != null)
			{
				for (int i = 0; i < this.mTaskItemList.Count; i++)
				{
					if (this.mTaskItemList[i].model != null && this.mTaskItemList[i].model.Id == num)
					{
						this.mTaskItemList[i].SetTaskItemStatus(taskStatus);
						flag = true;
						DataManager<DailyChargeRaffleDataManager>.GetInstance().OpenRaffleTurnTableFrame(this.mTaskItemList[i].model.RaffleTableId);
						DataManager<DailyChargeRaffleDataManager>.GetInstance().ReqDailyChargeCounter(num);
					}
				}
				if (flag)
				{
					DataManager<ActiveManager>.GetInstance().SendSevenDayTimeReq();
				}
			}
		}
		catch (Exception ex)
		{
			Logger.LogError("catch a convert error !");
		}
	}

	// Token: 0x0600C15A RID: 49498 RVA: 0x002E0BD4 File Offset: 0x002DEFD4
	private void _DailyChargeCounterChanged(UIEvent uIEvent)
	{
		if (uIEvent == null || uIEvent.Param1 == null)
		{
			return;
		}
		DailyChargeCounter dailyChargeCounter = uIEvent.Param1 as DailyChargeCounter;
		if (dailyChargeCounter == null || dailyChargeCounter.activityCounter == null)
		{
			return;
		}
		if (this.mTaskModelList == null)
		{
			return;
		}
		for (int i = 0; i < this.mTaskModelList.Count; i++)
		{
			DailyChargeRaffleModel dailyChargeRaffleModel = this.mTaskModelList[i];
			if (dailyChargeRaffleModel != null)
			{
				if ((long)dailyChargeRaffleModel.Id == (long)((ulong)dailyChargeCounter.dailyChargeActivityId))
				{
					if (dailyChargeCounter.activityCounter.CounterId == 1001U)
					{
						dailyChargeRaffleModel.accLimitChargeNum = (int)dailyChargeCounter.activityCounter.CounterValue;
					}
				}
			}
		}
	}

	// Token: 0x0600C15B RID: 49499 RVA: 0x002E0C90 File Offset: 0x002DF090
	private ComDailyChargeRaffle.DailyChargeTaskStatus GetTaskStatus(int status)
	{
		ComDailyChargeRaffle.DailyChargeTaskStatus result = ComDailyChargeRaffle.DailyChargeTaskStatus.ToCharge;
		if (status <= 1)
		{
			result = ComDailyChargeRaffle.DailyChargeTaskStatus.ToCharge;
		}
		else if (status == 5)
		{
			result = ComDailyChargeRaffle.DailyChargeTaskStatus.BeCharged;
		}
		return result;
	}

	// Token: 0x0600C15C RID: 49500 RVA: 0x002E0CB8 File Offset: 0x002DF0B8
	private void InitData()
	{
		this.mTaskModelList = DataManager<DailyChargeRaffleDataManager>.GetInstance().GetDailyChargeModels();
		if (this.mTaskModelList != null)
		{
			for (int i = 0; i < this.mTaskModelList.Count; i++)
			{
				DailyChargeRaffleModel dailyChargeRaffleModel = this.mTaskModelList[i];
				if (dailyChargeRaffleModel != null)
				{
					DataManager<DailyChargeRaffleDataManager>.GetInstance().ReqDailyChargeCounter(dailyChargeRaffleModel.Id);
				}
			}
		}
		SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(633, string.Empty, string.Empty);
		if (tableItem != null)
		{
			this.mFashionId = tableItem.Value;
		}
	}

	// Token: 0x0600C15D RID: 49501 RVA: 0x002E0D50 File Offset: 0x002DF150
	private void InitTRDesc()
	{
		this.toPayBtnTextDesc = TR.Value("daily_charge_raffle_button_desc");
	}

	// Token: 0x0600C15E RID: 49502 RVA: 0x002E0D64 File Offset: 0x002DF164
	private void InitView()
	{
		this.mBind = base.gameObject.GetComponent<ComCommonBind>();
		if (this.mBind != null)
		{
			this.mTimeHint = this.mBind.GetCom<Text>("TimeHint");
			this.mHint0 = this.mBind.GetCom<Text>("Hint0");
			this.mGoToTurnTableBtn = this.mBind.GetCom<Button>("GoToTurnTable");
			if (this.mGoToTurnTableBtn)
			{
				this.mGoToTurnTableBtn.onClick.AddListener(new UnityAction(this.OnGoToTurnTableClick));
			}
			this.mScrollViewList = this.mBind.GetCom<ComUIListScript>("ScrollViewList");
			this.mPreViewModelBtn = this.mBind.GetCom<Button>("preViewModel");
			if (this.mPreViewModelBtn != null)
			{
				this.mPreViewModelBtn.onClick.RemoveAllListeners();
				this.mPreViewModelBtn.onClick.AddListener(new UnityAction(this.OnPreViewModelClick));
			}
		}
		this.InitComUIList();
	}

	// Token: 0x0600C15F RID: 49503 RVA: 0x002E0E70 File Offset: 0x002DF270
	private void Clear()
	{
		this.mBind = null;
		this.mTimeHint = null;
		this.mHint0 = null;
		if (this.mGoToTurnTableBtn)
		{
			this.mGoToTurnTableBtn.onClick.RemoveListener(new UnityAction(this.OnGoToTurnTableClick));
		}
		this.mGoToTurnTableBtn = null;
		if (this.mScrollViewList != null)
		{
			this.mScrollViewList.SetElementAmount(0);
			this.mScrollViewList.UnInitialize();
		}
		this.mScrollViewList = null;
		if (this.mTaskItemList != null)
		{
			this.mTaskItemList.Clear();
		}
		if (this.mTaskModelList != null)
		{
			for (int i = 0; i < this.mTaskModelList.Count; i++)
			{
				this.mTaskModelList[i].Clear();
			}
			this.mTaskModelList.Clear();
		}
		if (this.mPreViewModelBtn != null)
		{
			this.mPreViewModelBtn.onClick.RemoveListener(new UnityAction(this.OnPreViewModelClick));
		}
		this.mPreViewModelBtn = null;
	}

	// Token: 0x0600C160 RID: 49504 RVA: 0x002E0F81 File Offset: 0x002DF381
	private void OnGoToTurnTableClick()
	{
		DataManager<DailyChargeRaffleDataManager>.GetInstance().OpenRaffleTurnTableFrame(this.mTaskModelList);
	}

	// Token: 0x0600C161 RID: 49505 RVA: 0x002E0F94 File Offset: 0x002DF394
	private void OnPreViewModelClick()
	{
		PreViewDataModel preViewDataModel = new PreViewDataModel();
		preViewDataModel.preViewItemList = new List<PreViewItemData>();
		ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.mFashionId, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return;
		}
		if (tableItem.SubType == ItemTable.eSubType.GiftPackage)
		{
			GiftPackTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<GiftPackTable>(tableItem.PackageID, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			FlatBufferArray<int> items = tableItem2.Items;
			for (int i = 0; i < items.Length; i++)
			{
				GiftTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<GiftTable>(items[i], string.Empty, string.Empty);
				if (tableItem3 != null)
				{
					if (tableItem3.RecommendJobs.Contains(DataManager<PlayerBaseData>.GetInstance().JobTableID))
					{
						PreViewItemData preViewItemData = new PreViewItemData();
						preViewItemData.itemId = tableItem3.ItemID;
						preViewDataModel.preViewItemList.Add(preViewItemData);
					}
				}
			}
		}
		Singleton<ClientSystemManager>.GetInstance().OpenFrame<PreviewModelFrame>(FrameLayer.Middle, preViewDataModel, string.Empty);
	}

	// Token: 0x0600C162 RID: 49506 RVA: 0x002E10A4 File Offset: 0x002DF4A4
	private void InitComUIList()
	{
		if (this.mTaskModelList == null || this.mTaskModelList.Count == 0)
		{
			return;
		}
		if (this.mScrollViewList == null)
		{
			return;
		}
		if (!this.mScrollViewList.IsInitialised())
		{
			this.mScrollViewList.Initialize();
			this.mScrollViewList.onBindItem = delegate(GameObject go)
			{
				if (go != null)
				{
					return go.GetComponent<DailyChargeRaffleTaskItem>();
				}
				return null;
			};
		}
		this.mScrollViewList.onItemVisiable = delegate(ComUIListElementScript var)
		{
			if (var == null)
			{
				return;
			}
			int index = var.m_index;
			if (index >= 0 && index < this.mTaskModelList.Count)
			{
				DailyChargeRaffleTaskItem dailyChargeRaffleTaskItem = var.gameObjectBindScript as DailyChargeRaffleTaskItem;
				if (dailyChargeRaffleTaskItem != null)
				{
					dailyChargeRaffleTaskItem.model = this.mTaskModelList[index];
					dailyChargeRaffleTaskItem.Initialize();
					dailyChargeRaffleTaskItem.SetToPayBtnText(string.Format(this.toPayBtnTextDesc, this.mTaskModelList[index].ChargePrice));
					int status = (int)this.mTaskModelList[index].Status;
					dailyChargeRaffleTaskItem.SetTaskItemStatus(this.GetTaskStatus(status));
					if (this.mTaskItemList != null && !this.mTaskItemList.Contains(dailyChargeRaffleTaskItem))
					{
						this.mTaskItemList.Add(dailyChargeRaffleTaskItem);
					}
				}
			}
		};
		this.mScrollViewList.SetElementAmount(this.mTaskModelList.Count);
		this.mScrollViewList.ResetContentPosition();
	}

	// Token: 0x04006D65 RID: 28005
	private List<DailyChargeRaffleModel> mTaskModelList = new List<DailyChargeRaffleModel>();

	// Token: 0x04006D66 RID: 28006
	private int mFashionId;

	// Token: 0x04006D67 RID: 28007
	private ComCommonBind mBind;

	// Token: 0x04006D68 RID: 28008
	private Text mTimeHint;

	// Token: 0x04006D69 RID: 28009
	private Text mHint0;

	// Token: 0x04006D6A RID: 28010
	private Button mGoToTurnTableBtn;

	// Token: 0x04006D6B RID: 28011
	private Button mPreViewModelBtn;

	// Token: 0x04006D6C RID: 28012
	private ComUIListScript mScrollViewList;

	// Token: 0x04006D6D RID: 28013
	private List<DailyChargeRaffleTaskItem> mTaskItemList = new List<DailyChargeRaffleTaskItem>();

	// Token: 0x04006D6E RID: 28014
	private string toPayBtnTextDesc;

	// Token: 0x0200137A RID: 4986
	public enum DailyChargeTaskStatus
	{
		// Token: 0x04006D71 RID: 28017
		ToCharge,
		// Token: 0x04006D72 RID: 28018
		BeCharged
	}
}
