using System;

namespace Protocol
{
	// Token: 0x02000944 RID: 2372
	[Protocol]
	public class SceneEquipTransferReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006BC8 RID: 27592 RVA: 0x0013AB40 File Offset: 0x00138F40
		public uint GetMsgID()
		{
			return 501017U;
		}

		// Token: 0x06006BC9 RID: 27593 RVA: 0x0013AB47 File Offset: 0x00138F47
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006BCA RID: 27594 RVA: 0x0013AB4F File Offset: 0x00138F4F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006BCB RID: 27595 RVA: 0x0013AB58 File Offset: 0x00138F58
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.equid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.transferId);
		}

		// Token: 0x06006BCC RID: 27596 RVA: 0x0013AB76 File Offset: 0x00138F76
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.equid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.transferId);
		}

		// Token: 0x06006BCD RID: 27597 RVA: 0x0013AB94 File Offset: 0x00138F94
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.equid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.transferId);
		}

		// Token: 0x06006BCE RID: 27598 RVA: 0x0013ABB2 File Offset: 0x00138FB2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.equid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.transferId);
		}

		// Token: 0x06006BCF RID: 27599 RVA: 0x0013ABD0 File Offset: 0x00138FD0
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 8;
		}

		// Token: 0x040030D0 RID: 12496
		public const uint MsgID = 501017U;

		// Token: 0x040030D1 RID: 12497
		public uint Sequence;

		// Token: 0x040030D2 RID: 12498
		public ulong equid;

		// Token: 0x040030D3 RID: 12499
		public ulong transferId;
	}
}
