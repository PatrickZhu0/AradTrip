using System;

namespace Protocol
{
	// Token: 0x0200075E RID: 1886
	[Protocol]
	public class SceneChampionGroupRecordReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005D73 RID: 23923 RVA: 0x00118B65 File Offset: 0x00116F65
		public uint GetMsgID()
		{
			return 509825U;
		}

		// Token: 0x06005D74 RID: 23924 RVA: 0x00118B6C File Offset: 0x00116F6C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005D75 RID: 23925 RVA: 0x00118B74 File Offset: 0x00116F74
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005D76 RID: 23926 RVA: 0x00118B7D File Offset: 0x00116F7D
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.groupID);
		}

		// Token: 0x06005D77 RID: 23927 RVA: 0x00118B8D File Offset: 0x00116F8D
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.groupID);
		}

		// Token: 0x06005D78 RID: 23928 RVA: 0x00118B9D File Offset: 0x00116F9D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.groupID);
		}

		// Token: 0x06005D79 RID: 23929 RVA: 0x00118BAD File Offset: 0x00116FAD
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.groupID);
		}

		// Token: 0x06005D7A RID: 23930 RVA: 0x00118BC0 File Offset: 0x00116FC0
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400264E RID: 9806
		public const uint MsgID = 509825U;

		// Token: 0x0400264F RID: 9807
		public uint Sequence;

		// Token: 0x04002650 RID: 9808
		public uint groupID;
	}
}
