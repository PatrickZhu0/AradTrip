using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020043E3 RID: 17379
public class Mechanism37 : BeMechanism
{
	// Token: 0x060181DB RID: 98779 RVA: 0x0077F4A4 File Offset: 0x0077D8A4
	public Mechanism37(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060181DC RID: 98780 RVA: 0x0077F4F4 File Offset: 0x0077D8F4
	public override void OnInit()
	{
		this.m_Radius = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), 1000);
		this.m_HurtID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.m_Hurtm_CheckInterval = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x060181DD RID: 98781 RVA: 0x0077F583 File Offset: 0x0077D983
	public override void OnUpdate(int deltaTime)
	{
		this.UpdateCheckRange(deltaTime);
		this.UpdateCheckHurt(deltaTime);
	}

	// Token: 0x060181DE RID: 98782 RVA: 0x0077F594 File Offset: 0x0077D994
	protected void UpdateCheckHurt(int deltaTime)
	{
		this.m_TimeAcc2 += deltaTime;
		if (this.m_TimeAcc2 > this.m_Hurtm_CheckInterval)
		{
			this.m_TimeAcc2 -= this.m_Hurtm_CheckInterval;
			for (int i = 0; i < this.inRangers.Count; i++)
			{
				BeActor beActor = this.inRangers[i];
				if (!beActor.IsDead() && beActor.GetCamp() != base.owner.GetCamp() && beActor.GetLifeState() == 2)
				{
					base.owner.DoAttackTo(beActor, this.m_HurtID, false, false);
				}
			}
		}
	}

	// Token: 0x060181DF RID: 98783 RVA: 0x0077F63E File Offset: 0x0077DA3E
	protected void UpdateCheckRange(int deltaTime)
	{
		this.m_TimeAcc += deltaTime;
		if (this.m_TimeAcc > this.m_CheckInterval)
		{
			this.m_TimeAcc -= this.m_CheckInterval;
			this.CheckRange();
		}
	}

	// Token: 0x060181E0 RID: 98784 RVA: 0x0077F678 File Offset: 0x0077DA78
	protected void CheckRange()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		VInt3 position = base.owner.GetPosition();
		position.z = 0;
		base.owner.CurrentBeScene.FindActorInRange(list, position, this.m_Radius, -1, 0);
		for (int i = 0; i < this.inRangers.Count; i++)
		{
			if (!list.Contains(this.inRangers[i]))
			{
				this.inRangers.RemoveAt(i);
				i--;
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			if (!this.inRangers.Contains(list[j]))
			{
				this.inRangers.Add(list[j]);
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x060181E1 RID: 98785 RVA: 0x0077F743 File Offset: 0x0077DB43
	public override void OnFinish()
	{
		this.inRangers.Clear();
	}

	// Token: 0x04011639 RID: 71225
	protected VInt m_Radius = VInt.one.i * 2;

	// Token: 0x0401163A RID: 71226
	protected int m_HurtID;

	// Token: 0x0401163B RID: 71227
	protected int m_TimeAcc;

	// Token: 0x0401163C RID: 71228
	protected int m_CheckInterval = 200;

	// Token: 0x0401163D RID: 71229
	protected int m_TimeAcc2;

	// Token: 0x0401163E RID: 71230
	protected int m_Hurtm_CheckInterval = 1000;

	// Token: 0x0401163F RID: 71231
	protected List<BeActor> inRangers = new List<BeActor>();
}
