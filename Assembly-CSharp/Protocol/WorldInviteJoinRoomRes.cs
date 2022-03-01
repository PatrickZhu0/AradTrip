using System;

namespace Protocol
{
	// Token: 0x02000AE5 RID: 2789
	[Protocol]
	public class WorldInviteJoinRoomRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007858 RID: 30808 RVA: 0x0015C1F0 File Offset: 0x0015A5F0
		public uint GetMsgID()
		{
			return 607824U;
		}

		// Token: 0x06007859 RID: 30809 RVA: 0x0015C1F7 File Offset: 0x0015A5F7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600785A RID: 30810 RVA: 0x0015C1FF File Offset: 0x0015A5FF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600785B RID: 30811 RVA: 0x0015C208 File Offset: 0x0015A608
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x0600785C RID: 30812 RVA: 0x0015C218 File Offset: 0x0015A618
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600785D RID: 30813 RVA: 0x0015C228 File Offset: 0x0015A628
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x0600785E RID: 30814 RVA: 0x0015C238 File Offset: 0x0015A638
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600785F RID: 30815 RVA: 0x0015C248 File Offset: 0x0015A648
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040038D0 RID: 14544
		public const uint MsgID = 607824U;

		// Token: 0x040038D1 RID: 14545
		public uint Sequence;

		// Token: 0x040038D2 RID: 14546
		public uint result;
	}
}
