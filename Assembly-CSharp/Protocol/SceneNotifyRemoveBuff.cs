using System;

namespace Protocol
{
	// Token: 0x02000B5F RID: 2911
	[Protocol]
	public class SceneNotifyRemoveBuff : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007BFA RID: 31738 RVA: 0x00162C6C File Offset: 0x0016106C
		public uint GetMsgID()
		{
			return 500712U;
		}

		// Token: 0x06007BFB RID: 31739 RVA: 0x00162C73 File Offset: 0x00161073
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007BFC RID: 31740 RVA: 0x00162C7B File Offset: 0x0016107B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007BFD RID: 31741 RVA: 0x00162C84 File Offset: 0x00161084
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffId);
		}

		// Token: 0x06007BFE RID: 31742 RVA: 0x00162C94 File Offset: 0x00161094
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffId);
		}

		// Token: 0x06007BFF RID: 31743 RVA: 0x00162CA4 File Offset: 0x001610A4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffId);
		}

		// Token: 0x06007C00 RID: 31744 RVA: 0x00162CB4 File Offset: 0x001610B4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffId);
		}

		// Token: 0x06007C01 RID: 31745 RVA: 0x00162CC4 File Offset: 0x001610C4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003AC0 RID: 15040
		public const uint MsgID = 500712U;

		// Token: 0x04003AC1 RID: 15041
		public uint Sequence;

		// Token: 0x04003AC2 RID: 15042
		public uint buffId;
	}
}
