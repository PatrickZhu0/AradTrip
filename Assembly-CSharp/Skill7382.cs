using System;
using System.Collections.Generic;

// Token: 0x020044FD RID: 17661
public class Skill7382 : BeSkill
{
	// Token: 0x06018939 RID: 100665 RVA: 0x007AD214 File Offset: 0x007AB614
	public Skill7382(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601893A RID: 100666 RVA: 0x007AD260 File Offset: 0x007AB660
	public override void OnInit()
	{
		base.OnInit();
		this.skillId = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.distance = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		this.delayTime = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
		this.interTime = TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true);
	}

	// Token: 0x0601893B RID: 100667 RVA: 0x007AD2FF File Offset: 0x007AB6FF
	public override void OnStart()
	{
		base.OnStart();
		this.handle = base.owner.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
		{
			if (this.hitOther)
			{
				return;
			}
			this.hitOther = true;
			BeActor beActor = args[0] as BeActor;
			if (beActor != null)
			{
				base.owner.CurrentBeScene.FindMainActor(this.actorList);
				this.actorList.Remove(beActor);
				base.owner.delayCaller.DelayCall(this.delayTime, delegate
				{
					this.AttackOther(this.actorList);
				}, 0, 0, false);
			}
		});
	}

	// Token: 0x0601893C RID: 100668 RVA: 0x007AD328 File Offset: 0x007AB728
	private void AttackOther(List<BeActor> list)
	{
		if (list.Count <= 0)
		{
			return;
		}
		BeActor beActor = list[0];
		list.RemoveAt(0);
		if (beActor.IsDead())
		{
			this.AttackOther(list);
		}
		else
		{
			base.owner.SetFace(beActor.GetFace(), true, false);
			VInt3 pos = new VInt3((!beActor.GetFace()) ? (-1 * IntMath.Float2IntWithFixed((float)this.distance / 1000f, 10000L, 100L, MidpointRounding.ToEven)) : 1, 0, 0) + beActor.GetPosition();
			VInt3 rkPos = BeAIManager.FindStandPosition(pos, base.owner.CurrentBeScene, base.owner.GetFace(), false, 30);
			base.owner.SetPosition(rkPos, false, true, false);
			if (base.owner.CanUseSkill(this.skillId))
			{
				base.owner.UseSkill(this.skillId, false);
				base.owner.delayCaller.DelayCall(this.interTime, delegate
				{
					if (!this.owner.IsInPassiveState())
					{
						this.AttackOther(list);
					}
				}, 0, 0, false);
			}
		}
	}

	// Token: 0x0601893D RID: 100669 RVA: 0x007AD463 File Offset: 0x007AB863
	public override void OnCancel()
	{
		this.RemoveHandle();
		base.OnCancel();
	}

	// Token: 0x0601893E RID: 100670 RVA: 0x007AD471 File Offset: 0x007AB871
	public override void OnFinish()
	{
		this.RemoveHandle();
		base.OnFinish();
	}

	// Token: 0x0601893F RID: 100671 RVA: 0x007AD47F File Offset: 0x007AB87F
	private void RemoveHandle()
	{
		this.hitOther = false;
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
	}

	// Token: 0x04011BAE RID: 72622
	private BeEventHandle handle;

	// Token: 0x04011BAF RID: 72623
	private int distance = 1000;

	// Token: 0x04011BB0 RID: 72624
	private int skillId = 1500;

	// Token: 0x04011BB1 RID: 72625
	private int delayTime = 1500;

	// Token: 0x04011BB2 RID: 72626
	private int interTime = 1000;

	// Token: 0x04011BB3 RID: 72627
	private bool hitOther;

	// Token: 0x04011BB4 RID: 72628
	private List<BeActor> actorList = new List<BeActor>();
}
