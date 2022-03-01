using System;

namespace Protocol
{
	// Token: 0x020007B5 RID: 1973
	public class SceneDungeonArea : IProtocolStream
	{
		// Token: 0x06005FE9 RID: 24553 RVA: 0x0011F0B8 File Offset: 0x0011D4B8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.monsters.Length);
			for (int i = 0; i < this.monsters.Length; i++)
			{
				this.monsters[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.destructs.Length);
			for (int j = 0; j < this.destructs.Length; j++)
			{
				this.destructs[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005FEA RID: 24554 RVA: 0x0011F148 File Offset: 0x0011D548
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.monsters = new SceneDungeonMonster[(int)num];
			for (int i = 0; i < this.monsters.Length; i++)
			{
				this.monsters[i] = new SceneDungeonMonster();
				this.monsters[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.destructs = new SceneDungeonMonster[(int)num2];
			for (int j = 0; j < this.destructs.Length; j++)
			{
				this.destructs[j] = new SceneDungeonMonster();
				this.destructs[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005FEB RID: 24555 RVA: 0x0011F200 File Offset: 0x0011D600
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.monsters.Length);
			for (int i = 0; i < this.monsters.Length; i++)
			{
				this.monsters[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.destructs.Length);
			for (int j = 0; j < this.destructs.Length; j++)
			{
				this.destructs[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005FEC RID: 24556 RVA: 0x0011F290 File Offset: 0x0011D690
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.monsters = new SceneDungeonMonster[(int)num];
			for (int i = 0; i < this.monsters.Length; i++)
			{
				this.monsters[i] = new SceneDungeonMonster();
				this.monsters[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.destructs = new SceneDungeonMonster[(int)num2];
			for (int j = 0; j < this.destructs.Length; j++)
			{
				this.destructs[j] = new SceneDungeonMonster();
				this.destructs[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005FED RID: 24557 RVA: 0x0011F348 File Offset: 0x0011D748
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.monsters.Length; i++)
			{
				num += this.monsters[i].getLen();
			}
			num += 2;
			for (int j = 0; j < this.destructs.Length; j++)
			{
				num += this.destructs[j].getLen();
			}
			return num;
		}

		// Token: 0x040027BC RID: 10172
		public uint id;

		// Token: 0x040027BD RID: 10173
		public SceneDungeonMonster[] monsters = new SceneDungeonMonster[0];

		// Token: 0x040027BE RID: 10174
		public SceneDungeonMonster[] destructs = new SceneDungeonMonster[0];
	}
}
