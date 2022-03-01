using System;

namespace Protocol
{
	// Token: 0x0200089E RID: 2206
	[Protocol]
	public class WorldGuildMergerRequestOperatorRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060066EB RID: 26347 RVA: 0x00130728 File Offset: 0x0012EB28
		public uint GetMsgID()
		{
			return 601980U;
		}

		// Token: 0x060066EC RID: 26348 RVA: 0x0013072F File Offset: 0x0012EB2F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060066ED RID: 26349 RVA: 0x00130737 File Offset: 0x0012EB37
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060066EE RID: 26350 RVA: 0x00130740 File Offset: 0x0012EB40
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
			BaseDLL.encode_int8(buffer, ref pos_, this.opType);
		}

		// Token: 0x060066EF RID: 26351 RVA: 0x0013075E File Offset: 0x0012EB5E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.opType);
		}

		// Token: 0x060066F0 RID: 26352 RVA: 0x0013077C File Offset: 0x0012EB7C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
			BaseDLL.encode_int8(buffer, ref pos_, this.opType);
		}

		// Token: 0x060066F1 RID: 26353 RVA: 0x0013079A File Offset: 0x0012EB9A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.opType);
		}

		// Token: 0x060066F2 RID: 26354 RVA: 0x001307B8 File Offset: 0x0012EBB8
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 1;
		}

		// Token: 0x04002E07 RID: 11783
		public const uint MsgID = 601980U;

		// Token: 0x04002E08 RID: 11784
		public uint Sequence;

		// Token: 0x04002E09 RID: 11785
		public uint errorCode;

		// Token: 0x04002E0A RID: 11786
		public byte opType;
	}
}
