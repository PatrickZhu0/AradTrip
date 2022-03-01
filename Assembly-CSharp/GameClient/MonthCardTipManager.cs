using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001947 RID: 6471
	public class MonthCardTipManager : Singleton<MonthCardTipManager>
	{
		// Token: 0x0600FBBA RID: 64442 RVA: 0x004500AB File Offset: 0x0044E4AB
		public override void Init()
		{
		}

		// Token: 0x0600FBBB RID: 64443 RVA: 0x004500AD File Offset: 0x0044E4AD
		public void SetPlayerKey(ulong roleID)
		{
			this.keyName = "HasShowMonthCardTip_" + roleID;
		}

		// Token: 0x0600FBBC RID: 64444 RVA: 0x004500C8 File Offset: 0x0044E4C8
		public void TryOpenMonthCardTipFrameByCond(ulong roleID)
		{
			this.SetPlayerKey(roleID);
			if (this.ConfigHasOpened())
			{
				return;
			}
			if (DataManager<PlayerBaseData>.GetInstance().Level == 1)
			{
				return;
			}
			int fatigue = (int)DataManager<PlayerBaseData>.GetInstance().fatigue;
			int monthCardLv = (int)DataManager<PlayerBaseData>.GetInstance().MonthCardLv;
			int serverTime = (int)DataManager<TimeManager>.GetInstance().GetServerTime();
			int num = monthCardLv - serverTime;
			if (num <= 0 && fatigue == 0)
			{
				if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MonthCardTipFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<MonthCardTipFrame>(FrameLayer.Middle, null, string.Empty);
				}
				this.SetConfig(this.keyName, 1);
			}
			else
			{
				this.SetConfig(this.keyName, 0);
			}
		}

		// Token: 0x0600FBBD RID: 64445 RVA: 0x0045016C File Offset: 0x0044E56C
		private bool ConfigHasOpened()
		{
			if (!PlayerPrefs.HasKey(this.keyName))
			{
				this.SetConfig(this.keyName, 0);
				return false;
			}
			return PlayerPrefs.GetInt(this.keyName) >= 1;
		}

		// Token: 0x0600FBBE RID: 64446 RVA: 0x004501A5 File Offset: 0x0044E5A5
		private void SetConfig(string keyName, int value)
		{
			PlayerPrefs.SetInt(keyName, value);
		}

		// Token: 0x0600FBBF RID: 64447 RVA: 0x004501AE File Offset: 0x0044E5AE
		public void SetTrueConfig(ulong roleID)
		{
			this.SetPlayerKey(roleID);
			this.SetConfig(this.keyName, 1);
		}

		// Token: 0x04009D44 RID: 40260
		private string keyName = "-";
	}
}
