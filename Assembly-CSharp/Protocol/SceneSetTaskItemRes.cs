using System;

namespace Protocol
{
	// Token: 0x02000C62 RID: 3170
	[Protocol]
	public class SceneSetTaskItemRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600837D RID: 33661 RVA: 0x00171947 File Offset: 0x0016FD47
		public uint GetMsgID()
		{
			return 501134U;
		}

		// Token: 0x0600837E RID: 33662 RVA: 0x0017194E File Offset: 0x0016FD4E
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600837F RID: 33663 RVA: 0x00171956 File Offset: 0x0016FD56
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008380 RID: 33664 RVA: 0x0017195F File Offset: 0x0016FD5F
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06008381 RID: 33665 RVA: 0x0017196F File Offset: 0x0016FD6F
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06008382 RID: 33666 RVA: 0x0017197F File Offset: 0x0016FD7F
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06008383 RID: 33667 RVA: 0x0017198F File Offset: 0x0016FD8F
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06008384 RID: 33668 RVA: 0x001719A0 File Offset: 0x0016FDA0
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003EE0 RID: 16096
		public const uint MsgID = 501134U;

		// Token: 0x04003EE1 RID: 16097
		public uint Sequence;

		// Token: 0x04003EE2 RID: 16098
		public uint result;
	}
}
