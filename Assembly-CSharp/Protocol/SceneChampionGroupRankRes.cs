using System;

namespace Protocol
{
	// Token: 0x0200075D RID: 1885
	[Protocol]
	public class SceneChampionGroupRankRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005D6A RID: 23914 RVA: 0x001189C0 File Offset: 0x00116DC0
		public uint GetMsgID()
		{
			return 509824U;
		}

		// Token: 0x06005D6B RID: 23915 RVA: 0x001189C7 File Offset: 0x00116DC7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005D6C RID: 23916 RVA: 0x001189CF File Offset: 0x00116DCF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005D6D RID: 23917 RVA: 0x001189D8 File Offset: 0x00116DD8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.rankList.Length);
			for (int i = 0; i < this.rankList.Length; i++)
			{
				this.rankList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005D6E RID: 23918 RVA: 0x00118A20 File Offset: 0x00116E20
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

		// Token: 0x06005D6F RID: 23919 RVA: 0x00118A7C File Offset: 0x00116E7C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.rankList.Length);
			for (int i = 0; i < this.rankList.Length; i++)
			{
				this.rankList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005D70 RID: 23920 RVA: 0x00118AC4 File Offset: 0x00116EC4
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

		// Token: 0x06005D71 RID: 23921 RVA: 0x00118B20 File Offset: 0x00116F20
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

		// Token: 0x0400264B RID: 9803
		public const uint MsgID = 509824U;

		// Token: 0x0400264C RID: 9804
		public uint Sequence;

		// Token: 0x0400264D RID: 9805
		public RankRole[] rankList = new RankRole[0];
	}
}
