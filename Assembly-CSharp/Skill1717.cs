using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x0200446C RID: 17516
public class Skill1717 : BeSkill
{
	// Token: 0x0601857E RID: 99710 RVA: 0x00795030 File Offset: 0x00793430
	public Skill1717(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601857F RID: 99711 RVA: 0x0079524C File Offset: 0x0079364C
	public override void OnInit()
	{
		this.shockTime = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.shockSpeed = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		this.shockRangeX = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
		this.shockRangeY = TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true);
		this.percent = TableManager.GetValueFromUnionCell(this.skillData.ValueE[0], base.level, true);
	}

	// Token: 0x06018580 RID: 99712 RVA: 0x00795310 File Offset: 0x00793710
	public VInt3 GetClostPoint(BeActor actor)
	{
		int num = int.MaxValue;
		int num2 = 0;
		VInt3 position = actor.GetPosition();
		for (int i = 0; i < this.pointsList.Length; i++)
		{
			VInt3 lhs = this.pointsList[i];
			int magnitude = (lhs - position).magnitude;
			if (magnitude < num)
			{
				num = magnitude;
				num2 = i;
			}
		}
		return this.pointsList[num2];
	}

	// Token: 0x06018581 RID: 99713 RVA: 0x0079538C File Offset: 0x0079378C
	public override void OnStart()
	{
		this.InitData();
		this.ModifyRadius();
		base.owner.grabPos = true;
		this.InitGrapPos();
		this.SetRuneManager();
		this.m_CanBoom = false;
		this.RemoveHandle();
		this.handle = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, delegate(object[] args)
		{
			BeProjectile beProjectile = args[0] as BeProjectile;
			if (beProjectile == null)
			{
				return;
			}
			if (beProjectile.m_iResID == this.targetEntityID || beProjectile.m_iResID == this.boomEntityID)
			{
				BeEventHandle item = beProjectile.RegisterEvent(BeEventType.onAfterCalFirstDamage, delegate(object[] obj)
				{
					if (!(bool)obj[1])
					{
						int num = this.percent;
						int[] array = (int[])obj[0];
						int i = array[0];
						int num2 = 0;
						if (this.runeManager != null)
						{
							num2 = this.runeManager.GetRuneCount();
						}
						num2 = base.owner.TriggerEventNew(BeEventType.onCalcRuneAddDamage, new EventParam
						{
							m_Int = this.skillID,
							m_Int2 = num2
						}).m_Int2;
						num *= num2 - 1;
						array[0] = i * (VFactor.one + VFactor.NewVFactor((long)num, (long)GlobalLogic.VALUE_1000));
					}
				});
				this.handleList.Add(item);
				if (beProjectile.m_iResID == this.targetEntityID)
				{
					base.owner.delayCaller.DelayCall(100, delegate
					{
						this.SetEntityIdleTime();
					}, 0, 0, false);
					beProjectile.SetTargetShockInfo(new ShockInfo
					{
						shockTime = (float)this.shockTime / 1000f,
						shockSpeed = (float)this.shockSpeed / 1000f,
						shockRangeX = (float)this.shockRangeX / 100f,
						shockRangeY = (float)this.shockRangeY / 100f
					});
					beProjectile.RegisterEvent(BeEventType.onDead, delegate(object[] obj)
					{
						this.control = false;
					});
					this.genBullete.Add(beProjectile);
					this.count++;
					if (this.count == this.maxCount)
					{
						this.control = true;
						this.InitPos();
						if (!BattleMain.IsModePvP(base.battleType))
						{
							this.AddButtonEffect();
						}
					}
				}
			}
		});
	}

	// Token: 0x06018582 RID: 99714 RVA: 0x007953EC File Offset: 0x007937EC
	private void InitData()
	{
		this.genBullete.Clear();
		this.maxRadius = new VInt(2f);
		this.maxCount = 5;
		this.count = 0;
		this.canMove = false;
		this.targets.Clear();
		this.time = 0;
		this.control = false;
		this.dis = VInt.zero;
		this.pi = VInt.zero;
		this.v0 = VFactor.zero;
		this.rSpeed = this.initSpeed;
		this.curFrame = 0;
	}

	// Token: 0x06018583 RID: 99715 RVA: 0x00795478 File Offset: 0x00793878
	public void ModifyRadius()
	{
		int num = GlobalLogic.VALUE_1000;
		VInt vint = 0;
		for (int i = 0; i < base.owner.MechanismList.Count; i++)
		{
			Mechanism129 mechanism = base.owner.MechanismList[i] as Mechanism129;
			if (mechanism != null)
			{
				num += mechanism.disRate;
				vint += mechanism.dis;
			}
		}
		this.maxRadius = this.maxRadius.i * VFactor.NewVFactor(num, GlobalLogic.VALUE_1000) + vint;
	}

	// Token: 0x06018584 RID: 99716 RVA: 0x00795514 File Offset: 0x00793914
	public void SetEntityIdleTime()
	{
		if (this.genBullete.Count <= 0)
		{
			return;
		}
		int uiTimeOut = this.genBullete[0].GetStateGraph().GetCurrentStateData().uiTimeOut;
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < base.owner.MechanismList.Count; i++)
		{
			Mechanism128 mechanism = base.owner.MechanismList[i] as Mechanism128;
			if (mechanism != null)
			{
				if (mechanism.time != 0)
				{
					num2 += mechanism.time;
				}
				if (mechanism.timeRate != 0)
				{
					num += mechanism.timeRate;
				}
			}
		}
		int num3 = (int)((float)uiTimeOut * VFactor.NewVFactor(num, GlobalLogic.VALUE_1000).single) + num2;
		for (int j = 0; j < this.genBullete.Count; j++)
		{
			if (this.genBullete[j].m_cpkCurEntityActionInfo != null)
			{
				this.genBullete[j].GetStateGraph().SetCurrentStatesTimeout(uiTimeOut + num3, true);
			}
		}
	}

	// Token: 0x06018585 RID: 99717 RVA: 0x00795630 File Offset: 0x00793A30
	private void InitGrapPos()
	{
		VInt3 position = base.owner.GetPosition();
		for (int i = 0; i < this.grapPosCount; i++)
		{
			this.pointsList[i] = this.initPointsList[i] + position;
		}
	}

	// Token: 0x06018586 RID: 99718 RVA: 0x00795688 File Offset: 0x00793A88
	public override bool CanUseSkill()
	{
		bool flag = false;
		if (this.runeManager == null)
		{
			this.SetRuneManager();
		}
		if (this.runeManager != null)
		{
			flag = (this.runeManager.GetRuneCount() > 0);
		}
		return base.CanUseSkill() && flag;
	}

	// Token: 0x06018587 RID: 99719 RVA: 0x007956D4 File Offset: 0x00793AD4
	public override BeActor.SkillCannotUseType GetCannotUseType()
	{
		bool flag = false;
		if (this.runeManager != null)
		{
			flag = (this.runeManager.GetRuneCount() > 0);
		}
		if (!flag)
		{
			return BeActor.SkillCannotUseType.NO_KEYING;
		}
		return base.GetCannotUseType();
	}

	// Token: 0x06018588 RID: 99720 RVA: 0x0079570C File Offset: 0x00793B0C
	private void SetRuneManager()
	{
		if (base.owner != null)
		{
			Skill1710 skill = base.owner.GetSkill(1710) as Skill1710;
			if (skill != null)
			{
				this.runeManager = skill.runeManager;
			}
		}
	}

	// Token: 0x06018589 RID: 99721 RVA: 0x0079574C File Offset: 0x00793B4C
	public override void OnEnterPhase(int phase)
	{
		this.curFrame = phase;
		if (phase == 2)
		{
			this.targets = base.owner.GrapedActorList;
			this.SetRunEffect();
			this.canMove = true;
		}
		if (phase == 3)
		{
			for (int i = 0; i < this.maxCount; i++)
			{
				base.owner.AddEntity(this.targetEntityID, base.owner.GetPosition(), 1, 0);
			}
		}
		if (phase != 3 || BattleMain.IsModePvP(base.battleType))
		{
			this.RemoveButtonEffect();
		}
	}

	// Token: 0x0601858A RID: 99722 RVA: 0x007957E0 File Offset: 0x00793BE0
	private void SetRunEffect()
	{
		if (this.runeManager == null)
		{
			return;
		}
		List<Rune> runeList = this.runeManager.getRuneList();
		for (int i = 0; i < runeList.Count; i++)
		{
			if (runeList[i] != null && runeList[i].effectRune != null)
			{
				runeList[i].effectRune.SetVisible(false);
			}
		}
	}

	// Token: 0x0601858B RID: 99723 RVA: 0x0079584C File Offset: 0x00793C4C
	public override void OnUpdate(int iDeltime)
	{
		if (this.control)
		{
			this.StartRotate();
		}
		if (this.canMove)
		{
			for (int i = 0; i < this.targets.Count; i++)
			{
				BeActor beActor = this.targets[i];
				if (beActor.stateController.CanMove())
				{
					VInt3 clostPoint = this.GetClostPoint(beActor);
					int i2 = this.y.i;
					VInt vint = new VInt(0.5f);
					clostPoint.z = i2 - vint.i;
					VInt3 position = beActor.GetPosition();
					VInt3 lhs = clostPoint - position;
					lhs.NormalizeTo(10000);
					VInt3 rkPos = position + lhs * this.speed;
					if ((beActor.GetPosition() - clostPoint).magnitude >= VInt.Float2VIntValue(0.1f))
					{
						beActor.SetPosition(rkPos, false, true, false);
					}
				}
			}
		}
		this.UpdateAttackBtnState(iDeltime);
		if (this.curFrame == 2)
		{
			this.AddBuff();
		}
		else if (this.curFrame == 4)
		{
			this.RemoveBuff();
		}
	}

	// Token: 0x0601858C RID: 99724 RVA: 0x0079597C File Offset: 0x00793D7C
	private void AddBuff()
	{
		if (base.owner != null)
		{
			for (int i = 0; i < base.owner.GrapedActorList.Count; i++)
			{
				BeActor beActor = base.owner.GrapedActorList[i];
				if (beActor.buffController.HasBuffByID(this.targetuffID) == null)
				{
					beActor.buffController.TryAddBuff(this.targetuffID, -1, 1);
				}
			}
		}
	}

	// Token: 0x0601858D RID: 99725 RVA: 0x007959F4 File Offset: 0x00793DF4
	private void RemoveBuff()
	{
		for (int i = 0; i < base.owner.GrapedActorList.Count; i++)
		{
			BeActor beActor = base.owner.GrapedActorList[i];
			beActor.buffController.RemoveBuff(this.targetuffID, 0, 0);
		}
	}

	// Token: 0x0601858E RID: 99726 RVA: 0x00795A48 File Offset: 0x00793E48
	private void UpdateAttackBtnState(int iDeltaTime)
	{
		if (this.time > 200 && this.rSpeed < this.maxRspeed)
		{
			this.rSpeed += this.stepRspeed;
			if (this.rSpeed > this.maxRspeed)
			{
				this.rSpeed = this.maxRspeed;
			}
			this.time = 0;
		}
		else
		{
			this.time += iDeltaTime;
		}
	}

	// Token: 0x0601858F RID: 99727 RVA: 0x00795ACE File Offset: 0x00793ECE
	public override void OnFinish()
	{
		this.canMove = false;
		base.owner.grabPos = false;
		this.RestoreData();
		this.SetRuneDead();
	}

	// Token: 0x06018590 RID: 99728 RVA: 0x00795AEF File Offset: 0x00793EEF
	protected void RestoreData()
	{
		this.RemoveButtonEffect();
		this.RestoreButton();
	}

	// Token: 0x06018591 RID: 99729 RVA: 0x00795B00 File Offset: 0x00793F00
	private void RemoveHandle()
	{
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
		for (int i = 0; i < this.handleList.Count; i++)
		{
			if (this.handleList[i] != null)
			{
				this.handleList[i].Remove();
				this.handleList[i] = null;
			}
		}
		this.handleList.Clear();
	}

	// Token: 0x06018592 RID: 99730 RVA: 0x00795B80 File Offset: 0x00793F80
	protected void AddButtonEffect()
	{
		base.owner.delayCaller.DelayCall(30, delegate
		{
			this.m_CanBoom = true;
			this.skillButtonState = BeSkill.SkillState.WAIT_FOR_NEXT_PRESS;
			this.pressMode = SkillPressMode.TWO_PRESS;
			if (base.button != null)
			{
				base.button.AddEffect(ETCButton.eEffectType.onContinue, false);
			}
		}, 0, 0, false);
	}

	// Token: 0x06018593 RID: 99731 RVA: 0x00795BA4 File Offset: 0x00793FA4
	protected void RemoveButtonEffect()
	{
		if (base.button != null)
		{
			base.button.RemoveEffect(ETCButton.eEffectType.onContinue, false);
		}
	}

	// Token: 0x06018594 RID: 99732 RVA: 0x00795BC4 File Offset: 0x00793FC4
	protected void RestoreButton()
	{
		this.m_CanBoom = false;
	}

	// Token: 0x06018595 RID: 99733 RVA: 0x00795BD0 File Offset: 0x00793FD0
	public override void OnCancel()
	{
		this.canMove = false;
		for (int i = 0; i < this.genBullete.Count; i++)
		{
			this.genBullete[i].DoDie();
		}
		this.RemoveBuff();
		this.RestoreData();
		this.SetRuneDead();
	}

	// Token: 0x06018596 RID: 99734 RVA: 0x00795C23 File Offset: 0x00794023
	private void SetRuneDead()
	{
		if (this.runeManager == null)
		{
			return;
		}
		this.runeManager.RemoveRune(false);
	}

	// Token: 0x06018597 RID: 99735 RVA: 0x00795C40 File Offset: 0x00794040
	public override void OnClickAgain()
	{
		if (!this.m_CanBoom)
		{
			return;
		}
		if (this.curFrame == 3 && !BattleMain.IsModePvP(base.battleType))
		{
			for (int i = 0; i < this.genBullete.Count; i++)
			{
				this.genBullete[i].DoDie();
			}
			(base.owner.GetStateGraph() as BeActorStateGraph).ExecuteNextPhaseSkill();
			this.RemoveButtonEffect();
			this.RestoreButton();
		}
	}

	// Token: 0x06018598 RID: 99736 RVA: 0x00795CC4 File Offset: 0x007940C4
	private void InitPos()
	{
		this.v0 = VFactor.pi * 2L / (long)this.genBullete.Count;
		for (int i = 1; i < this.genBullete.Count; i++)
		{
			this.genBullete[i].SetPosition(base.owner.GetPosition(), false, true);
		}
	}

	// Token: 0x06018599 RID: 99737 RVA: 0x00795D30 File Offset: 0x00794130
	private void StartRotate()
	{
		for (int i = 0; i < this.genBullete.Count; i++)
		{
			VFactor vfactor = this.pi.factor + this.v0 * (long)i;
			VInt vint = this.dis.i * IntMath.cos(vfactor.nom, vfactor.den);
			VInt vint2 = this.dis.i * IntMath.sin(vfactor.nom, vfactor.den);
			this.genBullete[i].SetPosition(new VInt3(vint2.i + base.owner.GetPosition().x, vint.i + base.owner.GetPosition().y, this.y.i), false, true);
		}
		this.dis += VInt.Float2VIntValue(0.1f);
		this.pi += ((!base.owner.GetFace()) ? (-this.rSpeed) : this.rSpeed);
		this.dis = VInt.Clamp(this.dis, 0, this.maxRadius);
	}

	// Token: 0x04011912 RID: 71954
	private VInt3[] pointsList = new VInt3[8];

	// Token: 0x04011913 RID: 71955
	private VInt3[] initPointsList = new VInt3[]
	{
		new VInt3(0f, 2f, 0f),
		new VInt3(-1.7f, 1.1f, 0f),
		new VInt3(-1.8f, -0.9f, 0f),
		new VInt3(-0.2f, -2f, 0f),
		new VInt3(1.6f, -1.2f, 0f),
		new VInt3(1.9f, 0.7f, 0f),
		new VInt3(0.4f, 2f, 0f),
		new VInt3(-1.5f, 1.3f, 0f)
	};

	// Token: 0x04011914 RID: 71956
	private List<BeProjectile> genBullete = new List<BeProjectile>();

	// Token: 0x04011915 RID: 71957
	public Mechanism22 runeManager;

	// Token: 0x04011916 RID: 71958
	private BeEventHandle handle;

	// Token: 0x04011917 RID: 71959
	private List<BeEventHandle> handleList = new List<BeEventHandle>();

	// Token: 0x04011918 RID: 71960
	private List<BeActor> targets = new List<BeActor>();

	// Token: 0x04011919 RID: 71961
	private int curFrame;

	// Token: 0x0401191A RID: 71962
	private int maxCount = 5;

	// Token: 0x0401191B RID: 71963
	private int count;

	// Token: 0x0401191C RID: 71964
	private int time;

	// Token: 0x0401191D RID: 71965
	private bool control;

	// Token: 0x0401191E RID: 71966
	private bool canMove;

	// Token: 0x0401191F RID: 71967
	private VInt dis = VInt.zero;

	// Token: 0x04011920 RID: 71968
	private VInt pi = VInt.zero;

	// Token: 0x04011921 RID: 71969
	private VFactor v0 = VFactor.zero;

	// Token: 0x04011922 RID: 71970
	private VInt rSpeed = new VInt(0.42f);

	// Token: 0x04011923 RID: 71971
	private VInt y = new VInt(2f);

	// Token: 0x04011924 RID: 71972
	private double speed = 0.1;

	// Token: 0x04011925 RID: 71973
	private VInt maxRadius = new VInt(2f);

	// Token: 0x04011926 RID: 71974
	private VInt maxRspeed = new VInt(0.42f);

	// Token: 0x04011927 RID: 71975
	private VInt stepRspeed = new VInt(0.025f);

	// Token: 0x04011928 RID: 71976
	private VInt initSpeed = new VInt(0.21f);

	// Token: 0x04011929 RID: 71977
	private int grapPosCount = 8;

	// Token: 0x0401192A RID: 71978
	private int shockTime;

	// Token: 0x0401192B RID: 71979
	private int shockSpeed;

	// Token: 0x0401192C RID: 71980
	private int shockRangeX;

	// Token: 0x0401192D RID: 71981
	private int shockRangeY;

	// Token: 0x0401192E RID: 71982
	protected bool m_CanBoom;

	// Token: 0x0401192F RID: 71983
	private int targetuffID = 171701;

	// Token: 0x04011930 RID: 71984
	private int targetEntityID = 60273;

	// Token: 0x04011931 RID: 71985
	private int boomEntityID = 60274;

	// Token: 0x04011932 RID: 71986
	private CrypticInt32 percent = 0;
}
