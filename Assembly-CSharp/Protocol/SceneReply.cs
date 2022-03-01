using System;

namespace Protocol
{
	// Token: 0x020006EF RID: 1775
	[Protocol]
	public class SceneReply : IProtocolStream, IGetMsgID
	{
		// Token: 0x060059E9 RID: 23017 RVA: 0x00111ABA File Offset: 0x0010FEBA
		public uint GetMsgID()
		{
			return 500806U;
		}

		// Token: 0x060059EA RID: 23018 RVA: 0x00111AC1 File Offset: 0x0010FEC1
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060059EB RID: 23019 RVA: 0x00111AC9 File Offset: 0x0010FEC9
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060059EC RID: 23020 RVA: 0x00111AD2 File Offset: 0x0010FED2
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.requester);
			BaseDLL.encode_int8(buffer, ref pos_, this.result);
		}

		// Token: 0x060059ED RID: 23021 RVA: 0x00111AFE File Offset: 0x0010FEFE
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.requester);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060059EE RID: 23022 RVA: 0x00111B2A File Offset: 0x0010FF2A
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.requester);
			BaseDLL.encode_int8(buffer, ref pos_, this.result);
		}

		// Token: 0x060059EF RID: 23023 RVA: 0x00111B56 File Offset: 0x0010FF56
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.requester);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060059F0 RID: 23024 RVA: 0x00111B84 File Offset: 0x0010FF84
		public int getLen()
		{
			int num = 0;
			num++;
			num += 8;
			return num + 1;
		}

		// Token: 0x0400246E RID: 9326
		public const uint MsgID = 500806U;

		// Token: 0x0400246F RID: 9327
		public uint Sequence;

		// Token: 0x04002470 RID: 9328
		public byte type;

		// Token: 0x04002471 RID: 9329
		public ulong requester;

		// Token: 0x04002472 RID: 9330
		public byte result;
	}
}
