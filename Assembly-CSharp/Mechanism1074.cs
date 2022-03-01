using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004294 RID: 17044
public class Mechanism1074 : BeMechanism
{
	// Token: 0x0601794C RID: 96588 RVA: 0x0074297C File Offset: 0x00740D7C
	public Mechanism1074(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601794D RID: 96589 RVA: 0x007429C8 File Offset: 0x00740DC8
	public override void OnInit()
	{
		base.OnInit();
		this.deadMonsterIds.Clear();
		this.summonMonsterIds.Clear();
		if (this.data.ValueA.Count > 0)
		{
			for (int i = 0; i < this.data.ValueA.Count; i++)
			{
				this.deadMonsterIds.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
			}
		}
		if (this.data.ValueB.Count > 0)
		{
			for (int j = 0; j < this.data.ValueB.Count; j++)
			{
				this.summonMonsterIds.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true));
			}
		}
		if (this.data.ValueC.Count > 0)
		{
			for (int k = 0; k < this.data.ValueC.Count; k++)
			{
				this.buffIds.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[k], this.level, true));
			}
		}
		if (this.data.StringValueA.Count > 0)
		{
			this.effectPath = this.data.StringValueA[0];
		}
	}

	// Token: 0x0601794E RID: 96590 RVA: 0x00742B4C File Offset: 0x00740F4C
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner == null || base.owner.CurrentBeScene == null || base.owner.FrameRandom == null)
		{
			return;
		}
		this.searchResults.Clear();
		List<BeActor> list = ListPool<BeActor>.Get();
		for (int i = 0; i < this.deadMonsterIds.Count; i++)
		{
			base.owner.CurrentBeScene.FindActorById2(list, this.deadMonsterIds[i], true);
			if (list.Count > 0)
			{
				this.searchResults.AddRange(list);
			}
		}
		ListPool<BeActor>.Release(list);
		if (this.searchResults.Count <= 0)
		{
			return;
		}
		int index = base.owner.FrameRandom.InRange(0, this.searchResults.Count);
		BeActor beActor = this.searchResults[index];
		int j = 0;
		while (j < this.deadMonsterIds.Count)
		{
			if (beActor != null && beActor.GetEntityData() != null && beActor.GetEntityData().MonsterIDEqual(this.deadMonsterIds[j]))
			{
				int num = beActor.GetEntityData().level;
				VInt3 position = beActor.GetPosition();
				position.z = 0;
				if (j < 0 && j >= this.summonMonsterIds.Count)
				{
					Logger.LogErrorFormat("mechanism {0} summonMonsterIds {1} is out of range {2}", new object[]
					{
						this.mechianismID,
						j,
						this.deadMonsterIds[j]
					});
					return;
				}
				if (j < 0 && j >= this.buffIds.Count)
				{
					Logger.LogErrorFormat("mechanism {0} buffIds {1} is out of range {2}", new object[]
					{
						this.mechianismID,
						j,
						this.deadMonsterIds[j]
					});
					return;
				}
				if (!beActor.IsDead() && beActor.m_iEntityLifeState != 4)
				{
					beActor.SetAutoFight(false);
					if (beActor.buffController != null)
					{
						beActor.buffController.RemoveAllBuff();
						beActor.buffController.TryAddBuff(this.buffIds[j], -1, 1);
					}
					if (beActor.m_pkGeActor != null)
					{
						beActor.m_pkGeActor.HideActor(true);
					}
				}
				base.owner.CurrentBeScene.SummonMonster(this.summonMonsterIds[j] + num * 100, position, base.owner.GetCamp(), base.owner, false, 0, true, 0, false, false);
				if (!string.IsNullOrEmpty(this.effectPath) && base.owner.CurrentBeScene.currentGeScene != null)
				{
					base.owner.CurrentBeScene.currentGeScene.CreateEffect(this.effectPath, 0f, position.vec3, 1f, 1f, false, false);
				}
				return;
			}
			else
			{
				j++;
			}
		}
	}

	// Token: 0x04010F1A RID: 69402
	private List<int> deadMonsterIds = new List<int>();

	// Token: 0x04010F1B RID: 69403
	private List<int> summonMonsterIds = new List<int>();

	// Token: 0x04010F1C RID: 69404
	private List<int> buffIds = new List<int>();

	// Token: 0x04010F1D RID: 69405
	private List<BeActor> searchResults = new List<BeActor>();

	// Token: 0x04010F1E RID: 69406
	private string effectPath = string.Empty;
}
