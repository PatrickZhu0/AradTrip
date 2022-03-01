using System;

namespace Protocol
{
	// Token: 0x02000B35 RID: 2869
	public class SkillBars : IProtocolStream
	{
		// Token: 0x06007AA7 RID: 31399 RVA: 0x0015FFCC File Offset: 0x0015E3CC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.index);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.bar.Length);
			for (int i = 0; i < this.bar.Length; i++)
			{
				this.bar[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007AA8 RID: 31400 RVA: 0x00160020 File Offset: 0x0015E420
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.index);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.bar = new SkillBar[(int)num];
			for (int i = 0; i < this.bar.Length; i++)
			{
				this.bar[i] = new SkillBar();
				this.bar[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007AA9 RID: 31401 RVA: 0x00160088 File Offset: 0x0015E488
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.index);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.bar.Length);
			for (int i = 0; i < this.bar.Length; i++)
			{
				this.bar[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007AAA RID: 31402 RVA: 0x001600DC File Offset: 0x0015E4DC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.index);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.bar = new SkillBar[(int)num];
			for (int i = 0; i < this.bar.Length; i++)
			{
				this.bar[i] = new SkillBar();
				this.bar[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007AAB RID: 31403 RVA: 0x00160144 File Offset: 0x0015E544
		public int getLen()
		{
			int num = 0;
			num++;
			num += 2;
			for (int i = 0; i < this.bar.Length; i++)
			{
				num += this.bar[i].getLen();
			}
			return num;
		}

		// Token: 0x04003A28 RID: 14888
		public byte index;

		// Token: 0x04003A29 RID: 14889
		public SkillBar[] bar = new SkillBar[0];
	}
}
