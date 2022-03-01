using System;
using System.Collections.Generic;

// Token: 0x020044FB RID: 17659
public class Skill6205 : BeSkill
{
	// Token: 0x06018931 RID: 100657 RVA: 0x007ACFCE File Offset: 0x007AB3CE
	public Skill6205(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018932 RID: 100658 RVA: 0x007ACFEF File Offset: 0x007AB3EF
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, delegate(object[] args)
		{
			BeProjectile beProjectile = args[0] as BeProjectile;
			if (beProjectile != null && base.owner.aiManager != null && Array.IndexOf<int>(this.entityID, beProjectile.m_iResID) != -1)
			{
				if (base.owner.aiManager.aiTarget != null)
				{
					beProjectile.SetPosition(base.owner.aiManager.aiTarget.GetPosition(), true, true);
				}
				else
				{
					BeActor beActor = this.FindMaxResentment();
					if (beActor != null)
					{
						beProjectile.SetPosition(beActor.GetPosition(), true, true);
					}
				}
			}
		});
	}

	// Token: 0x06018933 RID: 100659 RVA: 0x007AD018 File Offset: 0x007AB418
	private BeActor FindMaxResentment()
	{
		List<BeActor> list = new List<BeActor>();
		base.owner.CurrentBeScene.FindActorInRange(list, base.owner.GetPosition(), int.MaxValue, -1, 0);
		if (list.Count == 0)
		{
			return null;
		}
		base.owner.CurrentBeScene.SortResentmentList(list);
		return list[0];
	}

	// Token: 0x04011BAB RID: 72619
	private int[] entityID = new int[]
	{
		10442,
		10443,
		10444,
		10445,
		10446
	};
}
