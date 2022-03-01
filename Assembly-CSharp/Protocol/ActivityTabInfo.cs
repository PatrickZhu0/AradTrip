using System;

namespace Protocol
{
	// Token: 0x02000670 RID: 1648
	public class ActivityTabInfo : IProtocolStream
	{
		// Token: 0x0600561E RID: 22046 RVA: 0x00108264 File Offset: 0x00106664
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.actIds.Length);
			for (int i = 0; i < this.actIds.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.actIds[i]);
			}
		}

		// Token: 0x0600561F RID: 22047 RVA: 0x001082D8 File Offset: 0x001066D8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.actIds = new uint[(int)num2];
			for (int j = 0; j < this.actIds.Length; j++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.actIds[j]);
			}
		}

		// Token: 0x06005620 RID: 22048 RVA: 0x00108380 File Offset: 0x00106780
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.actIds.Length);
			for (int i = 0; i < this.actIds.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.actIds[i]);
			}
		}

		// Token: 0x06005621 RID: 22049 RVA: 0x001083F4 File Offset: 0x001067F4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.actIds = new uint[(int)num2];
			for (int j = 0; j < this.actIds.Length; j++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.actIds[j]);
			}
		}

		// Token: 0x06005622 RID: 22050 RVA: 0x0010849C File Offset: 0x0010689C
		public int getLen()
		{
			int num = 0;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			return num + (2 + 4 * this.actIds.Length);
		}

		// Token: 0x0400222E RID: 8750
		public uint id;

		// Token: 0x0400222F RID: 8751
		public string name;

		// Token: 0x04002230 RID: 8752
		public uint[] actIds = new uint[0];
	}
}
