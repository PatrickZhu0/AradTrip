using System;

namespace Protocol
{
	// Token: 0x02000764 RID: 1892
	[Protocol]
	public class UnionChampionScoreRankTopSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005DA6 RID: 23974 RVA: 0x001190C8 File Offset: 0x001174C8
		public uint GetMsgID()
		{
			return 1209811U;
		}

		// Token: 0x06005DA7 RID: 23975 RVA: 0x001190CF File Offset: 0x001174CF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005DA8 RID: 23976 RVA: 0x001190D7 File Offset: 0x001174D7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005DA9 RID: 23977 RVA: 0x001190E0 File Offset: 0x001174E0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.rankList.Length);
			for (int i = 0; i < this.rankList.Length; i++)
			{
				this.rankList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005DAA RID: 23978 RVA: 0x00119128 File Offset: 0x00117528
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.rankList = new RankRole[(int)num];
			for (int i = 0; i < this.rankList.Length; i++)
			{
				this.rankList[i] = new RankRole();
				this.rankList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005DAB RID: 23979 RVA: 0x00119184 File Offset: 0x00117584
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.rankList.Length);
			for (int i = 0; i < this.rankList.Length; i++)
			{
				this.rankList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005DAC RID: 23980 RVA: 0x001191CC File Offset: 0x001175CC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.rankList = new RankRole[(int)num];
			for (int i = 0; i < this.rankList.Length; i++)
			{
				this.rankList[i] = new RankRole();
				this.rankList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005DAD RID: 23981 RVA: 0x00119228 File Offset: 0x00117628
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.rankList.Length; i++)
			{
				num += this.rankList[i].getLen();
			}
			return num;
		}

		// Token: 0x04002664 RID: 9828
		public const uint MsgID = 1209811U;

		// Token: 0x04002665 RID: 9829
		public uint Sequence;

		// Token: 0x04002666 RID: 9830
		public RankRole[] rankList = new RankRole[0];
	}
}
