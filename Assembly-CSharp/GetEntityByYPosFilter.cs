using System;

// Token: 0x02004196 RID: 16790
public class GetEntityByYPosFilter : IEntityFilter
{
	// Token: 0x06017084 RID: 94340 RVA: 0x00710C3A File Offset: 0x0070F03A
	public void SetData(int min, int max)
	{
		this.m_MinY = min;
		this.m_MaxY = max;
	}

	// Token: 0x06017085 RID: 94341 RVA: 0x00710C4C File Offset: 0x0070F04C
	public bool isFit(BeEntity target)
	{
		BeActor beActor = target as BeActor;
		if (beActor == null || beActor.IsDead() || beActor.IsSkillMonster() || !beActor.stateController.CanBeTargeted())
		{
			return false;
		}
		VInt3 position = beActor.GetPosition();
		return position.y >= this.m_MinY && position.y <= this.m_MaxY;
	}

	// Token: 0x06017086 RID: 94342 RVA: 0x00710CBC File Offset: 0x0070F0BC
	public bool isUseDefault()
	{
		return true;
	}

	// Token: 0x0401095C RID: 67932
	private int m_MinY;

	// Token: 0x0401095D RID: 67933
	private int m_MaxY;
}
