using System;
using System.Collections.Generic;

// Token: 0x0200441B RID: 17435
public class Mechanism9 : BeMechanism
{
	// Token: 0x0601836E RID: 99182 RVA: 0x0078A515 File Offset: 0x00788915
	public Mechanism9(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601836F RID: 99183 RVA: 0x0078A534 File Offset: 0x00788934
	public override void OnInit()
	{
		int diffID = base.owner.CurrentBeBattle.dungeonManager.GetDungeonDataManager().id.diffID;
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			int num = this.data.ValueA[i].fixInitValue;
			int fixLevelGrow = this.data.ValueA[i].fixLevelGrow;
			if (!this.swallowList.ContainsKey(num))
			{
				this.swallowList.Add(num, fixLevelGrow);
			}
			num += diffID;
			if (!this.swallowList.ContainsKey(num))
			{
				this.swallowList.Add(num, fixLevelGrow);
			}
		}
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		if (valueFromUnionCell >= 1)
		{
			this.ownerDead = true;
		}
		valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		if (valueFromUnionCell > 1)
		{
			this.swallowMaxNum = valueFromUnionCell;
		}
		if (this.data.ValueD.Count > 0)
		{
			this.buffDelay = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		}
		this.immediatelyRemove = (TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true) != 0);
	}

	// Token: 0x06018370 RID: 99184 RVA: 0x0078A6CC File Offset: 0x00788ACC
	public override void OnStart()
	{
		if (base.owner != null)
		{
			List<BeEntity> hurtEntityList = base.owner.GetHurtEntityList();
			int num = 0;
			for (int i = 0; i < hurtEntityList.Count; i++)
			{
				BeEntity beEntity = hurtEntityList[i];
				BeActor monster = beEntity as BeActor;
				if (monster != null && !monster.IsDead() && this.CanSwallow(monster.GetEntityData().monsterID) && this.swallowList.ContainsKey(monster.GetEntityData().monsterID))
				{
					num++;
					base.owner.delayCaller.DelayCall(this.buffDelay, delegate
					{
						int buffID = this.swallowList[monster.GetEntityData().monsterID];
						this.owner.buffController.TryAddBuff(buffID, 1, 1);
					}, 0, 0, false);
					if (!this.immediatelyRemove)
					{
						monster.delayCaller.DelayCall(200, delegate
						{
							monster.DoDead(false);
						}, 0, 0, false);
					}
					else
					{
						monster.DoDead(false);
					}
					if (num >= this.swallowMaxNum)
					{
						break;
					}
				}
			}
			if (num > 0 && this.ownerDead)
			{
				base.owner.delayCaller.DelayCall(200, delegate
				{
					base.owner.DoDead(false);
				}, 0, 0, false);
			}
		}
	}

	// Token: 0x06018371 RID: 99185 RVA: 0x0078A838 File Offset: 0x00788C38
	public bool CanSwallow(int mid)
	{
		foreach (KeyValuePair<int, int> keyValuePair in this.swallowList)
		{
			int key = keyValuePair.Key;
			if (BeUtility.IsMonsterIDEqual(key, mid))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x040117A9 RID: 71593
	private Dictionary<int, int> swallowList = new Dictionary<int, int>();

	// Token: 0x040117AA RID: 71594
	private bool ownerDead;

	// Token: 0x040117AB RID: 71595
	private int swallowMaxNum = 1;

	// Token: 0x040117AC RID: 71596
	private int buffDelay;

	// Token: 0x040117AD RID: 71597
	private bool immediatelyRemove;
}
