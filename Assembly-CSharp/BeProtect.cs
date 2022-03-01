using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;

// Token: 0x020041A3 RID: 16803
public class BeProtect
{
	// Token: 0x0601710A RID: 94474 RVA: 0x007132B4 File Offset: 0x007116B4
	public BeProtect(BeActor owner)
	{
		this.actor = owner;
		this.floatHurtPercent = (VRate)Global.Settings.defaultFloatHurt;
		this.floatHurtLevelPercent = (VRate)Global.Settings.defaultFloatLevelHurat;
		this.groundHurtPercent = (VRate)Global.Settings.defaultGroundHurt;
		this.standHurtPercent = (VRate)Global.Settings.defaultStandHurt;
		this.InitSwitchData();
		this.InitRegistEvent();
	}

	// Token: 0x0601710B RID: 94475 RVA: 0x00713423 File Offset: 0x00711823
	public void SetValue(VRate floatHurtPercent, VRate floatHurtLevelPercent, VRate groundHurtPercent, VRate standHurtPercent)
	{
		if (!this.enable)
		{
			return;
		}
		this.floatHurtPercent = floatHurtPercent;
		this.floatHurtLevelPercent = floatHurtLevelPercent;
		this.groundHurtPercent = groundHurtPercent;
		this.standHurtPercent = standHurtPercent;
	}

	// Token: 0x0601710C RID: 94476 RVA: 0x00713450 File Offset: 0x00711850
	public void SetEnable(bool flag)
	{
		this.enable = flag;
		if (this.enable && BattleMain.IsProtectFloat(this.actor.battleType) && this.actor.GetMechanism(6228) == null)
		{
			this.actor.AddMechanism(6228, 0, MechanismSourceType.NONE, null, 0);
		}
	}

	// Token: 0x0601710D RID: 94477 RVA: 0x007134AE File Offset: 0x007118AE
	public bool IsEnable()
	{
		return this.enable;
	}

	// Token: 0x17001F74 RID: 8052
	// (get) Token: 0x0601710E RID: 94478 RVA: 0x007134B6 File Offset: 0x007118B6
	public bool FallHurtCounting
	{
		get
		{
			return this.fallHurtCounting;
		}
	}

	// Token: 0x17001F75 RID: 8053
	// (get) Token: 0x0601710F RID: 94479 RVA: 0x007134BE File Offset: 0x007118BE
	public int FallHurtEffect
	{
		get
		{
			return this.fallHurtEffect;
		}
	}

	// Token: 0x06017110 RID: 94480 RVA: 0x007134C6 File Offset: 0x007118C6
	public void Tick(int deltaTime)
	{
		if (!this.enable)
		{
			return;
		}
		this.UpdateSleepBuffProtectTime(deltaTime);
		this.UpdateCheckClearProtect(deltaTime);
		this.UpdateDelayClearFallProtect(deltaTime);
		this.UpdateTryToGetUp(deltaTime);
		this.UpdateHardTime(deltaTime);
		this.UpdateMissProtect(deltaTime);
	}

	// Token: 0x06017111 RID: 94481 RVA: 0x00713500 File Offset: 0x00711900
	public void Update(int hurtValue)
	{
		if (!this.enable)
		{
			return;
		}
		int ground = 0;
		int fall = 0;
		int stand = 0;
		bool flag = true;
		if (this.actor.HasTag(4))
		{
			if (!this.isTringToGetUp)
			{
				this.groundHurtCount += hurtValue;
				ground = hurtValue;
			}
			flag = false;
		}
		if (this.actor.HasTag(1))
		{
			this.fallHurtCount += hurtValue;
			fall = hurtValue;
			flag = false;
		}
		if (flag)
		{
			this.standHurtCount += hurtValue;
			stand = hurtValue;
		}
		else
		{
			this.ClearStandProtect();
		}
		this.UpdateHurtProtect(ground, fall, stand);
		this.StartCheckClearProtect();
	}

	// Token: 0x06017112 RID: 94482 RVA: 0x007135A4 File Offset: 0x007119A4
	public void StartFallHurtCount()
	{
		if (!this.enable || this.fallHurtCounting)
		{
			return;
		}
		this.fallHurtCount = 0;
		this.fallHurtCounting = true;
		this.fallHurtEffect = 0;
		this.accTimeAfterGetUp = 0;
		this.fallZAccFold = 0;
		this.actor.m_pkGeActor.ShowProtectFloat(true, this.floatHurtPercent.scalar);
	}

