using System;

namespace Protocol
{
	// Token: 0x0200082C RID: 2092
	[Protocol]
	public class WorldGuildLeaveRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060062FE RID: 25342 RVA: 0x00129D40 File Offset: 0x00128140
		public uint GetMsgID()
		{
			return 601904U;
		}

		// Token: 0x060062FF RID: 25343 RVA: 0x00129D47 File Offset: 0x00128147
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006300 RID: 25344 RVA: 0x00129D4F File Offset: 0x0012814F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006301 RID: 25345 RVA: 0x00129D58 File Offset: 0x00128158
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006302 RID: 25346 RVA: 0x00129D68 File Offset: 0x00128168
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006303 RID: 25347 RVA: 0x00129D78 File Offset: 0x00128178
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006304 RID: 25348 RVA: 0x00129D88 File Offset: 0x00128188
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006305 RID: 25349 RVA: 0x00129D98 File Offset: 0x00128198
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002C7C RID: 11388
		public const uint MsgID = 601904U;

		// Token: 0x04002C7D RID: 11389
		public uint Sequence;

		// Token: 0x04002C7E RID: 11390
		public uint result;
	}
}
