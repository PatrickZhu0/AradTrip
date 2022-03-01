using System;

namespace Protocol
{
	// Token: 0x02000ACE RID: 2766
	public class RoomListInfo : IProtocolStream
	{
		// Token: 0x0600778F RID: 30607 RVA: 0x00159C68 File Offset: 0x00158068
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.startIndex);
			BaseDLL.encode_uint32(buffer, ref pos_, this.total);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.rooms.Length);
			for (int i = 0; i < this.rooms.Length; i++)
			{
				this.rooms[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007790 RID: 30608 RVA: 0x00159CCC File Offset: 0x001580CC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startIndex);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.total);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.rooms = new RoomSimpleInfo[(int)num];
			for (int i = 0; i < this.rooms.Length; i++)
			{
				this.rooms[i] = new RoomSimpleInfo();
				this.rooms[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007791 RID: 30609 RVA: 0x00159D44 File Offset: 0x00158144
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.startIndex);
			BaseDLL.encode_uint32(buffer, ref pos_, this.total);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.rooms.Length);
			for (int i = 0; i < this.rooms.Length; i++)
			{
				this.rooms[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007792 RID: 30610 RVA: 0x00159DA8 File Offset: 0x001581A8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startIndex);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.total);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.rooms = new RoomSimpleInfo[(int)num];
			for (int i = 0; i < this.rooms.Length; i++)
			{
				this.rooms[i] = new RoomSimpleInfo();
				this.rooms[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007793 RID: 30611 RVA: 0x00159E20 File Offset: 0x00158220
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.rooms.Length; i++)
			{
				num += this.rooms[i].getLen();
			}
			return num;
		}

		// Token: 0x04003845 RID: 14405
		public uint startIndex;

		// Token: 0x04003846 RID: 14406
		public uint total;

		// Token: 0x04003847 RID: 14407
		public RoomSimpleInfo[] rooms = new RoomSimpleInfo[0];
	}
}
