using System;

namespace Protocol
{
	// Token: 0x020007B4 RID: 1972
	public class SceneDungeonMonster : IProtocolStream
	{
		// Token: 0x06005FE3 RID: 24547 RVA: 0x0011ED1C File Offset: 0x0011D11C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pointId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.typeId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.dropItems.Length);
			for (int i = 0; i < this.dropItems.Length; i++)
			{
				this.dropItems[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.prefixes.Length);
			for (int j = 0; j < this.prefixes.Length; j++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.prefixes[j]);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.summonerId);
		}

		// Token: 0x06005FE4 RID: 24548 RVA: 0x0011EDD4 File Offset: 0x0011D1D4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pointId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.typeId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.dropItems = new SceneDungeonDropItem[(int)num];
			for (int i = 0; i < this.dropItems.Length; i++)
			{
				this.dropItems[i] = new SceneDungeonDropItem();
				this.dropItems[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.prefixes = new byte[(int)num2];
			for (int j = 0; j < this.prefixes.Length; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.prefixes[j]);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.summonerId);
		}

		// Token: 0x06005FE5 RID: 24549 RVA: 0x0011EEAC File Offset: 0x0011D2AC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pointId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.typeId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.dropItems.Length);
			for (int i = 0; i < this.dropItems.Length; i++)
			{
				this.dropItems[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.prefixes.Length);
			for (int j = 0; j < this.prefixes.Length; j++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.prefixes[j]);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.summonerId);
		}

		// Token: 0x06005FE6 RID: 24550 RVA: 0x0011EF64 File Offset: 0x0011D364
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pointId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.typeId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.dropItems = new SceneDungeonDropItem[(int)num];
			for (int i = 0; i < this.dropItems.Length; i++)
			{
				this.dropItems[i] = new SceneDungeonDropItem();
				this.dropItems[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.prefixes = new byte[(int)num2];
			for (int j = 0; j < this.prefixes.Length; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.prefixes[j]);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.summonerId);
		}

		// Token: 0x06005FE7 RID: 24551 RVA: 0x0011F03C File Offset: 0x0011D43C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.dropItems.Length; i++)
			{
				num += this.dropItems[i].getLen();
			}
			num += 2 + this.prefixes.Length;
			return num + 4;
		}

		// Token: 0x040027B6 RID: 10166
		public uint id;

		// Token: 0x040027B7 RID: 10167
		public uint pointId;

		// Token: 0x040027B8 RID: 10168
		public uint typeId;

		// Token: 0x040027B9 RID: 10169
		public SceneDungeonDropItem[] dropItems = new SceneDungeonDropItem[0];

		// Token: 0x040027BA RID: 10170
		public byte[] prefixes = new byte[0];

		// Token: 0x040027BB RID: 10171
		public uint summonerId;
	}
}
