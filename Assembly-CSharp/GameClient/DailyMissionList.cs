using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020017C2 RID: 6082
	internal class DailyMissionList
	{
		// Token: 0x0600EFD2 RID: 61394 RVA: 0x004087F0 File Offset: 0x00406BF0
		public static bool HasFinishedDailyTask()
		{
			List<MissionManager.SingleMissionInfo> values = DailyMissionList._GetDailyMissions();
			return DailyMissionList._CheckRedPoint(values);
		}

		// Token: 0x0600EFD3 RID: 61395 RVA: 0x00408814 File Offset: 0x00406C14
		public static int GetFinishedDailyTask()
		{
			int num = 0;
			List<MissionManager.SingleMissionInfo> list = DailyMissionList._GetDailyMissions();
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].status == 2)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x0600EFD4 RID: 61396 RVA: 0x0040885D File Offset: 0x00406C5D
		private static bool _IsLegalDailyMission(MissionManager.SingleMissionInfo value)
		{
			return value != null && value.missionItem != null && (value.missionItem.TaskType == MissionTable.eTaskType.TT_DIALY && value.missionItem.SubType == MissionTable.eSubType.Daily_Task);
		}

		// Token: 0x0600EFD5 RID: 61397 RVA: 0x00408896 File Offset: 0x00406C96
		private ComDailyScript _OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComDailyScript>();
		}

		// Token: 0x0600EFD6 RID: 61398 RVA: 0x004088A0 File Offset: 0x00406CA0
		public void Initialize(ClientFrame clientFrame, GameObject gameObject, DailyMissionList.OnRedPointChanged onRedPointChanged)
		{
			this.clientFrame = clientFrame;
			this.gameObject = gameObject;
			this.onRedPointChanged = onRedPointChanged;
			this.comUIListScript = this.gameObject.GetComponent<ComUIListScript>();
			this.comUIListScript.Initialize();
			ComUIListScript comUIListScript = this.comUIListScript;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
			ComUIListScript comUIListScript2 = this.comUIListScript;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
			ComUIListScript comUIListScript3 = this.comUIListScript;
			comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this._OnItemSelectedDelegate));
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.missionChangedDelegate = (MissionManager.OnMissionChanged)Delegate.Combine(instance.missionChangedDelegate, new MissionManager.OnMissionChanged(this.OnMissionListChanged));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Combine(instance2.onAddNewMission, new MissionManager.DelegateAddNewMission(this.OnAddDailyMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Combine(instance3.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateDailyMission));
			MissionManager instance4 = DataManager<MissionManager>.GetInstance();
			instance4.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Combine(instance4.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnDeleteDailyMission));
			this._LoadDailyMissions();
		}

		// Token: 0x0600EFD7 RID: 61399 RVA: 0x004089F4 File Offset: 0x00406DF4
		private static List<MissionManager.SingleMissionInfo> _GetDailyMissions()
		{
			List<MissionManager.SingleMissionInfo> list = DataManager<MissionManager>.GetInstance().taskGroup.Values.ToList<MissionManager.SingleMissionInfo>();
			list.RemoveAll((MissionManager.SingleMissionInfo x) => !DailyMissionList._IsLegalDailyMission(x));
			return list;
		}

		// Token: 0x0600EFD8 RID: 61400 RVA: 0x00408A3C File Offset: 0x00406E3C
		private static bool _CheckRedPoint(List<MissionManager.SingleMissionInfo> values)
		{
			if (values != null)
			{
				for (int i = 0; i < values.Count; i++)
				{
					if (values[i].status == 2)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600EFD9 RID: 61401 RVA: 0x00408A7B File Offset: 0x00406E7B
		public bool CheckRedPoint()
		{
			return DailyMissionList._CheckRedPoint(this.missions);
		}

		// Token: 0x0600EFDA RID: 61402 RVA: 0x00408A88 File Offset: 0x00406E88
		private void _LoadDailyMissions()
		{
			this.missions = DailyMissionList._GetDailyMissions();
			if (this.missions != null && this.comUIListScript != null)
			{
				this.missions.Sort(new Comparison<MissionManager.SingleMissionInfo>(this._Sort));
				this.comUIListScript.SetElementAmount(this.missions.Count);
				if (this.onRedPointChanged != null)
				{
					this.onRedPointChanged(DailyMissionList._CheckRedPoint(this.missions));
				}
			}
		}

		// Token: 0x0600EFDB RID: 61403 RVA: 0x00408B0C File Offset: 0x00406F0C
		private int _Sort(MissionManager.SingleMissionInfo left, MissionManager.SingleMissionInfo right)
		{
			if (left.status != right.status)
			{
				if (left.status == 5)
				{
					return 1;
				}
				if (right.status == 5)
				{
					return -1;
				}
				return (int)(right.status - left.status);
			}
			else
			{
				if (left.missionItem.SortID != right.missionItem.SortID)
				{
					return left.missionItem.SortID - right.missionItem.SortID;
				}
				if (left.missionItem.MinPlayerLv != right.missionItem.MinPlayerLv)
				{
					return right.missionItem.MinPlayerLv - left.missionItem.MinPlayerLv;
				}
				if (left.taskID != right.taskID)
				{
					return (left.taskID >= right.taskID) ? 1 : -1;
				}
				return 0;
			}
		}

		// Token: 0x0600EFDC RID: 61404 RVA: 0x00408BE8 File Offset: 0x00406FE8
		private void _OnItemVisiableDelegate(ComUIListElementScript item)
		{
			if (item != null && item.m_index >= 0 && item.m_index < this.missions.Count)
			{
				ComDailyScript comDailyScript = item.gameObjectBindScript as ComDailyScript;
				if (comDailyScript != null)
				{
					comDailyScript.OnVisible(this.missions[item.m_index], this.clientFrame);
				}
			}
		}

		// Token: 0x0600EFDD RID: 61405 RVA: 0x00408C58 File Offset: 0x00407058
		private void _OnItemSelectedDelegate(ComUIListElementScript item)
		{
			if (item != null && item.m_index >= 0 && item.m_index < this.missions.Count)
			{
				ComDailyScript comDailyScript = item.gameObjectBindScript as ComDailyScript;
				if (comDailyScript != null)
				{
				}
			}
		}

		// Token: 0x0600EFDE RID: 61406 RVA: 0x00408CAC File Offset: 0x004070AC
		public void UnInitialize()
		{
			if (this.comUIListScript != null)
			{
				this.comUIListScript.SetElementAmount(0);
				ComUIListScript comUIListScript = this.comUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.comUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.comUIListScript;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this._OnItemSelectedDelegate));
				this.comUIListScript = null;
			}
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Remove(instance.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnDeleteDailyMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Remove(instance2.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateDailyMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Remove(instance3.onAddNewMission, new MissionManager.DelegateAddNewMission(this.OnAddDailyMission));
			MissionManager instance4 = DataManager<MissionManager>.GetInstance();
			instance4.missionChangedDelegate = (MissionManager.OnMissionChanged)Delegate.Remove(instance4.missionChangedDelegate, new MissionManager.OnMissionChanged(this.OnMissionListChanged));
			this.onRedPointChanged = null;
			this.clientFrame = null;
			this.gameObject = null;
		}

		// Token: 0x0600EFDF RID: 61407 RVA: 0x00408DFF File Offset: 0x004071FF
		private void OnAddDailyMission(uint taskID)
		{
			this._LoadDailyMissions();
		}

		// Token: 0x0600EFE0 RID: 61408 RVA: 0x00408E07 File Offset: 0x00407207
		private void OnUpdateDailyMission(uint taskID)
		{
			this._LoadDailyMissions();
		}

		// Token: 0x0600EFE1 RID: 61409 RVA: 0x00408E0F File Offset: 0x0040720F
		private void OnDeleteDailyMission(uint taskID)
		{
			this._LoadDailyMissions();
		}

		// Token: 0x0600EFE2 RID: 61410 RVA: 0x00408E17 File Offset: 0x00407217
		private void OnMissionListChanged()
		{
			this._LoadDailyMissions();
		}

		// Token: 0x04009317 RID: 37655
		private ClientFrame clientFrame;

		// Token: 0x04009318 RID: 37656
		private GameObject gameObject;

		// Token: 0x04009319 RID: 37657
		private ComUIListScript comUIListScript;

		// Token: 0x0400931A RID: 37658
		private List<MissionManager.SingleMissionInfo> missions;

		// Token: 0x0400931B RID: 37659
		public DailyMissionList.OnRedPointChanged onRedPointChanged;

		// Token: 0x020017C3 RID: 6083
		// (Invoke) Token: 0x0600EFE5 RID: 61413
		public delegate void OnRedPointChanged(bool bCheck);
	}
}
