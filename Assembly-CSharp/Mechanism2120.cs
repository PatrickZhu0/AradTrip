using System;
using GameClient;

// Token: 0x020043B4 RID: 17332
public class Mechanism2120 : BeMechanism
{
	// Token: 0x0601809C RID: 98460 RVA: 0x00776498 File Offset: 0x00774898
	public Mechanism2120(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601809D RID: 98461 RVA: 0x007764A2 File Offset: 0x007748A2
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onBeHitAfterFinalDamage, new BeEventHandle.Del(this._onBeHit));
		if (InputManager.instance != null)
		{
			InputManager.instance.SetVisible(true, false);
		}
	}

	// Token: 0x0601809E RID: 98462 RVA: 0x007764E0 File Offset: 0x007748E0
	private void _onBeHit(object[] args)
	{
		TimeLimiteBattle timeLimiteBattle = base.owner.CurrentBeBattle as TimeLimiteBattle;
		if (timeLimiteBattle != null)
		{
			timeLimiteBattle.OnTriggerCount();
		}
	}
}
