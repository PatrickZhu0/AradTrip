using System;

namespace Protocol
{
	// Token: 0x02000ACD RID: 2765
	public class RoomInfo : IProtocolStream
	{
		// Token: 0x06007789 RID: 30601 RVA: 0x00159A90 File Offset: 0x00157E90
		public void encode(byte[] buffer, ref int pos_)
		{
			this.roomSimpleInfo.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.roomSlotInfos.Length);
			for (int i = 0; i < this.roomSlotInfos.Length; i++)
			{
				this.roomSlotInfos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600778A RID: 30602 RVA: 0x00159AE4 File Offset: 0x00157EE4
		public void decode(byte[] buffer, ref int pos_)
		{
			this.roomSimpleInfo.decode(buffer, ref pos_);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.roomSlotInfos = new RoomSlotInfo[(int)num];
			for (int i = 0; i < this.roomSlotInfos.Length; i++)
			{
				this.roomSlotInfos[i] = new RoomSlotInfo();
				this.roomSlotInfos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600778B RID: 30603 RVA: 0x00159B4C File Offset: 0x00157F4C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.roomSimpleInfo.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.roomSlotInfos.Length);
			for (int i = 0; i < this.roomSlotInfos.Length; i++)
			{
				this.roomSlotInfos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600778C RID: 30604 RVA: 0x00159BA0 File Offset: 0x00157FA0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.roomSimpleInfo.decode(buffer, ref pos_);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.roomSlotInfos = new RoomSlotInfo[(int)num];
			for (int i = 0; i < this.roomSlotInfos.Length; i++)
			{
				this.roomSlotInfos[i] = new RoomSlotInfo();
				this.roomSlotInfos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600778D RID: 30605 RVA: 0x00159C08 File Offset: 0x00158008
		public int getLen()
		{
			int num = 0;
			num += this.roomSimpleInfo.getLen();
			num += 2;
			for (int i = 0; i < this.roomSlotInfos.Length; i++)
			{
				num += this.roomSlotInfos[i].getLen();
			}
			return num;
		}

		// Token: 0x04003843 RID: 14403
		public RoomSimpleInfo roomSimpleInfo = new RoomSimpleInfo();

		// Token: 0x04003844 RID: 14404
		public RoomSlotInfo[] roomSlotInfos = new RoomSlotInfo[0];
	}
}
