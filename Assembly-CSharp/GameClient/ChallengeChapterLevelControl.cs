using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014BA RID: 5306
	public class ChallengeChapterLevelControl : MonoBehaviour
	{
		// Token: 0x0600CDBA RID: 52666 RVA: 0x0032AA00 File Offset: 0x00328E00
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CDBB RID: 52667 RVA: 0x0032AA08 File Offset: 0x00328E08
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CDBC RID: 52668 RVA: 0x0032AA18 File Offset: 0x00328E18
		private void BindEvents()
		{
			if (this.levelItemList != null)
			{
				this.levelItemList.Initialize();
				ComUIListScript comUIListScript = this.levelItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnLevelItemVisible));
				ComUIListScript comUIListScript2 = this.levelItemList;
				comUIListScript2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScript2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnLevelItemUpdate));
			}
		}

		// Token: 0x0600CDBD RID: 52669 RVA: 0x0032AA90 File Offset: 0x00328E90
		private void UnBindEvents()
		{
			if (this.levelItemList != null)
			{
				ComUIListScript comUIListScript = this.levelItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnLevelItemVisible));
				ComUIListScript comUIListScript2 = this.levelItemList;
				comUIListScript2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScript2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnLevelItemUpdate));
			}
		}

		// Token: 0x0600CDBE RID: 52670 RVA: 0x0032AAFC File Offset: 0x00328EFC
		private void ClearData()
		{
			this._levelDataModelList = null;
			this._levelItemList = null;
			this._onLevelButtonClick = null;
		}

		// Token: 0x0600CDBF RID: 52671 RVA: 0x0032AB14 File Offset: 0x00328F14
		public void InitLevelControl(List<ChallengeChapterLevelDataModel> levelDataModelList, OnChapterLevelButtonClick onLevelButtonClick)
		{
			this._levelDataModelList = levelDataModelList;
			this._onLevelButtonClick = onLevelButtonClick;
			if (this._levelDataModelList == null || this._levelDataModelList.Count <= 0)
			{
				Logger.LogErrorFormat("LevelDataModel is null or count is zero ", new object[0]);
				return;
			}
			if (this.levelItemList != null)
			{
				this.levelItemList.SetElementAmount(this._levelDataModelList.Count);
			}
			int levelId = 0;
			int dungeonId = 0;
			for (int i = 0; i < this._levelDataModelList.Count; i++)
			{
				if (this._levelDataModelList[i] != null && this._levelDataModelList[i].IsSelected)
				{
					levelId = i;
					dungeonId = this._levelDataModelList[i].DungeonId;
					break;
				}
			}
			this.UpdateExpAndDropAdd(levelId, dungeonId);
		}

		// Token: 0x0600CDC0 RID: 52672 RVA: 0x0032ABEC File Offset: 0x00328FEC
		private void OnLevelItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._levelDataModelList == null)
			{
				return;
			}
			if (this.levelItemList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._levelDataModelList.Count)
			{
				return;
			}
			ChallengeChapterLevelDataModel challengeChapterLevelDataModel = this._levelDataModelList[item.m_index];
			ChallengeChapterLevelItem component = item.GetComponent<ChallengeChapterLevelItem>();
			if (component != null && challengeChapterLevelDataModel != null)
			{
				component.InitItem(challengeChapterLevelDataModel, new OnChapterLevelButtonClick(this.OnChapterLevelButtonClick));
			}
		}

		// Token: 0x0600CDC1 RID: 52673 RVA: 0x0032AC88 File Offset: 0x00329088
		private void OnLevelItemUpdate(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ChallengeChapterLevelItem component = item.GetComponent<ChallengeChapterLevelItem>();
			if (component != null)
			{
				component.OnUpdateLevelItemSelected();
			}
		}

		// Token: 0x0600CDC2 RID: 52674 RVA: 0x0032ACBB File Offset: 0x003290BB
		private void OnChapterLevelButtonClick(int levelId, int dungeonId)
		{
			this.UpdateExpAndDropAdd(levelId, dungeonId);
			this.UpdateLevelItemList(dungeonId);
			if (this._onLevelButtonClick != null)
			{
				this._onLevelButtonClick(levelId, dungeonId);
			}
		}

		// Token: 0x0600CDC3 RID: 52675 RVA: 0x0032ACE4 File Offset: 0x003290E4
		private void UpdateExpAndDropAdd(int levelId, int dungeonId)
		{
			if (DungeonUtility.IsLimitTimeHellDungeon(dungeonId) || DungeonUtility.IsWeekHellEntryDungeon(dungeonId) || DungeonUtility.IsWeekHellPreDungeon(dungeonId))
			{
				int onlyKingHardLevelDropRate = ChallengeUtility.GetOnlyKingHardLevelDropRate();
				if (this.addText != null)
				{
					string text = string.Format(TR.Value("challenge_chapter_level_only_drop_add"), onlyKingHardLevelDropRate);
					this.addText.text = text;
				}
				return;
			}
			int expRate = ChallengeUtility.GetExpRate(levelId);
			int dropRate = ChallengeUtility.GetDropRate(levelId);
			if (this.addText != null)
			{
				string text2 = string.Format(TR.Value("challenge_chapter_level_add"), expRate, dropRate);
				this.addText.text = text2;
			}
		}

		// Token: 0x0600CDC4 RID: 52676 RVA: 0x0032AD98 File Offset: 0x00329198
		private void UpdateLevelItemList(int selectedDungeonId)
		{
			for (int i = 0; i < this._levelDataModelList.Count; i++)
			{
				ChallengeChapterLevelDataModel challengeChapterLevelDataModel = this._levelDataModelList[i];
				if (challengeChapterLevelDataModel != null && challengeChapterLevelDataModel.DungeonId != selectedDungeonId)
				{
					challengeChapterLevelDataModel.IsSelected = false;
				}
			}
			if (this.levelItemList != null)
			{
				this.levelItemList.UpdateElement();
			}
		}

		// Token: 0x04007811 RID: 30737
		private List<ChallengeChapterLevelDataModel> _levelDataModelList;

		// Token: 0x04007812 RID: 30738
		private OnChapterLevelButtonClick _onLevelButtonClick;

		// Token: 0x04007813 RID: 30739
		private List<ChallengeChapterLevelItem> _levelItemList;

		// Token: 0x04007814 RID: 30740
		[SerializeField]
		private Text addText;

		// Token: 0x04007815 RID: 30741
		[SerializeField]
		private ComUIListScript levelItemList;
	}
}
