using System;

namespace Protocol
{
	// Token: 0x02000873 RID: 2163
	[Protocol]
	public class WorldGuildDelStorageReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600657D RID: 25981 RVA: 0x0012DDA4 File Offset: 0x0012C1A4
		public uint GetMsgID()
		{
			return 601974U;
		}

		// Token: 0x0600657E RID: 25982 RVA: 0x0012DDAB File Offset: 0x0012C1AB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600657F RID: 25983 RVA: 0x0012DDB3 File Offset: 0x0012C1B3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006580 RID: 25984 RVA: 0x0012DDBC File Offset: 0x0012C1BC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006581 RID: 25985 RVA: 0x0012DE04 File Offset: 0x0012C204
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new GuildStorageDelItemInfo[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new GuildStorageDelItemInfo();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006582 RID: 25986 RVA: 0x0012DE60 File Offset: 0x0012C260
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006583 RID: 25987 RVA: 0x0012DEA8 File Offset: 0x0012C2A8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new GuildStorageDelItemInfo[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new GuildStorageDelItemInfo();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006584 RID: 25988 RVA: 0x0012DF04 File Offset: 0x0012C304
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.items.Length; i++)
			{
				num += this.items[i].getLen();
			}
			return num;
		}

		// Token: 0x04002D78 RID: 11640
		public const uint MsgID = 601974U;

		// Token: 0x04002D79 RID: 11641
		public uint Sequence;

		// Token: 0x04002D7A RID: 11642
		public GuildStorageDelItemInfo[] items = new GuildStorageDelItemInfo[0];
	}
}
