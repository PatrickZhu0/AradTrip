using System;
using System.Collections.Generic;
using GameClient;
using GamePool;

// Token: 0x0200433A RID: 17210
public class Mechanism2004 : BeMechanism
{
	// Token: 0x06017CF8 RID: 97528 RVA: 0x0075A9D0 File Offset: 0x00758DD0
	public Mechanism2004(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017CF9 RID: 97529 RVA: 0x0075AA70 File Offset: 0x00758E70
	public override void OnInit()
	{
		base.OnInit();
		if (this.data.ValueA.Length >= 4)
		{
			for (int i = 0; i < this.reduceDamagePrecents.Length; i++)
			{
				this.reduceDamagePrecents[i] = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
			}
		}
	}

	// Token: 0x06017CFA RID: 97530 RVA: 0x0075AADC File Offset: 0x00758EDC
	public override void OnStart()
	{
		this.betrayTotal = 0;
		this.betrayCnt = 0;
		this.updateFlag = true;
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onHit, delegate(object[] args)
		{
			if (this.isBetray)
			{
				int[] array = args[0] as int[];
				BeEntity beEntity = args[2] as BeEntity;
				if (beEntity.IsSummonMonster())
				{
					return;
				}
				BeEntity owner = beEntity.GetOwner();
				if (owner.IsSummonMonster())
				{
					return;
				}
				if (owner != null)
				{
					BeActor beActor = owner as BeActor;
					if (beActor != null && beActor.isMainActor)
					{
						this.OnChangeResentmentValue(-this.hitMinusValue);
						if (this.showTip && base.owner.isLocalActor)
						{
							SystemNotifyManager.SysDungeonSkillTip("被队友攻击可有效降低背叛状态下的怨念值", 3f, false);
							this.showTip = false;
						}
					}
				}
			}
		});
		this.handleB = base.owner.RegisterEvent(BeEventType.onAfterFinalDamageNew, delegate(object[] args)
		{
			int[] array = args[0] as int[];
			BeActor beActor = args[1] as BeActor;
			if (beActor != null)
			{
				if (beActor.GetEntityData().isSummonMonster)
				{
					return;
				}
				BeActor beActor2 = beActor.GetOwner() as BeActor;
				if (beActor2 != null && beActor2.isMainActor)
				{
					Mechanism2004 mechanism = beActor2.GetMechanism(5300) as Mechanism2004;
					if (mechanism != null)
					{
						if (mechanism.IsBetray())
						{
							array[0] = 0;
						}
						Mechanism2004 mechanism2 = base.owner.GetMechanism(5300) as Mechanism2004;
						if (mechanism2 != null && mechanism2.IsBetray() && !mechanism.IsBetray() && base.owner != null && base.owner.CurrentBeBattle != null && base.owner.CurrentBeBattle.dungeonManager != null && base.owner.CurrentBeBattle.dungeonManager.GetDungeonDataManager() != null)
						{
							int diffID = base.owner.CurrentBeBattle.dungeonManager.GetDungeonDataManager().id.diffID;
							VFactor zero = VFactor.zero;
							if (diffID == 0)
							{
								zero = new VFactor((long)this.reduceDamagePrecents[0], 100L);
							}
							else if (diffID == 1)
							{
								zero = new VFactor((long)this.reduceDamagePrecents[1], 100L);
							}
							else if (diffID == 2)
							{
								zero = new VFactor((long)this.reduceDamagePrecents[2], 100L);
							}
							else if (diffID == 3)
							{
								zero = new VFactor((long)this.reduceDamagePrecents[3], 100L);
							}
							array[0] *= zero;
						}
					}
				}
			}
		});
		this.handleC = base.owner.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
		{
			BeBuff beBuff = args[0] as BeBuff;
			if (beBuff.buffID == this.buffID)
			{
				this.OnChangeResentmentValue(-this.buffMinusValue);
			}
		});
		BeEventHandle item = base.owner.RegisterEvent(BeEventType.BuffCanAdd, delegate(object[] args)
		{
			int[] array = args[0] as int[];
			int num = (int)args[1];
			if ((num == 521727 || num == 521728 || num == 521729) && this.HaveBuff(num))
			{
				array[0] = 1;
			}
		});
		BeEventHandle item2 = base.owner.RegisterEvent(BeEventType.onBuffBeforePostInit, delegate(object[] args)
		{
			BeBuff beBuff = args[0] as BeBuff;
			if (beBuff != null && (beBuff.buffID == 521826 || beBuff.buffID == 521847 || beBuff.buffID == 521828))
			{
				List<BeActor> list = ListPool<BeActor>.Get();
				base.owner.CurrentBeScene.FindMonsterByID(list, 30780031, true);
				for (int i = 0; i < list.Count; i++)
				{
					int num = 0;
					int num2 = beBuff.buffID;
					switch (num2)
					{
					case 521826:
						num = 521844;
						break;
					default:
						if (num2 == 521847)
						{
							num = 521845;
						}
						break;
					case 521828:
						num = 521846;
						break;
					}
					list[i].buffController.TryAddBuff(num, 100, 1);
				}
				ListPool<BeActor>.Release(list);
			}
		});
		BeEventHandle item3 = base.owner.RegisterEvent(BeEventType.onDead, delegate(object[] args)
		{
			this.OnChangeResentmentValue(-this.resentmentValue);
		});
		BeEventHandle item4 = base.owner.RegisterEvent(BeEventType.onRemoveBuff, delegate(object[] args)
		{
			int num = (int)args[0];
			if (num == 521828)
			{
				this.OnChangeResentmentValue(-this.resentmentValue);
			}
		});
		BeEventHandle item5 = base.owner.RegisterEvent(BeEventType.OnBeforePassDoor, delegate(object[] args)
		{
			if (base.owner.isLocalActor && base.owner.CurrentBeBattle != null && base.owner.CurrentBeBattle.dungeonManager != null && base.owner.CurrentBeBattle.dungeonManager.GetDungeonDataManager() != null)
			{
				int num = base.owner.CurrentBeBattle.dungeonManager.GetDungeonDataManager().CurrentAreaID();
				if (this.roomIDList.Contains(num))
				{
					return;
				}
				this.roomIDList.Add(num);
				Singleton<GameStatisticManager>.instance.SendBatrayCount(this.betrayCnt.ToString(), string.Format("running_{0}", num));
				this.betrayCnt = 0;
			}
		});
		this.handList.Add(item2);
		this.handList.Add(item3);
		this.handList.Add(item4);
		this.handList.Add(item5);
		this.handList.Add(item);
	}

	// Token: 0x06017CFB RID: 97531 RVA: 0x0075AC28 File Offset: 0x00759028
	private bool HaveBuff(int id)
	{
		return base.owner.buffController != null && (base.owner.buffController.HasBuffByID(521727) != null || base.owner.buffController.HasBuffByID(521728) != null || base.owner.buffController.HasBuffByID(521729) != null);
	}

	// Token: 0x06017CFC RID: 97532 RVA: 0x0075AC99 File Offset: 0x00759099
	public void CopyMechanims(int value, bool isBetray)
	{
		this.resentmentValue = value;
		this.isBetray = isBetray;
	}

	// Token: 0x06017CFD RID: 97533 RVA: 0x0075ACAC File Offset: 0x007590AC
	public override void OnUpdate(int deltaTime)
	{
		this.UpdateShowTip(deltaTime);
		base.OnUpdate(deltaTime);
		if (!this.updateFlag)
		{
			return;
		}
		if (!this.isBetray)
		{
			this.timer += deltaTime;
			if (this.timer >= this.addIntervalTime)
			{
				this.timer = 0;
			}
		}
		else
		{
			this.timer += deltaTime;
			if (this.timer >= this.minusIntervalTime)
			{
				this.OnChangeResentmentValue(-this.timeMinusValue);
				this.timer = 0;
			}
		}
	}

	// Token: 0x06017CFE RID: 97534 RVA: 0x0075AD3C File Offset: 0x0075913C
	private void UpdateShowTip(int delta)
	{
		if (!this.showTip)
		{
			this.tipTime += delta;
			if (this.tipTime > this.totalTime)
			{
				this.showTip = true;
				this.tipTime = 0;
			}
		}
	}

	// Token: 0x06017CFF RID: 97535 RVA: 0x0075AD76 File Offset: 0x00759176
	public bool IsBetray()
	{
		return this.isBetray;
	}

	// Token: 0x06017D00 RID: 97536 RVA: 0x0075AD80 File Offset: 0x00759180
	public void OnChangeResentmentValue(int value)
	{
		if (base.owner.IsDead() && value > 0)
		{
			return;
		}
		if (this.resentmentValue >= this.resentmentMax && this.isBetray && value > 0)
		{
			return;
		}
		if (this.resentmentValue <= 0 && value < 0)
		{
			return;
		}
		if (this.tempPause)
		{
			return;
		}
		this.ShowResentmentValue(value);
		this.resentmentValue += value;
		if (this.resentmentValue >= this.resentmentMax)
		{
			this.resentmentValue = this.resentmentMax;
			this.tempPause = true;
			if (base.owner.isLocalActor)
			{
				SystemNotifyManager.SysDungeonSkillTip("即将背叛，注意不要误伤队友", 3f, false);
			}
			base.owner.CurrentBeScene.DelayCaller.DelayCall(3000, delegate
			{
				this.tempPause = false;
				this.isBetray = true;
				this.timer = 0;
				base.owner.buffController.TryAddBuff(this.effectBuffID, -1, 1);
				base.owner.stateController.ResetAttackAbility();
				base.owner.stateController.SetAbilityEnable(BeAbilityType.ATTACK_FRIEND_ENEMY, false);
			}, 0, 0, false);
		}
		else if (this.resentmentValue <= 0)
		{
			this.resentmentValue = 0;
			this.isBetray = false;
			this.timer = 0;
			base.owner.buffController.RemoveBuff(this.effectBuffID, 0, 0);
			base.owner.stateController.ResetAttackAbility();
			base.owner.stateController.SetAbilityEnable(BeAbilityType.ATTACK_FRIEND_ENEMY, true);
		}
		if (this.isBetray)
		{
			this.RefreshEnergrUI(value);
		}
		else
		{
			this.RemoveSpellBar();
		}
	}

	// Token: 0x06017D01 RID: 97537 RVA: 0x0075AEEC File Offset: 0x007592EC
	private void ShowResentmentValue(int value)
	{
		if (value == 1 || value == -1)
		{
			return;
		}
		ComCharactorHPBar comCharactorHPBar = base.owner.m_pkGeActor.mCurHpBar as ComCharactorHPBar;
		if (comCharactorHPBar != null)
		{
			comCharactorHPBar.ShowResentmentChange(value);
		}
	}

	// Token: 0x06017D02 RID: 97538 RVA: 0x0075AF34 File Offset: 0x00759334
	protected void RefreshEnergrUI(int value)
	{
		int spellBarDuration = base.owner.GetSpellBarDuration(eDungeonCharactorBar.MonsterEnergyBar);
		if (spellBarDuration <= 0)
		{
			this.bar = base.owner.StartSpellBar(eDungeonCharactorBar.MonsterEnergyBar, this.resentmentMax, true, string.Empty, true);
			this.bar.autoAcc = false;
			this.bar.reverseAutoAcc = false;
			this.bar.autodelete = false;
		}
		base.owner.AddSpellBarProgress(eDungeonCharactorBar.MonsterEnergyBar, (float)value / (float)this.resentmentMax);
	}

	// Token: 0x06017D03 RID: 97539 RVA: 0x0075AFB1 File Offset: 0x007593B1
	private void RemoveSpellBar()
	{
		if (this.bar != null)
		{
			base.owner.StopSpellBar(eDungeonCharactorBar.MonsterEnergyBar, true);
			this.bar = null;
		}
	}

	// Token: 0x06017D04 RID: 97540 RVA: 0x0075AFD3 File Offset: 0x007593D3
	public int GetResentmentValue()
	{
		return this.resentmentValue;
	}

	// Token: 0x06017D05 RID: 97541 RVA: 0x0075AFDB File Offset: 0x007593DB
	public void SetUpdateFlag(bool flag)
	{
		this.updateFlag = flag;
	}

	// Token: 0x06017D06 RID: 97542 RVA: 0x0075AFE4 File Offset: 0x007593E4
	private void RemoveHandle()
	{
		for (int i = 0; i < this.handList.Count; i++)
		{
			if (this.handList[i] != null)
			{
				this.handList[i].Remove();
				this.handList[i] = null;
			}
		}
		this.handList.Clear();
	}

	// Token: 0x06017D07 RID: 97543 RVA: 0x0075B047 File Offset: 0x00759447
	public override void OnFinish()
	{
		base.OnFinish();
		this.RemoveHandle();
	}

	// Token: 0x0401121E RID: 70174
	private int resentmentValue;

	// Token: 0x0401121F RID: 70175
	private int addIntervalTime = 2000;

	// Token: 0x04011220 RID: 70176
	private int minusIntervalTime = 600;

	// Token: 0x04011221 RID: 70177
	private int timeAddValue = 1;

	// Token: 0x04011222 RID: 70178
	private int hitAddValue = 10;

	// Token: 0x04011223 RID: 70179
	private int buffMinusValue = 100;

	// Token: 0x04011224 RID: 70180
	private int timeMinusValue = 1;

	// Token: 0x04011225 RID: 70181
	private int hitMinusValue = 5;

	// Token: 0x04011226 RID: 70182
	private int buffID;

	// Token: 0x04011227 RID: 70183
	private bool isBetray;

	// Token: 0x04011228 RID: 70184
	private int resentmentMax = 100;

	// Token: 0x04011229 RID: 70185
	private bool updateFlag = true;

	// Token: 0x0401122A RID: 70186
	private List<BeEventHandle> handList = new List<BeEventHandle>();

	// Token: 0x0401122B RID: 70187
	private int effectBuffID = 521871;

	// Token: 0x0401122C RID: 70188
	private List<int> roomIDList = new List<int>();

	// Token: 0x0401122D RID: 70189
	private bool showTip = true;

	// Token: 0x0401122E RID: 70190
	private int[] reduceDamagePrecents = new int[4];

	// Token: 0x0401122F RID: 70191
	public int betrayCnt;

	// Token: 0x04011230 RID: 70192
	public int betrayTotal;

	// Token: 0x04011231 RID: 70193
	private int timer;

	// Token: 0x04011232 RID: 70194
	private int totalTime = 6000;

	// Token: 0x04011233 RID: 70195
	private int tipTime;

	// Token: 0x04011234 RID: 70196
	private bool tempPause;

	// Token: 0x04011235 RID: 70197
	private SpellBar bar;
}
