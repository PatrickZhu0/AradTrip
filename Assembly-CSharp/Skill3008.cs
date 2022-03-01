using System;
using System.Collections.Generic;
using GameClient;
using GamePool;

// Token: 0x020044B3 RID: 17587
public class Skill3008 : BeSkill
{
	// Token: 0x06018764 RID: 100196 RVA: 0x007A20F8 File Offset: 0x007A04F8
	public Skill3008(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018765 RID: 100197 RVA: 0x007A28B4 File Offset: 0x007A0CB4
	public override void OnInit()
	{
		this.m_CloneIdArr[0] = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		this.m_CloneIdArr[1] = TableManager.GetValueFromUnionCell(this.skillData.ValueB[1], base.level, true);
		this.m_CloneRayIdArr[0] = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
		this.m_CloneRayIdArr[1] = TableManager.GetValueFromUnionCell(this.skillData.ValueC[1], base.level, true);
		this.m_BombEntityId = TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true);
		this.m_BuffId = TableManager.GetValueFromUnionCell(this.skillData.ValueE[0], base.level, true);
		this.m_RayCloneTime = TableManager.GetValueFromUnionCell(this.skillData.ValueF[0], base.level, true);
		this.m_RebornPosList.Clear();
		this.m_RebornPosList.Add(this.m_PosOffset1);
		this.m_RebornPosList.Add(this.m_PosOffset2);
		this.m_RebornPosList.Add(this.m_PosOffset3);
		this.m_RebornPosList.Add(this.m_PosOffset4);
		this.m_RebornPosList.Add(this.m_PosOffset5);
		this.m_RebornPosList.Add(this.m_PosOffset6);
		this.m_RebornPosList.Add(this.m_PosOffset7);
		this.m_RebornPosList.Add(this.m_PosOffset8);
		this.m_RebornPosList.Add(this.m_PosOffset9);
		this.m_RebornPosList.Add(this.m_PosOffset10);
		if (base.owner != null && base.owner.CurrentBeBattle != null && base.owner.CurrentBeBattle.PkRaceType == 8)
		{
			this.m_CloneNum = TableManager.GetValueFromUnionCell(this.skillData.ValueG[0], base.level, true);
		}
		else
		{
			this.m_CloneNum = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		}
	}

	// Token: 0x06018766 RID: 100198 RVA: 0x007A2AF0 File Offset: 0x007A0EF0
	public override void OnPostInit()
	{
		if (base.owner != null && base.owner.CurrentBeBattle != null && base.owner.CurrentBeBattle.PkRaceType == 8)
		{
			this.m_CloneNum = TableManager.GetValueFromUnionCell(this.skillData.ValueG[0], base.level, true);
		}
		else
		{
			this.m_CloneNum = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		}
		if (base.owner.HasSkill(this.m_RaySkillId) && !BattleMain.IsModePvP(base.battleType) && !base.owner.IsMonster())
		{
			this.pressMode = SkillPressMode.TWO_PRESS_OUT;
		}
	}

	// Token: 0x06018767 RID: 100199 RVA: 0x007A2BB6 File Offset: 0x007A0FB6
	public override void OnStart()
	{
		this.m_CreateCloneFlag = true;
		base.owner.delayCaller.DelayCall(this.m_RayCloneTime, delegate
		{
			List<BeActor> list = new List<BeActor>();
			base.owner.CurrentBeScene.FindActorById(list, this.m_CloneMonsterId);
			for (int i = 0; i < list.Count; i++)
			{
				list[i].DoDead(false);
			}
		}, 0, 0, false);
	}

	// Token: 0x06018768 RID: 100200 RVA: 0x007A2BE8 File Offset: 0x007A0FE8
	public override void OnUpdate(int iDeltime)
	{
		if (base.owner.buffController.HasBuffByID(this.m_BuffId) != null && this.m_CreateCloneFlag)
		{
			this.m_CreateCloneFlag = false;
			base.owner.buffController.RemoveBuff(this.m_BuffId, 0, 0);
			this.CreateCloneMonster();
		}
	}

