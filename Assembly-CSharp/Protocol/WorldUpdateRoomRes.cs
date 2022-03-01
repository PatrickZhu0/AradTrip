using System;

namespace Protocol
{
	// Token: 0x02000ADD RID: 2781
	[Protocol]
	public class WorldUpdateRoomRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007810 RID: 30736 RVA: 0x0015BC7F File Offset: 0x0015A07F
		public uint GetMsgID()
		{
			return 607814U;
		}

		// Token: 0x06007811 RID: 30737 RVA: 0x0015BC86 File Offset: 0x0015A086
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007812 RID: 30738 RVA: 0x0015BC8E File Offset: 0x0015A08E
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007813 RID: 30739 RVA: 0x0015BC97 File Offset: 0x0015A097
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06007814 RID: 30740 RVA: 0x0015BCB4 File Offset: 0x0015A0B4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06007815 RID: 30741 RVA: 0x0015BCD1 File Offset: 0x0015A0D1
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06007816 RID: 30742 RVA: 0x0015BCEE File Offset: 0x0015A0EE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06007817 RID: 30743 RVA: 0x0015BD0C File Offset: 0x0015A10C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + this.info.getLen();
		}

		// Token: 0x040038B4 RID: 14516
		public const uint MsgID = 607814U;

		// Token: 0x040038B5 RID: 14517
		public uint Sequence;

		// Token: 0x040038B6 RID: 14518
		public uint result;

		// Token: 0x040038B7 RID: 14519
		public RoomInfo info = new RoomInfo();
	}
}
