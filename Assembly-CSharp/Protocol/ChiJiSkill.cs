using System;

namespace Protocol
{
	// Token: 0x0200071D RID: 1821
	public class ChiJiSkill : IProtocolStream
	{
		// Token: 0x06005B78 RID: 23416 RVA: 0x001152AC File Offset: 0x001136AC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.skillId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.skillLvl);
		}

		// Token: 0x06005B79 RID: 23417 RVA: 0x001152CA File Offset: 0x001136CA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.skillId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.skillLvl);
		}

		// Token: 0x06005B7A RID: 23418 RVA: 0x001152E8 File Offset: 0x001136E8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.skillId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.skillLvl);
		}

		// Token: 0x06005B7B RID: 23419 RVA: 0x00115306 File Offset: 0x00113706
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.skillId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.skillLvl);
		}

		// Token: 0x06005B7C RID: 23420 RVA: 0x00115324 File Offset: 0x00113724
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400254B RID: 9547
		public uint skillId;

		// Token: 0x0400254C RID: 9548
		public uint skillLvl;
	}
}
