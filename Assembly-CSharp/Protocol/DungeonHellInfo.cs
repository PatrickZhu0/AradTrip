using System;

namespace Protocol
{
	// Token: 0x020007B7 RID: 1975
	public class DungeonHellInfo : IProtocolStream
	{
		// Token: 0x06005FF5 RID: 24565 RVA: 0x0011F5A8 File Offset: 0x0011D9A8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.mode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.areaId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.waveInfoes.Length);
			for (int i = 0; i < this.waveInfoes.Length; i++)
			{
				this.waveInfoes[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.dropItems.Length);
			for (int j = 0; j < this.dropItems.Length; j++)
			{
				this.dropItems[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005FF6 RID: 24566 RVA: 0x0011F644 File Offset: 0x0011DA44
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.areaId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.waveInfoes = new DungeonHellWaveInfo[(int)num];
			for (int i = 0; i < this.waveInfoes.Length; i++)
			{
				this.waveInfoes[i] = new DungeonHellWaveInfo();
				this.waveInfoes[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.dropItems = new SceneDungeonDropItem[(int)num2];
			for (int j = 0; j < this.dropItems.Length; j++)
			{
				this.dropItems[j] = new SceneDungeonDropItem();
				this.dropItems[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005FF7 RID: 24567 RVA: 0x0011F708 File Offset: 0x0011DB08
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.mode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.areaId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.waveInfoes.Length);
			for (int i = 0; i < this.waveInfoes.Length; i++)
			{
				this.waveInfoes[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.dropItems.Length);
			for (int j = 0; j < this.dropItems.Length; j++)
			{
				this.dropItems[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005FF8 RID: 24568 RVA: 0x0011F7A4 File Offset: 0x0011DBA4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.areaId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.waveInfoes = new DungeonHellWaveInfo[(int)num];
			for (int i = 0; i < this.waveInfoes.Length; i++)
			{
				this.waveInfoes[i] = new DungeonHellWaveInfo();
				this.waveInfoes[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.dropItems = new SceneDungeonDropItem[(int)num2];
			for (int j = 0; j < this.dropItems.Length; j++)
			{
				this.dropItems[j] = new SceneDungeonDropItem();
				this.dropItems[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005FF9 RID: 24569 RVA: 0x0011F868 File Offset: 0x0011DC68
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			num += 2;
			for (int i = 0; i < this.waveInfoes.Length; i++)
			{
				num += this.waveInfoes[i].getLen();
			}
			num += 2;
			for (int j = 0; j < this.dropItems.Length; j++)
			{
				num += this.dropItems[j].getLen();
			}
			return num;
		}

		// Token: 0x040027C1 RID: 10177
		public byte mode;

		// Token: 0x040027C2 RID: 10178
		public uint areaId;

		// Token: 0x040027C3 RID: 10179
		public DungeonHellWaveInfo[] waveInfoes = new DungeonHellWaveInfo[0];

		// Token: 0x040027C4 RID: 10180
		public SceneDungeonDropItem[] dropItems = new SceneDungeonDropItem[0];
	}
}
