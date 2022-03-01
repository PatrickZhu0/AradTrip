using System;
using System.Collections.Generic;

// Token: 0x020042A2 RID: 17058
public class Mechanism1098 : BeMechanism
{
	// Token: 0x0601799D RID: 96669 RVA: 0x007450B1 File Offset: 0x007434B1
	public Mechanism1098(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601799E RID: 96670 RVA: 0x007450D0 File Offset: 0x007434D0
	public override void OnInit()
	{
		this.mBossMsg = this.data.StringValueA[0];
		this.mEffectId.Clear();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.mEffectId.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		this.mTotalNum = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.mSkillId = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x0601799F RID: 96671 RVA: 0x007451A0 File Offset: 0x007435A0
	public override void OnStart()
	{
		this.mBeHitNum = 0;
		if (base.owner.CurrentBeBattle != null && base.owner.CurrentBeBattle.dungeonPlayerManager != null)
		{
			List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
			if (allPlayers != null)
			{
				if (allPlayers.Count > 0 && allPlayers[0].playerActor != null)
				{
					this.handleA = allPlayers[0].playerActor.RegisterEvent(BeEventType.onHit, new BeEventHandle.Del(this.OnBeHitEvent));
				}
				if (allPlayers.Count > 1 && allPlayers[1].playerActor != null)
				{
					this.handleB = allPlayers[1].playerActor.RegisterEvent(BeEventType.onHit, new BeEventHandle.Del(this.OnBeHitEvent));
				}
				if (allPlayers.Count > 2 && allPlayers[2].playerActor != null)
				{
					this.handleC = allPlayers[2].playerActor.RegisterEvent(BeEventType.onHit, new BeEventHandle.Del(this.OnBeHitEvent));
				}
			}
			this.ShowHeadDialog(this.mTotalNum, false);
		}
	}

	// Token: 0x060179A0 RID: 96672 RVA: 0x007452C8 File Offset: 0x007436C8
	public override void OnFinish()
	{
		this.ShowHeadDialog(0, true);
	}

	// Token: 0x060179A1 RID: 96673 RVA: 0x007452D4 File Offset: 0x007436D4
	private void OnBeHitEvent(object[] args)
	{
		if (args.Length >= 7)
		{
			int item = (int)args[4];
			if (this.mEffectId.Contains(item))
			{
				this.mBeHitNum++;
				this.ShowHeadDialog(this.mTotalNum - this.mBeHitNum, false);
				if (this.mBeHitNum >= this.mTotalNum)
				{
					this.ShowHeadDialog(0, true);
					BeUtility.CancelCurrentSkill(base.owner);
					BeSkill skill = base.owner.GetSkill(this.mSkillId);
					if (skill != null)
					{
						skill.ResetCoolDown();
						base.owner.UseSkill(this.mSkillId, true);
					}
					base.owner.RemoveMechanism(this);
				}
			}
		}
	}

	// Token: 0x060179A2 RID: 96674 RVA: 0x00745388 File Offset: 0x00743788
	private void ShowHeadDialog(int num, bool hide = false)
	{
		float fLifeTime = 3.5f;
		if (!hide)
		{
			fLifeTime = 999f;
		}
		if (string.IsNullOrEmpty(this.mBossMsg))
		{
			this.mBossMsg = "剩余{0}";
		}
		if (base.owner != null && base.owner.m_pkGeActor != null)
		{
			base.owner.m_pkGeActor.ShowHeadDialog(string.Format(this.mBossMsg, num), hide, false, false, false, fLifeTime, false);
		}
	}

	// Token: 0x04010F5F RID: 69471
	private List<int> mEffectId = new List<int>();

	// Token: 0x04010F60 RID: 69472
	private int mTotalNum = 10;

	// Token: 0x04010F61 RID: 69473
	private int mSkillId;

	// Token: 0x04010F62 RID: 69474
	private string mBossMsg;

	// Token: 0x04010F63 RID: 69475
	protected int mBeHitNum;
}
