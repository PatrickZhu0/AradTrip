using System;

// Token: 0x0200446A RID: 17514
public class Skill1709 : BeSkill
{
	// Token: 0x0601856B RID: 99691 RVA: 0x00794B41 File Offset: 0x00792F41
	public Skill1709(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601856C RID: 99692 RVA: 0x00794B4B File Offset: 0x00792F4B
	public override void OnInit()
	{
		this.buffID = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
	}

	// Token: 0x0601856D RID: 99693 RVA: 0x00794B70 File Offset: 0x00792F70
	public override void OnPostInit()
	{
		base.OnPostInit();
		this.mpReduce = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
	}

	// Token: 0x0601856E RID: 99694 RVA: 0x00794B9B File Offset: 0x00792F9B
	public override void OnStart()
	{
	}

	// Token: 0x0601856F RID: 99695 RVA: 0x00794BA0 File Offset: 0x00792FA0
	public override void OnFinish()
	{
		this.takeEffect = true;
		base.owner.buffController.TryAddBuff(this.buffID, int.MaxValue, base.level);
		base.owner.GetEntityData().ChangeMPReduce(this.mpReduce);
		this.RemoveHandle();
		this.handle = base.owner.RegisterEvent(BeEventType.onMPChange, delegate(object[] args)
		{
			if (base.owner.GetEntityData().GetMP() < this.mpReduce)
			{
				base.PressAgainCancel();
			}
		});
	}

	// Token: 0x06018570 RID: 99696 RVA: 0x00794C14 File Offset: 0x00793014
	public override void OnCancel()
	{
		this.RemoveHandle();
		if (this.takeEffect)
		{
			base.owner.GetEntityData().ChangeMPReduce(-this.mpReduce);
			base.owner.buffController.RemoveBuff(this.buffID, 0, 0);
			this.takeEffect = false;
		}
	}

	// Token: 0x06018571 RID: 99697 RVA: 0x00794C68 File Offset: 0x00793068
	public void RemoveHandle()
	{
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
	}

	// Token: 0x04011903 RID: 71939
	protected BeEventHandle handle;

	// Token: 0x04011904 RID: 71940
	protected int buffID;

	// Token: 0x04011905 RID: 71941
	protected int mpReduce;

	// Token: 0x04011906 RID: 71942
	private bool takeEffect;
}
