using System;

namespace Protocol
{
	// Token: 0x020008EA RID: 2282
	[Protocol]
	public class SceneEquipStrengthen : IProtocolStream, IGetMsgID
	{
		// Token: 0x060068AA RID: 26794 RVA: 0x00135C95 File Offset: 0x00134095
		public uint GetMsgID()
		{
			return 500920U;
		}

		// Token: 0x060068AB RID: 26795 RVA: 0x00135C9C File Offset: 0x0013409C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060068AC RID: 26796 RVA: 0x00135CA4 File Offset: 0x001340A4
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060068AD RID: 26797 RVA: 0x00135CAD File Offset: 0x001340AD
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.euqipUid);
			BaseDLL.encode_int8(buffer, ref pos_, this.useUnbreak);
			BaseDLL.encode_uint64(buffer, ref pos_, this.strTickt);
		}

		// Token: 0x060068AE RID: 26798 RVA: 0x00135CD9 File Offset: 0x001340D9
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.euqipUid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.useUnbreak);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.strTickt);
		}

		// Token: 0x060068AF RID: 26799 RVA: 0x00135D05 File Offset: 0x00134105
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.euqipUid);
			BaseDLL.encode_int8(buffer, ref pos_, this.useUnbreak);
			BaseDLL.encode_uint64(buffer, ref pos_, this.strTickt);
		}

		// Token: 0x060068B0 RID: 26800 RVA: 0x00135D31 File Offset: 0x00134131
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.euqipUid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.useUnbreak);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.strTickt);
		}

		// Token: 0x060068B1 RID: 26801 RVA: 0x00135D60 File Offset: 0x00134160
		public int getLen()
		{
			int num = 0;
			num += 8;
			num++;
			return num + 8;
		}

		// Token: 0x04002F7A RID: 12154
		public const uint MsgID = 500920U;

		// Token: 0x04002F7B RID: 12155
		public uint Sequence;

		// Token: 0x04002F7C RID: 12156
		public ulong euqipUid;

		// Token: 0x04002F7D RID: 12157
		public byte useUnbreak;

		// Token: 0x04002F7E RID: 12158
		public ulong strTickt;
	}
}
