using System;

namespace Protocol
{
	// Token: 0x02000AE4 RID: 2788
	[Protocol]
	public class WorldInviteJoinRoomReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600784F RID: 30799 RVA: 0x0015C17C File Offset: 0x0015A57C
		public uint GetMsgID()
		{
			return 607823U;
		}

		// Token: 0x06007850 RID: 30800 RVA: 0x0015C183 File Offset: 0x0015A583
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007851 RID: 30801 RVA: 0x0015C18B File Offset: 0x0015A58B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007852 RID: 30802 RVA: 0x0015C194 File Offset: 0x0015A594
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
		}

		// Token: 0x06007853 RID: 30803 RVA: 0x0015C1A4 File Offset: 0x0015A5A4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
		}

		// Token: 0x06007854 RID: 30804 RVA: 0x0015C1B4 File Offset: 0x0015A5B4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
		}

		// Token: 0x06007855 RID: 30805 RVA: 0x0015C1C4 File Offset: 0x0015A5C4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
		}

		// Token: 0x06007856 RID: 30806 RVA: 0x0015C1D4 File Offset: 0x0015A5D4
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x040038CD RID: 14541
		public const uint MsgID = 607823U;

		// Token: 0x040038CE RID: 14542
		public uint Sequence;

		// Token: 0x040038CF RID: 14543
		public ulong playerId;
	}
}
