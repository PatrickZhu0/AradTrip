using System;

namespace Protocol
{
	// Token: 0x020008AF RID: 2223
	public class HistoryHonorInfo : IProtocolStream
	{
		// Token: 0x06006775 RID: 26485 RVA: 0x0013118C File Offset: 0x0012F58C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dateType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalHonor);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.pvpStatisticsList.Length);
			for (int i = 0; i < this.pvpStatisticsList.Length; i++)
			{
				this.pvpStatisticsList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006776 RID: 26486 RVA: 0x001311F0 File Offset: 0x0012F5F0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dateType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalHonor);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.pvpStatisticsList = new PvpStatistics[(int)num];
			for (int i = 0; i < this.pvpStatisticsList.Length; i++)
			{
				this.pvpStatisticsList[i] = new PvpStatistics();
				this.pvpStatisticsList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006777 RID: 26487 RVA: 0x00131268 File Offset: 0x0012F668
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dateType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalHonor);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.pvpStatisticsList.Length);
			for (int i = 0; i < this.pvpStatisticsList.Length; i++)
			{
				this.pvpStatisticsList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006778 RID: 26488 RVA: 0x001312CC File Offset: 0x0012F6CC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dateType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalHonor);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.pvpStatisticsList = new PvpStatistics[(int)num];
			for (int i = 0; i < this.pvpStatisticsList.Length; i++)
			{
				this.pvpStatisticsList[i] = new PvpStatistics();
				this.pvpStatisticsList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006779 RID: 26489 RVA: 0x00131344 File Offset: 0x0012F744
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.pvpStatisticsList.Length; i++)
			{
				num += this.pvpStatisticsList[i].getLen();
			}
			return num;
		}

		// Token: 0x04002E3D RID: 11837
		public uint dateType;

		// Token: 0x04002E3E RID: 11838
		public uint totalHonor;

		// Token: 0x04002E3F RID: 11839
		public PvpStatistics[] pvpStatisticsList = new PvpStatistics[0];
	}
}
