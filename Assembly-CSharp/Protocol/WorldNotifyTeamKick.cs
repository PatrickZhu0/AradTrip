using System;

namespace Protocol
{
	// Token: 0x02000BA4 RID: 2980
	[Protocol]
	public class WorldNotifyTeamKick : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007E1F RID: 32287 RVA: 0x00165F4C File Offset: 0x0016434C
		public uint GetMsgID()
		{
			return 601660U;
		}

		// Token: 0x06007E20 RID: 32288 RVA: 0x00165F53 File Offset: 0x00164353
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007E21 RID: 32289 RVA: 0x00165F5B File Offset: 0x0016435B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007E22 RID: 32290 RVA: 0x00165F64 File Offset: 0x00164364
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.endTime);
		}

		// Token: 0x06007E23 RID: 32291 RVA: 0x00165F74 File Offset: 0x00164374
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.endTime);
		}

		// Token: 0x06007E24 RID: 32292 RVA: 0x00165F84 File Offset: 0x00164384
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.endTime);
		}

		// Token: 0x06007E25 RID: 32293 RVA: 0x00165F94 File Offset: 0x00164394
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.endTime);
		}

		// Token: 0x06007E26 RID: 32294 RVA: 0x00165FA4 File Offset: 0x001643A4
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04003BBF RID: 15295
		public const uint MsgID = 601660U;

		// Token: 0x04003BC0 RID: 15296
		public uint Sequence;

		// Token: 0x04003BC1 RID: 15297
		public ulong endTime;
	}
}