	// Token: 0x06017113 RID: 94483 RVA: 0x00713608 File Offset: 0x00711A08
	public void StartGroundHurtCount()
	{
		if (!this.enable || this.groundHurtCounting)
		{
			return;
		}
		if (this.isTringToGetUp)
		{
			return;
		}
		this.groundHurtCount = 0;
		this.groundHurtCounting = true;
		this.timeAccTringToGetUp = 0;
		this.actor.m_pkGeActor.ShowProtectGround(true, this.groundHurtPercent.scalar);
	}

	// Token: 0x06017114 RID: 94484 RVA: 0x0071366C File Offset: 0x00711A6C
	public void StartStandHurtCount()
	{
		if (!this.enable || this.standHurtCounting)
		{
			return;
		}
		this.standHurtCount = 0;
		this.standHurtCounting = true;
		this.actor.m_pkGeActor.ShowProtectStand(true, this.standHurtPercent.scalar);
	}

	// Token: 0x06017115 RID: 94485 RVA: 0x007136BA File Offset: 0x00711ABA
	public void ClearProtect()
	{
		if (!this.enable)
		{
			return;
		}
		this.ClearGroundProtectCounting();
		this.ClearStandProtect();
	}

	// Token: 0x06017116 RID: 94486 RVA: 0x007136D4 File Offset: 0x00711AD4
	public void ClearUp()
	{
		if (!this.enable)
		{
			return;
		}
		this.ClearGroundProtect();
		this.ClearFallProtect();
		this.ClearStandProtect();
	}

	// Token: 0x06017117 RID: 94487 RVA: 0x007136F4 File Offset: 0x00711AF4
	public void ClearFallProtect()
	{
		if (!this.enable)
		{
			return;
		}
		if (this.fallHurtCounting)
		{
			this.fallHurtCounting = false;
			this.fallHurtEffect = 0;
			this.actor.ResetWeight();
		}
		this.accTimeAfterGetUp = 0;
		this.fallZAccFold = 0;
		this.actor.m_pkGeActor.ShowProtectFloat(false, 0f);
	}

	// Token: 0x06017118 RID: 94488 RVA: 0x00713755 File Offset: 0x00711B55
	public void DelayClearFallProtect()
	{
		if (!this.enable)
		{
			return;
		}
		if (!this.fallHurtCounting)
		{
			return;
		}
		this.accTimeAfterGetUp = this.fallClrTimeAfterGetUp;
	}

	// Token: 0x06017119 RID: 94489 RVA: 0x0071377C File Offset: 0x00711B7C
	private void UpdateDelayClearFallProtect(int dt)
	{
		if (!this.enable)
		{
			return;
		}
		if (this.accTimeAfterGetUp < 1)
		{
			return;
		}
		if (this.actor.GetPosition().z > 0 && !this.actor.isFloating)
		{
			this.accTimeAfterGetUp = this.fallClrTimeAfterGetUp;
			return;
		}
		this.accTimeAfterGetUp -= dt;
		if (this.accTimeAfterGetUp > 0)
		{
			return;
		}
		this.accTimeAfterGetUp = 0;
		this.ClearFallProtect();
	}

	// Token: 0x0601711A RID: 94490 RVA: 0x00713800 File Offset: 0x00711C00
	public void ClearGroundProtect()
	{
		if (!this.enable)
		{
			return;
		}
		if (this.groundHurtCounting)
		{
			this.groundHurtCounting = false;
		}
		this.isTringToGetUp = false;
		this.timeAccTringToGetUp = 0;
		this.actor.m_pkGeActor.ShowProtectGround(false, 0f);
	}

	// Token: 0x0601711B RID: 94491 RVA: 0x0071384F File Offset: 0x00711C4F
	private void ClearGroundProtectCounting()
	{
		if (!this.enable)
		{
			return;
		}
		if (this.groundHurtCounting)
		{
			this.groundHurtCounting = false;
		}
	}

