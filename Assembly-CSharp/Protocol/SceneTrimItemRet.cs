using System;

namespace Protocol
{
	// Token: 0x020008E6 RID: 2278
	[Protocol]
	public class SceneTrimItemRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006886 RID: 26758 RVA: 0x0013568C File Offset: 0x00133A8C
		public uint GetMsgID()
		{
			return 500915U;
		}

		// Token: 0x06006887 RID: 26759 RVA: 0x00135693 File Offset: 0x00133A93
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006888 RID: 26760 RVA: 0x0013569B File Offset: 0x00133A9B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006889 RID: 26761 RVA: 0x001356A4 File Offset: 0x00133AA4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x0600688A RID: 26762 RVA: 0x001356B4 File Offset: 0x00133AB4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x0600688B RID: 26763 RVA: 0x001356C4 File Offset: 0x00133AC4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x0600688C RID: 26764 RVA: 0x001356D4 File Offset: 0x00133AD4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x0600688D RID: 26765 RVA: 0x001356E4 File Offset: 0x00133AE4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002F6B RID: 12139
		public const uint MsgID = 500915U;

		// Token: 0x04002F6C RID: 12140
		public uint Sequence;

		// Token: 0x04002F6D RID: 12141
		public uint code;
	}
}
