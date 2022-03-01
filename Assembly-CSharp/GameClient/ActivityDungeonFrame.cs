using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001396 RID: 5014
	public class ActivityDungeonFrame : ClientFrame
	{
		// Token: 0x17001BD4 RID: 7124
		// (get) Token: 0x0600C28D RID: 49805 RVA: 0x002E5D3B File Offset: 0x002E413B
		private ActivityDungeonTable.eActivityType lastSwitchKindType
		{
			get
			{
				return this.mLastSwitchKindType;
			}
		}

		// Token: 0x17001BD5 RID: 7125
		// (get) Token: 0x0600C28E RID: 49806 RVA: 0x002E5D43 File Offset: 0x002E4143
		// (set) Token: 0x0600C28F RID: 49807 RVA: 0x002E5D4B File Offset: 0x002E414B
		private ActivityDungeonTable.eActivityType currentSwitchType
		{
			get
			{
				return this.mCurSwitchKindType;
			}
			set
			{
				if (this.mCurSwitchKindType != value)
				{
					this.mLastSwitchKindType = this.mCurSwitchKindType;
					this.mCurSwitchKindType = value;
				}
			}
		}

		// Token: 0x17001BD6 RID: 7126
		// (get) Token: 0x0600C290 RID: 49808 RVA: 0x002E5D6C File Offset: 0x002E416C
		private int GuideDungeonId
		{
			get
			{
				return this.mGuideDungeonId;
			}
		}

		// Token: 0x0600C291 RID: 49809 RVA: 0x002E5D74 File Offset: 0x002E4174
		public static void OpenLinkFrame(string strParam)
		{
			try
			{
				ActiveParams activeParams = new ActiveParams();
				string[] array = strParam.Split(new char[]
				{
					'|'
				});
				if (array.Length > 0)
				{
					try
					{
						activeParams.param0 = ulong.Parse(array[0]);
					}
					catch (Exception ex)
					{
						Logger.LogError("ActivityDungeonFrame.OpenLinkFrame : strParams[0] ==>" + ex.ToString());
					}
				}
				if (array.Length > 1)
				{
					try
					{
						activeParams.type = (ActivityDungeonTable.eActivityType)ulong.Parse(array[1]);
					}
					catch (Exception ex2)
					{
						Logger.LogError("ActivityDungeonFrame.OpenLinkFrame : strParams[1] ==>" + ex2.ToString());
					}
				}
				if (array.Length > 2)
				{
					try
					{
						activeParams.dungeonId = int.Parse(array[2]);
					}
					catch (Exception ex3)
					{
						Logger.LogError("ActivityDungeonFrame.OpenLinkFrame : strParams[2] ==>" + ex3.ToString());
					}
				}
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ActivityDungeonFrame>(null, false);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActivityDungeonFrame>(FrameLayer.Middle, activeParams, string.Empty);
			}
			catch (Exception ex4)
			{
				Logger.LogError(ex4.ToString());
			}
		}

		// Token: 0x0600C292 RID: 49810 RVA: 0x002E5EAC File Offset: 0x002E42AC
		protected override void _bindExUI()
		{
			this.mName = this.mBind.GetCom<Text>("name");
			this.mHelp = this.mBind.GetCom<Button>("help");
			this.mHelp.onClick.AddListener(new UnityAction(this._onHelpButtonClick));
			this.mClose = this.mBind.GetCom<Button>("close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			this.mTabroot = this.mBind.GetGameObject("tabroot");
			this.mTabrootgroup = this.mBind.GetCom<ToggleGroup>("tabrootgroup");
			this.mGridToggleGroup = this.mBind.GetCom<ToggleGroup>("gridToggleGroup");
			this.mGirldRoot = this.mBind.GetGameObject("girldRoot");
			this.mDailyRoot = this.mBind.GetGameObject("dailyRoot");
			this.mOtherRoot = this.mBind.GetGameObject("otherRoot");
			this.mOtherRootContent = this.mBind.GetGameObject("otherRootContent");
			this.mRewardRootContent = this.mBind.GetGameObject("rewardRootContent");
			this.mDailyKindToggle = this.mBind.GetCom<Toggle>("dailyKindToggle");
			this.mDailyKindToggle.onValueChanged.AddListener(new UnityAction<bool>(this._onDailyKindToggleToggleValueChange));
			this.mTimeLimitKindToggle = this.mBind.GetCom<Toggle>("timeLimitKindToggle");
			this.mTimeLimitKindToggle.onValueChanged.AddListener(new UnityAction<bool>(this._onTimeLimitKindToggleToggleValueChange));
			this.mRewardKindToggle = this.mBind.GetCom<Toggle>("rewardKindToggle");
			this.mRewardKindToggle.onValueChanged.AddListener(new UnityAction<bool>(this._onRewardKindToggleToggleValueChange));
			this.mAllDailyTab = this.mBind.GetCom<Toggle>("allDailyTab");
			this.mAllDailyTab.onValueChanged.AddListener(new UnityAction<bool>(this._onAllDailyTabToggleValueChange));
			this.mTimeLimitToggleGroup = this.mBind.GetCom<ToggleGroup>("timeLimitToggleGroup");
			this.mAllDialyTabRedPoint = this.mBind.GetGameObject("allDialyTabRedPoint");
			this.mDailyKindRedPoint = this.mBind.GetGameObject("dailyKindRedPoint");
			this.mTimeLimitKindRedPoint = this.mBind.GetGameObject("timeLimitKindRedPoint");
			this.mRewardKindRedPoint = this.mBind.GetGameObject("rewardKindRedPoint");
		}

		// Token: 0x0600C293 RID: 49811 RVA: 0x002E611C File Offset: 0x002E451C
		protected override void _unbindExUI()
		{
			this.mName = null;
			this.mHelp.onClick.RemoveListener(new UnityAction(this._onHelpButtonClick));
			this.mHelp = null;
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
			this.mTabroot = null;
			this.mTabrootgroup = null;
			this.mGridToggleGroup = null;
			this.mGirldRoot = null;
			this.mDailyRoot = null;
			this.mOtherRoot = null;
			this.mOtherRootContent = null;
			this.mRewardRootContent = null;
			this.mDailyKindToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._onDailyKindToggleToggleValueChange));
			this.mDailyKindToggle = null;
			this.mTimeLimitKindToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._onTimeLimitKindToggleToggleValueChange));
			this.mTimeLimitKindToggle = null;
			this.mRewardKindToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._onRewardKindToggleToggleValueChange));
			this.mRewardKindToggle = null;
			this.mAllDailyTab.onValueChanged.RemoveListener(new UnityAction<bool>(this._onAllDailyTabToggleValueChange));
			this.mAllDailyTab = null;
			this.mTimeLimitToggleGroup = null;
			this.mAllDialyTabRedPoint = null;
			this.mDailyKindRedPoint = null;
			this.mTimeLimitKindRedPoint = null;
			this.mRewardKindRedPoint = null;
		}

		// Token: 0x0600C294 RID: 49812 RVA: 0x002E625D File Offset: 0x002E465D
		private void _onHelpButtonClick()
		{
		}

		// Token: 0x0600C295 RID: 49813 RVA: 0x002E625F File Offset: 0x002E465F
		private void _onCloseButtonClick()
		{
			this._onClose();
		}

		// Token: 0x0600C296 RID: 49814 RVA: 0x002E6267 File Offset: 0x002E4667
		private void _onDailyKindToggleToggleValueChange(bool changed)
		{
			if (changed)
			{
				this._switch2KindTab(ActivityDungeonTable.eActivityType.Daily);
			}
		}

		// Token: 0x0600C297 RID: 49815 RVA: 0x002E6276 File Offset: 0x002E4676
		private void _onTimeLimitKindToggleToggleValueChange(bool changed)
		{
			if (changed)
			{
				this._switch2KindTab(ActivityDungeonTable.eActivityType.TimeLimit);
			}
		}

		// Token: 0x0600C298 RID: 49816 RVA: 0x002E6285 File Offset: 0x002E4685
		private void _onRewardKindToggleToggleValueChange(bool changed)
		{
			if (changed)
			{
				this._switch2KindTab(ActivityDungeonTable.eActivityType.Reward);
			}
		}

		// Token: 0x0600C299 RID: 49817 RVA: 0x002E6294 File Offset: 0x002E4694
		private void _onAllDailyTabToggleValueChange(bool changed)
		{
			if (changed)
			{
				this._switch2DailyTab(int.MaxValue);
			}
		}

		// Token: 0x0600C29A RID: 49818 RVA: 0x002E62A7 File Offset: 0x002E46A7
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Activity/Dungeon/ActivityDungeon";
		}

		// Token: 0x0600C29B RID: 49819 RVA: 0x002E62B0 File Offset: 0x002E46B0
		protected override void _OnOpenFrame()
		{
			this._clearBeforeOpenAndClose();
			this._tryGuideActivity();
			this._updateAllKindRedState();
			this._OnOpenChapterFrame();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityDungeonUpdate, new ClientEventSystem.UIEventHandler(this._updateUnitState));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnDeadTowerWipeoutTimeChange, new ClientEventSystem.UIEventHandler(this._updateUnitState));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityDungeonStateUpdate, new ClientEventSystem.UIEventHandler(this._updateStateUpdate));
		}

		// Token: 0x0600C29C RID: 49820 RVA: 0x002E6328 File Offset: 0x002E4728
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityDungeonUpdate, new ClientEventSystem.UIEventHandler(this._updateUnitState));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnDeadTowerWipeoutTimeChange, new ClientEventSystem.UIEventHandler(this._updateUnitState));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityDungeonStateUpdate, new ClientEventSystem.UIEventHandler(this._updateStateUpdate));
			this._clearAllKindTabContent();
			this._clearBeforeOpenAndClose();
		}

		// Token: 0x0600C29D RID: 49821 RVA: 0x002E6392 File Offset: 0x002E4792
		private void _clearBeforeOpenAndClose()
		{
			this.mCacheBind.Clear();
			this.mCacheTabBind.Clear();
			this.mLastSelectFrameName = string.Empty;
			this.mLastSwitchKindType = ActivityDungeonTable.eActivityType.None;
			this.mCurSwitchKindType = ActivityDungeonTable.eActivityType.None;
		}

		// Token: 0x0600C29E RID: 49822 RVA: 0x002E63C4 File Offset: 0x002E47C4
		private void _updateUnitState(UIEvent ui)
		{
			for (int i = 0; i < this.mCacheBind.Count; i++)
			{
				this._updateRedState(this.mCacheBind[i].sub, this.mCacheBind[i].bind);
				this._updateTimeLimitUnitState(this.mCacheBind[i].sub, this.mCacheBind[i].bind);
			}
			if (this.currentSwitchType == ActivityDungeonTable.eActivityType.Daily)
			{
				for (int j = 0; j < this.mCacheTabBind.Count; j++)
				{
					this._updateOneDailyTabRedPoint(this.mCacheTabBind[j].tab, this.mCacheTabBind[j].bind);
				}
			}
			this._updateAllKindRedState();
		}

		// Token: 0x0600C29F RID: 49823 RVA: 0x002E6493 File Offset: 0x002E4893
		private void _updateStateUpdate(UIEvent ui)
		{
			if (ActivityDungeonFrame.mSelectedLastDungeonId == -1)
			{
				this._switch2DailyTab(int.MaxValue);
			}
			else
			{
				this._switch2DailyTab(ActivityDungeonFrame.mSelectedLastDungeonId);
			}
		}

		// Token: 0x0600C2A0 RID: 49824 RVA: 0x002E64BC File Offset: 0x002E48BC
		private void _updateRedState(ActivityDungeonSub sub, ComCommonBind bind)
		{
			ActivityDungeonTable.eActivityType currentSwitchType = this.currentSwitchType;
			if (currentSwitchType != ActivityDungeonTable.eActivityType.Daily)
			{
				if (currentSwitchType == ActivityDungeonTable.eActivityType.TimeLimit)
				{
					this._updateTimeLimitUnitRedPoint(sub, bind);
				}
			}
			else
			{
				this._updateDailyUnitRedPoint(sub, bind);
				this._updateDailyUnitState(sub, bind);
			}
		}

		// Token: 0x0600C2A1 RID: 49825 RVA: 0x002E6505 File Offset: 0x002E4905
		private void _updateAllKindRedState()
		{
			this._updateKindRedState(ActivityDungeonTable.eActivityType.Daily);
			this._updateKindRedState(ActivityDungeonTable.eActivityType.Reward);
			this._updateKindRedState(ActivityDungeonTable.eActivityType.TimeLimit);
		}

		// Token: 0x0600C2A2 RID: 49826 RVA: 0x002E651C File Offset: 0x002E491C
		private void _updateKindRedState(ActivityDungeonTable.eActivityType type)
		{
			if (type != ActivityDungeonTable.eActivityType.Daily)
			{
				if (type != ActivityDungeonTable.eActivityType.Reward)
				{
					if (type == ActivityDungeonTable.eActivityType.TimeLimit)
					{
						this.mTimeLimitKindRedPoint.SetActive(DataManager<ActivityDungeonDataManager>.GetInstance().IsShowRedByActivityType(type));
						ScoreWarStatus scoreWarStatus = DataManager<Pk3v3CrossDataManager>.GetInstance().Get3v3CrossWarStatus();
						if (scoreWarStatus == ScoreWarStatus.SWS_PREPARE || scoreWarStatus == ScoreWarStatus.SWS_BATTLE)
						{
							this.mTimeLimitKindRedPoint.SetActive(true);
						}
					}
				}
				else
				{
					this.mRewardKindRedPoint.SetActive(MissionDailyFrame.CheckRedPoint());
				}
			}
			else
			{
				bool active = DataManager<ActivityDungeonDataManager>.GetInstance().IsShowRedByActivityType(type);
				this.mDailyKindRedPoint.SetActive(active);
				this.mAllDialyTabRedPoint.SetActive(active);
			}
		}

		// Token: 0x0600C2A3 RID: 49827 RVA: 0x002E65C1 File Offset: 0x002E49C1
		private void _tryGuideActivity()
		{
			this._updateGuideDungeonId();
			this._doGuideByActivityType();
			this._resetGuideDungeonId();
		}

		// Token: 0x0600C2A4 RID: 49828 RVA: 0x002E65D8 File Offset: 0x002E49D8
		private void _doGuideByActivityType()
		{
			switch (this._getGuideType())
			{
			case ActivityDungeonTable.eActivityType.None:
				Logger.LogErrorFormat("[活动副本] 错误的引导类型类型", new object[0]);
				break;
			case ActivityDungeonTable.eActivityType.TimeLimit:
				this.mTimeLimitKindToggle.isOn = true;
				break;
			case ActivityDungeonTable.eActivityType.Daily:
				this.mDailyKindToggle.isOn = true;
				break;
			case ActivityDungeonTable.eActivityType.Reward:
				this.mRewardKindToggle.isOn = true;
				break;
			}
		}

		// Token: 0x0600C2A5 RID: 49829 RVA: 0x002E6650 File Offset: 0x002E4A50
		private ActivityDungeonTable.eActivityType _getGuideType()
		{
			if (this.data != null && this.data.type == ActivityDungeonTable.eActivityType.Reward)
			{
				return ActivityDungeonTable.eActivityType.Reward;
			}
			ActivityDungeonSub subByDungeonID = DataManager<ActivityDungeonDataManager>.GetInstance().GetSubByDungeonID(this.GuideDungeonId);
			if (subByDungeonID != null)
			{
				return subByDungeonID.table.ActivityType;
			}
			return ActivityDungeonTable.eActivityType.Reward;
		}

		// Token: 0x0600C2A6 RID: 49830 RVA: 0x002E66A0 File Offset: 0x002E4AA0
		private void _updateGuideDungeonId()
		{
			this.data = (this.userData as ActiveParams);
			this._resetGuideDungeonId();
			if (this.data == null)
			{
				return;
			}
			int did = (int)this.data.param0;
			ActivityDungeonSub subByDungeonID = DataManager<ActivityDungeonDataManager>.GetInstance().GetSubByDungeonID(did);
			if (subByDungeonID != null)
			{
				this.mGuideDungeonId = subByDungeonID.dungeonId;
			}
		}

		// Token: 0x0600C2A7 RID: 49831 RVA: 0x002E66FB File Offset: 0x002E4AFB
		private void _resetGuideDungeonId()
		{
			this.mGuideDungeonId = ActivityDungeonFrame.mSelectedLastDungeonId;
		}

		// Token: 0x0600C2A8 RID: 49832 RVA: 0x002E6708 File Offset: 0x002E4B08
		private void _OnOpenChapterFrame()
		{
			if (this.userData != null)
			{
				this.data = (this.userData as ActiveParams);
				if (this.data != null && this.data.dungeonId > 0)
				{
					this._bindAllButton(this.data.dungeonId);
				}
			}
		}

		// Token: 0x0600C2A9 RID: 49833 RVA: 0x002E675E File Offset: 0x002E4B5E
		private void _switch2KindTab(ActivityDungeonTable.eActivityType type)
		{
			if (!this._isSwitchKindTab(type))
			{
				return;
			}
			this._clearAllKindTabContent();
			this._switch2KindContent();
			this._loadSwitchedKindContent(this.GuideDungeonId);
		}

		// Token: 0x0600C2AA RID: 49834 RVA: 0x002E6785 File Offset: 0x002E4B85
		private bool _isSwitchKindTab(ActivityDungeonTable.eActivityType type)
		{
			if (this.currentSwitchType != type)
			{
				this.currentSwitchType = type;
				return true;
			}
			return false;
		}

		// Token: 0x0600C2AB RID: 49835 RVA: 0x002E67A0 File Offset: 0x002E4BA0
		private void _clearAllKindTabContent()
		{
			string prefabPath = this.mBind.GetPrefabPath("tab");
			this.mBind.ClearCacheBinds(prefabPath);
			string prefabPath2 = this.mBind.GetPrefabPath("timelimitunit");
			this.mBind.ClearCacheBinds(prefabPath2);
			string prefabPath3 = this.mBind.GetPrefabPath("dailyunit");
			this.mBind.ClearCacheBinds(prefabPath3);
			string prefabPath4 = this.mBind.GetPrefabPath("rottenetterDailyUnit");
			this.mBind.ClearCacheBinds(prefabPath4);
			this.mLastSelectFrameName = string.Empty;
			this._clearRewradFrame();
			this._clearInfoFrame();
		}

		// Token: 0x0600C2AC RID: 49836 RVA: 0x002E6838 File Offset: 0x002E4C38
		private void _clearRewradFrame()
		{
			if (this.mLastOpenFrame != null)
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<IClientFrame>(this.mLastOpenFrame, true);
			}
			this.mLastOpenFrame = null;
		}

		// Token: 0x0600C2AD RID: 49837 RVA: 0x002E685D File Offset: 0x002E4C5D
		private void _clearInfoFrame()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<ActivityDungeonInfoFrame>(null, false);
		}

		// Token: 0x0600C2AE RID: 49838 RVA: 0x002E686C File Offset: 0x002E4C6C
		private void _switch2KindContent()
		{
			this.mOtherRoot.SetActive(false);
			this.mDailyRoot.SetActive(false);
			ActivityDungeonTable.eActivityType currentSwitchType = this.currentSwitchType;
			if (currentSwitchType != ActivityDungeonTable.eActivityType.Daily)
			{
				if (currentSwitchType == ActivityDungeonTable.eActivityType.TimeLimit || currentSwitchType == ActivityDungeonTable.eActivityType.Reward)
				{
					this.mOtherRoot.SetActive(true);
				}
			}
			else
			{
				this.mDailyRoot.SetActive(true);
			}
		}

		// Token: 0x0600C2AF RID: 49839 RVA: 0x002E68D4 File Offset: 0x002E4CD4
		private void _loadSwitchedKindContent(int dungeonId)
		{
			ActivityDungeonTable.eActivityType currentSwitchType = this.currentSwitchType;
			if (currentSwitchType != ActivityDungeonTable.eActivityType.Daily)
			{
				if (currentSwitchType != ActivityDungeonTable.eActivityType.TimeLimit)
				{
					if (currentSwitchType == ActivityDungeonTable.eActivityType.Reward)
					{
						this._loadDailyRewardFrame();
					}
				}
				else
				{
					this._initTimeLimitUnit(dungeonId);
				}
			}
			else
			{
				this._initDailyTabs(dungeonId);
			}
		}

		// Token: 0x0600C2B0 RID: 49840 RVA: 0x002E6928 File Offset: 0x002E4D28
		private void _initDailyTabs(int dungeonId)
		{
			if (null == this.mBind)
			{
				return;
			}
			List<ActivityDungeonTab> tabByActivityType = DataManager<ActivityDungeonDataManager>.GetInstance().GetTabByActivityType(ActivityDungeonTable.eActivityType.Daily);
			ActivityDungeonTab dailyDungeonTab = DataManager<ActivityDungeonDataManager>.GetInstance().GetDailyDungeonTab();
			string prefabPath = this.mBind.GetPrefabPath("tab");
			this.mBind.ClearCacheBinds(prefabPath);
			this.mCacheTabBind.Clear();
			for (int i = 0; i < tabByActivityType.Count; i++)
			{
				this._loadOneDailyTab(tabByActivityType[i], prefabPath, i, dailyDungeonTab == tabByActivityType[i]);
			}
			if (dailyDungeonTab == null)
			{
				this.mAllDailyTab.isOn = false;
				this.mAllDailyTab.isOn = true;
			}
			else
			{
				dungeonId = dailyDungeonTab.subs[0].dungeonId;
				this._switch2DailyTab(dungeonId);
			}
		}

		// Token: 0x0600C2B1 RID: 49841 RVA: 0x002E69F4 File Offset: 0x002E4DF4
		private void _loadOneDailyTab(ActivityDungeonTab tab, string tabnameunit, int index, bool isselected)
		{
			ComCommonBind comCommonBind = this.mBind.LoadExtraBind(tabnameunit);
			if (null != comCommonBind)
			{
				Utility.AttachTo(comCommonBind.gameObject, this.mTabroot, false);
				comCommonBind.gameObject.name = string.Format("Activity{0}", index);
				Text com = comCommonBind.GetCom<Text>("tabname");
				Toggle com2 = comCommonBind.GetCom<Toggle>("toggle");
				Button com3 = comCommonBind.GetCom<Button>("help");
				GameObject gameObject = comCommonBind.GetGameObject("helpRoot");
				gameObject.SetActive(false);
				ActivityDungeonFrame.ActivityDungeonTabWithBind activityDungeonTabWithBind = new ActivityDungeonFrame.ActivityDungeonTabWithBind();
				activityDungeonTabWithBind.tab = tab;
				activityDungeonTabWithBind.bind = comCommonBind;
				this.mCacheTabBind.Add(activityDungeonTabWithBind);
				this._updateOneDailyTabRedPoint(tab, comCommonBind);
				com.text = tab.name;
				com2.group = this.mTabrootgroup;
				com2.isOn = isselected;
				int dungeonId = tab.subs[0].dungeonId;
				com2.onValueChanged.AddListener(delegate(bool isOn)
				{
					if (isOn)
					{
						this._switch2DailyTab(dungeonId);
					}
				});
			}
		}

		// Token: 0x0600C2B2 RID: 49842 RVA: 0x002E6B08 File Offset: 0x002E4F08
		private void _updateOneDailyTabRedPoint(ActivityDungeonTab tab, ComCommonBind bind)
		{
			GameObject gameObject = bind.GetGameObject("redpoint");
			if (gameObject != null)
			{
				gameObject.SetActive(DataManager<ActivityDungeonDataManager>.GetInstance().IsTabShowRed(tab));
			}
		}

		// Token: 0x0600C2B3 RID: 49843 RVA: 0x002E6B40 File Offset: 0x002E4F40
		private void _switch2DailyTab(int dungeonId)
		{
			if (null == this.mBind)
			{
				return;
			}
			ActivityDungeonFrame.mSelectedLastDungeonId = dungeonId;
			List<ActivityDungeonSub> list = this._getDailyUnitActivitySubs(dungeonId);
			string text = this._getDailyUnitActivityTabName(dungeonId);
			this.mCacheBind.Clear();
			if (list.Count <= 0)
			{
				Logger.LogErrorFormat("[ActivityDungeon] 单位列表为空 {0} ", new object[]
				{
					dungeonId
				});
				return;
			}
			this.mLastSelectFrameName = text;
			string prefabPath = this.mBind.GetPrefabPath("dailyunit");
			string prefabPath2 = this.mBind.GetPrefabPath("rottenetterDailyUnit");
			this.mBind.ClearCacheBinds(prefabPath);
			this.mBind.ClearCacheBinds(prefabPath2);
			for (int i = 0; i < list.Count; i++)
			{
				if (DataManager<ActivityDungeonDataManager>.GetInstance()._judgeDungeonIDIsRotteneterHell(list[i].dungeonTable.ID))
				{
					if (list[i].state != eActivityDungeonState.End && list[i].state != eActivityDungeonState.None)
					{
						this._loadDailyUnitAndInit(list[i], prefabPath2);
					}
					break;
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				if (!DataManager<ActivityDungeonDataManager>.GetInstance()._judgeDungeonIDIsRotteneterHell(list[j].dungeonTable.ID))
				{
					this._loadDailyUnitAndInit(list[j], prefabPath);
				}
			}
		}

		// Token: 0x0600C2B4 RID: 49844 RVA: 0x002E6CA8 File Offset: 0x002E50A8
		private List<ActivityDungeonSub> _getDailyUnitActivitySubs(int dungeonId)
		{
			if (dungeonId == 2147483647)
			{
				return DataManager<ActivityDungeonDataManager>.GetInstance().GetSubByActivityType(ActivityDungeonTable.eActivityType.Daily);
			}
			ActivityDungeonTab tabByDungeonIDDefaultFirst = DataManager<ActivityDungeonDataManager>.GetInstance().GetTabByDungeonIDDefaultFirst(ActivityDungeonTable.eActivityType.Daily, dungeonId);
			if (tabByDungeonIDDefaultFirst != null)
			{
				return tabByDungeonIDDefaultFirst.subs;
			}
			return new List<ActivityDungeonSub>();
		}

		// Token: 0x0600C2B5 RID: 49845 RVA: 0x002E6CEC File Offset: 0x002E50EC
		private string _getDailyUnitActivityTabName(int dungeonId)
		{
			if (dungeonId == 2147483647)
			{
				return "全部";
			}
			ActivityDungeonTab tabByDungeonIDDefaultFirst = DataManager<ActivityDungeonDataManager>.GetInstance().GetTabByDungeonIDDefaultFirst(ActivityDungeonTable.eActivityType.Daily, dungeonId);
			if (tabByDungeonIDDefaultFirst != null)
			{
				return tabByDungeonIDDefaultFirst.name;
			}
			return string.Empty;
		}

		// Token: 0x0600C2B6 RID: 49846 RVA: 0x002E6D2C File Offset: 0x002E512C
		private void _loadDailyUnitAndInit(ActivityDungeonSub sub, string dailyunit)
		{
			ComCommonBind bind = this.mBind.LoadExtraBind(dailyunit);
			if (!this._attach2GridRoot(sub, bind))
			{
				return;
			}
			this._add2CacheBind(sub, bind);
			this._bindDailyGoAndSelectEvent(sub, bind);
			this._updateDailyUnitBaseInfo(sub, bind);
			this._updateDailyUnitState(sub, bind);
			this._updateDailyUnitRedPoint(sub, bind);
			if (DataManager<ActivityDungeonDataManager>.GetInstance()._judgeDungeonIDIsRotteneterHell(sub.dungeonTable.ID))
			{
				this._updateRotteneterHellTimes(sub, bind);
			}
		}

		// Token: 0x0600C2B7 RID: 49847 RVA: 0x002E6D9E File Offset: 0x002E519E
		private bool _attach2GridRoot(ActivityDungeonSub sub, ComCommonBind bind)
		{
			if (null != bind)
			{
				bind.gameObject.name = sub.id.ToString();
				Utility.AttachTo(bind.gameObject, this.mGirldRoot, false);
				return true;
			}
			return false;
		}

		// Token: 0x0600C2B8 RID: 49848 RVA: 0x002E6DE0 File Offset: 0x002E51E0
		private void _add2CacheBind(ActivityDungeonSub sub, ComCommonBind bind)
		{
			ActivityDungeonFrame.ActivityDungeonSubWithBind activityDungeonSubWithBind = new ActivityDungeonFrame.ActivityDungeonSubWithBind();
			activityDungeonSubWithBind.sub = sub;
			activityDungeonSubWithBind.bind = bind;
			this.mCacheBind.Add(activityDungeonSubWithBind);
		}

		// Token: 0x0600C2B9 RID: 49849 RVA: 0x002E6E10 File Offset: 0x002E5210
		private void _bindDailyGoAndSelectEvent(ActivityDungeonSub sub, ComCommonBind bind)
		{
			Button com = bind.GetCom<Button>("goButton");
			int dungeonId = sub.dungeonId;
			com.onClick.AddListener(delegate()
			{
				if (!ActivityDungeonDataManager.IsUltimateChallengeActivity(sub.table))
				{
					this._bindAllButton(dungeonId);
					return;
				}
				if (!DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsServiceTypeSwitchOpen(ServiceType.SERVICE_ZJSL_TOWER))
				{
					SystemNotifyManager.SystemNotify(4500005, string.Empty);
					return;
				}
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<UltimateChallengeFrame>(null, false);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<UltimateChallengeFrame>(FrameLayer.Middle, null, string.Empty);
			});
			Toggle com2 = bind.GetCom<Toggle>("toggle");
			com2.group = this.mGridToggleGroup;
			com2.isOn = (dungeonId == this.GuideDungeonId);
			com2.onValueChanged.AddListener(delegate(bool isOn)
			{
				if (isOn)
				{
					this._openActivityDungeonInfoFrame(dungeonId);
				}
			});
		}

		// Token: 0x0600C2BA RID: 49850 RVA: 0x002E6EA8 File Offset: 0x002E52A8
		private void _updateDailyUnitBaseInfo(ActivityDungeonSub sub, ComCommonBind bind)
		{
			this._updateDailyUnitBaseTextInfo(sub, bind);
			this._updateDailyUnitBaseSpritInfo(sub, bind);
			this._updateDailyUnitBaseCounterInfo(sub, bind);
			this._updateDailyUnitBaseShowHiddenInfo(sub, bind);
		}

		// Token: 0x0600C2BB RID: 49851 RVA: 0x002E6ECC File Offset: 0x002E52CC
		private void _updateDailyUnitBaseTextInfo(ActivityDungeonSub sub, ComCommonBind bind)
		{
			Text com = bind.GetCom<Text>("name");
			Text com2 = bind.GetCom<Text>("collectDesc");
			Text com3 = bind.GetCom<Text>("reclevel");
			Text com4 = bind.GetCom<Text>("unlockLevel");
			Text com5 = bind.GetCom<Text>("countDesc");
			Text com6 = bind.GetCom<Text>("modeDesc");
			com.text = sub.name;
			com4.text = sub.level.ToString();
			com2.text = sub.table.ExtraDescription;
			com6.text = sub.table.Mode;
			com5.text = sub.table.ShowCountDesc;
			com3.text = sub.GetDungeonRecommendLevel();
		}

		// Token: 0x0600C2BC RID: 49852 RVA: 0x002E6F8C File Offset: 0x002E538C
		private void _updateDailyUnitBaseSpritInfo(ActivityDungeonSub sub, ComCommonBind bind)
		{
			Image com = bind.GetCom<Image>("boardIcon");
			Image com2 = bind.GetCom<Image>("typeIcon");
			Image com3 = bind.GetCom<Image>("unitIcon");
			ETCImageLoader.LoadSprite(ref com3, sub.table.SingleTabIcon, true);
			ETCImageLoader.LoadSprite(ref com2, sub.table.ModeIconPath, true);
			ETCImageLoader.LoadSprite(ref com, sub.table.ModeBoardPath, true);
		}

		// Token: 0x0600C2BD RID: 49853 RVA: 0x002E6FFC File Offset: 0x002E53FC
		private void _updateDailyUnitBaseCounterInfo(ActivityDungeonSub sub, ComCommonBind bind)
		{
			ComCommonConsume com = bind.GetCom<ComCommonConsume>("countCosume");
			ComCommonConsume.eCountType eCountType = this._getDailyUnitCountType(sub.dungeonId);
			this._updateDailyUnitBaseCounterSumInfo(eCountType, bind);
			com.SetData(ComCommonConsume.eType.Count, eCountType, sub.dungeonId);
		}

		// Token: 0x0600C2BE RID: 49854 RVA: 0x002E7038 File Offset: 0x002E5438
		private void _updateDailyUnitBaseCounterSumInfo(ComCommonConsume.eCountType type, ComCommonBind bind)
		{
			GameObject gameObject = bind.GetGameObject("counterSplitRoot");
			GameObject gameObject2 = bind.GetGameObject("counterSumRoot");
			gameObject.SetActive(true);
			gameObject2.SetActive(true);
			if (type == ComCommonConsume.eCountType.DeadTower)
			{
				gameObject.SetActive(false);
				gameObject2.SetActive(false);
			}
		}

		// Token: 0x0600C2BF RID: 49855 RVA: 0x002E7080 File Offset: 0x002E5480
		private ComCommonConsume.eCountType _getDailyUnitCountType(int dungeonID)
		{
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(dungeonID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				DungeonTable.eSubType subType = tableItem.SubType;
				switch (subType)
				{
				case DungeonTable.eSubType.S_NIUTOUGUAI:
					return ComCommonConsume.eCountType.MouCount;
				case DungeonTable.eSubType.S_NANBUXIGU:
					return ComCommonConsume.eCountType.NorthCount;
				case DungeonTable.eSubType.S_SIWANGZHITA:
					return ComCommonConsume.eCountType.DeadTower;
				default:
					if (subType == DungeonTable.eSubType.S_FINALTEST_PVE)
					{
						return ComCommonConsume.eCountType.Final_Test;
					}
					break;
				}
			}
			return ComCommonConsume.eCountType.MouCount;
		}

		// Token: 0x0600C2C0 RID: 49856 RVA: 0x002E70DC File Offset: 0x002E54DC
		private void _updateDailyUnitBaseShowHiddenInfo(ActivityDungeonSub sub, ComCommonBind bind)
		{
			GameObject gameObject = bind.GetGameObject("battleTypeRoot");
			GameObject gameObject2 = bind.GetGameObject("countRoot");
			gameObject.SetActive(sub.table.ShowModeFlag);
			gameObject2.SetActive(sub.table.ShowCount);
		}

		// Token: 0x0600C2C1 RID: 49857 RVA: 0x002E7124 File Offset: 0x002E5524
		private void _updateDailyUnitState(ActivityDungeonSub sub, ComCommonBind bind)
		{
			GameObject gameObject = bind.GetGameObject("buttonRoot");
			GameObject gameObject2 = bind.GetGameObject("recLevelRoot");
			GameObject gameObject3 = bind.GetGameObject("finishRoot");
			GameObject gameObject4 = bind.GetGameObject("lockRoot");
			UIGray com = bind.GetCom<UIGray>("goButtonUIGray");
			GameObject gameObject5 = bind.GetGameObject("countParentRoot");
			gameObject.SetActive(false);
			gameObject2.SetActive(false);
			gameObject3.SetActive(false);
			gameObject4.SetActive(false);
			if (com)
			{
				com.enabled = false;
			}
			if (gameObject5)
			{
				gameObject5.CustomActive(false);
			}
			switch (sub.state)
			{
			case eActivityDungeonState.Start:
				gameObject2.SetActive(true);
				if (DataManager<ActivityDungeonDataManager>.GetInstance()._judgeDungeonIDIsRotteneterHell(sub.dungeonTable.ID))
				{
					gameObject.SetActive(true);
					if (gameObject5)
					{
						gameObject5.CustomActive(true);
					}
					if (sub.table.ShowCount && sub.isfinish)
					{
						if (com)
						{
							com.enabled = true;
						}
					}
					else if (com)
					{
						com.enabled = false;
					}
				}
				else if (ActivityDungeonDataManager.IsUltimateChallengeActivity(sub.table))
				{
					gameObject.SetActive(true);
				}
				else if (sub.table.ShowCount && sub.isfinish)
				{
					gameObject3.SetActive(true);
				}
				else
				{
					gameObject.SetActive(true);
				}
				break;
			case eActivityDungeonState.LevelLimit:
			case eActivityDungeonState.None:
				gameObject4.SetActive(true);
				if (DataManager<ActivityDungeonDataManager>.GetInstance()._judgeDungeonIDIsRotteneterHell(sub.dungeonTable.ID))
				{
					gameObject.SetActive(true);
					if (com)
					{
						com.enabled = true;
					}
					if (gameObject5)
					{
						gameObject5.CustomActive(false);
					}
				}
				break;
			case eActivityDungeonState.Prepare:
				Logger.LogErrorFormat("[活动副本] 日常不可能在准备状态 {0}, {1}", new object[]
				{
					sub.id,
					sub.name
				});
				break;
			}
		}

		// Token: 0x0600C2C2 RID: 49858 RVA: 0x002E7348 File Offset: 0x002E5748
		private void _updateDailyUnitRedPoint(ActivityDungeonSub sub, ComCommonBind bind)
		{
			GameObject gameObject = bind.GetGameObject("redpoint");
			gameObject.SetActive(sub.isshowred);
		}

		// Token: 0x0600C2C3 RID: 49859 RVA: 0x002E7370 File Offset: 0x002E5770
		private void _updateRotteneterHellTimes(ActivityDungeonSub sub, ComCommonBind bind)
		{
			SimpleTimer com = bind.GetCom<SimpleTimer>("simpleTimer");
			if (com)
			{
				com.SetCountdown((int)(sub.endtime - DataManager<TimeManager>.GetInstance().GetServerTime()));
				com.StartTimer();
			}
		}

		// Token: 0x0600C2C4 RID: 49860 RVA: 0x002E73B1 File Offset: 0x002E57B1
		private void _loadDailyRewardFrame()
		{
			this.mLastOpenFrame = MissionDailyFrame.Open(delegate(bool isOn)
			{
				this._updateAllKindRedState();
			}, this.mRewardRootContent);
		}

		// Token: 0x0600C2C5 RID: 49861 RVA: 0x002E73D0 File Offset: 0x002E57D0
		private void _initTimeLimitUnit(int dungeonId)
		{
			string prefabPath = this.mBind.GetPrefabPath("timelimitunit");
			List<ActivityDungeonTab> tabByActivityType = DataManager<ActivityDungeonDataManager>.GetInstance().GetTabByActivityType(ActivityDungeonTable.eActivityType.TimeLimit);
			this.mCacheBind.Clear();
			for (int i = 0; i < tabByActivityType.Count; i++)
			{
				for (int j = 0; j < tabByActivityType[i].subs.Count; j++)
				{
					this._loadTimeLimitUnit(tabByActivityType[i].subs[j], prefabPath);
				}
			}
		}

		// Token: 0x0600C2C6 RID: 49862 RVA: 0x002E7458 File Offset: 0x002E5858
		private void _loadTimeLimitUnit(ActivityDungeonSub sub, string timelimitunit)
		{
			ComCommonBind comCommonBind = this.mBind.LoadExtraBind(timelimitunit);
			if (null != comCommonBind)
			{
				Utility.AttachTo(comCommonBind.gameObject, this.mOtherRootContent, false);
				Image com = comCommonBind.GetCom<Image>("icon");
				ETCImageLoader.LoadSprite(ref com, sub.table.ImagePath, true);
				this._add2CacheBind(sub, comCommonBind);
				this._bindTimeLimitUnitEvent(sub, comCommonBind);
				this._updateTimeLimitUnitBaseInfo(sub, comCommonBind);
				this._updateTimeLimitUnitState(sub, comCommonBind);
				this._updateTimeLimitUnitRedPoint(sub, comCommonBind);
			}
		}

		// Token: 0x0600C2C7 RID: 49863 RVA: 0x002E74D8 File Offset: 0x002E58D8
		private void _bindTimeLimitUnitEvent(ActivityDungeonSub sub, ComCommonBind bind)
		{
			Button com = bind.GetCom<Button>("go");
			int dungeonId = sub.dungeonId;
			com.onClick.AddListener(delegate()
			{
				if (sub != null && sub.table != null && !string.IsNullOrEmpty(sub.table.GoLinkInfo))
				{
					if (DataManager<ActivityDungeonDataManager>.GetInstance().IsActivityDungeonBeAttackCityMonster(sub.table))
					{
						DataManager<ActivityDungeonDataManager>.GetInstance().ActivityDungeonFindAttackCityMonster();
					}
					else if (DataManager<ActivityDungeonDataManager>.GetInstance().IsActivityDungeonBeHonorBattleField(sub.table))
					{
						if (DataManager<TeamDataManager>.GetInstance().HasTeam())
						{
							SystemNotifyManager.SysNotifyTextAnimation(TR.Value("Chiji_has_team"), CommonTipsDesc.eShowMode.SI_UNIQUE);
							return;
						}
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiEntranceFrame>(FrameLayer.Middle, null, string.Empty);
					}
					else if (DataManager<ActivityDungeonDataManager>.GetInstance().IsActivityDungeonFairDuelField(sub.table))
					{
						ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
						if (clientSystemTown == null)
						{
							return;
						}
						PkWaitingRoomData userData = new PkWaitingRoomData
						{
							CurrentSceneID = clientSystemTown.CurrentSceneID,
							TargetTownSceneID = 6033,
							SceneSubType = CitySceneTable.eSceneSubType.FairDuelPrepare
						};
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<FairDuelEntranceFrame>(FrameLayer.Middle, userData, string.Empty);
					}
					else
					{
						DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(sub.table.GoLinkInfo, null, false);
						this._onClose();
					}
				}
				else
				{
					this._bindAllButton(dungeonId);
				}
				this.UpdateSubTabRedFlagByClick(sub);
			});
			Text componentInChildren = com.transform.GetComponentInChildren<Text>();
			if (componentInChildren != null)
			{
				if (DataManager<ActivityDungeonDataManager>.GetInstance().IsActivityDungeonBeAttackCityMonster(sub.table))
				{
					componentInChildren.text = TR.Value("limit_activity_button_description_go");
				}
				else
				{
					componentInChildren.text = TR.Value("limit_activity_button_description_enter");
				}
			}
			Toggle com2 = bind.GetCom<Toggle>("toggle");
			com2.group = this.mTimeLimitToggleGroup;
			com2.isOn = (dungeonId == this.GuideDungeonId);
			com2.onValueChanged.AddListener(delegate(bool isOn)
			{
				if (isOn)
				{
					this._openActivityDungeonInfoFrame(dungeonId);
					this.UpdateSubTabRedFlagByClick(sub);
				}
			});
		}

		// Token: 0x0600C2C8 RID: 49864 RVA: 0x002E75C7 File Offset: 0x002E59C7
		private void UpdateSubTabRedFlagByClick(ActivityDungeonSub sub)
		{
			if (sub == null)
			{
				return;
			}
			sub.SetIsAlreadyShowRedFlag();
		}

		// Token: 0x0600C2C9 RID: 49865 RVA: 0x002E75D8 File Offset: 0x002E59D8
		private void _updateTimeLimitUnitBaseInfo(ActivityDungeonSub sub, ComCommonBind bind)
		{
			Text com = bind.GetCom<Text>("name");
			Text com2 = bind.GetCom<Text>("openTime");
			Text com3 = bind.GetCom<Text>("limitLevel");
			com.text = sub.name;
			com2.text = sub.table.OpenTime;
			com3.text = sub.level.ToString();
			if (sub.dungeonId == 55)
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(450, string.Empty, string.Empty);
				if (tableItem != null)
				{
					com3.text = tableItem.Value.ToString();
				}
			}
			else if (sub.dungeonId == 56)
			{
				com3.text = GuildDataManager.GetGuildDungeonActivityPlayerLvLimit().ToString();
			}
			else if (sub.dungeonId == 57)
			{
				com3.text = sub.activityInfo.level.ToString();
			}
			else if (sub.dungeonId == 60)
			{
				SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(638, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					com3.text = tableItem2.Value.ToString();
				}
			}
		}

		// Token: 0x0600C2CA RID: 49866 RVA: 0x002E773C File Offset: 0x002E5B3C
		private void _updateTimeLimitUnitState(ActivityDungeonSub sub, ComCommonBind bind)
		{
			if (bind == null)
			{
				return;
			}
			GameObject gameObject = bind.GetGameObject("levelLimitRoot");
			GameObject gameObject2 = bind.GetGameObject("startRoot");
			GameObject gameObject3 = bind.GetGameObject("notOpenRoot");
			GameObject gameObject4 = bind.GetGameObject("lockRoot");
			GameObject gameObject5 = bind.GetGameObject("otherConditionRoot");
			if (gameObject != null)
			{
				gameObject.SetActive(false);
			}
			if (gameObject2 != null)
			{
				gameObject2.SetActive(false);
			}
			if (gameObject3 != null)
			{
				gameObject3.SetActive(false);
			}
			if (gameObject5 != null)
			{
				gameObject5.SetActive(false);
			}
			if (gameObject4 != null)
			{
				gameObject4.SetActive(false);
			}
			if (sub == null)
			{
				return;
			}
			eActivityDungeonState eActivityDungeonState = sub.state;
			if (sub.dungeonId == 55)
			{
				eActivityDungeonState = ActivityDungeonFrame.Get3v3CrossDungeonActivityState();
			}
			else if (sub.dungeonId == 56)
			{
				eActivityDungeonState = ActivityDungeonFrame.GetGuildDungeonActivityState();
			}
			else if (sub.dungeonId == 20)
			{
				eActivityDungeonState = ActivityDungeonFrame.GetGuildBattleActivityState();
			}
			else if (sub.dungeonId == 58)
			{
				eActivityDungeonState = ActivityDungeonFrame.GetGuildCrossBattleActivityState();
			}
			else if (sub.dungeonId == 60)
			{
				eActivityDungeonState = ActivityDungeonFrame.Get2v2CrossDungeonActivityState();
			}
			switch (eActivityDungeonState)
			{
			case eActivityDungeonState.Start:
				if (gameObject2 != null)
				{
					gameObject2.SetActive(true);
				}
				break;
			case eActivityDungeonState.LevelLimit:
				if (gameObject != null)
				{
					gameObject.SetActive(true);
				}
				if (gameObject4 != null)
				{
					gameObject4.SetActive(true);
				}
				break;
			case eActivityDungeonState.Prepare:
			case eActivityDungeonState.End:
				if (gameObject3 != null)
				{
					gameObject3.SetActive(true);
				}
				break;
			case eActivityDungeonState.None:
				if (gameObject3 != null)
				{
					gameObject3.SetActive(true);
				}
				if (sub.dungeonId == 56)
				{
					this.ShowGuildDungeonBtnSate(bind);
				}
				break;
			}
		}

		// Token: 0x0600C2CB RID: 49867 RVA: 0x002E7924 File Offset: 0x002E5D24
		private void ShowGuildDungeonBtnSate(ComCommonBind bind)
		{
			GameObject gameObject = bind.GetGameObject("notOpenRoot");
			GameObject gameObject2 = bind.GetGameObject("otherConditionRoot");
			if (gameObject2 != null && this.GuildLvNotFit())
			{
				gameObject2.CustomActive(true);
				Text componentInChildren = gameObject2.GetComponentInChildren<Text>();
				string str = string.Format("公会{0}级解锁", GuildDataManager.GetGuildDungeonActivityGuildLvLimit());
				componentInChildren.SafeSetText(str);
				gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600C2CC RID: 49868 RVA: 0x002E7994 File Offset: 0x002E5D94
		private bool GuildLvNotFit()
		{
			bool flag = DataManager<DailyTodoDataManager>.GetInstance().IsGuildDungeonTodayOpened();
			if (flag)
			{
				int guildDungeonActivityGuildLvLimit = GuildDataManager.GetGuildDungeonActivityGuildLvLimit();
				if (DataManager<GuildDataManager>.GetInstance().GetGuildLv() < guildDungeonActivityGuildLvLimit)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600C2CD RID: 49869 RVA: 0x002E79CC File Offset: 0x002E5DCC
		private void _updateTimeLimitUnitRedPoint(ActivityDungeonSub sub, ComCommonBind bind)
		{
			GameObject gameObject = bind.GetGameObject("redpoint");
			gameObject.SetActive(sub.isshowred);
			if (sub.dungeonId == 55)
			{
				ScoreWarStatus scoreWarStatus = DataManager<Pk3v3CrossDataManager>.GetInstance().Get3v3CrossWarStatus();
				if (scoreWarStatus == ScoreWarStatus.SWS_PREPARE || scoreWarStatus == ScoreWarStatus.SWS_BATTLE)
				{
					gameObject.SetActive(true);
					SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(450, string.Empty, string.Empty);
					if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.Value)
					{
						gameObject.SetActive(false);
					}
				}
				else
				{
					gameObject.SetActive(false);
				}
			}
			else if (sub.dungeonId == 56)
			{
				GuildDungeonStatus guildDungeonActivityStatus = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityStatus();
				gameObject.SetActive(GuildDataManager.CheckActivityLimit() && guildDungeonActivityStatus != GuildDungeonStatus.GUILD_DUNGEON_END);
			}
			else if (sub.dungeonId == 20)
			{
				if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_NORMAL || DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_NORMAL)
				{
					EGuildBattleState guildBattleState = DataManager<GuildDataManager>.GetInstance().GetGuildBattleState();
					if (guildBattleState == EGuildBattleState.LuckyDraw || guildBattleState == EGuildBattleState.Firing)
					{
						gameObject.SetActive(true);
					}
					else
					{
						gameObject.SetActive(false);
					}
				}
			}
			else if (sub.dungeonId == 58)
			{
				if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS)
				{
					EGuildBattleState guildBattleState2 = DataManager<GuildDataManager>.GetInstance().GetGuildBattleState();
					if (guildBattleState2 == EGuildBattleState.LuckyDraw || guildBattleState2 == EGuildBattleState.Firing)
					{
						gameObject.SetActive(true);
					}
					else
					{
						gameObject.SetActive(false);
					}
				}
			}
			else if (sub.dungeonId == 60)
			{
				ScoreWar2V2Status scoreWar2V2Status = DataManager<Pk2v2CrossDataManager>.GetInstance().Get2v2CrossWarStatus();
				if (scoreWar2V2Status == ScoreWar2V2Status.SWS_2V2_PREPARE || scoreWar2V2Status == ScoreWar2V2Status.SWS_2V2_BATTLE)
				{
					gameObject.SetActive(true);
					SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(638, string.Empty, string.Empty);
					if (tableItem2 != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem2.Value)
					{
						gameObject.SetActive(false);
					}
				}
				else
				{
					gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x0600C2CE RID: 49870 RVA: 0x002E7BD0 File Offset: 0x002E5FD0
		public void _bindAllButton(int dungeonId)
		{
			ActivityDungeonSub subByDungeonID = DataManager<ActivityDungeonDataManager>.GetInstance().GetSubByDungeonID(dungeonId);
			if (subByDungeonID == null)
			{
				return;
			}
			ActivityDungeonTable table = subByDungeonID.table;
			if (!this._checkCondition(subByDungeonID))
			{
				return;
			}
			if (table.ActivityType == ActivityDungeonTable.eActivityType.Daily)
			{
				ActivityDungeonFrame.mSelectedLastDungeonId = dungeonId;
				ChapterUtility.OpenChapterFrameByID(dungeonId, null);
				subByDungeonID.updateData.Reset();
			}
			else if (table.ActivityType == ActivityDungeonTable.eActivityType.TimeLimit)
			{
				if (subByDungeonID.dungeonId == 0)
				{
					DataManager<ActivityDungeonDataManager>.GetInstance().mIsLimitActivityRedPoint = false;
					DataManager<BudoManager>.GetInstance().TryBeginActive();
					this._onClose();
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RefreshLimitTimeState, null, null, null, null);
				}
				else if (subByDungeonID.dungeonTable.SubType == DungeonTable.eSubType.S_GUILDPK)
				{
					if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
					{
						Singleton<ClientSystemManager>.instance.OpenFrame<GuildMyMainFrame>(FrameLayer.Middle, null, string.Empty);
					}
					else
					{
						Singleton<ClientSystemManager>.instance.OpenFrame<GuildListFrame>(FrameLayer.Middle, null, string.Empty);
					}
					this._onClose();
				}
				else
				{
					Logger.LogErrorFormat("[活动副本] 限时活动错误类型", new object[0]);
				}
			}
			else
			{
				Logger.LogErrorFormat("[活动副本] 限时活动错误类型", new object[0]);
			}
		}

		// Token: 0x0600C2CF RID: 49871 RVA: 0x002E7CF2 File Offset: 0x002E60F2
		private void _openActivityDungeonInfoFrame(int dungeonId)
		{
			ActivityDungeonFrame.mSelectedLastDungeonId = dungeonId;
			Singleton<ClientSystemManager>.instance.OpenFrame<ActivityDungeonInfoFrame>(FrameLayer.Middle, dungeonId, string.Empty);
		}

		// Token: 0x0600C2D0 RID: 49872 RVA: 0x002E7D14 File Offset: 0x002E6114
		private bool _checkCondition(ActivityDungeonSub sub)
		{
			if (sub == null || sub.dungeonTable == null)
			{
				return false;
			}
			if (DataManager<ActivityDungeonDataManager>.GetInstance()._judgeDungeonIDIsRotteneterHell(sub.dungeonTable.ID) && sub.isfinish)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("fallen_hell_num_des"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return false;
			}
			if (sub.state == eActivityDungeonState.Start)
			{
				return true;
			}
			if ((int)DataManager<PlayerBaseData>.GetInstance().Level < sub.level)
			{
				SystemNotifyManager.SystemNotify(1008, string.Empty);
				return false;
			}
			return false;
		}

		// Token: 0x0600C2D1 RID: 49873 RVA: 0x002E7D9F File Offset: 0x002E619F
		private void _onClose()
		{
			this.frameMgr.CloseFrame<ActivityDungeonFrame>(this, false);
		}

		// Token: 0x0600C2D2 RID: 49874 RVA: 0x002E7DB0 File Offset: 0x002E61B0
		private bool TryHideBountyLeagueForIOS(ActivityDungeonSub actSub)
		{
			if (Singleton<IOSFunctionSwitchManager>.GetInstance().IsFunctionClosed(IOSFuncSwitchTable.eType.Bounty_League))
			{
				if (actSub == null)
				{
					return false;
				}
				int dungeonId = actSub.dungeonId;
				DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
				if (tableItem != null && tableItem.SubType == DungeonTable.eSubType.S_MONEYREWARDS_PVP)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600C2D3 RID: 49875 RVA: 0x002E7E0C File Offset: 0x002E620C
		public static eActivityDungeonState Get2v2CrossDungeonActivityState()
		{
			ScoreWar2V2Status scoreWar2V2Status = DataManager<Pk2v2CrossDataManager>.GetInstance().Get2v2CrossWarStatus();
			eActivityDungeonState result;
			if (scoreWar2V2Status == ScoreWar2V2Status.SWS_2V2_PREPARE || scoreWar2V2Status == ScoreWar2V2Status.SWS_2V2_BATTLE)
			{
				result = eActivityDungeonState.Start;
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(638, string.Empty, string.Empty);
				if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.Value)
				{
					result = eActivityDungeonState.LevelLimit;
				}
			}
			else
			{
				result = eActivityDungeonState.None;
			}
			return result;
		}

		// Token: 0x0600C2D4 RID: 49876 RVA: 0x002E7E78 File Offset: 0x002E6278
		public static eActivityDungeonState Get3v3CrossDungeonActivityState()
		{
			ScoreWarStatus scoreWarStatus = DataManager<Pk3v3CrossDataManager>.GetInstance().Get3v3CrossWarStatus();
			eActivityDungeonState result;
			if (scoreWarStatus == ScoreWarStatus.SWS_PREPARE || scoreWarStatus == ScoreWarStatus.SWS_BATTLE)
			{
				result = eActivityDungeonState.Start;
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(450, string.Empty, string.Empty);
				if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.Value)
				{
					result = eActivityDungeonState.LevelLimit;
				}
			}
			else
			{
				result = eActivityDungeonState.None;
			}
			return result;
		}

		// Token: 0x0600C2D5 RID: 49877 RVA: 0x002E7EE4 File Offset: 0x002E62E4
		public static eActivityDungeonState GetGuildDungeonActivityState()
		{
			GuildDungeonStatus guildDungeonActivityStatus = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityStatus();
			eActivityDungeonState result;
			if (guildDungeonActivityStatus == GuildDungeonStatus.GUILD_DUNGEON_PREPARE || guildDungeonActivityStatus == GuildDungeonStatus.GUILD_DUNGEON_START || guildDungeonActivityStatus == GuildDungeonStatus.GUILD_DUNGEON_REWARD)
			{
				result = eActivityDungeonState.Start;
				if ((int)DataManager<PlayerBaseData>.GetInstance().Level < GuildDataManager.GetGuildDungeonActivityPlayerLvLimit())
				{
					result = eActivityDungeonState.LevelLimit;
				}
			}
			else
			{
				result = eActivityDungeonState.None;
			}
			return result;
		}

		// Token: 0x0600C2D6 RID: 49878 RVA: 0x002E7F34 File Offset: 0x002E6334
		public static eActivityDungeonState GetGuildBattleActivityState()
		{
			eActivityDungeonState result = eActivityDungeonState.None;
			if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_NORMAL || DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_NORMAL)
			{
				EGuildBattleState guildBattleState = DataManager<GuildDataManager>.GetInstance().GetGuildBattleState();
				if (guildBattleState == EGuildBattleState.LuckyDraw || guildBattleState == EGuildBattleState.Firing)
				{
					result = eActivityDungeonState.Start;
				}
				else
				{
					result = eActivityDungeonState.None;
				}
			}
			return result;
		}

		// Token: 0x0600C2D7 RID: 49879 RVA: 0x002E7F88 File Offset: 0x002E6388
		public static eActivityDungeonState GetGuildCrossBattleActivityState()
		{
			eActivityDungeonState result = eActivityDungeonState.None;
			if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS)
			{
				EGuildBattleState guildBattleState = DataManager<GuildDataManager>.GetInstance().GetGuildBattleState();
				if (guildBattleState == EGuildBattleState.LuckyDraw || guildBattleState == EGuildBattleState.Firing)
				{
					result = eActivityDungeonState.Start;
				}
				else
				{
					result = eActivityDungeonState.None;
				}
			}
			return result;
		}

		// Token: 0x0600C2D8 RID: 49880 RVA: 0x002E7FCA File Offset: 0x002E63CA
		private bool _IsSpecialMode(ActivityDungeonSub sub)
		{
			return sub.activityId == BudoManager.ActiveID && (int)DataManager<PlayerBaseData>.GetInstance().Level >= sub.level;
		}

		// Token: 0x04006E2B RID: 28203
		private const int kAllDailyDungeonId = 2147483647;

		// Token: 0x04006E2C RID: 28204
		private static int mSelectedLastDungeonId = -1;

		// Token: 0x04006E2D RID: 28205
		private IClientFrame mLastOpenFrame;

		// Token: 0x04006E2E RID: 28206
		private string mLastSelectFrameName = string.Empty;

		// Token: 0x04006E2F RID: 28207
		private ActiveParams data;

		// Token: 0x04006E30 RID: 28208
		private ActivityDungeonTable.eActivityType mLastSwitchKindType;

		// Token: 0x04006E31 RID: 28209
		private ActivityDungeonTable.eActivityType mCurSwitchKindType;

		// Token: 0x04006E32 RID: 28210
		private List<ActivityDungeonFrame.ActivityDungeonSubWithBind> mCacheBind = new List<ActivityDungeonFrame.ActivityDungeonSubWithBind>();

		// Token: 0x04006E33 RID: 28211
		private List<ActivityDungeonFrame.ActivityDungeonTabWithBind> mCacheTabBind = new List<ActivityDungeonFrame.ActivityDungeonTabWithBind>();

		// Token: 0x04006E34 RID: 28212
		private int mGuideDungeonId = -1;

		// Token: 0x04006E35 RID: 28213
		public const int pk3v3CrossDungeonID = 55;

		// Token: 0x04006E36 RID: 28214
		public const int guildDungeonID = 56;

		// Token: 0x04006E37 RID: 28215
		public const int chijiDungeonID = 57;

		// Token: 0x04006E38 RID: 28216
		public const int guildBattleID = 20;

		// Token: 0x04006E39 RID: 28217
		public const int guildCrossBattleID = 58;

		// Token: 0x04006E3A RID: 28218
		public const int pk2v2CrossDungeonID = 60;

		// Token: 0x04006E3B RID: 28219
		private Text mName;

		// Token: 0x04006E3C RID: 28220
		private Button mHelp;

		// Token: 0x04006E3D RID: 28221
		private Button mClose;

		// Token: 0x04006E3E RID: 28222
		private GameObject mTabroot;

		// Token: 0x04006E3F RID: 28223
		private ToggleGroup mTabrootgroup;

		// Token: 0x04006E40 RID: 28224
		private ToggleGroup mGridToggleGroup;

		// Token: 0x04006E41 RID: 28225
		private GameObject mGirldRoot;

		// Token: 0x04006E42 RID: 28226
		private GameObject mDailyRoot;

		// Token: 0x04006E43 RID: 28227
		private GameObject mOtherRoot;

		// Token: 0x04006E44 RID: 28228
		private GameObject mOtherRootContent;

		// Token: 0x04006E45 RID: 28229
		private GameObject mRewardRootContent;

		// Token: 0x04006E46 RID: 28230
		private Toggle mDailyKindToggle;

		// Token: 0x04006E47 RID: 28231
		private Toggle mTimeLimitKindToggle;

		// Token: 0x04006E48 RID: 28232
		private Toggle mRewardKindToggle;

		// Token: 0x04006E49 RID: 28233
		private Toggle mAllDailyTab;

		// Token: 0x04006E4A RID: 28234
		private ToggleGroup mTimeLimitToggleGroup;

		// Token: 0x04006E4B RID: 28235
		private GameObject mAllDialyTabRedPoint;

		// Token: 0x04006E4C RID: 28236
		private GameObject mDailyKindRedPoint;

		// Token: 0x04006E4D RID: 28237
		private GameObject mTimeLimitKindRedPoint;

		// Token: 0x04006E4E RID: 28238
		private GameObject mRewardKindRedPoint;

		// Token: 0x02001397 RID: 5015
		private class ActivityDungeonSubWithBind
		{
			// Token: 0x17001BD7 RID: 7127
			// (get) Token: 0x0600C2DC RID: 49884 RVA: 0x002E800E File Offset: 0x002E640E
			// (set) Token: 0x0600C2DD RID: 49885 RVA: 0x002E8016 File Offset: 0x002E6416
			public ActivityDungeonSub sub { get; set; }

			// Token: 0x17001BD8 RID: 7128
			// (get) Token: 0x0600C2DE RID: 49886 RVA: 0x002E801F File Offset: 0x002E641F
			// (set) Token: 0x0600C2DF RID: 49887 RVA: 0x002E8027 File Offset: 0x002E6427
			public ComCommonBind bind { get; set; }
		}

		// Token: 0x02001398 RID: 5016
		private class ActivityDungeonTabWithBind
		{
			// Token: 0x17001BD9 RID: 7129
			// (get) Token: 0x0600C2E1 RID: 49889 RVA: 0x002E8038 File Offset: 0x002E6438
			// (set) Token: 0x0600C2E2 RID: 49890 RVA: 0x002E8040 File Offset: 0x002E6440
			public ActivityDungeonTab tab { get; set; }

			// Token: 0x17001BDA RID: 7130
			// (get) Token: 0x0600C2E3 RID: 49891 RVA: 0x002E8049 File Offset: 0x002E6449
			// (set) Token: 0x0600C2E4 RID: 49892 RVA: 0x002E8051 File Offset: 0x002E6451
			public ComCommonBind bind { get; set; }
		}
	}
}
