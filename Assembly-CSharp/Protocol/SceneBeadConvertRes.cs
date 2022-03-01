using System;

namespace Protocol
{
	// Token: 0x020009A5 RID: 2469
	[Protocol]
	public class SceneBeadConvertRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006F1C RID: 28444 RVA: 0x001412E0 File Offset: 0x0013F6E0
		public uint GetMsgID()
		{
			return 501091U;
		}

		// Token: 0x06006F1D RID: 28445 RVA: 0x001412E7 File Offset: 0x0013F6E7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006F1E RID: 28446 RVA: 0x001412EF File Offset: 0x0013F6EF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006F1F RID: 28447 RVA: 0x001412F8 File Offset: 0x0013F6F8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06006F20 RID: 28448 RVA: 0x00141308 File Offset: 0x0013F708
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06006F21 RID: 28449 RVA: 0x00141318 File Offset: 0x0013F718
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06006F22 RID: 28450 RVA: 0x00141328 File Offset: 0x0013F728
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06006F23 RID: 28451 RVA: 0x00141338 File Offset: 0x0013F738
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400326A RID: 12906
		public const uint MsgID = 501091U;

		// Token: 0x0400326B RID: 12907
		public uint Sequence;

		// Token: 0x0400326C RID: 12908
		public uint retCode;
	}
}
