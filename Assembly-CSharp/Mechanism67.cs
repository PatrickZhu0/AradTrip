using System;
using System.Collections.Generic;

// Token: 0x02004403 RID: 17411
public class Mechanism67 : BeMechanism
{
	// Token: 0x060182D3 RID: 99027 RVA: 0x00785D7D File Offset: 0x0078417D
	public Mechanism67(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060182D4 RID: 99028 RVA: 0x00785D88 File Offset: 0x00784188
	public override void OnInit()
	{
		this.percent = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_100);
		this.summonID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		VInt vint = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true), GlobalLogic.VALUE_1000);
		this.points = new List<VInt3>();
		for (int i = 0; i < this.data.ValueC.Count; i++)
		{
			VInt vint2 = VInt.NewVInt(this.data.ValueC[i].fixInitValue, GlobalLogic.VALUE_1000);
			VInt vint3 = VInt.NewVInt(this.data.ValueC[i].fixLevelGrow, GlobalLogic.VALUE_1000);
			this.points.Add(new VInt3(vint2.i, vint3.i, vint.i));
		}
		this.faces = new List<int>();
		for (int j = 0; j < this.data.ValueD.Count; j++)
		{
			this.faces.Add(TableManager.GetValueFromUnionCell(this.data.ValueD[j], this.level, true));
		}
	}

	// Token: 0x060182D5 RID: 99029 RVA: 0x00785F0D File Offset: 0x0078430D
	public override void OnStart()
	{
		if (base.owner != null)
		{
			this.handler = base.owner.RegisterEvent(BeEventType.onHPChange, delegate(object[] args)
			{
				if (!base.owner.IsDead())
				{
					VFactor hprate = base.owner.GetEntityData().GetHPRate();
					if (hprate < this.percent)
					{
						this.DoSummon();
						this.RemoveHandler();
					}
				}
			});
		}
	}

	// Token: 0x060182D6 RID: 99030 RVA: 0x00785F3C File Offset: 0x0078433C
	private void DoSummon()
	{
		for (int i = 0; i < this.points.Count; i++)
		{
			int num = base.owner.GetEntityData().level;
			int monsterID = this.summonID + num * GlobalLogic.VALUE_100;
			BeUtility.AdjustMonsterDifficulty(ref base.owner.GetEntityData().monsterID, ref monsterID);
			BeActor beActor = base.owner.CurrentBeScene.SummonMonster(monsterID, this.points[i], base.owner.GetCamp(), base.owner, false, base.owner.GetEntityData().GetLevel(), true, 0, false, false);
			if (beActor != null)
			{
				if (this.faces[i] == 0)
				{
					beActor.SetFace(base.owner.GetFace(), false, false);
				}
				else if (this.faces[i] == 1)
				{
					List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
					int num2 = -1;
					for (int j = 0; j < allPlayers.Count; j++)
					{
						BeActor playerActor = allPlayers[j].playerActor;
						if (playerActor != null && !playerActor.IsDead())
						{
							num2 = j;
							break;
						}
					}
					if (num2 >= 0 && num2 < allPlayers.Count)
					{
						beActor.SetFace(allPlayers[num2].playerActor.GetPosition().x < beActor.GetPosition().x, false, false);
					}
				}
				else if (this.faces[i] == 2)
				{
					beActor.SetFace(true, false, false);
				}
				else if (this.faces[i] == 3)
				{
					beActor.SetFace(false, false, false);
				}
			}
		}
	}

	// Token: 0x060182D7 RID: 99031 RVA: 0x00786113 File Offset: 0x00784513
	private void RemoveHandler()
	{
		if (this.handler != null)
		{
			this.handler.Remove();
			this.handler = null;
		}
	}

	// Token: 0x060182D8 RID: 99032 RVA: 0x00786132 File Offset: 0x00784532
	public override void OnFinish()
	{
		this.RemoveHandler();
	}

	// Token: 0x0401171F RID: 71455
	private VFactor percent;

	// Token: 0x04011720 RID: 71456
	private int summonID;

	// Token: 0x04011721 RID: 71457
	private List<VInt3> points;

	// Token: 0x04011722 RID: 71458
	private List<int> faces;

	// Token: 0x04011723 RID: 71459
	private BeEventHandle handler;
}
