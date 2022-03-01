using System;

namespace Protocol
{
	// Token: 0x02000A0F RID: 2575
	[Protocol]
	public class WorldMonopolyRollRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600724C RID: 29260 RVA: 0x0014B4D4 File Offset: 0x001498D4
		public uint GetMsgID()
		{
			return 610206U;
		}

		// Token: 0x0600724D RID: 29261 RVA: 0x0014B4DB File Offset: 0x001498DB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600724E RID: 29262 RVA: 0x0014B4E3 File Offset: 0x001498E3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600724F RID: 29263 RVA: 0x0014B4EC File Offset: 0x001498EC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.step);
		}

		// Token: 0x06007250 RID: 29264 RVA: 0x0014B50A File Offset: 0x0014990A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.step);
		}

		// Token: 0x06007251 RID: 29265 RVA: 0x0014B528 File Offset: 0x00149928
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.step);
		}

		// Token: 0x06007252 RID: 29266 RVA: 0x0014B546 File Offset: 0x00149946
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.step);
		}

		// Token: 0x06007253 RID: 29267 RVA: 0x0014B564 File Offset: 0x00149964
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003489 RID: 13449
		public const uint MsgID = 610206U;

		// Token: 0x0400348A RID: 13450
		public uint Sequence;

		// Token: 0x0400348B RID: 13451
		public uint errorCode;

		// Token: 0x0400348C RID: 13452
		public uint step;
	}
}
