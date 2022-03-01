using System;

// Token: 0x0200444E RID: 17486
public class Skill1205 : BeSkill
{
	// Token: 0x0601845A RID: 99418 RVA: 0x0078EBC7 File Offset: 0x0078CFC7
	public Skill1205(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601845B RID: 99419 RVA: 0x0078EBD1 File Offset: 0x0078CFD1
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner != null)
		{
			this.RemoveHandle();
			this.handler = base.owner.RegisterEvent(BeEventType.onSummon, delegate(object[] args)
			{
				base.SetInnerState(BeSkill.InnerState.LAUNCH);
				BeActor beActor = args[0] as BeActor;
				if (beActor != null)
				{
					beActor.stateController.SetAbilityEnable(BeAbilityType.BLOCK, false);
					beActor.SetPosition(this.effectPos, false, true, false);
					beActor.attribute = base.owner.attribute;
				}
				this.RemoveHandle();
			});
		}
	}

	// Token: 0x0601845C RID: 99420 RVA: 0x0078EC09 File Offset: 0x0078D009
	public override void OnCancel()
	{
		this.RemoveHandle();
	}

	// Token: 0x0601845D RID: 99421 RVA: 0x0078EC11 File Offset: 0x0078D011
	public override void OnFinish()
	{
		this.RemoveHandle();
	}

	// Token: 0x0601845E RID: 99422 RVA: 0x0078EC19 File Offset: 0x0078D019
	private void RemoveHandle()
	{
		if (this.handler != null)
		{
			this.handler.Remove();
			this.handler = null;
		}
	}

	// Token: 0x04011836 RID: 71734
	private BeEventHandle handler;
}
