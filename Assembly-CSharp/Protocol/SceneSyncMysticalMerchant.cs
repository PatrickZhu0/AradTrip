using System;

namespace Protocol
{
	// Token: 0x020008F6 RID: 2294
	[Protocol]
	public class SceneSyncMysticalMerchant : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006916 RID: 26902 RVA: 0x0013655C File Offset: 0x0013495C
		public uint GetMsgID()
		{
			return 501020U;
		}

		// Token: 0x06006917 RID: 26903 RVA: 0x00136563 File Offset: 0x00134963
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006918 RID: 26904 RVA: 0x0013656B File Offset: 0x0013496B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006919 RID: 26905 RVA: 0x00136574 File Offset: 0x00134974
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		}

		// Token: 0x0600691A RID: 26906 RVA: 0x00136584 File Offset: 0x00134984
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		}

		// Token: 0x0600691B RID: 26907 RVA: 0x00136594 File Offset: 0x00134994
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		}

		// Token: 0x0600691C RID: 26908 RVA: 0x001365A4 File Offset: 0x001349A4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		}

		// Token: 0x0600691D RID: 26909 RVA: 0x001365B4 File Offset: 0x001349B4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002FA7 RID: 12199
		public const uint MsgID = 501020U;

		// Token: 0x04002FA8 RID: 12200
		public uint Sequence;

		// Token: 0x04002FA9 RID: 12201
		public uint id;
	}
}
