using System;
using System.Collections.Generic;

// Token: 0x020042A5 RID: 17061
public class Mechanism1100 : BeMechanism
{
	// Token: 0x060179AC RID: 96684 RVA: 0x007457BB File Offset: 0x00743BBB
	public Mechanism1100(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060179AD RID: 96685 RVA: 0x007457E8 File Offset: 0x00743BE8
	public override void OnInit()
	{
		this.mMonsterTableData.Clear();
		int num = Math.Min(this.data.ValueA.Length, this.data.ValueB.Length);
		for (int i = 0; i < num; i++)
		{
			Mechanism1100.MonsterData item = default(Mechanism1100.MonsterData);
			item.summonId = this.data.ValueA[i].fixInitValue;
			item.level = this.data.ValueA[i].fixLevelGrow;
			item.x = this.data.ValueB[i].fixInitValue;
			item.y = this.data.ValueB[i].fixLevelGrow;
			if (this.data.ValueF.Count > i)
			{
				item.face = TableManager.GetValueFromUnionCell(this.data.ValueF[i], this.level, true);
			}
			this.mMonsterTableData.Add(item);
		}
		this.mMonsterEventHandle = new BeEventHandle[num];
		this.mNextSumMechanismId = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.mIgnoreMonsterId.Clear();
		for (int j = 0; j < this.data.ValueD.Count; j++)
		{
			this.mIgnoreMonsterId.Add(TableManager.GetValueFromUnionCell(this.data.ValueD[j], this.level, true));
		}
		this.mSummonInterval = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
	}

	// Token: 0x060179AE RID: 96686 RVA: 0x007459B4 File Offset: 0x00743DB4
	public override void OnStart()
	{
		if (base.owner != null && base.owner.CurrentBeScene != null)
		{
			for (int i = 0; i < this.mMonsterTableData.Count; i++)
			{
				BeActor beActor = base.owner.CurrentBeScene.SummonMonster(this.mMonsterTableData[i].summonId + this.mMonsterTableData[i].level * 100, new VInt3(this.mMonsterTableData[i].x, this.mMonsterTableData[i].y, 0), base.owner.GetCamp(), null, false, 0, true, 0, false, false);
				if (beActor != null)
				{
					if (this.mMonsterTableData[i].face == 1)
					{
						beActor.SetFace(false, false, false);
					}
					else if (this.mMonsterTableData[i].face == 2)
					{
						beActor.SetFace(true, false, false);
					}
					if (!this.mIgnoreMonsterId.Contains(this.mMonsterTableData[i].summonId) && this.mExistSummonNum < this.mMonsterEventHandle.Length)
					{
						this.mMonsterEventHandle[this.mExistSummonNum] = beActor.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this.OnMonsterDead));
						this.mExistSummonNum++;
					}
				}
			}
		}
	}

	// Token: 0x060179AF RID: 96687 RVA: 0x00745B36 File Offset: 0x00743F36
	public override void OnUpdate(int deltaTime)
	{
		this.mTimer += deltaTime;
		if (this.mTimer >= this.mSummonInterval)
		{
			this.DoNextSummon();
		}
	}

	// Token: 0x060179B0 RID: 96688 RVA: 0x00745B5D File Offset: 0x00743F5D
	public override void OnFinish()
	{
		this.ClearEventHandle();
	}

	// Token: 0x060179B1 RID: 96689 RVA: 0x00745B68 File Offset: 0x00743F68
	private void DoNextSummon()
	{
		Mechanism1101 mechanism = base.owner.GetMechanism(this.mNextSumMechanismId) as Mechanism1101;
		if (mechanism != null)
		{
			mechanism.TryAddOnceMechanism();
		}
		base.owner.RemoveMechanism(this);
	}

	// Token: 0x060179B2 RID: 96690 RVA: 0x00745BA4 File Offset: 0x00743FA4
	private void ClearEventHandle()
	{
		for (int i = 0; i < this.mMonsterEventHandle.Length; i++)
		{
			if (this.mMonsterEventHandle[i] != null)
			{
				this.mMonsterEventHandle[i].Remove();
				this.mMonsterEventHandle[i] = null;
			}
		}
	}

	// Token: 0x060179B3 RID: 96691 RVA: 0x00745BED File Offset: 0x00743FED
	private void OnMonsterDead(object[] args)
	{
		this.mExistSummonNum--;
		if (this.mExistSummonNum <= 0)
		{
			this.DoNextSummon();
		}
	}

	// Token: 0x04010F6C RID: 69484
	private List<Mechanism1100.MonsterData> mMonsterTableData = new List<Mechanism1100.MonsterData>();

	// Token: 0x04010F6D RID: 69485
	private List<int> mIgnoreMonsterId = new List<int>();

	// Token: 0x04010F6E RID: 69486
	private int mSummonInterval = 10000;

	// Token: 0x04010F6F RID: 69487
	private int mTimer;

	// Token: 0x04010F70 RID: 69488
	private BeEventHandle[] mMonsterEventHandle;

	// Token: 0x04010F71 RID: 69489
	private int mExistSummonNum;

	// Token: 0x04010F72 RID: 69490
	private int mNextSumMechanismId;

	// Token: 0x04010F73 RID: 69491
	private BeEventHandle onMonsterDeadHandle;

	// Token: 0x020042A6 RID: 17062
	private struct MonsterData
	{
		// Token: 0x04010F74 RID: 69492
		public int summonId;

		// Token: 0x04010F75 RID: 69493
		public int level;

		// Token: 0x04010F76 RID: 69494
		public int x;

		// Token: 0x04010F77 RID: 69495
		public int y;

		// Token: 0x04010F78 RID: 69496
		public int face;
	}
}
