using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C36 RID: 7222
	public class TeamDuplicationTeamSettingView : MonoBehaviour
	{
		// Token: 0x06011BA1 RID: 72609 RVA: 0x005317A0 File Offset: 0x0052FBA0
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011BA2 RID: 72610 RVA: 0x005317A8 File Offset: 0x0052FBA8
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011BA3 RID: 72611 RVA: 0x005317B6 File Offset: 0x0052FBB6
		private void ClearData()
		{
			this._teamType = TeamCopyTeamModel.TEAM_COPY_TEAM_MODEL_CHALLENGE;
			this._equipmentScoreValue = 0;
			this._goldValueNumber = 0;
			this.equipmentScoreDataList = null;
			this.goldValueDataList = null;
			this.defaultEquipmentScoreData = null;
			this.defaultGoldValueData = null;
			this._teamDifficultyLevel = 0U;
		}

		// Token: 0x06011BA4 RID: 72612 RVA: 0x005317F0 File Offset: 0x0052FBF0
		private void BindUiEvents()
		{
			if (this.buildButton != null)
			{
				this.buildButton.onClick.RemoveAllListeners();
				this.buildButton.onClick.AddListener(new UnityAction(this.OnBuildButtonClick));
			}
			if (this.cancelButton != null)
			{
				this.cancelButton.onClick.RemoveAllListeners();
				this.cancelButton.onClick.AddListener(new UnityAction(this.OnCancelButtonClick));
			}
			if (this.settingButton != null)
			{
				this.settingButton.onClick.RemoveAllListeners();
				this.settingButton.onClick.AddListener(new UnityAction(this.OnSettingButtonClick));
			}
		}

		// Token: 0x06011BA5 RID: 72613 RVA: 0x005318B4 File Offset: 0x0052FCB4
		private void UnBindUiEvents()
		{
			if (this.buildButton != null)
			{
				this.buildButton.onClick.RemoveAllListeners();
			}
			if (this.cancelButton != null)
			{
				this.cancelButton.onClick.RemoveAllListeners();
			}
			if (this.settingButton != null)
			{
				this.settingButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06011BA6 RID: 72614 RVA: 0x00531924 File Offset: 0x0052FD24
		public void Init(TeamCopyTeamModel teamType, uint teamDifficultyLevel = 0U, bool isResetEquipmentScore = false, int ownerEquipmentScore = 0)
		{
			bool isIn65LevelTeamDuplication = TeamDuplicationUtility.IsIn65LevelTeamDuplication();
			this._teamDifficultyLevel = teamDifficultyLevel;
			if (teamType == TeamCopyTeamModel.TEAM_COPY_TEAM_MODEL_GOLD)
			{
				this._teamType = teamType;
			}
			else
			{
				this._teamType = TeamCopyTeamModel.TEAM_COPY_TEAM_MODEL_CHALLENGE;
			}
			this._isResetEquipmentScore = isResetEquipmentScore;
			this._ownerEquipmentScore = ownerEquipmentScore;
			this.equipmentScoreDataList = TeamDuplicationUtility.GetTeamPropertyDataListByType(this._teamType, TeamDuplicationTeamPropertyType.EquipmentScoreType, isIn65LevelTeamDuplication);
			if (this.equipmentScoreDataList != null && this.equipmentScoreDataList.Count > 0)
			{
				if (!this._isResetEquipmentScore)
				{
					this.defaultEquipmentScoreData = this.equipmentScoreDataList[0];
					this._equipmentScoreValue = this.defaultEquipmentScoreData.Index;
				}
				else
				{
					this.defaultEquipmentScoreData = this.equipmentScoreDataList[0];
					for (int i = 0; i < this.equipmentScoreDataList.Count; i++)
					{
						ComControlData comControlData = this.equipmentScoreDataList[i];
						if (comControlData != null)
						{
							if (comControlData.Index == this._ownerEquipmentScore)
							{
								this.defaultEquipmentScoreData = comControlData;
								break;
							}
						}
					}
					this._equipmentScoreValue = this.defaultEquipmentScoreData.Index;
				}
				if (!this._isResetEquipmentScore && this._teamType == TeamCopyTeamModel.TEAM_COPY_TEAM_MODEL_GOLD)
				{
					this.goldValueDataList = TeamDuplicationUtility.GetTeamPropertyDataListByType(this._teamType, TeamDuplicationTeamPropertyType.GoldValueType, isIn65LevelTeamDuplication);
					if (this.goldValueDataList == null || this.goldValueDataList.Count <= 0)
					{
						Logger.LogErrorFormat("goldValueDataList is null or count is zero", new object[0]);
						return;
					}
					this.defaultGoldValueData = this.goldValueDataList[0];
					this._goldValueNumber = this.defaultGoldValueData.Index;
				}
				this.InitView();
				return;
			}
			Logger.LogErrorFormat("EquipmentScoreDataList is null or count is zero", new object[0]);
		}

		// Token: 0x06011BA7 RID: 72615 RVA: 0x00531AD8 File Offset: 0x0052FED8
		private void InitView()
		{
			this.InitTitle();
			this.InitContent();
			this.InitSettingDropDownControl();
			this.InitTeamSettingButton();
		}

		// Token: 0x06011BA8 RID: 72616 RVA: 0x00531AF2 File Offset: 0x0052FEF2
		private void InitTitle()
		{
			if (this.titleLabel != null)
			{
				this.titleLabel.text = TR.Value("team_duplication_team_setting_title");
			}
		}

		// Token: 0x06011BA9 RID: 72617 RVA: 0x00531B1C File Offset: 0x0052FF1C
		private void InitContent()
		{
			if (this.typeSettingLabel != null)
			{
				this.typeSettingLabel.text = TR.Value("team_duplication_team_setting_model_label");
			}
			if (this.equipmentScoreLabel != null)
			{
				this.equipmentScoreLabel.text = TR.Value("team_duplication_team_setting_equipment_score_label");
			}
			if (this._teamType == TeamCopyTeamModel.TEAM_COPY_TEAM_MODEL_GOLD)
			{
				CommonUtility.UpdateGameObjectVisible(this.challengeTypeRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.goldTypeRoot, true);
				if (this.goldTypeText != null)
				{
					this.goldTypeText.text = TR.Value("team_duplication_team_build_gold_type");
				}
				if (!this._isResetEquipmentScore)
				{
					CommonUtility.UpdateGameObjectVisible(this.goldValueRoot, true);
					if (this.goldValueLabel != null)
					{
						this.goldValueLabel.text = TR.Value("team_duplication_team_setting_gold_value_label");
					}
				}
				else
				{
					CommonUtility.UpdateGameObjectVisible(this.goldValueRoot, false);
				}
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.goldTypeRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.goldValueRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.challengeTypeRoot, true);
				if (this.challengeTypeText != null)
				{
					this.challengeTypeText.text = TR.Value("team_duplication_team_build_challenge_Type");
				}
			}
		}

		// Token: 0x06011BAA RID: 72618 RVA: 0x00531C5C File Offset: 0x0053005C
		private void InitSettingDropDownControl()
		{
			if (this.equipmentScoreDropDownControl != null)
			{
				this.equipmentScoreDropDownControl.InitComDropDownControl(this.defaultEquipmentScoreData, this.equipmentScoreDataList, new OnCommonNewDropDownItemButtonClick(this.OnEquipmentScoreDropDownItemSelected), new Action(this.OnResetEquipmentScoreDropDownAction));
			}
			if (this.goldValueDropDownControl != null && this._teamType == TeamCopyTeamModel.TEAM_COPY_TEAM_MODEL_GOLD && !this._isResetEquipmentScore)
			{
				this.goldValueDropDownControl.InitComDropDownControl(this.defaultGoldValueData, this.goldValueDataList, new OnCommonNewDropDownItemButtonClick(this.OnGoldValueDropDownItemSelected), new Action(this.OnResetGoldValueDropDownAction));
			}
		}

		// Token: 0x06011BAB RID: 72619 RVA: 0x00531D00 File Offset: 0x00530100
		private void InitTeamSettingButton()
		{
			if (!this._isResetEquipmentScore)
			{
				CommonUtility.UpdateButtonVisible(this.buildButton, true);
				CommonUtility.UpdateButtonVisible(this.settingButton, false);
			}
			else
			{
				CommonUtility.UpdateButtonVisible(this.buildButton, false);
				CommonUtility.UpdateButtonVisible(this.settingButton, true);
			}
		}

		// Token: 0x06011BAC RID: 72620 RVA: 0x00531D4D File Offset: 0x0053014D
		private void OnResetEquipmentScoreDropDownAction()
		{
			if (this.goldValueDropDownControl != null && this._teamType == TeamCopyTeamModel.TEAM_COPY_TEAM_MODEL_GOLD)
			{
				this.goldValueDropDownControl.UpdateDropDownList(false);
			}
		}

		// Token: 0x06011BAD RID: 72621 RVA: 0x00531D78 File Offset: 0x00530178
		private void OnResetGoldValueDropDownAction()
		{
			if (this.equipmentScoreDropDownControl != null)
			{
				this.equipmentScoreDropDownControl.UpdateDropDownList(false);
			}
		}

		// Token: 0x06011BAE RID: 72622 RVA: 0x00531D97 File Offset: 0x00530197
		private void OnEquipmentScoreDropDownItemSelected(ComControlData comControlData)
		{
			this._equipmentScoreValue = comControlData.Index;
		}

		// Token: 0x06011BAF RID: 72623 RVA: 0x00531DA5 File Offset: 0x005301A5
		private void OnGoldValueDropDownItemSelected(ComControlData comControlData)
		{
			this._goldValueNumber = comControlData.Index;
		}

		// Token: 0x06011BB0 RID: 72624 RVA: 0x00531DB3 File Offset: 0x005301B3
		private void OnCancelButtonClick()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamSettingFrame();
		}

		// Token: 0x06011BB1 RID: 72625 RVA: 0x00531DBC File Offset: 0x005301BC
		private void OnBuildButtonClick()
		{
			if (this._equipmentScoreValue <= 0)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_team_build_equipment_is_zero"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this._teamType == TeamCopyTeamModel.TEAM_COPY_TEAM_MODEL_GOLD && this._goldValueNumber <= 0)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_team_build_gold_value_is_zero"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamSettingFrame();
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamBuildFrame();
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyCreateTeamReq((uint)this._teamType, (uint)this._equipmentScoreValue, (uint)this._goldValueNumber, this._teamDifficultyLevel);
		}

		// Token: 0x06011BB2 RID: 72626 RVA: 0x00531E40 File Offset: 0x00530240
		private void OnSettingButtonClick()
		{
			string msgContent = TR.Value("team_duplication_team_Resetting_equipment_score", this._equipmentScoreValue);
			SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			int teamDuplicationEquipmentScore = TeamDuplicationUtility.GetTeamDuplicationEquipmentScore();
			if (teamDuplicationEquipmentScore != this._equipmentScoreValue)
			{
				DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyModifyEquipScoreReq(this._equipmentScoreValue);
			}
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamSettingFrame();
		}

		// Token: 0x0400B8C0 RID: 47296
		private uint _teamDifficultyLevel;

		// Token: 0x0400B8C1 RID: 47297
		private TeamCopyTeamModel _teamType = TeamCopyTeamModel.TEAM_COPY_TEAM_MODEL_CHALLENGE;

		// Token: 0x0400B8C2 RID: 47298
		private bool _isResetEquipmentScore;

		// Token: 0x0400B8C3 RID: 47299
		private int _ownerEquipmentScore;

		// Token: 0x0400B8C4 RID: 47300
		private int _equipmentScoreValue;

		// Token: 0x0400B8C5 RID: 47301
		private int _goldValueNumber;

		// Token: 0x0400B8C6 RID: 47302
		private ComControlData defaultEquipmentScoreData;

		// Token: 0x0400B8C7 RID: 47303
		private ComControlData defaultGoldValueData;

		// Token: 0x0400B8C8 RID: 47304
		private List<ComControlData> equipmentScoreDataList;

		// Token: 0x0400B8C9 RID: 47305
		private List<ComControlData> goldValueDataList;

		// Token: 0x0400B8CA RID: 47306
		[Space(15f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x0400B8CB RID: 47307
		[SerializeField]
		private Button buildButton;

		// Token: 0x0400B8CC RID: 47308
		[SerializeField]
		private Button cancelButton;

		// Token: 0x0400B8CD RID: 47309
		[SerializeField]
		private Button settingButton;

		// Token: 0x0400B8CE RID: 47310
		[Space(15f)]
		[Header("Mode")]
		[Space(10f)]
		[SerializeField]
		private Text typeSettingLabel;

		// Token: 0x0400B8CF RID: 47311
		[SerializeField]
		private GameObject challengeTypeRoot;

		// Token: 0x0400B8D0 RID: 47312
		[SerializeField]
		private Text challengeTypeText;

		// Token: 0x0400B8D1 RID: 47313
		[SerializeField]
		private GameObject goldTypeRoot;

		// Token: 0x0400B8D2 RID: 47314
		[SerializeField]
		private Text goldTypeText;

		// Token: 0x0400B8D3 RID: 47315
		[Space(15f)]
		[Header("EquipmentScore")]
		[Space(10f)]
		[SerializeField]
		private Text equipmentScoreLabel;

		// Token: 0x0400B8D4 RID: 47316
		[SerializeField]
		private CommonNewDropDownControl equipmentScoreDropDownControl;

		// Token: 0x0400B8D5 RID: 47317
		[Space(15f)]
		[Header("Gold")]
		[Space(10f)]
		[SerializeField]
		private GameObject goldValueRoot;

		// Token: 0x0400B8D6 RID: 47318
		[SerializeField]
		private Text goldValueLabel;

		// Token: 0x0400B8D7 RID: 47319
		[SerializeField]
		private CommonNewDropDownControl goldValueDropDownControl;
	}
}
