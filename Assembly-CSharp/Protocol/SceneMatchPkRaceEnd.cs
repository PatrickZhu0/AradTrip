using System;

namespace Protocol
{
	// Token: 0x020009FF RID: 2559
	[Protocol]
	public class SceneMatchPkRaceEnd : IProtocolStream, IGetMsgID
	{
		// Token: 0x060071BF RID: 29119 RVA: 0x0014A400 File Offset: 0x00148800
		public uint GetMsgID()
		{
			return 506705U;
		}

		// Token: 0x060071C0 RID: 29120 RVA: 0x0014A407 File Offset: 0x00148807
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060071C1 RID: 29121 RVA: 0x0014A40F File Offset: 0x0014880F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060071C2 RID: 29122 RVA: 0x0014A418 File Offset: 0x00148818
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.pkType);
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
			BaseDLL.encode_uint32(buffer, ref pos_, this.getHonor);
		}

		// Token: 0x060071C3 RID: 29123 RVA: 0x0014A540 File Offset: 0x00148940
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pkType);
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
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.getHonor);
		}

		// Token: 0x060071C4 RID: 29124 RVA: 0x0014A668 File Offset: 0x00148A68
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.pkType);
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
			BaseDLL.encode_uint32(buffer, ref pos_, this.getHonor);
		}

		// Token: 0x060071C5 RID: 29125 RVA: 0x0014A790 File Offset: 0x00148B90
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pkType);
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
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.getHonor);
		}

		// Token: 0x060071C6 RID: 29126 RVA: 0x0014A8B8 File Offset: 0x00148CB8
		public int getLen()
		{
			int num = 0;
			num++;
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
			return num + 4;
		}

		// Token: 0x0400343E RID: 13374
		public const uint MsgID = 506705U;

		// Token: 0x0400343F RID: 13375
		public uint Sequence;

		// Token: 0x04003440 RID: 13376
		public byte pkType;

		// Token: 0x04003441 RID: 13377
		public byte result;

		// Token: 0x04003442 RID: 13378
		public uint oldPkValue;

		// Token: 0x04003443 RID: 13379
		public uint newPkValue;

		// Token: 0x04003444 RID: 13380
		public uint oldMatchScore;

		// Token: 0x04003445 RID: 13381
		public uint newMatchScore;

		// Token: 0x04003446 RID: 13382
		public uint oldPkCoin;

		// Token: 0x04003447 RID: 13383
		public uint addPkCoinFromRace;

		// Token: 0x04003448 RID: 13384
		public uint totalPkCoinFromRace;

		// Token: 0x04003449 RID: 13385
		public byte isInPvPActivity;

		// Token: 0x0400344A RID: 13386
		public uint addPkCoinFromActivity;

		// Token: 0x0400344B RID: 13387
		public uint totalPkCoinFromActivity;

		// Token: 0x0400344C RID: 13388
		public uint oldSeasonLevel;

		// Token: 0x0400344D RID: 13389
		public uint newSeasonLevel;

		// Token: 0x0400344E RID: 13390
		public uint oldSeasonStar;

		// Token: 0x0400344F RID: 13391
		public uint newSeasonStar;

		// Token: 0x04003450 RID: 13392
		public uint oldSeasonExp;

		// Token: 0x04003451 RID: 13393
		public uint newSeasonExp;

		// Token: 0x04003452 RID: 13394
		public int changeSeasonExp;

		// Token: 0x04003453 RID: 13395
		public uint getHonor;
	}
}
