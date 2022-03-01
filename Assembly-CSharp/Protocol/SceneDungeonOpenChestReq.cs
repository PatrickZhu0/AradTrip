using System;

namespace Protocol
{
	// Token: 0x020007C7 RID: 1991
	[Protocol]
	public class SceneDungeonOpenChestReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006070 RID: 24688 RVA: 0x00122220 File Offset: 0x00120620
		public uint GetMsgID()
		{
			return 506813U;
		}

		// Token: 0x06006071 RID: 24689 RVA: 0x00122227 File Offset: 0x00120627
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006072 RID: 24690 RVA: 0x0012222F File Offset: 0x0012062F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006073 RID: 24691 RVA: 0x00122238 File Offset: 0x00120638
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.pos);
		}

		// Token: 0x06006074 RID: 24692 RVA: 0x00122248 File Offset: 0x00120648
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pos);
		}

		// Token: 0x06006075 RID: 24693 RVA: 0x00122258 File Offset: 0x00120658
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.pos);
		}

		// Token: 0x06006076 RID: 24694 RVA: 0x00122268 File Offset: 0x00120668
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pos);
		}

		// Token: 0x06006077 RID: 24695 RVA: 0x00122278 File Offset: 0x00120678
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04002834 RID: 10292
		public const uint MsgID = 506813U;

		// Token: 0x04002835 RID: 10293
		public uint Sequence;

		// Token: 0x04002836 RID: 10294
		public byte pos;
	}
}
