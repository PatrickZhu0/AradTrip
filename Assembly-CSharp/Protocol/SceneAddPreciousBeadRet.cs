using System;

namespace Protocol
{
	// Token: 0x0200090A RID: 2314
	[Protocol]
	public class SceneAddPreciousBeadRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060069CA RID: 27082 RVA: 0x00137544 File Offset: 0x00135944
		public uint GetMsgID()
		{
			return 500972U;
		}

		// Token: 0x060069CB RID: 27083 RVA: 0x0013754B File Offset: 0x0013594B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060069CC RID: 27084 RVA: 0x00137553 File Offset: 0x00135953
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060069CD RID: 27085 RVA: 0x0013755C File Offset: 0x0013595C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.preciousBeadId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
		}

		// Token: 0x060069CE RID: 27086 RVA: 0x00137588 File Offset: 0x00135988
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preciousBeadId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
		}

		// Token: 0x060069CF RID: 27087 RVA: 0x001375B4 File Offset: 0x001359B4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.preciousBeadId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
		}

		// Token: 0x060069D0 RID: 27088 RVA: 0x001375E0 File Offset: 0x001359E0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preciousBeadId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
		}

		// Token: 0x060069D1 RID: 27089 RVA: 0x0013760C File Offset: 0x00135A0C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 8;
		}

		// Token: 0x04002FF6 RID: 12278
		public const uint MsgID = 500972U;

		// Token: 0x04002FF7 RID: 12279
		public uint Sequence;

		// Token: 0x04002FF8 RID: 12280
		public uint code;

		// Token: 0x04002FF9 RID: 12281
		public uint preciousBeadId;

		// Token: 0x04002FFA RID: 12282
		public ulong itemUid;
	}
}
