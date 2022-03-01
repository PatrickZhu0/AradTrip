using System;

namespace Protocol
{
	// Token: 0x02000761 RID: 1889
	[Protocol]
	public class SceneChampionTotalStatusReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005D8B RID: 23947 RVA: 0x00118ED1 File Offset: 0x001172D1
		public uint GetMsgID()
		{
			return 509827U;
		}

		// Token: 0x06005D8C RID: 23948 RVA: 0x00118ED8 File Offset: 0x001172D8
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005D8D RID: 23949 RVA: 0x00118EE0 File Offset: 0x001172E0
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005D8E RID: 23950 RVA: 0x00118EE9 File Offset: 0x001172E9
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
		}

		// Token: 0x06005D8F RID: 23951 RVA: 0x00118EF9 File Offset: 0x001172F9
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
		}

		// Token: 0x06005D90 RID: 23952 RVA: 0x00118F09 File Offset: 0x00117309
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
		}

		// Token: 0x06005D91 RID: 23953 RVA: 0x00118F19 File Offset: 0x00117319
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
		}

		// Token: 0x06005D92 RID: 23954 RVA: 0x00118F2C File Offset: 0x0011732C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002659 RID: 9817
		public const uint MsgID = 509827U;

		// Token: 0x0400265A RID: 9818
		public uint Sequence;

		// Token: 0x0400265B RID: 9819
		public uint accid;
	}
}
