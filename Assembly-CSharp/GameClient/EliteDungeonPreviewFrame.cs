using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001541 RID: 5441
	public class EliteDungeonPreviewFrame : ClientFrame
	{
		// Token: 0x0600D47C RID: 54396 RVA: 0x00350913 File Offset: 0x0034ED13
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chapter/Normal/EliteDungeonPreview";
		}

		// Token: 0x0600D47D RID: 54397 RVA: 0x0035091A File Offset: 0x0034ED1A
		protected override void _OnOpenFrame()
		{
			this.InitEvaluationItem();
			this.InitAwardItem();
			this.UpdateUI();
			this.BindUIEvent();
		}

		// Token: 0x0600D47E RID: 54398 RVA: 0x00350934 File Offset: 0x0034ED34
		protected override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
		}

		// Token: 0x0600D47F RID: 54399 RVA: 0x0035093C File Offset: 0x0034ED3C
		protected override void _bindExUI()
		{
			this.mAwardItems = this.mBind.GetCom<ComUIListScript>("awardItems");
			this.mEvaluationItems = this.mBind.GetCom<ComUIListScript>("evaluationItems");
			this.mUnlockProcess = this.mBind.GetCom<Slider>("unlockProcess");
			this.mUnlockValue = this.mBind.GetCom<Text>("unlockValue");
			this.mChapterSelectUnit = this.mBind.GetCom<ComChapterDungeonUnit>("ChapterSelectUnit");
		}

		// Token: 0x0600D480 RID: 54400 RVA: 0x003509B7 File Offset: 0x0034EDB7
		protected override void _unbindExUI()
		{
			this.mAwardItems = null;
			this.mEvaluationItems = null;
			this.mUnlockProcess = null;
			this.mUnlockValue = null;
			this.mChapterSelectUnit = null;
		}

		// Token: 0x0600D481 RID: 54401 RVA: 0x003509DC File Offset: 0x0034EDDC
		private void BindUIEvent()
		{
		}

		// Token: 0x0600D482 RID: 54402 RVA: 0x003509DE File Offset: 0x0034EDDE
		private void UnBindUIEvent()
		{
		}

		// Token: 0x0600D483 RID: 54403 RVA: 0x003509E0 File Offset: 0x0034EDE0
		private void UpdateUI()
		{
			this.UpdateEvaluationItem();
			this.UpdateAwardItem();
			List<int> currentChapterNormalDungeonIDs = EliteDungeonPreviewFrame.GetCurrentChapterNormalDungeonIDs();
			int num = 0;
			if (currentChapterNormalDungeonIDs != null && currentChapterNormalDungeonIDs.Count > 0)
			{
				num = currentChapterNormalDungeonIDs.Count;
			}
			this.mUnlockValue.SafeSetText(string.Format("{0}/{1}", EliteDungeonPreviewFrame.GetSSSDungeonNum(), num));
			float value = 1f;
			if (num > 0)
			{
				value = (float)EliteDungeonPreviewFrame.GetSSSDungeonNum() / (float)num;
			}
			this.mUnlockProcess.SafeSetValue(value);
			if (this.mChapterSelectUnit != null)
			{
				List<int> list = null;
				ChapterSelectFrame chapterSelectFrame = Singleton<ClientSystemManager>.instance.GetFrame(typeof(ChapterSelectFrame)) as ChapterSelectFrame;
				if (chapterSelectFrame != null)
				{
					list = chapterSelectFrame.GetCurrentChapterDungeonIDs();
				}
				if (list != null)
				{
					int id2 = list.Find((int id) => TeamUtility.IsEliteDungeonID(id));
					DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(id2, string.Empty, string.Empty);
					if (tableItem != null)
					{
						this.mChapterSelectUnit.SetName(tableItem.Name, tableItem.RecommendLevel);
						this.mChapterSelectUnit.SetType(ComChapterDungeonUnit.eMissionType.None);
						this.mChapterSelectUnit.SetBackgroud(tableItem.TumbPath);
						this.mChapterSelectUnit.SetCharactorSprite(tableItem.TumbChPath);
						this.mChapterSelectUnit.ShowEliteBg(true);
					}
				}
			}
		}

		// Token: 0x0600D484 RID: 54404 RVA: 0x00350B40 File Offset: 0x0034EF40
		public static DungeonScore GetBestScore(int dungeonID)
		{
			DungeonScore dungeonScore = DungeonScore.C;
			DungeonID dungeonID2 = new DungeonID(dungeonID);
			if (dungeonID2 == null)
			{
				return dungeonScore;
			}
			DungeonID dungeonID3 = new DungeonID(dungeonID2.dungeonID);
			if (dungeonID3 == null)
			{
				return dungeonScore;
			}
			int dungeonTopHard = ChapterUtility.GetDungeonTopHard(dungeonID2.dungeonIDWithOutDiff);
			for (int i = 0; i <= dungeonTopHard; i++)
			{
				dungeonID3.diffID = i;
				if (ChapterUtility.GetDungeonBestScore(dungeonID3.dungeonID) >= dungeonScore)
				{
					dungeonScore = ChapterUtility.GetDungeonBestScore(dungeonID3.dungeonID);
				}
			}
			return dungeonScore;
		}

		// Token: 0x0600D485 RID: 54405 RVA: 0x00350BBA File Offset: 0x0034EFBA
		public static bool HasSSS(int dungeonID)
		{
			return EliteDungeonPreviewFrame.GetBestScore(dungeonID) == DungeonScore.SSS;
		}

		// Token: 0x0600D486 RID: 54406 RVA: 0x00350BC8 File Offset: 0x0034EFC8
		public static int GetSSSDungeonNum()
		{
			List<int> currentChapterNormalDungeonIDs = EliteDungeonPreviewFrame.GetCurrentChapterNormalDungeonIDs();
			int num = 0;
			if (currentChapterNormalDungeonIDs != null)
			{
				for (int i = 0; i < currentChapterNormalDungeonIDs.Count; i++)
				{
					if (EliteDungeonPreviewFrame.HasSSS(currentChapterNormalDungeonIDs[i]))
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x0600D487 RID: 54407 RVA: 0x00350C10 File Offset: 0x0034F010
		public static List<int> GetCurrentChapterNormalDungeonIDs()
		{
			List<int> list = new List<int>();
			ChapterSelectFrame chapterSelectFrame = Singleton<ClientSystemManager>.instance.GetFrame(typeof(ChapterSelectFrame)) as ChapterSelectFrame;
			if (chapterSelectFrame != null)
			{
				list = chapterSelectFrame.GetCurrentChapterDungeonIDs();
			}
			if (list != null)
			{
				list.RemoveAll((int id) => TeamUtility.IsEliteDungeonID(id));
			}
			return list;
		}

		// Token: 0x0600D488 RID: 54408 RVA: 0x00350C78 File Offset: 0x0034F078
		private void InitEvaluationItem()
		{
			if (this.mEvaluationItems == null)
			{
				return;
			}
			this.mEvaluationItems.Initialize();
			this.mEvaluationItems.onBindItem = delegate(GameObject go)
			{
				EliteDungeonPreviewEvaluationItem result = null;
				if (go)
				{
					result = go.GetComponent<EliteDungeonPreviewEvaluationItem>();
				}
				return result;
			};
			this.mEvaluationItems.onItemVisiable = delegate(ComUIListElementScript var1)
			{
				if (var1 == null)
				{
					return;
				}
				EliteDungeonPreviewEvaluationItem eliteDungeonPreviewEvaluationItem = var1.gameObjectBindScript as EliteDungeonPreviewEvaluationItem;
				if (eliteDungeonPreviewEvaluationItem != null && this.evaluationItemDatas != null && var1.m_index < this.evaluationItemDatas.Count)
				{
					eliteDungeonPreviewEvaluationItem.SetUp(this.evaluationItemDatas[var1.m_index], var1.m_index);
				}
			};
		}

		// Token: 0x0600D489 RID: 54409 RVA: 0x00350CE4 File Offset: 0x0034F0E4
		public static ComChapterDungeonUnit.eState GetDungeonState(int dungeonID)
		{
			DungeonID dungeonID2 = new DungeonID(0);
			if (dungeonID2 == null)
			{
				return ComChapterDungeonUnit.eState.Locked;
			}
			dungeonID2.dungeonID = ChapterUtility.GetReadyDungeonID(dungeonID, 0);
			ComChapterDungeonUnit.eState dungeonState = ChapterUtility.GetDungeonState(dungeonID2.dungeonID);
			if (dungeonState == ComChapterDungeonUnit.eState.Unlock)
			{
				DungeonScore bestScore = EliteDungeonPreviewFrame.GetBestScore(dungeonID);
				if (bestScore >= DungeonScore.B)
				{
					return ComChapterDungeonUnit.eState.Passed;
				}
			}
			return dungeonState;
		}

		// Token: 0x0600D48A RID: 54410 RVA: 0x00350D34 File Offset: 0x0034F134
		private void CalEvaluationItemDatas()
		{
			this.evaluationItemDatas = new List<int>();
			if (this.evaluationItemDatas == null)
			{
				return;
			}
			this.evaluationItemDatas = EliteDungeonPreviewFrame.GetCurrentChapterNormalDungeonIDs();
			this.evaluationItemDatas.Sort((int a, int b) => a.CompareTo(b));
			Predicate<int> match = delegate(int id)
			{
				DungeonScore bestScore = EliteDungeonPreviewFrame.GetBestScore(id);
				return bestScore == DungeonScore.SSS;
			};
			List<int> collection = this.evaluationItemDatas.FindAll(match);
			this.evaluationItemDatas.RemoveAll(match);
			this.evaluationItemDatas.AddRange(collection);
		}

		// Token: 0x0600D48B RID: 54411 RVA: 0x00350DCF File Offset: 0x0034F1CF
		private void UpdateEvaluationItem()
		{
			if (this.mEvaluationItems == null)
			{
				return;
			}
			this.CalEvaluationItemDatas();
			if (this.evaluationItemDatas != null)
			{
				this.mEvaluationItems.SetElementAmount(this.evaluationItemDatas.Count);
			}
		}

		// Token: 0x0600D48C RID: 54412 RVA: 0x00350E0C File Offset: 0x0034F20C
		private void InitAwardItem()
		{
			if (this.mAwardItems == null)
			{
				return;
			}
			this.mAwardItems.Initialize();
			this.mAwardItems.onBindItem = delegate(GameObject go)
			{
				EliteDungeonPreviewAwardItem result = null;
				if (go)
				{
					result = go.GetComponent<EliteDungeonPreviewAwardItem>();
				}
				return result;
			};
			this.mAwardItems.onItemVisiable = delegate(ComUIListElementScript var1)
			{
				if (var1 == null)
				{
					return;
				}
				EliteDungeonPreviewAwardItem eliteDungeonPreviewAwardItem = var1.gameObjectBindScript as EliteDungeonPreviewAwardItem;
				if (eliteDungeonPreviewAwardItem != null && this.awardItemDatas != null && var1.m_index < this.awardItemDatas.Count)
				{
					eliteDungeonPreviewAwardItem.SetUp(this.awardItemDatas[var1.m_index]);
				}
			};
		}

		// Token: 0x0600D48D RID: 54413 RVA: 0x00350E78 File Offset: 0x0034F278
		private void CalAwardItemDatas()
		{
			this.awardItemDatas = new List<int>();
			if (this.awardItemDatas == null)
			{
				return;
			}
			List<int> list = null;
			ChapterSelectFrame chapterSelectFrame = Singleton<ClientSystemManager>.instance.GetFrame(typeof(ChapterSelectFrame)) as ChapterSelectFrame;
			if (chapterSelectFrame != null)
			{
				list = chapterSelectFrame.GetCurrentChapterDungeonIDs();
			}
			if (list != null)
			{
				int id2 = list.Find((int id) => TeamUtility.IsEliteDungeonID(id));
				DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(id2, string.Empty, string.Empty);
				if (tableItem != null)
				{
					this.awardItemDatas.AddRange(tableItem.DropItems);
				}
			}
		}

		// Token: 0x0600D48E RID: 54414 RVA: 0x00350F1C File Offset: 0x0034F31C
		private void UpdateAwardItem()
		{
			if (this.mAwardItems == null)
			{
				return;
			}
			this.CalAwardItemDatas();
			if (this.awardItemDatas != null)
			{
				this.mAwardItems.SetElementAmount(this.awardItemDatas.Count);
			}
		}

		// Token: 0x04007CA3 RID: 31907
		private List<int> evaluationItemDatas;

		// Token: 0x04007CA4 RID: 31908
		private List<int> awardItemDatas;

		// Token: 0x04007CA5 RID: 31909
		private ComUIListScript mAwardItems;

		// Token: 0x04007CA6 RID: 31910
		private ComUIListScript mEvaluationItems;

		// Token: 0x04007CA7 RID: 31911
		private Slider mUnlockProcess;

		// Token: 0x04007CA8 RID: 31912
		private Text mUnlockValue;

		// Token: 0x04007CA9 RID: 31913
		private ComChapterDungeonUnit mChapterSelectUnit;
	}
}
