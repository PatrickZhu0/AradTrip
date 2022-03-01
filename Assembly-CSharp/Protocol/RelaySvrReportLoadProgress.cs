using System;

namespace Protocol
{
	// Token: 0x02000AA2 RID: 2722
	[Protocol]
	public class RelaySvrReportLoadProgress : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007693 RID: 30355 RVA: 0x00156D05 File Offset: 0x00155105
		public uint GetMsgID()
		{
			return 1300015U;
		}

		// Token: 0x06007694 RID: 30356 RVA: 0x00156D0C File Offset: 0x0015510C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007695 RID: 30357 RVA: 0x00156D14 File Offset: 0x00155114
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007696 RID: 30358 RVA: 0x00156D1D File Offset: 0x0015511D
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.progress);
		}

		// Token: 0x06007697 RID: 30359 RVA: 0x00156D2D File Offset: 0x0015512D
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.progress);
		}

		// Token: 0x06007698 RID: 30360 RVA: 0x00156D3D File Offset: 0x0015513D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.progress);
		}

		// Token: 0x06007699 RID: 30361 RVA: 0x00156D4D File Offset: 0x0015514D
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.progress);
		}

		// Token: 0x0600769A RID: 30362 RVA: 0x00156D60 File Offset: 0x00155160
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x0400376B RID: 14187
		public const uint MsgID = 1300015U;

		// Token: 0x0400376C RID: 14188
		public uint Sequence;

		// Token: 0x0400376D RID: 14189
		public byte progress;
	}
}
