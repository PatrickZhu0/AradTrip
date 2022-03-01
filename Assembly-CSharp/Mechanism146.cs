using System;
using System.Collections.Generic;

// Token: 0x0200431C RID: 17180
public class Mechanism146 : BeMechanism
{
	// Token: 0x06017C5B RID: 97371 RVA: 0x00756B32 File Offset: 0x00754F32
	public Mechanism146(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C5C RID: 97372 RVA: 0x00756B48 File Offset: 0x00754F48
	public override void OnStart()
	{
		if (base.owner != null)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onDead, delegate(object[] args)
			{
				if (base.owner != null && base.owner.CurrentBeBattle != null)
				{
					base.owner.CurrentBeBattle.OnCriticalElementDisappear();
				}
			});
			if (base.owner.CurrentBeScene != null)
			{
				this.handleB = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.onBossDead, new BeEventHandle.Del(this.onBossDead));
			}
		}
	}

	// Token: 0x06017C5D RID: 97373 RVA: 0x00756BB2 File Offset: 0x00754FB2
	private void onBossDead(object[] args)
	{
		base.owner.buffController.TryAddBuff(29, -1, 1);
	}

	// Token: 0x04011193 RID: 70035
	private List<int> mAttackActorIDs = new List<int>();
}
