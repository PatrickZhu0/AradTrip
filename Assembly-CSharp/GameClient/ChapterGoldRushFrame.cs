using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200152D RID: 5421
	public class ChapterGoldRushFrame : ChapterBaseFrame
	{
		// Token: 0x0600D31D RID: 54045 RVA: 0x003449F1 File Offset: 0x00342DF1
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Activity/Dungeon/ChapterGoldRush";
		}

		// Token: 0x0600D31E RID: 54046 RVA: 0x003449F8 File Offset: 0x00342DF8
		protected sealed override void _bindExUI()
		{
			this.mChapterInfo = this.mBind.GetCom<ComCommonChapterInfo>("chapterInfo");
			this.mStart = this.mBind.GetCom<Button>("start");
			this.mStart.onClick.AddListener(new UnityAction(this._onStartButtonClick));
			this.mLeftCount = this.mBind.GetCom<Text>("leftCount");
			this.mCurrentDiffDesc = this.mBind.GetCom<Text>("currentDiffDesc");
			this.mCurrentDropDesc = this.mBind.GetCom<Text>("currentDropDesc");
			this.mName = this.mBind.GetCom<Text>("name");
			this.mGroupStartGray = this.mBind.GetCom<UIGray>("GroupStartGray");
		}

		// Token: 0x0600D31F RID: 54047 RVA: 0x00344ABC File Offset: 0x00342EBC
		protected sealed override void _unbindExUI()
		{
			this.mChapterInfo = null;
			this.mStart.onClick.RemoveListener(new UnityAction(this._onStartButtonClick));
			this.mStart = null;
			this.mLeftCount = null;
			this.mCurrentDiffDesc = null;
			this.mCurrentDropDesc = null;
			this.mName = null;
			this.mGroupStartGray = null;
		}

		// Token: 0x0600D320 RID: 54048 RVA: 0x00344B16 File Offset: 0x00342F16
		private void _onStartButtonClick()
		{
			this._onStartButton();
		}

		// Token: 0x0600D321 RID: 54049 RVA: 0x00344B20 File Offset: 0x00342F20
		protected sealed override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mDungeonTable != null)
			{
				this.mName.text = this.mDungeonTable.Name;
				int num = this.mDungeonTable.DailyMaxTime - DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.DUNGEON_DAILY_COUNT_PREFIX, (int)this.mDungeonTable.SubType);
				this.mLeftCount.text = num.ToString();
			}
		}

		// Token: 0x0600D322 RID: 54050 RVA: 0x00344B94 File Offset: 0x00342F94
		protected sealed override void _loadLeftPanel()
		{
			if (null != this.mChapterInfo)
			{
				this.mChapterInfoCommon = this.mChapterInfo;
				this.mChapterInfoDiffculte = this.mChapterInfo;
				this.mChapterInfoDrops = this.mChapterInfo;
				this.mChapterPassReward = this.mChapterInfo;
				this.mChapterScore = this.mChapterInfo;
				this.mChapterMonsterInfo = this.mChapterInfo;
				this.mChapterActivityTimes = this.mChapterInfo;
				this.mChapterNodeState = this.mChapterInfo;
			}
			this.mChapterInfoDiffculte.SetDiffculte(this.mChapterInfoDiffculte.GetDiffculte(), this.mDungeonID.dungeonID);
			List<eChapterNodeState> list = new List<eChapterNodeState>();
			List<int> list2 = new List<int>();
			int dungeonTopHard = ChapterUtility.GetDungeonTopHard(this.mDungeonID.dungeonIDWithOutDiff);
			DungeonID dungeonID = new DungeonID(this.mDungeonID.dungeonID);
			for (int i = 0; i <= dungeonTopHard; i++)
			{
				dungeonID.diffID = i;
				DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(dungeonID.dungeonID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					list2.Add(tableItem.MinLevel);
				}
				else
				{
					list2.Add(0);
				}
				switch (ChapterUtility.GetDungeonState(dungeonID.dungeonID))
				{
				case ComChapterDungeonUnit.eState.Locked:
					if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= list2[i])
					{
						list.Add(eChapterNodeState.Lock);
					}
					else
					{
						list.Add(eChapterNodeState.LockLevel);
					}
					break;
				case ComChapterDungeonUnit.eState.Unlock:
					if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= list2[i])
					{
						list.Add(eChapterNodeState.Unlock);
					}
					else
					{
						list.Add(eChapterNodeState.LockLevel);
					}
					break;
				case ComChapterDungeonUnit.eState.Passed:
				case ComChapterDungeonUnit.eState.LockPassed:
					list.Add(eChapterNodeState.Passed);
					break;
				}
			}
			for (int j = dungeonTopHard + 1; j < 4; j++)
			{
				list.Add(eChapterNodeState.Miss);
			}
			if (this.mChapterNodeState != null)
			{
				this.mChapterNodeState.SetChapterState(list.ToArray(), list2.ToArray());
			}
		}

		// Token: 0x0600D323 RID: 54051 RVA: 0x00344D8F File Offset: 0x0034318F
		private void _onStartButton()
		{
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(base._commonStart());
		}

		// Token: 0x0600D324 RID: 54052 RVA: 0x00344DA4 File Offset: 0x003431A4
		protected sealed override void _onDiffChange(int idx)
		{
			this.mDungeonID.diffID = idx;
			int dungeonID = this.mDungeonID.dungeonID;
			this.mCurrentDiffDesc.text = ChapterUtility.GetHardString(idx);
			if (this.mDungeonTable != null)
			{
				this.mCurrentDropDesc.text = this.mDungeonTable.HardDescription;
			}
			ComChapterDungeonUnit.eState dungeonState = ChapterUtility.GetDungeonState(dungeonID);
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			bool enabled = dungeonState == ComChapterDungeonUnit.eState.Locked || tableItem.MinLevel > (int)DataManager<PlayerBaseData>.GetInstance().Level;
			this.mGroupStartGray.enabled = enabled;
		}

		// Token: 0x04007B8B RID: 31627
		private ComCommonChapterInfo mChapterInfo;

		// Token: 0x04007B8C RID: 31628
		private Button mStart;

		// Token: 0x04007B8D RID: 31629
		private Text mLeftCount;

		// Token: 0x04007B8E RID: 31630
		private Text mCurrentDiffDesc;

		// Token: 0x04007B8F RID: 31631
		private Text mCurrentDropDesc;

		// Token: 0x04007B90 RID: 31632
		private Text mName;

		// Token: 0x04007B91 RID: 31633
		private UIGray mGroupStartGray;
	}
}
