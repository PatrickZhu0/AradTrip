using System;
using System.Collections.Generic;
using Battle;
using UnityEngine;

// Token: 0x020044F9 RID: 17657
public class Skill5758 : Skill2112
{
	// Token: 0x06018928 RID: 100648 RVA: 0x007ACB3C File Offset: 0x007AAF3C
	public Skill5758(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018929 RID: 100649 RVA: 0x007ACB50 File Offset: 0x007AAF50
	public override void OnInit()
	{
		this.distancex = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true), GlobalLogic.VALUE_1000);
		this.distancey = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueA[1], base.level, true), GlobalLogic.VALUE_1000);
		this.skillList = new int[this.skillData.ValueB.Count];
		for (int i = 0; i < this.skillData.ValueB.Count; i++)
		{
			this.skillList[i] = TableManager.GetValueFromUnionCell(this.skillData.ValueB[i], base.level, true);
		}
		this.entityList = new int[this.skillData.ValueC.Count];
		for (int j = 0; j < this.skillData.ValueC.Count; j++)
		{
			this.entityList[j] = TableManager.GetValueFromUnionCell(this.skillData.ValueC[j], base.level, true);
		}
		this.effectPath = "Effects/Monster_Renzhe/Prefab/Eff_renzhe_yanwu";
		this.isCreatePoppet = false;
	}

	// Token: 0x0601892A RID: 100650 RVA: 0x007ACC8C File Offset: 0x007AB08C
	public override bool CheckSpellCondition(ActionState state)
	{
		bool flag = base.owner.stateController.HasBuffState(BeBuffStateType.FROZEN) || base.owner.stateController.HasBuffState(BeBuffStateType.STUN) || base.owner.stateController.HasBuffState(BeBuffStateType.STONE) || base.owner.stateController.HasBuffState(BeBuffStateType.SLEEP) || base.owner.stateController.HasBuffState(BeBuffStateType.STRAIN);
		bool flag2 = base.owner.sgGetCurrentState() == 4 || base.owner.sgGetCurrentState() == 15 || base.owner.sgGetCurrentState() == 14 || base.owner.sgGetCurrentState() == 18 || base.owner.sgGetCurrentState() == 6;
		return !flag && !flag2 && !base.owner.IsInPassiveState() && !base.owner.stateController.WillBeGrab();
	}

	// Token: 0x0601892B RID: 100651 RVA: 0x007ACDA8 File Offset: 0x007AB1A8
	public override void OnEnterPhase(int phase)
	{
		if (phase == 3)
		{
			this.curIndex = this.GetNextSkillIndex();
			int id = this.entityList[this.curIndex];
			this.CreateHeadEntity(id);
		}
	}

	// Token: 0x0601892C RID: 100652 RVA: 0x007ACDE0 File Offset: 0x007AB1E0
	private void CreateHeadEntity(int id)
	{
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			BattlePlayer battlePlayer = allPlayers[i];
			if (battlePlayer != null && battlePlayer.playerActor != null && !battlePlayer.playerActor.IsDead())
			{
				BeEntity beEntity = battlePlayer.playerActor.AddEntity(id, battlePlayer.playerActor.GetPosition(), 1, 0);
				if (beEntity != null && beEntity.m_pkGeActor != null)
				{
					GameObject attachNode = battlePlayer.playerActor.m_pkGeActor.GetAttachNode("[actor]OrignBuff");
					GameObject entityNode = beEntity.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root);
					if (attachNode != null && entityNode != null)
					{
						GeUtility.AttachTo(entityNode, attachNode, false);
						entityNode.transform.localPosition = Vector3.zero;
					}
				}
			}
		}
	}

	// Token: 0x0601892D RID: 100653 RVA: 0x007ACED0 File Offset: 0x007AB2D0
	private int GetNextSkillIndex()
	{
		if (this.skillList.Length == 0)
		{
			return -1;
		}
		int num = -1;
		for (int i = 0; i < 100; i++)
		{
			num = (int)base.FrameRandom.Random((uint)this.skillList.Length);
			if (num != this.lastSkillIndex)
			{
				break;
			}
		}
		this.lastSkillIndex = num;
		return num;
	}

	// Token: 0x0601892E RID: 100654 RVA: 0x007ACF30 File Offset: 0x007AB330
	public override void OnFinish()
	{
		int skillId = this.skillList[this.curIndex];
		base.owner.delayCaller.DelayCall(30, delegate
		{
			this.owner.UseSkill(skillId, false);
		}, 0, 0, false);
	}

	// Token: 0x04011BA7 RID: 72615
	private int[] skillList;

	// Token: 0x04011BA8 RID: 72616
	private int[] entityList;

	// Token: 0x04011BA9 RID: 72617
	private int curIndex;

	// Token: 0x04011BAA RID: 72618
	private int lastSkillIndex = -1;
}
