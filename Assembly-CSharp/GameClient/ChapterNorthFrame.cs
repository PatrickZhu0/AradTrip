using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001533 RID: 5427
	public class ChapterNorthFrame : ChapterBaseFrame
	{
		// Token: 0x0600D39D RID: 54173 RVA: 0x00348E5C File Offset: 0x0034725C
		protected override void _bindExUI()
		{
			this.mChapterInfo = this.mBind.GetCom<ComCommonChapterInfo>("chapterInfo");
			this.mStart = this.mBind.GetCom<Button>("start");
			this.mStart.onClick.AddListener(new UnityAction(this._onStartButtonClick));
			this.mCostSelect0 = this.mBind.GetCom<Toggle>("costSelect0");
			this.mCostSelect0.onValueChanged.AddListener(new UnityAction<bool>(this._onCostSelect0ToggleValueChange));
			this.mCostSelect1 = this.mBind.GetCom<Toggle>("costSelect1");
			this.mCostSelect1.onValueChanged.AddListener(new UnityAction<bool>(this._onCostSelect1ToggleValueChange));
			this.mLeftCount = this.mBind.GetCom<Text>("leftCount");
			this.mVipText = this.mBind.GetCom<Text>("vipText");
			this.mGetTexts[0] = this.mBind.GetCom<Text>("getText0");
			this.mGetTexts[1] = this.mBind.GetCom<Text>("getText1");
			this.mCostTexts[0] = this.mBind.GetCom<Text>("costText0");
			this.mCostTexts[1] = this.mBind.GetCom<Text>("costText1");
			this.mCurrentDiffText = this.mBind.GetCom<Text>("currentDiffText");
			this.mCurrentDropText = this.mBind.GetCom<Text>("currentDropText");
			this.mName = this.mBind.GetCom<Text>("name");
		}

		// Token: 0x0600D39E RID: 54174 RVA: 0x00348FE4 File Offset: 0x003473E4
		protected override void _unbindExUI()
		{
			this.mChapterInfo = null;
			this.mStart.onClick.RemoveListener(new UnityAction(this._onStartButtonClick));
			this.mStart = null;
			this.mCostSelect0.onValueChanged.RemoveListener(new UnityAction<bool>(this._onCostSelect0ToggleValueChange));
			this.mCostSelect0 = null;
			this.mCostSelect1.onValueChanged.RemoveListener(new UnityAction<bool>(this._onCostSelect1ToggleValueChange));
			this.mCostSelect1 = null;
			this.mLeftCount = null;
			this.mVipText = null;
			this.mGetTexts[0] = null;
			this.mGetTexts[1] = null;
			this.mCostTexts[0] = null;
			this.mCostTexts[1] = null;
			this.mCurrentDiffText = null;
			this.mCurrentDropText = null;
			this.mName = null;
		}

		// Token: 0x0600D39F RID: 54175 RVA: 0x003490A8 File Offset: 0x003474A8
		private void _onStartButtonClick()
		{
			this._onStartButton();
		}

		// Token: 0x0600D3A0 RID: 54176 RVA: 0x003490B0 File Offset: 0x003474B0
		private void _onCostSelect0ToggleValueChange(bool changed)
		{
			this._onHandle(0, changed);
		}

		// Token: 0x0600D3A1 RID: 54177 RVA: 0x003490BA File Offset: 0x003474BA
		private void _onCostSelect1ToggleValueChange(bool changed)
		{
			this._onHandle(1, changed);
		}

		// Token: 0x0600D3A2 RID: 54178 RVA: 0x003490C4 File Offset: 0x003474C4
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

		// Token: 0x0600D3A3 RID: 54179 RVA: 0x0034913B File Offset: 0x0034753B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Activity/Dungeon/ChapterNorth";
		}

		// Token: 0x0600D3A4 RID: 54180 RVA: 0x00349142 File Offset: 0x00347542
		private void _onHandle(int idx, bool status)
		{
			this.mSelect = -1;
			ChapterNorthFrame.sMuti = 1;
			if (status)
			{
				this.mSelect = idx;
				if (!int.TryParse(this.mGetTexts[idx].text, out ChapterNorthFrame.sMuti))
				{
					ChapterNorthFrame.sMuti = 1;
				}
			}
		}

		// Token: 0x0600D3A5 RID: 54181 RVA: 0x00349180 File Offset: 0x00347580
		private void _onStartButton()
		{
			if (this.mSelect >= 0 && this.mSelect < 2)
			{
				int nCount = 0;
				if (!int.TryParse(this.mCostTexts[this.mSelect].text, out nCount))
				{
					return;
				}
				CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
				costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT);
				costInfo.nCount = nCount;
				DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
				{
					MonoSingleton<GameFrameWork>.instance.StartCoroutine(base._commonStart());
				}, "common_money_cost", null);
			}
			else
			{
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(base._commonStart());
			}
		}

		// Token: 0x0600D3A6 RID: 54182 RVA: 0x00349218 File Offset: 0x00347618
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			this._updateInfo();
		}

		// Token: 0x0600D3A7 RID: 54183 RVA: 0x00349226 File Offset: 0x00347626
		private int _getMaxCount()
		{
			return this.mDungeonTable.DailyMaxTime + this._getVipCount();
		}

		// Token: 0x0600D3A8 RID: 54184 RVA: 0x0034923C File Offset: 0x0034763C
		private int _getVipCount()
		{
			float curVipLevelPrivilegeData = Utility.GetCurVipLevelPrivilegeData(VipPrivilegeTable.eType.MAGIC_VEIN_NUM);
			if (curVipLevelPrivilegeData <= 0f)
			{
				return 0;
			}
			return (int)curVipLevelPrivilegeData;
		}

		// Token: 0x0600D3A9 RID: 54185 RVA: 0x00349260 File Offset: 0x00347660
		private void _updateInfo()
		{
			ChapterNorthFrame.sMuti = 1;
			this.mSelect = -1;
			if (this.mDungeonTable != null)
			{
				this.mName.text = this.mDungeonTable.Name;
				FlatBufferArray<string> raceEndDropMultiCost = this.mDungeonTable.RaceEndDropMultiCost;
				int num = 0;
				while (num < raceEndDropMultiCost.Count && num < 2)
				{
					string text = raceEndDropMultiCost[num];
					string[] array = text.Split(new char[]
					{
						':'
					});
					if (array.Length >= 2)
					{
						this.mGetTexts[num].text = array[0];
						this.mCostTexts[num].text = array[1];
					}
					num++;
				}
				List<int> list = new List<int>(this.mDungeonTable.RaceEndDropBaseMulti);
				list.RemoveAll((int x) => x <= 0);
				if (list.Count > 0)
				{
				}
				int num2 = this._getMaxCount();
				int num3 = num2 - DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.DUNGEON_DAILY_COUNT_PREFIX, (int)this.mDungeonTable.SubType);
				this.mLeftCount.text = string.Format("{0}/{1}", num3, num2);
				int num4 = this._getVipCount();
				if (num4 <= 0)
				{
					KeyValuePair<int, float> firstValidVipLevelPrivilegeData = Utility.GetFirstValidVipLevelPrivilegeData(VipPrivilegeTable.eType.MAGIC_VEIN_NUM);
					if (firstValidVipLevelPrivilegeData.Key > 0)
					{
						this.mVipText.text = string.Format("贵族 {0} 可将挑战上限提升至 {1}", firstValidVipLevelPrivilegeData.Key, (int)firstValidVipLevelPrivilegeData.Value);
					}
				}
				else
				{
					this.mVipText.text = string.Format("贵族 {0} 挑战上限提升至 {1}", DataManager<PlayerBaseData>.GetInstance().VipLevel, num4);
				}
			}
		}

		// Token: 0x0600D3AA RID: 54186 RVA: 0x00349419 File Offset: 0x00347819
		protected override void _onDiffChange(int idx)
		{
			this.mCurrentDiffText.text = ChapterUtility.GetHardString(idx);
			if (this.mDungeonTable != null)
			{
				this.mCurrentDropText.text = this.mDungeonTable.HardDescription;
			}
		}

		// Token: 0x04007BF7 RID: 31735
		public static int sMuti = 1;

		// Token: 0x04007BF8 RID: 31736
		private ComCommonChapterInfo mChapterInfo;

		// Token: 0x04007BF9 RID: 31737
		private Button mStart;

		// Token: 0x04007BFA RID: 31738
		private Toggle mCostSelect0;

		// Token: 0x04007BFB RID: 31739
		private Toggle mCostSelect1;

		// Token: 0x04007BFC RID: 31740
		private Text mLeftCount;

		// Token: 0x04007BFD RID: 31741
		private Text mVipText;

		// Token: 0x04007BFE RID: 31742
		private Text[] mGetTexts = new Text[2];

		// Token: 0x04007BFF RID: 31743
		private Text[] mCostTexts = new Text[2];

		// Token: 0x04007C00 RID: 31744
		private Text mName;

		// Token: 0x04007C01 RID: 31745
		private Text mCurrentDiffText;

		// Token: 0x04007C02 RID: 31746
		private Text mCurrentDropText;

		// Token: 0x04007C03 RID: 31747
		private int mSelect = -1;
	}
}
