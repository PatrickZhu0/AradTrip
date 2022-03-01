using System;
using System.Globalization;
using Network;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020045D6 RID: 17878
	public class TimeManager : DataManager<TimeManager>
	{
		// Token: 0x0601920E RID: 102926 RVA: 0x007EF92B File Offset: 0x007EDD2B
		public uint GetServerTime()
		{
			return this.m_nUnixTime + (uint)(Time.realtimeSinceStartup - this.m_fStartTime);
		}

		// Token: 0x0601920F RID: 102927 RVA: 0x007EF941 File Offset: 0x007EDD41
		public double GetServerDoubleTime()
		{
			return this.m_dUnixTime + (double)(Time.realtimeSinceStartup - this.m_fStartTime);
		}

		// Token: 0x06019210 RID: 102928 RVA: 0x007EF958 File Offset: 0x007EDD58
		public string GetTimeT()
		{
			return Function.ConvertIntDateTime(this.GetServerTime()).ToString("T", DateTimeFormatInfo.InvariantInfo);
		}

		// Token: 0x06019211 RID: 102929 RVA: 0x007EF984 File Offset: 0x007EDD84
		public override void Initialize()
		{
		}

		// Token: 0x06019212 RID: 102930 RVA: 0x007EF986 File Offset: 0x007EDD86
		public override void Clear()
		{
		}

		// Token: 0x06019213 RID: 102931 RVA: 0x007EF988 File Offset: 0x007EDD88
		public override void OnApplicationStart()
		{
		}

		// Token: 0x06019214 RID: 102932 RVA: 0x007EF98A File Offset: 0x007EDD8A
		public override void OnApplicationQuit()
		{
		}

		// Token: 0x06019215 RID: 102933 RVA: 0x007EF98C File Offset: 0x007EDD8C
		public void OnRecvGateSyncServerTime(MsgDATA msgData)
		{
			GateSyncServerTime gateSyncServerTime = new GateSyncServerTime();
			gateSyncServerTime.decode(msgData.bytes);
			this.m_fStartTime = Time.realtimeSinceStartup;
			this.m_nUnixTime = gateSyncServerTime.time;
			this.m_dUnixTime = this.m_nUnixTime;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ServerTimeChanged, null, null, null, null);
		}

		// Token: 0x04012022 RID: 73762
		private float m_fStartTime;

		// Token: 0x04012023 RID: 73763
		private uint m_nUnixTime;

		// Token: 0x04012024 RID: 73764
		private double m_dUnixTime;
	}
}
