using System;
using System.Collections.Generic;
using GameClient;
using GamePool;
using UnityEngine;

// Token: 0x02004308 RID: 17160
internal class Mechanism131 : BeMechanism
{
	// Token: 0x06017BDB RID: 97243 RVA: 0x00752468 File Offset: 0x00750868
	public Mechanism131(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017BDC RID: 97244 RVA: 0x00752518 File Offset: 0x00750918
	public override void OnInit()
	{
		this.monsterNum = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.stayTime = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.speed = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true), GlobalLogic.VALUE_1000);
		this.totalTime = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		this.hpReduce = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
		this.maxNumForOneHit = TableManager.GetValueFromUnionCell(this.data.ValueG[0], this.level, true);
		this.pointArray = new VInt3[3];
		this.pointArray[0] = new VInt3(-100000, 60000, 0);
		this.pointArray[1] = new VInt3(-155000, 60000, 0);
		this.pointArray[2] = new VInt3(-45000, 60000, 0);
	}

	// Token: 0x06017BDD RID: 97245 RVA: 0x00752690 File Offset: 0x00750A90
	public override void OnStart()
	{
		this.index = 0;
		this.mainTimer = 5000;
		this.monsterCount = 0;
		this.singleCount = 0;
		this.setRoomFlag = false;
		this.handleA = base.owner.RegisterEvent(BeEventType.onAIStart, delegate(object[] args)
		{
			base.owner.aiManager.Stop();
			base.owner.UseSkill(this.preSkill, true);
			this.state = Mechanism131.StateEnum.PRE_SKILL;
			this.uiFrame = (Singleton<ClientSystemManager>.instance.OpenFrame<GoblinKingdomFrame>(FrameLayer.Middle, null, string.Empty) as GoblinKingdomFrame);
			this.uiFrame.SetNumText(this.monsterNum.ToString());
			this.UpdateTotalTime(0);
		});
		this.InitRooms();
	}

	// Token: 0x06017BDE RID: 97246 RVA: 0x007526EC File Offset: 0x00750AEC
	private void InitRooms()
	{
		base.owner.CurrentBeScene.FindMonsterByID(this.roomList, this.roomId2, true);
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindMonsterByID(list, this.roomId1, true);
		if (list[0].GetPosition().x < list[1].GetPosition().x)
		{
			this.roomList.Add(list[0]);
			this.roomList.Add(list[1]);
		}
		else
		{
			this.roomList.Add(list[1]);
			this.roomList.Add(list[0]);
		}
		ListPool<BeActor>.Release(list);
		for (int i = 0; i < this.roomList.Count; i++)
		{
			BeActor room = this.roomList[i];
			room.buffController.TryAddBuff(29, 999999, 1);
			room.RegisterEvent(BeEventType.onHPChange, delegate(object[] args)
			{
				int num = (int)args[0];
				this.hpReduceTotal += num;
				for (int j = 0; j < this.maxNumForOneHit; j++)
				{
					if (-this.hpReduceTotal < this.hpReduce)
					{
						break;
					}
					this.hpReduceTotal += this.hpReduce;
					if (this.roomList.IndexOf(room) == 0)
					{
						this.owner.CurrentBeScene.currentGeScene.CreateEffect(this.goblinEffectPath1, 0.62f, room.GetPosition().vec3, 1f, 1f, false, false);
					}
					else
					{
						this.owner.CurrentBeScene.currentGeScene.CreateEffect(this.goblinEffectPath2, 0.75f, room.GetPosition().vec3, 1f, 1f, false, false);
					}
					this.owner.delayCaller.DelayCall(800, delegate
					{
						this.owner.UseSkill(this.eatSkillId, false);
						this.monsterCount++;
						this.singleCount++;
						if (this.monsterCount == this.monsterNum)
						{
							this.SetCurrentRoomState(false);
							this.state = Mechanism131.StateEnum.BEFORE_DEAD;
							this.mainTimer = 2300;
							this.owner.delayCaller.DelayCall(300, delegate
							{
								this.owner.UseSkill(this.deadSkill, true);
							}, 0, 0, false);
						}
						if (this.uiFrame != null && this.monsterCount <= this.monsterNum)
						{
							this.uiFrame.SetNumText((this.monsterNum - this.monsterCount).ToString());
						}
					}, 0, 0, false);
				}
			});
		}
	}

	// Token: 0x06017BDF RID: 97247 RVA: 0x0075282C File Offset: 0x00750C2C
	public override void OnUpdate(int deltaTime)
	{
		if (base.owner == null)
		{
			return;
		}
		if (base.owner.IsDead())
		{
			return;
		}
		if (this.state == Mechanism131.StateEnum.NONE)
		{
			return;
		}
		if (this.state == Mechanism131.StateEnum.PRE_SKILL)
		{
			this.mainTimer -= deltaTime;
			if (this.mainTimer <= 0)
			{
				this.StartMove();
			}
		}
		else if (this.state == Mechanism131.StateEnum.MOVE)
		{
			this.mainTimer -= deltaTime;
			if (this.mainTimer <= this.preStayTime)
			{
				this.SetCurrentRoomState(true);
				this.setRoomFlag = true;
			}
			if (this.mainTimer <= 0)
			{
				this.StopMove();
				this.mainTimer = 0;
			}
		}
		else if (this.state == Mechanism131.StateEnum.STAY)
		{
			this.mainTimer += deltaTime;
			if (this.mainTimer + this.preMoveTime >= this.stayTime)
			{
				this.SetCurrentRoomState(false);
				this.setRoomFlag = true;
			}
			if (this.mainTimer >= this.stayTime)
			{
				if (this.singleCount > 0)
				{
					this.StartMove();
				}
				else
				{
					base.owner.UseSkill(this.attackSkillId, true);
					this.state = Mechanism131.StateEnum.ATTACK_SKILL;
					this.mainTimer = 3000;
				}
			}
		}
		else if (this.state == Mechanism131.StateEnum.ATTACK_SKILL)
		{
			this.mainTimer -= deltaTime;
			if (this.mainTimer <= 0)
			{
				this.StartMove();
			}
		}
		else if (this.state == Mechanism131.StateEnum.BEFORE_DEAD)
		{
			this.mainTimer -= deltaTime;
			if (this.mainTimer <= 0)
			{
				base.owner.DoDead(false);
			}
		}
		if (this.state != Mechanism131.StateEnum.BEFORE_DEAD && this.state != Mechanism131.StateEnum.PRE_SKILL)
		{
			this.UpdateTotalTime(deltaTime);
		}
	}

	// Token: 0x06017BE0 RID: 97248 RVA: 0x00752A00 File Offset: 0x00750E00
	private void SetCurrentRoomState(bool state)
	{
		if (this.setRoomFlag)
		{
			return;
		}
		if (state)
		{
			this.roomList[this.index].buffController.RemoveBuff(29, 0, 0);
			this.roomList[this.index].buffController.TryAddBuff(this.roomLeadAttackBuffInfo, null, false, null, 0);
		}
		else
		{
			this.roomList[this.index].buffController.TryAddBuff(29, 999999, 1);
		}
	}

	// Token: 0x06017BE1 RID: 97249 RVA: 0x00752A90 File Offset: 0x00750E90
	private void UpdateTotalTime(int deltaTime)
	{
		this.totalTime -= deltaTime;
		if (this.totalTime > 0)
		{
			if (this.uiFrame != null)
			{
				int num = this.totalTime / 60000;
				int num2 = this.totalTime % 60000 / 1000;
				int num3 = this.totalTime % 1000 / 10;
				string timeText = string.Format("{0}.{1:D2}.{2:D2}", num, num2, num3);
				this.uiFrame.SetTimeText(timeText);
			}
		}
		else
		{
			this.state = Mechanism131.StateEnum.BEFORE_DEAD;
			this.mainTimer = 2500;
			base.owner.UseSkill(this.boomSkill, true);
		}
	}

	// Token: 0x06017BE2 RID: 97250 RVA: 0x00752B48 File Offset: 0x00750F48
	private void RandNextIndex()
	{
		int num = (int)(base.owner.FrameRandom.Random(2U) + 1);
		this.index = (this.index + num) % this.pointArray.Length;
	}

	// Token: 0x06017BE3 RID: 97251 RVA: 0x00752B80 File Offset: 0x00750F80
	private void MoveToTarget()
	{
		base.owner.ChangeRunMode(true);
		base.owner.ClearMoveSpeed(7);
		VInt3 vint = this.pointArray[this.index] - base.owner.GetPosition();
		this.mainTimer = vint.magnitude * GlobalLogic.VALUE_1000 / this.speed.i;
		vint.NormalizeTo(this.speed.i);
		base.owner.SetMoveSpeedX(vint.x);
		base.owner.SetMoveSpeedY(vint.y);
		base.owner.SetFace(vint.x < 0, false, false);
		base.owner.m_pkGeActor.ChangeAction("Anim_Walk", 0.25f, true, true, false);
	}

	// Token: 0x06017BE4 RID: 97252 RVA: 0x00752C61 File Offset: 0x00751061
	private void StartMove()
	{
		this.RandNextIndex();
		this.MoveToTarget();
		this.state = Mechanism131.StateEnum.MOVE;
		this.setRoomFlag = false;
	}

	// Token: 0x06017BE5 RID: 97253 RVA: 0x00752C80 File Offset: 0x00751080
	private void StopMove()
	{
		base.owner.SetPosition(this.pointArray[this.index], false, true, false);
		base.owner.SetFace(false, false, false);
		base.owner.ResetMoveCmd();
		base.owner.m_pkGeActor.ChangeAction("Anim_Stayopen02", 0.25f, true, true, false);
		this.state = Mechanism131.StateEnum.STAY;
		this.setRoomFlag = false;
		this.singleCount = 0;
		this.hpReduceTotal = 0;
		GeEffectEx geEffectEx = base.owner.m_pkGeActor.CreateEffect(this.timeEffectPath, "[actor]Orign", 0f, Vec3.zero, 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
		if (geEffectEx != null)
		{
			Vector3 position = geEffectEx.GetPosition();
			position.y += 2.3f;
			geEffectEx.SetPosition(position);
		}
	}

	// Token: 0x06017BE6 RID: 97254 RVA: 0x00752D60 File Offset: 0x00751160
	public override void OnFinish()
	{
		if (this.uiFrame != null)
		{
			this.uiFrame.Close(false);
			this.uiFrame = null;
		}
		for (int i = 0; i < this.roomList.Count; i++)
		{
			this.roomList[i].GetEntityData().SetHP(-1);
			this.roomList[i].DoDead(false);
		}
		this.roomList.Clear();
	}

	// Token: 0x0401110C RID: 69900
	private int monsterNum;

	// Token: 0x0401110D RID: 69901
	private int stayTime;

	// Token: 0x0401110E RID: 69902
	private int totalTime;

	// Token: 0x0401110F RID: 69903
	private int hpReduce;

	// Token: 0x04011110 RID: 69904
	private int maxNumForOneHit;

	// Token: 0x04011111 RID: 69905
	private int eatSkillId = 5821;

	// Token: 0x04011112 RID: 69906
	private int attackSkillId = 5822;

	// Token: 0x04011113 RID: 69907
	private int boomSkill = 5823;

	// Token: 0x04011114 RID: 69908
	private int deadSkill = 5824;

	// Token: 0x04011115 RID: 69909
	private int preSkill = 5825;

	// Token: 0x04011116 RID: 69910
	private int preMoveTime = 1100;

	// Token: 0x04011117 RID: 69911
	private int preStayTime = 800;

	// Token: 0x04011118 RID: 69912
	private int roomId1 = 30450021;

	// Token: 0x04011119 RID: 69913
	private int roomId2 = 30490021;

	// Token: 0x0401111A RID: 69914
	private int roomLeadAttackBuffInfo = 568912;

	// Token: 0x0401111B RID: 69915
	private List<BeActor> roomList = new List<BeActor>();

	// Token: 0x0401111C RID: 69916
	private int hpReduceTotal;

	// Token: 0x0401111D RID: 69917
	private int singleCount;

	// Token: 0x0401111E RID: 69918
	private int monsterCount;

	// Token: 0x0401111F RID: 69919
	private int mainTimer;

	// Token: 0x04011120 RID: 69920
	private Mechanism131.StateEnum state;

	// Token: 0x04011121 RID: 69921
	private VInt3[] pointArray;

	// Token: 0x04011122 RID: 69922
	private VInt speed;

	// Token: 0x04011123 RID: 69923
	private int index;

	// Token: 0x04011124 RID: 69924
	private bool setRoomFlag;

	// Token: 0x04011125 RID: 69925
	private GoblinKingdomFrame uiFrame;

	// Token: 0x04011126 RID: 69926
	private string timeEffectPath = "Effects/Scene_effects/Scene_gblwg/Prefab/Eff_Scene_gblwg_daojishi";

	// Token: 0x04011127 RID: 69927
	private string goblinEffectPath1 = "Effects/Monster_Yijie_goblin/Monster_gblwg_tanchu/Prefab/Eff_Monster_gblwg_tanchu";

	// Token: 0x04011128 RID: 69928
	private string goblinEffectPath2 = "Effects/Monster_Yijie_goblin/Monster_gblwg_tanchu/Prefab/Eff_Monster_gblwg_tanchu01";

	// Token: 0x02004309 RID: 17161
	private enum StateEnum
	{
		// Token: 0x0401112A RID: 69930
		NONE,
		// Token: 0x0401112B RID: 69931
		PRE_SKILL,
		// Token: 0x0401112C RID: 69932
		STAY,
		// Token: 0x0401112D RID: 69933
		MOVE,
		// Token: 0x0401112E RID: 69934
		ATTACK_SKILL,
		// Token: 0x0401112F RID: 69935
		BEFORE_DEAD
	}
}
