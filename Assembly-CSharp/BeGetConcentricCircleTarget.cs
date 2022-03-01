using System;

// Token: 0x02004194 RID: 16788
public class BeGetConcentricCircleTarget : IEntityFilter
{
	// Token: 0x0601707D RID: 94333 RVA: 0x00710AC8 File Offset: 0x0070EEC8
	public bool isFit(BeEntity target)
	{
		BeActor beActor = target as BeActor;
		if (beActor == null)
		{
			return false;
		}
		if (beActor.IsDead())
		{
			return false;
		}
		if (this.m_Owner.IsDead() || this.m_Owner == beActor || this.m_Owner.m_iCamp == beActor.m_iCamp)
		{
			return false;
		}
		if (beActor.IsSkillMonster())
		{
			return false;
		}
		if (!beActor.stateController.CanBeTargeted())
		{
			return false;
		}
		VInt2 a = new VInt2(beActor.GetPosition().x, beActor.GetPosition().y);
		int magnitude = (a - this.m_OwnerPosXY).magnitude;
		return magnitude >= this.m_MinCircleRadius.i && magnitude <= this.m_MaxCircleRadius.i;
	}

	// Token: 0x0601707E RID: 94334 RVA: 0x00710BA5 File Offset: 0x0070EFA5
	public bool isUseDefault()
	{
		return false;
	}

	// Token: 0x04010956 RID: 67926
	public BeActor m_Owner;

	// Token: 0x04010957 RID: 67927
	public VInt2 m_OwnerPosXY;

	// Token: 0x04010958 RID: 67928
	public VInt m_MinCircleRadius;

	// Token: 0x04010959 RID: 67929
	public VInt m_MaxCircleRadius;

	// Token: 0x0401095A RID: 67930
	public static VInt LargeMaxCirleRadius = VInt.NewVInt(999999, GlobalLogic.VALUE_1000);
}
