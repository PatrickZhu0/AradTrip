using System;

namespace Protocol
{
	// Token: 0x020007BD RID: 1981
	public class RollDropResultItem : IProtocolStream
	{
		// Token: 0x06006019 RID: 24601 RVA: 0x0011FF98 File Offset: 0x0011E398
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.rollIndex);
			BaseDLL.encode_int8(buffer, ref pos_, this.opType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.point);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x0600601A RID: 24602 RVA: 0x0011FFFC File Offset: 0x0011E3FC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.rollIndex);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.opType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.point);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.playerName = StringHelper.BytesToString(array);
		}

		// Token: 0x0600601B RID: 24603 RVA: 0x00120084 File Offset: 0x0011E484
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.rollIndex);
			BaseDLL.encode_int8(buffer, ref pos_, this.opType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.point);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x0600601C RID: 24604 RVA: 0x001200E8 File Offset: 0x0011E4E8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.rollIndex);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.opType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.point);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.playerName = StringHelper.BytesToString(array);
		}

		// Token: 0x0600601D RID: 24605 RVA: 0x00120170 File Offset: 0x0011E570
		public int getLen()
		{
			int num = 0;
			num++;
			num++;
			num += 4;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.playerName);
			return num + (2 + array.Length);
		}

		// Token: 0x040027D4 RID: 10196
		public byte rollIndex;

		// Token: 0x040027D5 RID: 10197
		public byte opType;

		// Token: 0x040027D6 RID: 10198
		public uint point;

		// Token: 0x040027D7 RID: 10199
		public ulong playerId;

		// Token: 0x040027D8 RID: 10200
		public string playerName;
	}
}
