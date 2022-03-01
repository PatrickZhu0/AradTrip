using System;

namespace Protocol
{
	// Token: 0x0200074D RID: 1869
	public class ChampionTop16Player : IProtocolStream
	{
		// Token: 0x06005CE3 RID: 23779 RVA: 0x0011792C File Offset: 0x00115D2C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pos);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			this.avatar.encode(buffer, ref pos_);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.server);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.zoneID);
		}

		// Token: 0x06005CE4 RID: 23780 RVA: 0x001179B8 File Offset: 0x00115DB8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pos);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			this.avatar.decode(buffer, ref pos_);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.server = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.zoneID);
		}

		// Token: 0x06005CE5 RID: 23781 RVA: 0x00117A94 File Offset: 0x00115E94
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pos);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			this.avatar.encode(buffer, ref pos_);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.server);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.zoneID);
		}

		// Token: 0x06005CE6 RID: 23782 RVA: 0x00117B24 File Offset: 0x00115F24
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pos);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			this.avatar.decode(buffer, ref pos_);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.server = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.zoneID);
		}

		// Token: 0x06005CE7 RID: 23783 RVA: 0x00117C00 File Offset: 0x00116000
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num++;
			num += this.avatar.getLen();
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.server);
			num += 2 + array2.Length;
			return num + 4;
		}

		// Token: 0x0400260C RID: 9740
		public ulong roleID;

		// Token: 0x0400260D RID: 9741
		public uint pos;

		// Token: 0x0400260E RID: 9742
		public string name;

		// Token: 0x0400260F RID: 9743
		public byte occu;

		// Token: 0x04002610 RID: 9744
		public PlayerAvatar avatar = new PlayerAvatar();

		// Token: 0x04002611 RID: 9745
		public string server;

		// Token: 0x04002612 RID: 9746
		public uint zoneID;
	}
}
