using System;

namespace Protocol
{
	// Token: 0x02000846 RID: 2118
	[Protocol]
	public class WorldGuildDonateLogRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060063E8 RID: 25576 RVA: 0x0012B238 File Offset: 0x00129638
		public uint GetMsgID()
		{
			return 601930U;
		}

		// Token: 0x060063E9 RID: 25577 RVA: 0x0012B23F File Offset: 0x0012963F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060063EA RID: 25578 RVA: 0x0012B247 File Offset: 0x00129647
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060063EB RID: 25579 RVA: 0x0012B250 File Offset: 0x00129650
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.logs.Length);
			for (int i = 0; i < this.logs.Length; i++)
			{
				this.logs[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060063EC RID: 25580 RVA: 0x0012B298 File Offset: 0x00129698
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.logs = new GuildDonateLog[(int)num];
			for (int i = 0; i < this.logs.Length; i++)
			{
				this.logs[i] = new GuildDonateLog();
				this.logs[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060063ED RID: 25581 RVA: 0x0012B2F4 File Offset: 0x001296F4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.logs.Length);
			for (int i = 0; i < this.logs.Length; i++)
			{
				this.logs[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060063EE RID: 25582 RVA: 0x0012B33C File Offset: 0x0012973C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.logs = new GuildDonateLog[(int)num];
			for (int i = 0; i < this.logs.Length; i++)
			{
				this.logs[i] = new GuildDonateLog();
				this.logs[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060063EF RID: 25583 RVA: 0x0012B398 File Offset: 0x00129798
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.logs.Length; i++)
			{
				num += this.logs[i].getLen();
			}
			return num;
		}

		// Token: 0x04002CD3 RID: 11475
		public const uint MsgID = 601930U;

		// Token: 0x04002CD4 RID: 11476
		public uint Sequence;

		// Token: 0x04002CD5 RID: 11477
		public GuildDonateLog[] logs = new GuildDonateLog[0];
	}
}
