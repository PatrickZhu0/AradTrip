using System;

namespace Protocol
{
	// Token: 0x02000865 RID: 2149
	[Protocol]
	public class WorldGuildChallengeRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060064FF RID: 25855 RVA: 0x0012CC64 File Offset: 0x0012B064
		public uint GetMsgID()
		{
			return 601960U;
		}

		// Token: 0x06006500 RID: 25856 RVA: 0x0012CC6B File Offset: 0x0012B06B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006501 RID: 25857 RVA: 0x0012CC73 File Offset: 0x0012B073
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006502 RID: 25858 RVA: 0x0012CC7C File Offset: 0x0012B07C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006503 RID: 25859 RVA: 0x0012CC8C File Offset: 0x0012B08C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006504 RID: 25860 RVA: 0x0012CC9C File Offset: 0x0012B09C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006505 RID: 25861 RVA: 0x0012CCAC File Offset: 0x0012B0AC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006506 RID: 25862 RVA: 0x0012CCBC File Offset: 0x0012B0BC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002D44 RID: 11588
		public const uint MsgID = 601960U;

		// Token: 0x04002D45 RID: 11589
		public uint Sequence;

		// Token: 0x04002D46 RID: 11590
		public uint result;
	}
}
