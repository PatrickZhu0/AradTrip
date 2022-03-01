using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020013D6 RID: 5078
	public class ComAchievementTabReadPointBinder : MonoBehaviour
	{
		// Token: 0x0600C4CF RID: 50383 RVA: 0x002F48AC File Offset: 0x002F2CAC
		public void SetId(int mainId, int subId)
		{
			this.mainId = mainId;
			this.subId = subId;
			this._MarkDirty();
		}

		// Token: 0x0600C4D0 RID: 50384 RVA: 0x002F48C4 File Offset: 0x002F2CC4
		private void Awake()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Combine(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this._OnAddNewMainMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Combine(instance2.onUpdateMission, new MissionManager.DelegateUpdateMission(this._OnUpdateMainMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Combine(instance3.onDeleteMission, new MissionManager.DelegateDeleteMission(this._OnDeleteMission));
			MissionManager instance4 = DataManager<MissionManager>.GetInstance();
			instance4.missionChangedDelegate = (MissionManager.OnMissionChanged)Delegate.Combine(instance4.missionChangedDelegate, new MissionManager.OnMissionChanged(this._OnMissionChanged));
			MissionManager instance5 = DataManager<MissionManager>.GetInstance();
			instance5.onChestIdsChanged = (MissionManager.OnChestIdsChanged)Delegate.Combine(instance5.onChestIdsChanged, new MissionManager.OnChestIdsChanged(this._OnChestIdsChanged));
			this._MarkDirty();
		}

		// Token: 0x0600C4D1 RID: 50385 RVA: 0x002F4998 File Offset: 0x002F2D98
		private void OnDestroy()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Remove(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this._OnAddNewMainMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Remove(instance2.onUpdateMission, new MissionManager.DelegateUpdateMission(this._OnUpdateMainMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Remove(instance3.onDeleteMission, new MissionManager.DelegateDeleteMission(this._OnDeleteMission));
			MissionManager instance4 = DataManager<MissionManager>.GetInstance();
			instance4.missionChangedDelegate = (MissionManager.OnMissionChanged)Delegate.Remove(instance4.missionChangedDelegate, new MissionManager.OnMissionChanged(this._OnMissionChanged));
			MissionManager instance5 = DataManager<MissionManager>.GetInstance();
			instance5.onChestIdsChanged = (MissionManager.OnChestIdsChanged)Delegate.Remove(instance5.onChestIdsChanged, new MissionManager.OnChestIdsChanged(this._OnChestIdsChanged));
			InvokeMethod.RemoveInvokeCall(this);
			this.mDirty = false;
			this._Items.Clear();
		}

		// Token: 0x0600C4D2 RID: 50386 RVA: 0x002F4A7B File Offset: 0x002F2E7B
		private void _OnAddNewMainMission(uint taskID)
		{
			this._MarkDirty();
		}

		// Token: 0x0600C4D3 RID: 50387 RVA: 0x002F4A83 File Offset: 0x002F2E83
		private void _OnDeleteMission(uint taskID)
		{
			this._MarkDirty();
		}

		// Token: 0x0600C4D4 RID: 50388 RVA: 0x002F4A8B File Offset: 0x002F2E8B
		private void _OnUpdateMainMission(uint taskID)
		{
			this._MarkDirty();
		}

		// Token: 0x0600C4D5 RID: 50389 RVA: 0x002F4A93 File Offset: 0x002F2E93
		private void _OnMissionChanged()
		{
			this._MarkDirty();
		}

		// Token: 0x0600C4D6 RID: 50390 RVA: 0x002F4A9B File Offset: 0x002F2E9B
		private void _OnChestIdsChanged()
		{
			this._MarkDirty();
		}

		// Token: 0x0600C4D7 RID: 50391 RVA: 0x002F4AA3 File Offset: 0x002F2EA3
		private void _MarkDirty()
		{
			if (this.mDirty)
			{
				return;
			}
			this.mDirty = true;
			InvokeMethod.Invoke(this, 0.5f, new UnityAction(this._Update));
		}

		// Token: 0x0600C4D8 RID: 50392 RVA: 0x002F4AD0 File Offset: 0x002F2ED0
		private void _Update()
		{
			this.mDirty = false;
			bool flag = false;
			if (this.mainId == -1)
			{
				DataManager<AchievementGroupDataManager>.GetInstance().GetAllItems(ref this._Items);
			}
			else
			{
				AchievementGroupMainItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AchievementGroupMainItemTable>(this.mainId, string.Empty, string.Empty);
				AchievementGroupSecondMenuTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<AchievementGroupSecondMenuTable>(this.subId, string.Empty, string.Empty);
				DataManager<AchievementGroupDataManager>.GetInstance().GetSubItemsByTag(tableItem, tableItem2, ref this._Items);
			}
			if (this._Items != null)
			{
				for (int i = 0; i < this._Items.Count; i++)
				{
					if (this._Items[i] != null)
					{
						MissionManager.SingleMissionInfo mission = DataManager<MissionManager>.GetInstance().GetMission((uint)this._Items[i].ID);
						if (mission != null && mission.missionItem != null)
						{
							if (mission.status == 2)
							{
								flag = true;
								break;
							}
						}
					}
				}
			}
			UnityEvent unityEvent = (!flag) ? this.onFailed : this.onSucceed;
			if (unityEvent != null)
			{
				unityEvent.Invoke();
			}
		}

		// Token: 0x0400701F RID: 28703
		public int mainId = -1;

		// Token: 0x04007020 RID: 28704
		public int subId = -1;

		// Token: 0x04007021 RID: 28705
		public UnityEvent onSucceed;

		// Token: 0x04007022 RID: 28706
		public UnityEvent onFailed;

		// Token: 0x04007023 RID: 28707
		private bool mDirty;

		// Token: 0x04007024 RID: 28708
		private List<AchievementGroupSubItemTable> _Items = new List<AchievementGroupSubItemTable>();
	}
}
