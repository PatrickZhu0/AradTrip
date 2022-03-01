using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

// Token: 0x020042F8 RID: 17144
public class Mechanism1193 : BeMechanism
{
	// Token: 0x06017B8C RID: 97164 RVA: 0x0074FE30 File Offset: 0x0074E230
	public Mechanism1193(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B8D RID: 97165 RVA: 0x0074FE58 File Offset: 0x0074E258
	public override void OnInit()
	{
		this.mBuffInfoID.Clear();
		this.mTotalSkillSlotCount = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this.mBuffInfoID.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
		if (base.owner != null && base.owner.CurrentBeBattle != null)
		{
			this.mBuffMaxCount = (BattleMain.IsModePvP(base.owner.CurrentBeBattle.GetBattleType()) ? TableManager.GetValueFromUnionCell(this.data.ValueC[1], this.level, true) : TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true));
		}
	}

	// Token: 0x06017B8E RID: 97166 RVA: 0x0074FF6A File Offset: 0x0074E36A
	public override void OnUpdate(int deltaTime)
	{
		if (this.mDelayAddBuff)
		{
			this.mDelayAddBuff = false;
			this.TryAddBuff();
		}
	}

	// Token: 0x06017B8F RID: 97167 RVA: 0x0074FF84 File Offset: 0x0074E384
	private void TryAddBuff()
	{
		if (base.owner == null || base.owner.buffController == null)
		{
			return;
		}
		this.mAddBuffList.Clear();
		int num = this.GetEmptySlotCount();
		num = IntMath.Min(this.mBuffMaxCount, num);
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < this.mBuffInfoID.Count; j++)
			{
				this.mAddBuffList.Add(base.owner.buffController.TryAddBuff(this.mBuffInfoID[j], null, false, null, 0));
			}
		}
	}

	// Token: 0x06017B90 RID: 97168 RVA: 0x00750028 File Offset: 0x0074E428
	private int GetEmptySlotCount()
	{
		int num = 0;
		if (base.owner == null)
		{
			return num;
		}
		RaceSkillInfo[] playerInfoSkills = this.GetPlayerInfoSkills();
		if (playerInfoSkills == null)
		{
			return num;
		}
		for (int i = 0; i < playerInfoSkills.Length; i++)
		{
			if (playerInfoSkills[i] != null)
			{
				BeSkill skill = base.owner.GetSkill((int)playerInfoSkills[i].id);
				if (skill != null && skill.skillData != null && skill.skillData.SkillCategory == 3 && skill.skillData.IsBuff == 0 && skill.skillData.IsQTE == 0 && skill.skillData.IsRunAttack == 0 && skill.skillData.SkillType == SkillTable.eSkillType.ACTIVE)
				{
					num++;
				}
			}
		}
		return this.mTotalSkillSlotCount - num;
	}

	// Token: 0x06017B91 RID: 97169 RVA: 0x007500F8 File Offset: 0x0074E4F8
	private RaceSkillInfo[] GetPlayerInfoSkills()
	{
		if (base.owner == null || base.owner.CurrentBeBattle == null || base.owner.CurrentBeBattle.dungeonPlayerManager == null)
		{
			return null;
		}
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		BattlePlayer battlePlayer = null;
		for (int i = 0; i < allPlayers.Count; i++)
		{
			if (allPlayers[i].playerActor != null && allPlayers[i].playerActor.GetPID() == base.owner.GetPID())
			{
				battlePlayer = allPlayers[i];
			}
		}
		if (battlePlayer == null || battlePlayer.playerInfo == null || battlePlayer.playerInfo.skills == null)
		{
			return null;
		}
		return battlePlayer.playerInfo.skills;
	}

	// Token: 0x06017B92 RID: 97170 RVA: 0x007501D0 File Offset: 0x0074E5D0
	public override void OnFinish()
	{
		this.RemoveAllAddBuff();
	}

	// Token: 0x06017B93 RID: 97171 RVA: 0x007501D8 File Offset: 0x0074E5D8
	private void RemoveAllAddBuff()
	{
		if (base.owner == null || base.owner.buffController == null)
		{
			return;
		}
		for (int i = 0; i < this.mAddBuffList.Count; i++)
		{
			base.owner.buffController.RemoveBuff(this.mAddBuffList[i]);
		}
		this.mAddBuffList.Clear();
	}

	// Token: 0x040110B3 RID: 69811
	protected int mBuffMaxCount;

	// Token: 0x040110B4 RID: 69812
	protected List<int> mBuffInfoID = new List<int>();

	// Token: 0x040110B5 RID: 69813
	protected int mTotalSkillSlotCount;

	// Token: 0x040110B6 RID: 69814
	protected List<BeBuff> mAddBuffList = new List<BeBuff>();

	// Token: 0x040110B7 RID: 69815
	protected bool mDelayAddBuff = true;
}
