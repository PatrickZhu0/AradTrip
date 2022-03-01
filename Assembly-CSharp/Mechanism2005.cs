using System;

// Token: 0x0200433B RID: 17211
public class Mechanism2005 : BeMechanism
{
	// Token: 0x06017D11 RID: 97553 RVA: 0x0075B58E File Offset: 0x0075998E
	public Mechanism2005(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017D12 RID: 97554 RVA: 0x0075B5A4 File Offset: 0x007599A4
	public override void OnInit()
	{
		base.OnInit();
		this.dis = new VInt((float)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) / 1000f);
		this.skillID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017D13 RID: 97555 RVA: 0x0075B614 File Offset: 0x00759A14
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner == null)
		{
			base.Finish();
			return;
		}
		this.target = this.FindTarget(base.owner.GetPosition());
		if (this.target == null)
		{
			base.Finish();
			return;
		}
		this.handleA = this.target.RegisterEvent(BeEventType.onDead, delegate(object[] args)
		{
			base.owner.DoDead(false);
		});
		if (this.HaveBuff(this.target) || !this.target.isMainActor)
		{
			base.Finish();
			return;
		}
		this.handleB = base.owner.RegisterEvent(BeEventType.onBeKilled, delegate(object[] args)
		{
			if (base.owner.IsDead())
			{
				base.owner.DoDead(false);
			}
		});
		base.owner.stateController.SetAbilityEnable(BeAbilityType.BEGRAB, false);
		base.owner.buffController.RemoveBuff(521722, 0, 0);
		base.owner.UseSkill(this.skillID, true);
	}

	// Token: 0x06017D14 RID: 97556 RVA: 0x0075B704 File Offset: 0x00759B04
	protected BeActor FindTarget(VInt3 pos)
	{
		if (base.owner == null)
		{
			return null;
		}
		return base.owner.CurrentBeScene.FindNearestRangeTarget(pos, base.owner, this.dis, null);
	}

	// Token: 0x06017D15 RID: 97557 RVA: 0x0075B740 File Offset: 0x00759B40
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (base.owner == null || this.target == null || !this.isRunning)
		{
			return;
		}
		if (this.target.IsDead() || base.owner.IsDead())
		{
			base.owner.DoDead(false);
			return;
		}
		VInt3 position = this.target.GetPosition();
		VInt3 rkPos = position;
		if (!base.owner.GetFace())
		{
			rkPos.x = position.x - VInt.Float2VIntValue(0.5f);
		}
		else
		{
			rkPos.x = position.x + VInt.Float2VIntValue(0.5f);
		}
		rkPos.y -= VInt.Float2VIntValue(0.03f);
		rkPos.z += VInt.Float2VIntValue(0.3f);
		base.owner.SetPosition(rkPos, false, true, false);
		base.owner.SetFace(this.target.GetFace(), false, false);
	}

	// Token: 0x06017D16 RID: 97558 RVA: 0x0075B850 File Offset: 0x00759C50
	private bool HaveBuff(BeActor actor)
	{
		return actor.buffController != null && (actor.buffController.HasBuffByID(521727) != null || actor.buffController.HasBuffByID(521728) != null || actor.buffController.HasBuffByID(521729) != null);
	}

	// Token: 0x06017D17 RID: 97559 RVA: 0x0075B8AD File Offset: 0x00759CAD
	public override void OnFinish()
	{
		base.OnFinish();
	}

	// Token: 0x04011236 RID: 70198
	private BeActor target;

	// Token: 0x04011237 RID: 70199
	private VInt dis = VInt.one;

	// Token: 0x04011238 RID: 70200
	private int skillID;
}
