using System;
using System.Collections.Generic;

// Token: 0x0200447C RID: 17532
public class Skill20210 : BeSkill
{
	// Token: 0x06018608 RID: 99848 RVA: 0x007987FF File Offset: 0x00796BFF
	public Skill20210(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018609 RID: 99849 RVA: 0x0079882A File Offset: 0x00796C2A
	public override void OnInit()
	{
		base.OnInit();
	}

	// Token: 0x0601860A RID: 99850 RVA: 0x00798832 File Offset: 0x00796C32
	public override void OnStart()
	{
		base.OnStart();
		base.owner.CurrentBeScene.FindMainActor(this.list);
	}

	// Token: 0x0601860B RID: 99851 RVA: 0x00798851 File Offset: 0x00796C51
	public override void OnUpdate(int iDeltime)
	{
		base.OnUpdate(iDeltime);
	}

	// Token: 0x0601860C RID: 99852 RVA: 0x0079885C File Offset: 0x00796C5C
	public override void OnEnterPhase(int phase)
	{
		base.OnEnterPhase(phase);
		if (phase == 1)
		{
			return;
		}
		BeActor target = this.SelectTarget();
		if (target == null)
		{
			return;
		}
		base.owner.delayCaller.DelayCall(500, delegate
		{
			if (this.owner == null || this.owner.IsDead())
			{
				return;
			}
			if (target != null)
			{
				this.owner.SetFace(target.GetPosition().x < this.owner.GetPosition().x, true, false);
				VInt3 position = target.GetPosition();
				position.z = 0;
				GeEffectEx geEffectEx = this.owner.CurrentBeScene.currentGeScene.CreateEffect(this.effect, (float)this.time / 1000f, position.vec3, 1f, 1f, false, false);
				geEffectEx.SetScale(2.4f, 0f, 1.7f);
				BeMoveTo action = BeMoveTo.Create(this.owner, this.time, this.owner.GetPosition(), target.GetPosition(), false, null, false);
				this.owner.actionManager.RunAction(action);
			}
		}, 0, 0, false);
	}

	// Token: 0x0601860D RID: 99853 RVA: 0x007988C4 File Offset: 0x00796CC4
	private BeActor SelectTarget()
	{
		if (this.list.Count == 0)
		{
			base.owner.CurrentBeScene.FindMainActor(this.list);
			if (this.list.Count <= 0)
			{
				return null;
			}
		}
		int index = base.owner.FrameRandom.InRange(0, this.list.Count);
		BeActor result = this.list[index];
		this.list.Remove(this.list[index]);
		return result;
	}

	// Token: 0x04011987 RID: 72071
	private string effect = "Effects/Hero_Zhaohuanshi/Luyisi/Prefab/Eff_Zhaohuanluyisi_jiaodi";

	// Token: 0x04011988 RID: 72072
	private List<BeActor> list = new List<BeActor>();

	// Token: 0x04011989 RID: 72073
	private int time = 600;
}
