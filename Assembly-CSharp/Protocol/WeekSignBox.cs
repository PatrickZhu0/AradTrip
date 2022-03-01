using System;

namespace Protocol
{
	// Token: 0x02000A41 RID: 2625
	public class WeekSignBox : IProtocolStream
	{
		// Token: 0x060073AE RID: 29614 RVA: 0x0014FA38 File Offset: 0x0014DE38
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemVec.Length);
			for (int i = 0; i < this.itemVec.Length; i++)
			{
				this.itemVec[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060073AF RID: 29615 RVA: 0x0014FA8C File Offset: 0x0014DE8C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.itemVec = new ItemReward[(int)num];
			for (int i = 0; i < this.itemVec.Length; i++)
			{
				this.itemVec[i] = new ItemReward();
				this.itemVec[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060073B0 RID: 29616 RVA: 0x0014FAF4 File Offset: 0x0014DEF4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemVec.Length);
			for (int i = 0; i < this.itemVec.Length; i++)
			{
				this.itemVec[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060073B1 RID: 29617 RVA: 0x0014FB48 File Offset: 0x0014DF48
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.itemVec = new ItemReward[(int)num];
			for (int i = 0; i < this.itemVec.Length; i++)
			{
				this.itemVec[i] = new ItemReward();
				this.itemVec[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060073B2 RID: 29618 RVA: 0x0014FBB0 File Offset: 0x0014DFB0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.itemVec.Length; i++)
			{
				num += this.itemVec[i].getLen();
			}
			return num;
		}

		// Token: 0x040035B0 RID: 13744
		public uint opActId;

		// Token: 0x040035B1 RID: 13745
		public ItemReward[] itemVec = new ItemReward[0];
	}
}
