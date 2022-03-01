using System;

namespace Protocol
{
	// Token: 0x02000819 RID: 2073
	public class GuildRequesterInfo : IProtocolStream
	{
		// Token: 0x06006283 RID: 25219 RVA: 0x00126AE8 File Offset: 0x00124EE8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_int8(buffer, ref pos_, this.vipLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.requestTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonLevel);
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06006284 RID: 25220 RVA: 0x00126B74 File Offset: 0x00124F74
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.vipLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.requestTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonLevel);
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06006285 RID: 25221 RVA: 0x00126C24 File Offset: 0x00125024
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_int8(buffer, ref pos_, this.vipLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.requestTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonLevel);
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06006286 RID: 25222 RVA: 0x00126CB4 File Offset: 0x001250B4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.vipLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.requestTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonLevel);
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06006287 RID: 25223 RVA: 0x00126D64 File Offset: 0x00125164
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num += 2;
			num++;
			num++;
			num += 4;
			num += 4;
			return num + this.playerLabelInfo.getLen();
		}

		// Token: 0x04002C0C RID: 11276
		public ulong id;

		// Token: 0x04002C0D RID: 11277
		public string name;

		// Token: 0x04002C0E RID: 11278
		public ushort level;

		// Token: 0x04002C0F RID: 11279
		public byte occu;

		// Token: 0x04002C10 RID: 11280
		public byte vipLevel;

		// Token: 0x04002C11 RID: 11281
		public uint requestTime;

		// Token: 0x04002C12 RID: 11282
		public uint seasonLevel;

		// Token: 0x04002C13 RID: 11283
		public PlayerLabelInfo playerLabelInfo = new PlayerLabelInfo();
	}
}
