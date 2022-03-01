using System;
using System.Collections.Generic;

// Token: 0x0200441C RID: 17436
public class Mechanism90 : BeMechanism
{
	// Token: 0x06018373 RID: 99187 RVA: 0x0078A8ED File Offset: 0x00788CED
	public Mechanism90(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06018374 RID: 99188 RVA: 0x0078A918 File Offset: 0x00788D18
	public override void OnInit()
	{
		this.actorNumber = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.radius = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x06018375 RID: 99189 RVA: 0x0078A97F File Offset: 0x00788D7F
	public override void OnStart()
	{
		this.timer = 0;
	}

	// Token: 0x06018376 RID: 99190 RVA: 0x0078A988 File Offset: 0x00788D88
	public override void OnFinish()
	{
		this.actorList.Clear();
	}

	// Token: 0x06018377 RID: 99191 RVA: 0x0078A995 File Offset: 0x00788D95
	public override void OnUpdate(int deltaTime)
	{
		this.timer += deltaTime;
		if (this.timer >= this.interval)
		{
			this._checkActorToProtect();
			this._checkActorToHurt();
			this.timer = 0;
		}
	}

	// Token: 0x06018378 RID: 99192 RVA: 0x0078A9CC File Offset: 0x00788DCC
	private void _checkActorToProtect()
	{
		if (base.owner == null)
		{
			return;
		}
		if (base.owner.IsDead())
		{
			return;
		}
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			BeActor playerActor = allPlayers[i].playerActor;
			if (playerActor != null)
			{
				if (!playerActor.IsDead())
				{
					int magnitude = (playerActor.GetPosition() - base.owner.GetPosition()).magnitude;
					if (this.actorList.Contains(playerActor))
					{
						if (magnitude >= this.radius.i)
						{
							base.owner.CancelSkill(this.skillId, true);
							base.owner.sgSwitchStates(new BeStateData(0, 0));
							this.actorList.Remove(playerActor);
						}
					}
					else if (this.actorList.Count < this.actorNumber && magnitude < this.radius.i)
					{
						base.owner.UseSkill(this.skillId, false);
						this.actorList.Add(playerActor);
					}
				}
			}
		}
	}

	// Token: 0x06018379 RID: 99193 RVA: 0x0078AB0C File Offset: 0x00788F0C
	private void _checkActorToHurt()
	{
		if (base.owner == null)
		{
			return;
		}
		if (base.owner.IsDead())
		{
			return;
		}
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			BeActor playerActor = allPlayers[i].playerActor;
			if (playerActor != null)
			{
				if (!playerActor.IsDead())
				{
					if (!this.actorList.Contains(playerActor))
					{
						VInt3 vint = playerActor.GetPosition() - base.owner.GetPosition();
						if (vint.magnitude < this.radius.i && playerActor.sgGetCurrentState() != 4)
						{
							int fStateData = (vint.x <= 0) ? -60000 : 60000;
							playerActor.Locomote(new BeStateData(4, 0, fStateData, 0, 0, 200, true), false);
						}
					}
				}
			}
		}
	}

	// Token: 0x040117AE RID: 71598
	private int actorNumber;

	// Token: 0x040117AF RID: 71599
	private VInt radius;

	// Token: 0x040117B0 RID: 71600
	private List<BeActor> actorList = new List<BeActor>();

	// Token: 0x040117B1 RID: 71601
	private int skillId = 5770;

	// Token: 0x040117B2 RID: 71602
	private int interval = 150;

	// Token: 0x040117B3 RID: 71603
	private int timer;
}
