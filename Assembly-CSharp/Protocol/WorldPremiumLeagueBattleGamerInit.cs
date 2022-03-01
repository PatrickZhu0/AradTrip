using System;

namespace Protocol
{
	// Token: 0x02000A6C RID: 2668
	[Protocol]
	public class WorldPremiumLeagueBattleGamerInit : IProtocolStream, IGetMsgID
	{
		// Token: 0x060074FB RID: 29947 RVA: 0x001529B0 File Offset: 0x00150DB0
		public uint GetMsgID()
		{
			return 607706U;
		}

		// Token: 0x060074FC RID: 29948 RVA: 0x001529B7 File Offset: 0x00150DB7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060074FD RID: 29949 RVA: 0x001529BF File Offset: 0x00150DBF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060074FE RID: 29950 RVA: 0x001529C8 File Offset: 0x00150DC8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.gamers.Length);
			for (int i = 0; i < this.gamers.Length; i++)
			{
				this.gamers[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060074FF RID: 29951 RVA: 0x00152A10 File Offset: 0x00150E10
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.gamers = new PremiumLeagueBattleGamer[(int)num];
			for (int i = 0; i < this.gamers.Length; i++)
			{
				this.gamers[i] = new PremiumLeagueBattleGamer();
				this.gamers[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007500 RID: 29952 RVA: 0x00152A6C File Offset: 0x00150E6C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.gamers.Length);
			for (int i = 0; i < this.gamers.Length; i++)
			{
				this.gamers[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007501 RID: 29953 RVA: 0x00152AB4 File Offset: 0x00150EB4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.gamers = new PremiumLeagueBattleGamer[(int)num];
			for (int i = 0; i < this.gamers.Length; i++)
			{
				this.gamers[i] = new PremiumLeagueBattleGamer();
				this.gamers[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007502 RID: 29954 RVA: 0x00152B10 File Offset: 0x00150F10
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.gamers.Length; i++)
			{
				num += this.gamers[i].getLen();
			}
			return num;
		}

		// Token: 0x04003668 RID: 13928
		public const uint MsgID = 607706U;

		// Token: 0x04003669 RID: 13929
		public uint Sequence;

		// Token: 0x0400366A RID: 13930
		public PremiumLeagueBattleGamer[] gamers = new PremiumLeagueBattleGamer[0];
	}
}
