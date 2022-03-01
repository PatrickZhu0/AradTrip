using System;

// Token: 0x0200428A RID: 17034
public class Mechanism1065 : BeMechanism
{
	// Token: 0x06017918 RID: 96536 RVA: 0x0074136E File Offset: 0x0073F76E
	public Mechanism1065(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017919 RID: 96537 RVA: 0x00741390 File Offset: 0x0073F790
	public override void OnInit()
	{
		base.OnInit();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.hitEffectPos[i] = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
		}
		for (int j = 0; j < this.data.ValueB.Count; j++)
		{
			this.hitNumberPos[j] = TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true);
		}
	}

	// Token: 0x0601791A RID: 96538 RVA: 0x00741444 File Offset: 0x0073F844
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onChangeBeHitEffectPos, delegate(object[] args)
		{
			if (this.hitEffectPos != VInt3.zero)
			{
				VInt3[] array = (VInt3[])args[0];
				array[0] += this.hitEffectPos;
			}
		});
		this.handleB = base.owner.RegisterEvent(BeEventType.onChangeBeHitNumberPos, delegate(object[] args)
		{
			if (this.hitNumberPos != VInt3.zero)
			{
				Vec3[] array = (Vec3[])args[0];
				array[0] += this.hitNumberPos.vec3;
			}
		});
	}

	// Token: 0x04010EF5 RID: 69365
	private VInt3 hitEffectPos = VInt3.zero;

	// Token: 0x04010EF6 RID: 69366
	private VInt3 hitNumberPos = VInt3.zero;
}
