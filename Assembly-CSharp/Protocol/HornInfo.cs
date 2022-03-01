using System;

namespace Protocol
{
	// Token: 0x02000784 RID: 1924
	public class HornInfo : IProtocolStream
	{
		// Token: 0x06005EA2 RID: 24226 RVA: 0x0011BB10 File Offset: 0x00119F10
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roldId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.viplvl);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.content);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.minTime);
			BaseDLL.encode_int8(buffer, ref pos_, this.maxTime);
			BaseDLL.encode_uint16(buffer, ref pos_, this.combo);
			BaseDLL.encode_int8(buffer, ref pos_, this.num);
			BaseDLL.encode_uint32(buffer, ref pos_, this.headFrame);
		}

		// Token: 0x06005EA3 RID: 24227 RVA: 0x0011BBD4 File Offset: 0x00119FD4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roldId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.viplvl);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.content = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.minTime);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.maxTime);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.combo);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.num);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.headFrame);
		}

		// Token: 0x06005EA4 RID: 24228 RVA: 0x0011BCE8 File Offset: 0x0011A0E8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roldId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.viplvl);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.content);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.minTime);
			BaseDLL.encode_int8(buffer, ref pos_, this.maxTime);
			BaseDLL.encode_uint16(buffer, ref pos_, this.combo);
			BaseDLL.encode_int8(buffer, ref pos_, this.num);
			BaseDLL.encode_uint32(buffer, ref pos_, this.headFrame);
		}

		// Token: 0x06005EA5 RID: 24229 RVA: 0x0011BDB4 File Offset: 0x0011A1B4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roldId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.viplvl);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.content = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.minTime);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.maxTime);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.combo);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.num);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.headFrame);
		}

		// Token: 0x06005EA6 RID: 24230 RVA: 0x0011BEC8 File Offset: 0x0011A2C8
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num++;
			num += 2;
			num++;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.content);
			num += 2 + array2.Length;
			num++;
			num++;
			num += 2;
			num++;
			return num + 4;
		}

		// Token: 0x040026EE RID: 9966
		public ulong roldId;

		// Token: 0x040026EF RID: 9967
		public string name;

		// Token: 0x040026F0 RID: 9968
		public byte occu;

		// Token: 0x040026F1 RID: 9969
		public ushort level;

		// Token: 0x040026F2 RID: 9970
		public byte viplvl;

		// Token: 0x040026F3 RID: 9971
		public string content;

		// Token: 0x040026F4 RID: 9972
		public byte minTime;

		// Token: 0x040026F5 RID: 9973
		public byte maxTime;

		// Token: 0x040026F6 RID: 9974
		public ushort combo;

		// Token: 0x040026F7 RID: 9975
		public byte num;

		// Token: 0x040026F8 RID: 9976
		public uint headFrame;
	}
}
