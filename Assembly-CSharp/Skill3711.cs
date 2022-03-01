using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020044D1 RID: 17617
public class Skill3711 : BeSkill
{
	// Token: 0x06018850 RID: 100432 RVA: 0x007A777C File Offset: 0x007A5B7C
	public Skill3711(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018851 RID: 100433 RVA: 0x007A77A0 File Offset: 0x007A5BA0
	public override void OnInit()
	{
		base.OnInit();
		this.monsterIdArr[0] = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.monsterIdArr[1] = TableManager.GetValueFromUnionCell(this.skillData.ValueA[1], base.level, true);
	}

	// Token: 0x06018852 RID: 100434 RVA: 0x007A7800 File Offset: 0x007A5C00
	public override void OnStart()
	{
		base.OnStart();
		this.RemoveHandle();
		BeEventHandle item = base.owner.RegisterEvent(BeEventType.onStartPassDoor, delegate(object[] args)
		{
			this.SetMonsterDead();
		});
		this.handleList.Add(item);
		BeEventHandle item2 = base.owner.RegisterEvent(BeEventType.onDeadTowerEnterNextLayer, delegate(object[] args)
		{
			this.SetMonsterDead();
		});
		this.handleList.Add(item2);
	}

	// Token: 0x06018853 RID: 100435 RVA: 0x007A7864 File Offset: 0x007A5C64
	private void SetMonsterDead()
	{
		if (base.owner == null || base.owner.CurrentBeScene == null)
		{
			return;
		}
		int monsterID = (!BattleMain.IsModePvP(base.battleType)) ? this.monsterIdArr[0] : this.monsterIdArr[1];
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindActorById2(list, monsterID, false);
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				list[i].DoDead(false);
				list[i].m_pkGeActor.SetActorVisible(false);
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06018854 RID: 100436 RVA: 0x007A7910 File Offset: 0x007A5D10
	private void RemoveHandle()
	{
		for (int i = 0; i < this.handleList.Count; i++)
		{
			if (this.handleList[i] != null)
			{
				this.handleList[i].Remove();
				this.handleList[i] = null;
			}
		}
		this.handleList.Clear();
	}

	// Token: 0x04011B02 RID: 72450
	private int[] monsterIdArr = new int[2];

	// Token: 0x04011B03 RID: 72451
	private List<BeEventHandle> handleList = new List<BeEventHandle>();
}
