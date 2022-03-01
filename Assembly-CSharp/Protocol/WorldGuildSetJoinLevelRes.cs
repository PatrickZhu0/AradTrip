using System;

namespace Protocol
{
	// Token: 0x02000878 RID: 2168
	[Protocol]
	public class WorldGuildSetJoinLevelRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060065AA RID: 26026 RVA: 0x0012E25C File Offset: 0x0012C65C
		public uint GetMsgID()
		{
			return 601989U;
		}

		// Token: 0x060065AB RID: 26027 RVA: 0x0012E263 File Offset: 0x0012C663
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060065AC RID: 26028 RVA: 0x0012E26B File Offset: 0x0012C66B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060065AD RID: 26029 RVA: 0x0012E274 File Offset: 0x0012C674
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060065AE RID: 26030 RVA: 0x0012E284 File Offset: 0x0012C684
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060065AF RID: 26031 RVA: 0x0012E294 File Offset: 0x0012C694
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060065B0 RID: 26032 RVA: 0x0012E2A4 File Offset: 0x0012C6A4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060065B1 RID: 26033 RVA: 0x0012E2B4 File Offset: 0x0012C6B4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002D87 RID: 11655
		public const uint MsgID = 601989U;

		// Token: 0x04002D88 RID: 11656
		public uint Sequence;

		// Token: 0x04002D89 RID: 11657
		public uint result;
	}
}
