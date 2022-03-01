using System;
using System.Collections.Generic;
using System.Reflection;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200152F RID: 5423
	public class ChapterMouFrame : ChapterBaseFrame
	{
		// Token: 0x0600D332 RID: 54066 RVA: 0x00345017 File Offset: 0x00343417
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Activity/Dungeon/ChapterMou";
		}

		// Token: 0x0600D333 RID: 54067 RVA: 0x00345020 File Offset: 0x00343420
		protected override void _bindExUI()
		{
			this.mChapterInfo = this.mBind.GetCom<ComCommonChapterInfo>("chapterInfo");
			this.mStart = this.mBind.GetCom<Button>("start");
			this.mStart.onClick.AddListener(new UnityAction(this._onStartButtonClick));
			this.mLeftCount = this.mBind.GetCom<Text>("leftCount");
			this.mName = this.mBind.GetCom<Text>("name");
		}

		// Token: 0x0600D334 RID: 54068 RVA: 0x003450A1 File Offset: 0x003434A1
		protected override void _unbindExUI()
		{
			this.mChapterInfo = null;
			this.mStart.onClick.RemoveListener(new UnityAction(this._onStartButtonClick));
			this.mStart = null;
			this.mLeftCount = null;
			this.mName = null;
		}

		// Token: 0x0600D335 RID: 54069 RVA: 0x003450DB File Offset: 0x003434DB
		private void _onStartButtonClick()
		{
			this._onStartButton();
		}

		// Token: 0x0600D336 RID: 54070 RVA: 0x003450E3 File Offset: 0x003434E3
		protected override void _loadBg()
		{
		}

		// Token: 0x0600D337 RID: 54071 RVA: 0x003450E8 File Offset: 0x003434E8
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mDungeonTable != null)
			{
				this.mName.text = this.mDungeonTable.Name;
				int num = this.mDungeonTable.DailyMaxTime - DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.DUNGEON_DAILY_COUNT_PREFIX, (int)this.mDungeonTable.SubType);
				this.mLeftCount.text = num.ToString();
			}
		}

		// Token: 0x0600D338 RID: 54072 RVA: 0x0034515C File Offset: 0x0034355C
		protected override void _loadLeftPanel()
		{
			if (null != this.mChapterInfo)
			{
				ComCommonChapterInfo comCommonChapterInfo = this.mChapterInfo;
				this.mChapterInfoCommon = comCommonChapterInfo;
				this.mChapterInfoDiffculte = comCommonChapterInfo;
				this.mChapterInfoDrops = comCommonChapterInfo;
				this.mChapterPassReward = comCommonChapterInfo;
				this.mChapterScore = comCommonChapterInfo;
				this.mChapterMonsterInfo = comCommonChapterInfo;
				this.mChapterActivityTimes = comCommonChapterInfo;
			}
			this.mChapterInfoDiffculte.SetDiffculte(this.mChapterInfoDiffculte.GetDiffculte(), this.mDungeonID.dungeonID);
		}

		// Token: 0x0600D339 RID: 54073 RVA: 0x003451D4 File Offset: 0x003435D4
		protected override void _updateDropInfo()
		{
			List<ComItemList.Items> list = new List<ComItemList.Items>();
			ComItemList.Items items = new ComItemList.Items();
			LevelAdapterTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<LevelAdapterTable>(1000, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("can not get levelAdapterTable id is {0}", new object[]
				{
					1000
				});
				return;
			}
			PropertyInfo property = tableItem.GetType().GetProperty(string.Format("Level{0}", DataManager<PlayerBaseData>.GetInstance().Level), BindingFlags.Instance | BindingFlags.Public);
			items.id = this.mDungeonTable.DropItems[0];
			int count = 0;
			if (property != null)
			{
				count = (int)property.GetValue(tableItem, null);
			}
			items.id = this.mDungeonTable.DropItems[0];
			items.count = (uint)count;
			list.Add(items);
			this.mChapterInfoDrops.UpdateDropCount(list);
		}

		// Token: 0x0600D33A RID: 54074 RVA: 0x003452B3 File Offset: 0x003436B3
		private void _onStartButton()
		{
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(base._commonStart());
		}

		// Token: 0x04007B96 RID: 31638
		private ComCommonChapterInfo mChapterInfo;

		// Token: 0x04007B97 RID: 31639
		private Button mStart;

		// Token: 0x04007B98 RID: 31640
		private Text mLeftCount;

		// Token: 0x04007B99 RID: 31641
		private Text mName;

		// Token: 0x02001530 RID: 5424
		public enum ChapterSelectType
		{
			// Token: 0x04007B9B RID: 31643
			MouChapter = 1000
		}
	}
}
