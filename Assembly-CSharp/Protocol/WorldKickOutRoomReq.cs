using System;

namespace Protocol
{
	// Token: 0x02000AE2 RID: 2786
	[Protocol]
	public class WorldKickOutRoomReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600783D RID: 30781 RVA: 0x0015C094 File Offset: 0x0015A494
		public uint GetMsgID()
		{
			return 607819U;
		}

		// Token: 0x0600783E RID: 30782 RVA: 0x0015C09B File Offset: 0x0015A49B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600783F RID: 30783 RVA: 0x0015C0A3 File Offset: 0x0015A4A3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007840 RID: 30784 RVA: 0x0015C0AC File Offset: 0x0015A4AC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
		}

		// Token: 0x06007841 RID: 30785 RVA: 0x0015C0BC File Offset: 0x0015A4BC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
		}

		// Token: 0x06007842 RID: 30786 RVA: 0x0015C0CC File Offset: 0x0015A4CC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
		}

		// Token: 0x06007843 RID: 30787 RVA: 0x0015C0DC File Offset: 0x0015A4DC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
		}

		// Token: 0x06007844 RID: 30788 RVA: 0x0015C0EC File Offset: 0x0015A4EC
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x040038C7 RID: 14535
		public const uint MsgID = 607819U;

		// Token: 0x040038C8 RID: 14536
		public uint Sequence;

		// Token: 0x040038C9 RID: 14537
		public ulong playerId;
	}
}
