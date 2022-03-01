using System;

namespace GameClient
{
	// Token: 0x0200184B RID: 6219
	public class LimitTimeActivityCheckComponent : IDisposable
	{
		// Token: 0x0600F428 RID: 62504 RVA: 0x0041F198 File Offset: 0x0041D598
		public void InitData(IActivity activity)
		{
			this.mActivityData = activity;
		}

		// Token: 0x0600F429 RID: 62505 RVA: 0x0041F1A1 File Offset: 0x0041D5A1
		public void Checked(IActivity activity)
		{
			if (!this.mIsChecked)
			{
				this.mIsChecked = true;
				this.SaveCurrTimeStamp();
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeUpdate, activity, null, null, null);
			}
		}

		// Token: 0x0600F42A RID: 62506 RVA: 0x0041F1CE File Offset: 0x0041D5CE
		public bool IsChecked()
		{
			this.mIsChecked = this.HasRedPointFirstShowedToday();
			return this.mIsChecked;
		}

		// Token: 0x0600F42B RID: 62507 RVA: 0x0041F1E2 File Offset: 0x0041D5E2
		public void Dispose()
		{
			this.mIsChecked = false;
		}

		// Token: 0x0600F42C RID: 62508 RVA: 0x0041F1EC File Offset: 0x0041D5EC
		private bool HasRedPointFirstShowedToday()
		{
			int tempTimeStamp = this.GetTempTimeStamp();
			int refreshTimeStamp = this.GetRefreshTimeStamp();
			return tempTimeStamp >= refreshTimeStamp;
		}

		// Token: 0x0600F42D RID: 62509 RVA: 0x0041F211 File Offset: 0x0041D611
		private int GetTempTimeStamp()
		{
			return Singleton<PlayerPrefsManager>.GetInstance().GetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.LimitTimeActivityTabRedPoint, new object[]
			{
				string.Format("ActivityID{0}", (int)this.mActivityData.GetId())
			});
		}

		// Token: 0x0600F42E RID: 62510 RVA: 0x0041F244 File Offset: 0x0041D644
		public void SaveCurrTimeStamp()
		{
			int serverTime = (int)DataManager<TimeManager>.GetInstance().GetServerTime();
			Singleton<PlayerPrefsManager>.GetInstance().SetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.LimitTimeActivityTabRedPoint, serverTime, new object[]
			{
				string.Format("ActivityID{0}", (int)this.mActivityData.GetId())
			});
		}

		// Token: 0x0600F42F RID: 62511 RVA: 0x0041F28C File Offset: 0x0041D68C
		private int GetRefreshTimeStamp()
		{
			int currTimeHour = this.GetCurrTimeHour();
			DateTime currDateTime = this.GetCurrDateTime();
			DateTime time;
			if (this.m_RedPointUpdateHour > currTimeHour)
			{
				time = Function.GetYesterdayGivenHourTime(this.m_RedPointUpdateHour);
			}
			else
			{
				time = Function.GetTodayGivenHourTime(this.m_RedPointUpdateHour);
			}
			return Convert.ToInt32(Function.ConvertDateTimeInt(time));
		}

		// Token: 0x0600F430 RID: 62512 RVA: 0x0041F2E0 File Offset: 0x0041D6E0
		private int GetCurrTimeHour()
		{
			double serverDoubleTime = DataManager<TimeManager>.GetInstance().GetServerDoubleTime();
			return Function.ConvertIntDateTime(serverDoubleTime).Hour;
		}

		// Token: 0x0600F431 RID: 62513 RVA: 0x0041F308 File Offset: 0x0041D708
		private DateTime GetCurrDateTime()
		{
			double serverDoubleTime = DataManager<TimeManager>.GetInstance().GetServerDoubleTime();
			return Function.ConvertIntDateTime(serverDoubleTime);
		}

		// Token: 0x04009609 RID: 38409
		private bool mIsChecked;

		// Token: 0x0400960A RID: 38410
		private int m_RedPointUpdateHour = 6;

		// Token: 0x0400960B RID: 38411
		private IActivity mActivityData;
	}
}
