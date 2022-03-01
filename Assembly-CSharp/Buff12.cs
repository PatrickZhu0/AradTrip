using System;

// Token: 0x02004217 RID: 16919
public class Buff12 : BeBuff
{
	// Token: 0x060176C5 RID: 95941 RVA: 0x007323AB File Offset: 0x007307AB
	public Buff12(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x060176C6 RID: 95942 RVA: 0x007323C0 File Offset: 0x007307C0
	public override void OnFinish()
	{
		if (base.owner != null && !base.owner.IsDead())
		{
			base.owner.buffController.TryAddBuff(29, GlobalLogic.VALUE_5000, 1);
			if (base.owner.aiManager != null)
			{
				base.owner.aiManager.Stop();
				base.owner.ClearMoveSpeed(7);
			}
			base.owner.m_pkGeActor.ChangeSurface("无敌", 0f, true, true);
			if (this.showDisappearEffect && base.owner.GetEntityData().type != 8)
			{
				base.owner.CurrentBeScene.currentGeScene.CreateEffect("Effects/Hero_Zhaohuanshi/Kaxiliyasi/Prefab/Eff_kaxiliyasi_xiaoshi", 0f, new Vec3(base.owner.GetPosition().fx, base.owner.GetPosition().fy, 0.5f), 1f, 1f, false, false);
			}
			if (base.owner.HasAction("Expdead2") || base.owner.HasAction("Expdead3"))
			{
				base.owner.DoDead(false);
			}
			else if (base.owner.m_iEntityLifeState != 4)
			{
				int[] array = new int[]
				{
					0
				};
				base.owner.TriggerEvent(BeEventType.onDead, new object[]
				{
					array,
					false,
					base.owner
				});
				base.owner.SetIsDead(true);
				base.owner.delayCaller.DelayCall(300, delegate
				{
					base.owner.OnDead();
					base.owner.SetLifeState(EntityLifeState.ELS_CANREMOVE);
				}, 0, 0, false);
			}
		}
	}

	// Token: 0x04010D13 RID: 68883
	public bool showDisappearEffect = true;
}
