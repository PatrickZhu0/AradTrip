using System;

namespace Protocol
{
	// Token: 0x020007BF RID: 1983
	[Protocol]
	public class SceneDungeonAddMonsterDropItemNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006028 RID: 24616 RVA: 0x00120E30 File Offset: 0x0011F230
		public uint GetMsgID()
		{
			return 506815U;
		}

		// Token: 0x06006029 RID: 24617 RVA: 0x00120E37 File Offset: 0x0011F237
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600602A RID: 24618 RVA: 0x00120E3F File Offset: 0x0011F23F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600602B RID: 24619 RVA: 0x00120E48 File Offset: 0x0011F248
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.monsterId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.dropItems.Length);
			for (int i = 0; i < this.dropItems.Length; i++)
			{
				this.dropItems[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600602C RID: 24620 RVA: 0x00120E9C File Offset: 0x0011F29C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.monsterId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.dropItems = new SceneDungeonDropItem[(int)num];
			for (int i = 0; i < this.dropItems.Length; i++)
			{
				this.dropItems[i] = new SceneDungeonDropItem();
				this.dropItems[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600602D RID: 24621 RVA: 0x00120F04 File Offset: 0x0011F304
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.monsterId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.dropItems.Length);
			for (int i = 0; i < this.dropItems.Length; i++)
			{
				this.dropItems[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600602E RID: 24622 RVA: 0x00120F58 File Offset: 0x0011F358
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.monsterId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.dropItems = new SceneDungeonDropItem[(int)num];
			for (int i = 0; i < this.dropItems.Length; i++)
			{
				this.dropItems[i] = new SceneDungeonDropItem();
				this.dropItems[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600602F RID: 24623 RVA: 0x00120FC0 File Offset: 0x0011F3C0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.dropItems.Length; i++)
			{
				num += this.dropItems[i].getLen();
			}
			return num;
		}

		// Token: 0x040027F5 RID: 10229
		public const uint MsgID = 506815U;

		// Token: 0x040027F6 RID: 10230
		public uint Sequence;

		// Token: 0x040027F7 RID: 10231
		public uint monsterId;

		// Token: 0x040027F8 RID: 10232
		public SceneDungeonDropItem[] dropItems = new SceneDungeonDropItem[0];
	}
}
