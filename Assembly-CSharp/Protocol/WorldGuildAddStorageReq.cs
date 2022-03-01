using System;

namespace Protocol
{
	// Token: 0x02000871 RID: 2161
	[Protocol]
	public class WorldGuildAddStorageReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600656B RID: 25963 RVA: 0x0012DB7A File Offset: 0x0012BF7A
		public uint GetMsgID()
		{
			return 601972U;
		}

		// Token: 0x0600656C RID: 25964 RVA: 0x0012DB81 File Offset: 0x0012BF81
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600656D RID: 25965 RVA: 0x0012DB89 File Offset: 0x0012BF89
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600656E RID: 25966 RVA: 0x0012DB94 File Offset: 0x0012BF94
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600656F RID: 25967 RVA: 0x0012DBDC File Offset: 0x0012BFDC
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
		}

		// Token: 0x06006570 RID: 25968 RVA: 0x0012DC38 File Offset: 0x0012C038
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006571 RID: 25969 RVA: 0x0012DC80 File Offset: 0x0012C080
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
		}

		// Token: 0x06006572 RID: 25970 RVA: 0x0012DCDC File Offset: 0x0012C0DC
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

		// Token: 0x04002D72 RID: 11634
		public const uint MsgID = 601972U;

		// Token: 0x04002D73 RID: 11635
		public uint Sequence;

		// Token: 0x04002D74 RID: 11636
		public GuildStorageItemInfo[] items = new GuildStorageItemInfo[0];
	}
}
