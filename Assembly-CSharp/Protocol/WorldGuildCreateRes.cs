using System;

namespace Protocol
{
	// Token: 0x0200082A RID: 2090
	[Protocol]
	public class WorldGuildCreateRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060062EC RID: 25324 RVA: 0x00129C94 File Offset: 0x00128094
		public uint GetMsgID()
		{
			return 601902U;
		}

		// Token: 0x060062ED RID: 25325 RVA: 0x00129C9B File Offset: 0x0012809B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060062EE RID: 25326 RVA: 0x00129CA3 File Offset: 0x001280A3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060062EF RID: 25327 RVA: 0x00129CAC File Offset: 0x001280AC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060062F0 RID: 25328 RVA: 0x00129CBC File Offset: 0x001280BC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060062F1 RID: 25329 RVA: 0x00129CCC File Offset: 0x001280CC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060062F2 RID: 25330 RVA: 0x00129CDC File Offset: 0x001280DC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060062F3 RID: 25331 RVA: 0x00129CEC File Offset: 0x001280EC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002C77 RID: 11383
		public const uint MsgID = 601902U;

		// Token: 0x04002C78 RID: 11384
		public uint Sequence;

		// Token: 0x04002C79 RID: 11385
		public uint result;
	}
}
