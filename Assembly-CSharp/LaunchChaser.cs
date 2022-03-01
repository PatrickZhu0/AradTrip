using System;
using System.Collections.Generic;
using Battle;
using GameClient;
using GamePool;

// Token: 0x0200449D RID: 17565
public class LaunchChaser
{
	// Token: 0x060186CA RID: 100042 RVA: 0x0079DB5C File Offset: 0x0079BF5C
	public void Init(BeActor owner, int level, int accSpeed)
	{
		if (owner == null)
		{
			return;
		}
		this.RemoveHandle();
		this.level = level;
		if (accSpeed > 0)
		{
			this.mTrailAccSpeed = accSpeed;
		}
		this.mOwner = owner;
		this.mHandle = owner.RegisterEvent(BeEventType.onHitOtherAfterHurt, delegate(object[] args)
		{
			BeActor beActor = args[0] as BeActor;
			if (beActor == null)
			{
				return;
			}
			if (beActor.IsDead())
			{
				return;
			}
			this.mTarget = beActor;
		});
		this.mProjectileChaserData.Clear();
	}

	// Token: 0x060186CB RID: 100043 RVA: 0x0079DBB8 File Offset: 0x0079BFB8
	private Mechanism2072 GetChaserMgr(BeActor owner)
	{
		BeMechanism mechanism = owner.GetMechanism(Mechanism2072.ChaserMgrID);
		if (mechanism == null)
		{
			return null;
		}
		return mechanism as Mechanism2072;
	}

	// Token: 0x060186CC RID: 100044 RVA: 0x0079DBE1 File Offset: 0x0079BFE1
	public bool CanLaunch()
	{
		return this.mTarget != null && !this.mTarget.IsDead();
	}