	// Token: 0x06018769 RID: 100201 RVA: 0x007A2C40 File Offset: 0x007A1040
	protected void CreateCloneMonster()
	{
		int num;
		if (!base.owner.HasSkill(this.m_RaySkillId) && !base.owner.IsMonster())
		{
			num = ((!BattleMain.IsModePvP(base.battleType)) ? this.m_CloneIdArr[0] : this.m_CloneIdArr[1]);
		}
		else
		{
			num = ((!BattleMain.IsModePvP(base.battleType)) ? this.m_CloneRayIdArr[0] : this.m_CloneRayIdArr[1]);
		}
		List<BeActor> list = new List<BeActor>();
		if (!BattleMain.IsModePvP(base.battleType))
		{
			this.m_CurrentRayCloneNum = this.m_CloneNum;
			this.RemoveHandle();
		}
		for (int i = 0; i < this.m_CloneNum; i++)
		{
			BeActor beActor = base.owner.CurrentBeScene.CreateMonster(num + base.level * 100, true, null, base.level, base.owner.GetCamp(), base.owner, false);
			Buff12 buff = beActor.buffController.HasBuffByID(12) as Buff12;
			if (buff != null)
			{
				buff.showDisappearEffect = false;
			}
			beActor.SetOwner(base.owner);
			beActor.SetRestrainPosition(false);
			beActor.stateController.SetAbilityEnable(BeAbilityType.BLOCK, false);
			VInt3 position = base.owner.GetPosition();
			VInt3[] array = this.m_RebornPosList[this.m_CloneNum - 1];
			int num2 = (!base.owner.GetFace()) ? array[i].x : (-array[i].x);
			beActor.SetPosition(new VInt3(position.x + num2, position.y + array[i].y, position.z + array[i].z), false, true, false);
			beActor.SetFace(base.owner.GetFace(), true, true);
			list.Add(beActor);
			if (!BattleMain.IsModePvP(base.battleType))
			{
				BeEventHandle beEventHandle = beActor.RegisterEvent(BeEventType.onDead, delegate(object[] args)
				{
					this.RayCloneDead();
				});
			}
		}
	}

	// Token: 0x0601876A RID: 100202 RVA: 0x007A2E58 File Offset: 0x007A1258
	protected void RemoveHandle()
	{
		if (this.m_RayCloneDeadList.Count > 0)
		{
			for (int i = 0; i < this.m_RayCloneDeadList.Count; i++)
			{
				if (this.m_RayCloneDeadList[i] != null)
				{
					this.m_RayCloneDeadList[i].Remove();
				}
			}
		}
		this.m_RayCloneDeadList.Clear();
	}

	// Token: 0x0601876B RID: 100203 RVA: 0x007A2EBF File Offset: 0x007A12BF
	protected void RayCloneDead()
	{
		this.m_CurrentRayCloneNum--;
		if (this.m_CurrentRayCloneNum <= 0)
		{
			if (this.FunctionIsOpen())
			{
				base.Cancel();
			}
			else
			{
				base.ResetButtonEffect();
			}
		}
	}

