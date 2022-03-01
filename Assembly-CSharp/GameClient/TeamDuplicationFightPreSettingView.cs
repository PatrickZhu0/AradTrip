using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C4D RID: 7245
	public class TeamDuplicationFightPreSettingView : MonoBehaviour
	{
		// Token: 0x06011CA6 RID: 72870 RVA: 0x005356A6 File Offset: 0x00533AA6
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011CA7 RID: 72871 RVA: 0x005356AE File Offset: 0x00533AAE
		private void OnDestroy()
		{
			this.UnBindUiEvents();
		}

		// Token: 0x06011CA8 RID: 72872 RVA: 0x005356B8 File Offset: 0x00533AB8
		private void BindUiEvents()
		{
			if (this.freeModeButton != null)
			{
				this.freeModeButton.onClick.RemoveAllListeners();
				this.freeModeButton.onClick.AddListener(new UnityAction(this.OnFreeModeButtonClick));
			}
			if (this.guideModeButton != null)
			{
				this.guideModeButton.onClick.RemoveAllListeners();
				this.guideModeButton.onClick.AddListener(new UnityAction(this.OnGuideModeButtonClick));
			}
		}

		// Token: 0x06011CA9 RID: 72873 RVA: 0x00535740 File Offset: 0x00533B40
		private void UnBindUiEvents()
		{
			if (this.freeModeButton != null)
			{
				this.freeModeButton.onClick.RemoveAllListeners();
			}
			if (this.guideModeButton != null)
			{
				this.guideModeButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06011CAA RID: 72874 RVA: 0x0053578F File Offset: 0x00533B8F
		public void Init()
		{
			this.InitData();
			this.InitView();
		}

		// Token: 0x06011CAB RID: 72875 RVA: 0x0053579D File Offset: 0x00533B9D
		private void InitData()
		{
		}

		// Token: 0x06011CAC RID: 72876 RVA: 0x0053579F File Offset: 0x00533B9F
		private void InitView()
		{
			this.InitFreeMode();
			this.InitGuideMode();
		}

		// Token: 0x06011CAD RID: 72877 RVA: 0x005357AD File Offset: 0x00533BAD
		private void InitFreeMode()
		{
			if (this.freeModeContentText != null)
			{
				this.freeModeContentText.text = TR.Value("team_duplication_fight_pre_setting_free_mode_content");
			}
		}

		// Token: 0x06011CAE RID: 72878 RVA: 0x005357D5 File Offset: 0x00533BD5
		private void InitGuideMode()
		{
			if (this.guideModeContentText != null)
			{
				this.guideModeContentText.text = TR.Value("team_duplication_fight_pre_setting_guide_mode_content");
			}
		}

		// Token: 0x06011CAF RID: 72879 RVA: 0x00535800 File Offset: 0x00533C00
		private void OnFreeModeButtonClick()
		{
			string contentStr = string.Format(TR.Value("team_duplication_model_sure_content"), TR.Value("team_duplication_fight_pre_setting_free_mode"), TR.Value("team_duplication_fight_pre_setting_guide_mode"));
			TeamDuplicationUtility.OnShowCommonMsgBoxFrame(contentStr, new Action(this.OnFreeModelSureAction), 3);
		}

		// Token: 0x06011CB0 RID: 72880 RVA: 0x00535844 File Offset: 0x00533C44
		private void OnGuideModeButtonClick()
		{
			DataManager<TeamDuplicationDataManager>.GetInstance().FightSettingConfigPlanModel = TeamCopyPlanModel.TEAM_COPY_PLAN_MODEL_GUIDE;
			if (DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationTeamDifficultyConfigNotSet())
			{
				TeamDuplicationUtility.SetTeamDuplicationDefaultCaptainDifficultySetting();
			}
			TeamDuplicationUtility.OnOpenTeamDuplicationFightSettingDifficultyFrame();
		}

		// Token: 0x06011CB1 RID: 72881 RVA: 0x0053586A File Offset: 0x00533C6A
		private void OnFreeModelSureAction()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationFightPreSettingFrame();
			DataManager<TeamDuplicationDataManager>.GetInstance().FightSettingConfigPlanModel = TeamCopyPlanModel.TEAM_COPY_PLAN_MODEL_FREE;
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_setting_free_model_ok"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0400B95A RID: 47450
		[Space(15f)]
		[Header("freeMode")]
		[Space(10f)]
		[SerializeField]
		private Button freeModeButton;

		// Token: 0x0400B95B RID: 47451
		[SerializeField]
		private Text freeModeContentText;

		// Token: 0x0400B95C RID: 47452
		[Space(15f)]
		[Header("guideMode")]
		[Space(10f)]
		[SerializeField]
		private Button guideModeButton;

		// Token: 0x0400B95D RID: 47453
		[SerializeField]
		private Text guideModeSpecialText;

		// Token: 0x0400B95E RID: 47454
		[SerializeField]
		private Text guideModeContentText;
	}
}
