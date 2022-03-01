using System;

namespace Protocol
{
	// Token: 0x02000B68 RID: 2920
	[Protocol]
	public class SceneBuySkillPageRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007C4B RID: 31819 RVA: 0x00163170 File Offset: 0x00161570
		public uint GetMsgID()
		{
			return 500721U;
		}

		// Token: 0x06007C4C RID: 31820 RVA: 0x00163177 File Offset: 0x00161577
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007C4D RID: 31821 RVA: 0x0016317F File Offset: 0x0016157F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007C4E RID: 31822 RVA: 0x00163188 File Offset: 0x00161588
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007C4F RID: 31823 RVA: 0x00163198 File Offset: 0x00161598
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007C50 RID: 31824 RVA: 0x001631A8 File Offset: 0x001615A8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007C51 RID: 31825 RVA: 0x001631B8 File Offset: 0x001615B8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007C52 RID: 31826 RVA: 0x001631C8 File Offset: 0x001615C8
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003ADF RID: 15071
		public const uint MsgID = 500721U;

		// Token: 0x04003AE0 RID: 15072
		public uint Sequence;

		// Token: 0x04003AE1 RID: 15073
		public uint result;
	}
}
