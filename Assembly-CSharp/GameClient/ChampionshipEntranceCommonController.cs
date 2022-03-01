using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014E1 RID: 5345
	public class ChampionshipEntranceCommonController : MonoBehaviour
	{
		// Token: 0x0600CF61 RID: 53089 RVA: 0x00332F5A File Offset: 0x0033135A
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600CF62 RID: 53090 RVA: 0x00332F62 File Offset: 0x00331362
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600CF63 RID: 53091 RVA: 0x00332F70 File Offset: 0x00331370
		private void BindUiEvents()
		{
		}

		// Token: 0x0600CF64 RID: 53092 RVA: 0x00332F72 File Offset: 0x00331372
		private void UnBindUiEvents()
		{
		}

		// Token: 0x0600CF65 RID: 53093 RVA: 0x00332F74 File Offset: 0x00331374
		private void ClearData()
		{
			this._scheduleTable = null;
			this._avatarView = null;
		}

		// Token: 0x0600CF66 RID: 53094 RVA: 0x00332F84 File Offset: 0x00331384
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipFightRaceAllGroupMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipFightRaceAllGroupMessage));
		}

		// Token: 0x0600CF67 RID: 53095 RVA: 0x00332FA1 File Offset: 0x003313A1
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipFightRaceAllGroupMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipFightRaceAllGroupMessage));
		}

		// Token: 0x0600CF68 RID: 53096 RVA: 0x00332FC0 File Offset: 0x003313C0
		public void Init(ChampionshipScheduleTable championshipScheduleTable)
		{
			this._scheduleTable = championshipScheduleTable;
			if (this._scheduleTable == null)
			{
				return;
			}
			this.SetBigRewardScheduleId(this._scheduleTable.ID);
			if (this.scheduleIconImage != null)
			{
				ETCImageLoader.LoadSprite(ref this.scheduleIconImage, this._scheduleTable.ScheduleIconPath, true);
				this.scheduleIconImage.SetNativeSize();
			}
			if (this.scheduleTimeLabel != null)
			{
				string championshipScheduleTimeStr = ChampionshipUtility.GetChampionshipScheduleTimeStr();
				this.scheduleTimeLabel.text = championshipScheduleTimeStr;
			}
			if (this.scheduleContentLabel != null)
			{
				string finalStringByUpdateChangeLineFlag = CommonUtility.GetFinalStringByUpdateChangeLineFlag(this._scheduleTable.ScheduleDescription);
				this.scheduleContentLabel.text = finalStringByUpdateChangeLineFlag;
			}
			if (this.helpNewAssistant != null)
			{
				this.helpNewAssistant.HelpId = this._scheduleTable.CommonHelpId;
			}
			this.UpdateAvatarView();
		}

		// Token: 0x0600CF69 RID: 53097 RVA: 0x003330A3 File Offset: 0x003314A3
		public void InitBigRewardControl()
		{
			if (this.bigRewardControl != null)
			{
				this.bigRewardControl.InitControl();
			}
		}

		// Token: 0x0600CF6A RID: 53098 RVA: 0x003330C1 File Offset: 0x003314C1
		private void SetBigRewardScheduleId(int scheduleId)
		{
			if (this.bigRewardControl != null)
			{
				this.bigRewardControl.SetScheduleId(scheduleId);
			}
		}

		// Token: 0x0600CF6B RID: 53099 RVA: 0x003330E0 File Offset: 0x003314E0
		private void UpdateAvatarView()
		{
			if (this.avatarRoot == null)
			{
				return;
			}
			if (this._scheduleTable.ScheduleType != ChampionshipScheduleTable.eScheduleType.One_Select)
			{
				CommonUtility.UpdateGameObjectVisible(this.avatarRoot, false);
				return;
			}
			if (this.scheduleImageBg != null)
			{
				ETCImageLoader.LoadSprite(ref this.scheduleImageBg, "UI/Image/Background/UI_Beijing_Championship_Di.png:UI_Beijing_Championship_Di", true);
			}
			ChampionshipFightRaceDataModel finalFightRaceDataModel = ChampionshipUtility.GetFinalFightRaceDataModel();
			if (finalFightRaceDataModel == null)
			{
				DataManager<ChampionshipDataManager>.GetInstance().OnSendSceneChampionshipFightRaceData();
				return;
			}
			this.ShowAvatarView(finalFightRaceDataModel);
		}

		// Token: 0x0600CF6C RID: 53100 RVA: 0x00333160 File Offset: 0x00331560
		private void ShowAvatarView(ChampionshipFightRaceDataModel fightRaceDataModel)
		{
			if (fightRaceDataModel == null)
			{
				return;
			}
			if (this._avatarView != null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.avatarRoot, true);
			GameObject gameObject = CommonUtility.LoadGameObject(this.avatarRoot);
			if (gameObject == null)
			{
				return;
			}
			this._avatarView = gameObject.GetComponent<ChampionshipAvatarView>();
			if (this._avatarView != null)
			{
				ChampionshipTopPlayerDataModel topPlayerDataModelByPlayerGuid = ChampionshipUtility.GetTopPlayerDataModelByPlayerGuid(fightRaceDataModel.FirstPlayerGuid);
				ChampionshipTopPlayerDataModel leftPlayerDataModel = ChampionshipUtility.CreateTopPlayerDataModelByTopPlayerDataModel(topPlayerDataModelByPlayerGuid);
				ChampionshipTopPlayerDataModel topPlayerDataModelByPlayerGuid2 = ChampionshipUtility.GetTopPlayerDataModelByPlayerGuid(fightRaceDataModel.SecondPlayerGuid);
				ChampionshipTopPlayerDataModel rightPlayerDataModel = ChampionshipUtility.CreateTopPlayerDataModelByTopPlayerDataModel(topPlayerDataModelByPlayerGuid2);
				this._avatarView.Init(leftPlayerDataModel, rightPlayerDataModel);
			}
		}

		// Token: 0x0600CF6D RID: 53101 RVA: 0x00333200 File Offset: 0x00331600
		private void OnReceiveChampionshipFightRaceAllGroupMessage(UIEvent uiEvent)
		{
			if (this._scheduleTable.ScheduleType != ChampionshipScheduleTable.eScheduleType.One_Select)
			{
				return;
			}
			ChampionshipFightRaceDataModel finalFightRaceDataModel = ChampionshipUtility.GetFinalFightRaceDataModel();
			this.ShowAvatarView(finalFightRaceDataModel);
		}

		// Token: 0x0600CF6E RID: 53102 RVA: 0x0033322D File Offset: 0x0033162D
		public void ResetChampionshipAvatarView()
		{
			if (this._avatarView != null)
			{
				this._avatarView.ResetAvatarView();
			}
		}

		// Token: 0x0400794B RID: 31051
		private const string FinalScheduleBgPath = "UI/Image/Background/UI_Beijing_Championship_Di.png:UI_Beijing_Championship_Di";

		// Token: 0x0400794C RID: 31052
		private ChampionshipScheduleTable _scheduleTable;

		// Token: 0x0400794D RID: 31053
		private ChampionshipAvatarView _avatarView;

		// Token: 0x0400794E RID: 31054
		[Space(10f)]
		[Header("ScheduleBg")]
		[Space(10f)]
		[SerializeField]
		private Image scheduleImageBg;

		// Token: 0x0400794F RID: 31055
		[Space(10f)]
		[Header("Title")]
		[Space(10f)]
		[SerializeField]
		private Image scheduleIconImage;

		// Token: 0x04007950 RID: 31056
		[SerializeField]
		private Text scheduleTimeLabel;

		// Token: 0x04007951 RID: 31057
		[SerializeField]
		private Text scheduleContentLabel;

		// Token: 0x04007952 RID: 31058
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private CommonHelpNewAssistant helpNewAssistant;

		// Token: 0x04007953 RID: 31059
		[Space(10f)]
		[Header("Avatar")]
		[Space(10f)]
		[SerializeField]
		private GameObject avatarRoot;

		// Token: 0x04007954 RID: 31060
		[Space(10f)]
		[Header("BigRewardPreviewControl")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipBigRewardControl bigRewardControl;
	}
}