	// Token: 0x0601876C RID: 100204 RVA: 0x007A2EF8 File Offset: 0x007A12F8
	public override void OnClickAgain()
	{
		if (base.owner.IsMonster())
		{
			return;
		}
		if (BattleMain.IsModePvP(base.battleType))
		{
			return;
		}
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindActorById2(list, this.m_CloneRayIdArr[0], false);
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				BeActor beActor = list[i];
				if (beActor.GetOwner() != null && beActor.GetOwner() == base.owner)
				{
					beActor.DoDead(false);
					beActor.m_pkGeActor.SetActorVisible(false);
					base.owner.AddEntity(this.m_BombEntityId, beActor.GetPosition(), 1, 0);
					if (this.FunctionIsOpen())
					{
						base.Cancel();
					}
				}
			}
			if (!this.FunctionIsOpen())
			{
				base.ResetButtonEffect();
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x0601876D RID: 100205 RVA: 0x007A2FDE File Offset: 0x007A13DE
	private bool FunctionIsOpen()
	{
		return base.owner.CurrentBeBattle != null && base.owner.CurrentBeBattle.FunctionIsOpen(BattleFlagType.NianQiBug);
	}

	// Token: 0x04011A6B RID: 72299
	protected int m_CloneNum = 2;

	// Token: 0x04011A6C RID: 72300
	protected int[] m_CloneIdArr = new int[2];

	// Token: 0x04011A6D RID: 72301
	protected int[] m_CloneRayIdArr = new int[2];

	// Token: 0x04011A6E RID: 72302
	protected int m_BombEntityId;

	// Token: 0x04011A6F RID: 72303
	protected int m_BuffId;

	// Token: 0x04011A70 RID: 72304
	protected int m_RayCloneTime = 5000;

	// Token: 0x04011A71 RID: 72305
	protected int m_RaySkillId = 3109;

	// Token: 0x04011A72 RID: 72306
	protected VInt3[] m_PosOffset1 = new VInt3[]
	{
		new VInt3(1.1f, 0f, 0f)
	};

	// Token: 0x04011A73 RID: 72307
	protected VInt3[] m_PosOffset2 = new VInt3[]
	{
		new VInt3(1.25f, 0f, 0f),
		new VInt3(-1.25f, 0f, 0f)
	};

	// Token: 0x04011A74 RID: 72308
	protected VInt3[] m_PosOffset3 = new VInt3[]
	{
		new VInt3(1.25f, 0f, 0f),
		new VInt3(-0.75f, 1.1f, 0f),
		new VInt3(-0.75f, -1.1f, 0f)
	};

	// Token: 0x04011A75 RID: 72309
	protected VInt3[] m_PosOffset4 = new VInt3[]
	{
		new VInt3(1.35f, 0f, 0f),
		new VInt3(-1.35f, 0f, 0f),
		new VInt3(0f, 1.1f, 0f),
		new VInt3(0f, -1.1f, 0f)
	};

	// Token: 0x04011A76 RID: 72310
	protected VInt3[] m_PosOffset5 = new VInt3[]
	{
		new VInt3(1.4f, 0f, 0f),
		new VInt3(-1f, -0.65f, 0f),
		new VInt3(-1f, 0.65f, 0f),
		new VInt3(0.45f, -1.3f, 0f),
		new VInt3(0.45f, 1.3f, 0f)
	};

	// Token: 0x04011A77 RID: 72311
	protected VInt3[] m_PosOffset6 = new VInt3[]
	{
		new VInt3(1.5f, 0f, 0f),
		new VInt3(-1.5f, 0f, 0f),
		new VInt3(0.65f, 1.1f, 0f),
		new VInt3(0.65f, -1.1f, 0f),
		new VInt3(-0.65f, 1.1f, 0f),
		new VInt3(-0.65f, -1.1f, 0f)
	};

	// Token: 0x04011A78 RID: 72312
	protected VInt3[] m_PosOffset7 = new VInt3[]
	{
		new VInt3(1.7f, 0f, 0f),
		new VInt3(-0.3f, 1.4f, 0f),
		new VInt3(-0.3f, -1.4f, 0f),
		new VInt3(0.9f, -0.8f, 0f),
		new VInt3(0.9f, 0.8f, 0f),
		new VInt3(-1.3f, 0.6f, 0f),
		new VInt3(-1.3f, -0.6f, 0f)
	};

	// Token: 0x04011A79 RID: 72313
	protected VInt3[] m_PosOffset8 = new VInt3[]
	{
		new VInt3(1.7f, 0f, 0f),
		new VInt3(0f, 1.4f, 0f),
		new VInt3(0f, -1.4f, 0f),
		new VInt3(1.1f, -0.8f, 0f),
		new VInt3(1.1f, 0.8f, 0f),
		new VInt3(-1.1f, 0.8f, 0f),
		new VInt3(-1.1f, -0.8f, 0f),
		new VInt3(-1.7f, 0f, 0f)
	};

	// Token: 0x04011A7A RID: 72314
	protected VInt3[] m_PosOffset9 = new VInt3[]
	{
		new VInt3(1.9f, 0f, 0f),
		new VInt3(0.35f, 1.4f, 0f),
		new VInt3(0.35f, -1.4f, 0f),
		new VInt3(1.4f, 0.8f, 0f),
		new VInt3(1.4f, -0.8f, 0f),
		new VInt3(-1.55f, 0.5f, 0f),
		new VInt3(-1.55f, -0.5f, 0f),
		new VInt3(-0.7f, 1.05f, 0f),
		new VInt3(-0.7f, -1.05f, 0f)
	};

	// Token: 0x04011A7B RID: 72315
	protected VInt3[] m_PosOffset10 = new VInt3[]
	{
		new VInt3(1.95f, 0f, 0f),
		new VInt3(-1.95f, 0f, 0f),
		new VInt3(0.5f, 1.4f, 0f),
		new VInt3(0.5f, -1.4f, 0f),
		new VInt3(1.4f, 0.8f, 0f),
		new VInt3(1.4f, -0.8f, 0f),
		new VInt3(-1.4f, 0.8f, 0f),
		new VInt3(-1.4f, -0.8f, 0f),
		new VInt3(-0.5f, 1.4f, 0f),
		new VInt3(-0.5f, -1.4f, 0f)
	};

	// Token: 0x04011A7C RID: 72316
	protected List<VInt3[]> m_RebornPosList = new List<VInt3[]>();

	// Token: 0x04011A7D RID: 72317
	protected bool m_CreateCloneFlag;

	// Token: 0x04011A7E RID: 72318
	protected int m_CloneMonsterId;

	// Token: 0x04011A7F RID: 72319
	protected List<BeEventHandle> m_RayCloneDeadList = new List<BeEventHandle>();

	// Token: 0x04011A80 RID: 72320
	protected int m_CurrentRayCloneNum;
}
