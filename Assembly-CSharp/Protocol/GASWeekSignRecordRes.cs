using System;

namespace Protocol
{
	// Token: 0x02000A47 RID: 2631
	[Protocol]
	public class GASWeekSignRecordRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060073DE RID: 29662 RVA: 0x0015023C File Offset: 0x0014E63C
		public uint GetMsgID()
		{
			return 707402U;
		}

		// Token: 0x060073DF RID: 29663 RVA: 0x00150243 File Offset: 0x0014E643
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060073E0 RID: 29664 RVA: 0x0015024B File Offset: 0x0014E64B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060073E1 RID: 29665 RVA: 0x00150254 File Offset: 0x0014E654
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActType);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.record.Length);
			for (int i = 0; i < this.record.Length; i++)
			{
				this.record[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060073E2 RID: 29666 RVA: 0x001502A8 File Offset: 0x0014E6A8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.record = new WeekSignRecord[(int)num];
			for (int i = 0; i < this.record.Length; i++)
			{
				this.record[i] = new WeekSignRecord();
				this.record[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060073E3 RID: 29667 RVA: 0x00150310 File Offset: 0x0014E710
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActType);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.record.Length);
			for (int i = 0; i < this.record.Length; i++)
			{
				this.record[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060073E4 RID: 29668 RVA: 0x00150364 File Offset: 0x0014E764
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.record = new WeekSignRecord[(int)num];
			for (int i = 0; i < this.record.Length; i++)
			{
				this.record[i] = new WeekSignRecord();
				this.record[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060073E5 RID: 29669 RVA: 0x001503CC File Offset: 0x0014E7CC
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.record.Length; i++)
			{
				num += this.record[i].getLen();
			}
			return num;
		}

		// Token: 0x040035C5 RID: 13765
		public const uint MsgID = 707402U;

		// Token: 0x040035C6 RID: 13766
		public uint Sequence;

		// Token: 0x040035C7 RID: 13767
		public uint opActType;

		// Token: 0x040035C8 RID: 13768
		public WeekSignRecord[] record = new WeekSignRecord[0];
	}
}
