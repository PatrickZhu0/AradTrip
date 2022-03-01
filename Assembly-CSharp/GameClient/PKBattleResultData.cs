using System;
using Protocol;

namespace GameClient
{
	// Token: 0x0200198A RID: 6538
	public class PKBattleResultData
	{
		// Token: 0x0600FE2E RID: 65070 RVA: 0x0046463C File Offset: 0x00462A3C
		public PKBattleResultData(SceneMatchPkRaceEnd res)
		{
			this.pkType = res.pkType;
			this.result = res.result;
			this.oldPkValue = res.oldPkValue;
			this.newPkValue = res.newPkValue;
			this.oldMatchScore = res.oldMatchScore;
			this.newMatchScore = res.newMatchScore;
			this.oldPkCoin = res.oldPkCoin;
			this.addPkCoinFromRace = res.addPkCoinFromRace;
			this.totalPkCoinFromRace = res.totalPkCoinFromRace;
			this.isInPvPActivity = res.isInPvPActivity;
			this.addPkCoinFromActivity = res.addPkCoinFromActivity;
			this.totalPkCoinFromActivity = res.totalPkCoinFromActivity;
			this.oldSeasonLevel = res.oldSeasonLevel;
			this.newSeasonLevel = res.newSeasonLevel;
			this.oldSeasonStar = res.oldSeasonStar;
			this.newSeasonStar = res.newSeasonStar;
			this.oldSeasonExp = res.oldSeasonExp;
			this.newSeasonExp = res.newSeasonExp;
			this.changeSeasonExp = res.changeSeasonExp;
			this.changeGlory = res.getHonor;
		}

		// Token: 0x0600FE2F RID: 65071 RVA: 0x00464740 File Offset: 0x00462B40
		public PKBattleResultData(SceneRoomMatchPkRaceEnd res)
		{
			this.pkType = res.pkType;
			this.result = res.result;
			this.oldPkValue = res.oldPkValue;
			this.newPkValue = res.newPkValue;
			this.oldMatchScore = res.oldMatchScore;
			this.newMatchScore = res.newMatchScore;
			this.oldPkCoin = res.oldPkCoin;
			this.addPkCoinFromRace = res.addPkCoinFromRace;
			this.totalPkCoinFromRace = res.totalPkCoinFromRace;
			this.isInPvPActivity = res.isInPvPActivity;
			this.addPkCoinFromActivity = res.addPkCoinFromActivity;
			this.totalPkCoinFromActivity = res.totalPkCoinFromActivity;
			this.oldSeasonLevel = res.oldSeasonLevel;
			this.newSeasonLevel = res.newSeasonLevel;
			this.oldSeasonStar = res.oldSeasonStar;
			this.newSeasonStar = res.newSeasonStar;
			this.oldSeasonExp = res.oldSeasonExp;
			this.newSeasonExp = res.newSeasonExp;
			this.changeSeasonExp = res.changeSeasonExp;
			this.changeGlory = res.getHonor;
		}

		// Token: 0x17001D14 RID: 7444
		// (get) Token: 0x0600FE30 RID: 65072 RVA: 0x00464843 File Offset: 0x00462C43
		// (set) Token: 0x0600FE31 RID: 65073 RVA: 0x0046484B File Offset: 0x00462C4B
		public byte pkType
		{
			get
			{
				return this.mPkType;
			}
			set
			{
				this.mPkType = value;
			}
		}

		// Token: 0x17001D15 RID: 7445
		// (get) Token: 0x0600FE32 RID: 65074 RVA: 0x00464854 File Offset: 0x00462C54
		// (set) Token: 0x0600FE33 RID: 65075 RVA: 0x0046485C File Offset: 0x00462C5C
		public byte result
		{
			get
			{
				return this.mResult;
			}
			set
			{
				this.mResult = value;
			}
		}

		// Token: 0x17001D16 RID: 7446
		// (get) Token: 0x0600FE34 RID: 65076 RVA: 0x00464865 File Offset: 0x00462C65
		// (set) Token: 0x0600FE35 RID: 65077 RVA: 0x0046486D File Offset: 0x00462C6D
		public uint oldPkValue
		{
			get
			{
				return this.mOldPkValue;
			}
			set
			{
				this.mOldPkValue = value;
			}
		}

		// Token: 0x17001D17 RID: 7447
		// (get) Token: 0x0600FE36 RID: 65078 RVA: 0x00464876 File Offset: 0x00462C76
		// (set) Token: 0x0600FE37 RID: 65079 RVA: 0x0046487E File Offset: 0x00462C7E
		public uint newPkValue
		{
			get
			{
				return this.mNewPkValue;
			}
			set
			{
				this.mNewPkValue = value;
			}
		}

