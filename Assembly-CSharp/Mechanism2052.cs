using System;
using GameClient;

// Token: 0x0200436C RID: 17260
public class Mechanism2052 : BeMechanism
{
	// Token: 0x06017E81 RID: 97921 RVA: 0x007660BD File Offset: 0x007644BD
	public Mechanism2052(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017E82 RID: 97922 RVA: 0x007660C8 File Offset: 0x007644C8
	public override void OnInit()
	{
		base.OnInit();
		this.monsterId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.resID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.mHitActorCreatFlag = (TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) != 0);
	}

	// Token: 0x06017E83 RID: 97923 RVA: 0x00766160 File Offset: 0x00764560
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, new BeEventHandle.Del(this.onGenProjectile));
		if (this.mHitActorCreatFlag)
		{
			this.SceneHandleNewA = base.owner.CurrentBeScene.RegisterEventNew(BeEventSceneType.onHurtEntity, new BeEvent.BeEventHandleNew.Function(this.OnHurtEntity));
		}
	}

	// Token: 0x06017E84 RID: 97924 RVA: 0x007661C4 File Offset: 0x007645C4
	private void onGenProjectile(object[] args)
	{
		BeProjectile beProjectile = args[0] as BeProjectile;
		if (beProjectile != null)
		{
			beProjectile.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this.onProjectileDead));
		}
	}

	// Token: 0x06017E85 RID: 97925 RVA: 0x007661F8 File Offset: 0x007645F8
	private void onProjectileDead(object[] args)
	{
		if (base.owner == null || base.owner.CurrentBeScene == null)
		{
			return;
		}
		BeProjectile beProjectile = args[0] as BeProjectile;
		if (beProjectile != null && beProjectile.m_iResID == this.resID)
		{
			VInt3 pos = beProjectile.GetPosition();
			pos = BeAIManager.FindStandPositionNew(pos, base.owner.CurrentBeScene, !beProjectile.GetFace(), false, 40);
			BeActor beActor = base.owner.CurrentBeScene.SummonMonster(this.monsterId + this.level * 100, pos, base.owner.GetCamp(), base.owner, false, 0, true, 0, false, false);
		}
	}

	// Token: 0x06017E86 RID: 97926 RVA: 0x007662A4 File Offset: 0x007646A4
	protected void OnHurtEntity(BeEvent.BeEventParam param)
	{
		BeEntity beEntity = param.m_Obj as BeEntity;
		if (beEntity == null || beEntity.m_iResID != this.resID)
		{
			return;
		}
		BeActor beActor = param.m_Obj2 as BeActor;
		if (beActor != null && beActor.GetEntityData() != null && beActor.GetEntityData().isMonster)
		{
			param.m_Int = 0;
		}
	}

	// Token: 0x04011359 RID: 70489
	private int monsterId;

	// Token: 0x0401135A RID: 70490
	private int resID;

	// Token: 0x0401135B RID: 70491
	private bool mHitActorCreatFlag;
}
