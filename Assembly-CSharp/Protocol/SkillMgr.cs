using System;

namespace Protocol
{
	// Token: 0x02000B59 RID: 2905
	public class SkillMgr : IProtocolStream
	{
		// Token: 0x06007BCD RID: 31693 RVA: 0x001625EC File Offset: 0x001609EC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.pageCnt);
			BaseDLL.encode_uint32(buffer, ref pos_, this.currentPage);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.skillPages.Length);
			for (int i = 0; i < this.skillPages.Length; i++)
			{
				this.skillPages[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007BCE RID: 31694 RVA: 0x00162650 File Offset: 0x00160A50
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pageCnt);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.currentPage);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.skillPages = new SkillPage[(int)num];
			for (int i = 0; i < this.skillPages.Length; i++)
			{
				this.skillPages[i] = new SkillPage();
				this.skillPages[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007BCF RID: 31695 RVA: 0x001626C8 File Offset: 0x00160AC8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.pageCnt);
			BaseDLL.encode_uint32(buffer, ref pos_, this.currentPage);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.skillPages.Length);
			for (int i = 0; i < this.skillPages.Length; i++)
			{
				this.skillPages[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007BD0 RID: 31696 RVA: 0x0016272C File Offset: 0x00160B2C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pageCnt);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.currentPage);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.skillPages = new SkillPage[(int)num];
			for (int i = 0; i < this.skillPages.Length; i++)
			{
				this.skillPages[i] = new SkillPage();
				this.skillPages[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007BD1 RID: 31697 RVA: 0x001627A4 File Offset: 0x00160BA4
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.skillPages.Length; i++)
			{
				num += this.skillPages[i].getLen();
			}
			return num;
		}

		// Token: 0x04003AAD RID: 15021
		public uint pageCnt;

		// Token: 0x04003AAE RID: 15022
		public uint currentPage;

		// Token: 0x04003AAF RID: 15023
		public SkillPage[] skillPages = new SkillPage[0];
	}
}
