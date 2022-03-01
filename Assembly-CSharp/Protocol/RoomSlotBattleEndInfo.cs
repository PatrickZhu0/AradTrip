using System;

namespace Protocol
{
	// Token: 0x02000ACF RID: 2767
	public class RoomSlotBattleEndInfo : IProtocolStream
	{
		// Token: 0x06007795 RID: 30613 RVA: 0x00159E70 File Offset: 0x00158270
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.resultFlag);
			BaseDLL.encode_uint32(buffer, ref pos_, this.roomId);
			BaseDLL.encode_int8(buffer, ref pos_, this.roomType);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_int8(buffer, ref pos_, this.seat);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonStar);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonExp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.scoreWarBaseScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.scoreWarContriScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.getHonor);
		}

		// Token: 0x06007796 RID: 30614 RVA: 0x00159F18 File Offset: 0x00158318
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.resultFlag);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roomId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.roomType);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seat);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonStar);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonExp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.scoreWarBaseScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.scoreWarContriScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.getHonor);
		}

		// Token: 0x06007797 RID: 30615 RVA: 0x00159FC0 File Offset: 0x001583C0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.resultFlag);
			BaseDLL.encode_uint32(buffer, ref pos_, this.roomId);
			BaseDLL.encode_int8(buffer, ref pos_, this.roomType);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_int8(buffer, ref pos_, this.seat);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonStar);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonExp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.scoreWarBaseScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.scoreWarContriScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.getHonor);
		}

		// Token: 0x06007798 RID: 30616 RVA: 0x0015A068 File Offset: 0x00158468
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.resultFlag);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roomId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.roomType);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seat);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonStar);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonExp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.scoreWarBaseScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.scoreWarContriScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.getHonor);
		}

		// Token: 0x06007799 RID: 30617 RVA: 0x0015A110 File Offset: 0x00158510
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			num++;
			num += 8;
			num++;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003848 RID: 14408
		public byte resultFlag;

		// Token: 0x04003849 RID: 14409
		public uint roomId;

		// Token: 0x0400384A RID: 14410
		public byte roomType;

		// Token: 0x0400384B RID: 14411
		public ulong roleId;

		// Token: 0x0400384C RID: 14412
		public byte seat;

		// Token: 0x0400384D RID: 14413
		public uint seasonLevel;

		// Token: 0x0400384E RID: 14414
		public uint seasonStar;

		// Token: 0x0400384F RID: 14415
		public uint seasonExp;

		// Token: 0x04003850 RID: 14416
		public uint scoreWarBaseScore;

		// Token: 0x04003851 RID: 14417
		public uint scoreWarContriScore;

		// Token: 0x04003852 RID: 14418
		public uint getHonor;
	}
}
