using System;

namespace Protocol
{
	// Token: 0x02000B6F RID: 2927
	[Protocol]
	public class SceneNotifyBootFlag : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007C8A RID: 31882 RVA: 0x00163550 File Offset: 0x00161950
		public uint GetMsgID()
		{
			return 505403U;
		}

		// Token: 0x06007C8B RID: 31883 RVA: 0x00163557 File Offset: 0x00161957
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007C8C RID: 31884 RVA: 0x0016355F File Offset: 0x0016195F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007C8D RID: 31885 RVA: 0x00163568 File Offset: 0x00161968
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		}

		// Token: 0x06007C8E RID: 31886 RVA: 0x00163578 File Offset: 0x00161978
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007C8F RID: 31887 RVA: 0x00163588 File Offset: 0x00161988
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		}

		// Token: 0x06007C90 RID: 31888 RVA: 0x00163598 File Offset: 0x00161998
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007C91 RID: 31889 RVA: 0x001635A8 File Offset: 0x001619A8
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003AF7 RID: 15095
		public const uint MsgID = 505403U;

		// Token: 0x04003AF8 RID: 15096
		public uint Sequence;

		// Token: 0x04003AF9 RID: 15097
		public uint id;
	}
}
