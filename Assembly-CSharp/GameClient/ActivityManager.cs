using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020011BF RID: 4543
	public sealed class ActivityManager : DataManager<ActivityManager>
	{
		// Token: 0x0600AE8B RID: 44683 RVA: 0x00261240 File Offset: 0x0025F640
		public VanityBuffBonusModel GetVanityBuffBonusModel()
		{
			return this.vanityBBModel;
		}

		// Token: 0x0600AE8C RID: 44684 RVA: 0x00261248 File Offset: 0x0025F648
		public int GetActivityOrderId(int filterId, int activityId)
		{
			int num = 0;
			ActivityTabInfo activityTabInfo = DataManager<ActivityDataManager>.GetInstance().GetActivityTabInfo(filterId);
			if (activityTabInfo != null)
			{
				for (int i = 0; i < activityTabInfo.actIds.Length; i++)
				{
					if (this.mActivities.ContainsKey(activityTabInfo.actIds[i]) && this.mActivities[activityTabInfo.actIds[i]].GetState() == OpActivityState.OAS_IN)
					{
						if ((ulong)activityTabInfo.actIds[i] == (ulong)((long)activityId))
						{
							break;
						}
						num++;
					}
				}
				return num;
			}
			return 0;
		}

		// Token: 0x0600AE8D RID: 44685 RVA: 0x002612D9 File Offset: 0x0025F6D9
		public IActivity GetActivity(uint id)
		{
			if (this.mActivities.ContainsKey(id))
			{
				return this.mActivities[id];
			}
			return null;
		}

		// Token: 0x0600AE8E RID: 44686 RVA: 0x002612FA File Offset: 0x0025F6FA
		public Dictionary<int, List<IActivity>> GetAllActivities()
		{
			return this.mActivitiesByFilterId;
		}

		// Token: 0x0600AE8F RID: 44687 RVA: 0x00261304 File Offset: 0x0025F704
		public bool IsHaveAnyActivity()
		{
			if (!Utility.IsUnLockFunc(63))
			{
				return false;
			}
			foreach (IActivity activity in this.mActivities.Values)
			{
				if (activity.GetState() == OpActivityState.OAS_IN)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600AE90 RID: 44688 RVA: 0x00261384 File Offset: 0x0025F784
		public bool IsActivityOpen(int id)
		{
			return this.mActivities.ContainsKey((uint)id) && this.mActivities[(uint)id].GetState() == OpActivityState.OAS_IN;
		}

		// Token: 0x0600AE91 RID: 44689 RVA: 0x002613B4 File Offset: 0x0025F7B4
		public bool IsHaveAnyRedPoint()
		{
			foreach (IActivity activity in this.mActivities.Values)
			{
				if (activity.GetState() == OpActivityState.OAS_IN && activity.IsHaveRedPoint())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600AE92 RID: 44690 RVA: 0x00261430 File Offset: 0x0025F830
		public bool IsFilterHaveRedPoint(int filterId)
		{
			if (this.mActivitiesByFilterId.ContainsKey(filterId))
			{
				foreach (IActivity activity in this.mActivitiesByFilterId[filterId])
				{
					if (activity.GetState() == OpActivityState.OAS_IN && activity.IsHaveRedPoint())
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x0600AE93 RID: 44691 RVA: 0x002614C0 File Offset: 0x0025F8C0
		public bool IsHaveRedPoint(uint activityId)
		{
			return this.mActivities.ContainsKey(activityId) && this.mActivities[activityId].IsHaveRedPoint() && this.mActivities[activityId].GetState() == OpActivityState.OAS_IN;
		}

		// Token: 0x0600AE94 RID: 44692 RVA: 0x0026150D File Offset: 0x0025F90D
		public void ShowActivity(uint activityId, Transform root)
		{
			if (!this.mActivities.ContainsKey(activityId))
			{
				this._AddActivity(activityId);
			}
			if (this.mActivities.ContainsKey(activityId))
			{
				this.mActivities[activityId].Show(root);
			}
		}

		// Token: 0x0600AE95 RID: 44693 RVA: 0x0026154A File Offset: 0x0025F94A
		public void HideActivity(uint activityId)
		{
			if (this.mActivities.ContainsKey(activityId))
			{
				this.mActivities[activityId].Hide();
			}
		}

		// Token: 0x0600AE96 RID: 44694 RVA: 0x0026156E File Offset: 0x0025F96E
		public override void Initialize()
		{
			this._BindEvents();
		}

		// Token: 0x0600AE97 RID: 44695 RVA: 0x00261578 File Offset: 0x0025F978
		public override void Clear()
		{
			this._UnBindEvents();
			if (this.mActivities != null)
			{
				foreach (IActivity activity in this.mActivities.Values)
				{
					activity.Dispose();
				}
				this.mActivities.Clear();
			}
			if (this.mActivitiesByFilterId != null)
			{
				this.mActivitiesByFilterId.Clear();
			}
			this.vanityBBModel = null;
		}

		// Token: 0x0600AE98 RID: 44696 RVA: 0x00261614 File Offset: 0x0025FA14
		public void RequestGiftDatas()
		{
			DataManager<ActivityDataManager>.GetInstance().RequestMallGiftData();
		}

		// Token: 0x0600AE99 RID: 44697 RVA: 0x00261620 File Offset: 0x0025FA20
		private void _BindEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeDataUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeTaskDataUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityTaskUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityTabsInfoUpdate, new ClientEventSystem.UIEventHandler(this._OnTabsInfoUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.VanityBonusBuffPos, new ClientEventSystem.UIEventHandler(this._onVanityBonusBuffPos));
		}

		// Token: 0x0600AE9A RID: 44698 RVA: 0x0026169C File Offset: 0x0025FA9C
		private void _UnBindEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeDataUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeTaskDataUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityTaskUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityTabsInfoUpdate, new ClientEventSystem.UIEventHandler(this._OnTabsInfoUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.VanityBonusBuffPos, new ClientEventSystem.UIEventHandler(this._onVanityBonusBuffPos));
		}

		// Token: 0x0600AE9B RID: 44699 RVA: 0x00261718 File Offset: 0x0025FB18
		private void _onVanityBonusBuffPos(UIEvent ui)
		{
			Vector3 pos = (Vector3)ui.Param1;
			BuffTable buffTable = (BuffTable)ui.Param2;
			this.vanityBBModel = new VanityBuffBonusModel();
			this.vanityBBModel.pos = pos;
			this.vanityBBModel.iconPath = buffTable.Icon;
			this.vanityBBModel.des = buffTable.Name;
		}

		// Token: 0x0600AE9C RID: 44700 RVA: 0x00261778 File Offset: 0x0025FB78
		private void _OnTabsInfoUpdate(UIEvent uiEvent)
		{
			Dictionary<int, ActivityTabInfo> tabInfos = DataManager<ActivityDataManager>.GetInstance().GetTabInfos();
			foreach (KeyValuePair<int, ActivityTabInfo> keyValuePair in tabInfos)
			{
				ActivityTabInfo value = keyValuePair.Value;
				if (value != null && !this.mActivitiesByFilterId.ContainsKey(keyValuePair.Key))
				{
					this.mActivitiesByFilterId.Add(keyValuePair.Key, new List<IActivity>());
				}
				this.mActivitiesByFilterId[keyValuePair.Key].Clear();
				for (int i = 0; i < value.actIds.Length; i++)
				{
					if (this.mActivities.ContainsKey(value.actIds[i]))
					{
						if (!this.mActivitiesByFilterId[keyValuePair.Key].Contains(this.mActivities[value.actIds[i]]))
						{
							if (this.CheckFlyingGiftPackActivityTabIsShow(value.actIds[i]))
							{
								if (this.CheckConsumeRebateActivityTabIsShow(value.actIds[i]))
								{
									if (this.CheckSpringFestivalRedEnvelopeRainActivityTabIsShow(value.actIds[i]))
									{
										this.mActivitiesByFilterId[keyValuePair.Key].Add(this.mActivities[value.actIds[i]]);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600AE9D RID: 44701 RVA: 0x00261914 File Offset: 0x0025FD14
		private void _OnActivityUpdate(UIEvent uiEvent)
		{
			uint num = (uint)uiEvent.Param1;
			IActivity activity = null;
			if (this.mActivities.ContainsKey(num))
			{
				activity = this.mActivities[num];
				this.mActivities[num].UpdateData();
				if (this.mActivities[num].GetState() == OpActivityState.OAS_END)
				{
					this.mActivities[num].Close();
					this.mActivities.Remove(num);
				}
			}
			else
			{
				this._AddActivity(num);
				if (this.mActivities.ContainsKey(num))
				{
					activity = this.mActivities[num];
				}
			}
			if (activity != null)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeUpdate, activity, null, null, null);
			}
		}

		// Token: 0x0600AE9E RID: 44702 RVA: 0x002619D8 File Offset: 0x0025FDD8
		private void _OnActivityTaskUpdate(UIEvent uiEvent)
		{
			LimitTimeActivityTaskUpdateData limitTimeActivityTaskUpdateData = (LimitTimeActivityTaskUpdateData)uiEvent.Param1;
			if (limitTimeActivityTaskUpdateData == null)
			{
				return;
			}
			if (this.mActivities.ContainsKey((uint)limitTimeActivityTaskUpdateData.ActivityId))
			{
				this.mActivities[(uint)limitTimeActivityTaskUpdateData.ActivityId].UpdateTask(limitTimeActivityTaskUpdateData.TaskId);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeTaskUpdate, limitTimeActivityTaskUpdateData, null, null, null);
			}
		}

		// Token: 0x0600AE9F RID: 44703 RVA: 0x00261A40 File Offset: 0x0025FE40
		private void _AddActivity(uint activityId)
		{
			IActivity activity = ActivityLimitTimeFactory.Create(activityId);
			if (activity != null)
			{
				this.mActivities.Add(activityId, activity);
				int filterIdByActivityId = DataManager<ActivityDataManager>.GetInstance().GetFilterIdByActivityId((int)activityId);
				if (filterIdByActivityId == -1)
				{
					return;
				}
				if (!this.CheckFlyingGiftPackActivityTabIsShow(activityId))
				{
					return;
				}
				if (!this.CheckConsumeRebateActivityTabIsShow(activityId))
				{
					return;
				}
				if (!this.CheckSpringFestivalRedEnvelopeRainActivityTabIsShow(activityId))
				{
					return;
				}
				this.mActivitiesByFilterId[filterIdByActivityId].Add(activity);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeUpdate, this.mActivities[activityId], null, null, null);
			}
		}

		// Token: 0x0600AEA0 RID: 44704 RVA: 0x00261AD4 File Offset: 0x0025FED4
		public bool CheckFlyingGiftPackActivityTabIsShow(uint activityId)
		{
			int num = 0;
			int.TryParse(TR.Value("soaring_activity_id"), out num);
			return (ulong)activityId != (ulong)((long)num) || ClientApplication.playerinfo.CheckAllRoleLevelIsContainsParamLevel(DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv);
		}

		// Token: 0x0600AEA1 RID: 44705 RVA: 0x00261B14 File Offset: 0x0025FF14
		public bool CheckConsumeRebateActivityTabIsShow(uint activityId)
		{
			if (activityId == 1540U)
			{
				int num = 0;
				int.TryParse(TR.Value("ConsumeRebateLimitPlayerGrade"), out num);
				return (int)DataManager<PlayerBaseData>.GetInstance().Level >= num;
			}
			return true;
		}

		// Token: 0x0600AEA2 RID: 44706 RVA: 0x00261B54 File Offset: 0x0025FF54
		public bool CheckSpringFestivalRedEnvelopeRainActivityTabIsShow(uint activityId)
		{
			if (activityId == 1585U)
			{
				int num = 0;
				int.TryParse(TR.Value("SpringFestivalRedEnvelopeRainLimitPlayerGrade"), out num);
				return (int)DataManager<PlayerBaseData>.GetInstance().Level >= num;
			}
			return true;
		}

		// Token: 0x0600AEA3 RID: 44707 RVA: 0x00261B94 File Offset: 0x0025FF94
		public void UpdateFlyingGiftPackActivity(uint activityId)
		{
			if (this.mActivities.ContainsKey(activityId))
			{
				IActivity item = this.mActivities[activityId];
				int filterIdByActivityId = DataManager<ActivityDataManager>.GetInstance().GetFilterIdByActivityId((int)activityId);
				if (filterIdByActivityId == -1)
				{
					return;
				}
				if (!this.CheckFlyingGiftPackActivityTabIsShow(activityId))
				{
					return;
				}
				this.mActivitiesByFilterId[filterIdByActivityId].Add(item);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeUpdate, this.mActivities[activityId], null, null, null);
			}
		}

		// Token: 0x0600AEA4 RID: 44708 RVA: 0x00261C10 File Offset: 0x00260010
		public void UpdateConsumeRebateActivity(uint activityId)
		{
			if (this.mActivities.ContainsKey(activityId))
			{
				IActivity item = this.mActivities[activityId];
				int filterIdByActivityId = DataManager<ActivityDataManager>.GetInstance().GetFilterIdByActivityId((int)activityId);
				if (filterIdByActivityId == -1)
				{
					return;
				}
				if (!this.CheckConsumeRebateActivityTabIsShow(activityId))
				{
					return;
				}
				this.mActivitiesByFilterId[filterIdByActivityId].Add(item);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeUpdate, this.mActivities[activityId], null, null, null);
			}
		}

		// Token: 0x0600AEA5 RID: 44709 RVA: 0x00261C8C File Offset: 0x0026008C
		public void UpdateSpringFestivalRedEnvelopeRainActivity(uint activityId)
		{
			if (this.mActivities.ContainsKey(activityId))
			{
				IActivity item = this.mActivities[activityId];
				int filterIdByActivityId = DataManager<ActivityDataManager>.GetInstance().GetFilterIdByActivityId((int)activityId);
				if (filterIdByActivityId == -1)
				{
					return;
				}
				if (!this.CheckSpringFestivalRedEnvelopeRainActivityTabIsShow(activityId))
				{
					return;
				}
				this.mActivitiesByFilterId[filterIdByActivityId].Add(item);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeUpdate, this.mActivities[activityId], null, null, null);
			}
		}

		// Token: 0x0600AEA6 RID: 44710 RVA: 0x00261D08 File Offset: 0x00260108
		public bool GetVanityBonusActivityIsShow()
		{
			uint activityVanityBonusActivityId = DataManager<ActivityDataManager>.GetInstance().GetActivityVanityBonusActivityId();
			IActivity activity = DataManager<ActivityManager>.GetInstance().GetActivity(activityVanityBonusActivityId);
			return activity != null && activity.GetState() == OpActivityState.OAS_IN;
		}

		// Token: 0x0600AEA7 RID: 44711 RVA: 0x00261D44 File Offset: 0x00260144
		public bool GetChaosAdditionActivityIsShow()
		{
			uint activityChaosAdditionID = DataManager<ActivityDataManager>.GetInstance().GetActivityChaosAdditionID();
			IActivity activity = DataManager<ActivityManager>.GetInstance().GetActivity(activityChaosAdditionID);
			return activity != null && activity.GetState() == OpActivityState.OAS_IN;
		}

		// Token: 0x0600AEA8 RID: 44712 RVA: 0x00261D80 File Offset: 0x00260180
		public bool CheckCourtesyPrivilegesActivityIsExpire()
		{
			bool result = false;
			foreach (KeyValuePair<int, List<IActivity>> keyValuePair in this.mActivitiesByFilterId)
			{
				if (keyValuePair.Value.Count > 0)
				{
					bool flag = false;
					for (int i = 0; i < keyValuePair.Value.Count; i++)
					{
						OpActivityData limitTimeActivityData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(keyValuePair.Value[i].GetId());
						if (limitTimeActivityData != null)
						{
							if (limitTimeActivityData.tmpType == 50009U)
							{
								if (limitTimeActivityData.state == 1)
								{
									uint parm = limitTimeActivityData.parm;
									if ((ulong)parm - (ulong)((long)DataManager<TimeManager>.GetInstance().GetServerTime()) <= 0UL)
									{
										if (DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.GIFT_RIGHT_CARD) == 0)
										{
											result = true;
											keyValuePair.Value.RemoveAt(i);
										}
										else
										{
											result = false;
										}
									}
									else
									{
										result = false;
									}
									flag = true;
									break;
								}
							}
						}
					}
					if (flag)
					{
						break;
					}
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600AEA9 RID: 44713 RVA: 0x00261EE0 File Offset: 0x002602E0
		public bool CheckAbyssBlackGoldMemberActivityIsExpire()
		{
			foreach (KeyValuePair<int, List<IActivity>> keyValuePair in this.mActivitiesByFilterId)
			{
				if (keyValuePair.Value.Count > 0)
				{
					for (int i = 0; i < keyValuePair.Value.Count; i++)
					{
						OpActivityData limitTimeActivityData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(keyValuePair.Value[i].GetId());
						if (limitTimeActivityData != null)
						{
							if (limitTimeActivityData.tmpType == 600010U)
							{
								if (limitTimeActivityData.state == 1)
								{
									if (limitTimeActivityData.tasks.Length > 0)
									{
										OpActTaskData opActTaskData = limitTimeActivityData.tasks[0];
										if (opActTaskData != null)
										{
											OpActTask limitTimeTaskData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeTaskData(opActTaskData.dataid);
											if (limitTimeTaskData != null)
											{
												if (limitTimeTaskData.state == 2)
												{
													return false;
												}
												if (opActTaskData.variables.Length >= 2)
												{
													uint num = opActTaskData.variables[1];
													if ((ulong)num - (ulong)((long)DataManager<TimeManager>.GetInstance().GetServerTime()) <= 0UL)
													{
														keyValuePair.Value.RemoveAt(i);
														return true;
													}
													return false;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return true;
		}

		// Token: 0x0400619A RID: 24986
		private readonly Dictionary<uint, IActivity> mActivities = new Dictionary<uint, IActivity>();

		// Token: 0x0400619B RID: 24987
		private readonly Dictionary<int, List<IActivity>> mActivitiesByFilterId = new Dictionary<int, List<IActivity>>();

		// Token: 0x0400619C RID: 24988
		private VanityBuffBonusModel vanityBBModel;
	}
}
