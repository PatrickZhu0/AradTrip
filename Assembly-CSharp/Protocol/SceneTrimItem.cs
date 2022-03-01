using System;

namespace Protocol
{
	// Token: 0x020008E5 RID: 2277
	[Protocol]
	public class SceneTrimItem : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600687D RID: 26749 RVA: 0x00135618 File Offset: 0x00133A18
		public uint GetMsgID()
		{
			return 500914U;
		}

		// Token: 0x0600687E RID: 26750 RVA: 0x0013561F File Offset: 0x00133A1F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600687F RID: 26751 RVA: 0x00135627 File Offset: 0x00133A27
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006880 RID: 26752 RVA: 0x00135630 File Offset: 0x00133A30
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.pack);
		}

		// Token: 0x06006881 RID: 26753 RVA: 0x00135640 File Offset: 0x00133A40
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pack);
		}

		// Token: 0x06006882 RID: 26754 RVA: 0x00135650 File Offset: 0x00133A50
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.pack);
		}

		// Token: 0x06006883 RID: 26755 RVA: 0x00135660 File Offset: 0x00133A60
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pack);
		}

		// Token: 0x06006884 RID: 26756 RVA: 0x00135670 File Offset: 0x00133A70
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04002F68 RID: 12136
		public const uint MsgID = 500914U;

		// Token: 0x04002F69 RID: 12137
		public uint Sequence;

		// Token: 0x04002F6A RID: 12138
		public byte pack;
	}
}