	// Token: 0x0601711C RID: 94492 RVA: 0x00713870 File Offset: 0x00711C70
	private void UpdateTryToGetUp(int dt)
	{
		if (!this.enable)
		{
			return;
		}
		if (!this.isTringToGetUp)
		{
			return;
		}
		if (this.actor.buffController.HasBuffByID(101) != null)
		{
			return;
		}
		if (!this.actor.HasTag(4) || this.actor.IsGrabed())
		{
			this.timeAccTringToGetUp = 0;
			return;
		}
		int z = this.actor.GetPosition().z;
		int num = VInt.Float2VIntValue(0.0001f);
		if (z <= num)
		{
			this.timeAccTringToGetUp += dt;
			if (this.timeAccTringToGetUp < this.timeAccTringToGetUpMax)
			{
				return;
			}
			if (this.actor.CurrentBeBattle == null || this.actor.CurrentBeBattle.GetBattleType() != BattleType.PVP3V3Battle || this.actor.attribute == null || this.actor.attribute.GetHP() <= 0)
			{
			}
			this.ClearGroundProtect();
			this.actor.sgClearStateStack();
			this.actor.sgPushState(new BeStateData(17, 0));
			this.actor.sgLocomoteState();
			this.actor.buffController.RemoveBuff(7, 0, 0);
			this.actor.buffController.TryAddBuff(2, GlobalLogic.VALUE_1000, 1);
		}
	}

	// Token: 0x0601711D RID: 94493 RVA: 0x007139C4 File Offset: 0x00711DC4
	public void ClearStandProtect()
	{
		if (!this.enable)
		{
			return;
		}
		if (this.standHurtCounting)
		{
			this.standHurtCounting = false;
		}
		if (this.actor.m_pkGeActor != null)
		{
			this.actor.m_pkGeActor.ShowProtectStand(false, 0f);
		}
		else
		{
			Logger.LogErrorFormat("ClearStandProtect jobID:{0}", new object[]
			{
				this.actor.professionID
			});
		}
	}

	// Token: 0x0601711E RID: 94494 RVA: 0x00713A40 File Offset: 0x00711E40
	private void FallHurtTakeEffect()
	{
		if (!this.enable)
		{
			return;
		}
		BeEntityData entityData = this.actor.GetEntityData();
		if (this.fallZAccFold > 9)
		{
			return;
		}
		this.fallZAccFold++;
		this.actor.moveZAcc += entityData.weight;
		this.fallHurtEffect++;
		this.fallHurtCount -= entityData.battleData.maxHp * this.floatHurtLevelPercent.factor;
	}

