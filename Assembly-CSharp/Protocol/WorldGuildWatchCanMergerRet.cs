using System;

namespace Protocol
{
	// Token: 0x0200089C RID: 2204
	[Protocol]
	public class WorldGuildWatchCanMergerRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060066D9 RID: 26329 RVA: 0x00130458 File Offset: 0x0012E858
		public uint GetMsgID()
		{
			return 601978U;
		}

		// Token: 0x060066DA RID: 26330 RVA: 0x0013045F File Offset: 0x0012E85F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060066DB RID: 26331 RVA: 0x00130467 File Offset: 0x0012E867
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060066DC RID: 26332 RVA: 0x00130470 File Offset: 0x0012E870
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.start);
			BaseDLL.encode_uint16(buffer, ref pos_, this.totalNum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.guilds.Length);
			for (int i = 0; i < this.guilds.Length; i++)
			{
				this.guilds[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060066DD RID: 26333 RVA: 0x001304D4 File Offset: 0x0012E8D4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.start);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.totalNum);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.guilds = new GuildEntry[(int)num];
			for (int i = 0; i < this.guilds.Length; i++)
			{
				this.guilds[i] = new GuildEntry();
				this.guilds[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060066DE RID: 26334 RVA: 0x0013054C File Offset: 0x0012E94C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.start);
			BaseDLL.encode_uint16(buffer, ref pos_, this.totalNum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.guilds.Length);
			for (int i = 0; i < this.guilds.Length; i++)
			{
				this.guilds[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060066DF RID: 26335 RVA: 0x001305B0 File Offset: 0x0012E9B0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.start);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.totalNum);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.guilds = new GuildEntry[(int)num];
			for (int i = 0; i < this.guilds.Length; i++)
			{
				this.guilds[i] = new GuildEntry();
				this.guilds[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060066E0 RID: 26336 RVA: 0x00130628 File Offset: 0x0012EA28
		public int getLen()
		{
			int num = 0;
			num += 2;
			num += 2;
			num += 2;
			for (int i = 0; i < this.guilds.Length; i++)
			{
				num += this.guilds[i].getLen();
			}
			return num;
		}

		// Token: 0x04002DFE RID: 11774
		public const uint MsgID = 601978U;

		// Token: 0x04002DFF RID: 11775
		public uint Sequence;

		// Token: 0x04002E00 RID: 11776
		public ushort start;

		// Token: 0x04002E01 RID: 11777
		public ushort totalNum;

		// Token: 0x04002E02 RID: 11778
		public GuildEntry[] guilds = new GuildEntry[0];
	}
}
