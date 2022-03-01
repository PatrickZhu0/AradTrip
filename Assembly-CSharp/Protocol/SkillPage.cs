using System;

namespace Protocol
{
	// Token: 0x02000B58 RID: 2904
	public class SkillPage : IProtocolStream
	{
		// Token: 0x06007BC7 RID: 31687 RVA: 0x00162450 File Offset: 0x00160850
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.skillList.Length);
			for (int i = 0; i < this.skillList.Length; i++)
			{
				this.skillList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007BC8 RID: 31688 RVA: 0x00162498 File Offset: 0x00160898
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.skillList = new Skill[(int)num];
			for (int i = 0; i < this.skillList.Length; i++)
			{
				this.skillList[i] = new Skill();
				this.skillList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007BC9 RID: 31689 RVA: 0x001624F4 File Offset: 0x001608F4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.skillList.Length);
			for (int i = 0; i < this.skillList.Length; i++)
			{
				this.skillList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007BCA RID: 31690 RVA: 0x0016253C File Offset: 0x0016093C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.skillList = new Skill[(int)num];
			for (int i = 0; i < this.skillList.Length; i++)
			{
				this.skillList[i] = new Skill();
				this.skillList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007BCB RID: 31691 RVA: 0x00162598 File Offset: 0x00160998
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.skillList.Length; i++)
			{
				num += this.skillList[i].getLen();
			}
			return num;
		}

		// Token: 0x04003AAC RID: 15020
		public Skill[] skillList = new Skill[0];
	}
}
