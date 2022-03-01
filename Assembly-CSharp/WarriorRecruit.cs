using System;
using System.Collections.Generic;
using GameClient;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x020013C2 RID: 5058
public class WarriorRecruit : MonoBehaviour
{
	// Token: 0x0600C443 RID: 50243 RVA: 0x002F1968 File Offset: 0x002EFD68
	private void Awake()
	{
		this._RegistUIEventHandle();
		this._InitTaskUIScriptList();
		if (this.btCopyInviteCode != null)
		{
			this.btCopyInviteCode.onClick.AddListener(new UnityAction(this._OnClickCopyCode));
		}
		if (this.btRecruitList != null)
		{
			this.btRecruitList.onClick.AddListener(new UnityAction(this._OnClickRecruitList));
		}
		if (this.btRecruitShop != null)
		{
			this.btRecruitShop.onClick.AddListener(new UnityAction(this._OnClickRecruitShop));
		}
		if (this.tgToggle1 != null)
		{
			this.tgToggle1.onValueChanged.AddListener(new UnityAction<bool>(this._OnClickToggle1));
		}
		if (this.tgToggle2 != null)
		{
			this.tgToggle2.onValueChanged.AddListener(new UnityAction<bool>(this._OnClickToggle2));
		}
		if (this.InputInvoiteCode != null)
		{
			this.InputInvoiteCode.onValueChanged.AddListener(new UnityAction<string>(this._OnInputInvoiteCodeClick));
		}
		if (this.InvoiteCodeInputField != null)
		{
			this.InvoiteCodeInputField.onValueChanged.AddListener(new UnityAction<string>(this._OnInvoiteCodeClick));
		}
		if (this.BindInvoiteCode != null)
		{
			this.BindInvoiteCode.onClick.AddListener(new UnityAction(this._OnBindInvoiteCodeClick));
		}
		this._Init();
	}

	// Token: 0x0600C444 RID: 50244 RVA: 0x002F1AF0 File Offset: 0x002EFEF0
	private void OnDestroy()
	{
		this._UnRegistUIEventHandle();
		this._UnInitTaskUIScriptList();
		if (this.btCopyInviteCode != null)
		{
			this.btCopyInviteCode.onClick.RemoveAllListeners();
		}
		if (this.btRecruitList != null)
		{
			this.btRecruitList.onClick.RemoveAllListeners();
		}
		if (this.btRecruitShop != null)
		{
			this.btRecruitShop.onClick.RemoveAllListeners();
		}
		if (this.tgToggle1 != null)
		{
			this.tgToggle1.onValueChanged.RemoveAllListeners();
		}
		if (this.tgToggle2 != null)
		{
			this.tgToggle2.onValueChanged.RemoveAllListeners();
		}
		if (this.targetTaskList != null)
		{
			this.targetTaskList.Clear();
		}
		if (this.InputInvoiteCode != null)
		{
			this.InputInvoiteCode.onValueChanged.RemoveAllListeners();
		}
		if (this.InvoiteCodeInputField != null)
		{
			this.InvoiteCodeInputField.onValueChanged.RemoveAllListeners();
		}
		if (this.BindInvoiteCode != null)
		{
			this.BindInvoiteCode.onClick.RemoveAllListeners();
		}
		this.sInvoiteCode = string.Empty;
		this.warriorRecruitTabType = WarriorRecruitTabType.None;
		this.RecruitmentBonusPreview_Companion_IsCreat = false;
		this.RecruitmentBonusPreview_Accept_IsCreat = false;
	}

