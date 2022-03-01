using System;

namespace Protocol
{
	// Token: 0x02000999 RID: 2457
	[Protocol]
	public class SceneEquipInscriptionExtractReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006EB3 RID: 28339 RVA: 0x001401EC File Offset: 0x0013E5EC
		public uint GetMsgID()
		{
			return 501079U;
		}

		// Token: 0x06006EB4 RID: 28340 RVA: 0x001401F3 File Offset: 0x0013E5F3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006EB5 RID: 28341 RVA: 0x001401FB File Offset: 0x0013E5FB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006EB6 RID: 28342 RVA: 0x00140204 File Offset: 0x0013E604
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			BaseDLL.encode_uint32(buffer, ref pos_, this.inscriptionId);
		}

		// Token: 0x06006EB7 RID: 28343 RVA: 0x00140230 File Offset: 0x0013E630
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.inscriptionId);
		}

		// Token: 0x06006EB8 RID: 28344 RVA: 0x0014025C File Offset: 0x0013E65C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			BaseDLL.encode_uint32(buffer, ref pos_, this.inscriptionId);
		}

		// Token: 0x06006EB9 RID: 28345 RVA: 0x00140288 File Offset: 0x0013E688
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.inscriptionId);
		}

		// Token: 0x06006EBA RID: 28346 RVA: 0x001402B4 File Offset: 0x0013E6B4
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003229 RID: 12841
		public const uint MsgID = 501079U;

		// Token: 0x0400322A RID: 12842
		public uint Sequence;

		// Token: 0x0400322B RID: 12843
		public ulong guid;

		// Token: 0x0400322C RID: 12844
		public uint index;

		// Token: 0x0400322D RID: 12845
		public uint inscriptionId;
	}
}
