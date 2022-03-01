using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020044BF RID: 17599
public class Skill3117 : BeSkill
{
	// Token: 0x060187BF RID: 100287 RVA: 0x007A4B1A File Offset: 0x007A2F1A
	public Skill3117(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060187C0 RID: 100288 RVA: 0x007A4B2F File Offset: 0x007A2F2F
	public override void OnCancel()
	{
		this.RemoveEntity();
	}

	// Token: 0x060187C1 RID: 100289 RVA: 0x007A4B37 File Offset: 0x007A2F37
	public override void OnFinish()
	{
		this.RemoveEntity();
	}

	// Token: 0x060187C2 RID: 100290 RVA: 0x007A4B40 File Offset: 0x007A2F40
	protected void RemoveEntity()
	{
		List<BeEntity> list = ListPool<BeEntity>.Get();
		base.owner.CurrentBeScene.GetEntitys2(list);
		if (list.Count > 0)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].m_iResID == this.m_EntityId && list[i].GetOwner() == base.owner && !list[i].IsDead())
				{
					list[i].OnRemove(false);
				}
			}
		}
		ListPool<BeEntity>.Release(list);
	}

	// Token: 0x04011AA8 RID: 72360
	protected int m_EntityId = 69044;
}
