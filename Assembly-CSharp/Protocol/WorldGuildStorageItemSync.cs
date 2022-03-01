using System;

namespace Protocol
{
	// Token: 0x02000870 RID: 2160
	[Protocol]
	public class WorldGuildStorageItemSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006562 RID: 25954 RVA: 0x0012D892 File Offset: 0x0012BC92
		public uint GetMsgID()
		{
			return 601971U;
		}

		// Token: 0x06006563 RID: 25955 RVA: 0x0012D899 File Offset: 0x0012BC99
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006564 RID: 25956 RVA: 0x0012D8A1 File Offset: 0x0012BCA1
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006565 RID: 25957 RVA: 0x0012D8AC File Offset: 0x0012BCAC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.records.Length);
			for (int j = 0; j < this.records.Length; j++)
			{
				this.records[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006566 RID: 25958 RVA: 0x0012D92C File Offset: 0x0012BD2C
		public void decode(byte[] buffer, ref int pos_)
		{
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
			this.records = new GuildStorageOpRecord[(int)num2];
			for (int j = 0; j < this.records.Length; j++)
			{
				this.records[j] = new GuildStorageOpRecord();
				this.records[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006567 RID: 25959 RVA: 0x0012D9D4 File Offset: 0x0012BDD4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.records.Length);
			for (int j = 0; j < this.records.Length; j++)
			{
				this.records[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006568 RID: 25960 RVA: 0x0012DA54 File Offset: 0x0012BE54
		public void decode(MapViewStream buffer, ref int pos_)
		{
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
			this.records = new GuildStorageOpRecord[(int)num2];
			for (int j = 0; j < this.records.Length; j++)
			{
				this.records[j] = new GuildStorageOpRecord();
				this.records[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006569 RID: 25961 RVA: 0x0012DAFC File Offset: 0x0012BEFC
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.items.Length; i++)
			{
				num += this.items[i].getLen();
			}
			num += 2;
			for (int j = 0; j < this.records.Length; j++)
			{
				num += this.records[j].getLen();
			}
			return num;
		}

		// Token: 0x04002D6E RID: 11630
		public const uint MsgID = 601971U;

		// Token: 0x04002D6F RID: 11631
		public uint Sequence;

		// Token: 0x04002D70 RID: 11632
		public GuildStorageItemInfo[] items = new GuildStorageItemInfo[0];

		// Token: 0x04002D71 RID: 11633
		public GuildStorageOpRecord[] records = new GuildStorageOpRecord[0];
	}
}
