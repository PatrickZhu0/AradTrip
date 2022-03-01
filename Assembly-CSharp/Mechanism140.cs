using System;
using System.Collections.Generic;
using GamePool;
using UnityEngine;

// Token: 0x02004314 RID: 17172
public class Mechanism140 : BeMechanism
{
	// Token: 0x06017C1E RID: 97310 RVA: 0x00754B10 File Offset: 0x00752F10
	public Mechanism140(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C1F RID: 97311 RVA: 0x00754C40 File Offset: 0x00753040
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.createCDArr[i] = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
		}
		this.entitySpeed = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true), GlobalLogic.VALUE_1000);
		for (int j = 0; j < this.data.ValueC.Count; j++)
		{
			this.addAttackValueArr[j] = TableManager.GetValueFromUnionCell(this.data.ValueC[j], this.level, true);
		}
	}

	// Token: 0x06017C20 RID: 97312 RVA: 0x00754D18 File Offset: 0x00753118
	public override void OnStart()
	{
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		this.monsterId = ((!BattleMain.IsModePvP(base.battleType)) ? this.monsterIdArr[0] : this.monsterIdArr[1]);
		this.sceneHandleA = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.onSummon, delegate(object[] args)
		{
			BeActor actor = (BeActor)args[0];
			if (actor != null && actor.GetEntityData().monsterID == this.monsterId && actor.GetCamp() == base.owner.GetCamp())
			{
				this.summonMonsterList.Add(actor);
				if (this.GetAliveMonsterCount() >= 2)
				{
					actor.delayCaller.DelayCall(GlobalLogic.VALUE_1000, delegate
					{
						if (actor != null && !actor.IsDead())
						{
							this.PlayActionSingle(actor, this.changeToAttack, this.attackIdle);
						}
					}, 0, 0, false);
					this.AddAttackBuff(actor, true);
				}
				else
				{
					actor.delayCaller.DelayCall(467, delegate
					{
						if (actor != null && !actor.IsDead())
						{
							this.AddTriggerBuff(actor);
						}
					}, 0, 0, false);
				}
				actor.RegisterEvent(BeEventType.onDead, delegate(object[] args1)
				{
					this.deadMonsterList.Add(actor);
				});
			}
		});
	}

	// Token: 0x06017C21 RID: 97313 RVA: 0x00754D85 File Offset: 0x00753185
	public override void OnUpdate(int deltaTime)
	{
		this.UpdateCreateCD(deltaTime);
		this.UpdateEntityState();
	}

	// Token: 0x06017C22 RID: 97314 RVA: 0x00754D94 File Offset: 0x00753194
	protected bool StartLaunch()
	{
		this.launchActor = this.GetFirstMonster();
		if (this.launchActor == null)
		{
			return false;
		}
		this.lastReceiveActor = this.launchActor;
		this.lastReceiveSummonIndex = this.GetLaunchSummonIndex(this.launchActor);
		this.receiveActor = this.GetReceiveMonster(this.lastReceiveActor);
		if (this.receiveActor == null)
		{
			return false;
		}
		BeActor beActor = (BeActor)this.launchActor.GetOwner();
		this.RegisterEntityCreate(beActor);
		VInt3 position = this.launchActor.GetPosition();
		position.z += this.entityCreateHeight;
		this.projectile = (BeProjectile)beActor.AddEntity(this.entityId, position, 1, 0);
		this.projectile.dontSetFace = true;
		this.SetTrail();
		return true;
	}

	// Token: 0x06017C23 RID: 97315 RVA: 0x00754E5C File Offset: 0x0075325C
	protected void UpdateEntityState()
	{
		this.UpdateCreateCondition();
		this.UpdateEntityPos();
	}

	// Token: 0x06017C24 RID: 97316 RVA: 0x00754E6A File Offset: 0x0075326A
	protected void EndLaunch()
	{
		this.projectile.DoDie();
		this.runningFlag = false;
		this.StartCD();
	}

	// Token: 0x06017C25 RID: 97317 RVA: 0x00754E84 File Offset: 0x00753284
	protected void UpdateEntityPos()
	{
		if (!this.runningFlag)
		{
			return;
		}
		if (this.receiveActor == null || this.receiveActor.IsDead())
		{
			this.SwitchTarget(false);
			return;
		}
		VInt3 position = this.receiveActor.GetPosition();
		if (this.projectile != null)
		{
			VInt3 position2 = this.projectile.GetPosition();
			if (Mathf.Abs(position.x - position2.x) < this.reboundDis && Mathf.Abs(position.y - position2.y) < this.reboundDis)
			{
				this.SwitchTarget(true);
			}
		}
	}

	// Token: 0x06017C26 RID: 97318 RVA: 0x00754F28 File Offset: 0x00753328
	protected void SwitchTarget(bool isCloseToTarget)
	{
		if (this.launchActor == null || this.receiveActor == null)
		{
			return;
		}
		if (this.receiveActor == this.launchActor)
		{
			this.EndLaunch();
			return;
		}
		if (isCloseToTarget)
		{
			BeActor receiveMonster = this.GetReceiveMonster(this.receiveActor);
			if (receiveMonster != null)
			{
				this.lastReceiveActor = this.receiveActor;
				this.receiveActor = receiveMonster;
			}
			else if (this.launchActor != null && !this.launchActor.IsDead())
			{
				this.lastReceiveActor = this.receiveActor;
				this.receiveActor = this.launchActor;
			}
			else
			{
				this.lastReceiveActor = this.receiveActor;
				this.launchActor = this.GetReceiveMonster(this.launchActor);
				this.receiveActor = this.launchActor;
			}
		}
		else if (this.receiveActor != null && this.receiveActor.IsDead())
		{
			this.lastReceiveActor = this.receiveActor;
			this.receiveActor = this.GetReceiveMonster(this.lastReceiveActor);
		}
		if (this.receiveActor != null)
		{
			this.SetTrail();
		}
		else
		{
			this.EndLaunch();
		}
	}

	// Token: 0x06017C27 RID: 97319 RVA: 0x00755054 File Offset: 0x00753454
	protected void SetTrail()
	{
		if (this.projectile == null || this.receiveActor == null)
		{
			return;
		}
		LinearLogicTrial linearLogicTrial = new LinearLogicTrial();
		VInt3 position = this.projectile.GetPosition();
		linearLogicTrial.StartPoint = position;
		VInt3 position2 = this.receiveActor.GetPosition();
		position2.z = linearLogicTrial.StartPoint.z;
		linearLogicTrial.EndPoint = position2;
		linearLogicTrial.MoveSpeed = this.entitySpeed;
		linearLogicTrial.Init();
		this.projectile.trail = linearLogicTrial;
		this.projectile.ResetDamageData();
		this.PlayActionSingle(this.lastReceiveActor, this.attack, this.attackIdle);
		this.ChangeMonsterFace(this.lastReceiveActor, this.receiveActor);
		this.SetModelRotate(position2, position);
	}

	// Token: 0x06017C28 RID: 97320 RVA: 0x00755114 File Offset: 0x00753514
	protected void SetModelRotate(VInt3 targetPos, VInt3 startPos)
	{
		if (this.projectile == null)
		{
			return;
		}
		Vector3 vector = targetPos.vector3 - startPos.vector3;
		if (vector != Vector3.zero)
		{
			float num = Quaternion.LookRotation(vector).eulerAngles.y - 90f;
			this.projectile.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root).transform.localRotation = Quaternion.Euler(0f, num, 0f);
		}
	}

	// Token: 0x06017C29 RID: 97321 RVA: 0x0075519C File Offset: 0x0075359C
	protected void UpdateCreateCondition()
	{
		if (this.runningFlag || this.isCDFlag)
		{
			return;
		}
		int aliveMonsterCount = this.GetAliveMonsterCount();
		if (!this.startFlag && this.changeFlag && aliveMonsterCount >= 2)
		{
			this.runningFlag = true;
			this.StartLaunch();
		}
		else if (!this.changeFlag && aliveMonsterCount >= 2)
		{
			this.changeFlag = true;
			this.startFlag = true;
			this.RemoveTriggerBuff();
			this.PlayAction(this.changeToAttack, this.attackIdle);
			base.owner.delayCaller.DelayCall(this.ChangeToAttackTime, delegate
			{
				bool flag = this.StartLaunch();
				if (flag)
				{
					this.startFlag = false;
					this.runningFlag = true;
				}
			}, 0, 0, false);
		}
		else if (this.changeFlag && aliveMonsterCount < 2)
		{
			this.changeFlag = false;
			List<BeActor> list = ListPool<BeActor>.Get();
			this.GetAliveMonsterList(list);
			if (list.Count > 0)
			{
				this.AddTriggerBuff(list[0]);
				this.AddAttackBuff(list[0], false);
			}
			ListPool<BeActor>.Release(list);
			this.PlayAction(this.changeToIdle, this.idle);
		}
	}

	// Token: 0x06017C2A RID: 97322 RVA: 0x007552C0 File Offset: 0x007536C0
	protected BeActor GetFirstMonster()
	{
		BeActor result = null;
		List<BeActor> list = ListPool<BeActor>.Get();
		this.GetAliveMonsterList(list);
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] != null && !list[i].IsDead())
			{
				result = list[i];
				break;
			}
		}
		ListPool<BeActor>.Release(list);
		return result;
	}

	// Token: 0x06017C2B RID: 97323 RVA: 0x00755324 File Offset: 0x00753724
	protected int GetLaunchSummonIndex(BeActor actor)
	{
		int result = 0;
		for (int i = 0; i < this.summonMonsterList.Count; i++)
		{
			if (actor == this.summonMonsterList[i])
			{
				result = i;
				break;
			}
		}
		return result;
	}

	// Token: 0x06017C2C RID: 97324 RVA: 0x0075536C File Offset: 0x0075376C
	protected BeActor GetReceiveMonster(BeActor lastReceive)
	{
		BeActor result = null;
		int num = -1;
		for (int i = 0; i < this.summonMonsterList.Count; i++)
		{
			if (this.summonMonsterList[i] == lastReceive)
			{
				num = i;
			}
			if (num != -1 && i > num)
			{
				result = this.summonMonsterList[i];
				break;
			}
		}
		return result;
	}

	// Token: 0x06017C2D RID: 97325 RVA: 0x007553D0 File Offset: 0x007537D0
	protected BeActor GetLaunchMonster()
	{
		BeActor result = null;
		for (int i = this.lastReceiveSummonIndex; i < this.summonMonsterList.Count; i++)
		{
			if (this.summonMonsterList[i] != null && !this.summonMonsterList[i].IsDead())
			{
				result = this.summonMonsterList[i];
				break;
			}
		}
		return result;
	}

	// Token: 0x06017C2E RID: 97326 RVA: 0x0075543C File Offset: 0x0075383C
	protected int GetAliveMonsterCount()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		this.GetAliveMonsterList(list);
		int count = list.Count;
		ListPool<BeActor>.Release(list);
		return count;
	}

	// Token: 0x06017C2F RID: 97327 RVA: 0x00755468 File Offset: 0x00753868
	protected void GetAliveMonsterList(List<BeActor> monsterList)
	{
		for (int i = 0; i < this.summonMonsterList.Count; i++)
		{
			BeActor item = this.summonMonsterList[i];
			if (!this.deadMonsterList.Contains(item))
			{
				monsterList.Add(item);
			}
		}
	}

	// Token: 0x06017C30 RID: 97328 RVA: 0x007554B6 File Offset: 0x007538B6
	protected void RegisterEntityCreate(BeActor creater)
	{
		if (this.handleB != null)
		{
			this.handleB.Remove();
			this.handleB = null;
		}
		this.handleB = creater.RegisterEvent(BeEventType.onChangeDamage, delegate(object[] args)
		{
			int num = (int)args[0];
			if (num != this.hurtId)
			{
				return;
			}
			int aliveMonsterCount = this.GetAliveMonsterCount();
			if (aliveMonsterCount < 2 || aliveMonsterCount > 5)
			{
				return;
			}
			int num2 = this.addAttackValueArr[aliveMonsterCount - 2];
			int[] array = (int[])args[1];
			array[0] += num2;
			array[1] += num2;
		});
	}

	// Token: 0x06017C31 RID: 97329 RVA: 0x007554F4 File Offset: 0x007538F4
	protected void ChangeMonsterFace(BeActor launcher, BeActor receiver)
	{
		if (launcher == null || receiver == null)
		{
			return;
		}
		int num = launcher.GetPosition().x - receiver.GetPosition().x;
		launcher.SetFace(num > 0, true, true);
	}

	// Token: 0x06017C32 RID: 97330 RVA: 0x00755538 File Offset: 0x00753938
	protected void AddTriggerBuff(BeActor actor)
	{
		int buffInfoID = (!BattleMain.IsModePvP(base.battleType)) ? this.triggerBuffInfoId[0] : this.triggerBuffInfoId[1];
		BuffInfoData buffInfo = new BuffInfoData(buffInfoID, actor.GetEntityData().level, 0);
		actor.buffController.AddTriggerBuff(buffInfo);
	}

	// Token: 0x06017C33 RID: 97331 RVA: 0x00755590 File Offset: 0x00753990
	protected void RemoveTriggerBuff()
	{
		int buffInfoID = (!BattleMain.IsModePvP(base.battleType)) ? this.triggerBuffInfoId[0] : this.triggerBuffInfoId[1];
		List<BeActor> list = ListPool<BeActor>.Get();
		this.GetAliveMonsterList(list);
		for (int i = 0; i < list.Count; i++)
		{
			list[i].buffController.RemoveTriggerBuff(buffInfoID);
			this.AddAttackBuff(list[i], true);
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06017C34 RID: 97332 RVA: 0x00755610 File Offset: 0x00753A10
	protected void AddAttackBuff(BeActor actor, bool isAdd = false)
	{
		if (isAdd)
		{
			actor.buffController.TryAddBuff(this.attackBuffId, int.MaxValue, 1);
		}
		else
		{
			BeBuff beBuff = actor.buffController.HasBuffByID(this.attackBuffId);
			if (beBuff != null)
			{
				actor.buffController.RemoveBuff(beBuff);
			}
		}
	}

	// Token: 0x06017C35 RID: 97333 RVA: 0x00755664 File Offset: 0x00753A64
	protected void StartCD()
	{
		this.isCDFlag = true;
		int aliveMonsterCount = this.GetAliveMonsterCount();
		if (aliveMonsterCount <= 5 && aliveMonsterCount > 1 && aliveMonsterCount > 1)
		{
			this.curCtrateCD = this.createCDArr[aliveMonsterCount - 2];
		}
		this.curCreateCD = this.curCtrateCD;
	}

	// Token: 0x06017C36 RID: 97334 RVA: 0x007556B0 File Offset: 0x00753AB0
	protected void UpdateCreateCD(int deltaTime)
	{
		if (!this.isCDFlag)
		{
			return;
		}
		if (this.curCreateCD > 0)
		{
			this.curCreateCD -= deltaTime;
		}
		else
		{
			this.curCreateCD = this.curCtrateCD;
			this.isCDFlag = false;
		}
	}

	// Token: 0x06017C37 RID: 97335 RVA: 0x007556F0 File Offset: 0x00753AF0
	protected void PlayAction(string curAction, string delayAction)
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		this.GetAliveMonsterList(list);
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				BeActor actor = list[i];
				this.PlayActionSingle(actor, curAction, delayAction);
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06017C38 RID: 97336 RVA: 0x00755740 File Offset: 0x00753B40
	protected void PlayActionSingle(BeActor actor, string curAction, string delayAction)
	{
		int ms = actor.PlayAction(curAction, 1f);
		actor.delayCaller.DelayCall(ms, delegate
		{
			if (actor != null && !actor.IsDead())
			{
				actor.PlayAction(delayAction, 1f);
			}
		}, 0, 0, false);
	}

	// Token: 0x0401114E RID: 69966
	public int[] createCDArr = new int[]
	{
		1000,
		667,
		167,
		0
	};

	// Token: 0x0401114F RID: 69967
	protected VInt entitySpeed = 60000;

	// Token: 0x04011150 RID: 69968
	protected int[] addAttackValueArr = new int[]
	{
		0,
		900,
		1200,
		1500
	};

	// Token: 0x04011151 RID: 69969
	protected int entityId = 63609;

	// Token: 0x04011152 RID: 69970
	protected int[] monsterIdArr = new int[]
	{
		93060031,
		93000034
	};

	// Token: 0x04011153 RID: 69971
	protected int hurtId = 36092;

	// Token: 0x04011154 RID: 69972
	protected List<BeActor> summonMonsterList = new List<BeActor>();

	// Token: 0x04011155 RID: 69973
	protected List<BeActor> deadMonsterList = new List<BeActor>();

	// Token: 0x04011156 RID: 69974
	public int curCtrateCD = 1000;

	// Token: 0x04011157 RID: 69975
	protected int monsterId = 93000034;

	// Token: 0x04011158 RID: 69976
	protected int entityCreateHeight = 8000;

	// Token: 0x04011159 RID: 69977
	protected int reboundDis = 5000;

	// Token: 0x0401115A RID: 69978
	protected int[] triggerBuffInfoId = new int[]
	{
		360903,
		360902
	};

	// Token: 0x0401115B RID: 69979
	protected int attackBuffId = 360211;

	// Token: 0x0401115C RID: 69980
	protected bool startFlag;

	// Token: 0x0401115D RID: 69981
	protected bool runningFlag;

	// Token: 0x0401115E RID: 69982
	protected bool changeFlag;

	// Token: 0x0401115F RID: 69983
	protected bool switchToIdleFlag;

	// Token: 0x04011160 RID: 69984
	protected BeActor launchActor;

	// Token: 0x04011161 RID: 69985
	protected BeActor lastReceiveActor;

	// Token: 0x04011162 RID: 69986
	protected BeActor receiveActor;

	// Token: 0x04011163 RID: 69987
	protected int lastReceiveSummonIndex;

	// Token: 0x04011164 RID: 69988
	protected BeProjectile projectile;

	// Token: 0x04011165 RID: 69989
	protected bool isCDFlag;

	// Token: 0x04011166 RID: 69990
	protected int curCreateCD;

	// Token: 0x04011167 RID: 69991
	protected string idle = "Idle";

	// Token: 0x04011168 RID: 69992
	protected string attack = "Attack";

	// Token: 0x04011169 RID: 69993
	protected string changeToAttack = "ChangeToAttack";

	// Token: 0x0401116A RID: 69994
	protected string attackIdle = "AttackIdle";

	// Token: 0x0401116B RID: 69995
	protected string changeToIdle = "ChangeToIdle";

	// Token: 0x0401116C RID: 69996
	protected int ChangeToAttackTime = 1500;
}
