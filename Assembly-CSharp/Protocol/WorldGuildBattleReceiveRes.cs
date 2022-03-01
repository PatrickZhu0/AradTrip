using System;

namespace Protocol
{
	// Token: 0x02000858 RID: 2136
	[Protocol]
	public class WorldGuildBattleReceiveRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600648A RID: 25738 RVA: 0x0012BC84 File Offset: 0x0012A084
		public uint GetMsgID()
		{
			return 601947U;
		}

		// Token: 0x0600648B RID: 25739 RVA: 0x0012BC8B File Offset: 0x0012A08B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600648C RID: 25740 RVA: 0x0012BC93 File Offset: 0x0012A093
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600648D RID: 25741 RVA: 0x0012BC9C File Offset: 0x0012A09C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.boxId);
		}

		// Token: 0x0600648E RID: 25742 RVA: 0x0012BCBA File Offset: 0x0012A0BA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.boxId);
		}

		// Token: 0x0600648F RID: 25743 RVA: 0x0012BCD8 File Offset: 0x0012A0D8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.boxId);
		}

		// Token: 0x06006490 RID: 25744 RVA: 0x0012BCF6 File Offset: 0x0012A0F6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.boxId);
		}

		// Token: 0x06006491 RID: 25745 RVA: 0x0012BD14 File Offset: 0x0012A114
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 1;
		}

		// Token: 0x04002D09 RID: 11529
		public const uint MsgID = 601947U;

		// Token: 0x04002D0A RID: 11530
		public uint Sequence;

		// Token: 0x04002D0B RID: 11531
		public uint result;

		// Token: 0x04002D0C RID: 11532
		public byte boxId;
	}
}
