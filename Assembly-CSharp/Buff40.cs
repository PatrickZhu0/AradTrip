using System;
using GameClient;

// Token: 0x02004228 RID: 16936
public class Buff40 : BeBuff
{
	// Token: 0x06017728 RID: 96040 RVA: 0x00734533 File Offset: 0x00732933
	public Buff40(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x06017729 RID: 96041 RVA: 0x00734544 File Offset: 0x00732944
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner != null && base.owner.isLocalActor)
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				clientSystemBattle.UseDrug();
			}
		}
	}
}
