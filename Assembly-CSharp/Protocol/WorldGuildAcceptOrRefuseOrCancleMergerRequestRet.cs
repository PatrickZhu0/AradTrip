using System;

namespace Protocol
{
	// Token: 0x020008A4 RID: 2212
	[Protocol]
	public class WorldGuildAcceptOrRefuseOrCancleMergerRequestRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006721 RID: 26401 RVA: 0x00130B20 File Offset: 0x0012EF20
		public uint GetMsgID()
		{
			return 601986U;
		}

		// Token: 0x06006722 RID: 26402 RVA: 0x00130B27 File Offset: 0x0012EF27
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006723 RID: 26403 RVA: 0x00130B2F File Offset: 0x0012EF2F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006724 RID: 26404 RVA: 0x00130B38 File Offset: 0x0012EF38
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
			BaseDLL.encode_int8(buffer, ref pos_, this.opType);
		}

		// Token: 0x06006725 RID: 26405 RVA: 0x00130B56 File Offset: 0x0012EF56
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.opType);
		}

		// Token: 0x06006726 RID: 26406 RVA: 0x00130B74 File Offset: 0x0012EF74
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
			BaseDLL.encode_int8(buffer, ref pos_, this.opType);
		}

		// Token: 0x06006727 RID: 26407 RVA: 0x00130B92 File Offset: 0x0012EF92
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.opType);
		}

		// Token: 0x06006728 RID: 26408 RVA: 0x00130BB0 File Offset: 0x0012EFB0
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 1;
		}

		// Token: 0x04002E19 RID: 11801
		public const uint MsgID = 601986U;

		// Token: 0x04002E1A RID: 11802
		public uint Sequence;

		// Token: 0x04002E1B RID: 11803
		public uint errorCode;

		// Token: 0x04002E1C RID: 11804
		public byte opType;
	}
}
