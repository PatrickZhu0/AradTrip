using System;

namespace Protocol
{
	// Token: 0x020007B6 RID: 1974
	public class DungeonHellWaveInfo : IProtocolStream
	{
		// Token: 0x06005FEF RID: 24559 RVA: 0x0011F3CC File Offset: 0x0011D7CC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.wave);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.monsters.Length);
			for (int i = 0; i < this.monsters.Length; i++)
			{
				this.monsters[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005FF0 RID: 24560 RVA: 0x0011F420 File Offset: 0x0011D820
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.wave);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.monsters = new SceneDungeonMonster[(int)num];
			for (int i = 0; i < this.monsters.Length; i++)
			{
				this.monsters[i] = new SceneDungeonMonster();
				this.monsters[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005FF1 RID: 24561 RVA: 0x0011F488 File Offset: 0x0011D888
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.wave);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.monsters.Length);
			for (int i = 0; i < this.monsters.Length; i++)
			{
				this.monsters[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005FF2 RID: 24562 RVA: 0x0011F4DC File Offset: 0x0011D8DC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.wave);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.monsters = new SceneDungeonMonster[(int)num];
			for (int i = 0; i < this.monsters.Length; i++)
			{
				this.monsters[i] = new SceneDungeonMonster();
				this.monsters[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005FF3 RID: 24563 RVA: 0x0011F544 File Offset: 0x0011D944
		public int getLen()
		{
			int num = 0;
			num++;
			num += 2;
			for (int i = 0; i < this.monsters.Length; i++)
			{
				num += this.monsters[i].getLen();
			}
			return num;
		}

		// Token: 0x040027BF RID: 10175
		public byte wave;

		// Token: 0x040027C0 RID: 10176
		public SceneDungeonMonster[] monsters = new SceneDungeonMonster[0];
	}
}
