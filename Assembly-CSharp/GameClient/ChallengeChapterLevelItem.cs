using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014BB RID: 5307
	public class ChallengeChapterLevelItem : MonoBehaviour
	{
		// Token: 0x0600CDC6 RID: 52678 RVA: 0x0032AE0B File Offset: 0x0032920B
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CDC7 RID: 52679 RVA: 0x0032AE13 File Offset: 0x00329213
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CDC8 RID: 52680 RVA: 0x0032AE21 File Offset: 0x00329221
		private void BindEvents()
		{
			if (this.levelButton != null)
			{
				this.levelButton.onClick.RemoveAllListeners();
				this.levelButton.onClick.AddListener(new UnityAction(this.OnLevelButtonClick));
			}
		}

		// Token: 0x0600CDC9 RID: 52681 RVA: 0x0032AE60 File Offset: 0x00329260
		private void UnBindEvents()
		{
			if (this.levelButton != null)
			{
				this.levelButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CDCA RID: 52682 RVA: 0x0032AE83 File Offset: 0x00329283
		private void ClearData()
		{
			this._levelDataModel = null;
			this._onChapterLevelButtonClick = null;
			this._dungeonTable = null;
		}

		// Token: 0x0600CDCB RID: 52683 RVA: 0x0032AE9C File Offset: 0x0032929C
		public void InitItem(ChallengeChapterLevelDataModel levelDataModel, OnChapterLevelButtonClick onLevelButtonClick)
		{
			this._levelDataModel = levelDataModel;
			this._onChapterLevelButtonClick = onLevelButtonClick;
			if (this._levelDataModel == null || this._levelDataModel.DungeonId <= 0)
			{
				Logger.LogErrorFormat("DungeonLevelDataModel is null or DungeonId is zero", new object[0]);
				return;
			}
			this._levelId = this._levelDataModel.Index;
			this._dungeonId = this._levelDataModel.DungeonId;
			this._dungeonTable = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(this._levelDataModel.DungeonId, string.Empty, string.Empty);
			if (this._dungeonTable == null)
			{
				Logger.LogErrorFormat("DungeonTable is null and chapterId is {0}", new object[]
				{
					this._levelDataModel.DungeonId
				});
				return;
			}
			this.InitContent();
		}

		// Token: 0x0600CDCC RID: 52684 RVA: 0x0032AF60 File Offset: 0x00329360
		private void InitContent()
		{
			if (this.levelNameText != null)
			{
				if (DungeonUtility.IsLimitTimeHellDungeon(this._dungeonId) || DungeonUtility.IsWeekHellEntryDungeon(this._dungeonId) || DungeonUtility.IsWeekHellPreDungeon(this._dungeonId))
				{
					this.levelNameText.text = ChallengeUtility.GetLevelName(3);
				}
				else
				{
					this.levelNameText.text = ChallengeUtility.GetLevelName(this._levelId);
				}
			}
			if (this.recommendLevel != null)
			{
				this.recommendLevel.text = this._dungeonTable.RecommendLevel;
			}
			this.OnUpdateLevelItemSelected();
			this.InitLevelItemUnLock();
		}

		// Token: 0x0600CDCD RID: 52685 RVA: 0x0032B010 File Offset: 0x00329410
		private void InitLevelItemUnLock()
		{
			this.ResetLevelItemStateFlag();
			ComChapterDungeonUnit.eState dungeonState = ChapterUtility.GetDungeonState(this._dungeonId);
			eChapterNodeState eChapterNodeState = eChapterNodeState.Unlock;
			switch (dungeonState)
			{
			case ComChapterDungeonUnit.eState.Locked:
				eChapterNodeState = eChapterNodeState.Lock;
				break;
			case ComChapterDungeonUnit.eState.Unlock:
				if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= this._dungeonTable.MinLevel)
				{
					eChapterNodeState = eChapterNodeState.Unlock;
				}
				else
				{
					eChapterNodeState = eChapterNodeState.LockLevel;
				}
				break;
			case ComChapterDungeonUnit.eState.Passed:
			case ComChapterDungeonUnit.eState.LockPassed:
				eChapterNodeState = eChapterNodeState.Passed;
				break;
			}
			switch (eChapterNodeState)
			{
			case eChapterNodeState.Lock:
				if (DungeonUtility.IsLimitTimeHellDungeon(this._dungeonId) || DungeonUtility.IsWeekHellEntryDungeon(this._dungeonId) || DungeonUtility.IsWeekHellPreDungeon(this._dungeonId))
				{
					if (this.beforeLevelLockRoot != null)
					{
						this.beforeLevelLockRoot.gameObject.CustomActive(true);
					}
					if (this.beforeLevelText != null)
					{
						this.beforeLevelText.text = string.Format(TR.Value("challenge_chapter_special_hell_unlock"), new object[0]);
					}
				}
				else
				{
					if (this.beforeLevelLockRoot != null)
					{
						this.beforeLevelLockRoot.gameObject.CustomActive(true);
					}
					if (this.beforeLevelText != null)
					{
						string preLevelName = ChallengeUtility.GetPreLevelName(this._levelId);
						this.beforeLevelText.text = string.Format(TR.Value("challenge_chapter_pre_level_unLock"), preLevelName);
					}
				}
				break;
			case eChapterNodeState.LockLevel:
				if (this.playerLevelLockRoot != null)
				{
					this.playerLevelLockRoot.gameObject.CustomActive(true);
				}
				if (this.playerLevelText != null)
				{
					string arg = this._dungeonTable.MinLevel.ToString();
					this.playerLevelText.text = string.Format(TR.Value("challenge_chapter_player_level_unLock"), arg);
				}
				break;
			case eChapterNodeState.Unlock:
				if (this.unPassedRoot != null)
				{
					this.unPassedRoot.gameObject.CustomActive(true);
				}
				break;
			case eChapterNodeState.Passed:
				if (this.scoreRoot != null)
				{
					this.scoreRoot.gameObject.CustomActive(true);
				}
				this.UpdateLevelItemScore();
				break;
			}
		}

		// Token: 0x0600CDCE RID: 52686 RVA: 0x0032B248 File Offset: 0x00329648
		private void UpdateLevelItemScore()
		{
			switch (ChapterUtility.GetDungeonBestScore(this._dungeonId))
			{
			case DungeonScore.C:
			case DungeonScore.B:
			case DungeonScore.A:
				this.SetImageVisible(this.AImage, true);
				break;
			case DungeonScore.S:
				this.SetImageVisible(this.secondSImage, true);
				break;
			case DungeonScore.SS:
				this.SetImageVisible(this.secondSImage, true);
				this.SetImageVisible(this.thirdSImage, true);
				break;
			case DungeonScore.SSS:
				this.SetImageVisible(this.firstSImage, true);
				this.SetImageVisible(this.secondSImage, true);
				this.SetImageVisible(this.thirdSImage, true);
				break;
			}
		}

		// Token: 0x0600CDCF RID: 52687 RVA: 0x0032B2F3 File Offset: 0x003296F3
		public void OnUpdateLevelItemSelected()
		{
			if (this._levelDataModel != null && this.itemSelectedFlag != null)
			{
				this.itemSelectedFlag.gameObject.CustomActive(this._levelDataModel.IsSelected);
			}
		}

		// Token: 0x0600CDD0 RID: 52688 RVA: 0x0032B32C File Offset: 0x0032972C
		private void OnLevelButtonClick()
		{
			if (this._levelDataModel != null)
			{
				if (this._levelDataModel.IsSelected)
				{
					return;
				}
				this._levelDataModel.IsSelected = true;
				this._onChapterLevelButtonClick(this._levelDataModel.Index, this._levelDataModel.DungeonId);
			}
		}

		// Token: 0x0600CDD1 RID: 52689 RVA: 0x0032B382 File Offset: 0x00329782
		private void SetImageVisible(Image sImage, bool flag)
		{
			if (sImage != null)
			{
				sImage.gameObject.CustomActive(flag);
			}
		}

		// Token: 0x0600CDD2 RID: 52690 RVA: 0x0032B39C File Offset: 0x0032979C
		private void ResetLevelItemStateFlag()
		{
			if (this.beforeLevelLockRoot != null)
			{
				this.beforeLevelLockRoot.gameObject.CustomActive(false);
			}
			if (this.playerLevelLockRoot != null)
			{
				this.playerLevelLockRoot.gameObject.CustomActive(false);
			}
			if (this.unPassedRoot != null)
			{
				this.unPassedRoot.gameObject.CustomActive(false);
			}
			if (this.scoreRoot != null)
			{
				this.scoreRoot.gameObject.CustomActive(false);
			}
			if (this.AImage != null)
			{
				this.AImage.gameObject.CustomActive(false);
			}
			if (this.firstSImage != null)
			{
				this.firstSImage.gameObject.CustomActive(false);
			}
			if (this.secondSImage != null)
			{
				this.secondSImage.gameObject.CustomActive(false);
			}
			if (this.thirdSImage != null)
			{
				this.thirdSImage.gameObject.CustomActive(false);
			}
		}

		// Token: 0x04007816 RID: 30742
		private int _levelId;

		// Token: 0x04007817 RID: 30743
		private int _dungeonId;

		// Token: 0x04007818 RID: 30744
		private ChallengeChapterLevelDataModel _levelDataModel;

		// Token: 0x04007819 RID: 30745
		private OnChapterLevelButtonClick _onChapterLevelButtonClick;

		// Token: 0x0400781A RID: 30746
		private DungeonTable _dungeonTable;

		// Token: 0x0400781B RID: 30747
		[Space(10f)]
		[Header("Item")]
		[SerializeField]
		private Text levelNameText;

		// Token: 0x0400781C RID: 30748
		[SerializeField]
		private Text recommendLevel;

		// Token: 0x0400781D RID: 30749
		[SerializeField]
		private Button levelButton;

		// Token: 0x0400781E RID: 30750
		[SerializeField]
		private Image itemSelectedFlag;

		// Token: 0x0400781F RID: 30751
		[Space(10f)]
		[Header("unPass")]
		[Space(10f)]
		[SerializeField]
		private GameObject beforeLevelLockRoot;

		// Token: 0x04007820 RID: 30752
		[SerializeField]
		private Text beforeLevelText;

		// Token: 0x04007821 RID: 30753
		[SerializeField]
		private GameObject playerLevelLockRoot;

		// Token: 0x04007822 RID: 30754
		[SerializeField]
		private Text playerLevelText;

		// Token: 0x04007823 RID: 30755
		[SerializeField]
		private GameObject unPassedRoot;

		// Token: 0x04007824 RID: 30756
		[Space(10f)]
		[Header("Score")]
		[Space(10f)]
		[SerializeField]
		private GameObject scoreRoot;

		// Token: 0x04007825 RID: 30757
		[SerializeField]
		private Image AImage;

		// Token: 0x04007826 RID: 30758
		[SerializeField]
		private Image firstSImage;

		// Token: 0x04007827 RID: 30759
		[SerializeField]
		private Image secondSImage;

		// Token: 0x04007828 RID: 30760
		[SerializeField]
		private Image thirdSImage;
	}
}