	// Token: 0x0600C445 RID: 50245 RVA: 0x002F1C48 File Offset: 0x002F0048
	private void _RegistUIEventHandle()
	{
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.AccountSpecialItemUpdate, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.WarriorRecruitQueryTaskSuccessed, new ClientEventSystem.UIEventHandler(this._WarriorRecruitQueryTaskSuccessed));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.WarriorRecruitQueryIdentitySuccessed, new ClientEventSystem.UIEventHandler(this._WarriorRecruitQueryIdentitySuccessed));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.WarriorRecruitBindInviteCodeSuccessed, new ClientEventSystem.UIEventHandler(this._WarriorRecruitBindInviteCodeSuccessed));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.WarriorRecruitReceiveRewardSuccessed, new ClientEventSystem.UIEventHandler(this._WarriorRecruitReceiveRewardSuccessed));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.WarriorRecruitQueryHireAlreadyBindSuccessed, new ClientEventSystem.UIEventHandler(this._WarriorRecruitQueryHireAlreadyBindSuccessed));
	}

	// Token: 0x0600C446 RID: 50246 RVA: 0x002F1CF8 File Offset: 0x002F00F8
	private void _UnRegistUIEventHandle()
	{
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.AccountSpecialItemUpdate, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.WarriorRecruitQueryTaskSuccessed, new ClientEventSystem.UIEventHandler(this._WarriorRecruitQueryTaskSuccessed));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.WarriorRecruitQueryIdentitySuccessed, new ClientEventSystem.UIEventHandler(this._WarriorRecruitQueryIdentitySuccessed));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.WarriorRecruitBindInviteCodeSuccessed, new ClientEventSystem.UIEventHandler(this._WarriorRecruitBindInviteCodeSuccessed));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.WarriorRecruitReceiveRewardSuccessed, new ClientEventSystem.UIEventHandler(this._WarriorRecruitReceiveRewardSuccessed));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.WarriorRecruitQueryHireAlreadyBindSuccessed, new ClientEventSystem.UIEventHandler(this._WarriorRecruitQueryHireAlreadyBindSuccessed));
	}

	// Token: 0x0600C447 RID: 50247 RVA: 0x002F1DA7 File Offset: 0x002F01A7
	private void _OnCountValueChanged(UIEvent uiEvent)
	{
		this._RefreshWarriorRecruitCoin();
	}

	// Token: 0x0600C448 RID: 50248 RVA: 0x002F1DAF File Offset: 0x002F01AF
	private void _WarriorRecruitQueryTaskSuccessed(UIEvent uiEvent)
	{
		DataManager<WarriorRecruitDataManager>.GetInstance().SendHireInfoReq();
	}

	// Token: 0x0600C449 RID: 50249 RVA: 0x002F1DBC File Offset: 0x002F01BC
	private void _WarriorRecruitQueryIdentitySuccessed(UIEvent uiEvent)
	{
		if (this.warriorRecruitTabType != WarriorRecruitTabType.None)
		{
			this.RefreshTaskState();
		}
		else
		{
			if ((WarriorRecruitDataManager.identify & 2) == 2)
			{
				DataManager<WarriorRecruitDataManager>.GetInstance().SendWorldQueryHireAlreadyBindReq();
			}
			else
			{
				this._RefreshAcceptRecruitmentToggle();
			}
			this._InitInterface();
			if (this.tgToggle1 != null)
			{
				this.tgToggle1.isOn = true;
			}
		}
	}

	// Token: 0x0600C44A RID: 50250 RVA: 0x002F1E24 File Offset: 0x002F0224
	private void _WarriorRecruitBindInviteCodeSuccessed(UIEvent uiEvent)
	{
		if (this.BindInvoiteCodeRoot != null)
		{
			this.BindInvoiteCodeRoot.CustomActive(false);
		}
		if (this.BindSuccessedRoot != null)
		{
			this.BindSuccessedRoot.CustomActive(true);
		}
		DataManager<WarriorRecruitDataManager>.GetInstance().SendQueryTaskStatusReq();
	}

	// Token: 0x0600C44B RID: 50251 RVA: 0x002F1E75 File Offset: 0x002F0275
	private void _WarriorRecruitReceiveRewardSuccessed(UIEvent uiEvent)
	{
		this.RefreshTaskState();
	}

	// Token: 0x0600C44C RID: 50252 RVA: 0x002F1E7D File Offset: 0x002F027D
	private void _WarriorRecruitQueryHireAlreadyBindSuccessed(UIEvent uiEvent)
	{
		this._RefreshAcceptRecruitmentToggle();
	}

	// Token: 0x0600C44D RID: 50253 RVA: 0x002F1E88 File Offset: 0x002F0288
	private void RefreshTaskState()
	{
		if (this.warriorRecruitTabType == WarriorRecruitTabType.companion)
		{
			this._UpdateCompanionData();
		}
		else if (WarriorRecruitDataManager.isBindInviteCode)
		{
			this.RecruitmentBonusPreview_AcceptRoot.CustomActive(false);
			this.BindSuccessedRoot.CustomActive(true);
			this._UpdateAcceptData();
		}
		else
		{
			this._CreatAcceptBonusPreview();
		}
	}

	// Token: 0x0600C44E RID: 50254 RVA: 0x002F1EE0 File Offset: 0x002F02E0
	private void _InitTaskUIScriptList()
	{
		if (this.list != null)
		{
			this.list.Initialize();
			ComUIListScript comUIListScript = this.list;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
			ComUIListScript comUIListScript2 = this.list;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
		}
	}

	// Token: 0x0600C44F RID: 50255 RVA: 0x002F1F58 File Offset: 0x002F0358
	private void _UnInitTaskUIScriptList()
	{
		if (this.list != null)
		{
			ComUIListScript comUIListScript = this.list;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
			ComUIListScript comUIListScript2 = this.list;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
		}
	}

	// Token: 0x0600C450 RID: 50256 RVA: 0x002F1FC4 File Offset: 0x002F03C4
	private WarriorRecruitItem _OnBindItemDelegate(GameObject itemObject)
	{
		return itemObject.GetComponent<WarriorRecruitItem>();
	}

	// Token: 0x0600C451 RID: 50257 RVA: 0x002F1FCC File Offset: 0x002F03CC
	private void _OnItemVisiableDelegate(ComUIListElementScript item)
	{
		WarriorRecruitItem warriorRecruitItem = item.gameObjectBindScript as WarriorRecruitItem;
		if (warriorRecruitItem != null && item.m_index >= 0 && item.m_index < this.targetTaskList.Count)
		{
			warriorRecruitItem.OnItemVisiable(this.targetTaskList[item.m_index], item.m_index);
		}
	}

	// Token: 0x0600C452 RID: 50258 RVA: 0x002F2030 File Offset: 0x002F0430
	private void _Init()
	{
		if (DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_HIRE_RED_POINT) <= 0)
		{
			DataManager<WarriorRecruitDataManager>.GetInstance().SendWorldQueryHireRedPointReq();
		}
		DataManager<WarriorRecruitDataManager>.GetInstance().SendQueryTaskStatusReq();
		if (this.ActivityName != null)
		{
		}
		if (DataManager<ActiveManager>.GetInstance().allActivities.ContainsKey(this.warriorRecruitActiveID))
		{
			ActivityInfo activityInfo = DataManager<ActiveManager>.GetInstance().allActivities[this.warriorRecruitActiveID];
			if (activityInfo == null)
			{
				return;
			}
			if (this.ActivityTime != null)
			{
				this.ActivityTime.text = string.Format("{0}", Function.GetTimeWithoutYearNoZero((int)activityInfo.startTime, (int)activityInfo.dueTime));
			}
		}
	}

	// Token: 0x0600C453 RID: 50259 RVA: 0x002F20E5 File Offset: 0x002F04E5
	private void SetScrollRectValue()
	{
		if (this.Rect != null)
		{
			this.Rect.verticalNormalizedPosition = 1f;
		}
	}

	// Token: 0x0600C454 RID: 50260 RVA: 0x002F2108 File Offset: 0x002F0508
	private void _RefreshItemListCount()
	{
		if (this.list != null)
		{
			this.list.SetElementAmount(this.targetTaskList.Count);
		}
	}

	// Token: 0x0600C455 RID: 50261 RVA: 0x002F2131 File Offset: 0x002F0531
	private void _OnClickCopyCode()
	{
	}

	// Token: 0x0600C456 RID: 50262 RVA: 0x002F2133 File Offset: 0x002F0533
	private void _OnClickRecruitList()
	{
		DataManager<WarriorRecruitDataManager>.GetInstance().SendQueryHireListReq();
	}

	// Token: 0x0600C457 RID: 50263 RVA: 0x002F213F File Offset: 0x002F053F
	private void _OnClickRecruitShop()
	{
		DataManager<AccountShopDataManager>.GetInstance().OpenAccountShop(34, 0, 0, -1);
	}

	// Token: 0x0600C458 RID: 50264 RVA: 0x002F2150 File Offset: 0x002F0550
	private void _OnClickToggle1(bool value)
	{
		if (!value)
		{
			return;
		}
		this.RecruitRoot.CustomActive(value);
		this.AcceptRecruitRoot.CustomActive(!value);
		this.btRecruitList.CustomActive(value);
		this.RecruitmentBonusPreview_CompanionRoot.CustomActive(false);
		this.RecruitmentBonusPreview_AcceptRoot.CustomActive(false);
		this.BindSuccessedRoot.CustomActive(false);
		this.list.CustomActive(false);
		this._RefreshInvoiteCodeRoot();
		this.warriorRecruitTabType = WarriorRecruitTabType.companion;
		if (WarriorRecruitDataManager.isOtherBindMe)
		{
			this._UpdateCompanionData();
			this.SetScrollRectValue();
		}
		else
		{
			this._CreatCompanionBonusPreview();
		}
	}

	// Token: 0x0600C459 RID: 50265 RVA: 0x002F21EC File Offset: 0x002F05EC
	private void _OnClickToggle2(bool value)
	{
		if (!value)
		{
			return;
		}
		this.RecruitRoot.CustomActive(!value);
		this.AcceptRecruitRoot.CustomActive(value);
		this.btRecruitList.CustomActive(!value);
		this.RecruitmentBonusPreview_CompanionRoot.CustomActive(false);
		this.RecruitmentBonusPreview_AcceptRoot.CustomActive(false);
		this.BindSuccessedRoot.CustomActive(false);
		this.list.CustomActive(false);
		this.warriorRecruitTabType = WarriorRecruitTabType.accept;
		if (WarriorRecruitDataManager.isBindInviteCode)
		{
			this.BindSuccessedRoot.CustomActive(true);
			this._UpdateAcceptData();
			this.SetScrollRectValue();
		}
		else
		{
			this._CreatAcceptBonusPreview();
		}
	}

	// Token: 0x0600C45A RID: 50266 RVA: 0x002F2290 File Offset: 0x002F0690
	private void _CreatCompanionBonusPreview()
	{
		if (!this.RecruitmentBonusPreview_Companion_IsCreat)
		{
			this.RecruitmentBonusPreview_Companion_IsCreat = true;
			for (int i = 0; i < DataManager<WarriorRecruitDataManager>.GetInstance().mRecruitmentBonusPreview_OldPlayerList.Count; i++)
			{
				int tableId = DataManager<WarriorRecruitDataManager>.GetInstance().mRecruitmentBonusPreview_OldPlayerList[i];
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(tableId, 100, 0);
				if (itemData != null)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.RecruitmentBonusPreview_ComItemPrefab);
					if (gameObject != null)
					{
						Utility.AttachTo(gameObject, this.RecruitmentBonusPreview_Companion_ItemParent, false);
						ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
						if (component != null)
						{
							Button com = component.GetCom<Button>("Iconbtn");
							Image com2 = component.GetCom<Image>("Icon");
							Image com3 = component.GetCom<Image>("backgroud");
							if (com != null)
							{
								com.onClick.RemoveAllListeners();
								com.onClick.AddListener(delegate()
								{
									DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
								});
							}
							if (com3 != null)
							{
								ETCImageLoader.LoadSprite(ref com3, itemData.GetQualityInfo().Background, true);
							}
							if (com2 != null)
							{
								ETCImageLoader.LoadSprite(ref com2, itemData.Icon, true);
							}
						}
						gameObject.CustomActive(true);
					}
				}
			}
		}
		this.RecruitmentBonusPreview_CompanionRoot.CustomActive(true);
	}

	// Token: 0x0600C45B RID: 50267 RVA: 0x002F23F4 File Offset: 0x002F07F4
	private void _CreatAcceptBonusPreview()
	{
		if (!this.RecruitmentBonusPreview_Accept_IsCreat)
		{
			this.RecruitmentBonusPreview_Accept_IsCreat = true;
			for (int i = 0; i < DataManager<WarriorRecruitDataManager>.GetInstance().mRecruitmentBonusPreview_NewPlayerList.Count; i++)
			{
				int tableId = DataManager<WarriorRecruitDataManager>.GetInstance().mRecruitmentBonusPreview_NewPlayerList[i];
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(tableId, 100, 0);
				if (itemData != null)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.RecruitmentBonusPreview_ComItemPrefab);
					if (gameObject != null)
					{
						Utility.AttachTo(gameObject, this.RecruitmentBonusPreview_Accept_ItemParent, false);
						ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
						if (component != null)
						{
							Button com = component.GetCom<Button>("Iconbtn");
							Image com2 = component.GetCom<Image>("Icon");
							Image com3 = component.GetCom<Image>("backgroud");
							if (com != null)
							{
								com.onClick.RemoveAllListeners();
								com.onClick.AddListener(delegate()
								{
									DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
								});
							}
							if (com3 != null)
							{
								ETCImageLoader.LoadSprite(ref com3, itemData.GetQualityInfo().Background, true);
							}
							if (com2 != null)
							{
								ETCImageLoader.LoadSprite(ref com2, itemData.Icon, true);
							}
						}
						gameObject.CustomActive(true);
					}
				}
			}
		}
		this.RecruitmentBonusPreview_AcceptRoot.CustomActive(true);
	}

	// Token: 0x0600C45C RID: 50268 RVA: 0x002F2558 File Offset: 0x002F0958
	private void _UpdateCompanionData()
	{
		this.list.CustomActive(true);
		this.targetTaskList.Clear();
		this.targetTaskList.AddRange(DataManager<WarriorRecruitDataManager>.GetInstance().mRecruitCompanionsTaskList);
		this.targetTaskList.Sort(new Comparison<WarriorRecruitTaskDataModel>(this.Cmp));
		this._RefreshItemListCount();
	}

	// Token: 0x0600C45D RID: 50269 RVA: 0x002F25B0 File Offset: 0x002F09B0
	private void _UpdateAcceptData()
	{
		this.list.CustomActive(true);
		this.targetTaskList.Clear();
		if ((WarriorRecruitDataManager.identify & 2) != 0)
		{
			this.targetTaskList = DataManager<WarriorRecruitDataManager>.GetInstance().FilterRecruiIdentifyTask(2);
		}
		else if ((WarriorRecruitDataManager.identify & 8) != 0)
		{
			this.targetTaskList = DataManager<WarriorRecruitDataManager>.GetInstance().FilterRecruiIdentifyTask(8);
		}
		this.targetTaskList.Sort(new Comparison<WarriorRecruitTaskDataModel>(this.Cmp));
		this._RefreshItemListCount();
	}

	// Token: 0x0600C45E RID: 50270 RVA: 0x002F2630 File Offset: 0x002F0A30
	private void _RefreshAcceptRecruitmentToggle()
	{
		bool bActive = DataManager<WarriorRecruitDataManager>.GetInstance().IsAcceptRecruitTabShow();
		this.tgToggle2.CustomActive(bActive);
	}

	// Token: 0x0600C45F RID: 50271 RVA: 0x002F2654 File Offset: 0x002F0A54
	private void _RefreshInvoiteCodeRoot()
	{
		if (this.InvoiteCodeRoot != null)
		{
			this.InvoiteCodeRoot.CustomActive((WarriorRecruitDataManager.identify & 4) != 0);
		}
	}

	// Token: 0x0600C460 RID: 50272 RVA: 0x002F2680 File Offset: 0x002F0A80
	private void _InitInterface()
	{
		if (this.InvoiteCodeInputField != null)
		{
			this.InvoiteCodeInputField.text = WarriorRecruitDataManager.inviteCode;
		}
		if (this.BindInvoiteCodeRoot != null)
		{
			this.BindInvoiteCodeRoot.CustomActive(!WarriorRecruitDataManager.isBindInviteCode);
		}
		this._RefreshWarriorRecruitCoin();
	}

	// Token: 0x0600C461 RID: 50273 RVA: 0x002F26D8 File Offset: 0x002F0AD8
	private void _OnInputInvoiteCodeClick(string value)
	{
		this.sInvoiteCode = value;
	}

	// Token: 0x0600C462 RID: 50274 RVA: 0x002F26E1 File Offset: 0x002F0AE1
	private void _OnInvoiteCodeClick(string value)
	{
		this.InvoiteCodeInputField.text = WarriorRecruitDataManager.inviteCode;
	}

	// Token: 0x0600C463 RID: 50275 RVA: 0x002F26F4 File Offset: 0x002F0AF4
	private void _OnBindInvoiteCodeClick()
	{
		if (this.sInvoiteCode == string.Empty)
		{
			SystemNotifyManager.SysNotifyTextAnimation("请输入邀请码", CommonTipsDesc.eShowMode.SI_UNIQUE);
			return;
		}
		this.sInvoiteCode = this.sInvoiteCode.Replace("\n", string.Empty).Replace(" ", string.Empty).Replace("\t", string.Empty).Replace("\r", string.Empty);
		if (this.sInvoiteCode == WarriorRecruitDataManager.inviteCode)
		{
			SystemNotifyManager.SysNotifyTextAnimation("不能邀请自己", CommonTipsDesc.eShowMode.SI_UNIQUE);
			return;
		}
		DataManager<WarriorRecruitDataManager>.GetInstance().SendUseHireCodeReq(this.sInvoiteCode);
	}

	// Token: 0x0600C464 RID: 50276 RVA: 0x002F279C File Offset: 0x002F0B9C
	private void _RefreshWarriorRecruitCoin()
	{
		if (this.CoinNum != null)
		{
			this.CoinNum.text = DataManager<AccountShopDataManager>.GetInstance().GetAccountSpecialItemNum(AccountCounterType.ACC_COUNTER_HIRE_COIN).ToString();
		}
	}

	// Token: 0x0600C465 RID: 50277 RVA: 0x002F27DF File Offset: 0x002F0BDF
	private int Cmp(WarriorRecruitTaskDataModel left, WarriorRecruitTaskDataModel right)
	{
		if (left.state != right.state)
		{
			return ActiveItemObject.ms_sort_order[left.state] - ActiveItemObject.ms_sort_order[right.state];
		}
		return left.taskId - right.taskId;
	}

	// Token: 0x04006FB6 RID: 28598
	public Text ActivityName;

	// Token: 0x04006FB7 RID: 28599
	public Text ActivityTime;

	// Token: 0x04006FB8 RID: 28600
	public Button btCopyInviteCode;

	// Token: 0x04006FB9 RID: 28601
	public Text CoinNum;

	// Token: 0x04006FBA RID: 28602
	public Button btRecruitList;

	// Token: 0x04006FBB RID: 28603
	public Button btRecruitShop;

	// Token: 0x04006FBC RID: 28604
	public Toggle tgToggle1;

	// Token: 0x04006FBD RID: 28605
	public Toggle tgToggle2;

	// Token: 0x04006FBE RID: 28606
	public ComUIListScript list;

	// Token: 0x04006FBF RID: 28607
	public GameObject InvoiteCodeRoot;

	// Token: 0x04006FC0 RID: 28608
	public InputField InputInvoiteCode;

	// Token: 0x04006FC1 RID: 28609
	public InputField InvoiteCodeInputField;

	// Token: 0x04006FC2 RID: 28610
	public Button BindInvoiteCode;

	// Token: 0x04006FC3 RID: 28611
	public GameObject BindInvoiteCodeRoot;

	// Token: 0x04006FC4 RID: 28612
	public GameObject RecruitRoot;

	// Token: 0x04006FC5 RID: 28613
	public GameObject AcceptRecruitRoot;

	// Token: 0x04006FC6 RID: 28614
	public ScrollRect Rect;

	// Token: 0x04006FC7 RID: 28615
	public GameObject RecruitmentBonusPreview_CompanionRoot;

	// Token: 0x04006FC8 RID: 28616
	public GameObject RecruitmentBonusPreview_AcceptRoot;

	// Token: 0x04006FC9 RID: 28617
	public GameObject RecruitmentBonusPreview_ComItemPrefab;

	// Token: 0x04006FCA RID: 28618
	public GameObject RecruitmentBonusPreview_Companion_ItemParent;

	// Token: 0x04006FCB RID: 28619
	public GameObject RecruitmentBonusPreview_Accept_ItemParent;

	// Token: 0x04006FCC RID: 28620
	public GameObject BindSuccessedRoot;

	// Token: 0x04006FCD RID: 28621
	private List<WarriorRecruitTaskDataModel> targetTaskList = new List<WarriorRecruitTaskDataModel>();

	// Token: 0x04006FCE RID: 28622
	private string sInvoiteCode = string.Empty;

	// Token: 0x04006FCF RID: 28623
	private int warriorRecruitActiveID = 8800;

	// Token: 0x04006FD0 RID: 28624
	private WarriorRecruitTabType warriorRecruitTabType;

	// Token: 0x04006FD1 RID: 28625
	private bool RecruitmentBonusPreview_Companion_IsCreat;

	// Token: 0x04006FD2 RID: 28626
	private bool RecruitmentBonusPreview_Accept_IsCreat;
}
