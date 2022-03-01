using System;

namespace Protocol
{
	// Token: 0x02000A3E RID: 2622
	[Protocol]
	public class SceneArtifactJarExtractDiscountReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007393 RID: 29587 RVA: 0x0014F70C File Offset: 0x0014DB0C
		public uint GetMsgID()
		{
			return 507404U;
		}

		// Token: 0x06007394 RID: 29588 RVA: 0x0014F713 File Offset: 0x0014DB13
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007395 RID: 29589 RVA: 0x0014F71B File Offset: 0x0014DB1B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007396 RID: 29590 RVA: 0x0014F724 File Offset: 0x0014DB24
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
		}

		// Token: 0x06007397 RID: 29591 RVA: 0x0014F734 File Offset: 0x0014DB34
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
		}

		// Token: 0x06007398 RID: 29592 RVA: 0x0014F744 File Offset: 0x0014DB44
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
		}

		// Token: 0x06007399 RID: 29593 RVA: 0x0014F754 File Offset: 0x0014DB54
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
		}

		// Token: 0x0600739A RID: 29594 RVA: 0x0014F764 File Offset: 0x0014DB64
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040035A4 RID: 13732
		public const uint MsgID = 507404U;

		// Token: 0x040035A5 RID: 13733
		public uint Sequence;

		// Token: 0x040035A6 RID: 13734
		public uint opActId;
	}
}
