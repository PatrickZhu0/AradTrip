using System;

namespace Protocol
{
	// Token: 0x02000AE9 RID: 2793
	[Protocol]
	public class WorldBeInviteRoomRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600787C RID: 30844 RVA: 0x0015C47F File Offset: 0x0015A87F
		public uint GetMsgID()
		{
			return 607828U;
		}

		// Token: 0x0600787D RID: 30845 RVA: 0x0015C486 File Offset: 0x0015A886
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600787E RID: 30846 RVA: 0x0015C48E File Offset: 0x0015A88E
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600787F RID: 30847 RVA: 0x0015C497 File Offset: 0x0015A897
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			this.roomInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06007880 RID: 30848 RVA: 0x0015C4B4 File Offset: 0x0015A8B4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			this.roomInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06007881 RID: 30849 RVA: 0x0015C4D1 File Offset: 0x0015A8D1
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			this.roomInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06007882 RID: 30850 RVA: 0x0015C4EE File Offset: 0x0015A8EE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			this.roomInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06007883 RID: 30851 RVA: 0x0015C50C File Offset: 0x0015A90C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + this.roomInfo.getLen();
		}

		// Token: 0x040038DF RID: 14559
		public const uint MsgID = 607828U;

		// Token: 0x040038E0 RID: 14560
		public uint Sequence;

		// Token: 0x040038E1 RID: 14561
		public uint result;

		// Token: 0x040038E2 RID: 14562
		public RoomInfo roomInfo = new RoomInfo();
	}
}
