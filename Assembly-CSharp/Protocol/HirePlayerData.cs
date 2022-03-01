using System;

namespace Protocol
{
	// Token: 0x02000C40 RID: 3136
	public class HirePlayerData : IProtocolStream
	{
		// Token: 0x0600829C RID: 33436 RVA: 0x0016FD54 File Offset: 0x0016E154
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.userId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_int8(buffer, ref pos_, this.online);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lv);
		}

		// Token: 0x0600829D RID: 33437 RVA: 0x0016FDB8 File Offset: 0x0016E1B8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.userId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.online);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lv);
		}

		// Token: 0x0600829E RID: 33438 RVA: 0x0016FE40 File Offset: 0x0016E240
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.userId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_int8(buffer, ref pos_, this.online);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lv);
		}

		// Token: 0x0600829F RID: 33439 RVA: 0x0016FEA4 File Offset: 0x0016E2A4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.userId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.online);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lv);
		}

		// Token: 0x060082A0 RID: 33440 RVA: 0x0016FF2C File Offset: 0x0016E32C
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num++;
			num++;
			return num + 4;
		}

		// Token: 0x04003E5C RID: 15964
		public ulong userId;

		// Token: 0x04003E5D RID: 15965
		public string name;

		// Token: 0x04003E5E RID: 15966
		public byte occu;

		// Token: 0x04003E5F RID: 15967
		public byte online;

		// Token: 0x04003E60 RID: 15968
		public uint lv;
	}
}
