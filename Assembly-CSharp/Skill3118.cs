using System;

// Token: 0x020044C0 RID: 17600
public class Skill3118 : BeSkill
{
	// Token: 0x060187C3 RID: 100291 RVA: 0x007A4BD9 File Offset: 0x007A2FD9
	public Skill3118(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060187C4 RID: 100292 RVA: 0x007A4BF9 File Offset: 0x007A2FF9
	public override void OnEnterPhase(int phase)
	{
		if (phase == 3)
		{
			base.owner.delayCaller.DelayCall(this.delayLaunch, delegate
			{
				this.DoStart();
			}, 0, 0, false);
		}
	}

	// Token: 0x060187C5 RID: 100293 RVA: 0x007A4C28 File Offset: 0x007A3028
	public override void OnFinish()
	{
		this.DoRestore();
	}

	// Token: 0x060187C6 RID: 100294 RVA: 0x007A4C30 File Offset: 0x007A3030
	public override void OnCancel()
	{
		this.DoRestore();
	}

	// Token: 0x060187C7 RID: 100295 RVA: 0x007A4C38 File Offset: 0x007A3038
	private void DoStart()
	{
		this.mechanism = (base.owner.AddMechanism(1110, 1, MechanismSourceType.NONE, null, 0) as Mechanism70);
		if (this.mechanism != null)
		{
			this.mechanism.skill = this;
			this.mechanism.canControl = true;
			this.mechanism.DoStart();
		}
	}

	// Token: 0x060187C8 RID: 100296 RVA: 0x007A4C94 File Offset: 0x007A3094
	public void AttackCamera(BeEntity entity)
	{
		if (entity == null)
		{
			return;
		}
		if (base.owner.isLocalActor)
		{
			if (entity != base.owner && !this.skillState.IsRunning())
			{
				entity = base.owner;
			}
			BattleMain.instance.GetDungeonManager().GetGeScene().AttachCameraTo(entity.m_pkGeActor);
		}
	}

	// Token: 0x060187C9 RID: 100297 RVA: 0x007A4CF8 File Offset: 0x007A30F8
	private void DoRestore()
	{
		if (this.mechanism != null)
		{
			this.mechanism.canControl = false;
			this.mechanism.Finish();
			this.mechanism.SetDead();
			this.mechanism = null;
		}
		this.AttackCamera(base.owner);
	}

	// Token: 0x04011AA9 RID: 72361
	private int delayLaunch = 200;

	// Token: 0x04011AAA RID: 72362
	private int mechanismID = 1110;

	// Token: 0x04011AAB RID: 72363
	private Mechanism70 mechanism;
}
