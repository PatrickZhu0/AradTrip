using System;

namespace Protocol
{
	// Token: 0x02000C75 RID: 3189
	[Protocol]
	public class WorldReceiveMasterDailyTaskRewardRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008425 RID: 33829 RVA: 0x00172AC8 File Offset: 0x00170EC8
		public uint GetMsgID()
		{
			return 601766U;
		}

		// Token: 0x06008426 RID: 33830 RVA: 0x00172ACF File Offset: 0x00170ECF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008427 RID: 33831 RVA: 0x00172AD7 File Offset: 0x00170ED7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008428 RID: 33832 RVA: 0x00172AE0 File Offset: 0x00170EE0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06008429 RID: 33833 RVA: 0x00172AF0 File Offset: 0x00170EF0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x0600842A RID: 33834 RVA: 0x00172B00 File Offset: 0x00170F00
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x0600842B RID: 33835 RVA: 0x00172B10 File Offset: 0x00170F10
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x0600842C RID: 33836 RVA: 0x00172B20 File Offset: 0x00170F20
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003F23 RID: 16163
		public const uint MsgID = 601766U;

		// Token: 0x04003F24 RID: 16164
		public uint Sequence;

		// Token: 0x04003F25 RID: 16165
		public uint code;
	}
}
