using System;

namespace GameClient
{
	// Token: 0x0200138F RID: 5007
	internal class ActivityDungeonDeadTowerUpdateData : IActivityDungeonUpdateData
	{
		// Token: 0x0600C229 RID: 49705 RVA: 0x002E462D File Offset: 0x002E2A2D
		public ActivityDungeonDeadTowerUpdateData()
		{
			this._init();
		}

		// Token: 0x0600C22A RID: 49706 RVA: 0x002E463C File Offset: 0x002E2A3C
		private void _init()
		{
			this.mState = ActivityDungeonDeadTowerUpdateData.eState.onWaitEnd;
			this.mWaitTime = this._getPersistendTime();
			this.mLastIsTimeEnd = this._isTimeEnd();
			if (this.mLastIsTimeEnd)
			{
				if (!this._isVisisted())
				{
					this.mState = ActivityDungeonDeadTowerUpdateData.eState.onWaitView;
				}
				else
				{
					this.mState = ActivityDungeonDeadTowerUpdateData.eState.onNone;
				}
			}
			else
			{
				this.mState = ActivityDungeonDeadTowerUpdateData.eState.onWaitEnd;
			}
		}

		// Token: 0x0600C22B RID: 49707 RVA: 0x002E469D File Offset: 0x002E2A9D
		private bool _isTimeEnd()
		{
			return this.mWaitTime < DataManager<TimeManager>.GetInstance().GetServerTime();
		}

		// Token: 0x0600C22C RID: 49708 RVA: 0x002E46B1 File Offset: 0x002E2AB1
		private uint _getPersistendTime()
		{
			return Singleton<ActivityDungeonPersistentDataManager>.instance.GetWipeEndTime(DataManager<PlayerBaseData>.GetInstance().RoleID);
		}

		// Token: 0x0600C22D RID: 49709 RVA: 0x002E46C7 File Offset: 0x002E2AC7
		private bool _isVisisted()
		{
			return Singleton<ActivityDungeonPersistentDataManager>.instance.HasWipeEndVisited(DataManager<PlayerBaseData>.GetInstance().RoleID);
		}

		// Token: 0x0600C22E RID: 49710 RVA: 0x002E46DD File Offset: 0x002E2ADD
		private bool _isDeathTowerWipeoutEndTimeChanged()
		{
			return this.mWaitTime < this._getPersistendTime();
		}

		// Token: 0x0600C22F RID: 49711 RVA: 0x002E46ED File Offset: 0x002E2AED
		public bool IsChanged()
		{
			return this.mState == ActivityDungeonDeadTowerUpdateData.eState.onWaitView;
		}

		// Token: 0x0600C230 RID: 49712 RVA: 0x002E46F8 File Offset: 0x002E2AF8
		public void Update(float delta)
		{
			ActivityDungeonDeadTowerUpdateData.eState eState = this.mState;
			if (eState != ActivityDungeonDeadTowerUpdateData.eState.onNone)
			{
				if (eState == ActivityDungeonDeadTowerUpdateData.eState.onWaitEnd)
				{
					if (this._isTimeEnd())
					{
						this.mState = ActivityDungeonDeadTowerUpdateData.eState.onWaitView;
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityDungeonDeadTowerWipeEnd, null, null, null, null);
						DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.ActivityDungeon);
					}
				}
			}
			else if (this._isDeathTowerWipeoutEndTimeChanged())
			{
				this._init();
			}
		}

		// Token: 0x0600C231 RID: 49713 RVA: 0x002E4770 File Offset: 0x002E2B70
		public void Reset()
		{
			if (this.mState == ActivityDungeonDeadTowerUpdateData.eState.onWaitView)
			{
				this.mState = ActivityDungeonDeadTowerUpdateData.eState.onNone;
				Singleton<ActivityDungeonPersistentDataManager>.instance.SetWipeEndTimeVistedAndSave(DataManager<PlayerBaseData>.GetInstance().RoleID);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityDungeonDeadTowerWipeEnd, null, null, null, null);
				DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.ActivityDungeon);
			}
		}

		// Token: 0x04006DF9 RID: 28153
		private bool mLastIsTimeEnd;

		// Token: 0x04006DFA RID: 28154
		private uint mWaitTime;

		// Token: 0x04006DFB RID: 28155
		private ActivityDungeonDeadTowerUpdateData.eState mState;

		// Token: 0x02001390 RID: 5008
		private enum eState
		{
			// Token: 0x04006DFD RID: 28157
			onNone,
			// Token: 0x04006DFE RID: 28158
			onWaitEnd,
			// Token: 0x04006DFF RID: 28159
			onWaitView
		}
	}
}
