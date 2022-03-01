using System;

namespace Protocol
{
	// Token: 0x0200099F RID: 2463
	public class FriendPresentInfo : IProtocolStream
	{
		// Token: 0x06006EE9 RID: 28393 RVA: 0x00140980 File Offset: 0x0013ED80
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.friendId);
			BaseDLL.encode_int8(buffer, ref pos_, this.friendOcc);
			BaseDLL.encode_uint16(buffer, ref pos_, this.friendLev);
			byte[] str = StringHelper.StringToUTF8Bytes(this.friendname);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.isOnline);
			BaseDLL.encode_uint32(buffer, ref pos_, this.beSendedTimes);
			BaseDLL.encode_uint32(buffer, ref pos_, this.beSendedLimit);
			BaseDLL.encode_uint32(buffer, ref pos_, this.sendTimes);
			BaseDLL.encode_uint32(buffer, ref pos_, this.sendLimit);
			BaseDLL.encode_uint32(buffer, ref pos_, this.sendedTotalTimes);
			BaseDLL.encode_uint32(buffer, ref pos_, this.sendedTotalLimit);
		}

		// Token: 0x06006EEA RID: 28394 RVA: 0x00140A44 File Offset: 0x0013EE44
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.friendId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.friendOcc);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.friendLev);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.friendname = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isOnline);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.beSendedTimes);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.beSendedLimit);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sendTimes);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sendLimit);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sendedTotalTimes);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sendedTotalLimit);
		}

		// Token: 0x06006EEB RID: 28395 RVA: 0x00140B2C File Offset: 0x0013EF2C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.friendId);
			BaseDLL.encode_int8(buffer, ref pos_, this.friendOcc);
			BaseDLL.encode_uint16(buffer, ref pos_, this.friendLev);
			byte[] str = StringHelper.StringToUTF8Bytes(this.friendname);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.isOnline);
			BaseDLL.encode_uint32(buffer, ref pos_, this.beSendedTimes);
			BaseDLL.encode_uint32(buffer, ref pos_, this.beSendedLimit);
			BaseDLL.encode_uint32(buffer, ref pos_, this.sendTimes);
			BaseDLL.encode_uint32(buffer, ref pos_, this.sendLimit);
			BaseDLL.encode_uint32(buffer, ref pos_, this.sendedTotalTimes);
			BaseDLL.encode_uint32(buffer, ref pos_, this.sendedTotalLimit);
		}

		// Token: 0x06006EEC RID: 28396 RVA: 0x00140BF4 File Offset: 0x0013EFF4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.friendId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.friendOcc);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.friendLev);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.friendname = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isOnline);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.beSendedTimes);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.beSendedLimit);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sendTimes);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sendLimit);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sendedTotalTimes);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sendedTotalLimit);
		}

		// Token: 0x06006EED RID: 28397 RVA: 0x00140CDC File Offset: 0x0013F0DC
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 8;
			num++;
			num += 2;
			byte[] array = StringHelper.StringToUTF8Bytes(this.friendname);
			num += 2 + array.Length;
			num++;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003246 RID: 12870
		public ulong guid;

		// Token: 0x04003247 RID: 12871
		public ulong friendId;

		// Token: 0x04003248 RID: 12872
		public byte friendOcc;

		// Token: 0x04003249 RID: 12873
		public ushort friendLev;

		// Token: 0x0400324A RID: 12874
		public string friendname;

		// Token: 0x0400324B RID: 12875
		public byte isOnline;

		// Token: 0x0400324C RID: 12876
		public uint beSendedTimes;

		// Token: 0x0400324D RID: 12877
		public uint beSendedLimit;

		// Token: 0x0400324E RID: 12878
		public uint sendTimes;

		// Token: 0x0400324F RID: 12879
		public uint sendLimit;

		// Token: 0x04003250 RID: 12880
		public uint sendedTotalTimes;

		// Token: 0x04003251 RID: 12881
		public uint sendedTotalLimit;
	}
}
