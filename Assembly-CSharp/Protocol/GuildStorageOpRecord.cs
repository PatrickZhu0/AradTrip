using System;

namespace Protocol
{
	// Token: 0x02000828 RID: 2088
	public class GuildStorageOpRecord : IProtocolStream
	{
		// Token: 0x060062DD RID: 25309 RVA: 0x00129798 File Offset: 0x00127B98
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.opType);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.time);
		}

		// Token: 0x060062DE RID: 25310 RVA: 0x00129818 File Offset: 0x00127C18
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opType);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.items = new GuildStorageItemInfo[(int)num2];
			for (int j = 0; j < this.items.Length; j++)
			{
				this.items[j] = new GuildStorageItemInfo();
				this.items[j].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time);
		}

		// Token: 0x060062DF RID: 25311 RVA: 0x001298D4 File Offset: 0x00127CD4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.opType);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.time);
		}

		// Token: 0x060062E0 RID: 25312 RVA: 0x00129958 File Offset: 0x00127D58
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opType);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.items = new GuildStorageItemInfo[(int)num2];
			for (int j = 0; j < this.items.Length; j++)
			{
				this.items[j] = new GuildStorageItemInfo();
				this.items[j].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time);
		}

		// Token: 0x060062E1 RID: 25313 RVA: 0x00129A14 File Offset: 0x00127E14
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num += 4;
			num += 2;
			for (int i = 0; i < this.items.Length; i++)
			{
				num += this.items[i].getLen();
			}
			return num + 4;
		}

		// Token: 0x04002C6F RID: 11375
		public string name;

		// Token: 0x04002C70 RID: 11376
		public uint opType;

		// Token: 0x04002C71 RID: 11377
		public GuildStorageItemInfo[] items = new GuildStorageItemInfo[0];

		// Token: 0x04002C72 RID: 11378
		public uint time;
	}
}
