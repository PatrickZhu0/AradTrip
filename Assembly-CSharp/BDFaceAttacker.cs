using System;

// Token: 0x020040FA RID: 16634
public class BDFaceAttacker : BDEventBase
{
	// Token: 0x06016A5E RID: 92766 RVA: 0x006DC1D4 File Offset: 0x006DA5D4
	public override void OnEvent(BeEntity pkEntity)
	{
		base.OnEvent(pkEntity);
		BeActor beActor = (BeActor)pkEntity;
		if (beActor == null)
		{
			return;
		}
		BeActor beActor2 = beActor.CurrentBeScene.GetEntityByPID(pkEntity.lastAttackerId.i) as BeActor;
		if (beActor2 != null && !beActor2.IsDead())
		{
			pkEntity.SetFace(pkEntity.GetPosition().x > beActor2.GetPosition().x, false, false);
		}
	}
}
