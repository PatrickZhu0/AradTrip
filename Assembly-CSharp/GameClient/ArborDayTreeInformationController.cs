using System;
using System.Collections.Generic;
using Protocol;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001874 RID: 6260
	public class ArborDayTreeInformationController : MonoBehaviour
	{
		// Token: 0x0600F543 RID: 62787 RVA: 0x004227C4 File Offset: 0x00420BC4
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600F544 RID: 62788 RVA: 0x004227CC File Offset: 0x00420BCC
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600F545 RID: 62789 RVA: 0x004227DC File Offset: 0x00420BDC
		private void ClearData()
		{
			this._timeInterval = 0f;
			this._treeGrowingEndTimeStamp = 0U;
			if (this._treeIdentifyIdList != null)
			{
				this._treeIdentifyIdList.Clear();
				this._treeIdentifyIdList = null;
			}
			if (this._treeIdentifyIdStrList != null)
			{
				this._treeIdentifyIdStrList.Clear();
				this._treeIdentifyIdStrList = null;
			}
			this._model = null;
			this._treePlantState = PlantOpActSate.POPS_NONE;
		}

		// Token: 0x0600F546 RID: 62790 RVA: 0x00422844 File Offset: 0x00420C44
		private void BindUiEvents()
		{
			if (this.treePlantingButton != null)
			{
				this.treePlantingButton.ResetButtonListener();
				this.treePlantingButton.SetButtonListener(new Action(this.OnTreePlantingButtonClicked));
			}
			if (this.treeIdentifyButton != null)
			{
				this.treeIdentifyButton.ResetButtonListener();
				this.treeIdentifyButton.SetButtonListener(new Action(this.OnTreeIdentifyButtonClicked));
			}
			if (this.treeIdentifyItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.treeIdentifyItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnTreeIdentifyItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.treeIdentifyItemList;
				comUIListScriptEx2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScriptEx2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnTreeIdentifyItemUpdate));
				ComUIListScriptEx comUIListScriptEx3 = this.treeIdentifyItemList;
				comUIListScriptEx3.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx3.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnTreeIdentifyItemRecycle));
			}
		}

		// Token: 0x0600F547 RID: 62791 RVA: 0x00422940 File Offset: 0x00420D40
		private void UnBindUiEvents()
		{
			if (this.treePlantingButton != null)
			{
				this.treePlantingButton.ResetButtonListener();
			}
			if (this.treeIdentifyButton != null)
			{
				this.treeIdentifyButton.ResetButtonListener();
			}
			if (this.treeIdentifyItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.treeIdentifyItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnTreeIdentifyItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.treeIdentifyItemList;
				comUIListScriptEx2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScriptEx2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnTreeIdentifyItemUpdate));
				ComUIListScriptEx comUIListScriptEx3 = this.treeIdentifyItemList;
				comUIListScriptEx3.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx3.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnTreeIdentifyItemRecycle));
			}
		}

		// Token: 0x0600F548 RID: 62792 RVA: 0x00422A0B File Offset: 0x00420E0B
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChangeChanged));
		}

		// Token: 0x0600F549 RID: 62793 RVA: 0x00422A28 File Offset: 0x00420E28
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChangeChanged));
		}

		// Token: 0x0600F54A RID: 62794 RVA: 0x00422A48 File Offset: 0x00420E48
		private void OnCountValueChangeChanged(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			string a = (string)uiEvent.Param1;
			if (string.Equals(a, this._treeProficiencyStr))
			{
				this.UpdateTreeProficiencyValue();
				return;
			}
			if (string.Equals(a, this._treePlantStateStr))
			{
				this.UpdateTreePlantState();
				return;
			}
			if (string.Equals(a, this._treeGrowingEndTimeStampStr))
			{
				this._treeGrowingEndTimeStamp = (uint)ArborDayUtility.GetCounterValueByCounterStr(this._treeGrowingEndTimeStampStr);
				this.UpdateTreeGrowingLastTimeContent();
			}
		}

		// Token: 0x0600F54B RID: 62795 RVA: 0x00422ACC File Offset: 0x00420ECC
		private void InitTreeInformationDataFromActivityModel()
		{
			string[] strParam = this._model.StrParam;
			if (strParam != null && strParam.Length == 4)
			{
				this._treeProficiencyStr = strParam[0];
				this._treeGrowingLastTimeStr = strParam[1];
				this._treePlantStateStr = strParam[2];
				this._treeGrowingEndTimeStampStr = strParam[3];
			}
			this._treeIdentifyIdList = new List<int>();
			if (this._model.ParamArray != null && this._model.ParamArray.Length > 0)
			{
				for (int i = 0; i < this._model.ParamArray.Length; i++)
				{
					uint num = this._model.ParamArray[i];
					if (num > 0U)
					{
						this._treeIdentifyIdList.Add((int)num);
					}
				}
			}
			this._treeIdentifyIdStrList = CommonUtility.GetStrListBySplitString(this._model.CountParam);
		}

		// Token: 0x0600F54C RID: 62796 RVA: 0x00422B9B File Offset: 0x00420F9B
		public void InitTreeInformationController(ILimitTimeActivityModel model)
		{
			this._model = model;
			if (this._model == null)
			{
				return;
			}
			this.InitTreeInformationDataFromActivityModel();
			this.InitTreeInformationBaseContent();
			this.OnUpdateTreeInformationContent();
		}

		// Token: 0x0600F54D RID: 62797 RVA: 0x00422BC4 File Offset: 0x00420FC4
		private void InitTreeInformationBaseContent()
		{
			if (this.activityTimeLabel != null)
			{
				string text = string.Format(TR.Value("Limit_Time_Activity_Time_Interval_Format"), TimeUtility.GetTimeFormatByYearMonthDay(this._model.StartTime), TimeUtility.GetTimeFormatByYearMonthDay(this._model.EndTime));
				this.activityTimeLabel.text = text;
			}
			if (this.treeProficiencyTitleLabel != null)
			{
				this.treeProficiencyTitleLabel.text = TR.Value("Arbor_Day_Proficiency_Title");
			}
			if (this.treeProficiencyContentLabel != null)
			{
				this.treeProficiencyContentLabel.text = TR.Value("Arbor_Day_Proficiency_Introduction");
			}
			if (this.treeIdentifyTitleLabel != null)
			{
				this.treeIdentifyTitleLabel.text = TR.Value("Arbor_Day_Get_Tree_Title");
			}
			if (this.treeIdentifyFinishLabel != null)
			{
				this.treeIdentifyFinishLabel.text = TR.Value("Arbor_Day_Already_Identify_All_Tree");
			}
		}

		// Token: 0x0600F54E RID: 62798 RVA: 0x00422CB6 File Offset: 0x004210B6
		private void OnUpdateTreeInformationContent()
		{
			this.UpdateTreeProficiencyValue();
			this.UpdateTreePlantState();
			this.UpdateTreeIdentifyItemList();
		}

		// Token: 0x0600F54F RID: 62799 RVA: 0x00422CCC File Offset: 0x004210CC
		private void UpdateTreeProficiencyValue()
		{
			if (this.treeProficiencyValueText != null)
			{
				int counterValueByCounterStr = ArborDayUtility.GetCounterValueByCounterStr(this._treeProficiencyStr);
				this.treeProficiencyValueText.text = counterValueByCounterStr.ToString();
			}
		}

		// Token: 0x0600F550 RID: 62800 RVA: 0x00422D0E File Offset: 0x0042110E
		public void OnUpdateTreeInformationController(ILimitTimeActivityModel model)
		{
			this._model = model;
			if (this._model == null)
			{
				return;
			}
			this.OnUpdateTreeInformationContent();
		}

		// Token: 0x0600F551 RID: 62801 RVA: 0x00422D2C File Offset: 0x0042112C
		private void UpdateTreePlantState()
		{
			CommonUtility.UpdateGameObjectVisible(this.plantingTreeImage, false);
			CommonUtility.UpdateGameObjectVisible(this.growingTreeImage, false);
			CommonUtility.UpdateGameObjectVisible(this.identifyTreeImage, false);
			this._treePlantState = (PlantOpActSate)ArborDayUtility.GetCounterValueByCounterStr(this._treePlantStateStr);
			switch (this._treePlantState)
			{
			case PlantOpActSate.POPS_PLANTING:
				CommonUtility.UpdateButtonWithCdVisibleAndReset(this.treePlantingButton, false);
				CommonUtility.UpdateGameObjectVisible(this.treeGrowingLeftTimeRoot, true);
				this._treeGrowingEndTimeStamp = (uint)ArborDayUtility.GetCounterValueByCounterStr(this._treeGrowingEndTimeStampStr);
				this.UpdateTreeGrowingLastTimeContent();
				CommonUtility.UpdateGameObjectVisible(this.growingTreeImage, true);
				CommonUtility.UpdateButtonWithCdVisibleAndReset(this.treeIdentifyButton, false);
				CommonUtility.UpdateGameObjectVisible(this.treeIdentifyFinishRoot, false);
				break;
			case PlantOpActSate.POPS_CAN_APP:
				CommonUtility.UpdateButtonWithCdVisibleAndReset(this.treePlantingButton, false);
				CommonUtility.UpdateGameObjectVisible(this.treeGrowingLeftTimeRoot, false);
				CommonUtility.UpdateButtonWithCdVisibleAndReset(this.treeIdentifyButton, true);
				CommonUtility.UpdateGameObjectVisible(this.identifyTreeImage, true);
				CommonUtility.UpdateGameObjectVisible(this.treeIdentifyFinishRoot, false);
				break;
			case PlantOpActSate.POPS_ALLGET:
				CommonUtility.UpdateButtonWithCdVisibleAndReset(this.treePlantingButton, false);
				CommonUtility.UpdateGameObjectVisible(this.treeGrowingLeftTimeRoot, false);
				CommonUtility.UpdateButtonWithCdVisibleAndReset(this.treeIdentifyButton, false);
				CommonUtility.UpdateGameObjectVisible(this.identifyTreeImage, true);
				CommonUtility.UpdateGameObjectVisible(this.treeIdentifyFinishRoot, true);
				break;
			default:
				CommonUtility.UpdateButtonWithCdVisibleAndReset(this.treePlantingButton, true);
				CommonUtility.UpdateGameObjectVisible(this.plantingTreeImage, true);
				CommonUtility.UpdateGameObjectVisible(this.treeGrowingLeftTimeRoot, false);
				CommonUtility.UpdateButtonWithCdVisibleAndReset(this.treeIdentifyButton, false);
				CommonUtility.UpdateGameObjectVisible(this.treeIdentifyFinishRoot, false);
				break;
			}
		}

		// Token: 0x0600F552 RID: 62802 RVA: 0x00422EAC File Offset: 0x004212AC
		private void UpdateTreeIdentifyItemList()
		{
			if (this.treeIdentifyItemList == null)
			{
				return;
			}
			if (!this.treeIdentifyItemList.IsInitialised())
			{
				this.treeIdentifyItemList.Initialize();
				int elementAmount = 0;
				if (this._treeIdentifyIdList != null)
				{
					elementAmount = this._treeIdentifyIdList.Count;
				}
				this.treeIdentifyItemList.SetElementAmount(elementAmount);
			}
			else
			{
				this.treeIdentifyItemList.UpdateElement();
			}
		}

		// Token: 0x0600F553 RID: 62803 RVA: 0x00422F1C File Offset: 0x0042131C
		private void OnTreeIdentifyItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._treeIdentifyIdList == null || this._treeIdentifyIdList.Count <= 0)
			{
				return;
			}
			if (this._treeIdentifyIdStrList == null || this._treeIdentifyIdStrList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._treeIdentifyIdList.Count || item.m_index >= this._treeIdentifyIdStrList.Count)
			{
				return;
			}
			int num = this._treeIdentifyIdList[item.m_index];
			string itemIdStr = this._treeIdentifyIdStrList[item.m_index];
			ArborDayTreeIdentifyItem component = item.GetComponent<ArborDayTreeIdentifyItem>();
			if (component != null && num > 0)
			{
				component.InitItem(num, itemIdStr, item.m_index + 1);
			}
		}

		// Token: 0x0600F554 RID: 62804 RVA: 0x00422FF8 File Offset: 0x004213F8
		private void OnTreeIdentifyItemUpdate(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ArborDayTreeIdentifyItem component = item.GetComponent<ArborDayTreeIdentifyItem>();
			if (component != null)
			{
				component.UpdateItem();
			}
		}

		// Token: 0x0600F555 RID: 62805 RVA: 0x0042302C File Offset: 0x0042142C
		private void OnTreeIdentifyItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ArborDayTreeIdentifyItem component = item.GetComponent<ArborDayTreeIdentifyItem>();
			if (component != null)
			{
				component.RecycleItem();
			}
		}

		// Token: 0x0600F556 RID: 62806 RVA: 0x0042305F File Offset: 0x0042145F
		private void OnTreePlantingButtonClicked()
		{
			DataManager<ActivityDataManager>.GetInstance().OnSendSceneActivePlantReq();
		}

		// Token: 0x0600F557 RID: 62807 RVA: 0x0042306B File Offset: 0x0042146B
		private void OnTreeIdentifyButtonClicked()
		{
			DataManager<ActivityDataManager>.GetInstance().OnSendSceneActivePlantAppraReq();
		}

		// Token: 0x0600F558 RID: 62808 RVA: 0x00423078 File Offset: 0x00421478
		private void Update()
		{
			if (this._treePlantState != PlantOpActSate.POPS_PLANTING)
			{
				return;
			}
			if (this._treeGrowingEndTimeStamp <= 0U)
			{
				return;
			}
			if (this._treeGrowingEndTimeStamp < DataManager<TimeManager>.GetInstance().GetServerTime())
			{
				return;
			}
			this._timeInterval += Time.deltaTime;
			if (this._timeInterval >= 1f)
			{
				this.UpdateTreeGrowingLastTimeContent();
			}
		}

		// Token: 0x0600F559 RID: 62809 RVA: 0x004230DD File Offset: 0x004214DD
		private void UpdateTreeGrowingLastTimeContent()
		{
			this._timeInterval = 0f;
			this.UpdateTreeGrowingLeftTimeLabel();
		}

		// Token: 0x0600F55A RID: 62810 RVA: 0x004230F0 File Offset: 0x004214F0
		private void UpdateTreeGrowingLeftTimeLabel()
		{
			if (this.treeGrowingLeftTimeLabel == null)
			{
				return;
			}
			string countDownTimeByMinuteSecondFormat = CountDownTimeUtility.GetCountDownTimeByMinuteSecondFormat(this._treeGrowingEndTimeStamp, DataManager<TimeManager>.GetInstance().GetServerTime());
			this.treeGrowingLeftTimeLabel.text = TR.Value("Arbor_Day_Tree_is_in_Growing", countDownTimeByMinuteSecondFormat);
		}

		// Token: 0x0400966B RID: 38507
		private ILimitTimeActivityModel _model;

		// Token: 0x0400966C RID: 38508
		private PlantOpActSate _treePlantState;

		// Token: 0x0400966D RID: 38509
		private string _treeProficiencyStr;

		// Token: 0x0400966E RID: 38510
		private string _treeGrowingLastTimeStr;

		// Token: 0x0400966F RID: 38511
		private string _treePlantStateStr;

		// Token: 0x04009670 RID: 38512
		private string _treeGrowingEndTimeStampStr;

		// Token: 0x04009671 RID: 38513
		private List<int> _treeIdentifyIdList;

		// Token: 0x04009672 RID: 38514
		private List<string> _treeIdentifyIdStrList;

		// Token: 0x04009673 RID: 38515
		private uint _treeGrowingEndTimeStamp;

		// Token: 0x04009674 RID: 38516
		private float _timeInterval;

		// Token: 0x04009675 RID: 38517
		[Space(10f)]
		[Header("ActivityTime")]
		[Space(10f)]
		[SerializeField]
		private Text activityTimeLabel;

		// Token: 0x04009676 RID: 38518
		[Space(10f)]
		[Header("Proficiency")]
		[Space(10f)]
		[SerializeField]
		private Text treeProficiencyTitleLabel;

		// Token: 0x04009677 RID: 38519
		[SerializeField]
		private Text treeProficiencyContentLabel;

		// Token: 0x04009678 RID: 38520
		[SerializeField]
		private Text treeProficiencyValueText;

		// Token: 0x04009679 RID: 38521
		[Space(10f)]
		[Header("TreeGrowingLeftTime")]
		[Space(10f)]
		[SerializeField]
		private Text treeGrowingLeftTimeLabel;

		// Token: 0x0400967A RID: 38522
		[SerializeField]
		private GameObject treeGrowingLeftTimeRoot;

		// Token: 0x0400967B RID: 38523
		[Space(10f)]
		[Header("TreeIdentifyFinishRoot")]
		[Space(10f)]
		[SerializeField]
		private Text treeIdentifyFinishLabel;

		// Token: 0x0400967C RID: 38524
		[SerializeField]
		private GameObject treeIdentifyFinishRoot;

		// Token: 0x0400967D RID: 38525
		[Space(10f)]
		[Header("treeImageRoot")]
		[Space(10f)]
		[SerializeField]
		private GameObject plantingTreeImage;

		// Token: 0x0400967E RID: 38526
		[SerializeField]
		private GameObject growingTreeImage;

		// Token: 0x0400967F RID: 38527
		[SerializeField]
		private GameObject identifyTreeImage;

		// Token: 0x04009680 RID: 38528
		[Space(10f)]
		[Header("TreePlantButton")]
		[Space(10f)]
		[SerializeField]
		private ComButtonWithCd treePlantingButton;

		// Token: 0x04009681 RID: 38529
		[SerializeField]
		private ComButtonWithCd treeIdentifyButton;

		// Token: 0x04009682 RID: 38530
		[Space(10f)]
		[Header("identifyTree")]
		[Space(10f)]
		[SerializeField]
		private Text treeIdentifyTitleLabel;

		// Token: 0x04009683 RID: 38531
		[SerializeField]
		private ComUIListScriptEx treeIdentifyItemList;
	}
}
