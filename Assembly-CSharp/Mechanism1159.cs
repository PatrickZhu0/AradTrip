using System;

// Token: 0x020042D1 RID: 17105
public class Mechanism1159 : BeMechanism
{
	// Token: 0x06017AAE RID: 96942 RVA: 0x0074B486 File Offset: 0x00749886
	public Mechanism1159(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017AAF RID: 96943 RVA: 0x0074B4A4 File Offset: 0x007498A4
	public override void OnInit()
	{
		base.OnInit();
		this._checkTime = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this._buffId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		if (this.data.ValueC.Count > 0)
		{
			this.m_NewResetCDFlag = (TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) == 0);
		}
	}

	// Token: 0x06017AB0 RID: 96944 RVA: 0x0074B551 File Offset: 0x00749951
	public override void OnStart()
	{
		base.OnStart();
		this._RegisterEvent();
		this._functionState = Mechanism1159.FunctionState.Ready;
	}

	// Token: 0x06017AB1 RID: 96945 RVA: 0x0074B566 File Offset: 0x00749966
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this._UpdateFunctionState(deltaTime);
	}

	// Token: 0x06017AB2 RID: 96946 RVA: 0x0074B578 File Offset: 0x00749978
	private void _RegisterEvent()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onSkillCancel, new BeEventHandle.Del(this._OnSkillCancel));
		this.handleB = base.owner.RegisterEvent(BeEventType.onCastSkillFinish, new BeEventHandle.Del(this._OnCastSkillFinish));
		this.handleC = base.owner.RegisterEvent(BeEventType.onBeforeHit, new BeEventHandle.Del(this._OnBeforeHit));
		this.handleD = base.owner.RegisterEvent(BeEventType.onCastSkill, new BeEventHandle.Del(this._OnCastSkill));
	}

	// Token: 0x06017AB3 RID: 96947 RVA: 0x0074B604 File Offset: 0x00749A04
	private void _UpdateFunctionState(int deltaTime)
	{
		if (this._functionState == Mechanism1159.FunctionState.Pause)
		{
			return;
		}
		if (this._functionState != Mechanism1159.FunctionState.InCD)
		{
			return;
		}
		this._curTime += deltaTime;
		if (this._curTime < this._checkTime)
		{
			return;
		}
		this._curTime = 0;
		this._functionState = Mechanism1159.FunctionState.Ready;
	}

	// Token: 0x06017AB4 RID: 96948 RVA: 0x0074B659 File Offset: 0x00749A59
	private void _OnSkillCancel(object[] args)
	{
		if (this._functionState != Mechanism1159.FunctionState.AddDamage && this._functionState != Mechanism1159.FunctionState.Pause)
		{
			return;
		}
		if (!this.m_NewResetCDFlag)
		{
			this._curTime = 0;
		}
		this._functionState = Mechanism1159.FunctionState.InCD;
	}

	// Token: 0x06017AB5 RID: 96949 RVA: 0x0074B68D File Offset: 0x00749A8D
	private void _OnCastSkillFinish(object[] args)
	{
		if (this._functionState != Mechanism1159.FunctionState.AddDamage && this._functionState != Mechanism1159.FunctionState.Pause)
		{
			return;
		}
		if (!this.m_NewResetCDFlag)
		{
			this._curTime = 0;
		}
		this._functionState = Mechanism1159.FunctionState.InCD;
	}

	// Token: 0x06017AB6 RID: 96950 RVA: 0x0074B6C1 File Offset: 0x00749AC1
	private void _OnCastSkill(object[] args)
	{
		if (this._functionState != Mechanism1159.FunctionState.InCD)
		{
			return;
		}
		if (!this.m_NewResetCDFlag)
		{
			this._curTime = 0;
			this._functionState = Mechanism1159.FunctionState.Pause;
		}
	}

	// Token: 0x06017AB7 RID: 96951 RVA: 0x0074B6EC File Offset: 0x00749AEC
	private void _OnBeforeHit(object[] args)
	{
		if (this.m_NewResetCDFlag)
		{
			this._curTime = 0;
		}
		if (this._functionState == Mechanism1159.FunctionState.InCD)
		{
			return;
		}
		int num = (int)args[3];
		if (this._functionState == Mechanism1159.FunctionState.Ready)
		{
			this._curSkillId = num;
			this._functionState = Mechanism1159.FunctionState.AddDamage;
		}
		if (this._functionState == Mechanism1159.FunctionState.AddDamage && this._curSkillId == num)
		{
			base.owner.buffController.TryAddBuff(this._buffId, 33, 1);
		}
	}

	// Token: 0x04011020 RID: 69664
	private int _checkTime = 5000;

	// Token: 0x04011021 RID: 69665
	private int _buffId;

	// Token: 0x04011022 RID: 69666
	private int _curTime;

	// Token: 0x04011023 RID: 69667
	private Mechanism1159.FunctionState _functionState;

	// Token: 0x04011024 RID: 69668
	private int _curSkillId;

	// Token: 0x04011025 RID: 69669
	private bool m_NewResetCDFlag = true;

	// Token: 0x020042D2 RID: 17106
	private enum FunctionState
	{
		// Token: 0x04011027 RID: 69671
		None,
		// Token: 0x04011028 RID: 69672
		InCD,
		// Token: 0x04011029 RID: 69673
		Pause,
		// Token: 0x0401102A RID: 69674
		Ready,
		// Token: 0x0401102B RID: 69675
		AddDamage
	}
}
