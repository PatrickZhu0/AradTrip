using System;

namespace Protocol
{
	// Token: 0x02000943 RID: 2371
	[Protocol]
	public class SceneEquipRecNotifyReset : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006BBF RID: 27583 RVA: 0x0013AB08 File Offset: 0x00138F08
		public uint GetMsgID()
		{
			return 501016U;
		}

		// Token: 0x06006BC0 RID: 27584 RVA: 0x0013AB0F File Offset: 0x00138F0F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006BC1 RID: 27585 RVA: 0x0013AB17 File Offset: 0x00138F17
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006BC2 RID: 27586 RVA: 0x0013AB20 File Offset: 0x00138F20
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006BC3 RID: 27587 RVA: 0x0013AB22 File Offset: 0x00138F22
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006BC4 RID: 27588 RVA: 0x0013AB24 File Offset: 0x00138F24
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006BC5 RID: 27589 RVA: 0x0013AB26 File Offset: 0x00138F26
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006BC6 RID: 27590 RVA: 0x0013AB28 File Offset: 0x00138F28
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040030CE RID: 12494
		public const uint MsgID = 501016U;

		// Token: 0x040030CF RID: 12495
		public uint Sequence;
	}
}
