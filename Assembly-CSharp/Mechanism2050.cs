using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x0200436A RID: 17258
public class Mechanism2050 : BeMechanism
{
	// Token: 0x06017E6D RID: 97901 RVA: 0x007654C8 File Offset: 0x007638C8
	public Mechanism2050(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017E6E RID: 97902 RVA: 0x00765534 File Offset: 0x00763934
	public override void OnInit()
	{
		base.OnInit();
		this.moveXSpeed = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.moveZSpeed = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.maxHitNum = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.maxZpos = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.entityID = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
		if (valueFromUnionCell != 0)
		{
			this.buffID = valueFromUnionCell;
		}
	}

	// Token: 0x06017E6F RID: 97903 RVA: 0x00765640 File Offset: 0x00763A40
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onCollide, delegate(object[] args)
		{
			if (base.owner.IsDead() || base.owner.CurrentBeScene.IsInBlockPlayer(base.owner.GetPosition()))
			{
				return;
			}
			BeActor target = args[0] as BeActor;
			if (!target.isMainActor || target.IsDead())
			{
				return;
			}
			if (this.target == null && target != null && !target.isSpecialMonster)
			{
				target.SetAttackButtonState(ButtonState.RELEASE, true);
				target.sgSwitchStates(new BeStateData(0, 0));
				target.buffController.TryAddBuff(this.buffID, -1, 1);
				target.buffController.TryAddBuff(99, -1, 1);
				target.m_pkGeActor.ChangeAction("Anim_Xiadun", 1f, true, true, false);
				target.buffController.TryAddBuff(29, -1, 1);
				target.stateController.SetAbilityEnable(BeAbilityType.CHANGE_FACE, false);
				this.target = target;
				this.SetSkillBtn(false);
				BeEventHandle item2 = target.RegisterEvent(BeEventType.OnChangeMoveDir, delegate(object[] obj)
				{
					short num = (short)obj[0];
					bool flag = (bool)obj[1];
					if (flag)
					{
						if (num > 6 && num < 18)
						{
							this.tempMoveSpeed = -this.moveXSpeed;
						}
						else
						{
							this.tempMoveSpeed = this.moveXSpeed;
						}
					}
					else
					{
						this.tempMoveSpeed = 0;
					}
				});
				BeEventHandle item3 = target.RegisterEvent(BeEventType.onCastNormalAttack, delegate(object[] obj)
				{
					this.attackFlag = true;
					this.isInit = true;
					target.AddEntity(this.entityID, target.GetPosition(), 1, 0);
					this.owner.SetMoveSpeedZ(-this.moveZSpeed);
				});
				BeEventHandle item4 = target.RegisterEvent(BeEventType.onHitOther, delegate(object[] obj)
				{
					if (!this.attackFlag)
					{
						return;
					}
					this.attackFlag = false;
					this.recordHitNum++;
					if (this.recordHitNum >= this.maxHitNum && !this.owner.IsDead())
					{
						this.owner.DoDead(false);
					}
				});
				BeEventHandle item5 = target.RegisterEvent(BeEventType.onDead, delegate(object[] obj)
				{
					VInt3 position = target.GetPosition();
					target.SetPosition(new VInt3(position.x, position.y, 0), false, true, false);
					if (!this.owner.IsDead())
					{
						this.owner.DoDead(false);
					}
				});
				this.handlList.Add(item2);
				this.handlList.Add(item3);
				this.handlList.Add(item4);
				this.handlList.Add(item5);
			}
		});
		BeEventHandle item = base.owner.RegisterEvent(BeEventType.onTouchGround, delegate(object[] obj)
		{
			if (this.isInit && !base.owner.IsDead())
			{
				base.owner.DoDead(false);
			}
		});
		this.handlList.Add(item);
	}

	// Token: 0x06017E70 RID: 97904 RVA: 0x00765698 File Offset: 0x00763A98
	private void SetSkillBtn(bool flag)
	{
		if (this.target != null && this.target.isLocalActor)
		{
			if (flag)
			{
				if (!base.owner.CurrentBeBattle.HasFlag(BattleFlagType.InputUIBug))
				{
					InputManager.instance.ResetButtonState2();
				}
				else
				{
					InputManager.instance.ResetButtonState();
				}
			}
			else
			{
				InputManager.instance.SetButtonStateActive(0);
			}
		}
	}

	// Token: 0x06017E71 RID: 97905 RVA: 0x0076570C File Offset: 0x00763B0C
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (base.owner.IsDead())
		{
			return;
		}
		if (base.owner.GetPosition().z > this.maxZpos && !base.owner.IsDead())
		{
			if (this.target != null)
			{
				this.target.DoHPChange(-2147483647, false);
			}
			base.owner.DoDead(false);
		}
		if (!base.owner.IsDead())
		{
			base.owner.SetMoveSpeedX(this.tempMoveSpeed);
			if (this.target != null)
			{
				this.target.SetPosition(base.owner.GetPosition(), true, true, false);
			}
		}
	}

	// Token: 0x06017E72 RID: 97906 RVA: 0x007657D1 File Offset: 0x00763BD1
	public override void OnFinish()
	{
		base.OnFinish();
		this.ClearHandle();
		this.RestoreTarget();
	}

	// Token: 0x06017E73 RID: 97907 RVA: 0x007657E8 File Offset: 0x00763BE8
	private void RestoreTarget()
	{
		if (this.target != null)
		{
			this.SetSkillBtn(true);
			this.target.TriggerEvent(BeEventType.onMechanism2050RestoreBtn, null);
			this.target.buffController.RemoveBuff(this.buffID, 0, 0);
			this.target.buffController.RemoveBuff(99, 0, 0);
			this.target.stateController.SetAbilityEnable(BeAbilityType.CHANGE_FACE, true);
			this.target.buffController.RemoveBuff(29, 0, 0);
			this.target.sgSwitchStates(new BeStateData(0, 0));
			this.target = null;
		}
	}

	// Token: 0x06017E74 RID: 97908 RVA: 0x00765884 File Offset: 0x00763C84
	private void ClearHandle()
	{
		for (int i = 0; i < this.handlList.Count; i++)
		{
			if (this.handlList[i] != null)
			{
				this.handlList[i].Remove();
				this.handlList[i] = null;
			}
		}
		this.handlList.Clear();
	}

	// Token: 0x04011341 RID: 70465
	private BeActor target;

	// Token: 0x04011342 RID: 70466
	private int monsterID;

	// Token: 0x04011343 RID: 70467
	private int moveXSpeed = 50000;

	// Token: 0x04011344 RID: 70468
	private int tempMoveSpeed;

	// Token: 0x04011345 RID: 70469
	private int entityID = 60478;

	// Token: 0x04011346 RID: 70470
	private int boomEntityID = 60464;

	// Token: 0x04011347 RID: 70471
	private int maxZpos = 30000;

	// Token: 0x04011348 RID: 70472
	private int recordHitNum;

	// Token: 0x04011349 RID: 70473
	private int maxHitNum = 5;

	// Token: 0x0401134A RID: 70474
	private int moveZSpeed = 100000;

	// Token: 0x0401134B RID: 70475
	private bool isInit;

	// Token: 0x0401134C RID: 70476
	private bool attackFlag;

	// Token: 0x0401134D RID: 70477
	private int buffID = 570028;

	// Token: 0x0401134E RID: 70478
	private List<BeEventHandle> handlList = new List<BeEventHandle>();
}
