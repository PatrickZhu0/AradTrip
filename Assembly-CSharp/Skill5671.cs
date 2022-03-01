using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020044F1 RID: 17649
public class Skill5671 : BeSkill
{
	// Token: 0x060188EC RID: 100588 RVA: 0x007AB7CF File Offset: 0x007A9BCF
	public Skill5671(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060188ED RID: 100589 RVA: 0x007AB7FA File Offset: 0x007A9BFA
	public override void OnInit()
	{
		this.speed = 20000;
	}

	// Token: 0x060188EE RID: 100590 RVA: 0x007AB807 File Offset: 0x007A9C07
	public override void OnStart()
	{
		base.owner.aiManager.StopCurrentCommand();
		base.owner.aiManager.Stop();
	}

	// Token: 0x060188EF RID: 100591 RVA: 0x007AB829 File Offset: 0x007A9C29
	public override void OnEnterPhase(int phase)
	{
		if (phase == 1)
		{
			this.TraceTarget();
		}
		else if (phase == 2)
		{
			base.owner.ResetMoveCmd();
			base.owner.ChangeRunMode(false);
		}
	}

	// Token: 0x060188F0 RID: 100592 RVA: 0x007AB85C File Offset: 0x007A9C5C
	private void TraceTarget()
	{
		if (base.owner == null || base.owner.IsDead())
		{
			return;
		}
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindMonsterByID(list, this.monsterId, true);
		if (list.Count > 0)
		{
			base.owner.ChangeRunMode(true);
			base.owner.ClearMoveSpeed(7);
			VInt3 vint = list[0].GetPosition() - base.owner.GetPosition();
			if (vint.magnitude > this.standDis)
			{
				VInt3 rhs = vint;
				rhs.NormalizeTo(this.standDis);
				vint -= rhs;
				this.timer = vint.magnitude * GlobalLogic.VALUE_1000 / this.speed;
				VInt3 vint2 = vint.NormalizeTo(this.speed);
				base.owner.SetMoveSpeedX(vint2.x);
				base.owner.SetMoveSpeedY(vint2.y);
				base.owner.SetFace(vint2.x < 0, false, false);
			}
			else
			{
				this.timer = 0;
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x060188F1 RID: 100593 RVA: 0x007AB98E File Offset: 0x007A9D8E
	public override void OnUpdate(int iDeltime)
	{
		if (this.curPhase == 1)
		{
			this.timer -= iDeltime;
			if (this.timer <= 0)
			{
				((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
			}
		}
	}

	// Token: 0x060188F2 RID: 100594 RVA: 0x007AB9CB File Offset: 0x007A9DCB
	public override void OnCancel()
	{
		this.ResetMove();
	}

	// Token: 0x060188F3 RID: 100595 RVA: 0x007AB9D3 File Offset: 0x007A9DD3
	public override void OnFinish()
	{
		this.ResetMove();
	}

	// Token: 0x060188F4 RID: 100596 RVA: 0x007AB9DB File Offset: 0x007A9DDB
	private void ResetMove()
	{
		base.owner.ResetMoveCmd();
		base.owner.ChangeRunMode(false);
		base.owner.aiManager.Start();
	}

	// Token: 0x04011B82 RID: 72578
	private int monsterId = 30200011;

	// Token: 0x04011B83 RID: 72579
	private int speed = 10000;

	// Token: 0x04011B84 RID: 72580
	private int standDis = 15000;

	// Token: 0x04011B85 RID: 72581
	private int timer;
}
