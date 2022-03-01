using System;

namespace Protocol
{
	// Token: 0x02000B8E RID: 2958
	[Protocol]
	public class WorldTeamReadyReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007D59 RID: 32089 RVA: 0x001650FC File Offset: 0x001634FC
		public uint GetMsgID()
		{
			return 601632U;
		}

		// Token: 0x06007D5A RID: 32090 RVA: 0x00165103 File Offset: 0x00163503
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007D5B RID: 32091 RVA: 0x0016510B File Offset: 0x0016350B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007D5C RID: 32092 RVA: 0x00165114 File Offset: 0x00163514
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.ready);
		}

		// Token: 0x06007D5D RID: 32093 RVA: 0x00165124 File Offset: 0x00163524
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.ready);
		}

		// Token: 0x06007D5E RID: 32094 RVA: 0x00165134 File Offset: 0x00163534
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.ready);
		}

		// Token: 0x06007D5F RID: 32095 RVA: 0x00165144 File Offset: 0x00163544
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.ready);
		}

		// Token: 0x06007D60 RID: 32096 RVA: 0x00165154 File Offset: 0x00163554
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003B76 RID: 15222
		public const uint MsgID = 601632U;

		// Token: 0x04003B77 RID: 15223
		public uint Sequence;

		// Token: 0x04003B78 RID: 15224
		public byte ready;
	}
}
