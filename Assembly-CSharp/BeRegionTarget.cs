using System;
using ProtoTable;

// Token: 0x020041A5 RID: 16805
public class BeRegionTarget
{
	// Token: 0x17001F76 RID: 8054
	// (get) Token: 0x06017144 RID: 94532 RVA: 0x007147BC File Offset: 0x00712BBC
	// (set) Token: 0x06017145 RID: 94533 RVA: 0x007147C4 File Offset: 0x00712BC4
	public bool removed
	{
		get
		{
			return this.mRemoved;
		}
		set
		{
			this.mRemoved = value;
		}
	}

	// Token: 0x17001F77 RID: 8055
	// (get) Token: 0x06017146 RID: 94534 RVA: 0x007147CD File Offset: 0x00712BCD
	// (set) Token: 0x06017147 RID: 94535 RVA: 0x007147D5 File Offset: 0x00712BD5
	public SceneRegionTable.eType type
	{
		get
		{
			return this.mType;
		}
		set
		{
			this.mType = value;
		}
	}

	// Token: 0x17001F78 RID: 8056
	// (get) Token: 0x06017148 RID: 94536 RVA: 0x007147DE File Offset: 0x00712BDE
	// (set) Token: 0x06017149 RID: 94537 RVA: 0x007147E6 File Offset: 0x00712BE6
	public BattlePlayer battlePlayer
	{
		get
		{
			return this.mBattlePlayer;
		}
		set
		{
			this.mBattlePlayer = value;
		}
	}

	// Token: 0x17001F79 RID: 8057
	// (get) Token: 0x0601714A RID: 94538 RVA: 0x007147EF File Offset: 0x00712BEF
	// (set) Token: 0x0601714B RID: 94539 RVA: 0x007147F7 File Offset: 0x00712BF7
	public BeActor target
	{
		get
		{
			return this.mTarget;
		}
		set
		{
			this.mTarget = value;
		}
	}

	// Token: 0x17001F7A RID: 8058
	// (get) Token: 0x0601714C RID: 94540 RVA: 0x00714800 File Offset: 0x00712C00
	public BeRegionState lastState
	{
		get
		{
			return this.mLastState;
		}
	}

	// Token: 0x17001F7B RID: 8059
	// (get) Token: 0x0601714D RID: 94541 RVA: 0x00714808 File Offset: 0x00712C08
	public bool isStateChanged
	{
		get
		{
			if (this.mLastState == BeRegionState.Over)
			{
				this.mLastState = this.mState;
				return false;
			}
			return this.mLastState != this.mState;
		}
	}

	// Token: 0x17001F7C RID: 8060
	// (get) Token: 0x0601714E RID: 94542 RVA: 0x00714835 File Offset: 0x00712C35
	// (set) Token: 0x0601714F RID: 94543 RVA: 0x00714840 File Offset: 0x00712C40
	public BeRegionState state
	{
		get
		{
			return this.mState;
		}
		set
		{
			this.mLastState = this.mState;
			this.mState = value;
			if (this.target != null && BattleMain.instance.GetPlayerManager().GetAllPlayers().Count > 1 && this.type == SceneRegionTable.eType.DOOR)
			{
				BeRegionState beRegionState = this.mState;
				if (beRegionState != BeRegionState.In)
				{
					if (beRegionState == BeRegionState.Out || beRegionState == BeRegionState.None)
					{
						this.target.ShowTransport(false);
					}
				}
				else
				{
					this.target.ShowTransport(true);
				}
			}
		}
	}

	// Token: 0x04010A0D RID: 68109
	protected BeActor mTarget;

	// Token: 0x04010A0E RID: 68110
	protected BattlePlayer mBattlePlayer;

	// Token: 0x04010A0F RID: 68111
	protected BeRegionState mState;

	// Token: 0x04010A10 RID: 68112
	protected BeRegionState mLastState;

	// Token: 0x04010A11 RID: 68113
	protected bool mRemoved;

	// Token: 0x04010A12 RID: 68114
	protected SceneRegionTable.eType mType;
}
