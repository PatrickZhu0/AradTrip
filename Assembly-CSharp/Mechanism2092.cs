using System;
using System.Collections.Generic;
using Battle;

// Token: 0x02004398 RID: 17304
public class Mechanism2092 : BeMechanism
{
	// Token: 0x06017FDA RID: 98266 RVA: 0x0076F2E8 File Offset: 0x0076D6E8
	public Mechanism2092(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017FDB RID: 98267 RVA: 0x0076F3E8 File Offset: 0x0076D7E8
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.mTargetHurtSet.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		this.mChaserType = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		if (this.data.ValueC.Count > 0)
		{
			this.m_TriggerCD = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		}
		if (this.data.ValueD.Count > 0)
		{
			this.mAddChaserType = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		}
		else
		{
			this.mAddChaserType = -1;
		}
		if (this.data.ValueE.Count > 0)
		{
			this.m_ChaserLevel = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		}
		if (this.data.ValueF.Count > 0)
		{
			this.m_ChaserAccSpeed = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
		}
	}

	// Token: 0x06017FDC RID: 98268 RVA: 0x0076F570 File Offset: 0x0076D970
	public override void OnStart()
	{
		if (base.owner == null)
		{
			return;
		}
		this.handleA = base.owner.RegisterEvent(BeEventType.onHitOtherAfterHurt, new BeEventHandle.Del(this.OnAttackResult));
	}

	// Token: 0x06017FDD RID: 98269 RVA: 0x0076F5A0 File Offset: 0x0076D9A0
	private void OnAttackResult(object[] args)
	{
		if (this.m_TriggerCD > 0 && this.m_CD.IsCD())
		{
			return;
		}
		AttackResult attackResult = (AttackResult)args[2];
		if (attackResult == AttackResult.CRITICAL)
		{
			int item = (int)args[1];
			if (this.mTargetHurtSet.Contains(item))
			{
				BeActor beActor = args[0] as BeActor;
				if (beActor != null && !beActor.IsDead())
				{
					this.LaunchChaser(beActor);
				}
				if (this.mAddChaserType != -2)
				{
					this.AddChaser();
				}
				if (this.m_TriggerCD > 0)
				{
					this.m_CD.StartCD(this.m_TriggerCD);
				}
			}
		}
	}

	// Token: 0x06017FDE RID: 98270 RVA: 0x0076F646 File Offset: 0x0076DA46
	public override void OnUpdate(int deltaTime)
	{
		if (this.m_TriggerCD > 0)
		{
			this.m_CD.UpdateCD(deltaTime);
		}
	}

	// Token: 0x06017FDF RID: 98271 RVA: 0x0076F660 File Offset: 0x0076DA60
	private void AddChaser()
	{
		if (this.chaserMgr == null)
		{
			this.chaserMgr = this.GetChaserMgr(base.owner);
		}
		if (this.chaserMgr == null)
		{
			return;
		}
		int type = this.mAddChaserType;
		if (this.mAddChaserType == -1)
		{
			type = (int)base.FrameRandom.Random(5U);
		}
		this.chaserMgr.AddChaserByExternal((Mechanism2072.ChaserType)type, Mechanism2072.ChaseSizeType.Normal, true);
	}

	// Token: 0x06017FE0 RID: 98272 RVA: 0x0076F6C4 File Offset: 0x0076DAC4
	private Mechanism2072 GetChaserMgr(BeActor owner)
	{
		if (owner == null)
		{
			return null;
		}
		BeMechanism mechanism = owner.GetMechanism(Mechanism2072.ChaserMgrID);
		if (mechanism == null)
		{
			return null;
		}
		return mechanism as Mechanism2072;
	}

