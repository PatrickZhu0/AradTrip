using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000083 RID: 131
	internal class MissionScoreRedBinder : MonoBehaviour
	{
		// Token: 0x1700001C RID: 28
		// (set) Token: 0x060002CB RID: 715 RVA: 0x00015A77 File Offset: 0x00013E77
		public int LinkID
		{
			set
			{
				this.iLinkID = value;
				this._Update();
			}
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00015A88 File Offset: 0x00013E88
		private void Start()
		{
			this._Update();
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onDailyScoreChanged = (MissionManager.OnDailyScoreChanged)Delegate.Combine(instance.onDailyScoreChanged, new MissionManager.OnDailyScoreChanged(this.OnDailyScoreChanged));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onChestIdsChanged = (MissionManager.OnChestIdsChanged)Delegate.Combine(instance2.onChestIdsChanged, new MissionManager.OnChestIdsChanged(this.OnChestIdsChanged));
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00015AE8 File Offset: 0x00013EE8
		private void OnDestroy()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onDailyScoreChanged = (MissionManager.OnDailyScoreChanged)Delegate.Remove(instance.onDailyScoreChanged, new MissionManager.OnDailyScoreChanged(this.OnDailyScoreChanged));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onChestIdsChanged = (MissionManager.OnChestIdsChanged)Delegate.Remove(instance2.onChestIdsChanged, new MissionManager.OnChestIdsChanged(this.OnChestIdsChanged));
			this.target = null;
		}

		// Token: 0x060002CE RID: 718 RVA: 0x00015B48 File Offset: 0x00013F48
		private void OnDailyScoreChanged(int score)
		{
			this._Update();
		}

		// Token: 0x060002CF RID: 719 RVA: 0x00015B50 File Offset: 0x00013F50
		private void OnChestIdsChanged()
		{
			this._Update();
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00015B58 File Offset: 0x00013F58
		private void _Update()
		{
			MissionManager.MissionScoreData missionScoreData = DataManager<MissionManager>.GetInstance().MissionScoreDatas.Find((MissionManager.MissionScoreData x) => x.missionScoreItem.ID == this.iLinkID);
			bool bActive = false;
			if (missionScoreData != null)
			{
				bActive = (missionScoreData.missionScoreItem.Score <= DataManager<MissionManager>.GetInstance().Score && !DataManager<MissionManager>.GetInstance().AcquiredChestIDs.Contains(missionScoreData.missionScoreItem.ID));
			}
			if (this.target == null)
			{
				this.target = base.gameObject;
			}
			this.target.CustomActive(bActive);
		}

		// Token: 0x040002C4 RID: 708
		public GameObject target;

		// Token: 0x040002C5 RID: 709
		public int iLinkID;
	}
}
