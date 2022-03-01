using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004457 RID: 17495
public class Skill1315 : BeSkill
{
	// Token: 0x060184D9 RID: 99545 RVA: 0x007916BB File Offset: 0x0078FABB
	public Skill1315(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060184DA RID: 99546 RVA: 0x007916E6 File Offset: 0x0078FAE6
	public override void OnPostInit()
	{
	}

	// Token: 0x060184DB RID: 99547 RVA: 0x007916E8 File Offset: 0x0078FAE8
	public override void OnStart()
	{
		this.hasPassed = false;
		this.RemoveHandle();
		this.m_PassDoorHandle = base.owner.RegisterEvent(BeEventType.onStartPassDoor, delegate(object[] args)
		{
			this.ClearDeadHandle();
		});
		this.m_PassTowerHandle = base.owner.RegisterEvent(BeEventType.onDeadTowerEnterNextLayer, delegate(object[] args)
		{
			this.ClearDeadHandle();
		});
		base.owner.delayCaller.DelayCall(this.delayFindMonster, delegate
		{
			if (this.hasPassed)
			{
				return;
			}
			List<BeActor> list = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.FindActorById2(list, this.monterID, false);
			if (list.Count > 0)
			{
				BeActor actor = list[0];
				if (actor != null)
				{
					this.m_MonsterDeadHandle = actor.RegisterEvent(BeEventType.onDead, delegate(object[] args)
					{
						this.owner.AddEntity(this.entityID, actor.GetPosition(), 1, 0);
					});
				}
			}
			ListPool<BeActor>.Release(list);
		}, 0, 0, false);
	}

	// Token: 0x060184DC RID: 99548 RVA: 0x00791765 File Offset: 0x0078FB65
	protected void ClearDeadHandle()
	{
		this.hasPassed = true;
		if (this.m_MonsterDeadHandle != null)
		{
			this.m_MonsterDeadHandle.Remove();
			this.m_MonsterDeadHandle = null;
		}
	}

	// Token: 0x060184DD RID: 99549 RVA: 0x0079178C File Offset: 0x0078FB8C
	protected void RemoveHandle()
	{
		if (this.m_MonsterDeadHandle != null)
		{
			this.m_MonsterDeadHandle.Remove();
			this.m_MonsterDeadHandle = null;
		}
		if (this.m_PassDoorHandle != null)
		{
			this.m_PassDoorHandle.Remove();
			this.m_PassDoorHandle = null;
		}
		if (this.m_PassTowerHandle != null)
		{
			this.m_PassTowerHandle.Remove();
			this.m_PassTowerHandle = null;
		}
	}

	// Token: 0x0401189A RID: 71834
	protected BeEventHandle m_PassDoorHandle;

	// Token: 0x0401189B RID: 71835
	protected BeEventHandle m_PassTowerHandle;

	// Token: 0x0401189C RID: 71836
	protected BeEventHandle m_MonsterDeadHandle;

	// Token: 0x0401189D RID: 71837
	private int entityID = 60515;

	// Token: 0x0401189E RID: 71838
	private int monterID = 90000031;

	// Token: 0x0401189F RID: 71839
	private int delayFindMonster = 3000;

	// Token: 0x040118A0 RID: 71840
	private bool hasPassed;
}
