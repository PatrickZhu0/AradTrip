using System;

namespace Protocol
{
	// Token: 0x02000A9A RID: 2714
	public class DungeonPlayerRaceEndInfo : IProtocolStream
	{
		// Token: 0x06007651 RID: 30289 RVA: 0x00156190 File Offset: 0x00154590
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_int8(buffer, ref pos_, this.pos);
			BaseDLL.encode_int8(buffer, ref pos_, this.score);
			for (int i = 0; i < this.md5.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.md5[i]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, this.beHitCount);
			BaseDLL.encode_uint64(buffer, ref pos_, this.bossDamage);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerRemainHp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerRemainMp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss1ID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss2ID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss1RemainHp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss2RemainHp);
		}

		// Token: 0x06007652 RID: 30290 RVA: 0x00156260 File Offset: 0x00154660
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pos);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.score);
			for (int i = 0; i < this.md5.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.md5[i]);
			}
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.beHitCount);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.bossDamage);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerRemainHp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerRemainMp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss1ID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss2ID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss1RemainHp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss2RemainHp);
		}

		// Token: 0x06007653 RID: 30291 RVA: 0x00156334 File Offset: 0x00154734
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_int8(buffer, ref pos_, this.pos);
			BaseDLL.encode_int8(buffer, ref pos_, this.score);
			for (int i = 0; i < this.md5.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.md5[i]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, this.beHitCount);
			BaseDLL.encode_uint64(buffer, ref pos_, this.bossDamage);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerRemainHp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerRemainMp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss1ID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss2ID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss1RemainHp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss2RemainHp);
		}

		// Token: 0x06007654 RID: 30292 RVA: 0x00156404 File Offset: 0x00154804
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pos);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.score);
			for (int i = 0; i < this.md5.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.md5[i]);
			}
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.beHitCount);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.bossDamage);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerRemainHp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerRemainMp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss1ID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss2ID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss1RemainHp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss2RemainHp);
		}

		// Token: 0x06007655 RID: 30293 RVA: 0x001564D8 File Offset: 0x001548D8
		public int getLen()
		{
			int num = 0;
			num += 8;
			num++;
			num++;
			num += this.md5.Length;
			num += 2;
			num += 8;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003743 RID: 14147
		public ulong roleId;

		// Token: 0x04003744 RID: 14148
		public byte pos;

		// Token: 0x04003745 RID: 14149
		public byte score;

		// Token: 0x04003746 RID: 14150
		public byte[] md5 = new byte[16];

		// Token: 0x04003747 RID: 14151
		public ushort beHitCount;

		// Token: 0x04003748 RID: 14152
		public ulong bossDamage;

		// Token: 0x04003749 RID: 14153
		public uint playerRemainHp;

		// Token: 0x0400374A RID: 14154
		public uint playerRemainMp;

		// Token: 0x0400374B RID: 14155
		public uint boss1ID;

		// Token: 0x0400374C RID: 14156
		public uint boss2ID;

		// Token: 0x0400374D RID: 14157
		public uint boss1RemainHp;

		// Token: 0x0400374E RID: 14158
		public uint boss2RemainHp;
	}
}
