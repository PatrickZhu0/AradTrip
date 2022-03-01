using System;

namespace Protocol
{
	// Token: 0x02000830 RID: 2096
	[Protocol]
	public class WorldGuildListRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006322 RID: 25378 RVA: 0x00129F58 File Offset: 0x00128358
		public uint GetMsgID()
		{
			return 601908U;
		}

		// Token: 0x06006323 RID: 25379 RVA: 0x00129F5F File Offset: 0x0012835F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006324 RID: 25380 RVA: 0x00129F67 File Offset: 0x00128367
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006325 RID: 25381 RVA: 0x00129F70 File Offset: 0x00128370
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.start);
			BaseDLL.encode_uint16(buffer, ref pos_, this.totalnum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.guilds.Length);
			for (int i = 0; i < this.guilds.Length; i++)
			{
				this.guilds[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006326 RID: 25382 RVA: 0x00129FD4 File Offset: 0x001283D4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.start);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.totalnum);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.guilds = new GuildEntry[(int)num];
			for (int i = 0; i < this.guilds.Length; i++)
			{
				this.guilds[i] = new GuildEntry();
				this.guilds[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006327 RID: 25383 RVA: 0x0012A04C File Offset: 0x0012844C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.start);
			BaseDLL.encode_uint16(buffer, ref pos_, this.totalnum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.guilds.Length);
			for (int i = 0; i < this.guilds.Length; i++)
			{
				this.guilds[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006328 RID: 25384 RVA: 0x0012A0B0 File Offset: 0x001284B0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.start);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.totalnum);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.guilds = new GuildEntry[(int)num];
			for (int i = 0; i < this.guilds.Length; i++)
			{
				this.guilds[i] = new GuildEntry();
				this.guilds[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006329 RID: 25385 RVA: 0x0012A128 File Offset: 0x00128528
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

		// Token: 0x04002C89 RID: 11401
		public const uint MsgID = 601908U;

		// Token: 0x04002C8A RID: 11402
		public uint Sequence;

		// Token: 0x04002C8B RID: 11403
		public ushort start;

		// Token: 0x04002C8C RID: 11404
		public ushort totalnum;

		// Token: 0x04002C8D RID: 11405
		public GuildEntry[] guilds = new GuildEntry[0];
	}
}
