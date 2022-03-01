using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C2C RID: 7212
	public class TeamDuplicationTeamBuildView : MonoBehaviour
	{
		// Token: 0x06011B10 RID: 72464 RVA: 0x0052ED50 File Offset: 0x0052D150
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011B11 RID: 72465 RVA: 0x0052ED58 File Offset: 0x0052D158
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011B12 RID: 72466 RVA: 0x0052ED68 File Offset: 0x0052D168
		private void ClearData()
		{
			this._isCanCreateGold = false;
			this._teamDifficultyControl = null;
			this._teamDifficultyLevel = 0U;
			this._challengeBaseEffectPrefabWithNormalLevel = null;
			this._goldBaseEffectPrefabWithNormalLevel = null;
			this._coverEffectPrefabWithNormalLevel = null;
			this._isIn65LevelTeamDuplication = false;
			this._goldBaseEffectPrefabWith65Level = null;
			this._challengeBaseEffectPrefabWith65Level = null;
			this._coverEffectPrefabWith65Level = null;
		}

		// Token: 0x06011B13 RID: 72467 RVA: 0x0052EDBC File Offset: 0x0052D1BC
		private void BindUiEvents()
		{
			if (this.goldModelButton != null)
			{
				this.goldModelButton.onClick.RemoveAllListeners();
				this.goldModelButton.onClick.AddListener(new UnityAction(this.OnGoldModelButtonClick));
			}
			if (this.challengeModelButton != null)
			{
				this.challengeModelButton.onClick.RemoveAllListeners();
				this.challengeModelButton.onClick.AddListener(new UnityAction(this.OnChallengeModelButtonClick));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
		}

		// Token: 0x06011B14 RID: 72468 RVA: 0x0052EE80 File Offset: 0x0052D280
		private void UnBindUiEvents()
		{
			if (this.goldModelButton != null)
			{
				this.goldModelButton.onClick.RemoveAllListeners();
			}
			if (this.challengeModelButton != null)
			{
				this.challengeModelButton.onClick.RemoveAllListeners();
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06011B15 RID: 72469 RVA: 0x0052EEF0 File Offset: 0x0052D2F0
		public void Init()
		{
			this.InitData();
			this.InitView();
		}

		// Token: 0x06011B16 RID: 72470 RVA: 0x0052EF00 File Offset: 0x0052D300
		private void InitData()
		{
			this._teamDifficultyLevel = 1U;
			TeamDuplicationPlayerInformationDataModel playerInformationDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetPlayerInformationDataModel();
			if (playerInformationDataModel != null)
			{
				this._isCanCreateGold = playerInformationDataModel.IsCanCreateGold;
			}
			this._isIn65LevelTeamDuplication = TeamDuplicationUtility.IsIn65LevelTeamDuplication();
		}

		// Token: 0x06011B17 RID: 72471 RVA: 0x0052EF3C File Offset: 0x0052D33C
		private void InitView()
		{
			this.InitTeamDifficultyControl();
			this.InitGoldModel();
			this.InitChallengeModel();
			this.InitCoverEffect();
		}

		// Token: 0x06011B18 RID: 72472 RVA: 0x0052EF56 File Offset: 0x0052D356
		private void InitCoverEffect()
		{
			if (!this._isIn65LevelTeamDuplication)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.coverEffectWith65LevelRoot, true);
			if (this._coverEffectPrefabWith65Level == null)
			{
				this._coverEffectPrefabWith65Level = CommonUtility.LoadGameObject(this.coverEffectWith65LevelRoot);
			}
		}

		// Token: 0x06011B19 RID: 72473 RVA: 0x0052EF94 File Offset: 0x0052D394
		private void InitTeamDifficultyControl()
		{
			if (this.teamDifficultyRoot == null)
			{
				return;
			}
			if (this._isIn65LevelTeamDuplication)
			{
				return;
			}
			this._teamDifficultyControl = this.LoadTeamDifficultyControl(this.teamDifficultyRoot);
			if (this._teamDifficultyControl != null)
			{
				this._teamDifficultyControl.Init(new OnTeamDifficultyClickedAction(this.OnTeamDifficultyClickedAction));
			}
		}

		// Token: 0x06011B1A RID: 72474 RVA: 0x0052EFF9 File Offset: 0x0052D3F9
		private void OnTeamDifficultyClickedAction(uint teamDifficultyLevel)
		{
			if (this._teamDifficultyLevel == teamDifficultyLevel)
			{
				return;
			}
			this._teamDifficultyLevel = teamDifficultyLevel;
			this.UpdateTeamBuildViewByDifficultyLevel();
		}

		// Token: 0x06011B1B RID: 72475 RVA: 0x0052F018 File Offset: 0x0052D418
		private void UpdateTeamBuildViewByDifficultyLevel()
		{
			if (this._teamDifficultyLevel == 1U)
			{
				CommonUtility.UpdateGameObjectVisible(this.coverEffectRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.challengeBaseEffectRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.goldBaseEffectRoot, false);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.coverEffectRoot, true);
				if (this._coverEffectPrefabWithNormalLevel == null)
				{
					this._coverEffectPrefabWithNormalLevel = CommonUtility.LoadGameObject(this.coverEffectRoot);
				}
				CommonUtility.UpdateGameObjectVisible(this.challengeBaseEffectRoot, true);
				if (this._challengeBaseEffectPrefabWithNormalLevel == null)
				{
					this._challengeBaseEffectPrefabWithNormalLevel = CommonUtility.LoadGameObject(this.challengeBaseEffectRoot);
				}
				if (!this._isCanCreateGold)
				{
					CommonUtility.UpdateGameObjectVisible(this.goldBaseEffectRoot, false);
				}
				else
				{
					CommonUtility.UpdateGameObjectVisible(this.goldBaseEffectRoot, true);
					if (this._goldBaseEffectPrefabWithNormalLevel == null)
					{
						this._goldBaseEffectPrefabWithNormalLevel = CommonUtility.LoadGameObject(this.goldBaseEffectRoot);
					}
				}
			}
		}

		// Token: 0x06011B1C RID: 72476 RVA: 0x0052F100 File Offset: 0x0052D500
		private void InitGoldModel()
		{
			if (this._isIn65LevelTeamDuplication)
			{
				if (this.goldImageIcon != null && !string.IsNullOrEmpty(this.goldImagePathWith65Level))
				{
					ETCImageLoader.LoadSprite(ref this.goldImageIcon, this.goldImagePathWith65Level, true);
					this.goldImageIcon.SetNativeSize();
				}
				if (this._isCanCreateGold)
				{
					CommonUtility.UpdateGameObjectVisible(this.goldBaseEffectWith65LevelRoot, true);
					if (this._goldBaseEffectPrefabWith65Level == null)
					{
						this._goldBaseEffectPrefabWith65Level = CommonUtility.LoadGameObject(this.goldBaseEffectWith65LevelRoot);
					}
				}
			}
			if (this._isCanCreateGold)
			{
				CommonUtility.UpdateGameObjectVisible(this.goldLockContentRoot, false);
				CommonUtility.UpdateUIGrayVisible(this.goldImageGray, false);
				CommonUtility.UpdateTextVisible(this.goldUnLockContentText, true);
				if (this.goldUnLockContentText != null)
				{
					string text = TR.Value("team_duplication_team_build_gold_unlock_content");
					if (this._isIn65LevelTeamDuplication)
					{
						text = TR.Value("team_duplication_team_build_gold_unlock_content_with_65_level");
					}
					this.goldUnLockContentText.text = text;
				}
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.goldLockContentRoot, true);
				CommonUtility.UpdateUIGrayVisible(this.goldImageGray, true);
				CommonUtility.UpdateTextVisible(this.goldUnLockContentText, false);
				if (this.goldLockContentText != null)
				{
					string originalStr = string.Empty;
					if (this._isIn65LevelTeamDuplication)
					{
						int passTimesWith65Level = DataManager<TeamDuplicationDataManager>.GetInstance().GetPassTimesWith65Level();
						int equipScoreWith65Level = DataManager<TeamDuplicationDataManager>.GetInstance().GetEquipScoreWith65Level();
						originalStr = TR.Value("team_duplication_team_build_gold_lock_content_with_65_level", passTimesWith65Level, equipScoreWith65Level);
					}
					else
					{
						int passTimesWithNormalLevel = DataManager<TeamDuplicationDataManager>.GetInstance().GetPassTimesWithNormalLevel();
						int equipScoreWithNormalLevel = DataManager<TeamDuplicationDataManager>.GetInstance().GetEquipScoreWithNormalLevel();
						originalStr = TR.Value("team_duplication_team_build_gold_lock_content", passTimesWithNormalLevel, equipScoreWithNormalLevel);
					}
					string finalStringByUpdateChangeLineFlag = CommonUtility.GetFinalStringByUpdateChangeLineFlag(originalStr);
					this.goldLockContentText.text = finalStringByUpdateChangeLineFlag;
				}
			}
		}

		// Token: 0x06011B1D RID: 72477 RVA: 0x0052F2C0 File Offset: 0x0052D6C0
		private void OnGoldModelButtonClick()
		{
			if (this._isCanCreateGold)
			{
				TeamDuplicationUtility.OnOpenTeamDuplicationTeamSettingFrame(new TeamDuplicationTeamBuildDataModel
				{
					TeamDifficultyLevel = this._teamDifficultyLevel,
					TeamModelType = 2
				});
			}
			else
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_team_build_gold_is_lock"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x06011B1E RID: 72478 RVA: 0x0052F310 File Offset: 0x0052D710
		private void InitChallengeModel()
		{
			if (this._isIn65LevelTeamDuplication)
			{
				if (this.challengeImageIcon != null && !string.IsNullOrEmpty(this.challengeImagePathWith65Level))
				{
					ETCImageLoader.LoadSprite(ref this.challengeImageIcon, this.challengeImagePathWith65Level, true);
					this.challengeImageIcon.SetNativeSize();
				}
				CommonUtility.UpdateGameObjectVisible(this.challengeBaseEffectWith65LevelRoot, true);
				if (this._challengeBaseEffectPrefabWith65Level == null)
				{
					this._challengeBaseEffectPrefabWith65Level = CommonUtility.LoadGameObject(this.challengeBaseEffectWith65LevelRoot);
				}
			}
			if (this.challengeContentText == null)
			{
				return;
			}
			string text = string.Empty;
			if (this._isIn65LevelTeamDuplication)
			{
				text = TR.Value("team_duplication_team_build_challenge_content_with_65_Level");
			}
			else
			{
				text = TR.Value("team_duplication_team_build_challenge_content");
			}
			this.challengeContentText.text = text;
		}

		// Token: 0x06011B1F RID: 72479 RVA: 0x0052F3E0 File Offset: 0x0052D7E0
		private void OnChallengeModelButtonClick()
		{
			TeamDuplicationUtility.OnOpenTeamDuplicationTeamSettingFrame(new TeamDuplicationTeamBuildDataModel
			{
				TeamDifficultyLevel = this._teamDifficultyLevel,
				TeamModelType = 1
			});
		}

		// Token: 0x06011B20 RID: 72480 RVA: 0x0052F40C File Offset: 0x0052D80C
		private void OnCloseButtonClick()
		{
			CommonUtility.UpdateButtonState(this.closeButton, null, false);
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamBuildFrame();
		}

		// Token: 0x06011B21 RID: 72481 RVA: 0x0052F420 File Offset: 0x0052D820
		private TeamDuplicationTeamDifficultyControl LoadTeamDifficultyControl(GameObject root)
		{
			if (root == null)
			{
				return null;
			}
			GameObject gameObject = CommonUtility.LoadGameObject(root);
			if (gameObject == null)
			{
				return null;
			}
			return gameObject.GetComponent<TeamDuplicationTeamDifficultyControl>();
		}

		// Token: 0x0400B85D RID: 47197
		private uint _teamDifficultyLevel;

		// Token: 0x0400B85E RID: 47198
		private bool _isCanCreateGold;

		// Token: 0x0400B85F RID: 47199
		private TeamDuplicationTeamDifficultyControl _teamDifficultyControl;

		// Token: 0x0400B860 RID: 47200
		private bool _isIn65LevelTeamDuplication;

		// Token: 0x0400B861 RID: 47201
		private GameObject _challengeBaseEffectPrefabWithNormalLevel;

		// Token: 0x0400B862 RID: 47202
		private GameObject _goldBaseEffectPrefabWithNormalLevel;

		// Token: 0x0400B863 RID: 47203
		private GameObject _coverEffectPrefabWithNormalLevel;

		// Token: 0x0400B864 RID: 47204
		private GameObject _challengeBaseEffectPrefabWith65Level;

		// Token: 0x0400B865 RID: 47205
		private GameObject _goldBaseEffectPrefabWith65Level;

		// Token: 0x0400B866 RID: 47206
		private GameObject _coverEffectPrefabWith65Level;

		// Token: 0x0400B867 RID: 47207
		[Space(25f)]
		[Header("GoldType")]
		[Space(20f)]
		[SerializeField]
		private Button goldModelButton;

		// Token: 0x0400B868 RID: 47208
		[SerializeField]
		private GameObject goldLockContentRoot;

		// Token: 0x0400B869 RID: 47209
		[SerializeField]
		private Text goldLockContentText;

		// Token: 0x0400B86A RID: 47210
		[SerializeField]
		private Text goldUnLockContentText;

		// Token: 0x0400B86B RID: 47211
		[SerializeField]
		private UIGray goldImageGray;

		// Token: 0x0400B86C RID: 47212
		[SerializeField]
		private Image goldImageIcon;

		// Token: 0x0400B86D RID: 47213
		[SerializeField]
		private string goldImagePathWith65Level;

		// Token: 0x0400B86E RID: 47214
		[Space(25f)]
		[Header("ChallengeType")]
		[Space(20f)]
		[SerializeField]
		private Button challengeModelButton;

		// Token: 0x0400B86F RID: 47215
		[SerializeField]
		private Text challengeContentText;

		// Token: 0x0400B870 RID: 47216
		[SerializeField]
		private Image challengeImageIcon;

		// Token: 0x0400B871 RID: 47217
		[SerializeField]
		private string challengeImagePathWith65Level;

		// Token: 0x0400B872 RID: 47218
		[Space(25f)]
		[Header("TeamDifficultyRoot")]
		[Space(20f)]
		[SerializeField]
		private GameObject teamDifficultyRoot;

		// Token: 0x0400B873 RID: 47219
		[Space(25f)]
		[Header("EffectRoot")]
		[Space(20f)]
		[SerializeField]
		private GameObject challengeBaseEffectRoot;

		// Token: 0x0400B874 RID: 47220
		[SerializeField]
		private GameObject goldBaseEffectRoot;

		// Token: 0x0400B875 RID: 47221
		[SerializeField]
		private GameObject coverEffectRoot;

		// Token: 0x0400B876 RID: 47222
		[Space(25f)]
		[Header("EffectRootWith65Level")]
		[Space(20f)]
		[SerializeField]
		private GameObject challengeBaseEffectWith65LevelRoot;

		// Token: 0x0400B877 RID: 47223
		[SerializeField]
		private GameObject goldBaseEffectWith65LevelRoot;

		// Token: 0x0400B878 RID: 47224
		[SerializeField]
		private GameObject coverEffectWith65LevelRoot;

		// Token: 0x0400B879 RID: 47225
		[Space(25f)]
		[Header("CloseButton")]
		[Space(20f)]
		[SerializeField]
		private Button closeButton;
	}
}
