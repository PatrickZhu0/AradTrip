using System;

namespace Protocol
{
	// Token: 0x02000C72 RID: 3186
	[Protocol]
	public class WorldReportMasterDailyTaskReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600840A RID: 33802 RVA: 0x0017292E File Offset: 0x00170D2E
		public uint GetMsgID()
		{
			return 601761U;
		}

		// Token: 0x0600840B RID: 33803 RVA: 0x00172935 File Offset: 0x00170D35
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600840C RID: 33804 RVA: 0x0017293D File Offset: 0x00170D3D
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600840D RID: 33805 RVA: 0x00172946 File Offset: 0x00170D46
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.masterId);
		}

		// Token: 0x0600840E RID: 33806 RVA: 0x00172956 File Offset: 0x00170D56
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.masterId);
		}

		// Token: 0x0600840F RID: 33807 RVA: 0x00172966 File Offset: 0x00170D66
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.masterId);
		}

		// Token: 0x06008410 RID: 33808 RVA: 0x00172976 File Offset: 0x00170D76
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.masterId);
		}

		// Token: 0x06008411 RID: 33809 RVA: 0x00172988 File Offset: 0x00170D88
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04003F19 RID: 16153
		public const uint MsgID = 601761U;

		// Token: 0x04003F1A RID: 16154
		public uint Sequence;

		// Token: 0x04003F1B RID: 16155
		public ulong masterId;
	}
}