	// Token: 0x06017FE1 RID: 98273 RVA: 0x0076F6F8 File Offset: 0x0076DAF8
	private bool LaunchChaser(BeActor target)
	{
		BeProjectile projectile = this.GetProjectile(target);
		if (projectile == null)
		{
			return false;
		}
		projectile.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this.OnChaserFlyComplete));
		return true;
	}

	// Token: 0x06017FE2 RID: 98274 RVA: 0x0076F72C File Offset: 0x0076DB2C
	private void OnChaserFlyComplete(object[] args)
	{
		BeProjectile beProjectile = args[0] as BeProjectile;
		if (beProjectile == null)
		{
			return;
		}
		this.CreateBoomProjectile(beProjectile);
	}

	// Token: 0x06017FE3 RID: 98275 RVA: 0x0076F750 File Offset: 0x0076DB50
	private BeProjectile GetProjectile(BeActor target)
	{
		if (base.owner == null)
		{
			return null;
		}
		BeProjectile beProjectile = base.owner.AddEntity(this.mChaserPathResID, this.GetAnchorWorldPos(this.mChaserLaunchPos), this.GetLevel(), 10000) as BeProjectile;
		if (beProjectile == null)
		{
			return null;
		}
		beProjectile.SetFace(base.owner.GetPosition().x > target.GetPosition().x, false, false);
		beProjectile.ClearMoveSpeed(7);
		AccelerateFollowTarget accelerateFollowTarget = new AccelerateFollowTarget();
		accelerateFollowTarget.StartPoint = beProjectile.GetPosition();
		accelerateFollowTarget.m_AccSpeed = this.m_ChaserAccSpeed;
		if (target.attribute != null)
		{
			accelerateFollowTarget.offsetHeight = target.attribute.height / 2;
		}
		accelerateFollowTarget.Init();
		accelerateFollowTarget.owner = beProjectile;
		accelerateFollowTarget.target = target;
		beProjectile.trail = accelerateFollowTarget;
		beProjectile.hurtID = 0;
		this.CreateLightEffect(this.mChaserType);
		this.PlayAudio(this.mChaserType);
		if (beProjectile.m_pkGeActor != null)
		{
			GeEffectEx geEffectEx = beProjectile.m_pkGeActor.CreateEffect(this.m_ChaserPathArr[this.mChaserType], "[actor]origin", 1E+09f, Vec3.zero, 1f, 1f, false, false, EffectTimeType.BUFF, false);
			if (geEffectEx != null)
			{
				geEffectEx.SetScale(1f);
			}
		}
		return beProjectile;
	}

	// Token: 0x06017FE4 RID: 98276 RVA: 0x0076F8B0 File Offset: 0x0076DCB0
	private void CreateLightEffect(int type)
	{
		if (this.mChaserLightEffect.Length <= type || type < 0)
		{
			return;
		}
		if (base.owner == null || base.owner.m_pkGeActor == null)
		{
			return;
		}
		string effectPath = this.mChaserLightEffect[type];
		GeEffectEx geEffectEx = base.owner.m_pkGeActor.CreateEffect(effectPath, "[actor]Orign", 0f, Vec3.zero, 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
		if (geEffectEx != null)
		{
			GeUtility.AttachTo(geEffectEx.GetRootNode(), base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root), false);
			geEffectEx.SetPosition(this.GetAnchorWorldPos(this.mChaserLaunchPos).vector3);
		}
	}

	// Token: 0x06017FE5 RID: 98277 RVA: 0x0076F964 File Offset: 0x0076DD64
	private void PlayAudio(int type)
	{
		if (this.mChaserLightSfx.Length <= type || type < 0)
		{
			return;
		}
		MonoSingleton<AudioManager>.instance.PlaySound(this.mChaserLightSfx[type]);
		base.owner.delayCaller.DelayCall(100, delegate
		{
			if (this.mChaserLaunchSfx.Length <= type)
			{
				return;
			}
			MonoSingleton<AudioManager>.instance.PlaySound(this.mChaserLaunchSfx[type]);
		}, 0, 0, false);
	}

	// Token: 0x06017FE6 RID: 98278 RVA: 0x0076F9E0 File Offset: 0x0076DDE0
	private void CreateBoomProjectile(BeProjectile proj)
	{
		if (base.owner == null)
		{
			return;
		}
		int[] array = new int[]
		{
			63733,
			63735,
			63741,
			63739,
			63737
		};
		if (this.mChaserType >= array.Length)
		{
			return;
		}
		int entityID = array[this.mChaserType];
		BeEntity beEntity = base.owner.AddEntity(entityID, proj.GetPosition(), this.GetLevel(), 0);
		if (beEntity != null)
		{
			beEntity.SetScale(1);
		}
	}

	// Token: 0x06017FE7 RID: 98279 RVA: 0x0076FA50 File Offset: 0x0076DE50
	private int GetLevel()
	{
		if (this.m_ChaserLevel > 0)
		{
			return this.m_ChaserLevel;
		}
		if (base.owner == null)
		{
			return 1;
		}
		int num = base.owner.GetSkillLevel(2302);
		if (num <= 0)
		{
			num = 1;
		}
		return num;
	}

	// Token: 0x06017FE8 RID: 98280 RVA: 0x0076FA98 File Offset: 0x0076DE98
	private VInt3 GetAnchorWorldPos(VInt3 pos)
	{
		if (base.owner == null)
		{
			return VInt3.zero;
		}
		pos.x = ((!base.owner.GetFace()) ? pos.x : (pos.x * -1));
		return base.owner.GetPosition() + pos;
	}

	// Token: 0x04011472 RID: 70770
	private readonly int mChaserPathResID = 63748;

	// Token: 0x04011473 RID: 70771
	private readonly VInt3 mChaserLaunchPos = new VInt3(-0.752f, -0.38f, 1.811f);

	// Token: 0x04011474 RID: 70772
	private readonly string[] m_ChaserPathArr = new string[]
	{
		"Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_wu",
		"Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_guang",
		"Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_fire",
		"Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_ice",
		"Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_an"
	};

	// Token: 0x04011475 RID: 70773
	private CoolDown m_CD = new CoolDown();

	// Token: 0x04011476 RID: 70774
	private HashSet<int> mTargetHurtSet = new HashSet<int>();

	// Token: 0x04011477 RID: 70775
	private int mChaserType;

	// Token: 0x04011478 RID: 70776
	private int mAddChaserType = -1;

	// Token: 0x04011479 RID: 70777
	private int m_TriggerCD;

	// Token: 0x0401147A RID: 70778
	private int m_ChaserLevel = -1;

	// Token: 0x0401147B RID: 70779
	private int m_ChaserAccSpeed = 200;

	// Token: 0x0401147C RID: 70780
	private Mechanism2072 chaserMgr;

	// Token: 0x0401147D RID: 70781
	private readonly string[] mChaserLightEffect = new string[]
	{
		"Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_wu_fashe",
		"Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_guang_fashe",
		"Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_fire_fashe",
		"Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_ice_fashe",
		"Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_an_fashe"
	};

	// Token: 0x0401147E RID: 70782
	private readonly int[] mChaserLightSfx = new int[]
	{
		4731,
		4727,
		4730,
		4728,
		4729
	};

	// Token: 0x0401147F RID: 70783
	private readonly int[] mChaserLaunchSfx = new int[]
	{
		4704,
		4690,
		4698,
		4683,
		4681
	};
}
