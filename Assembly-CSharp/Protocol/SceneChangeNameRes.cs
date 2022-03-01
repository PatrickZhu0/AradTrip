using System;

namespace Protocol
{
	// Token: 0x02000B3B RID: 2875
	[Protocol]
	public class SceneChangeNameRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007ADA RID: 31450 RVA: 0x001605E8 File Offset: 0x0015E9E8
		public uint GetMsgID()
		{
			return 501218U;
		}

		// Token: 0x06007ADB RID: 31451 RVA: 0x001605EF File Offset: 0x0015E9EF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007ADC RID: 31452 RVA: 0x001605F7 File Offset: 0x0015E9F7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007ADD RID: 31453 RVA: 0x00160600 File Offset: 0x0015EA00
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06007ADE RID: 31454 RVA: 0x00160610 File Offset: 0x0015EA10
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06007ADF RID: 31455 RVA: 0x00160620 File Offset: 0x0015EA20
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06007AE0 RID: 31456 RVA: 0x00160630 File Offset: 0x0015EA30
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06007AE1 RID: 31457 RVA: 0x00160640 File Offset: 0x0015EA40
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003A3B RID: 14907
		public const uint MsgID = 501218U;

		// Token: 0x04003A3C RID: 14908
		public uint Sequence;

		// Token: 0x04003A3D RID: 14909
		public uint code;
	}
}
