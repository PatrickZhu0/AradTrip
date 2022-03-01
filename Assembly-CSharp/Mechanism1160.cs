using System;

// Token: 0x020042D4 RID: 17108
public class Mechanism1160 : BeMechanism
{
	// Token: 0x06017ABA RID: 96954 RVA: 0x0074B84F File Offset: 0x00749C4F
	public Mechanism1160(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017ABB RID: 96955 RVA: 0x0074B864 File Offset: 0x00749C64
	public override void OnInit()
	{
		base.OnInit();
		this._needTransRate = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this._transRate = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true), GlobalLogic.VALUE_1000);
		this._addMaxValue = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06017ABC RID: 96956 RVA: 0x0074B8F9 File Offset: 0x00749CF9
	public override void OnStart()
	{
		base.OnStart();
		this._RegisterEvent();
		if (base.owner.attribute != null)
		{
			this._addMaxValue *= base.owner.attribute.GetLevel();
		}
	}

	// Token: 0x06017ABD RID: 96957 RVA: 0x0074B934 File Offset: 0x00749D34
	private void _RegisterEvent()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onBeforeHit, new BeEventHandle.Del(this._OnBeforeHit));
	}

	// Token: 0x06017ABE RID: 96958 RVA: 0x0074B958 File Offset: 0x00749D58
	private void _OnBeforeHit(object[] args)
	{
		int num = base.FrameRandom.InRange(0, GlobalLogic.VALUE_1000);
		if (num > this._needTransRate)
		{
			return;
		}
		BeActor beActor = args[0] as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (!beActor.stateController.HasBuffState(BeBuffStateType.BLEEDING))
		{
			return;
		}
		int hp = beActor.attribute.GetHP();
		int num2 = hp * this._transRate;
		num2 = IntMath.Min(num2, this._addMaxValue);
		base.owner.DoHPChange(num2, false);
	}

	// Token: 0x04011030 RID: 69680
	private int _needTransRate;

	// Token: 0x04011031 RID: 69681
	private VFactor _transRate = VFactor.zero;

	// Token: 0x04011032 RID: 69682
	private int _addMaxValue;
}
