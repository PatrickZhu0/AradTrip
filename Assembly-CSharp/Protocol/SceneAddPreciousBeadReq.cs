using System;

namespace Protocol
{
	// Token: 0x02000909 RID: 2313
	[Protocol]
	public class SceneAddPreciousBeadReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060069C1 RID: 27073 RVA: 0x00137494 File Offset: 0x00135894
		public uint GetMsgID()
		{
			return 500971U;
		}

		// Token: 0x060069C2 RID: 27074 RVA: 0x0013749B File Offset: 0x0013589B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060069C3 RID: 27075 RVA: 0x001374A3 File Offset: 0x001358A3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060069C4 RID: 27076 RVA: 0x001374AC File Offset: 0x001358AC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.preciousBeadUid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
		}

		// Token: 0x060069C5 RID: 27077 RVA: 0x001374CA File Offset: 0x001358CA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.preciousBeadUid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
		}

		// Token: 0x060069C6 RID: 27078 RVA: 0x001374E8 File Offset: 0x001358E8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.preciousBeadUid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
		}

		// Token: 0x060069C7 RID: 27079 RVA: 0x00137506 File Offset: 0x00135906
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.preciousBeadUid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
		}

		// Token: 0x060069C8 RID: 27080 RVA: 0x00137524 File Offset: 0x00135924
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 8;
		}

		// Token: 0x04002FF2 RID: 12274
		public const uint MsgID = 500971U;

		// Token: 0x04002FF3 RID: 12275
		public uint Sequence;

		// Token: 0x04002FF4 RID: 12276
		public ulong preciousBeadUid;

		// Token: 0x04002FF5 RID: 12277
		public ulong itemUid;
	}
}
