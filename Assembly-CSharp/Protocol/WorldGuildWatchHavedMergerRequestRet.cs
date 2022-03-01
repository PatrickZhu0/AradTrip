using System;

namespace Protocol
{
	// Token: 0x020008A2 RID: 2210
	[Protocol]
	public class WorldGuildWatchHavedMergerRequestRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600670F RID: 26383 RVA: 0x001308C8 File Offset: 0x0012ECC8
		public uint GetMsgID()
		{
			return 601984U;
		}

		// Token: 0x06006710 RID: 26384 RVA: 0x001308CF File Offset: 0x0012ECCF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006711 RID: 26385 RVA: 0x001308D7 File Offset: 0x0012ECD7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006712 RID: 26386 RVA: 0x001308E0 File Offset: 0x0012ECE0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.guilds.Length);
			for (int i = 0; i < this.guilds.Length; i++)
			{
				this.guilds[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006713 RID: 26387 RVA: 0x00130928 File Offset: 0x0012ED28
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.guilds = new GuildEntry[(int)num];
			for (int i = 0; i < this.guilds.Length; i++)
			{
				this.guilds[i] = new GuildEntry();
				this.guilds[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006714 RID: 26388 RVA: 0x00130984 File Offset: 0x0012ED84
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.guilds.Length);
			for (int i = 0; i < this.guilds.Length; i++)
			{
				this.guilds[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006715 RID: 26389 RVA: 0x001309CC File Offset: 0x0012EDCC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.guilds = new GuildEntry[(int)num];
			for (int i = 0; i < this.guilds.Length; i++)
			{
				this.guilds[i] = new GuildEntry();
				this.guilds[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006716 RID: 26390 RVA: 0x00130A28 File Offset: 0x0012EE28
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.guilds.Length; i++)
			{
				num += this.guilds[i].getLen();
			}
			return num;
		}

		// Token: 0x04002E12 RID: 11794
		public const uint MsgID = 601984U;

		// Token: 0x04002E13 RID: 11795
		public uint Sequence;

		// Token: 0x04002E14 RID: 11796
		public GuildEntry[] guilds = new GuildEntry[0];
	}
}