	// Token: 0x0601711F RID: 94495 RVA: 0x00713AD8 File Offset: 0x00711ED8
	private void UpdateHurtProtect(int ground = 0, int fall = 0, int stand = 0)
	{
		if (!this.enable)
		{
			return;
		}
		if (this.actor == null)
		{
			return;
		}
		BeEntityData entityData = this.actor.GetEntityData();
		if (entityData == null)
		{
			return;
		}
		if (this.fallHurtCounting)
		{
			if (this.fallHurtEffect >= 1)
			{
				if (this.fallHurtCount > entityData.battleData.maxHp * this.floatHurtLevelPercent.factor)
				{
					this.FallHurtTakeEffect();
				}
			}
			else if (this.fallHurtCount > entityData.battleData.maxHp * this.floatHurtPercent.factor)
			{
				this.FallHurtTakeEffect();
			}
			if (this.fallZAccFold > 0)
			{
				VFactor a = new VFactor((long)((int)((long)this.actor.moveZAcc)), (long)((int)((long)entityData.weight)));
				if (a < (long)(this.fallZAccFold + 1))
				{
					this.actor.moveZAcc = entityData.weight.i * (this.fallZAccFold + 1);
				}
			}
			if (fall > 0 && this.fallHurtEffect < 1)
			{
				float num = this.floatHurtPercent.scalar - (float)(this.fallHurtCount - fall) / (float)entityData.battleData.maxHp;
				if (num >= 0f && this.actor.m_pkGeActor != null)
				{
					this.actor.m_pkGeActor.ShowProtectFloat(true, num);
				}
			}
		}
		if (this.groundHurtCounting)
		{
			if (this.groundHurtCount > entityData.battleData.maxHp * this.groundHurtPercent.factor && !this.actor.IsGrabed())
			{
				this.groundHurtCounting = false;
				this.isTringToGetUp = true;
			}
			if (ground > 0)
			{
				float num2 = this.groundHurtPercent.scalar - (float)(this.groundHurtCount - ground) / (float)entityData.battleData.maxHp;
				if (num2 >= 0f && this.actor.m_pkGeActor != null)
				{
					this.actor.m_pkGeActor.ShowProtectGround(true, num2);
				}
			}
		}
		if (this.standHurtCounting && this.actor.buffController.HasBuffByID(101) == null)
		{
			if (this.standHurtCount > entityData.GetMaxHP() * this.standHurtPercent.factor && !this.actor.IsGrabed())
			{
				this.actor.ClearMoveSpeed(7);
				this.actor.sgClearStateStack();
				this.actor.sgPushState(new BeStateData(11, 0));
				for (int i = 11; i <= 14; i++)
				{
					BeBuff beBuff = this.actor.buffController.HasBuffByType((BuffType)i);
					if (beBuff != null)
					{
						this.actor.buffController.RemoveBuff(beBuff);
					}
				}
				this.actor.sgLocomoteState();
				this.actor.buffController.TryAddBuff(34, GlobalLogic.VALUE_1000, 1);
				this.standHurtCounting = false;
			}
			if (stand > 0)
			{
				float num3 = this.standHurtPercent.scalar - (float)(this.standHurtCount - stand) / (float)entityData.battleData.maxHp;
				if (num3 >= 0f && this.actor.m_pkGeActor != null)
				{
					this.actor.m_pkGeActor.ShowProtectStand(true, num3);
				}
			}
		}
	}

	// Token: 0x06017120 RID: 94496 RVA: 0x00713E5F File Offset: 0x0071225F
	public void ResetFallTime()
	{
		this.accTimeAfterGetUp = 0;
	}

	// Token: 0x06017121 RID: 94497 RVA: 0x00713E68 File Offset: 0x00712268
	public bool IsAfterGetUpFallCounting()
	{
		return this.accTimeAfterGetUp > 0;
	}

	// Token: 0x06017122 RID: 94498 RVA: 0x00713E73 File Offset: 0x00712273
	private void StartCheckClearProtect()
	{
		if (!this.enable)
		{
			return;
		}
		this.checkClearProtect = true;
		this.timeAcc = 0;
	}

	// Token: 0x06017123 RID: 94499 RVA: 0x00713E90 File Offset: 0x00712290
	private void UpdateCheckClearProtect(int delta)
	{
		if (!this.enable)
		{
			return;
		}
		if (!this.checkClearProtect)
		{
			return;
		}
		this.timeAcc += delta;
		if ((float)this.timeAcc > Global.Settings.protectClearDuration)
		{
			this.ClearProtect();
			this.StopCheckClearProtect();
		}
	}

	// Token: 0x06017124 RID: 94500 RVA: 0x00713EE5 File Offset: 0x007122E5
	private void StopCheckClearProtect()
	{
		if (!this.enable)
		{
			return;
		}
		if (!this.checkClearProtect)
		{
			return;
		}
		this.checkClearProtect = false;
		this.timeAcc = 0;
	}

	// Token: 0x06017125 RID: 94501 RVA: 0x00713F10 File Offset: 0x00712310
	private void InitSwitchData()
	{
		this.abnormalBuffProtectSwitch = BeClientSwitch.FunctionIsOpen(ClientSwitchType.PkAbnormalBuffProtect);
		this.hardProtectSwitch = BeClientSwitch.FunctionIsOpen(ClientSwitchType.HardProtect);
		if (this.actor == null || this.actor.CurrentBeBattle == null || this.actor.CurrentBeBattle.PkRaceType != 8)
		{
			return;
		}
		SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(655, string.Empty, string.Empty);
		if (tableItem != null)
		{
			this.floatHurtPercent = new VRate(tableItem.Value);
		}
		tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(656, string.Empty, string.Empty);
		if (tableItem != null)
		{
			this.floatHurtLevelPercent = new VRate(tableItem.Value);
		}
		tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(657, string.Empty, string.Empty);
		if (tableItem != null)
		{
			this.groundHurtPercent = new VRate(tableItem.Value);
		}
		tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(658, string.Empty, string.Empty);
		if (tableItem != null)
		{
			this.standHurtPercent = new VRate(tableItem.Value);
		}
	}

