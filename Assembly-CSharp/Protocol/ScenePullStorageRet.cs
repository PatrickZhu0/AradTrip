using System;

namespace Protocol
{
	// Token: 0x020008E3 RID: 2275
	[Protocol]
	public class ScenePullStorageRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600686B RID: 26731 RVA: 0x0013556C File Offset: 0x0013396C
		public uint GetMsgID()
		{
			return 500912U;
		}

		// Token: 0x0600686C RID: 26732 RVA: 0x00135573 File Offset: 0x00133973
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600686D RID: 26733 RVA: 0x0013557B File Offset: 0x0013397B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600686E RID: 26734 RVA: 0x00135584 File Offset: 0x00133984
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x0600686F RID: 26735 RVA: 0x00135594 File Offset: 0x00133994
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006870 RID: 26736 RVA: 0x001355A4 File Offset: 0x001339A4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006871 RID: 26737 RVA: 0x001355B4 File Offset: 0x001339B4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006872 RID: 26738 RVA: 0x001355C4 File Offset: 0x001339C4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002F63 RID: 12131
		public const uint MsgID = 500912U;

		// Token: 0x04002F64 RID: 12132
		public uint Sequence;

		// Token: 0x04002F65 RID: 12133
		public uint code;
	}
}
