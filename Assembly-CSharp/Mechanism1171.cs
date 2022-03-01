using System;
using GameClient;

// Token: 0x020042E0 RID: 17120
public class Mechanism1171 : BeMechanism
{
	// Token: 0x06017B09 RID: 97033 RVA: 0x0074D0B9 File Offset: 0x0074B4B9
	public Mechanism1171(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B0A RID: 97034 RVA: 0x0074D0C3 File Offset: 0x0074B4C3
	public override void OnStart()
	{
		base.OnStart();
		this._haveAttack = false;
		this._RegisterEvent();
	}

	// Token: 0x06017B0B RID: 97035 RVA: 0x0074D0D8 File Offset: 0x0074B4D8
	private void _RegisterEvent()
	{
		this.handleNewA = base.owner.RegisterEventNew(BeEventType.onStateChangeEnd, new BeEvent.BeEventHandleNew.Function(this._OnStateChangeEnd));
	}

	// Token: 0x06017B0C RID: 97036 RVA: 0x0074D0FC File Offset: 0x0074B4FC
	private void _OnStateChangeEnd(BeEvent.BeEventParam param)
	{
		if (this._haveAttack)
		{
			return;
		}
		ActionState @int = (ActionState)param.m_Int;
		if (@int != ActionState.AS_FALLGROUND && @int != ActionState.AS_FALLCLICK)
		{
			return;
		}
		this._haveAttack = true;
		this._ClearFallGroundTag();
		this._RemoveAttachBuff();
	}

	// Token: 0x06017B0D RID: 97037 RVA: 0x0074D140 File Offset: 0x0074B540
	private void _ClearFallGroundTag()
	{
		base.owner.SetTag(4, false);
	}

	// Token: 0x06017B0E RID: 97038 RVA: 0x0074D14F File Offset: 0x0074B54F
	private void _RemoveAttachBuff()
	{
		if (this.attachBuff == null)
		{
			return;
		}
		this.attachBuff.Finish();
	}

	// Token: 0x04011062 RID: 69730
	private bool _haveAttack;
}