	// Token: 0x060186CD RID: 100045 RVA: 0x0079DC04 File Offset: 0x0079C004
	public bool Launch()
	{
		if (!this.CanLaunch())
		{
			return false;
		}
		if (this.mChaserMgr == null)
		{
			this.mChaserMgr = this.GetChaserMgr(this.mOwner);
			if (this.mChaserMgr == null)
			{
				return false;
			}
		}
		List<Mechanism2072.ChaserData> list = ListPool<Mechanism2072.ChaserData>.Get();
		this.mChaserMgr.LaunchChaser(1, list);
		if (list.Count <= 0)
		{
			ListPool<Mechanism2072.ChaserData>.Release(list);
			return false;
		}
		this.CreateLightEffect(list[0]);
		this.PlayAudio((int)list[0].type);
		GeEffectEx effect = list[0].effect;
		if (effect != null && this.mOwner != null && this.mOwner.m_pkGeActor != null)
		{
			this.mOwner.m_pkGeActor.DestroyEffect(list[0].effect);
		}
		BeProjectile projectile = this.GetProjectile(list[0]);
		if (projectile == null)
		{
			ListPool<Mechanism2072.ChaserData>.Release(list);
			return false;
		}
		projectile.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this.OnChaserFlyComplete));
		ListPool<Mechanism2072.ChaserData>.Release(list);
		return true;
	}

	// Token: 0x060186CE RID: 100046 RVA: 0x0079DD10 File Offset: 0x0079C110
	private void CreateLightEffect(Mechanism2072.ChaserData data)
	{
		int type = (int)data.type;
		if (this.mChaserLightEffect.Length <= type || type < 0)
		{
			return;
		}
		if (this.mOwner == null || this.mOwner.m_pkGeActor == null)
		{
			return;
		}
		string effectPath = this.mChaserLightEffect[type];
		GeEffectEx geEffectEx = this.mOwner.m_pkGeActor.CreateEffect(effectPath, "[actor]Orign", 0f, Vec3.zero, 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
		if (geEffectEx != null)
		{
			GeUtility.AttachTo(geEffectEx.GetRootNode(), this.mOwner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root), false);
			geEffectEx.SetPosition(data.position.vector3);
		}
	}

	// Token: 0x060186CF RID: 100047 RVA: 0x0079DDC4 File Offset: 0x0079C1C4
	private void PlayAudio(int type)
	{
		if (this.mChaserLightSfx.Length <= type || type < 0)
		{
			return;
		}
		MonoSingleton<AudioManager>.instance.PlaySound(this.mChaserLightSfx[type]);
		this.mOwner.delayCaller.DelayCall(100, delegate
		{
			if (this.mChaserLaunchSfx.Length <= type)
			{
				return;
			}
			MonoSingleton<AudioManager>.instance.PlaySound(this.mChaserLaunchSfx[type]);
		}, 0, 0, false);
	}

	// Token: 0x060186D0 RID: 100048 RVA: 0x0079DE40 File Offset: 0x0079C240
	private void SetProjectileData(BeProjectile proj, Mechanism2072.ChaserData data)
	{
		if (proj == null)
		{
			return;
		}
		int pid = proj.GetPID();
		if (this.mProjectileChaserData.ContainsKey(pid))
		{
			return;
		}
		this.mProjectileChaserData[pid] = data;
	}

	// Token: 0x060186D1 RID: 100049 RVA: 0x0079DE7C File Offset: 0x0079C27C
	private bool GetProjectileData(BeProjectile proj, out Mechanism2072.ChaserData data)
	{
		if (proj == null)
		{
			data = null;
			return false;
		}
		int pid = proj.GetPID();
		if (this.mProjectileChaserData.ContainsKey(pid))
		{
			data = this.mProjectileChaserData[pid];
			this.mProjectileChaserData.Remove(pid);
			return true;
		}
		data = null;
		return false;
	}

	// Token: 0x060186D2 RID: 100050 RVA: 0x0079DED0 File Offset: 0x0079C2D0
	private void OnChaserFlyComplete(object[] args)
	{
		BeProjectile beProjectile = args[0] as BeProjectile;
		if (beProjectile == null)
		{
			return;
		}
		this.ReduceChaseCount();
		Mechanism2072.ChaserData chaserData;
		if (!this.GetProjectileData(beProjectile, out chaserData))
		{
			return;
		}
		this.CheckInvincible(beProjectile, chaserData);
	}

	// Token: 0x060186D3 RID: 100051 RVA: 0x0079DF0C File Offset: 0x0079C30C
	private void CheckInvincible(BeProjectile projectile, Mechanism2072.ChaserData chaserData)
	{
		if (projectile.trail != null)
		{
			AccelerateFollowTarget accelerateFollowTarget = projectile.trail as AccelerateFollowTarget;
			if (accelerateFollowTarget != null && accelerateFollowTarget.target != null && accelerateFollowTarget.target.stateController != null)
			{
				if (!accelerateFollowTarget.target.stateController.CanBeHit())
				{
					this.AddChaser(chaserData);
				}
				else
				{
					this.CreateBoomProjectile(projectile, chaserData);
				}
			}
		}
	}

	// Token: 0x060186D4 RID: 100052 RVA: 0x0079DF7C File Offset: 0x0079C37C
	private void AddChaser(Mechanism2072.ChaserData chaserData)
	{
		if (this.mChaserMgr == null)
		{
			this.mChaserMgr = this.GetChaserMgr(this.mOwner);
			if (this.mChaserMgr == null)
			{
				return;
			}
		}
		this.mChaserMgr.AddChaser(chaserData.type, chaserData.sizeType, true);
	}

	// Token: 0x060186D5 RID: 100053 RVA: 0x0079DFCC File Offset: 0x0079C3CC
	private void CreateBoomProjectile(BeProjectile proj, Mechanism2072.ChaserData chaserData)
	{
		if (this.mOwner == null)
		{
			return;
		}
		if (chaserData.sizeType >= (Mechanism2072.ChaseSizeType)this.mChaserBoomResID.GetLength(0))
		{
			return;
		}
		if (chaserData.type >= (Mechanism2072.ChaserType)this.mChaserBoomResID.GetLength(1))
		{
			return;
		}
		int entityID = this.mChaserBoomResID[(int)chaserData.sizeType, (int)chaserData.type];
		this.mOwner.TriggerEventNew(BeEventType.onChaserUse, new EventParam
		{
			m_Int = (int)chaserData.sizeType,
			m_Int2 = (int)chaserData.type
		});
		BeEntity beEntity = this.mOwner.AddEntity(entityID, proj.GetPosition(), this.level, 0);
		if (beEntity != null)
		{
			beEntity.SetScale((this.GetChaserSizeTypeScale(chaserData.sizeType) + chaserData.scale).vint);
		}
	}

	// Token: 0x060186D6 RID: 100054 RVA: 0x0079E0A4 File Offset: 0x0079C4A4
	private void ReduceChaseCount()
	{
		if (this.mOwner == null)
		{
			return;
		}
		Mechanism2072 mechanism = this.mOwner.GetMechanism(Mechanism2072.ChaserMgrID) as Mechanism2072;
		if (mechanism == null)
		{
			return;
		}
		mechanism.ReduceChaserCount(1);
	}

	// Token: 0x060186D7 RID: 100055 RVA: 0x0079E0E4 File Offset: 0x0079C4E4
	private BeProjectile GetProjectile(Mechanism2072.ChaserData chaserData)
	{
		if (this.mOwner == null)
		{
			return null;
		}
		BeProjectile beProjectile = this.mOwner.AddEntity(this.mChaserPathResID, chaserData.position, this.level, 10000) as BeProjectile;
		if (beProjectile == null)
		{
			return null;
		}
		beProjectile.SetFace(this.mOwner.GetPosition().x > this.mTarget.GetPosition().x, false, false);
		beProjectile.ClearMoveSpeed(7);
		AccelerateFollowTarget accelerateFollowTarget = new AccelerateFollowTarget();
		accelerateFollowTarget.StartPoint = beProjectile.GetPosition();
		accelerateFollowTarget.m_InitSpeed = 0;
		accelerateFollowTarget.m_AccSpeed = this.mTrailAccSpeed;
		if (this.mTarget.attribute != null)
		{
			accelerateFollowTarget.offsetHeight = this.mTarget.attribute.height / 2;
		}
		accelerateFollowTarget.Init();
		accelerateFollowTarget.owner = beProjectile;
		accelerateFollowTarget.target = this.mTarget;
		beProjectile.trail = accelerateFollowTarget;
		beProjectile.hurtID = 0;
		if (beProjectile.m_pkGeActor != null && chaserData.effect != null && chaserData.effect.GetEffectName() != null)
		{
			GeEffectEx effect = beProjectile.m_pkGeActor.CreateEffect(chaserData.effect.GetEffectName(), "[actor]origin", 1E+09f, Vec3.zero, 1f, 1f, false, false, EffectTimeType.BUFF, false);
			this.SetEffectScale(chaserData, effect);
		}
		this.SetProjectileData(beProjectile, chaserData);
		return beProjectile;
	}

	// Token: 0x060186D8 RID: 100056 RVA: 0x0079E25C File Offset: 0x0079C65C
	private void SetEffectScale(Mechanism2072.ChaserData data, GeEffectEx effect)
	{
		if (effect == null)
		{
			return;
		}
		VFactor chaserSizeTypeScale = this.GetChaserSizeTypeScale(data.sizeType);
		effect.SetScale((chaserSizeTypeScale + data.scale).single);
	}

	// Token: 0x060186D9 RID: 100057 RVA: 0x0079E298 File Offset: 0x0079C698
	private VFactor GetChaserSizeTypeScale(Mechanism2072.ChaseSizeType size)
	{
		VFactor result = VFactor.one;
		if (size == Mechanism2072.ChaseSizeType.Big)
		{
			result = VFactor.NewVFactor(1300, GlobalLogic.VALUE_1000);
		}
		return result;
	}

	// Token: 0x060186DA RID: 100058 RVA: 0x0079E2CD File Offset: 0x0079C6CD
	public void Destroy()
	{
		this.mOwner = null;
		this.mTarget = null;
		this.mProjectileChaserData.Clear();
		this.RemoveHandle();
	}

	// Token: 0x060186DB RID: 100059 RVA: 0x0079E2EE File Offset: 0x0079C6EE
	private void RemoveHandle()
	{
		if (this.mHandle != null)
		{
			this.mHandle.Remove();
			this.mHandle = null;
		}
	}

	// Token: 0x040119FA RID: 72186
	private BeActor mOwner;

	// Token: 0x040119FB RID: 72187
	private int level = 1;

	// Token: 0x040119FC RID: 72188
	private BeEventHandle mHandle;

	// Token: 0x040119FD RID: 72189
	private BeActor mTarget;

	// Token: 0x040119FE RID: 72190
	private Mechanism2072 mChaserMgr;

	// Token: 0x040119FF RID: 72191
	private Dictionary<int, Mechanism2072.ChaserData> mProjectileChaserData = new Dictionary<int, Mechanism2072.ChaserData>();

	// Token: 0x04011A00 RID: 72192
	private readonly int mChaserPathResID = 63748;

	// Token: 0x04011A01 RID: 72193
	private int mTrailAccSpeed = 200;

	// Token: 0x04011A02 RID: 72194
	private readonly int[,] mChaserBoomResID = new int[,]
	{
		{
			63733,
			63735,
			63741,
			63739,
			63737
		},
		{
			63734,
			63736,
			63742,
			63740,
			63738
		}
	};

	// Token: 0x04011A03 RID: 72195
	private readonly string[] mChaserLightEffect = new string[]
	{
		"Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_wu_fashe",
		"Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_guang_fashe",
		"Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_fire_fashe",
		"Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_ice_fashe",
		"Effects/Hero_Lifa/Eff_Lifa_XWRH/Prefab/Eff_Lifa_XWRH_an_fashe"
	};

	// Token: 0x04011A04 RID: 72196
	private readonly int[] mChaserLightSfx = new int[]
	{
		4731,
		4727,
		4730,
		4728,
		4729
	};

	// Token: 0x04011A05 RID: 72197
	private readonly int[] mChaserLaunchSfx = new int[]
	{
		4704,
		4690,
		4698,
		4683,
		4681
	};
}
