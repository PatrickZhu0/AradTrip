using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004360 RID: 17248
public class Mechanism2041 : Mechanism2018
{
	// Token: 0x06017E33 RID: 97843 RVA: 0x00763548 File Offset: 0x00761948
	public Mechanism2041(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017E34 RID: 97844 RVA: 0x0076356C File Offset: 0x0076196C
	public override void OnInit()
	{
		base.OnInit();
		this.xOffset = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[2], this.level, true), GlobalLogic.VALUE_1000);
		this.damageX = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[3], this.level, true), GlobalLogic.VALUE_1000);
		this.hurtId = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		this.deadDelay = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
		if (this.deadDelay < 0)
		{
			this.deadDelay = 0;
		}
	}

	// Token: 0x06017E35 RID: 97845 RVA: 0x00763646 File Offset: 0x00761A46
	public override void OnStart()
	{
		this.hurtFlag = false;
	}

	// Token: 0x06017E36 RID: 97846 RVA: 0x00763650 File Offset: 0x00761A50
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (!this.hurtFlag)
		{
			VInt3 position = base.owner.GetPosition();
			if (!base.owner.GetFace())
			{
				position.x += this.xOffset.i;
			}
			else
			{
				position.x -= this.xOffset.i;
			}
			if (base.owner.CurrentBeScene.IsInBlockPlayer(position))
			{
				this.hurtFlag = true;
				this.DoDamage();
				base.owner.delayCaller.DelayCall(this.deadDelay, new DelayCaller.Del(this.DoOwnerDead), 0, 0, false);
			}
		}
	}

	// Token: 0x06017E37 RID: 97847 RVA: 0x0076370B File Offset: 0x00761B0B
	private void DoOwnerDead()
	{
		if (!base.owner.IsDead())
		{
			base.owner.DoDead(false);
		}
	}

	// Token: 0x06017E38 RID: 97848 RVA: 0x0076372C File Offset: 0x00761B2C
	private void DoDamage()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindFaceTargetsX(list, base.owner, this.boxXY[0] + this.damageX);
		for (int i = 0; i < list.Count; i++)
		{
			base.owner._onHurtEntity(list[i], list[i].GetPosition(), this.hurtId);
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x0401130B RID: 70411
	private VInt xOffset = 0;

	// Token: 0x0401130C RID: 70412
	private int hurtId;

	// Token: 0x0401130D RID: 70413
	private VInt damageX = 0;

	// Token: 0x0401130E RID: 70414
	private int deadDelay;

	// Token: 0x0401130F RID: 70415
	private bool hurtFlag;
}
