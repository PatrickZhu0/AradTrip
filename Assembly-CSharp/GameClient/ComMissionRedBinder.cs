using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020017C0 RID: 6080
	public class ComMissionRedBinder : MonoBehaviour
	{
		// Token: 0x0600EFC1 RID: 61377 RVA: 0x004084DD File Offset: 0x004068DD
		public void AddRedPointBinder(ComMissionRedBinder.MissionRedBinderType[] binders)
		{
			this.mFlags = binders;
			this._MarkDirty();
		}

		// Token: 0x0600EFC2 RID: 61378 RVA: 0x004084EC File Offset: 0x004068EC
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
		}

		// Token: 0x0600EFC3 RID: 61379 RVA: 0x004085B8 File Offset: 0x004069B8
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
		}

		// Token: 0x0600EFC4 RID: 61380 RVA: 0x00408690 File Offset: 0x00406A90
		private void _OnAddNewMainMission(uint taskID)
		{
			this._MarkDirty();
		}

		// Token: 0x0600EFC5 RID: 61381 RVA: 0x00408698 File Offset: 0x00406A98
		private void _OnDeleteMission(uint taskID)
		{
			this._MarkDirty();
		}

		// Token: 0x0600EFC6 RID: 61382 RVA: 0x004086A0 File Offset: 0x00406AA0
		private void _OnUpdateMainMission(uint taskID)
		{
			this._MarkDirty();
		}

		// Token: 0x0600EFC7 RID: 61383 RVA: 0x004086A8 File Offset: 0x00406AA8
		private void _OnMissionChanged()
		{
			this._MarkDirty();
		}

		// Token: 0x0600EFC8 RID: 61384 RVA: 0x004086B0 File Offset: 0x00406AB0
		private void _OnChestIdsChanged()
		{
			this._MarkDirty();
		}

		// Token: 0x0600EFC9 RID: 61385 RVA: 0x004086B8 File Offset: 0x00406AB8
		private bool _CheckDaily()
		{
			return DailyMissionList.GetFinishedDailyTask() > 0;
		}

		// Token: 0x0600EFCA RID: 61386 RVA: 0x004086C2 File Offset: 0x00406AC2
		private bool _CheckDailyChest()
		{
			return MissionDailyFrame.GetChestRedPoint() > 0;
		}

		// Token: 0x0600EFCB RID: 61387 RVA: 0x004086CC File Offset: 0x00406ACC
		private bool _CheckAchievement()
		{
			return DataManager<MissionManager>.GetInstance().GetAchievementMissionStatusCount(2) > 0;
		}

		// Token: 0x0600EFCC RID: 61388 RVA: 0x004086DC File Offset: 0x00406ADC
		private bool _CheckTitle()
		{
			return DataManager<MissionManager>.GetInstance().GetTitleMissionStatusCount(2) > 0;
		}

		// Token: 0x0600EFCD RID: 61389 RVA: 0x004086EC File Offset: 0x00406AEC
		private bool _CheckMain()
		{
			return DataManager<MissionManager>.GetInstance().GetMainMissionStatusCount(2) > 0;
		}

		// Token: 0x0600EFCE RID: 61390 RVA: 0x004086FC File Offset: 0x00406AFC
		private void _MarkDirty()
		{
			if (this.mDirty)
			{
				return;
			}
			this.mDirty = true;
			InvokeMethod.Invoke(this, 0.5f, new UnityAction(this._Update));
		}

		// Token: 0x0600EFCF RID: 61391 RVA: 0x00408728 File Offset: 0x00406B28
		private void Start()
		{
			this._MarkDirty();
		}

		// Token: 0x0600EFD0 RID: 61392 RVA: 0x00408730 File Offset: 0x00406B30
		private void _Update()
		{
			this.mDirty = false;
			bool flag = false;
			int num = 0;
			while (num < this.mFlags.Length && !flag)
			{
				ComMissionRedBinder.MissionRedBinderType missionRedBinderType = this.mFlags[num];
				switch (missionRedBinderType)
				{
				case ComMissionRedBinder.MissionRedBinderType.MRBT_MAIN:
					flag = this._CheckMain();
					break;
				case ComMissionRedBinder.MissionRedBinderType.MRBT_DAILY:
					flag = this._CheckDaily();
					break;
				default:
					if (missionRedBinderType == ComMissionRedBinder.MissionRedBinderType.MRBT_TITLE)
					{
						flag = this._CheckTitle();
					}
					break;
				case ComMissionRedBinder.MissionRedBinderType.MRBT_DAILY_CHEST:
					flag = this._CheckDailyChest();
					break;
				}
				num++;
			}
			UnityEvent unityEvent = (!flag) ? this.onFailed : this.onSucceed;
			if (unityEvent != null)
			{
				unityEvent.Invoke();
			}
		}

		// Token: 0x0400930D RID: 37645
		public ComMissionRedBinder.MissionRedBinderType[] mFlags = new ComMissionRedBinder.MissionRedBinderType[0];

		// Token: 0x0400930E RID: 37646
		public UnityEvent onSucceed;

		// Token: 0x0400930F RID: 37647
		public UnityEvent onFailed;

		// Token: 0x04009310 RID: 37648
		private bool mDirty;

		// Token: 0x020017C1 RID: 6081
		public enum MissionRedBinderType
		{
			// Token: 0x04009312 RID: 37650
			MRBT_MAIN = 1,
			// Token: 0x04009313 RID: 37651
			MRBT_DAILY,
			// Token: 0x04009314 RID: 37652
			MRBT_DAILY_CHEST = 4,
			// Token: 0x04009315 RID: 37653
			MRBT_ACHIEVEMENT = 8,
			// Token: 0x04009316 RID: 37654
			MRBT_TITLE = 16
		}
	}
}
