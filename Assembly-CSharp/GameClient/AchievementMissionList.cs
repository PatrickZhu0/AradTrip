using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020017B7 RID: 6071
	internal class AchievementMissionList
	{
		// Token: 0x17001CE4 RID: 7396
		// (get) Token: 0x0600EF6A RID: 61290 RVA: 0x00405B6D File Offset: 0x00403F6D
		public bool Initialized
		{
			get
			{
				return this._Initialized;
			}
		}

		// Token: 0x0600EF6B RID: 61291 RVA: 0x00405B75 File Offset: 0x00403F75
		private bool _IsLegalAchievementMission(MissionManager.SingleMissionInfo value)
		{
			return value.missionItem.TaskType == MissionTable.eTaskType.TT_ACHIEVEMENT && value.missionItem.SubType == MissionTable.eSubType.Daily_Null;
		}

		// Token: 0x0600EF6C RID: 61292 RVA: 0x00405B9B File Offset: 0x00403F9B
		private ComAchievementScript _OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComAchievementScript>();
		}

		// Token: 0x0600EF6D RID: 61293 RVA: 0x00405BA4 File Offset: 0x00403FA4
		public void Initialize(ClientFrame clientFrame, GameObject gameObject, AchievementMissionList.OnRedPointChanged onRedPointChanged)
		{
			if (this._Initialized)
			{
				return;
			}
			this._Initialized = true;
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
			instance2.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Combine(instance2.onAddNewMission, new MissionManager.DelegateAddNewMission(this.OnAddAchievementMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Combine(instance3.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateAchievementMission));
			MissionManager instance4 = DataManager<MissionManager>.GetInstance();
			instance4.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Combine(instance4.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnDeleteAchievementMission));
			this._LoadAchievementMissions();
		}

		// Token: 0x0600EF6E RID: 61294 RVA: 0x00405D08 File Offset: 0x00404108
		private List<MissionManager.SingleMissionInfo> _GetAchievementMissions()
		{
			List<MissionManager.SingleMissionInfo> list = DataManager<MissionManager>.GetInstance().taskGroup.Values.ToList<MissionManager.SingleMissionInfo>();
			list.RemoveAll((MissionManager.SingleMissionInfo x) => !this._IsLegalAchievementMission(x));
			return list;
		}

		// Token: 0x0600EF6F RID: 61295 RVA: 0x00405D40 File Offset: 0x00404140
		private bool _CheckRedPoint(List<MissionManager.SingleMissionInfo> values)
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

		// Token: 0x0600EF70 RID: 61296 RVA: 0x00405D80 File Offset: 0x00404180
		private void _LoadAchievementMissions()
		{
			this.missions = this._GetAchievementMissions();
			this.missions.Sort(new Comparison<MissionManager.SingleMissionInfo>(this._Sort));
			this.comUIListScript.SetElementAmount(this.missions.Count);
			if (this.onRedPointChanged != null)
			{
				this.onRedPointChanged(this._CheckRedPoint(this.missions));
			}
		}

		// Token: 0x0600EF71 RID: 61297 RVA: 0x00405DE8 File Offset: 0x004041E8
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
				if (left.taskID != right.taskID)
				{
					return (left.taskID >= right.taskID) ? 1 : -1;
				}
				return 0;
			}
		}

		// Token: 0x0600EF72 RID: 61298 RVA: 0x00405E90 File Offset: 0x00404290
		private void _OnItemVisiableDelegate(ComUIListElementScript item)
		{
			if (item != null && item.m_index >= 0 && item.m_index < this.missions.Count)
			{
				ComAchievementScript comAchievementScript = item.gameObjectBindScript as ComAchievementScript;
				if (comAchievementScript != null)
				{
					comAchievementScript.OnVisible(this.missions[item.m_index], this.clientFrame);
				}
			}
		}

		// Token: 0x0600EF73 RID: 61299 RVA: 0x00405F00 File Offset: 0x00404300
		private void _OnItemSelectedDelegate(ComUIListElementScript item)
		{
			if (item != null && item.m_index >= 0 && item.m_index < this.missions.Count)
			{
				ComAchievementScript comAchievementScript = item.gameObjectBindScript as ComAchievementScript;
				if (comAchievementScript != null)
				{
				}
			}
		}

		// Token: 0x0600EF74 RID: 61300 RVA: 0x00405F54 File Offset: 0x00404354
		public void UnInitialize()
		{
			if (this._Initialized)
			{
				MissionManager instance = DataManager<MissionManager>.GetInstance();
				instance.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Remove(instance.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnDeleteAchievementMission));
				MissionManager instance2 = DataManager<MissionManager>.GetInstance();
				instance2.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Remove(instance2.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateAchievementMission));
				MissionManager instance3 = DataManager<MissionManager>.GetInstance();
				instance3.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Remove(instance3.onAddNewMission, new MissionManager.DelegateAddNewMission(this.OnAddAchievementMission));
				MissionManager instance4 = DataManager<MissionManager>.GetInstance();
				instance4.missionChangedDelegate = (MissionManager.OnMissionChanged)Delegate.Remove(instance4.missionChangedDelegate, new MissionManager.OnMissionChanged(this.OnMissionListChanged));
				if (null != this.comUIListScript)
				{
					ComUIListScript comUIListScript = this.comUIListScript;
					comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
					ComUIListScript comUIListScript2 = this.comUIListScript;
					comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
					ComUIListScript comUIListScript3 = this.comUIListScript;
					comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this._OnItemSelectedDelegate));
					this.comUIListScript = null;
				}
				this.onRedPointChanged = null;
				this.clientFrame = null;
				this.gameObject = null;
				this._Initialized = false;
			}
		}

		// Token: 0x0600EF75 RID: 61301 RVA: 0x004060AD File Offset: 0x004044AD
		private void OnMissionListChanged()
		{
			this._LoadAchievementMissions();
		}

		// Token: 0x0600EF76 RID: 61302 RVA: 0x004060B5 File Offset: 0x004044B5
		private void OnAddAchievementMission(uint taskID)
		{
			this._LoadAchievementMissions();
		}

		// Token: 0x0600EF77 RID: 61303 RVA: 0x004060BD File Offset: 0x004044BD
		private void OnUpdateAchievementMission(uint taskID)
		{
			this._LoadAchievementMissions();
		}

		// Token: 0x0600EF78 RID: 61304 RVA: 0x004060C5 File Offset: 0x004044C5
		private void OnDeleteAchievementMission(uint taskID)
		{
			this._LoadAchievementMissions();
		}

		// Token: 0x040092B3 RID: 37555
		private ClientFrame clientFrame;

		// Token: 0x040092B4 RID: 37556
		private GameObject gameObject;

		// Token: 0x040092B5 RID: 37557
		private ComUIListScript comUIListScript;

		// Token: 0x040092B6 RID: 37558
		private List<MissionManager.SingleMissionInfo> missions;

		// Token: 0x040092B7 RID: 37559
		public AchievementMissionList.OnRedPointChanged onRedPointChanged;

		// Token: 0x040092B8 RID: 37560
		private bool _Initialized;

		// Token: 0x020017B8 RID: 6072
		// (Invoke) Token: 0x0600EF7B RID: 61307
		public delegate void OnRedPointChanged(bool bCheck);
	}
}
