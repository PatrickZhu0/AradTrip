using System;

// Token: 0x0200418F RID: 16783
public class BeActionActorFilter : IEntityFilter
{
	// Token: 0x0601706D RID: 94317 RVA: 0x00710863 File Offset: 0x0070EC63
	public void Init(bool special = false, bool bati = false, bool absorb = false, bool geDang = false, bool fallOrFloat = false)
	{
		this.isSpecialBuff = special;
		this.isBati = bati;
		this.isAbsorb = absorb;
		this.isGeDang = geDang;
		this.isFallgroundOrFloat = fallOrFloat;
	}

	// Token: 0x0601706E RID: 94318 RVA: 0x0071088C File Offset: 0x0070EC8C
	public bool isFit(BeEntity target)
	{
		BeActor beActor = (BeActor)target;
		return beActor != null && !beActor.IsDead() && !beActor.isAbsorb && beActor.buffController != null && !beActor.buffController.HaveBatiBuff() && beActor.buffController.HasBuffByID(50) == null && beActor.stateController != null && beActor.stateController.HasBornAbility(BeAbilityType.FALLGROUND) && beActor.stateController.HasBornAbility(BeAbilityType.FLOAT) && (!this.isSpecialBuff || (!beActor.stateController.HasBuffState(BeBuffStateType.FROZEN) && !beActor.stateController.HasBuffState(BeBuffStateType.STONE)));
	}

	// Token: 0x0601706F RID: 94319 RVA: 0x00710956 File Offset: 0x0070ED56
	public bool isUseDefault()
	{
		return true;
	}

	// Token: 0x0401094E RID: 67918
	private bool isSpecialBuff;

	// Token: 0x0401094F RID: 67919
	private bool isBati;

	// Token: 0x04010950 RID: 67920
	private bool isAbsorb;

	// Token: 0x04010951 RID: 67921
	private bool isGeDang;

	// Token: 0x04010952 RID: 67922
	private bool isFallgroundOrFloat;
}