		// Token: 0x17001D18 RID: 7448
		// (get) Token: 0x0600FE38 RID: 65080 RVA: 0x00464887 File Offset: 0x00462C87
		// (set) Token: 0x0600FE39 RID: 65081 RVA: 0x0046488F File Offset: 0x00462C8F
		public uint oldMatchScore
		{
			get
			{
				return this.mOldMatchScore;
			}
			set
			{
				this.mOldMatchScore = value;
			}
		}

		// Token: 0x17001D19 RID: 7449
		// (get) Token: 0x0600FE3A RID: 65082 RVA: 0x00464898 File Offset: 0x00462C98
		// (set) Token: 0x0600FE3B RID: 65083 RVA: 0x004648A0 File Offset: 0x00462CA0
		public uint newMatchScore
		{
			get
			{
				return this.mNewMatchScore;
			}
			set
			{
				this.mNewMatchScore = value;
			}
		}

		// Token: 0x17001D1A RID: 7450
		// (get) Token: 0x0600FE3C RID: 65084 RVA: 0x004648A9 File Offset: 0x00462CA9
		// (set) Token: 0x0600FE3D RID: 65085 RVA: 0x004648B1 File Offset: 0x00462CB1
		public uint oldPkCoin
		{
			get
			{
				return this.mOldPkCoin;
			}
			set
			{
				this.mOldPkCoin = value;
			}
		}

		// Token: 0x17001D1B RID: 7451
		// (get) Token: 0x0600FE3E RID: 65086 RVA: 0x004648BA File Offset: 0x00462CBA
		// (set) Token: 0x0600FE3F RID: 65087 RVA: 0x004648C2 File Offset: 0x00462CC2
		public uint addPkCoinFromRace
		{
			get
			{
				return this.mAddPkCoinFromRace;
			}
			set
			{
				this.mAddPkCoinFromRace = value;
			}
		}

		// Token: 0x17001D1C RID: 7452
		// (get) Token: 0x0600FE40 RID: 65088 RVA: 0x004648CB File Offset: 0x00462CCB
		// (set) Token: 0x0600FE41 RID: 65089 RVA: 0x004648D3 File Offset: 0x00462CD3
		public uint totalPkCoinFromRace
		{
			get
			{
				return this.mTotalPkCoinFromRace;
			}
			set
			{
				this.mTotalPkCoinFromRace = value;
			}
		}

		// Token: 0x17001D1D RID: 7453
		// (get) Token: 0x0600FE42 RID: 65090 RVA: 0x004648DC File Offset: 0x00462CDC
		// (set) Token: 0x0600FE43 RID: 65091 RVA: 0x004648E4 File Offset: 0x00462CE4
		public byte isInPvPActivity
		{
			get
			{
				return this.mIsInPvPActivity;
			}
			set
			{
				this.mIsInPvPActivity = value;
			}
		}

		// Token: 0x17001D1E RID: 7454
		// (get) Token: 0x0600FE44 RID: 65092 RVA: 0x004648ED File Offset: 0x00462CED
		// (set) Token: 0x0600FE45 RID: 65093 RVA: 0x004648F5 File Offset: 0x00462CF5
		public uint addPkCoinFromActivity
		{
			get
			{
				return this.mAddPkCoinFromActivity;
			}
			set
			{
				this.mAddPkCoinFromActivity = value;
			}
		}

		// Token: 0x17001D1F RID: 7455
		// (get) Token: 0x0600FE46 RID: 65094 RVA: 0x004648FE File Offset: 0x00462CFE
		// (set) Token: 0x0600FE47 RID: 65095 RVA: 0x00464906 File Offset: 0x00462D06
		public uint totalPkCoinFromActivity
		{
			get
			{
				return this.mTotalPkCoinFromActivity;
			}
			set
			{
				this.mTotalPkCoinFromActivity = value;
			}
		}

		// Token: 0x17001D20 RID: 7456
		// (get) Token: 0x0600FE48 RID: 65096 RVA: 0x0046490F File Offset: 0x00462D0F
		// (set) Token: 0x0600FE49 RID: 65097 RVA: 0x00464917 File Offset: 0x00462D17
		public uint oldSeasonLevel
		{
			get
			{
				return this.mOldSeasonLevel;
			}
			set
			{
				this.mOldSeasonLevel = value;
			}
		}

		// Token: 0x17001D21 RID: 7457
		// (get) Token: 0x0600FE4A RID: 65098 RVA: 0x00464920 File Offset: 0x00462D20
		// (set) Token: 0x0600FE4B RID: 65099 RVA: 0x00464928 File Offset: 0x00462D28
		public uint newSeasonLevel
		{
			get
			{
				return this.mNewSeasonLevel;
			}
			set
			{
				this.mNewSeasonLevel = value;
			}
		}

