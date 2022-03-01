using System;

namespace Protocol
{
	// Token: 0x020008DC RID: 2268
	[Protocol]
	public class SceneSellItem : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600682C RID: 26668 RVA: 0x0013518C File Offset: 0x0013358C
		public uint GetMsgID()
		{
			return 500903U;
		}

		// Token: 0x0600682D RID: 26669 RVA: 0x00135193 File Offset: 0x00133593
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600682E RID: 26670 RVA: 0x0013519B File Offset: 0x0013359B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600682F RID: 26671 RVA: 0x001351A4 File Offset: 0x001335A4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x06006830 RID: 26672 RVA: 0x001351C2 File Offset: 0x001335C2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06006831 RID: 26673 RVA: 0x001351E0 File Offset: 0x001335E0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x06006832 RID: 26674 RVA: 0x001351FE File Offset: 0x001335FE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06006833 RID: 26675 RVA: 0x0013521C File Offset: 0x0013361C
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 2;
		}

		// Token: 0x04002F4B RID: 12107
		public const uint MsgID = 500903U;

		// Token: 0x04002F4C RID: 12108
		public uint Sequence;

		// Token: 0x04002F4D RID: 12109
		public ulong uid;

		// Token: 0x04002F4E RID: 12110
		public ushort num;
	}
}
