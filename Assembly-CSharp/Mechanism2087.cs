using System;
using System.Collections.Generic;

// Token: 0x02004390 RID: 17296
public class Mechanism2087 : BeMechanism
{
	// Token: 0x06017FB5 RID: 98229 RVA: 0x0076E134 File Offset: 0x0076C534
	public Mechanism2087(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017FB6 RID: 98230 RVA: 0x0076E1D0 File Offset: 0x0076C5D0
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.m_entityIDSets.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], 1, true));
			this.m_entityOffsetSets.Add(VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[i], 2, true), GlobalLogic.VALUE_1000));
			this.m_delayDamageTimeSets.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
			this.m_delayHurtTimeSets.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true));
		}
		for (int j = 0; j < this.data.ValueD.Count; j++)
		{
			this.m_entityIDSetsInMulti.Add(TableManager.GetValueFromUnionCell(this.data.ValueD[j], 1, true));
			this.m_entityOffsetSetsInMulti.Add(VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueD[j], 2, true), GlobalLogic.VALUE_1000));
			this.m_delayDamageTimeSetsInMulti.Add(TableManager.GetValueFromUnionCell(this.data.ValueE[j], this.level, true));
			this.m_delayHurtTimeSetsInMulti.Add(TableManager.GetValueFromUnionCell(this.data.ValueF[j], this.level, true));
		}
		this.m_hurtId = TableManager.GetValueFromUnionCell(this.data.ValueG[0], this.level, true);
		this.m_lastHurtId = TableManager.GetValueFromUnionCell(this.data.ValueG[1], this.level, true);
	}

	// Token: 0x06017FB7 RID: 98231 RVA: 0x0076E3C4 File Offset: 0x0076C7C4
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (this.m_entityTargets.Count <= 0 && this.m_hurtAttackTargets.Count <= 0)
		{
			return;
		}
		this.m_durTime += deltaTime;
		if (this.m_entityTargets.Count > 0)
		{
			Mechanism2087.EntityTargetInfo entityTargetInfo = this.m_entityTargets.Peek();
			if (entityTargetInfo.delayCreateTime <= this.m_durTime)
			{
				VInt3 position = entityTargetInfo.target.GetPosition();
				position.x += entityTargetInfo.offset.i;
				BeEntity beEntity = base.owner.AddEntity(entityTargetInfo.entityId, position, 1, 0);
				if (beEntity != null)
				{
					beEntity.SetFace(true, false, false);
				}
				this.m_hurtAttackTargets.Enqueue(new Mechanism2087.HurtTargetInfo
				{
					target = entityTargetInfo.target,
					delayHurtTime = entityTargetInfo.delayHurtTime,
					timeStamp = this.m_durTime,
					hurtid = entityTargetInfo.hurtid
				});
				this.m_entityTargets.Dequeue();
			}
		}
		if (this.m_hurtAttackTargets.Count > 0)
		{
			Mechanism2087.HurtTargetInfo hurtTargetInfo = this.m_hurtAttackTargets.Peek();
			int num = this.m_durTime - hurtTargetInfo.timeStamp;
			if (hurtTargetInfo.delayHurtTime <= num)
			{
				if (hurtTargetInfo.target != null && !hurtTargetInfo.target.IsDead())
				{
					base.owner._onHurtEntity(hurtTargetInfo.target, hurtTargetInfo.target.GetPosition(), hurtTargetInfo.hurtid);
				}
				this.m_hurtAttackTargets.Dequeue();
			}
		}
	}

	// Token: 0x06017FB8 RID: 98232 RVA: 0x0076E55C File Offset: 0x0076C95C
	public override void OnStart()
	{
		base.OnStart();
		this.m_entityTargets.Clear();
		this.m_hurtAttackTargets.Clear();
		this.m_durTime = 0;
		if (base.owner == null || base.owner.CurrentBeScene == null)
		{
			return;
		}
		base.owner.CurrentBeScene.FindAllMonsters(this.m_monsterList, base.owner, false, null);
		if (this.m_monsterList.Count == 0)
		{
			return;
		}
		if (this.m_monsterList.Count > 1)
		{
			if (this.m_monsterList.Count == 2)
			{
				BeActor target = this.m_monsterList[0];
				int num = this.m_entityIDSetsInMulti.Count / 2;
				int i;
				for (i = 0; i < num; i++)
				{
					this.m_entityTargets.Enqueue(new Mechanism2087.EntityTargetInfo
					{
						target = target,
						entityId = this.m_entityIDSetsInMulti[i],
						offset = this.m_entityOffsetSetsInMulti[i],
						delayCreateTime = this.m_delayDamageTimeSetsInMulti[i],
						hurtid = this.m_hurtId,
						delayHurtTime = this.m_delayHurtTimeSetsInMulti[i]
					});
				}
				BeActor target2 = this.m_monsterList[1];
				while (i < this.m_entityIDSetsInMulti.Count)
				{
					this.m_entityTargets.Enqueue(new Mechanism2087.EntityTargetInfo
					{
						target = target2,
						entityId = this.m_entityIDSetsInMulti[i],
						offset = this.m_entityOffsetSetsInMulti[i],
						delayCreateTime = this.m_delayDamageTimeSetsInMulti[i],
						hurtid = this.m_hurtId,
						delayHurtTime = this.m_delayHurtTimeSetsInMulti[i]
					});
					i++;
				}
			}
			else
			{
				this.m_monsterSelectedIds.Clear();
				int count = this.m_monsterList.Count;
				for (int j = 0; j < this.m_entityIDSetsInMulti.Count; j++)
				{
					if (this.m_monsterList.Count <= 0)
					{
						Logger.LogErrorFormat("mechanism id {0} mutliCount {1} targetCount {2}", new object[]
						{
							this.mechianismID,
							this.m_entityIDSetsInMulti.Count,
							count
						});
						return;
					}
					int index = base.FrameRandom.InRange(0, this.m_monsterList.Count);
					BeActor beActor = this.m_monsterList[index];
					int pid = beActor.GetPID();
					if (this.m_monsterSelectedIds.Contains(pid))
					{
						this.m_monsterList.RemoveAt(index);
					}
					else
					{
						this.m_monsterSelectedIds.Add(pid);
					}
					this.m_entityTargets.Enqueue(new Mechanism2087.EntityTargetInfo
					{
						target = beActor,
						entityId = this.m_entityIDSetsInMulti[j],
						delayCreateTime = this.m_delayDamageTimeSetsInMulti[j],
						offset = this.m_entityOffsetSetsInMulti[j],
						hurtid = this.m_hurtId,
						delayHurtTime = this.m_delayHurtTimeSetsInMulti[j]
					});
				}
			}
		}
		else
		{
			BeActor target3 = this.m_monsterList[0];
			for (int k = 0; k < this.m_entityIDSets.Count; k++)
			{
				this.m_entityTargets.Enqueue(new Mechanism2087.EntityTargetInfo
				{
					target = target3,
					entityId = this.m_entityIDSets[k],
					offset = this.m_entityOffsetSets[k],
					hurtid = ((k != this.m_entityIDSets.Count - 1) ? this.m_hurtId : this.m_lastHurtId),
					delayCreateTime = this.m_delayDamageTimeSets[k],
					delayHurtTime = this.m_delayHurtTimeSets[k]
				});
			}
		}
	}

	// Token: 0x0401143D RID: 70717
	private List<int> m_entityIDSets = new List<int>();

	// Token: 0x0401143E RID: 70718
	private List<VInt> m_entityOffsetSets = new List<VInt>();

	// Token: 0x0401143F RID: 70719
	private List<int> m_delayDamageTimeSets = new List<int>();

	// Token: 0x04011440 RID: 70720
	private List<int> m_delayHurtTimeSets = new List<int>();

	// Token: 0x04011441 RID: 70721
	private List<int> m_entityIDSetsInMulti = new List<int>();

	// Token: 0x04011442 RID: 70722
	private List<VInt> m_entityOffsetSetsInMulti = new List<VInt>();

	// Token: 0x04011443 RID: 70723
	private List<int> m_delayHurtTimeSetsInMulti = new List<int>();

	// Token: 0x04011444 RID: 70724
	private List<int> m_delayDamageTimeSetsInMulti = new List<int>();

	// Token: 0x04011445 RID: 70725
	private List<BeActor> m_monsterList = new List<BeActor>();

	// Token: 0x04011446 RID: 70726
	private List<int> m_monsterSelectedIds = new List<int>();

	// Token: 0x04011447 RID: 70727
	private int m_durTime;

	// Token: 0x04011448 RID: 70728
	private Queue<Mechanism2087.EntityTargetInfo> m_entityTargets = new Queue<Mechanism2087.EntityTargetInfo>();

	// Token: 0x04011449 RID: 70729
	private Queue<Mechanism2087.HurtTargetInfo> m_hurtAttackTargets = new Queue<Mechanism2087.HurtTargetInfo>();

	// Token: 0x0401144A RID: 70730
	private int m_hurtId;

	// Token: 0x0401144B RID: 70731
	private int m_lastHurtId;

	// Token: 0x02004391 RID: 17297
	private class EntityTargetInfo
	{
		// Token: 0x0401144C RID: 70732
		public BeActor target;

		// Token: 0x0401144D RID: 70733
		public int entityId;

		// Token: 0x0401144E RID: 70734
		public VInt offset;

		// Token: 0x0401144F RID: 70735
		public int hurtid;

		// Token: 0x04011450 RID: 70736
		public int delayCreateTime;

		// Token: 0x04011451 RID: 70737
		public int delayHurtTime;
	}

	// Token: 0x02004392 RID: 17298
	public class HurtTargetInfo
	{
		// Token: 0x04011452 RID: 70738
		public int timeStamp;

		// Token: 0x04011453 RID: 70739
		public int delayHurtTime;

		// Token: 0x04011454 RID: 70740
		public BeActor target;

		// Token: 0x04011455 RID: 70741
		public int hurtid;
	}
}
