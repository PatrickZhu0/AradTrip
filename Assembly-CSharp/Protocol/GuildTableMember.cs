using System;

namespace Protocol
{
	// Token: 0x0200081B RID: 2075
	public class GuildTableMember : IProtocolStream
	{
		// Token: 0x0600628F RID: 25231 RVA: 0x00126E5C File Offset: 0x0012525C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.seat);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06006290 RID: 25232 RVA: 0x00126ED8 File Offset: 0x001252D8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seat);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06006291 RID: 25233 RVA: 0x00126F78 File Offset: 0x00125378
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.seat);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06006292 RID: 25234 RVA: 0x00126FF8 File Offset: 0x001253F8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seat);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06006293 RID: 25235 RVA: 0x00127098 File Offset: 0x00125498
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 2;
			num++;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num++;
			num++;
			return num + this.playerLabelInfo.getLen();
		}

		// Token: 0x04002C16 RID: 11286
		public ulong id;

		// Token: 0x04002C17 RID: 11287
		public ushort level;

		// Token: 0x04002C18 RID: 11288
		public byte occu;

		// Token: 0x04002C19 RID: 11289
		public string name;

		// Token: 0x04002C1A RID: 11290
		public byte seat;

		// Token: 0x04002C1B RID: 11291
		public byte type;

		// Token: 0x04002C1C RID: 11292
		public PlayerLabelInfo playerLabelInfo = new PlayerLabelInfo();
	}
}
