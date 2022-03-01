using System;
using System.Collections.Generic;
using Protocol;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001913 RID: 6419
	public class LimitTimeActivityFrame : ClientFrame
	{
		// Token: 0x0600F9E7 RID: 63975 RVA: 0x004461CA File Offset: 0x004445CA
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/ActivityCombineFrame";
		}

		// Token: 0x0600F9E8 RID: 63976 RVA: 0x004461D1 File Offset: 0x004445D1
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600F9E9 RID: 63977 RVA: 0x004461D4 File Offset: 0x004445D4
		protected override void _OnOpenFrame()
		{
			DataManager<ZillionaireGameDataManager>.GetInstance().OnSendWorldMonopolyCoinReq();
			DataManager<ZillionaireGameDataManager>.GetInstance().OnSendWorldMonopolyStatusReq();
			base._OnOpenFrame();
			DataManager<ActivityManager>.GetInstance().CheckCourtesyPrivilegesActivityIsExpire();
			this._InitView();
			this._BindEvents();
			DataManager<ActivityDataManager>.GetInstance().RequestMallGiftData();
			DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq(ActivityLimitTimeFactory.EActivityType.OAT_SUMMER_WEEKLY_VACATION, ActivityLimitTimeFactory.EActivityCounterType.OAT_SUMMER_WEEKLY_VACATION);
			DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq(ActivityLimitTimeFactory.EActivityType.OAT_DAILYCHALLENGEACTIVITY, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_WEEKLY_ACCEPT_TASK);
			if (this.userData != null)
			{
				int activityId = (int)this.userData;
				int parentId = this._GetParentId(activityId);
				int subId = this._GetSubId(parentId, activityId);
				this.mView.GoToToggleFromID(parentId, subId);
			}
		}

		// Token: 0x0600F9EA RID: 63978 RVA: 0x0044627C File Offset: 0x0044467C
		public static void OpenLinkFrame(string strParam)
		{
			string[] array = strParam.Split(new char[]
			{
				'|'
			});
			int num = -1;
			int.TryParse(array[0], out num);
			if (num != -1)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<LimitTimeActivityFrame>(FrameLayer.Middle, num, string.Empty);
			}
		}

		// Token: 0x0600F9EB RID: 63979 RVA: 0x004462C8 File Offset: 0x004446C8
		public void OpenFrameByActivityId(uint activityId)
		{
			int parentId = this._GetParentId((int)activityId);
			int subId = this._GetSubId(parentId, (int)activityId);
			if (this.mView != null)
			{
				this.mView.GoToToggleFromID(parentId, subId);
			}
		}

		// Token: 0x0600F9EC RID: 63980 RVA: 0x00446304 File Offset: 0x00444704
		protected override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			if (this.mActivityToggleData != null)
			{
				for (int i = 0; i < this.mActivityToggleData.Count; i++)
				{
					for (int j = 0; j < this.mActivityToggleData[i].Count; j++)
					{
						IActivity activity = DataManager<ActivityManager>.GetInstance().GetActivity(this.mActivityToggleData[i][j]);
						if (activity != null)
						{
							activity.Close();
						}
					}
				}
				this.mActivityToggleData.Clear();
			}
			if (this.mToggleFilterIds != null)
			{
				this.mToggleFilterIds.Clear();
			}
			this._UnBindEvents();
		}

		// Token: 0x0600F9ED RID: 63981 RVA: 0x004463B0 File Offset: 0x004447B0
		private void _InitView()
		{
			if (this.mBind != null && this.mView != null)
			{
				this.mView.Init(this._GetParentToggleData(), this._InitSubToggleDatas(), new ComTwoLevelToggleGroup.OnValueChanged(this._OnParentToggleValueChanged), new ComTwoLevelToggleGroup.OnValueChanged(this._OnSubToggleValueChanged));
				this.mCurrentSelectParentId = 0;
				this.mView.OnButtonCloseClick = new UnityAction(this._OnCloseClick);
			}
		}

		// Token: 0x0600F9EE RID: 63982 RVA: 0x0044642C File Offset: 0x0044482C
		private void _OnCloseClick()
		{
			base.Close(false);
		}

		// Token: 0x0600F9EF RID: 63983 RVA: 0x00446435 File Offset: 0x00444835
		private void _OnParentToggleValueChanged(int id, bool value)
		{
			if (value)
			{
				this.mCurrentSelectParentId = id;
			}
		}

		// Token: 0x0600F9F0 RID: 63984 RVA: 0x00446444 File Offset: 0x00444844
		private void _OnSubToggleValueChanged(int id, bool value)
		{
			if (value && this.mActivityToggleData != null && this.mCurrentSelectParentId >= 0 && this.mCurrentSelectParentId < this.mActivityToggleData.Count && this.mView != null)
			{
				DataManager<ActivityManager>.GetInstance().HideActivity(this.mSelectActivityId);
				if (id < 0 || id >= this.mActivityToggleData[this.mCurrentSelectParentId].Count)
				{
					return;
				}
				DataManager<ActivityManager>.GetInstance().ShowActivity(this.mActivityToggleData[this.mCurrentSelectParentId][id], this.mView.FrameRoot);
				this.mSelectActivityId = this.mActivityToggleData[this.mCurrentSelectParentId][id];
			}
		}

		// Token: 0x0600F9F1 RID: 63985 RVA: 0x00446512 File Offset: 0x00444912
		private void OnButtonClose()
		{
			base.Close(false);
		}

		// Token: 0x0600F9F2 RID: 63986 RVA: 0x0044651C File Offset: 0x0044491C
		private void _BindEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeTaskUpdate, new ClientEventSystem.UIEventHandler(this._OnTaskStateChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityStateChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeToggleChange, new ClientEventSystem.UIEventHandler(this._OnActivityLimitTimeToggleChange));
		}

		// Token: 0x0600F9F3 RID: 63987 RVA: 0x0044657C File Offset: 0x0044497C
		private void _UnBindEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeTaskUpdate, new ClientEventSystem.UIEventHandler(this._OnTaskStateChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityStateChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeToggleChange, new ClientEventSystem.UIEventHandler(this._OnActivityLimitTimeToggleChange));
		}

		// Token: 0x0600F9F4 RID: 63988 RVA: 0x004465DC File Offset: 0x004449DC
		private void _OnTaskStateChanged(UIEvent uiEvent)
		{
			LimitTimeActivityTaskUpdateData limitTimeActivityTaskUpdateData = (LimitTimeActivityTaskUpdateData)uiEvent.Param1;
			if (limitTimeActivityTaskUpdateData == null)
			{
				return;
			}
			IActivity activity = DataManager<ActivityManager>.GetInstance().GetActivity((uint)limitTimeActivityTaskUpdateData.ActivityId);
			if (this.mToggleFilterIds != null && activity != null && this.mView != null)
			{
				int num = this._GetParentId((int)activity.GetId());
				if (num >= 0 && num < this.mToggleFilterIds.Count)
				{
					int num2 = this._GetSubId(num, (int)activity.GetId());
					if (num2 != -1)
					{
						this.mView.SetSubRedPoint(num, num2, activity.IsHaveRedPoint());
						this.mView.SetParentRedPoint(num, DataManager<ActivityManager>.GetInstance().IsFilterHaveRedPoint(this.mToggleFilterIds[num]));
					}
				}
			}
		}

		// Token: 0x0600F9F5 RID: 63989 RVA: 0x004466A0 File Offset: 0x00444AA0
		private void _OnActivityLimitTimeToggleChange(UIEvent uiEvent)
		{
			int activityId = (int)uiEvent.Param1;
			int parentId = this._GetParentId(activityId);
			int subId = this._GetSubId(parentId, activityId);
			this.mView.GoToToggleFromID(parentId, subId);
		}

		// Token: 0x0600F9F6 RID: 63990 RVA: 0x004466D8 File Offset: 0x00444AD8
		private void _OnActivityStateChanged(UIEvent uiEvent)
		{
			IActivity activity = (IActivity)uiEvent.Param1;
			if (activity != null && this.mView != null)
			{
				int id = (int)activity.GetId();
				int num = this._GetParentId(id);
				if (num != -1)
				{
					int num2 = this._GetSubId(num, id);
					if (activity.GetState() == OpActivityState.OAS_END)
					{
						if (this.mActivityToggleData != null && num >= 0 && num < this.mActivityToggleData.Count && num2 < this.mActivityToggleData[num].Count)
						{
							this.mActivityToggleData[num].RemoveAt(num2);
							this.mView.RemoveSubToggle((uint)num, (uint)num2);
							if (this.mActivityToggleData[num].Count == 0)
							{
								this.mActivityToggleData.RemoveAt(num);
								this.mToggleFilterIds.RemoveAt(num);
								this.mView.RemoveParentToggle(num);
							}
						}
					}
					else
					{
						this.mView.SetSubRedPoint(num, num2, activity.IsHaveRedPoint());
						this.mView.SetParentRedPoint(num, DataManager<ActivityManager>.GetInstance().IsFilterHaveRedPoint(this.mToggleFilterIds[num]));
					}
				}
				else if (activity.GetState() == OpActivityState.OAS_IN || activity.GetState() == OpActivityState.OAS_PREPARE)
				{
					int filterIdByActivityId = DataManager<ActivityDataManager>.GetInstance().GetFilterIdByActivityId(id);
					int activityOrderId = DataManager<ActivityManager>.GetInstance().GetActivityOrderId(filterIdByActivityId, id);
					int num3 = this._GetIdByFilterId(filterIdByActivityId);
					if (num3 == -1)
					{
						num3 = this._GetParentInsertPosition(filterIdByActivityId);
						if (this.mCurrentSelectParentId >= num3)
						{
							this.mCurrentSelectParentId++;
						}
						this.mToggleFilterIds.Insert(num3, filterIdByActivityId);
						this.mActivityToggleData.Insert(num3, new List<uint>());
						this.mActivityToggleData[num3].Add((uint)id);
						List<ITwoLevelToggleData> subToggleDatas = new List<ITwoLevelToggleData>();
						ActivityTabInfo activityTabInfo = DataManager<ActivityDataManager>.GetInstance().GetActivityTabInfo(filterIdByActivityId);
						if (activityTabInfo != null)
						{
							ITwoLevelToggleData data = new LimitTimeToggleData(activityTabInfo.name, activity.IsHaveRedPoint(), null);
							this.mView.AddTopToggle(subToggleDatas, data, num3);
						}
					}
					else if (num3 >= 0 && num3 < this.mActivityToggleData.Count)
					{
						this.mActivityToggleData[num3].Insert(activityOrderId, (uint)id);
					}
					this.mView.AddSubToggle((uint)num3, new LimitTimeToggleData(activity), activityOrderId);
				}
			}
		}

		// Token: 0x0600F9F7 RID: 63991 RVA: 0x00446930 File Offset: 0x00444D30
		private int _GetParentInsertPosition(int filterId)
		{
			for (int i = 0; i < this.mToggleFilterIds.Count; i++)
			{
				if (filterId < this.mToggleFilterIds[i])
				{
					return i;
				}
			}
			return this.mActivityToggleData.Count;
		}

		// Token: 0x0600F9F8 RID: 63992 RVA: 0x00446978 File Offset: 0x00444D78
		private int _GetIdByFilterId(int filterId)
		{
			for (int i = 0; i < this.mToggleFilterIds.Count; i++)
			{
				if (this.mToggleFilterIds[i] == filterId)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600F9F9 RID: 63993 RVA: 0x004469B8 File Offset: 0x00444DB8
		private List<ITwoLevelToggleData> _GetParentToggleData()
		{
			Dictionary<int, List<IActivity>> allActivities = DataManager<ActivityManager>.GetInstance().GetAllActivities();
			List<ITwoLevelToggleData> list = new List<ITwoLevelToggleData>(allActivities.Count);
			foreach (KeyValuePair<int, List<IActivity>> keyValuePair in allActivities)
			{
				if (keyValuePair.Value.Count > 0)
				{
					ActivityTabInfo activityTabInfo = DataManager<ActivityDataManager>.GetInstance().GetActivityTabInfo(keyValuePair.Key);
					if (activityTabInfo == null)
					{
						Logger.LogError("在活动页签表中找不到id为" + keyValuePair.Key + "的数据!");
					}
					else
					{
						string name = activityTabInfo.name;
						bool isShowRedPoint = false;
						bool flag = false;
						for (int i = 0; i < keyValuePair.Value.Count; i++)
						{
							if (keyValuePair.Value[i].GetState() == OpActivityState.OAS_IN || keyValuePair.Value[i].GetState() == OpActivityState.OAS_PREPARE)
							{
								flag = true;
								if (keyValuePair.Value[i].IsHaveRedPoint())
								{
									isShowRedPoint = true;
									break;
								}
							}
						}
						if (flag)
						{
							list.Add(new LimitTimeToggleData(name, isShowRedPoint, null));
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600F9FA RID: 63994 RVA: 0x00446B24 File Offset: 0x00444F24
		private List<List<ITwoLevelToggleData>> _InitSubToggleDatas()
		{
			Dictionary<int, List<IActivity>> allActivities = DataManager<ActivityManager>.GetInstance().GetAllActivities();
			List<List<ITwoLevelToggleData>> list = new List<List<ITwoLevelToggleData>>(allActivities.Count);
			int num = 0;
			foreach (KeyValuePair<int, List<IActivity>> keyValuePair in allActivities)
			{
				if (keyValuePair.Value.Count > 0)
				{
					bool flag = false;
					for (int i = 0; i < keyValuePair.Value.Count; i++)
					{
						if (keyValuePair.Value[i].GetState() == OpActivityState.OAS_IN || keyValuePair.Value[i].GetState() == OpActivityState.OAS_PREPARE)
						{
							if (!flag)
							{
								list.Add(new List<ITwoLevelToggleData>());
								this.mActivityToggleData.Add(new List<uint>());
								this.mToggleFilterIds.Add(keyValuePair.Key);
								flag = true;
							}
							int id = (int)keyValuePair.Value[i].GetId();
							int filterIdByActivityId = DataManager<ActivityDataManager>.GetInstance().GetFilterIdByActivityId(id);
							int activityOrderId = DataManager<ActivityManager>.GetInstance().GetActivityOrderId(filterIdByActivityId, id);
							LimitTimeToggleData item = new LimitTimeToggleData(keyValuePair.Value[i]);
							if (this.mActivityToggleData[num].Count == 0)
							{
								list[num].Add(item);
								this.mActivityToggleData[num].Add(keyValuePair.Value[i].GetId());
							}
							else
							{
								for (int j = 0; j < this.mActivityToggleData[num].Count; j++)
								{
									int activityOrderId2 = DataManager<ActivityManager>.GetInstance().GetActivityOrderId(filterIdByActivityId, (int)this.mActivityToggleData[num][j]);
									if (activityOrderId2 > activityOrderId)
									{
										list[num].Insert(j, item);
										this.mActivityToggleData[num].Insert(j, keyValuePair.Value[i].GetId());
										break;
									}
									if (j == this.mActivityToggleData[num].Count - 1)
									{
										list[num].Add(item);
										this.mActivityToggleData[num].Add(keyValuePair.Value[i].GetId());
										break;
									}
								}
							}
						}
					}
					if (flag)
					{
						num++;
					}
				}
			}
			return list;
		}

		// Token: 0x0600F9FB RID: 63995 RVA: 0x00446DBC File Offset: 0x004451BC
		private int _GetParentId(int activityId)
		{
			if (this.mActivityToggleData != null)
			{
				for (int i = 0; i < this.mActivityToggleData.Count; i++)
				{
					for (int j = 0; j < this.mActivityToggleData[i].Count; j++)
					{
						if ((ulong)this.mActivityToggleData[i][j] == (ulong)((long)activityId))
						{
							return i;
						}
					}
				}
			}
			return -1;
		}

		// Token: 0x0600F9FC RID: 63996 RVA: 0x00446E30 File Offset: 0x00445230
		private int _GetSubId(int parentId, int activityId)
		{
			if (parentId >= 0 && this.mActivityToggleData != null && parentId < this.mActivityToggleData.Count)
			{
				for (int i = 0; i < this.mActivityToggleData[parentId].Count; i++)
				{
					if ((ulong)this.mActivityToggleData[parentId][i] == (ulong)((long)activityId))
					{
						return i;
					}
				}
			}
			return -1;
		}

		// Token: 0x0600F9FD RID: 63997 RVA: 0x00446E9F File Offset: 0x0044529F
		protected override void _bindExUI()
		{
			this.mView = this.mBind.GetCom<LimitTimeActivityView>("LimitTimeActivityFrame");
		}

		// Token: 0x0600F9FE RID: 63998 RVA: 0x00446EB7 File Offset: 0x004452B7
		protected override void _unbindExUI()
		{
			if (this.mView != null)
			{
				this.mView.Dispose();
			}
			this.mView = null;
		}

		// Token: 0x04009C16 RID: 39958
		private const string prefabPath = "UIFlatten/Prefabs/OperateActivity/ActivityCombineFrame";

		// Token: 0x04009C17 RID: 39959
		private readonly List<List<uint>> mActivityToggleData = new List<List<uint>>();

		// Token: 0x04009C18 RID: 39960
		private readonly List<int> mToggleFilterIds = new List<int>();

		// Token: 0x04009C19 RID: 39961
		private int mCurrentSelectParentId;

		// Token: 0x04009C1A RID: 39962
		private uint mSelectActivityId;

		// Token: 0x04009C1B RID: 39963
		private LimitTimeActivityView mView;

		// Token: 0x02001914 RID: 6420
		private struct ToggleIndex
		{
			// Token: 0x0600F9FF RID: 63999 RVA: 0x00446EDC File Offset: 0x004452DC
			public ToggleIndex(int parentId, int subId)
			{
				this.ParentId = parentId;
				this.SubId = subId;
			}

			// Token: 0x04009C1C RID: 39964
			public int ParentId;

			// Token: 0x04009C1D RID: 39965
			public int SubId;
		}
	}
}
