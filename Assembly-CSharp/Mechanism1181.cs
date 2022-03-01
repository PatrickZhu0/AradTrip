using System;
using GameClient;

// Token: 0x020042E9 RID: 17129
public class Mechanism1181 : BeMechanism
{
	// Token: 0x06017B3C RID: 97084 RVA: 0x0074E265 File Offset: 0x0074C665
	public Mechanism1181(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B3D RID: 97085 RVA: 0x0074E26F File Offset: 0x0074C66F
	public override void OnStart()
	{
		base.OnStart();
		this._RegisterEvent();
	}

	// Token: 0x06017B3E RID: 97086 RVA: 0x0074E27D File Offset: 0x0074C67D
	private void _RegisterEvent()
	{
		this.handleNewA = base.owner.RegisterEventNew(BeEventType.onBreakActionChangeEvent, new BeEvent.BeEventHandleNew.Function(this._OnBreakActionChangeEvent));
	}

	// Token: 0x06017B3F RID: 97087 RVA: 0x0074E29E File Offset: 0x0074C69E
	private void _OnBreakActionChangeEvent(BeEvent.BeEventParam param)
	{
		if (!base.owner.stateController.CanBeBreakAction())
		{
			param.m_Bool = true;
		}
	}
}
