using System;

namespace Protocol
{
	// Token: 0x02000AD9 RID: 2777
	[Protocol]
	public class SceneRoomMatchPkRaceEnd : IProtocolStream, IGetMsgID
	{
		// Token: 0x060077EC RID: 30700 RVA: 0x0015AF94 File Offset: 0x00159394
		public uint GetMsgID()
		{
			return 507802U;
		}

		// Token: 0x060077ED RID: 30701 RVA: 0x0015AF9B File Offset: 0x0015939B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060077EE RID: 30702 RVA: 0x0015AFA3 File Offset: 0x001593A3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060077EF RID: 30703 RVA: 0x0015AFAC File Offset: 0x001593AC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.pkType);
			BaseDLL.encode_uint64(buffer, ref pos_, this.raceId);
			BaseDLL.encode_int8(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.oldPkValue);
			BaseDLL.encode_uint32(buffer, ref pos_, this.newPkValue);
			BaseDLL.encode_uint32(buffer, ref pos_, this.oldMatchScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.newMatchScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.oldPkCoin);
			BaseDLL.encode_uint32(buffer, ref pos_, this.addPkCoinFromRace);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalPkCoinFromRace);
			BaseDLL.encode_int8(buffer, ref pos_, this.isInPvPActivity);
			BaseDLL.encode_uint32(buffer, ref pos_, this.addPkCoinFromActivity);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalPkCoinFromActivity);
			BaseDLL.encode_uint32(buffer, ref pos_, this.oldSeasonLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.newSeasonLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.oldSeasonStar);
			BaseDLL.encode_uint32(buffer, ref pos_, this.newSeasonStar);
			BaseDLL.encode_uint32(buffer, ref pos_, this.oldSeasonExp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.newSeasonExp);
			BaseDLL.encode_int32(buffer, ref pos_, this.changeSeasonExp);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.slotInfos.Length);
			for (int i = 0; i < this.slotInfos.Length; i++)
			{
				this.slotInfos[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.getHonor);
		}

		// Token: 0x060077F0 RID: 30704 RVA: 0x0015B118 File Offset: 0x00159518
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pkType);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.raceId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oldPkValue);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.newPkValue);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oldMatchScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.newMatchScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oldPkCoin);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.addPkCoinFromRace);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalPkCoinFromRace);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isInPvPActivity);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.addPkCoinFromActivity);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalPkCoinFromActivity);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oldSeasonLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.newSeasonLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oldSeasonStar);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.newSeasonStar);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oldSeasonExp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.newSeasonExp);
			BaseDLL.decode_int32(buffer, ref pos_, ref this.changeSeasonExp);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.slotInfos = new RoomSlotBattleEndInfo[(int)num];
			for (int i = 0; i < this.slotInfos.Length; i++)
			{
				this.slotInfos[i] = new RoomSlotBattleEndInfo();
				this.slotInfos[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.getHonor);
		}

		// Token: 0x060077F1 RID: 30705 RVA: 0x0015B298 File Offset: 0x00159698
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.pkType);
			BaseDLL.encode_uint64(buffer, ref pos_, this.raceId);
			BaseDLL.encode_int8(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.oldPkValue);
			BaseDLL.encode_uint32(buffer, ref pos_, this.newPkValue);
			BaseDLL.encode_uint32(buffer, ref pos_, this.oldMatchScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.newMatchScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.oldPkCoin);
			BaseDLL.encode_uint32(buffer, ref pos_, this.addPkCoinFromRace);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalPkCoinFromRace);
			BaseDLL.encode_int8(buffer, ref pos_, this.isInPvPActivity);
			BaseDLL.encode_uint32(buffer, ref pos_, this.addPkCoinFromActivity);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalPkCoinFromActivity);
			BaseDLL.encode_uint32(buffer, ref pos_, this.oldSeasonLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.newSeasonLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.oldSeasonStar);
			BaseDLL.encode_uint32(buffer, ref pos_, this.newSeasonStar);
			BaseDLL.encode_uint32(buffer, ref pos_, this.oldSeasonExp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.newSeasonExp);
			BaseDLL.encode_int32(buffer, ref pos_, this.changeSeasonExp);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.slotInfos.Length);
			for (int i = 0; i < this.slotInfos.Length; i++)
			{
				this.slotInfos[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.getHonor);
		}

		// Token: 0x060077F2 RID: 30706 RVA: 0x0015B404 File Offset: 0x00159804
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pkType);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.raceId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oldPkValue);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.newPkValue);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oldMatchScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.newMatchScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oldPkCoin);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.addPkCoinFromRace);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalPkCoinFromRace);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isInPvPActivity);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.addPkCoinFromActivity);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalPkCoinFromActivity);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oldSeasonLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.newSeasonLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oldSeasonStar);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.newSeasonStar);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oldSeasonExp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.newSeasonExp);
			BaseDLL.decode_int32(buffer, ref pos_, ref this.changeSeasonExp);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.slotInfos = new RoomSlotBattleEndInfo[(int)num];
			for (int i = 0; i < this.slotInfos.Length; i++)
			{
				this.slotInfos[i] = new RoomSlotBattleEndInfo();
				this.slotInfos[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.getHonor);
		}

		// Token: 0x060077F3 RID: 30707 RVA: 0x0015B584 File Offset: 0x00159984
		public int getLen()
		{
			int num = 0;
			num++;
			num += 8;
			num++;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num++;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.slotInfos.Length; i++)
			{
				num += this.slotInfos[i].getLen();
			}
			return num + 4;
		}

		// Token: 0x04003885 RID: 14469
		public const uint MsgID = 507802U;

		// Token: 0x04003886 RID: 14470
		public uint Sequence;

		// Token: 0x04003887 RID: 14471
		public byte pkType;

		// Token: 0x04003888 RID: 14472
		public ulong raceId;

		// Token: 0x04003889 RID: 14473
		public byte result;

		// Token: 0x0400388A RID: 14474
		public uint oldPkValue;

		// Token: 0x0400388B RID: 14475
		public uint newPkValue;

		// Token: 0x0400388C RID: 14476
		public uint oldMatchScore;

		// Token: 0x0400388D RID: 14477
		public uint newMatchScore;

		// Token: 0x0400388E RID: 14478
		public uint oldPkCoin;

		// Token: 0x0400388F RID: 14479
		public uint addPkCoinFromRace;

		// Token: 0x04003890 RID: 14480
		public uint totalPkCoinFromRace;

		// Token: 0x04003891 RID: 14481
		public byte isInPvPActivity;

		// Token: 0x04003892 RID: 14482
		public uint addPkCoinFromActivity;

		// Token: 0x04003893 RID: 14483
		public uint totalPkCoinFromActivity;

		// Token: 0x04003894 RID: 14484
		public uint oldSeasonLevel;

		// Token: 0x04003895 RID: 14485
		public uint newSeasonLevel;

		// Token: 0x04003896 RID: 14486
		public uint oldSeasonStar;

		// Token: 0x04003897 RID: 14487
		public uint newSeasonStar;

		// Token: 0x04003898 RID: 14488
		public uint oldSeasonExp;

		// Token: 0x04003899 RID: 14489
		public uint newSeasonExp;

		// Token: 0x0400389A RID: 14490
		public int changeSeasonExp;

		// Token: 0x0400389B RID: 14491
		public RoomSlotBattleEndInfo[] slotInfos = new RoomSlotBattleEndInfo[0];

		// Token: 0x0400389C RID: 14492
		public uint getHonor;
	}
}
