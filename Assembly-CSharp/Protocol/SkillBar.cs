using System;

namespace Protocol
{
	// Token: 0x02000B34 RID: 2868
	public class SkillBar : IProtocolStream
	{
		// Token: 0x06007AA1 RID: 31393 RVA: 0x0015FDFC File Offset: 0x0015E1FC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.index);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.grids.Length);
			for (int i = 0; i < this.grids.Length; i++)
			{
				this.grids[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007AA2 RID: 31394 RVA: 0x0015FE50 File Offset: 0x0015E250
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.index);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.grids = new SkillBarGrid[(int)num];
			for (int i = 0; i < this.grids.Length; i++)
			{
				this.grids[i] = new SkillBarGrid();
				this.grids[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007AA3 RID: 31395 RVA: 0x0015FEB8 File Offset: 0x0015E2B8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.index);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.grids.Length);
			for (int i = 0; i < this.grids.Length; i++)
			{
				this.grids[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007AA4 RID: 31396 RVA: 0x0015FF0C File Offset: 0x0015E30C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.index);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.grids = new SkillBarGrid[(int)num];
			for (int i = 0; i < this.grids.Length; i++)
			{
				this.grids[i] = new SkillBarGrid();
				this.grids[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007AA5 RID: 31397 RVA: 0x0015FF74 File Offset: 0x0015E374
		public int getLen()
		{
			int num = 0;
			num++;
			num += 2;
			for (int i = 0; i < this.grids.Length; i++)
			{
				num += this.grids[i].getLen();
			}
			return num;
		}

		// Token: 0x04003A26 RID: 14886
		public byte index;

		// Token: 0x04003A27 RID: 14887
		public SkillBarGrid[] grids = new SkillBarGrid[0];
	}
}
