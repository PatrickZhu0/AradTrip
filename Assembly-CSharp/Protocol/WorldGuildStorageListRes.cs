using System;

namespace Protocol
{
	// Token: 0x0200086F RID: 2159
	[Protocol]
	public class WorldGuildStorageListRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006559 RID: 25945 RVA: 0x0012D528 File Offset: 0x0012B928
		public uint GetMsgID()
		{
			return 601970U;
		}

		// Token: 0x0600655A RID: 25946 RVA: 0x0012D52F File Offset: 0x0012B92F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600655B RID: 25947 RVA: 0x0012D537 File Offset: 0x0012B937
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600655C RID: 25948 RVA: 0x0012D540 File Offset: 0x0012B940
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.maxSize);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemRecords.Length);
			for (int j = 0; j < this.itemRecords.Length; j++)
			{
				this.itemRecords[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600655D RID: 25949 RVA: 0x0012D5DC File Offset: 0x0012B9DC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.maxSize);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new GuildStorageItemInfo[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new GuildStorageItemInfo();
				this.items[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.itemRecords = new GuildStorageOpRecord[(int)num2];
			for (int j = 0; j < this.itemRecords.Length; j++)
			{
				this.itemRecords[j] = new GuildStorageOpRecord();
				this.itemRecords[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600655E RID: 25950 RVA: 0x0012D6A0 File Offset: 0x0012BAA0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.maxSize);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemRecords.Length);
			for (int j = 0; j < this.itemRecords.Length; j++)
			{
				this.itemRecords[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600655F RID: 25951 RVA: 0x0012D73C File Offset: 0x0012BB3C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.maxSize);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new GuildStorageItemInfo[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new GuildStorageItemInfo();
				this.items[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.itemRecords = new GuildStorageOpRecord[(int)num2];
			for (int j = 0; j < this.itemRecords.Length; j++)
			{
				this.itemRecords[j] = new GuildStorageOpRecord();
				this.itemRecords[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006560 RID: 25952 RVA: 0x0012D800 File Offset: 0x0012BC00
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.items.Length; i++)
			{
				num += this.items[i].getLen();
			}
			num += 2;
			for (int j = 0; j < this.itemRecords.Length; j++)
			{
				num += this.itemRecords[j].getLen();
			}
			return num;
		}

		// Token: 0x04002D68 RID: 11624
		public const uint MsgID = 601970U;

		// Token: 0x04002D69 RID: 11625
		public uint Sequence;

		// Token: 0x04002D6A RID: 11626
		public uint result;

		// Token: 0x04002D6B RID: 11627
		public uint maxSize;

		// Token: 0x04002D6C RID: 11628
		public GuildStorageItemInfo[] items = new GuildStorageItemInfo[0];

		// Token: 0x04002D6D RID: 11629
		public GuildStorageOpRecord[] itemRecords = new GuildStorageOpRecord[0];
	}
}
