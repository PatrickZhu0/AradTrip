using System;

namespace Protocol
{
	// Token: 0x02000A3C RID: 2620
	[Protocol]
	public class SceneArtifactJarDiscountInfoReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007381 RID: 29569 RVA: 0x0014F570 File Offset: 0x0014D970
		public uint GetMsgID()
		{
			return 507402U;
		}

		// Token: 0x06007382 RID: 29570 RVA: 0x0014F577 File Offset: 0x0014D977
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007383 RID: 29571 RVA: 0x0014F57F File Offset: 0x0014D97F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007384 RID: 29572 RVA: 0x0014F588 File Offset: 0x0014D988
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
		}

		// Token: 0x06007385 RID: 29573 RVA: 0x0014F598 File Offset: 0x0014D998
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
		}

		// Token: 0x06007386 RID: 29574 RVA: 0x0014F5A8 File Offset: 0x0014D9A8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
		}

		// Token: 0x06007387 RID: 29575 RVA: 0x0014F5B8 File Offset: 0x0014D9B8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
		}

		// Token: 0x06007388 RID: 29576 RVA: 0x0014F5C8 File Offset: 0x0014D9C8
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400359B RID: 13723
		public const uint MsgID = 507402U;

		// Token: 0x0400359C RID: 13724
		public uint Sequence;

		// Token: 0x0400359D RID: 13725
		public uint opActId;
	}
}
