using System;
using System.Collections.Generic;
using GameClient;
using GamePool;
using UnityEngine;

// Token: 0x02004373 RID: 17267
public class Mechanism2059 : BeMechanism
{
	// Token: 0x06017EB4 RID: 97972 RVA: 0x0076775C File Offset: 0x00765B5C
	public Mechanism2059(int id, int lv) : base(id, lv)
	{
	}

	// Token: 0x06017EB5 RID: 97973 RVA: 0x007677B4 File Offset: 0x00765BB4
	public override void OnInit()
	{
		base.OnInit();
		this.monsterIdArr[0] = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.monsterIdArr[1] = TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true);
		this.absorbMaxCount = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		for (int i = 0; i < this.data.ValueC.Count; i++)
		{
			this.targetPos[i] = TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true);
		}
		this.absorbSpeed = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.absorbAcc = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		this.hurtId = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
		this.delayTime = TableManager.GetValueFromUnionCell(this.data.ValueG[0], this.level, true);
	}

	// Token: 0x06017EB6 RID: 97974 RVA: 0x00767932 File Offset: 0x00765D32
	public override void OnStart()
	{
		base.OnStart();
		this.InitData();
	}

	// Token: 0x06017EB7 RID: 97975 RVA: 0x00767940 File Offset: 0x00765D40
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (!this.CheckStart(deltaTime))
		{
			return;
		}
		this.runingTime += deltaTime;
		this.UpdateAbsorbPlayers();
		this.UpdateAbsorbDeadBody();
		this.UpdateAbsorbSpeed();
		this.CheckStart(deltaTime);
	}

	// Token: 0x06017EB8 RID: 97976 RVA: 0x0076797E File Offset: 0x00765D7E
	private bool CheckStart(int deltaTime)
	{
		if (this.curDelayTime >= this.delayTime)
		{
			return true;
		}
		this.curDelayTime += deltaTime;
		return false;
	}

	// Token: 0x06017EB9 RID: 97977 RVA: 0x007679A2 File Offset: 0x00765DA2
	public override void OnFinish()
	{
		base.OnFinish();
		this.SetMonsterRemove();
		this.CloseFrame();
	}

	// Token: 0x06017EBA RID: 97978 RVA: 0x007679B8 File Offset: 0x00765DB8
	private void InitData()
	{
		this.curDelayTime = 0;
		this.runingTime = 0;
		this.monsterDead = 0;
		this.RefreshCompleteCount(0);
		for (int i = 0; i < this.offsetArr.Length; i++)
		{
			int num = base.FrameRandom.InRange(-1000, 1000);
			this.offsetArr[i] = num;
		}
		this.monsterList.Clear();
		if (base.owner.CurrentBeScene != null)
		{
			this.sceneHandleA = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.onSummon, delegate(object[] args)
			{
				BeActor beActor = args[0] as BeActor;
				if (beActor != null && beActor.GetEntityData().MonsterIDEqual(this.monsterIdArr[1]))
				{
					this.monsterDead++;
					this.RefreshCompleteCount(this.monsterDead);
				}
			});
		}
	}

	// Token: 0x06017EBB RID: 97979 RVA: 0x00767A58 File Offset: 0x00765E58
	private void UpdateAbsorbSpeed()
	{
		this.curAbsorbSpeed = this.absorbSpeed + this.runingTime * this.absorbAcc;
	}

	// Token: 0x06017EBC RID: 97980 RVA: 0x00767A74 File Offset: 0x00765E74
	private void UpdateAbsorbPlayers()
	{
		if (!this.absorbFlag)
		{
			return;
		}
		if (base.owner.CurrentBeBattle == null || base.owner.CurrentBeBattle.dungeonPlayerManager == null)
		{
			return;
		}
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			if (allPlayers[i] != null)
			{
				BeActor playerActor = allPlayers[i].playerActor;
				if (playerActor != null)
				{
					if (!playerActor.IsDead())
					{
						if (this.GetDis(playerActor, this.targetPos) < GlobalLogic.VALUE_5000)
						{
							this.ClearExtraSpeed(playerActor);
							if (playerActor.stateController.CanBeHit())
							{
								if (playerActor.isLocalActor)
								{
									MonoSingleton<AudioManager>.instance.PlaySound(5016);
								}
								base.owner.DoAttackTo(playerActor, this.hurtId, true, false);
							}
						}
						else
						{
							this.AbsorbTarget(playerActor, this.targetPos);
						}
					}
				}
			}
		}
	}

	// Token: 0x06017EBD RID: 97981 RVA: 0x00767B8C File Offset: 0x00765F8C
	private void UpdateAbsorbDeadBody()
	{
		if (!this.absorbFlag)
		{
			return;
		}
		List<BeActor> list = ListPool<BeActor>.Get();
		VInt3 pos = this.targetPos;
		pos.x -= 20000;
		base.owner.CurrentBeScene.FindMonsterByIDAndCamp(list, this.monsterIdArr[1], base.owner.GetCamp());
		for (int i = 0; i < list.Count; i++)
		{
			BeActor beActor = list[i];
			if (this.GetDis(list[i], pos) <= GlobalLogic.VALUE_5000)
			{
				if (!this.monsterList.Contains(beActor))
				{
					this.monsterList.Add(beActor);
					this.ClearExtraSpeed(beActor);
					this.SetMonsterActorXOffset(false);
				}
			}
			else
			{
				this.AbsorbTarget(beActor, pos);
			}
		}
		ListPool<BeActor>.Release(list);
		if (this.monsterList.Count >= this.absorbMaxCount)
		{
			this.absorbFlag = false;
			base.owner.UseSkill(this.useSkillId, true);
		}
	}

	// Token: 0x06017EBE RID: 97982 RVA: 0x00767C90 File Offset: 0x00766090
	private int GetDis(BeActor actor, VInt3 pos)
	{
		return (pos - actor.GetPosition()).magnitude;
	}

	// Token: 0x06017EBF RID: 97983 RVA: 0x00767CB4 File Offset: 0x007660B4
	private void AbsorbTarget(BeActor actor, VInt3 pos)
	{
		if (!actor.stateController.CanMove())
		{
			return;
		}
		if (actor.stateController.CanNotAbsorbByBlockHole())
		{
			return;
		}
		VInt3 position = actor.GetPosition();
		VInt3 vint = new VInt3(pos.x - position.x, pos.y - position.y, pos.z - position.z);
		VInt3 vint2 = vint.NormalizeTo(this.curAbsorbSpeed);
		if (actor.stateController.CanMoveX())
		{
			actor.extraSpeed.x = vint2.x;
		}
		if (actor.stateController.CanMoveY())
		{
			actor.extraSpeed.y = vint2.y;
		}
		actor.extraSpeed.z = vint2.z;
	}

	// Token: 0x06017EC0 RID: 97984 RVA: 0x00767D82 File Offset: 0x00766182
	private void ClearExtraSpeed(BeActor actor)
	{
		actor.extraSpeed = VInt3.zero;
	}

	// Token: 0x06017EC1 RID: 97985 RVA: 0x00767D90 File Offset: 0x00766190
	private void SetMonsterRemove()
	{
		for (int i = 0; i < this.monsterList.Count; i++)
		{
			BeActor beActor = this.monsterList[i];
			if (beActor != null && !beActor.IsDead())
			{
				beActor.DoDead(false);
			}
		}
		this.SetMonsterActorXOffset(true);
	}

	// Token: 0x06017EC2 RID: 97986 RVA: 0x00767DEC File Offset: 0x007661EC
	private void SetMonsterActorXOffset(bool isRestore = false)
	{
		for (int i = 0; i < this.offsetArr.Length; i++)
		{
			if (i < this.monsterList.Count)
			{
				BeActor beActor = this.monsterList[i];
				if (beActor != null)
				{
					if (beActor.m_pkGeActor != null)
					{
						GameObject entityNode = beActor.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Actor);
						if (!(entityNode == null))
						{
							if (isRestore)
							{
								entityNode.transform.localPosition = Vector3.zero;
							}
							else
							{
								entityNode.transform.localPosition = new Vector3((float)this.offsetArr[i] / 1000f, 0f, 0f);
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06017EC3 RID: 97987 RVA: 0x00767EB4 File Offset: 0x007662B4
	private void RefreshCompleteCount(int curCount)
	{
		if (this.frame == null)
		{
			this.frame = (Singleton<ClientSystemManager>.instance.OpenFrame<TeamDungeonBattleFrame>(FrameLayer.Middle, null, string.Empty) as TeamDungeonBattleFrame);
		}
		if (this.frame != null)
		{
			this.frame.ShowCompelteCount(curCount, this.absorbMaxCount);
		}
	}

	// Token: 0x06017EC4 RID: 97988 RVA: 0x00767F05 File Offset: 0x00766305
	private void CloseFrame()
	{
		if (this.frame == null)
		{
			return;
		}
		this.frame.Close(false);
		this.frame = null;
	}

	// Token: 0x0401137C RID: 70524
	private int[] monsterIdArr = new int[2];

	// Token: 0x0401137D RID: 70525
	private int absorbMaxCount;

	// Token: 0x0401137E RID: 70526
	private VInt3 targetPos = VInt3.zero;

	// Token: 0x0401137F RID: 70527
	private int absorbSpeed;

	// Token: 0x04011380 RID: 70528
	private int absorbAcc;

	// Token: 0x04011381 RID: 70529
	private int hurtId;

	// Token: 0x04011382 RID: 70530
	private int delayTime;

	// Token: 0x04011383 RID: 70531
	private int useSkillId = 21074;

	// Token: 0x04011384 RID: 70532
	private int curAbsorbSpeed;

	// Token: 0x04011385 RID: 70533
	private bool absorbFlag = true;

	// Token: 0x04011386 RID: 70534
	private TeamDungeonBattleFrame frame;

	// Token: 0x04011387 RID: 70535
	private int curDelayTime;

	// Token: 0x04011388 RID: 70536
	private int runingTime;

	// Token: 0x04011389 RID: 70537
	private int[] offsetArr = new int[5];

	// Token: 0x0401138A RID: 70538
	private List<BeActor> monsterList = new List<BeActor>();

	// Token: 0x0401138B RID: 70539
	private int monsterDead;
}
