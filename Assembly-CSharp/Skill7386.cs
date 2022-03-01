using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020044FE RID: 17662
public class Skill7386 : BeSkill
{
	// Token: 0x06018942 RID: 100674 RVA: 0x007AD55F File Offset: 0x007AB95F
	public Skill7386(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018943 RID: 100675 RVA: 0x007AD574 File Offset: 0x007AB974
	public override void OnInit()
	{
		base.OnInit();
	}

	// Token: 0x06018944 RID: 100676 RVA: 0x007AD57C File Offset: 0x007AB97C
	public override void OnStart()
	{
		base.OnStart();
		this.handle = base.owner.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
		{
			this.mechanism = base.owner.AddMechanism(1178, 0, MechanismSourceType.NONE, null, 0);
		});
	}

	// Token: 0x06018945 RID: 100677 RVA: 0x007AD5A4 File Offset: 0x007AB9A4
	public override void OnEnterPhase(int phase)
	{
		base.OnEnterPhase(phase);
		if (phase == 2)
		{
			List<BeActor> list = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.FindMonsterByID(list, this.monsterID, true);
			if (list.Count > 0)
			{
				BeActor beActor = list[0];
				beActor.DoDead(false);
				bool face = base.owner.GetFace();
				float x = (!face) ? -1f : 1f;
				base.owner.SetPosition(beActor.GetPosition() + new VInt3(x, 0f, 0f), true, true, false);
			}
			ListPool<BeActor>.Release(list);
		}
	}

	// Token: 0x06018946 RID: 100678 RVA: 0x007AD64A File Offset: 0x007ABA4A
	public override void OnCancel()
	{
		this.RemoveHandle();
		base.OnCancel();
	}

	// Token: 0x06018947 RID: 100679 RVA: 0x007AD658 File Offset: 0x007ABA58
	public override void OnFinish()
	{
		this.RemoveHandle();
		base.OnFinish();
	}

	// Token: 0x06018948 RID: 100680 RVA: 0x007AD666 File Offset: 0x007ABA66
	private void RemoveHandle()
	{
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
		if (this.mechanism != null)
		{
			base.owner.RemoveMechanism(1178);
		}
	}

	// Token: 0x04011BB5 RID: 72629
	private BeEventHandle handle;

	// Token: 0x04011BB6 RID: 72630
	private BeEventHandle handle1;

	// Token: 0x04011BB7 RID: 72631
	private BeMechanism mechanism;

	// Token: 0x04011BB8 RID: 72632
	private int monsterID = 4730011;
}