		// Token: 0x17001D22 RID: 7458
		// (get) Token: 0x0600FE4C RID: 65100 RVA: 0x00464931 File Offset: 0x00462D31
		// (set) Token: 0x0600FE4D RID: 65101 RVA: 0x00464939 File Offset: 0x00462D39
		public uint oldSeasonStar
		{
			get
			{
				return this.mOldSeasonStar;
			}
			set
			{
				this.mOldSeasonStar = value;
			}
		}

		// Token: 0x17001D23 RID: 7459
		// (get) Token: 0x0600FE4E RID: 65102 RVA: 0x00464942 File Offset: 0x00462D42
		// (set) Token: 0x0600FE4F RID: 65103 RVA: 0x0046494A File Offset: 0x00462D4A
		public uint newSeasonStar
		{
			get
			{
				return this.mNewSeasonStar;
			}
			set
			{
				this.mNewSeasonStar = value;
			}
		}

		// Token: 0x17001D24 RID: 7460
		// (get) Token: 0x0600FE50 RID: 65104 RVA: 0x00464953 File Offset: 0x00462D53
		// (set) Token: 0x0600FE51 RID: 65105 RVA: 0x0046495B File Offset: 0x00462D5B
		public uint oldSeasonExp
		{
			get
			{
				return this.mOldSeasonExp;
			}
			set
			{
				this.mOldSeasonExp = value;
			}
		}

		// Token: 0x17001D25 RID: 7461
		// (get) Token: 0x0600FE52 RID: 65106 RVA: 0x00464964 File Offset: 0x00462D64
		// (set) Token: 0x0600FE53 RID: 65107 RVA: 0x0046496C File Offset: 0x00462D6C
		public uint newSeasonExp
		{
			get
			{
				return this.mNewSeasonExp;
			}
			set
			{
				this.mNewSeasonExp = value;
			}
		}

		// Token: 0x17001D26 RID: 7462
		// (get) Token: 0x0600FE54 RID: 65108 RVA: 0x00464975 File Offset: 0x00462D75
		// (set) Token: 0x0600FE55 RID: 65109 RVA: 0x0046497D File Offset: 0x00462D7D
		public int changeSeasonExp
		{
			get
			{
				return this.mChangeSeasonExp;
			}
			set
			{
				this.mChangeSeasonExp = value;
			}
		}

		// Token: 0x17001D27 RID: 7463
		// (get) Token: 0x0600FE56 RID: 65110 RVA: 0x00464986 File Offset: 0x00462D86
		// (set) Token: 0x0600FE57 RID: 65111 RVA: 0x0046498E File Offset: 0x00462D8E
		public uint changeGlory
		{
			get
			{
				return this.mChangeGlory;
			}
			set
			{
				this.mChangeGlory = value;
			}
		}

		// Token: 0x0400A04A RID: 41034
		private byte mPkType;

		// Token: 0x0400A04B RID: 41035
		private byte mResult;

		// Token: 0x0400A04C RID: 41036
		private uint mOldPkValue;

		// Token: 0x0400A04D RID: 41037
		private uint mNewPkValue;

		// Token: 0x0400A04E RID: 41038
		private uint mOldMatchScore;

		// Token: 0x0400A04F RID: 41039
		private uint mNewMatchScore;

		// Token: 0x0400A050 RID: 41040
		private uint mOldPkCoin;

		// Token: 0x0400A051 RID: 41041
		private uint mAddPkCoinFromRace;

		// Token: 0x0400A052 RID: 41042
		private uint mTotalPkCoinFromRace;

		// Token: 0x0400A053 RID: 41043
		private byte mIsInPvPActivity;

		// Token: 0x0400A054 RID: 41044
		private uint mAddPkCoinFromActivity;

		// Token: 0x0400A055 RID: 41045
		private uint mTotalPkCoinFromActivity;

		// Token: 0x0400A056 RID: 41046
		private uint mOldSeasonLevel;

		// Token: 0x0400A057 RID: 41047
		private uint mNewSeasonLevel;

		// Token: 0x0400A058 RID: 41048
		private uint mOldSeasonStar;

		// Token: 0x0400A059 RID: 41049
		private uint mNewSeasonStar;

		// Token: 0x0400A05A RID: 41050
		private uint mOldSeasonExp;

		// Token: 0x0400A05B RID: 41051
		private uint mNewSeasonExp;

		// Token: 0x0400A05C RID: 41052
		private int mChangeSeasonExp;

		// Token: 0x0400A05D RID: 41053
		private uint mChangeGlory;
	}
}
