using System;

namespace Protocol
{
	// Token: 0x02000699 RID: 1689
	[Protocol]
	public class WorldBlessCrystalInfoRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005774 RID: 22388 RVA: 0x0010AE4C File Offset: 0x0010924C
		public uint GetMsgID()
		{
			return 608604U;
		}

		// Token: 0x06005775 RID: 22389 RVA: 0x0010AE53 File Offset: 0x00109253
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005776 RID: 22390 RVA: 0x0010AE5B File Offset: 0x0010925B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005777 RID: 22391 RVA: 0x0010AE64 File Offset: 0x00109264
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.ownBlessCrystalNum);
			BaseDLL.encode_uint64(buffer, ref pos_, this.ownBlessCrystalExp);
		}

		// Token: 0x06005778 RID: 22392 RVA: 0x0010AE90 File Offset: 0x00109290
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ownBlessCrystalNum);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.ownBlessCrystalExp);
		}

		// Token: 0x06005779 RID: 22393 RVA: 0x0010AEBC File Offset: 0x001092BC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.ownBlessCrystalNum);
			BaseDLL.encode_uint64(buffer, ref pos_, this.ownBlessCrystalExp);
		}

		// Token: 0x0600577A RID: 22394 RVA: 0x0010AEE8 File Offset: 0x001092E8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ownBlessCrystalNum);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.ownBlessCrystalExp);
		}

		// Token: 0x0600577B RID: 22395 RVA: 0x0010AF14 File Offset: 0x00109314
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 8;
		}

		// Token: 0x040022C5 RID: 8901
		public const uint MsgID = 608604U;

		// Token: 0x040022C6 RID: 8902
		public uint Sequence;

		// Token: 0x040022C7 RID: 8903
		public uint resCode;

		// Token: 0x040022C8 RID: 8904
		public uint ownBlessCrystalNum;

		// Token: 0x040022C9 RID: 8905
		public ulong ownBlessCrystalExp;
	}
}
