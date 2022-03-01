using System;

namespace Protocol
{
	// Token: 0x0200086D RID: 2157
	[Protocol]
	public class WorldGuildBattleLotteryRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006547 RID: 25927 RVA: 0x0012D428 File Offset: 0x0012B828
		public uint GetMsgID()
		{
			return 601968U;
		}

		// Token: 0x06006548 RID: 25928 RVA: 0x0012D42F File Offset: 0x0012B82F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006549 RID: 25929 RVA: 0x0012D437 File Offset: 0x0012B837
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600654A RID: 25930 RVA: 0x0012D440 File Offset: 0x0012B840
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.contribution);
		}

		// Token: 0x0600654B RID: 25931 RVA: 0x0012D45E File Offset: 0x0012B85E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.contribution);
		}

		// Token: 0x0600654C RID: 25932 RVA: 0x0012D47C File Offset: 0x0012B87C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.contribution);
		}

		// Token: 0x0600654D RID: 25933 RVA: 0x0012D49A File Offset: 0x0012B89A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.contribution);
		}

		// Token: 0x0600654E RID: 25934 RVA: 0x0012D4B8 File Offset: 0x0012B8B8
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002D62 RID: 11618
		public const uint MsgID = 601968U;

		// Token: 0x04002D63 RID: 11619
		public uint Sequence;

		// Token: 0x04002D64 RID: 11620
		public uint result;

		// Token: 0x04002D65 RID: 11621
		public uint contribution;
	}
}
