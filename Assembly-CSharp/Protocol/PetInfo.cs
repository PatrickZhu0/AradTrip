using System;

namespace Protocol
{
	// Token: 0x02000A4C RID: 2636
	public class PetInfo : IProtocolStream
	{
		// Token: 0x0600740B RID: 29707 RVA: 0x00150750 File Offset: 0x0014EB50
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_uint32(buffer, ref pos_, this.exp);
			BaseDLL.encode_uint16(buffer, ref pos_, this.hunger);
			BaseDLL.encode_int8(buffer, ref pos_, this.skillIndex);
			BaseDLL.encode_int8(buffer, ref pos_, this.pointFeedCount);
			BaseDLL.encode_int8(buffer, ref pos_, this.goldFeedCount);
			BaseDLL.encode_int8(buffer, ref pos_, this.selectSkillCount);
			BaseDLL.encode_uint32(buffer, ref pos_, this.petScore);
		}

		// Token: 0x0600740C RID: 29708 RVA: 0x001507EC File Offset: 0x0014EBEC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.exp);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.hunger);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.skillIndex);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pointFeedCount);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.goldFeedCount);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.selectSkillCount);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.petScore);
		}

		// Token: 0x0600740D RID: 29709 RVA: 0x00150888 File Offset: 0x0014EC88
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_uint32(buffer, ref pos_, this.exp);
			BaseDLL.encode_uint16(buffer, ref pos_, this.hunger);
			BaseDLL.encode_int8(buffer, ref pos_, this.skillIndex);
			BaseDLL.encode_int8(buffer, ref pos_, this.pointFeedCount);
			BaseDLL.encode_int8(buffer, ref pos_, this.goldFeedCount);
			BaseDLL.encode_int8(buffer, ref pos_, this.selectSkillCount);
			BaseDLL.encode_uint32(buffer, ref pos_, this.petScore);
		}

		// Token: 0x0600740E RID: 29710 RVA: 0x00150924 File Offset: 0x0014ED24
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.exp);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.hunger);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.skillIndex);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pointFeedCount);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.goldFeedCount);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.selectSkillCount);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.petScore);
		}

		// Token: 0x0600740F RID: 29711 RVA: 0x001509C0 File Offset: 0x0014EDC0
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += 2;
			num += 4;
			num += 2;
			num++;
			num++;
			num++;
			num++;
			return num + 4;
		}

		// Token: 0x040035DB RID: 13787
		public ulong id;

		// Token: 0x040035DC RID: 13788
		public uint dataId;

		// Token: 0x040035DD RID: 13789
		public ushort level;

		// Token: 0x040035DE RID: 13790
		public uint exp;

		// Token: 0x040035DF RID: 13791
		public ushort hunger;

		// Token: 0x040035E0 RID: 13792
		public byte skillIndex;

		// Token: 0x040035E1 RID: 13793
		public byte pointFeedCount;

		// Token: 0x040035E2 RID: 13794
		public byte goldFeedCount;

		// Token: 0x040035E3 RID: 13795
		public byte selectSkillCount;

		// Token: 0x040035E4 RID: 13796
		public uint petScore;
	}
}
