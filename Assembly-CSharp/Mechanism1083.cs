using System;

// Token: 0x0200429B RID: 17051
public class Mechanism1083 : BeMechanism
{
	// Token: 0x06017970 RID: 96624 RVA: 0x00743DCF File Offset: 0x007421CF
	public Mechanism1083(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x17002004 RID: 8196
	// (get) Token: 0x06017971 RID: 96625 RVA: 0x00743DE0 File Offset: 0x007421E0
	public bool Flag
	{
		get
		{
			return this.finishFrozenFlag;
		}
	}

	// Token: 0x06017972 RID: 96626 RVA: 0x00743DE8 File Offset: 0x007421E8
	public override void OnInit()
	{
		this.buffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.attachEffectID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		if (TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) == 0)
		{
			this.finishFrozenFlag = true;
		}
		else
		{
			this.finishFrozenFlag = false;
		}
	}

	// Token: 0x06017973 RID: 96627 RVA: 0x00743E84 File Offset: 0x00742284
	public override void OnStart()
	{
		if (base.owner != null)
		{
			if (this.buffInfoID != 0)
			{
				this.handleA = base.owner.RegisterEvent(BeEventType.onBeforeHit, new BeEventHandle.Del(this.OnBeforeHitEvent));
			}
			if (this.attachEffectID != 0)
			{
				this.handleB = base.owner.RegisterEvent(BeEventType.onAfterFinalDamageNew, new BeEventHandle.Del(this.OnAfterFinalDamageNewEvent));
			}
		}
	}

	// Token: 0x06017974 RID: 96628 RVA: 0x00743EF0 File Offset: 0x007422F0
	private void OnBeforeHitEvent(object[] args)
	{
		if (args != null && args.Length >= 3)
		{
			int num = (int)args[2];
			if (num == this.attachEffectID)
			{
				return;
			}
			MagicElementType attackElementType = base.owner.GetEntityData().GetAttackElementType(num);
			BeActor beActor = args[0] as BeActor;
			if (beActor != null && attackElementType == MagicElementType.FIRE && beActor.stateController.HasBuffState(BeBuffStateType.FROZEN))
			{
				base.owner.buffController.TryAddBuffInfo(this.buffInfoID, base.owner, this.level);
			}
		}
	}

	// Token: 0x06017975 RID: 96629 RVA: 0x00743F88 File Offset: 0x00742388
	private void OnAfterFinalDamageNewEvent(object[] args)
	{
		int num = (int)args[2];
		if (num == this.attachEffectID)
		{
			return;
		}
		MagicElementType attackElementType = base.owner.GetEntityData().GetAttackElementType(num);
		BeActor beActor = (BeActor)args[1];
		if (beActor != null && attackElementType == MagicElementType.FIRE && beActor.stateController.HasBuffState(BeBuffStateType.FROZEN))
		{
			base.owner.DoAttackTo(beActor, this.attachEffectID, false, true);
		}
	}

	// Token: 0x04010F35 RID: 69429
	private int buffInfoID;

	// Token: 0x04010F36 RID: 69430
	private int attachEffectID;

	// Token: 0x04010F37 RID: 69431
	private bool finishFrozenFlag = true;
}
