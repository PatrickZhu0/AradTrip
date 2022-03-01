using System;

// Token: 0x02004363 RID: 17251
public class Mechanism2044 : BeMechanism
{
	// Token: 0x06017E42 RID: 97858 RVA: 0x00763BC9 File Offset: 0x00761FC9
	public Mechanism2044(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06017E43 RID: 97859 RVA: 0x00763BE0 File Offset: 0x00761FE0
	public override void OnInit()
	{
		base.OnInit();
		this.monsterId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.dist = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.hpRate = VFactor.NewVFactor(valueFromUnionCell, GlobalLogic.VALUE_1000);
	}

	// Token: 0x06017E44 RID: 97860 RVA: 0x00763C78 File Offset: 0x00762078
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner == null || base.owner.CurrentBeScene == null)
		{
			return;
		}
		BeActor beActor = base.owner.CurrentBeScene.CreateMonster(this.monsterId + base.owner.GetEntityData().GetLevel() * 100, true, null, this.level, base.owner.GetCamp(), base.owner, false);
		if (beActor == null)
		{
			return;
		}
		VInt3 position = base.owner.GetPosition();
		int hp = base.owner.attribute.GetHP();
		int hp2 = hp * this.hpRate;
		VInt3 vint = new VInt3(position.x + this.dist, position.y, position.z);
		if (base.owner.CurrentBeScene.IsInBlockPlayer(vint))
		{
			vint = BeAIManager.FindStandPositionNew(vint, base.owner.CurrentBeScene, false, false, 40);
		}
		beActor.SetPosition(vint, false, true, false);
		beActor.attribute.SetHP(hp2);
		if (beActor.m_pkGeActor != null)
		{
			beActor.m_pkGeActor.isSyncHPMP = true;
			beActor.m_pkGeActor.SyncHPBar();
			beActor.m_pkGeActor.isSyncHPMP = false;
		}
		beActor.StartAI(null, true);
		beActor = base.owner.CurrentBeScene.CreateMonster(this.monsterId + base.owner.GetEntityData().GetLevel() * 100, true, null, this.level, base.owner.GetCamp(), base.owner, false);
		if (beActor == null)
		{
			return;
		}
		vint = new VInt3(position.x - this.dist, position.y, position.z);
		if (base.owner.CurrentBeScene.IsInBlockPlayer(vint))
		{
			vint = BeAIManager.FindStandPositionNew(vint, base.owner.CurrentBeScene, true, false, 40);
		}
		beActor.SetPosition(vint, false, true, false);
		beActor.attribute.SetHP(hp2);
		beActor.StartAI(null, true);
		if (beActor.m_pkGeActor != null)
		{
			beActor.m_pkGeActor.isSyncHPMP = true;
			beActor.m_pkGeActor.SyncHPBar();
			beActor.m_pkGeActor.isSyncHPMP = false;
		}
		base.owner.attribute.SetHP(-1);
		base.owner.DoDead(true);
		if (base.owner.m_pkGeActor != null)
		{
			base.owner.m_pkGeActor.SetActorVisible(false);
		}
	}

	// Token: 0x04011316 RID: 70422
	private int monsterId;

	// Token: 0x04011317 RID: 70423
	private int dist;

	// Token: 0x04011318 RID: 70424
	private VFactor hpRate = VFactor.zero;
}
