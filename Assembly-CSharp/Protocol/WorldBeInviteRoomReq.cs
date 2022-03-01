using System;

namespace Protocol
{
	// Token: 0x02000AE8 RID: 2792
	[Protocol]
	public class WorldBeInviteRoomReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007873 RID: 30835 RVA: 0x0015C34C File Offset: 0x0015A74C
		public uint GetMsgID()
		{
			return 607827U;
		}

		// Token: 0x06007874 RID: 30836 RVA: 0x0015C353 File Offset: 0x0015A753
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007875 RID: 30837 RVA: 0x0015C35B File Offset: 0x0015A75B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007876 RID: 30838 RVA: 0x0015C364 File Offset: 0x0015A764
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.roomId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.invitePlayerId);
			BaseDLL.encode_int8(buffer, ref pos_, this.isAccept);
			BaseDLL.encode_int8(buffer, ref pos_, this.slotGroup);
		}

		// Token: 0x06007877 RID: 30839 RVA: 0x0015C39E File Offset: 0x0015A79E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roomId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.invitePlayerId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isAccept);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slotGroup);
		}

		// Token: 0x06007878 RID: 30840 RVA: 0x0015C3D8 File Offset: 0x0015A7D8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.roomId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.invitePlayerId);
			BaseDLL.encode_int8(buffer, ref pos_, this.isAccept);
			BaseDLL.encode_int8(buffer, ref pos_, this.slotGroup);
		}

		// Token: 0x06007879 RID: 30841 RVA: 0x0015C412 File Offset: 0x0015A812
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roomId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.invitePlayerId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isAccept);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slotGroup);
		}

		// Token: 0x0600787A RID: 30842 RVA: 0x0015C44C File Offset: 0x0015A84C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			num++;
			return num + 1;
		}

		// Token: 0x040038D9 RID: 14553
		public const uint MsgID = 607827U;

		// Token: 0x040038DA RID: 14554
		public uint Sequence;

		// Token: 0x040038DB RID: 14555
		public uint roomId;

		// Token: 0x040038DC RID: 14556
		public ulong invitePlayerId;

		// Token: 0x040038DD RID: 14557
		public byte isAccept;

		// Token: 0x040038DE RID: 14558
		public byte slotGroup;
	}
}
