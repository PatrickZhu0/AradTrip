using System;

namespace Protocol
{
	// Token: 0x02000744 RID: 1860
	[Protocol]
	public class shooterRankRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005CA4 RID: 23716 RVA: 0x00117574 File Offset: 0x00115974
		public uint GetMsgID()
		{
			return 708315U;
		}

		// Token: 0x06005CA5 RID: 23717 RVA: 0x0011757B File Offset: 0x0011597B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005CA6 RID: 23718 RVA: 0x00117583 File Offset: 0x00115983
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005CA7 RID: 23719 RVA: 0x0011758C File Offset: 0x0011598C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.shooterRankList.Length);
			for (int i = 0; i < this.shooterRankList.Length; i++)
			{
				this.shooterRankList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005CA8 RID: 23720 RVA: 0x001175D4 File Offset: 0x001159D4
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.shooterRankList = new shooterRankInfo[(int)num];
			for (int i = 0; i < this.shooterRankList.Length; i++)
			{
				this.shooterRankList[i] = new shooterRankInfo();
				this.shooterRankList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005CA9 RID: 23721 RVA: 0x00117630 File Offset: 0x00115A30
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.shooterRankList.Length);
			for (int i = 0; i < this.shooterRankList.Length; i++)
			{
				this.shooterRankList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005CAA RID: 23722 RVA: 0x00117678 File Offset: 0x00115A78
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.shooterRankList = new shooterRankInfo[(int)num];
			for (int i = 0; i < this.shooterRankList.Length; i++)
			{
				this.shooterRankList[i] = new shooterRankInfo();
				this.shooterRankList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005CAB RID: 23723 RVA: 0x001176D4 File Offset: 0x00115AD4
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.shooterRankList.Length; i++)
			{
				num += this.shooterRankList[i].getLen();
			}
			return num;
		}

		// Token: 0x040025D2 RID: 9682
		public const uint MsgID = 708315U;

		// Token: 0x040025D3 RID: 9683
		public uint Sequence;

		// Token: 0x040025D4 RID: 9684
		public shooterRankInfo[] shooterRankList = new shooterRankInfo[0];
	}
}
