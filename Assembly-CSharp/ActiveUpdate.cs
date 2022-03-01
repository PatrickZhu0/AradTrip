using System;
using GameClient;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200000D RID: 13
public class ActiveUpdate : MonoBehaviour
{
	// Token: 0x0600004C RID: 76 RVA: 0x0000604C File Offset: 0x0000444C
	private void OnSevenDayTimeChanged(uint time1, uint time2, uint time3, double recvTime)
	{
		this.time1 = time1;
		this.time2 = time2;
		this.time3 = time3;
		this.recvTime = recvTime;
	}

	// Token: 0x0600004D RID: 77 RVA: 0x0000606C File Offset: 0x0000446C
	private void Start()
	{
		ActiveManager instance = DataManager<ActiveManager>.GetInstance();
		instance.onSevenDayTimeChanged = (ActiveManager.OnSevenDayTimeChanged)Delegate.Combine(instance.onSevenDayTimeChanged, new ActiveManager.OnSevenDayTimeChanged(this.OnSevenDayTimeChanged));
		DataManager<ActiveManager>.GetInstance().SendSevenDayTimeReq();
		if (this.text != null && DataManager<ActiveManager>.GetInstance().ActiveDictionary.ContainsKey(this.iTemplateID))
		{
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().ActiveDictionary[this.iTemplateID];
			if (activeData != null && this.funcname != null && this.fTickInterval > 0f)
			{
				base.InvokeRepeating(this.funcname, 0f, this.fTickInterval);
			}
		}
		else if (this.text != null && this.funcname != null && this.fTickInterval > 0f)
		{
			base.InvokeRepeating(this.funcname, 0f, this.fTickInterval);
		}
	}

	// Token: 0x0600004E RID: 78 RVA: 0x0000616C File Offset: 0x0000456C
	private void OnUpdateCloseTime()
	{
		double num = 10.0;
		if (!double.TryParse(TR.Value("seven_day_last_time"), out num))
		{
			base.CancelInvoke("OnUpdateCloseTime");
			return;
		}
		RoleInfo[] roleinfo = ClientApplication.playerinfo.roleinfo;
		if (roleinfo != null)
		{
			for (int i = 0; i < roleinfo.Length; i++)
			{
				if (roleinfo[i].roleId == DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
					uint num2 = (this.time1 + (uint)this.recvTime <= serverTime) ? 0U : (this.time1 + (uint)this.recvTime - serverTime);
					uint num3 = num2 / 86400U;
					uint num4 = num2 / 3600U % 24U;
					uint num5 = num2 / 60U % 60U;
					uint num6 = num2 % 60U;
					this.text.text = string.Format(this.formatTimeString, new object[]
					{
						num3,
						num4,
						num5,
						num6
					});
					break;
				}
			}
		}
	}

	// Token: 0x0600004F RID: 79 RVA: 0x0000628C File Offset: 0x0000468C
	private void OnUpdateAwardCloseTime()
	{
		double num = 10.0;
		if (!double.TryParse(TR.Value("seven_day_award_last_time"), out num))
		{
			base.CancelInvoke("OnUpdateAwardCloseTime");
			return;
		}
		RoleInfo[] roleinfo = ClientApplication.playerinfo.roleinfo;
		if (roleinfo != null)
		{
			for (int i = 0; i < roleinfo.Length; i++)
			{
				if (roleinfo[i].roleId == DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
					uint num2 = (this.time2 + (uint)this.recvTime <= serverTime) ? 0U : (this.time2 + (uint)this.recvTime - serverTime);
					uint num3 = num2 / 86400U;
					uint num4 = num2 / 3600U % 24U;
					uint num5 = num2 / 60U % 60U;
					uint num6 = num2 % 60U;
					this.text.text = string.Format(this.formatTimeString, new object[]
					{
						num3,
						num4,
						num5,
						num6
					});
					break;
				}
			}
		}
	}

