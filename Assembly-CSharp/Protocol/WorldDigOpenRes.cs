using System;

namespace Protocol
{
	// Token: 0x0200079F RID: 1951
	[Protocol]
	public class WorldDigOpenRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005F6B RID: 24427 RVA: 0x0011DB3C File Offset: 0x0011BF3C
		public uint GetMsgID()
		{
			return 608212U;
		}

		// Token: 0x06005F6C RID: 24428 RVA: 0x0011DB43 File Offset: 0x0011BF43
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005F6D RID: 24429 RVA: 0x0011DB4B File Offset: 0x0011BF4B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005F6E RID: 24430 RVA: 0x0011DB54 File Offset: 0x0011BF54
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemIndex);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemNum);
		}

		// Token: 0x06005F6F RID: 24431 RVA: 0x0011DB8E File Offset: 0x0011BF8E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemIndex);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemNum);
		}

		// Token: 0x06005F70 RID: 24432 RVA: 0x0011DBC8 File Offset: 0x0011BFC8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemIndex);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemNum);
		}

		// Token: 0x06005F71 RID: 24433 RVA: 0x0011DC02 File Offset: 0x0011C002
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemIndex);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemNum);
		}

		// Token: 0x06005F72 RID: 24434 RVA: 0x0011DC3C File Offset: 0x0011C03C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002762 RID: 10082
		public const uint MsgID = 608212U;

		// Token: 0x04002763 RID: 10083
		public uint Sequence;

		// Token: 0x04002764 RID: 10084
		public uint result;

		// Token: 0x04002765 RID: 10085
		public uint itemIndex;

		// Token: 0x04002766 RID: 10086
		public uint itemId;

		// Token: 0x04002767 RID: 10087
		public uint itemNum;
	}
}
