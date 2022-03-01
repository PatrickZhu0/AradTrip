using System;
using GameClient;

// Token: 0x0200426F RID: 17007
public class Mechanism1037 : BeMechanism
{
	// Token: 0x06017892 RID: 96402 RVA: 0x0073DEAC File Offset: 0x0073C2AC
	public Mechanism1037(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017893 RID: 96403 RVA: 0x0073DEB8 File Offset: 0x0073C2B8
	public override void OnInit()
	{
		this.limitTime = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.limitNum = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017894 RID: 96404 RVA: 0x0073DF15 File Offset: 0x0073C315
	public override void OnStart()
	{
		this.InitFrame();
		this.handleA = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.onMonsterDead, new BeEventHandle.Del(this.MonsterDead));
	}

	// Token: 0x06017895 RID: 96405 RVA: 0x0073DF40 File Offset: 0x0073C340
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (this.curTime >= this.limitTime)
		{
			this.SendFightEnd(false);
		}
		else
		{
			this.RefreshProgress();
			this.curTime += deltaTime;
		}
	}

	// Token: 0x06017896 RID: 96406 RVA: 0x0073DF7A File Offset: 0x0073C37A
	public override void OnFinish()
	{
		base.OnFinish();
		this.CloseSpecialFrame();
	}

	// Token: 0x06017897 RID: 96407 RVA: 0x0073DF88 File Offset: 0x0073C388
	private void MonsterDead(object[] args)
	{
		BeActor beActor = args[0] as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (beActor.m_iCamp != base.owner.m_iCamp)
		{
			return;
		}
		this.curNum++;
		this.RefreshKillNum();
		if (this.curNum >= this.limitNum)
		{
			this.SendFightEnd(true);
		}
	}

	// Token: 0x06017898 RID: 96408 RVA: 0x0073DFE8 File Offset: 0x0073C3E8
	private void SendFightEnd(bool isSuccess)
	{
		if (this.isEnd)
		{
			return;
		}
		this.isEnd = true;
		if (base.owner.CurrentBeBattle == null)
		{
			return;
		}
		PVEBattle pvebattle = base.owner.CurrentBeBattle as PVEBattle;
		if (pvebattle == null)
		{
			return;
		}
		pvebattle.SendLimitDungeonFightEnd(isSuccess);
	}

	// Token: 0x06017899 RID: 96409 RVA: 0x0073E038 File Offset: 0x0073C438
	private void InitFrame()
	{
		ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
		if (clientSystemBattle != null)
		{
			clientSystemBattle.HideFightingTime();
		}
		if (this.frame == null)
		{
			this.frame = (Singleton<ClientSystemManager>.instance.OpenFrame<TeamDungeonBattleFrame>(FrameLayer.Middle, null, string.Empty) as TeamDungeonBattleFrame);
		}
		if (this.frame != null)
		{
			this.frame.SetKillNum(0, this.limitNum);
		}
	}

	// Token: 0x0601789A RID: 96410 RVA: 0x0073E0A5 File Offset: 0x0073C4A5
	private void CloseSpecialFrame()
	{
		if (this.frame != null)
		{
			this.frame.Close(false);
		}
	}

	// Token: 0x0601789B RID: 96411 RVA: 0x0073E0BE File Offset: 0x0073C4BE
	private void RefreshKillNum()
	{
		if (this.frame != null)
		{
			this.frame.SetKillNum(this.curNum, this.limitNum);
		}
	}

	// Token: 0x0601789C RID: 96412 RVA: 0x0073E0E2 File Offset: 0x0073C4E2
	private void RefreshProgress()
	{
		if (this.frame != null)
		{
			this.frame.SetKillTime(this.limitTime - this.curTime);
		}
	}

	// Token: 0x04010E99 RID: 69273
	private int limitTime;

	// Token: 0x04010E9A RID: 69274
	private int limitNum;

	// Token: 0x04010E9B RID: 69275
	private int curTime;

	// Token: 0x04010E9C RID: 69276
	private int curNum;

	// Token: 0x04010E9D RID: 69277
	private bool isEnd;

	// Token: 0x04010E9E RID: 69278
	private TeamDungeonBattleFrame frame;
}
