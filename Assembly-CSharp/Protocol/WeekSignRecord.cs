using System;

namespace Protocol
{
	// Token: 0x02000A46 RID: 2630
	public class WeekSignRecord : IProtocolStream
	{
		// Token: 0x060073D8 RID: 29656 RVA: 0x0014FF7C File Offset: 0x0014E37C
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.serverName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.roleName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.createTime);
		}

		// Token: 0x060073D9 RID: 29657 RVA: 0x0014FFEC File Offset: 0x0014E3EC
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.serverName = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.roleName = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.createTime);
		}

		// Token: 0x060073DA RID: 29658 RVA: 0x001500AC File Offset: 0x0014E4AC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.serverName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.roleName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.createTime);
		}

		// Token: 0x060073DB RID: 29659 RVA: 0x00150124 File Offset: 0x0014E524
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.serverName = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.roleName = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.createTime);
		}

		// Token: 0x060073DC RID: 29660 RVA: 0x001501E4 File Offset: 0x0014E5E4
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.serverName);
			num += 2 + array.Length;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.roleName);
			num += 2 + array2.Length;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040035C0 RID: 13760
		public string serverName;

		// Token: 0x040035C1 RID: 13761
		public string roleName;

		// Token: 0x040035C2 RID: 13762
		public uint itemId;

		// Token: 0x040035C3 RID: 13763
		public uint itemNum;

		// Token: 0x040035C4 RID: 13764
		public uint createTime;
	}
}
