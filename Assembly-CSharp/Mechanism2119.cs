using System;
using GameClient;

// Token: 0x020043B3 RID: 17331
public class Mechanism2119 : BeMechanism
{
	// Token: 0x06018099 RID: 98457 RVA: 0x00776435 File Offset: 0x00774835
	public Mechanism2119(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601809A RID: 98458 RVA: 0x0077643F File Offset: 0x0077483F
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this._onDead));
	}

	// Token: 0x0601809B RID: 98459 RVA: 0x00776468 File Offset: 0x00774868
	private void _onDead(object[] args)
	{
		TimeLimiteBattle timeLimiteBattle = base.owner.CurrentBeBattle as TimeLimiteBattle;
		if (timeLimiteBattle != null)
		{
			timeLimiteBattle.OnTriggerCount();
		}
		base.Finish();
	}
}
