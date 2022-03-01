using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020045A0 RID: 17824
	public class NpcRelationMissionManager : DataManager<NpcRelationMissionManager>
	{
		// Token: 0x06018E6E RID: 101998 RVA: 0x007CC0DA File Offset: 0x007CA4DA
		public List<MissionManager.SingleMissionInfo> GetNpcRelationMissions(int iNpcId)
		{
			if (!this.m_dicNpc2Missions.ContainsKey(iNpcId))
			{
				return null;
			}
			return this.m_dicNpc2Missions[iNpcId];
		}

		// Token: 0x06018E6F RID: 101999 RVA: 0x007CC0FC File Offset: 0x007CA4FC
		public override void Initialize()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Combine(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this.OnAddNewMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Combine(instance2.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onDeleteMissionValue = (MissionManager.OnDeleteMissionValue)Delegate.Combine(instance3.onDeleteMissionValue, new MissionManager.OnDeleteMissionValue(this.OnRemoveMission));
			MissionManager instance4 = DataManager<MissionManager>.GetInstance();
			instance4.missionChangedDelegate = (MissionManager.OnMissionChanged)Delegate.Combine(instance4.missionChangedDelegate, new MissionManager.OnMissionChanged(this.OnMissionChanged));
			PlayerBaseData instance5 = DataManager<PlayerBaseData>.GetInstance();
			instance5.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(instance5.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			this.RegisterAllNpcMissions();
		}

		// Token: 0x06018E70 RID: 102000 RVA: 0x007CC1D0 File Offset: 0x007CA5D0
		public override void Clear()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Remove(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this.OnAddNewMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Remove(instance2.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onDeleteMissionValue = (MissionManager.OnDeleteMissionValue)Delegate.Remove(instance3.onDeleteMissionValue, new MissionManager.OnDeleteMissionValue(this.OnRemoveMission));
			MissionManager instance4 = DataManager<MissionManager>.GetInstance();
			instance4.missionChangedDelegate = (MissionManager.OnMissionChanged)Delegate.Remove(instance4.missionChangedDelegate, new MissionManager.OnMissionChanged(this.OnMissionChanged));
			PlayerBaseData instance5 = DataManager<PlayerBaseData>.GetInstance();
			instance5.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance5.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			this.UnRegisterAllNpcMissions();
		}

		// Token: 0x06018E71 RID: 102001 RVA: 0x007CC2A1 File Offset: 0x007CA6A1
		private void OnNotifyNpcRelationMissionChanged(int iNpcId)
		{
			if (this.onNpcRelationMissionChanged != null)
			{
				this.onNpcRelationMissionChanged(iNpcId);
			}
		}

		// Token: 0x06018E72 RID: 102002 RVA: 0x007CC2BC File Offset: 0x007CA6BC
		private void OnAddNewMission(uint taskID)
		{
			int relationNpcId = this.GetRelationNpcId(taskID);
			if (relationNpcId == 0)
			{
				return;
			}
			this.RegisterMission(relationNpcId, DataManager<MissionManager>.GetInstance().GetMission(taskID));
		}

		// Token: 0x06018E73 RID: 102003 RVA: 0x007CC2EC File Offset: 0x007CA6EC
		private void OnUpdateMission(uint taskID)
		{
			this.UnRegisterMission(DataManager<MissionManager>.GetInstance().GetMission(taskID));
			int relationNpcId = this.GetRelationNpcId(taskID);
			if (relationNpcId == 0)
			{
				return;
			}
			this.RegisterMission(relationNpcId, DataManager<MissionManager>.GetInstance().GetMission(taskID));
		}

		// Token: 0x06018E74 RID: 102004 RVA: 0x007CC32B File Offset: 0x007CA72B
		private void OnRemoveMission(MissionManager.SingleMissionInfo value)
		{
			this.UnRegisterMission(value);
		}

		// Token: 0x06018E75 RID: 102005 RVA: 0x007CC334 File Offset: 0x007CA734
		private void OnMissionChanged()
		{
			this.UnRegisterAllNpcMissions();
			this.RegisterAllNpcMissions();
		}

		// Token: 0x06018E76 RID: 102006 RVA: 0x007CC342 File Offset: 0x007CA742
		private void OnLevelChanged(int iPreLv, int iCurLv)
		{
			this.UnRegisterAllNpcMissions();
			this.RegisterAllNpcMissions();
		}

		// Token: 0x06018E77 RID: 102007 RVA: 0x007CC350 File Offset: 0x007CA750
		private int GetStatusValue(int iStatus)
		{
			if (iStatus >= 0 && iStatus < this.ms_status_order.Length)
			{
				return this.ms_status_order[iStatus];
			}
			return this.ms_status_order.Length;
		}

		// Token: 0x06018E78 RID: 102008 RVA: 0x007CC378 File Offset: 0x007CA778
		private int GetRelationNpcId(MissionManager.SingleMissionInfo value)
		{
			if (!ComMainMissionScript.IsLegalMainMission(value))
			{
				return 0;
			}
			if (value.status == 0 && value.missionItem.AcceptType == MissionTable.eAcceptType.ACT_NPC)
			{
				NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(value.missionItem.MissionTakeNpc, string.Empty, string.Empty);
				if (tableItem != null)
				{
					return tableItem.ID;
				}
				return 0;
			}
			else if (value.status == 2 && value.missionItem.FinishType == MissionTable.eFinishType.FINISH_TYPE_NPC)
			{
				NpcTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(value.missionItem.MissionFinishNpc, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					return tableItem2.ID;
				}
				return 0;
			}
			else
			{
				if (value.status != 1 || value.missionItem.TaskFinishType != MissionTable.eTaskFinishType.TFT_SUBMIT_ITEM)
				{
					return 0;
				}
				NpcTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(value.missionItem.MissionFinishNpc, string.Empty, string.Empty);
				if (tableItem3 != null)
				{
					return tableItem3.ID;
				}
				return 0;
			}
		}

		// Token: 0x06018E79 RID: 102009 RVA: 0x007CC478 File Offset: 0x007CA878
		private int GetRelationNpcId(uint taskID)
		{
			MissionManager.SingleMissionInfo mission = DataManager<MissionManager>.GetInstance().GetMission(taskID);
			if (mission == null)
			{
				return 0;
			}
			return this.GetRelationNpcId(mission);
		}

		// Token: 0x06018E7A RID: 102010 RVA: 0x007CC4A0 File Offset: 0x007CA8A0
		private void RegisterAllNpcMissions()
		{
			List<MissionManager.SingleMissionInfo> list = DataManager<MissionManager>.GetInstance().taskGroup.Values.ToList<MissionManager.SingleMissionInfo>();
			for (int i = 0; i < list.Count; i++)
			{
				int relationNpcId = this.GetRelationNpcId(list[i].taskID);
				if (relationNpcId != 0)
				{
					this.RegisterMission(relationNpcId, list[i]);
				}
			}
		}

		// Token: 0x06018E7B RID: 102011 RVA: 0x007CC508 File Offset: 0x007CA908
		private void UnRegisterAllNpcMissions()
		{
			foreach (KeyValuePair<int, List<MissionManager.SingleMissionInfo>> keyValuePair in this.m_dicNpc2Missions)
			{
				keyValuePair.Value.Clear();
				Dictionary<int, List<MissionManager.SingleMissionInfo>>.Enumerator enumerator;
				KeyValuePair<int, List<MissionManager.SingleMissionInfo>> keyValuePair2 = enumerator.Current;
				this.OnNotifyNpcRelationMissionChanged(keyValuePair2.Key);
			}
			this.m_dicNpc2Missions.Clear();
			this.m_dicTask2List.Clear();
			this.m_akCachedLinkObjects.Clear();
		}

		// Token: 0x06018E7C RID: 102012 RVA: 0x007CC57C File Offset: 0x007CA97C
		private void RegisterMission(int iNpcId, MissionManager.SingleMissionInfo value)
		{
			if (iNpcId == 0 || value == null || value.missionItem == null)
			{
				return;
			}
			if ((int)DataManager<PlayerBaseData>.GetInstance().Level < value.missionItem.MinPlayerLv)
			{
				return;
			}
			if (this.m_dicTask2List.ContainsKey(value.missionItem.ID))
			{
				return;
			}
			List<MissionManager.SingleMissionInfo> list = null;
			if (!this.m_dicNpc2Missions.TryGetValue(iNpcId, out list))
			{
				list = new List<MissionManager.SingleMissionInfo>();
				this.m_dicNpc2Missions.Add(iNpcId, list);
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].missionItem.ID == value.missionItem.ID)
				{
					return;
				}
			}
			NpcRelationMissionManager.MissionLinkObject missionLinkObject;
			if (this.m_akCachedLinkObjects.Count > 0)
			{
				missionLinkObject = this.m_akCachedLinkObjects.Pop();
			}
			else
			{
				missionLinkObject = new NpcRelationMissionManager.MissionLinkObject();
			}
			this.m_dicTask2List.Add(value.missionItem.ID, missionLinkObject);
			missionLinkObject.parent = list;
			list.Add(value);
			missionLinkObject.iNpcId = iNpcId;
			list.Sort(delegate(MissionManager.SingleMissionInfo x, MissionManager.SingleMissionInfo y)
			{
				if (x.status != y.status)
				{
					return this.GetStatusValue((int)x.status) - this.GetStatusValue((int)y.status);
				}
				return (x.taskID >= y.taskID) ? 1 : -1;
			});
			this.OnNotifyNpcRelationMissionChanged(iNpcId);
		}

		// Token: 0x06018E7D RID: 102013 RVA: 0x007CC6A8 File Offset: 0x007CAAA8
		private void UnRegisterMission(MissionManager.SingleMissionInfo value)
		{
			if (value == null || !this.m_dicTask2List.ContainsKey(value.missionItem.ID))
			{
				return;
			}
			NpcRelationMissionManager.MissionLinkObject missionLinkObject = this.m_dicTask2List[value.missionItem.ID];
			if (missionLinkObject != null)
			{
				this.m_akCachedLinkObjects.Push(missionLinkObject);
				this.m_dicTask2List.Remove(value.missionItem.ID);
				missionLinkObject.parent.Remove(value);
				this.OnNotifyNpcRelationMissionChanged(missionLinkObject.iNpcId);
			}
		}

		// Token: 0x04011EA2 RID: 73378
		public NpcRelationMissionManager.OnNpcRelationMissionChanged onNpcRelationMissionChanged;

		// Token: 0x04011EA3 RID: 73379
		private Dictionary<int, List<MissionManager.SingleMissionInfo>> m_dicNpc2Missions = new Dictionary<int, List<MissionManager.SingleMissionInfo>>();

		// Token: 0x04011EA4 RID: 73380
		private Dictionary<int, NpcRelationMissionManager.MissionLinkObject> m_dicTask2List = new Dictionary<int, NpcRelationMissionManager.MissionLinkObject>();

		// Token: 0x04011EA5 RID: 73381
		private Stack<NpcRelationMissionManager.MissionLinkObject> m_akCachedLinkObjects = new Stack<NpcRelationMissionManager.MissionLinkObject>();

		// Token: 0x04011EA6 RID: 73382
		private int[] ms_status_order = new int[]
		{
			2,
			1,
			0,
			3,
			4,
			5
		};

		// Token: 0x020045A1 RID: 17825
		// (Invoke) Token: 0x06018E80 RID: 102016
		public delegate void OnNpcRelationMissionChanged(int iNpcId);

		// Token: 0x020045A2 RID: 17826
		private class MissionLinkObject
		{
			// Token: 0x04011EA7 RID: 73383
			public List<MissionManager.SingleMissionInfo> parent;

			// Token: 0x04011EA8 RID: 73384
			public int iNpcId;
		}
	}
}
