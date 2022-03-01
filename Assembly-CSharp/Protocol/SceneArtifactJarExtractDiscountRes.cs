using System;

namespace Protocol
{
	// Token: 0x02000A3F RID: 2623
	[Protocol]
	public class SceneArtifactJarExtractDiscountRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600739C RID: 29596 RVA: 0x0014F780 File Offset: 0x0014DB80
		public uint GetMsgID()
		{
			return 507405U;
		}

		// Token: 0x0600739D RID: 29597 RVA: 0x0014F787 File Offset: 0x0014DB87
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600739E RID: 29598 RVA: 0x0014F78F File Offset: 0x0014DB8F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600739F RID: 29599 RVA: 0x0014F798 File Offset: 0x0014DB98
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x060073A0 RID: 29600 RVA: 0x0014F7B6 File Offset: 0x0014DBB6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x060073A1 RID: 29601 RVA: 0x0014F7D4 File Offset: 0x0014DBD4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x060073A2 RID: 29602 RVA: 0x0014F7F2 File Offset: 0x0014DBF2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x060073A3 RID: 29603 RVA: 0x0014F810 File Offset: 0x0014DC10
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x040035A7 RID: 13735
		public const uint MsgID = 507405U;

		// Token: 0x040035A8 RID: 13736
		public uint Sequence;

		// Token: 0x040035A9 RID: 13737
		public uint opActId;

		// Token: 0x040035AA RID: 13738
		public uint errorCode;
	}
}