	// Token: 0x06017126 RID: 94502 RVA: 0x0071402D File Offset: 0x0071242D
	public bool IsInGroundProtect()
	{
		return this.isTringToGetUp;
	}

	// Token: 0x06017127 RID: 94503 RVA: 0x0071403D File Offset: 0x0071243D
	public void BeHit()
	{
		this.RegistPVPMissBeHit();
		this.RegisterHardProtectBeHit();
		this.RegisterAbnormalProtectBeHit();
	}

	// Token: 0x06017128 RID: 94504 RVA: 0x00714051 File Offset: 0x00712451
	public void AddBuff(BuffType type)
	{
		if (!this.CheckAbnormalProtectOpen())
		{
			return;
		}
		if (!this.IsControlBuff(type))
		{
			return;
		}
		this.AddProtectBuffSingle(type);
		if (this.CheckProtectBuff())
		{
			this.RefreshProtectBuffTime();
		}
	}

	// Token: 0x06017129 RID: 94505 RVA: 0x00714084 File Offset: 0x00712484
	public void RegisterAbnormalProtectBeHit()
	{
		if (!this.CheckAbnormalProtectOpen())
		{
			return;
		}
		if (this.CheckProtectBuff())
		{
			this.RefreshProtectBuffTime();
		}
	}

	// Token: 0x0601712A RID: 94506 RVA: 0x007140A4 File Offset: 0x007124A4
	private void UpdateSleepBuffProtectTime(int deltaTime)
	{
		this.acc += deltaTime;
		if (this.acc >= this.sleepRefreshProtectTime)
		{
			this.acc = 0;
			if (this.actor.stateController.HasBuffState(BeBuffStateType.SLEEP))
			{
				this.RefreshSleepProtectBuffTime();
			}
		}
	}

	// Token: 0x0601712B RID: 94507 RVA: 0x007140F7 File Offset: 0x007124F7
	private void RefreshSleepProtectBuffTime()
	{
		if (!this.CheckAbnormalProtectOpen())
		{
			return;
		}
		if (this.actor.buffController.HasBuffByID(this.buffIdArr[3]) != null)
		{
			this.RefreshSleepProtectBuff();
		}
	}

	// Token: 0x0601712C RID: 94508 RVA: 0x00714128 File Offset: 0x00712528
	private void RefreshSleepProtectBuff()
	{
		foreach (BeBuff beBuff in this.actor.buffController.GetBuffList())
		{
			if (beBuff != null && !beBuff.CanRemove() && beBuff.buffID == this.buffIdArr[3])
			{
				beBuff.RefreshDuration(beBuff.duration);
			}
		}
	}

	// Token: 0x0601712D RID: 94509 RVA: 0x0071419C File Offset: 0x0071259C
	protected void AddProtectBuffSingle(BuffType type)
	{
		int buffID = 0;
		switch (type)
		{
		case BuffType.STUN:
			buffID = this.buffIdArr[0];
			break;
		case BuffType.STONE:
			buffID = this.buffIdArr[2];
			break;
		case BuffType.FROZEN:
			buffID = this.buffIdArr[1];
			break;
		case BuffType.SLEEP:
			buffID = this.buffIdArr[3];
			break;
		}
		BeBuff beBuff = this.actor.buffController.TryAddBuff(buffID, this.protectBuffTime, 1);
		if (beBuff != null)
		{
			this.protectBuffList.Add(beBuff);
		}
	}

