using System;

namespace Protocol
{
	// Token: 0x02000AD5 RID: 2773
	[Protocol]
	public class WorldSyncRoomBeInviteInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x060077C8 RID: 30664 RVA: 0x0015A90C File Offset: 0x00158D0C
		public uint GetMsgID()
		{
			return 607806U;
		}

		// Token: 0x060077C9 RID: 30665 RVA: 0x0015A913 File Offset: 0x00158D13
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060077CA RID: 30666 RVA: 0x0015A91B File Offset: 0x00158D1B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060077CB RID: 30667 RVA: 0x0015A924 File Offset: 0x00158D24
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			BaseDLL.encode_int8(buffer, ref pos_, this.isAccept);
		}

		// Token: 0x060077CC RID: 30668 RVA: 0x0015A942 File Offset: 0x00158D42
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isAccept);
		}

		// Token: 0x060077CD RID: 30669 RVA: 0x0015A960 File Offset: 0x00158D60
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			BaseDLL.encode_int8(buffer, ref pos_, this.isAccept);
		}

		// Token: 0x060077CE RID: 30670 RVA: 0x0015A97E File Offset: 0x00158D7E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isAccept);
		}

		// Token: 0x060077CF RID: 30671 RVA: 0x0015A99C File Offset: 0x00158D9C
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 1;
		}

		// Token: 0x0400386F RID: 14447
		public const uint MsgID = 607806U;

		// Token: 0x04003870 RID: 14448
		public uint Sequence;

		// Token: 0x04003871 RID: 14449
		public ulong playerId;

		// Token: 0x04003872 RID: 14450
		public byte isAccept;
	}
}
