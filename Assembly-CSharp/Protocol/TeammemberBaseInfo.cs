using System;

namespace Protocol
{
	// Token: 0x02000B78 RID: 2936
	public class TeammemberBaseInfo : IProtocolStream
	{
		// Token: 0x06007C9C RID: 31900 RVA: 0x00163660 File Offset: 0x00161A60
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06007C9D RID: 31901 RVA: 0x001636C0 File Offset: 0x00161AC0
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
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06007C9E RID: 31902 RVA: 0x00163744 File Offset: 0x00161B44
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			this.playerLabelInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06007C9F RID: 31903 RVA: 0x001637A8 File Offset: 0x00161BA8
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
			this.playerLabelInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06007CA0 RID: 31904 RVA: 0x0016382C File Offset: 0x00161C2C
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num += 2;
			num++;
			return num + this.playerLabelInfo.getLen();
		}

		// Token: 0x04003B10 RID: 15120
		public ulong id;

		// Token: 0x04003B11 RID: 15121
		public string name;

		// Token: 0x04003B12 RID: 15122
		public ushort level;

		// Token: 0x04003B13 RID: 15123
		public byte occu;

		// Token: 0x04003B14 RID: 15124
		public PlayerLabelInfo playerLabelInfo = new PlayerLabelInfo();
	}
}