	// Token: 0x0601712E RID: 94510 RVA: 0x0071422C File Offset: 0x0071262C
	protected bool CheckProtectBuff()
	{
		bool result = false;
		for (int i = 0; i < this.buffIdArr.Length; i++)
		{
			BeBuff beBuff = this.actor.buffController.HasBuffByID(this.buffIdArr[i]);
			if (beBuff != null)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x0601712F RID: 94511 RVA: 0x0071427B File Offset: 0x0071267B
	protected bool IsControlBuff(BuffType type)
	{
		return type == BuffType.FROZEN || type == BuffType.STONE || type == BuffType.STUN || type == BuffType.SLEEP;
	}

	// Token: 0x06017130 RID: 94512 RVA: 0x007142A0 File Offset: 0x007126A0
	protected void RefreshProtectBuffTime()
	{
		if (this.protectBuffList == null)
		{
			return;
		}
		for (int i = 0; i < this.protectBuffList.Count; i++)
		{
			BeBuff beBuff = this.protectBuffList[i];
			if (beBuff != null)
			{
				beBuff.RefreshDuration(beBuff.duration);
			}
		}
	}

	// Token: 0x06017131 RID: 94513 RVA: 0x007142F9 File Offset: 0x007126F9
	private bool CheckAbnormalProtectOpen()
	{
		return this.abnormalBuffProtectSwitch && this.enable && !this.actor.IsMonster();
	}

	// Token: 0x06017132 RID: 94514 RVA: 0x00714328 File Offset: 0x00712728
	private void RegistPVPMissBeHit()
	{
		this.startRecordTime = true;
		this.accJudgeTimer = 0;
	}

	// Token: 0x06017133 RID: 94515 RVA: 0x00714338 File Offset: 0x00712738
	private void InitRegistEvent()
	{
		this.actor.RegisterEvent(BeEventType.OnAttackResult, delegate(object[] args)
		{
			this.hitNums %= this.hitNumsLoop;
			if (this.hitNums == 0)
			{
				this.hasTriggerMiss = false;
			}
			this.hitNums++;
			int[] array = args[0] as int[];
			AttackResult attackResult = (AttackResult)array[0];
			if (attackResult != AttackResult.MISS)
			{
				if (this.hitNums <= this.hitNumsLoop && this.hasTriggerMiss)
				{
					return;
				}
				int num = this.actor.FrameRandom.InRange(1, 1000);
				int num2 = this.curMissRate / 3 * this.hitNums;
				if (num <= num2)
				{
					this.hasTriggerMiss = true;
					array[0] = 0;
				}
			}
			else
			{
				this.hasTriggerMiss = true;
			}
		});
	}

	// Token: 0x06017134 RID: 94516 RVA: 0x00714354 File Offset: 0x00712754
	private void UpdateMissProtect(int deltaTime)
	{
		if (!BattleMain.IsModePvP(this.actor.battleType))
		{
			return;
		}
		if (this.startRecordTime)
		{
			if (!this.actor.IsGrabed())
			{
				this.accJudgeTimer += deltaTime;
				if (this.accJudgeTimer >= this.judgeTime)
				{
					this.ResetMissProtect();
					return;
				}
			}
			this.accPtotectTime += deltaTime;
			if (this.accPtotectTime >= this.missProtectTime)
			{
				this.TriggerMissProtect(this.accPtotectTime);
			}
		}
	}

	// Token: 0x06017135 RID: 94517 RVA: 0x007143E3 File Offset: 0x007127E3
	private void ResetMissProtect()
	{
		this.startRecordTime = false;
		this.accJudgeTimer = 0;
		this.curMissRate = 0;
		this.accPtotectTime = 0;
	}

	// Token: 0x06017136 RID: 94518 RVA: 0x00714404 File Offset: 0x00712804
	private void TriggerMissProtect(int totalTime)
	{
		int num = Array.IndexOf<int>(this.missProtectTimeArr, totalTime / 1000);
		if (num < 0)
		{
			num = this.missProtectRateArr.Length - 1;
		}
		this.curMissRate = this.missProtectRateArr[num];
	}

	// Token: 0x06017137 RID: 94519 RVA: 0x00714444 File Offset: 0x00712844
	private void RegisterHardProtectBeHit()
	{
		if (!this.CheckHardProtectOpen())
		{
			return;
		}
		if (!this.hardProtectFlag)
		{
			this.StartHardTime();
		}
		else
		{
			this.ResetHardTime();
		}
		this.RefreshHardProtectBuff();
	}

	// Token: 0x06017138 RID: 94520 RVA: 0x00714474 File Offset: 0x00712874
	private void StartHardTime()
	{
		this.hardProtectFlag = true;
	}

	// Token: 0x06017139 RID: 94521 RVA: 0x00714480 File Offset: 0x00712880
	private void UpdateHardTime(int deltaTime)
	{
		if (!this.CheckHardProtectOpen())
		{
			return;
		}
		if (!this.hardProtectFlag)
		{
			return;
		}
		this.curHardProtectTime += deltaTime;
		if (this.curHardProtectTime >= this.hardProtectTime)
		{
			this.hardProtectFlag = false;
			this.curHardProtectTime = 0;
			this.ResetHardTimeAndCount();
		}
	}

	// Token: 0x0601713A RID: 94522 RVA: 0x007144D8 File Offset: 0x007128D8
	private void ResetHardTime()
	{
		this.curHardProtectTime = 0;
	}

	// Token: 0x0601713B RID: 94523 RVA: 0x007144E1 File Offset: 0x007128E1
	private void ResetHardTimeAndCount()
	{
		this.curHardProtectTime = 0;
		this.curHardProtectCount = 0;
	}

	// Token: 0x0601713C RID: 94524 RVA: 0x007144F4 File Offset: 0x007128F4
	private void RefreshHardProtectBuff()
	{
		this.curHardProtectCount++;
		if (this.curHardProtectCount >= this.hardProtectCountArr[3])
		{
			this.AddOrRefreshHardProtectBuff(3);
		}
		else if (this.curHardProtectCount >= this.hardProtectCountArr[2])
		{
			this.AddOrRefreshHardProtectBuff(2);
		}
		else if (this.curHardProtectCount >= this.hardProtectCountArr[1])
		{
			this.AddOrRefreshHardProtectBuff(1);
		}
		else if (this.curHardProtectCount >= this.hardProtectCountArr[0])
		{
			this.AddOrRefreshHardProtectBuff(0);
		}
	}

	// Token: 0x0601713D RID: 94525 RVA: 0x00714588 File Offset: 0x00712988
	private void AddOrRefreshHardProtectBuff(int index)
	{
		if (!this.CheckHardProtectOpen())
		{
			return;
		}
		int num = this.hardProtectBuffArr[index];
		if (this.actor.buffController.HasBuffByID(num) == null)
		{
			BeBuff item = this.actor.buffController.TryAddBuff(num, this.hardProtectBuffTime, 1);
			this.hardBuffList.Add(item);
		}
		else
		{
			this.RefreshAllHardProtectBuff();
		}
	}

	// Token: 0x0601713E RID: 94526 RVA: 0x007145F4 File Offset: 0x007129F4
	private void RefreshAllHardProtectBuff()
	{
		if (this.hardBuffList == null)
		{
			return;
		}
		for (int i = 0; i < this.hardBuffList.Count; i++)
		{
			BeBuff beBuff = this.hardBuffList[i];
			if (beBuff != null)
			{
				beBuff.RefreshDuration(beBuff.duration);
			}
		}
		this.hardBuffList.RemoveAll((BeBuff buff) => buff == null);
	}

	// Token: 0x0601713F RID: 94527 RVA: 0x00714678 File Offset: 0x00712A78
	public bool IsEnterHardProtect()
	{
		if (this.actor.HasTag(1))
		{
			return false;
		}
		int num = this.actor.GetEntityData().battleData.hard;
		return num >= this.hardProtectMax;
	}

	// Token: 0x06017140 RID: 94528 RVA: 0x007146BF File Offset: 0x00712ABF
	private bool CheckHardProtectOpen()
	{
		return this.hardProtectSwitch && this.enable && BattleMain.IsModePvP(this.actor.battleType);
	}

	// Token: 0x040109D6 RID: 68054
	protected BeActor actor;

	// Token: 0x040109D7 RID: 68055
	protected int fallHurtCount;

	// Token: 0x040109D8 RID: 68056
	protected int groundHurtCount;

	// Token: 0x040109D9 RID: 68057
	protected bool fallHurtCounting;

	// Token: 0x040109DA RID: 68058
	protected bool groundHurtCounting;

	// Token: 0x040109DB RID: 68059
	protected int fallHurtEffect;

	// Token: 0x040109DC RID: 68060
	protected int standHurtCount;

	// Token: 0x040109DD RID: 68061
	protected bool standHurtCounting;

	// Token: 0x040109DE RID: 68062
	protected VRate floatHurtPercent;

	// Token: 0x040109DF RID: 68063
	protected VRate floatHurtLevelPercent;

	// Token: 0x040109E0 RID: 68064
	protected VRate groundHurtPercent;

	// Token: 0x040109E1 RID: 68065
	protected VRate standHurtPercent;

	// Token: 0x040109E2 RID: 68066
	protected bool checkClearProtect;

	// Token: 0x040109E3 RID: 68067
	protected int timeAcc;

	// Token: 0x040109E4 RID: 68068
	protected bool enable;

	// Token: 0x040109E5 RID: 68069
	protected int fallClrTimeAfterGetUp = 1200;

	// Token: 0x040109E6 RID: 68070
	protected int accTimeAfterGetUp;

	// Token: 0x040109E7 RID: 68071
	protected int fallZAccFold;

	// Token: 0x040109E8 RID: 68072
	protected bool isTringToGetUp;

	// Token: 0x040109E9 RID: 68073
	protected int timeAccTringToGetUpMax = 167;

	// Token: 0x040109EA RID: 68074
	protected int timeAccTringToGetUp;

	// Token: 0x040109EB RID: 68075
	protected bool abnormalBuffProtectSwitch;

	// Token: 0x040109EC RID: 68076
	protected bool hardProtectSwitch;

	// Token: 0x040109ED RID: 68077
	protected bool missProtectSwitch;

	// Token: 0x040109EE RID: 68078
	protected int[] buffIdArr = new int[]
	{
		71,
		72,
		73,
		74
	};

	// Token: 0x040109EF RID: 68079
	protected List<BeBuff> protectBuffList = new List<BeBuff>();

	// Token: 0x040109F0 RID: 68080
	protected int protectBuffTime = 2500;

	// Token: 0x040109F1 RID: 68081
	private int sleepRefreshProtectTime = 1000;

	// Token: 0x040109F2 RID: 68082
	private int acc;

	// Token: 0x040109F3 RID: 68083
	private bool startRecordTime;

	// Token: 0x040109F4 RID: 68084
	private int judgeTime = 3000;

	// Token: 0x040109F5 RID: 68085
	private int missProtectTime = 10000;

	// Token: 0x040109F6 RID: 68086
	private int curMissRate;

	// Token: 0x040109F7 RID: 68087
	private int hitNumsLoop = 3;

	// Token: 0x040109F8 RID: 68088
	private bool hasTriggerMiss;

	// Token: 0x040109F9 RID: 68089
	private int[] missProtectTimeArr = new int[]
	{
		10,
		11,
		12,
		13,
		14,
		15,
		16,
		17,
		18,
		19,
		20,
		21
	};

	// Token: 0x040109FA RID: 68090
	private int[] missProtectRateArr = new int[]
	{
		10,
		20,
		30,
		40,
		50,
		60,
		70,
		80,
		100,
		120,
		200,
		500
	};

	// Token: 0x040109FB RID: 68091
	private int hitNums;

	// Token: 0x040109FC RID: 68092
	private int accJudgeTimer;

	// Token: 0x040109FD RID: 68093
	private int accPtotectTime;

	// Token: 0x040109FE RID: 68094
	private int[] hardProtectCountArr = new int[]
	{
		8,
		15,
		35,
		60
	};

	// Token: 0x040109FF RID: 68095
	private int[] hardProtectBuffArr = new int[]
	{
		79,
		80,
		81,
		82
	};

	// Token: 0x04010A00 RID: 68096
	private int curHardProtectCount;

	// Token: 0x04010A01 RID: 68097
	private int hardProtectTime = 3000;

	// Token: 0x04010A02 RID: 68098
	private int curHardProtectTime;

	// Token: 0x04010A03 RID: 68099
	private bool hardProtectFlag;

	// Token: 0x04010A04 RID: 68100
	private int hardProtectBuffTime = 3000;

	// Token: 0x04010A05 RID: 68101
	private int hardProtectMax = 4500;

	// Token: 0x04010A06 RID: 68102
	private List<BeBuff> hardBuffList = new List<BeBuff>();
}