	// Token: 0x06000050 RID: 80 RVA: 0x000063AC File Offset: 0x000047AC
	private void OnUpdateDailyChargeReset()
	{
		uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
		uint num = (this.time3 + (uint)this.recvTime <= serverTime) ? 0U : (this.time3 + (uint)this.recvTime - serverTime);
		uint num2 = num / 86400U;
		uint num3 = num / 3600U % 24U;
		uint num4 = num / 60U % 60U;
		uint num5 = num % 60U;
		this.text.text = string.Format(this.formatTimeString, new object[]
		{
			num2,
			num3,
			num4,
			num5
		});
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00006454 File Offset: 0x00004854
	private void OnLineTimeAccumulate()
	{
		if (DataManager<ActiveManager>.GetInstance().ActiveDictionary.ContainsKey(this.iTemplateID))
		{
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().ActiveDictionary[this.iTemplateID];
			if (activeData != null)
			{
				ActiveManager.ActiveMainUpdateKey activeMainUpdateKey = null;
				for (int i = 0; i < activeData.updateMainKeys.Count; i++)
				{
					if (activeData.updateMainKeys[i].key == this.key)
					{
						activeMainUpdateKey = activeData.updateMainKeys[i];
						break;
					}
				}
				if (activeMainUpdateKey == null)
				{
					return;
				}
				int templateUpdateValue = DataManager<ActiveManager>.GetInstance().GetTemplateUpdateValue(this.iTemplateID, activeMainUpdateKey.key, 0);
				double num = DataManager<TimeManager>.GetInstance().GetServerTime() - activeMainUpdateKey.fRecievedTime;
				DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds(num + (double)templateUpdateValue - 28800.0);
				this.text.text = string.Format(activeMainUpdateKey.content, dateTime.ToString("HH:mm:ss"));
			}
		}
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00006574 File Offset: 0x00004974
	private void OnLineTimeAccumulateShowMinutes()
	{
		if (DataManager<ActiveManager>.GetInstance().ActiveDictionary.ContainsKey(this.iTemplateID))
		{
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().ActiveDictionary[this.iTemplateID];
			if (activeData != null)
			{
				ActiveManager.ActiveMainUpdateKey activeMainUpdateKey = null;
				for (int i = 0; i < activeData.updateMainKeys.Count; i++)
				{
					if (activeData.updateMainKeys[i].key == this.key)
					{
						activeMainUpdateKey = activeData.updateMainKeys[i];
						break;
					}
				}
				if (activeMainUpdateKey == null)
				{
					return;
				}
				int templateUpdateValue = DataManager<ActiveManager>.GetInstance().GetTemplateUpdateValue(this.iTemplateID, activeMainUpdateKey.key, 0);
				double num = DataManager<TimeManager>.GetInstance().GetServerTime() - activeMainUpdateKey.fRecievedTime;
				DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds(num + (double)templateUpdateValue - 28800.0);
				DateTime dateTime2 = new DateTime(1970, 1, 1);
				TimeSpan timeSpan = new TimeSpan(dateTime.Ticks - dateTime2.Ticks);
				int num2 = (int)Math.Floor(timeSpan.TotalMinutes);
				if (num2 >= this.mTotalNum)
				{
					num2 = this.mTotalNum;
				}
				this.text.text = string.Format(this.formatTimeString, num2, this.mTotalNum);
			}
		}
	}

	// Token: 0x06000053 RID: 83 RVA: 0x000066DF File Offset: 0x00004ADF
	public void SetTotlaNum(int totalNum)
	{
		this.mTotalNum = totalNum;
	}

	// Token: 0x06000054 RID: 84 RVA: 0x000066E8 File Offset: 0x00004AE8
	private void OnDestroy()
	{
		ActiveManager instance = DataManager<ActiveManager>.GetInstance();
		instance.onSevenDayTimeChanged = (ActiveManager.OnSevenDayTimeChanged)Delegate.Remove(instance.onSevenDayTimeChanged, new ActiveManager.OnSevenDayTimeChanged(this.OnSevenDayTimeChanged));
	}

	// Token: 0x04000025 RID: 37
	public int iTemplateID;

	// Token: 0x04000026 RID: 38
	public string key;

	// Token: 0x04000027 RID: 39
	public float fTickInterval;

	// Token: 0x04000028 RID: 40
	public string funcname;

	// Token: 0x04000029 RID: 41
	public Text text;

	// Token: 0x0400002A RID: 42
	public string formatTimeString = "{0:D2}天{1:D2}时{2:D2}分{3:D2}秒";

	// Token: 0x0400002B RID: 43
	private int mTotalNum;

	// Token: 0x0400002C RID: 44
	private uint time1;

	// Token: 0x0400002D RID: 45
	private uint time2;

	// Token: 0x0400002E RID: 46
	private uint time3;

	// Token: 0x0400002F RID: 47
	private double recvTime;
}
