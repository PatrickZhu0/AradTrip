using System;

namespace Protocol
{
	// Token: 0x0200072F RID: 1839
	public class MapInfo : IProtocolStream
	{
		// Token: 0x06005BFC RID: 23548 RVA: 0x00115E08 File Offset: 0x00114208
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.terrain);
			BaseDLL.encode_uint32(buffer, ref pos_, this.winShooterId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.shooter.Length);
			for (int i = 0; i < this.shooter.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.shooter[i]);
			}
		}

		// Token: 0x06005BFD RID: 23549 RVA: 0x00115E7C File Offset: 0x0011427C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.terrain);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.winShooterId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.shooter = new uint[(int)num];
			for (int i = 0; i < this.shooter.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.shooter[i]);
			}
		}

		// Token: 0x06005BFE RID: 23550 RVA: 0x00115EF8 File Offset: 0x001142F8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.terrain);
			BaseDLL.encode_uint32(buffer, ref pos_, this.winShooterId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.shooter.Length);
			for (int i = 0; i < this.shooter.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.shooter[i]);
			}
		}

		// Token: 0x06005BFF RID: 23551 RVA: 0x00115F6C File Offset: 0x0011436C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.terrain);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.winShooterId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.shooter = new uint[(int)num];
			for (int i = 0; i < this.shooter.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.shooter[i]);
			}
		}

		// Token: 0x06005C00 RID: 23552 RVA: 0x00115FE8 File Offset: 0x001143E8
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			return num + (2 + 4 * this.shooter.Length);
		}

		// Token: 0x04002588 RID: 9608
		public uint id;

		// Token: 0x04002589 RID: 9609
		public uint terrain;

		// Token: 0x0400258A RID: 9610
		public uint winShooterId;

		// Token: 0x0400258B RID: 9611
		public uint[] shooter = new uint[0];
	}
}
