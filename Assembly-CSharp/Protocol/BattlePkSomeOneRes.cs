using System;

namespace Protocol
{
	// Token: 0x020006FA RID: 1786
	[Protocol]
	public class BattlePkSomeOneRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005A46 RID: 23110 RVA: 0x00112BB4 File Offset: 0x00110FB4
		public uint GetMsgID()
		{
			return 2200008U;
		}

		// Token: 0x06005A47 RID: 23111 RVA: 0x00112BBB File Offset: 0x00110FBB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005A48 RID: 23112 RVA: 0x00112BC3 File Offset: 0x00110FC3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005A49 RID: 23113 RVA: 0x00112BCC File Offset: 0x00110FCC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.dstId);
		}

		// Token: 0x06005A4A RID: 23114 RVA: 0x00112BF8 File Offset: 0x00110FF8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.dstId);
		}

		// Token: 0x06005A4B RID: 23115 RVA: 0x00112C24 File Offset: 0x00111024
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.dstId);
		}

		// Token: 0x06005A4C RID: 23116 RVA: 0x00112C50 File Offset: 0x00111050
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.dstId);
		}

		// Token: 0x06005A4D RID: 23117 RVA: 0x00112C7C File Offset: 0x0011107C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			return num + 8;
		}

		// Token: 0x040024A3 RID: 9379
		public const uint MsgID = 2200008U;

		// Token: 0x040024A4 RID: 9380
		public uint Sequence;

		// Token: 0x040024A5 RID: 9381
		public uint retCode;

		// Token: 0x040024A6 RID: 9382
		public ulong roleId;

		// Token: 0x040024A7 RID: 9383
		public ulong dstId;
	}
}
