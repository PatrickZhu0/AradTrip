using System;

namespace Protocol
{
	// Token: 0x02000A70 RID: 2672
	[Protocol]
	public class WorldPremiumLeagueBattleRecordRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600751F RID: 29983 RVA: 0x00152DC4 File Offset: 0x001511C4
		public uint GetMsgID()
		{
			return 607710U;
		}

		// Token: 0x06007520 RID: 29984 RVA: 0x00152DCB File Offset: 0x001511CB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007521 RID: 29985 RVA: 0x00152DD3 File Offset: 0x001511D3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007522 RID: 29986 RVA: 0x00152DDC File Offset: 0x001511DC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalCount);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.records.Length);
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007523 RID: 29987 RVA: 0x00152E30 File Offset: 0x00151230
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalCount);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.records = new PremiumLeagueRecordEntry[(int)num];
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i] = new PremiumLeagueRecordEntry();
				this.records[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007524 RID: 29988 RVA: 0x00152E98 File Offset: 0x00151298
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalCount);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.records.Length);
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007525 RID: 29989 RVA: 0x00152EEC File Offset: 0x001512EC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalCount);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.records = new PremiumLeagueRecordEntry[(int)num];
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i] = new PremiumLeagueRecordEntry();
				this.records[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007526 RID: 29990 RVA: 0x00152F54 File Offset: 0x00151354
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.records.Length; i++)
			{
				num += this.records[i].getLen();
			}
			return num;
		}

		// Token: 0x04003678 RID: 13944
		public const uint MsgID = 607710U;

		// Token: 0x04003679 RID: 13945
		public uint Sequence;

		// Token: 0x0400367A RID: 13946
		public uint totalCount;

		// Token: 0x0400367B RID: 13947
		public PremiumLeagueRecordEntry[] records = new PremiumLeagueRecordEntry[0];
	}
}
