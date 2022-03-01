using System;
using System.Collections.Generic;

// Token: 0x02004272 RID: 17010
internal class Mechanism104 : BeMechanism
{
	// Token: 0x060178A2 RID: 96418 RVA: 0x0073E2B0 File Offset: 0x0073C6B0
	public Mechanism104(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060178A3 RID: 96419 RVA: 0x0073E2C8 File Offset: 0x0073C6C8
	public override void OnInit()
	{
		this.moveSpeed = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
		this.stopDistance = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x060178A4 RID: 96420 RVA: 0x0073E339 File Offset: 0x0073C739
	public override void OnStart()
	{
		base.owner.aiManager.Stop();
		this.timer = this.intervel;
		this.FindTarget();
	}

	// Token: 0x060178A5 RID: 96421 RVA: 0x0073E360 File Offset: 0x0073C760
	private void FindTarget()
	{
		int num = int.MaxValue;
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			BeActor playerActor = allPlayers[i].playerActor;
			if (playerActor != null && !playerActor.IsDead())
			{
				int magnitude = (base.owner.GetPosition() - playerActor.GetPosition()).magnitude;
				if (magnitude < num)
				{
					num = magnitude;
					this.target = playerActor;
				}
			}
		}
	}

	// Token: 0x060178A6 RID: 96422 RVA: 0x0073E3F4 File Offset: 0x0073C7F4
	private void ChaseTarget()
	{
		if (this.target == null)
		{
			return;
		}
		VInt3 vint = this.target.GetPosition() - base.owner.GetPosition();
		if (vint.magnitude <= this.stopDistance.i)
		{
			base.owner.SetMoveSpeedX(VInt.zero);
			base.owner.SetMoveSpeedY(VInt.zero);
		}
		else
		{
			vint.NormalizeTo(this.moveSpeed.i);
			base.owner.SetMoveSpeedX(vint.x);
			base.owner.SetMoveSpeedY(vint.y);
		}
	}

	// Token: 0x060178A7 RID: 96423 RVA: 0x0073E4A8 File Offset: 0x0073C8A8
	public override void OnUpdate(int deltaTime)
	{
		if (this.target == null)
		{
			return;
		}
		if (this.target.IsDead())
		{
			return;
		}
		this.timer += deltaTime;
		if (this.timer >= this.intervel)
		{
			this.timer -= this.intervel;
			this.ChaseTarget();
		}
	}

	// Token: 0x060178A8 RID: 96424 RVA: 0x0073E50A File Offset: 0x0073C90A
	public override void OnFinish()
	{
		base.owner.aiManager.Start();
	}

	// Token: 0x04010EA3 RID: 69283
	private VInt moveSpeed;

	// Token: 0x04010EA4 RID: 69284
	private VInt stopDistance;

	// Token: 0x04010EA5 RID: 69285
	private int intervel = GlobalLogic.VALUE_200;

	// Token: 0x04010EA6 RID: 69286
	private int timer;

	// Token: 0x04010EA7 RID: 69287
	private BeActor target;
}
