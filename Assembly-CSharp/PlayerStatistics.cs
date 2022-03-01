using System;
using System.Collections.Generic;
using GameClient;
using Protocol;

// Token: 0x02004204 RID: 16900
public class PlayerStatistics
{
	// Token: 0x0601763B RID: 95803 RVA: 0x007314B0 File Offset: 0x0072F8B0
	private void _notify()
	{
		UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonScoreChanged, null, null, null, null);
	}

	// Token: 0x0601763C RID: 95804 RVA: 0x007314C5 File Offset: 0x0072F8C5
	public void Reset()
	{
		this.mUsedItem.Clear();
		this.mUsedSkill.Clear();
		this.mKilledMonster.Clear();
		this.data = new PlayerStatistics.FightStatistics();
		this.pkResults = new List<PlayerStatistics.MatchRoundPKResoult>();
	}

	// Token: 0x0601763D RID: 95805 RVA: 0x00731500 File Offset: 0x0072F900
	public void AddPKResult(int roundIndex, byte roundTargetSeat, PKResult roundResult, ePVPBattleEndType endType, uint selfHpRate)
	{
		int lastPKRoundIndex = this.GetLastPKRoundIndex();
		if (roundIndex <= lastPKRoundIndex)
		{
			return;
		}
		PlayerStatistics.MatchRoundPKResoult matchRoundPKResoult = new PlayerStatistics.MatchRoundPKResoult();
		matchRoundPKResoult.roundIndex = roundIndex;
		matchRoundPKResoult.roundResult = roundResult;
		matchRoundPKResoult.roundTargetSeat = roundTargetSeat;
		matchRoundPKResoult.endType = endType;
		matchRoundPKResoult.SelfHPRate = selfHpRate;
		this.pkResults.Add(matchRoundPKResoult);
	}

	// Token: 0x0601763E RID: 95806 RVA: 0x00731553 File Offset: 0x0072F953
	public int GetLastPKRoundIndex()
	{
		if (this.pkResults.Count <= 0)
		{
			return -1;
		}
		return this.pkResults[this.pkResults.Count - 1].roundIndex;
	}

	// Token: 0x0601763F RID: 95807 RVA: 0x00731588 File Offset: 0x0072F988
	public uint GetLastHurtedRate()
	{
		if (this.pkResults.Count <= 0)
		{
			return 0U;
		}
		if (this.pkResults.Count == 1)
		{
			return PlayerStatistics.skFullHPRate - this.pkResults[this.pkResults.Count - 1].SelfHPRate;
		}
		uint selfHPRate = this.pkResults[this.pkResults.Count - 1].SelfHPRate;
		uint selfHPRate2 = this.pkResults[this.pkResults.Count - 2].SelfHPRate;
		if (selfHPRate > selfHPRate2)
		{
			return 0U;
		}
		return selfHPRate2 - selfHPRate;
	}

	// Token: 0x06017640 RID: 95808 RVA: 0x00731628 File Offset: 0x0072FA28
	public int GetKillMatchPlayerCount()
	{
		int num = 0;
		for (int i = 0; i < this.pkResults.Count; i++)
		{
			if (this.pkResults[i].endType == ePVPBattleEndType.onAllEnemyDied && this.pkResults[i].roundResult == PKResult.WIN)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x06017641 RID: 95809 RVA: 0x00731686 File Offset: 0x0072FA86
	public PKResult GetLastPKResult()
	{
		if (this.pkResults.Count <= 0)
		{
			return PKResult.INVALID;
		}
		return this.pkResults[this.pkResults.Count - 1].roundResult;
	}

	// Token: 0x06017642 RID: 95810 RVA: 0x007316B8 File Offset: 0x0072FAB8
	public void UseItem(int id, int num)
	{
		for (int i = 0; i < num; i++)
		{
			this.mUsedItem.Add(id);
		}
		this._notify();
	}

	// Token: 0x06017643 RID: 95811 RVA: 0x007316E9 File Offset: 0x0072FAE9
	public void UseSkill(int skill)
	{
		this.mUsedSkill.Add(skill);
		this._notify();
	}

	// Token: 0x06017644 RID: 95812 RVA: 0x007316FD File Offset: 0x0072FAFD
	public void OnHit()
	{
		this.data.beHitCount++;
		this._notify();
	}

	// Token: 0x06017645 RID: 95813 RVA: 0x00731718 File Offset: 0x0072FB18
	public void Reborn()
	{
		this.data.rebornCount++;
		this._notify();
	}

	// Token: 0x06017646 RID: 95814 RVA: 0x00731733 File Offset: 0x0072FB33
	public void Dead()
	{
		this.data.deadCount++;
		this._notify();
	}

	// Token: 0x04010CCB RID: 68811
	public static uint skFullHPRate = 10000U;

	// Token: 0x04010CCC RID: 68812
	public PlayerStatistics.MatchRacePKResult raceResult = new PlayerStatistics.MatchRacePKResult();

	// Token: 0x04010CCD RID: 68813
	public int raceResultRank = 1;

	// Token: 0x04010CCE RID: 68814
	private List<int> mUsedItem = new List<int>();

	// Token: 0x04010CCF RID: 68815
	private List<int> mUsedSkill = new List<int>();

	// Token: 0x04010CD0 RID: 68816
	private List<int> mKilledMonster = new List<int>();

	// Token: 0x04010CD1 RID: 68817
	public PlayerStatistics.FightStatistics data = new PlayerStatistics.FightStatistics();

	// Token: 0x04010CD2 RID: 68818
	private List<PlayerStatistics.MatchRoundPKResoult> pkResults = new List<PlayerStatistics.MatchRoundPKResoult>();

	// Token: 0x04010CD3 RID: 68819
	public int killPlayers;

	// Token: 0x02004205 RID: 16901
	public class FightStatistics
	{
		// Token: 0x17001FE7 RID: 8167
		// (get) Token: 0x06017649 RID: 95817 RVA: 0x00731762 File Offset: 0x0072FB62
		// (set) Token: 0x0601764A RID: 95818 RVA: 0x0073176A File Offset: 0x0072FB6A
		public int beHitCount
		{
			get
			{
				return this.mBeHitCount;
			}
			set
			{
				this.mBeHitCount = value;
			}
		}

		// Token: 0x17001FE8 RID: 8168
		// (get) Token: 0x0601764B RID: 95819 RVA: 0x00731773 File Offset: 0x0072FB73
		// (set) Token: 0x0601764C RID: 95820 RVA: 0x0073177B File Offset: 0x0072FB7B
		public int BossDamage
		{
			get
			{
				return this.mBossDamage;
			}
			set
			{
				this.mBossDamage = value;
			}
		}

		// Token: 0x17001FE9 RID: 8169
		// (get) Token: 0x0601764D RID: 95821 RVA: 0x00731784 File Offset: 0x0072FB84
		// (set) Token: 0x0601764E RID: 95822 RVA: 0x0073178C File Offset: 0x0072FB8C
		public int deadCount
		{
			get
			{
				return this.mDeadCount;
			}
			set
			{
				this.mDeadCount = value;
			}
		}

		// Token: 0x17001FEA RID: 8170
		// (get) Token: 0x0601764F RID: 95823 RVA: 0x00731795 File Offset: 0x0072FB95
		// (set) Token: 0x06017650 RID: 95824 RVA: 0x0073179D File Offset: 0x0072FB9D
		public int rebornCount
		{
			get
			{
				return this.mRebornCount;
			}
			set
			{
				this.mRebornCount = value;
			}
		}

		// Token: 0x17001FEB RID: 8171
		// (get) Token: 0x06017651 RID: 95825 RVA: 0x007317A6 File Offset: 0x0072FBA6
		// (set) Token: 0x06017652 RID: 95826 RVA: 0x007317AE File Offset: 0x0072FBAE
		public int maxCombo
		{
			get
			{
				return this.mMaxCombo;
			}
			set
			{
				this.mMaxCombo = value;
			}
		}

		// Token: 0x17001FEC RID: 8172
		// (get) Token: 0x06017653 RID: 95827 RVA: 0x007317B7 File Offset: 0x0072FBB7
		// (set) Token: 0x06017654 RID: 95828 RVA: 0x007317BF File Offset: 0x0072FBBF
		public int maxHurt
		{
			get
			{
				return this.mMaxHurt;
			}
			set
			{
				this.mMaxHurt = value;
			}
		}

		// Token: 0x04010CD4 RID: 68820
		private int mBeHitCount;

		// Token: 0x04010CD5 RID: 68821
		private int mBossDamage;

		// Token: 0x04010CD6 RID: 68822
		private int mDeadCount;

		// Token: 0x04010CD7 RID: 68823
		private int mRebornCount;

		// Token: 0x04010CD8 RID: 68824
		private int mMaxCombo;

		// Token: 0x04010CD9 RID: 68825
		private int mMaxHurt;
	}

	// Token: 0x02004206 RID: 16902
	private class MatchRoundPKResoult
	{
		// Token: 0x17001FED RID: 8173
		// (get) Token: 0x06017656 RID: 95830 RVA: 0x007317D0 File Offset: 0x0072FBD0
		// (set) Token: 0x06017657 RID: 95831 RVA: 0x007317D8 File Offset: 0x0072FBD8
		public int roundIndex
		{
			get
			{
				return this.mRoundIndex;
			}
			set
			{
				this.mRoundIndex = value;
			}
		}

		// Token: 0x17001FEE RID: 8174
		// (get) Token: 0x06017658 RID: 95832 RVA: 0x007317E1 File Offset: 0x0072FBE1
		// (set) Token: 0x06017659 RID: 95833 RVA: 0x007317E9 File Offset: 0x0072FBE9
		public byte roundTargetSeat
		{
			get
			{
				return this.mRoundTargetSeat;
			}
			set
			{
				this.mRoundTargetSeat = value;
			}
		}

		// Token: 0x17001FEF RID: 8175
		// (get) Token: 0x0601765A RID: 95834 RVA: 0x007317F2 File Offset: 0x0072FBF2
		// (set) Token: 0x0601765B RID: 95835 RVA: 0x007317FA File Offset: 0x0072FBFA
		public PKResult roundResult
		{
			get
			{
				return this.mRoundResult;
			}
			set
			{
				this.mRoundResult = value;
			}
		}

		// Token: 0x17001FF0 RID: 8176
		// (get) Token: 0x0601765C RID: 95836 RVA: 0x00731803 File Offset: 0x0072FC03
		// (set) Token: 0x0601765D RID: 95837 RVA: 0x0073180B File Offset: 0x0072FC0B
		public ePVPBattleEndType endType
		{
			get
			{
				return this.mEndType;
			}
			set
			{
				this.mEndType = value;
			}
		}

		// Token: 0x17001FF1 RID: 8177
		// (get) Token: 0x0601765E RID: 95838 RVA: 0x00731814 File Offset: 0x0072FC14
		// (set) Token: 0x0601765F RID: 95839 RVA: 0x0073181C File Offset: 0x0072FC1C
		public uint SelfHPRate
		{
			get
			{
				return this.mSelfHPRate;
			}
			set
			{
				this.mSelfHPRate = value;
			}
		}

		// Token: 0x04010CDA RID: 68826
		private int mRoundIndex;

		// Token: 0x04010CDB RID: 68827
		private byte mRoundTargetSeat;

		// Token: 0x04010CDC RID: 68828
		private PKResult mRoundResult;

		// Token: 0x04010CDD RID: 68829
		private ePVPBattleEndType mEndType;

		// Token: 0x04010CDE RID: 68830
		private uint mSelfHPRate;
	}

	// Token: 0x02004207 RID: 16903
	public class MatchRacePlayerResult
	{
		// Token: 0x17001FF2 RID: 8178
		// (get) Token: 0x06017661 RID: 95841 RVA: 0x0073183B File Offset: 0x0072FC3B
		// (set) Token: 0x06017662 RID: 95842 RVA: 0x00731843 File Offset: 0x0072FC43
		public uint pkValue
		{
			get
			{
				return this.mPkValue;
			}
			set
			{
				this.mPkValue = value;
			}
		}

		// Token: 0x17001FF3 RID: 8179
		// (get) Token: 0x06017663 RID: 95843 RVA: 0x0073184C File Offset: 0x0072FC4C
		// (set) Token: 0x06017664 RID: 95844 RVA: 0x00731854 File Offset: 0x0072FC54
		public uint matchScore
		{
			get
			{
				return this.mMatchScore;
			}
			set
			{
				this.mMatchScore = value;
			}
		}

		// Token: 0x17001FF4 RID: 8180
		// (get) Token: 0x06017665 RID: 95845 RVA: 0x0073185D File Offset: 0x0072FC5D
		// (set) Token: 0x06017666 RID: 95846 RVA: 0x00731865 File Offset: 0x0072FC65
		public uint pkCoin
		{
			get
			{
				return this.mPkCoin;
			}
			set
			{
				this.mPkCoin = value;
			}
		}

		// Token: 0x17001FF5 RID: 8181
		// (get) Token: 0x06017667 RID: 95847 RVA: 0x0073186E File Offset: 0x0072FC6E
		// (set) Token: 0x06017668 RID: 95848 RVA: 0x00731876 File Offset: 0x0072FC76
		public uint seasonLevel
		{
			get
			{
				return this.mSeasonLevel;
			}
			set
			{
				this.mSeasonLevel = value;
			}
		}

		// Token: 0x17001FF6 RID: 8182
		// (get) Token: 0x06017669 RID: 95849 RVA: 0x0073187F File Offset: 0x0072FC7F
		// (set) Token: 0x0601766A RID: 95850 RVA: 0x00731887 File Offset: 0x0072FC87
		public uint seasonStar
		{
			get
			{
				return this.mSeasonStar;
			}
			set
			{
				this.mSeasonStar = value;
			}
		}

		// Token: 0x17001FF7 RID: 8183
		// (get) Token: 0x0601766B RID: 95851 RVA: 0x00731890 File Offset: 0x0072FC90
		// (set) Token: 0x0601766C RID: 95852 RVA: 0x00731898 File Offset: 0x0072FC98
		public uint seasonExp
		{
			get
			{
				return this.mSeasonExp;
			}
			set
			{
				this.mSeasonExp = value;
			}
		}

		// Token: 0x17001FF8 RID: 8184
		// (get) Token: 0x0601766D RID: 95853 RVA: 0x007318A1 File Offset: 0x0072FCA1
		// (set) Token: 0x0601766E RID: 95854 RVA: 0x007318A9 File Offset: 0x0072FCA9
		public uint scoreWarContriScore
		{
			get
			{
				return this.mScoreWarContriScore;
			}
			set
			{
				this.mScoreWarContriScore = value;
			}
		}

		// Token: 0x17001FF9 RID: 8185
		// (get) Token: 0x0601766F RID: 95855 RVA: 0x007318B2 File Offset: 0x0072FCB2
		// (set) Token: 0x06017670 RID: 95856 RVA: 0x007318BA File Offset: 0x0072FCBA
		public uint scoreWarBaseScore
		{
			get
			{
				return this.mScoreWarBaseScore;
			}
			set
			{
				this.mScoreWarBaseScore = value;
			}
		}

		// Token: 0x17001FFA RID: 8186
		// (get) Token: 0x06017671 RID: 95857 RVA: 0x007318C3 File Offset: 0x0072FCC3
		// (set) Token: 0x06017672 RID: 95858 RVA: 0x007318CB File Offset: 0x0072FCCB
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

		// Token: 0x04010CDF RID: 68831
		private uint mPkValue;

		// Token: 0x04010CE0 RID: 68832
		private uint mMatchScore;

		// Token: 0x04010CE1 RID: 68833
		private uint mPkCoin;

		// Token: 0x04010CE2 RID: 68834
		private uint mSeasonLevel;

		// Token: 0x04010CE3 RID: 68835
		private uint mSeasonStar;

		// Token: 0x04010CE4 RID: 68836
		private uint mSeasonExp;

		// Token: 0x04010CE5 RID: 68837
		private uint mScoreWarContriScore = uint.MaxValue;

		// Token: 0x04010CE6 RID: 68838
		private uint mScoreWarBaseScore = uint.MaxValue;

		// Token: 0x04010CE7 RID: 68839
		private uint mChangeGlory;
	}

	// Token: 0x02004208 RID: 16904
	public class MatchRacePKResult
	{
		// Token: 0x17001FFB RID: 8187
		// (get) Token: 0x06017674 RID: 95860 RVA: 0x007318EE File Offset: 0x0072FCEE
		// (set) Token: 0x06017675 RID: 95861 RVA: 0x007318F6 File Offset: 0x0072FCF6
		public PKResult raceResult
		{
			get
			{
				return this.mRaceResult;
			}
			set
			{
				this.mRaceResult = value;
			}
		}

		// Token: 0x17001FFC RID: 8188
		// (get) Token: 0x06017676 RID: 95862 RVA: 0x007318FF File Offset: 0x0072FCFF
		// (set) Token: 0x06017677 RID: 95863 RVA: 0x00731907 File Offset: 0x0072FD07
		public uint roomId
		{
			get
			{
				return this.mRoomId;
			}
			set
			{
				this.mRoomId = value;
			}
		}

		// Token: 0x17001FFD RID: 8189
		// (get) Token: 0x06017678 RID: 95864 RVA: 0x00731910 File Offset: 0x0072FD10
		// (set) Token: 0x06017679 RID: 95865 RVA: 0x00731918 File Offset: 0x0072FD18
		public RoomType roomType
		{
			get
			{
				return this.mRoomType;
			}
			set
			{
				this.mRoomType = value;
			}
		}

		// Token: 0x17001FFE RID: 8190
		// (get) Token: 0x0601767A RID: 95866 RVA: 0x00731921 File Offset: 0x0072FD21
		// (set) Token: 0x0601767B RID: 95867 RVA: 0x00731929 File Offset: 0x0072FD29
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

		// Token: 0x17001FFF RID: 8191
		// (get) Token: 0x0601767C RID: 95868 RVA: 0x00731932 File Offset: 0x0072FD32
		// (set) Token: 0x0601767D RID: 95869 RVA: 0x0073193A File Offset: 0x0072FD3A
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

		// Token: 0x17002000 RID: 8192
		// (get) Token: 0x0601767E RID: 95870 RVA: 0x00731943 File Offset: 0x0072FD43
		// (set) Token: 0x0601767F RID: 95871 RVA: 0x0073194B File Offset: 0x0072FD4B
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

		// Token: 0x17002001 RID: 8193
		// (get) Token: 0x06017680 RID: 95872 RVA: 0x00731954 File Offset: 0x0072FD54
		// (set) Token: 0x06017681 RID: 95873 RVA: 0x0073195C File Offset: 0x0072FD5C
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

		// Token: 0x17002002 RID: 8194
		// (get) Token: 0x06017682 RID: 95874 RVA: 0x00731965 File Offset: 0x0072FD65
		// (set) Token: 0x06017683 RID: 95875 RVA: 0x0073196D File Offset: 0x0072FD6D
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

		// Token: 0x17002003 RID: 8195
		// (get) Token: 0x06017684 RID: 95876 RVA: 0x00731976 File Offset: 0x0072FD76
		// (set) Token: 0x06017685 RID: 95877 RVA: 0x0073197E File Offset: 0x0072FD7E
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

		// Token: 0x04010CE8 RID: 68840
		private PKResult mRaceResult = PKResult.INVALID;

		// Token: 0x04010CE9 RID: 68841
		private uint mRoomId;

		// Token: 0x04010CEA RID: 68842
		private RoomType mRoomType;

		// Token: 0x04010CEB RID: 68843
		private uint mAddPkCoinFromRace;

		// Token: 0x04010CEC RID: 68844
		private uint mTotalPkCoinFromRace;

		// Token: 0x04010CED RID: 68845
		private byte mIsInPvPActivity;

		// Token: 0x04010CEE RID: 68846
		private uint mAddPkCoinFromActivity;

		// Token: 0x04010CEF RID: 68847
		private uint mTotalPkCoinFromActivity;

		// Token: 0x04010CF0 RID: 68848
		private int mChangeSeasonExp;

		// Token: 0x04010CF1 RID: 68849
		public PlayerStatistics.MatchRacePlayerResult beforeRaceResult = new PlayerStatistics.MatchRacePlayerResult();

		// Token: 0x04010CF2 RID: 68850
		public PlayerStatistics.MatchRacePlayerResult afterRaceResult;
	}
}
