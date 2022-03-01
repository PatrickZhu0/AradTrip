using System;
using System.Collections.Generic;
using GamePool;
using ProtoTable;
using UnityEngine;

// Token: 0x020041A2 RID: 16802
public class BeProjectile : BeEntity
{
	// Token: 0x060170D4 RID: 94420 RVA: 0x00711D74 File Offset: 0x00710174
	public BeProjectile(int iResID, int iCamp, int iID) : base(iResID, iCamp, (long)iID)
	{
	}

	// Token: 0x060170D5 RID: 94421 RVA: 0x00711DCB File Offset: 0x007101CB
	public void SetCanAttackEnemyAndFriend(bool canAttack)
	{
		this.m_CanAttackEnemyAndFriend = canAttack;
	}

	// Token: 0x060170D6 RID: 94422 RVA: 0x00711DD4 File Offset: 0x007101D4
	private int ConverK2W(int r)
	{
		long num = (long)r;
		num = num * 10000L / 10000L;
		return (int)num;
	}

	// Token: 0x060170D7 RID: 94423 RVA: 0x00711DF8 File Offset: 0x007101F8
	private int ConverW2K(int r)
	{
		long num = (long)r;
		num = num * 10000L / 10000L;
		return (int)num;
	}

	// Token: 0x060170D8 RID: 94424 RVA: 0x00711E1A File Offset: 0x0071021A
	public VFactor DegreeToRadian(int degree)
	{
		return VFactor.pi / 180L * (long)degree / 100L;
	}

	// Token: 0x060170D9 RID: 94425 RVA: 0x00711E3B File Offset: 0x0071023B
	protected override bool _canAttackedEntity2(BeEntity pkEntity)
	{
		return base._canAttackedEntity2(pkEntity) || this.m_CanAttackEnemyAndFriend;
	}

	// Token: 0x060170DA RID: 94426 RVA: 0x00711E54 File Offset: 0x00710254
	public sealed override void InitReset(int iResID, int iCamp, int iID)
	{
		base.InitReset(iResID, iCamp, iID);
		this.m_fLifes = 0;
		this.m_eType = ProjectType.BULLET;
		this.hurtType = 0;
		this.forcex = 0f;
		this.forcey = 0f;
		this.hurtTime = 0f;
		this.targetShockInfo = default(ShockInfo);
		this.sceneShockInfo = default(ShockInfo);
		this.isHitFloat = false;
		this.hitFloatForceY = 0f;
		this.isHurtPause = false;
		this.hurtPauseIime = 0f;
		this.hurtID = 0;
		this.attachHurts.Clear();
		this.hurtAddBuffs.Clear();
		this.originPos = VInt3.zero;
		this.distance = 0;
		this.hitThrough = false;
		this.totoalHitCount = 1;
		this.lifeTime = 0;
		this.needSetFace = true;
		this.triggerSkillLevel = 0;
		this.hitThroughFactor = VRate.zero;
		this.delayDead = 0;
		this.markDead = false;
		this.hitGroundClick = false;
		this.center = VInt3.zero;
		this.isRotation = false;
		this.rotateSpeed = 0;
		this.moveSpeed = 0;
		this.isFollowRotate = false;
		this.data = null;
		this.targetChooseType = TargetChooseType.NONE;
		this.trail = null;
		this.degree = 0;
		this.radius = 0;
		this.m_bCanBeAttacked = false;
		this.m_eType = ProjectType.BULLET;
		base.moveZAcc = 0;
		this.hurtType = 0;
		this.forcex = 4f;
		this.forcey = 0f;
		this.hasHP = false;
		this.attackCountExceedPlayExtDead = false;
		this.playExtDead = false;
		this.projectileDeadType = ProjectileDeadType.NORMAL;
		this.data = Singleton<TableManager>.GetInstance().GetTableItem<ObjectTable>(this.m_iResID, string.Empty, string.Empty);
		this.onCollideDie = false;
		this.onXInBlockDie = false;
		this.changForceBehindOther = false;
	}

	// Token: 0x060170DB RID: 94427 RVA: 0x00712038 File Offset: 0x00710438
	public virtual void Create(float fDelaytime = 0f, bool useCube = false)
	{
		BeStatesGraph pkStateGraph;
		if (this.m_pkStateGraph == null)
		{
			BeProjectileStateGraph beProjectileStateGraph = new BeProjectileStateGraph();
			beProjectileStateGraph.InitStatesGraph();
			beProjectileStateGraph.pkProjectile = this;
			beProjectileStateGraph.m_pkEntity = this;
			pkStateGraph = beProjectileStateGraph;
		}
		else
		{
			pkStateGraph = this.m_pkStateGraph;
		}
		base.Create(pkStateGraph, 0, false, false, useCube);
		this.InitTableData();
	}

	// Token: 0x060170DC RID: 94428 RVA: 0x0071208C File Offset: 0x0071048C
	public sealed override bool IsAttackAdd2Statistics()
	{
		BeActor beActor = base.GetOwner() as BeActor;
		return beActor != null && beActor.IsAttackAdd2Statistics();
	}

	// Token: 0x060170DD RID: 94429 RVA: 0x007120B4 File Offset: 0x007104B4
	public override void TriggerHitAfterDoHurt(BeActor target)
	{
		base.TriggerHitAfterDoHurt(target);
		BeActor projectileOwnerActor = base.GetProjectileOwnerActor(this);
		if (projectileOwnerActor != null)
		{
			projectileOwnerActor.TriggerHitAfterDoHurt(target);
		}
	}

	// Token: 0x060170DE RID: 94430 RVA: 0x007120E0 File Offset: 0x007104E0
	public void InitTableData()
	{
		if (this.data != null)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.Duration, this.triggerSkillLevel, true);
			if (valueFromUnionCell > 0)
			{
				this.m_fLifes = valueFromUnionCell;
			}
			bool flag = this.data.GenRune > 0;
			if (flag && this.owner != null)
			{
				this.owner.TriggerEvent(BeEventType.onAddRune, null);
			}
		}
		this.CreateShadow();
	}

	// Token: 0x060170DF RID: 94431 RVA: 0x00712152 File Offset: 0x00710552
	public bool IsGenRune()
	{
		return this.data != null && this.data.GenRune > 0;
	}

	// Token: 0x060170E0 RID: 94432 RVA: 0x00712170 File Offset: 0x00710570
	private void CreateShadow()
	{
		Singleton<GeSimpleShadowManager>.instance.RemoveShadowObject(this.m_pkGeActor.renderObject);
		if (this.data != null && (this.data.ShadowScaleX > 0 || this.data.ShadowScaleZ > 0))
		{
			Vector3 one = Vector3.one;
			Vector4 entityPlane = GeSceneEx.EntityPlane;
			this.m_pkGeActor.SetEntityPlane(entityPlane);
			if (this.data.ShadowScaleX > 0)
			{
				one.x = (float)this.data.ShadowScaleX / 1000f;
			}
			if (this.data.ShadowScaleZ > 0)
			{
				one.z = (float)this.data.ShadowScaleZ / 1000f;
			}
			this.m_pkGeActor.AddSimpleShadow(one);
		}
	}

	// Token: 0x060170E1 RID: 94433 RVA: 0x00712238 File Offset: 0x00710638
	public VFactor GetProjectileScale()
	{
		VFactor one = VFactor.one;
		if (this.data != null && this.triggerSkillLevel > 1)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell((!BattleMain.IsModePvP(base.battleType)) ? this.data.Scale : this.data.PVPScale, this.triggerSkillLevel, true);
			if (valueFromUnionCell > 0)
			{
				one = new VFactor((long)valueFromUnionCell, 1000L);
			}
		}
		return one;
	}

	// Token: 0x060170E2 RID: 94434 RVA: 0x007122B4 File Offset: 0x007106B4
	public VFactor GetProjectileZDimScale()
	{
		VFactor one = VFactor.one;
		if (this.data != null && this.triggerSkillLevel > 1)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell((!BattleMain.IsModePvP(base.battleType)) ? this.data.Zscale : this.data.PVPZscale, this.triggerSkillLevel, true);
			if (valueFromUnionCell > 0)
			{
				one = new VFactor((long)valueFromUnionCell, 1000L);
			}
		}
		return one;
	}

	// Token: 0x060170E3 RID: 94435 RVA: 0x0071232D File Offset: 0x0071072D
	public sealed override void _updatePosition(int iDeltime)
	{
		base._updatePosition(iDeltime);
	}

	// Token: 0x060170E4 RID: 94436 RVA: 0x00712336 File Offset: 0x00710736
	public sealed override bool _isCmdMoveForbiden()
	{
		return true;
	}

	// Token: 0x060170E5 RID: 94437 RVA: 0x0071233C File Offset: 0x0071073C
	public sealed override void _updateGraphicActor(bool force = false)
	{
		if (this.m_pkGeActor != null && (this.m_bGraphicPositionDirty || force))
		{
			VInt3 position = base.GetPosition();
			this.m_pkGeActor.SetPosition(position.vector3);
			if (this.needSetFace)
			{
				this.m_pkGeActor.SetFaceLeft(base.GetFace());
			}
			else
			{
				this.m_pkGeActor.SetFaceLeft(false);
			}
			this.m_pkGeActor.SetScale(this.m_fScale.scalar);
			this.m_bGraphicPositionDirty = false;
		}
	}

	// Token: 0x060170E6 RID: 94438 RVA: 0x007123C8 File Offset: 0x007107C8
	public sealed override void _onHurtEntity(BeEntity pkEntity, VInt3 hitPos, int hurtid = 0)
	{
		if (pkEntity == null)
		{
			return;
		}
		if (this.hurtID != 0)
		{
			hurtid = this.hurtID;
		}
		if (this.totoalHitCount <= 0)
		{
			return;
		}
		EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(hurtid, string.Empty, string.Empty);
		if (tableItem != null)
		{
			this.AddSkillBuffBeforeDealHurt(tableItem.SkillID);
		}
		base._onHurtEntity(pkEntity, hitPos, hurtid);
		if (tableItem != null)
		{
			this.RemoveSkillBuffAfterDealHurt(tableItem.SkillID);
		}
	}

	// Token: 0x060170E7 RID: 94439 RVA: 0x0071244E File Offset: 0x0071084E
	protected override void OnAttachHurt(BeEntity pkEntity, EffectTable hurtData)
	{
		base.OnAttachHurt(pkEntity, hurtData);
		if (hurtData == null)
		{
			return;
		}
		if (hurtData != null && hurtData.HitGrab && !pkEntity.IsGrabed())
		{
			return;
		}
		this.DoAttachHurt(pkEntity);
	}

	// Token: 0x060170E8 RID: 94440 RVA: 0x00712483 File Offset: 0x00710883
	public void AddSkillBuff(int buffID)
	{
		this.hurtAddBuffs.Add(buffID);
	}

	// Token: 0x060170E9 RID: 94441 RVA: 0x00712494 File Offset: 0x00710894
	protected void AddSkillBuffBeforeDealHurt(int skillID)
	{
		if (skillID <= 0)
		{
			return;
		}
		List<int> skillIDs = new List<int>
		{
			skillID
		};
		BeActor beActor = base.GetOwner() as BeActor;
		if (beActor != null && !beActor.IsDeadOrRemoved())
		{
			for (int i = 0; i < this.hurtAddBuffs.Count; i++)
			{
				beActor.buffController.TryAddBuff(this.hurtAddBuffs[i], 1, this.triggerSkillLevel, 1000, 0, false, skillIDs, 0, 0, null);
			}
		}
	}

	// Token: 0x060170EA RID: 94442 RVA: 0x0071251C File Offset: 0x0071091C
	protected void RemoveSkillBuffAfterDealHurt(int skillID)
	{
		if (skillID <= 0)
		{
			return;
		}
		BeActor beActor = base.GetOwner() as BeActor;
		if (beActor != null && !beActor.IsDeadOrRemoved())
		{
			for (int i = 0; i < this.hurtAddBuffs.Count; i++)
			{
				beActor.buffController.RemoveBuff(this.hurtAddBuffs[i], 0, 0);
			}
		}
	}

	// Token: 0x060170EB RID: 94443 RVA: 0x00712584 File Offset: 0x00710984
	public sealed override void OnDealHit(BeEntity pkEntity)
	{
		if (this.targetShockInfo.shockTime > 0f)
		{
			float num = this.targetShockInfo.shockRangeX;
			float shockRangeY = this.targetShockInfo.shockRangeY;
			if (base.GetFace())
			{
				num *= -1f;
			}
			pkEntity._addShock(this.targetShockInfo.shockTime, this.targetShockInfo.shockSpeed, num, shockRangeY, 1);
		}
		BeActor beActor = base.GetTopOwner(this) as BeActor;
		if (beActor != null && beActor.isLocalActor && this.sceneShockInfo.shockTime > 0f)
		{
			this.currentBeScene.currentGeScene.GetCamera().PlayShockEffect(this.sceneShockInfo.shockTime, this.sceneShockInfo.shockSpeed, this.sceneShockInfo.shockRangeX, this.sceneShockInfo.shockRangeY, 2, beActor.IsCurSkillOpenShock());
		}
	}

	// Token: 0x060170EC RID: 94444 RVA: 0x0071266B File Offset: 0x00710A6B
	public override bool IsCurSkillOpenShock()
	{
		return this.owner == null || this.owner.IsCurSkillOpenShock();
	}

	// Token: 0x060170ED RID: 94445 RVA: 0x00712688 File Offset: 0x00710A88
	public sealed override void ShowMissEffect(Vec3 Pos)
	{
		BeActor beActor = base.GetOwner() as BeActor;
		if (beActor != null && beActor.isMainActor && !beActor.IsDeadOrRemoved())
		{
			string effectPath = "Effects/Common/Sfx/Hit/Prefab/Eff_hit_miss_newguo";
			this.currentBeScene.currentGeScene.CreateEffect(effectPath, 0f, Pos, 1f, 1f, false, base.GetFace());
		}
	}

	// Token: 0x060170EE RID: 94446 RVA: 0x007126EC File Offset: 0x00710AEC
	public sealed override void OnBeforeGetDamage(BeEntity target, AttackResult result, bool isBackHit, int hurtID)
	{
		if (base.GetOwner() == target)
		{
			return;
		}
		BeActor beActor = base.GetOwner() as BeActor;
		if (beActor != null && !beActor.IsDeadOrRemoved())
		{
			beActor.DealBeforeGetDamage(target, result, hurtID, isBackHit, this.m_iResID);
		}
	}

	// Token: 0x060170EF RID: 94447 RVA: 0x00712734 File Offset: 0x00710B34
	public sealed override void onHitEntity(BeEntity pkEntity, VInt3 pos, int hurtID = 0, AttackResult result = AttackResult.MISS, int finalDamage = 0)
	{
		if (this.m_eType == ProjectType.BULLET || this.m_eType == ProjectType.SINGLE)
		{
			this.totoalHitCount--;
			VRate vrate = this.hitThroughFactor;
			if (hurtID > 0)
			{
				EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(hurtID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					int level = 1;
					BeEntityData entityData = base.GetEntityData();
					if (entityData != null)
					{
						level = entityData.GetSkillLevel(tableItem.SkillID);
					}
					VRate vrate2 = TableManager.GetValueFromUnionCell(tableItem.HitThroughRate, level, true);
					VRate[] array = new VRate[]
					{
						vrate2
					};
					this.owner.TriggerEvent(BeEventType.onChangeHitThrough, new object[]
					{
						hurtID,
						array
					});
					vrate += array[0];
				}
			}
			if (vrate > 1)
			{
				if ((int)base.FrameRandom.Range1000() > vrate)
				{
					this.totoalHitCount = 0;
				}
				else
				{
					this.totoalHitCount = Mathf.Max(1, this.totoalHitCount);
				}
			}
		}
		if (result != AttackResult.MISS && this.owner != null)
		{
			if (result == AttackResult.CRITICAL)
			{
				this.owner.TriggerEvent(BeEventType.onHitCritical, new object[]
				{
					pos
				});
			}
			int num = 0;
			EffectTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(hurtID, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				num = tableItem2.SkillID;
			}
			this.owner.TriggerEvent(BeEventType.onHitOther, new object[]
			{
				pkEntity,
				hurtID,
				num,
				pos,
				0,
				finalDamage
			});
			if (this.owner != this)
			{
				BeActor beActor = this.owner as BeActor;
				if (beActor != null)
				{
					beActor.onHitEntity(pkEntity, pos, hurtID, result, finalDamage);
				}
			}
			this.owner.TriggerEvent(BeEventType.onHitOtherAfterHurt, new object[]
			{
				pkEntity,
				hurtID,
				result
			});
		}
	}

	// Token: 0x060170F0 RID: 94448 RVA: 0x0071296C File Offset: 0x00710D6C
	public void DoAttachHurt(BeEntity target)
	{
		for (int i = 0; i < this.attachHurts.Count; i++)
		{
			if (this.attachHurts[i] > 0)
			{
				int num = this.attachHurts[i];
				if (target.stateController.CanBeHit())
				{
					if (Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(num, string.Empty, string.Empty) == null)
					{
						if (this.m_cpkCurEntityActionInfo != null)
						{
						}
					}
					else if (!(target is BeObject))
					{
						base.DoAttackTo(target, num, false, true);
					}
				}
			}
		}
	}

	// Token: 0x060170F1 RID: 94449 RVA: 0x00712A10 File Offset: 0x00710E10
	public sealed override void ShowHitEffect(Vec3 Pos, BeEntity target, int hurtID)
	{
		string text;
		if (this.m_cpkCurEntityActionInfo != null && this.m_cpkCurEntityActionInfo.hitEffectAsset.IsValid())
		{
			text = this.m_cpkCurEntityActionInfo.hitEffectAsset.m_AssetPath;
		}
		else
		{
			text = Global.Settings.defaultProjectileHitEffect;
		}
		string[] array = new string[]
		{
			text
		};
		base.TriggerEvent(BeEventType.onChangeHitEffect, new object[]
		{
			hurtID,
			array
		});
		text = array[0];
		DAssetObject effectRes;
		effectRes.m_AssetObj = null;
		effectRes.m_AssetPath = text;
		EffectsFrames dummy_HIT_EFF_FRAME = this.currentBeScene.currentGeScene.DUMMY_HIT_EFF_FRAME;
		dummy_HIT_EFF_FRAME.localPosition = new Vector3(0f, 0f, 0f);
		dummy_HIT_EFF_FRAME.localRotation = this.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Actor).transform.localRotation;
		GeEffectEx geEffectEx = this.currentBeScene.currentGeScene.CreateEffect(effectRes, dummy_HIT_EFF_FRAME, 0f, Pos, 1f, 1f, false, base.GetFace());
		if (target != null && geEffectEx != null)
		{
			target.currentHitEffectNum++;
			int ms = Math.Max(IntMath.Float2Int(geEffectEx.GetTimeLen()), 100);
			target.delayCaller.DelayCall(ms, delegate
			{
				target.currentHitEffectNum--;
			}, 0, 0, false);
		}
	}

	// Token: 0x060170F2 RID: 94450 RVA: 0x00712B7A File Offset: 0x00710F7A
	public void SetType(ProjectType t, int value)
	{
		this.m_eType = t;
		this.m_fLifes = value;
	}

	// Token: 0x060170F3 RID: 94451 RVA: 0x00712B8A File Offset: 0x00710F8A
	public int GetLifeTime()
	{
		return this.m_fLifes;
	}

	// Token: 0x060170F4 RID: 94452 RVA: 0x00712B94 File Offset: 0x00710F94
	public sealed override bool Update(int iDeltaTime)
	{
		int i = iDeltaTime;
		int num = 16;
		while (i > 0)
		{
			int iDeltaTime2 = Mathf.Min(num, i);
			if (base.Update(iDeltaTime2))
			{
				this.CheckDistance();
				this.CheckLifeTime(this.timeAcc);
				this.CheckAttackCount();
				if (this.isRotation)
				{
					this.UpdateRotation();
				}
			}
			i -= num;
		}
		if (this.trail != null)
		{
			this.UpdateTrail(iDeltaTime);
		}
		return true;
	}

	// Token: 0x060170F5 RID: 94453 RVA: 0x00712C06 File Offset: 0x00711006
	public void UpdateTrail(int iDeltaTime)
	{
		this.trail.OnTick(iDeltaTime);
		this.SetPosition(this.trail.currentPos, false, true);
	}

	// Token: 0x060170F6 RID: 94454 RVA: 0x00712C28 File Offset: 0x00711028
	public void InitLocalRotation()
	{
		if (this.m_pkGeActor == null)
		{
			return;
		}
		if (this.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Actor) == null)
		{
			return;
		}
		float scalar = this.m_fMoveXSpeed.scalar;
		float scalar2 = base.moveZSpeed.scalar;
		Vector2 vector;
		vector..ctor(scalar, scalar2);
		float num = 0f;
		if (vector.y != 0f)
		{
			num = Vector2.Angle(vector, new Vector2(1f, 0f));
		}
		if (base.GetFace() && num != 0f)
		{
			num = 180f - num;
		}
		if (vector.y < 0f)
		{
			num = -num;
		}
		if (vector.x == 0f && vector.y == 0f)
		{
			num = 0f;
		}
		this.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Actor).transform.localRotation = Quaternion.AngleAxis(num, Vector3.forward);
	}

	// Token: 0x060170F7 RID: 94455 RVA: 0x00712D2E File Offset: 0x0071112E
	public void SetTargetShockInfo(ShockInfo info)
	{
		this.targetShockInfo = info;
	}

	// Token: 0x060170F8 RID: 94456 RVA: 0x00712D37 File Offset: 0x00711137
	public void SetSceneShockInfo(ShockInfo info)
	{
		this.sceneShockInfo = info;
	}

	// Token: 0x060170F9 RID: 94457 RVA: 0x00712D40 File Offset: 0x00711140
	public void DoDie()
	{
		if (base.sgGetCurrentState() == 16)
		{
			return;
		}
		base.TriggerEvent(BeEventType.onDead, new object[]
		{
			this
		});
		if (!this.sgStarted)
		{
			if (this.m_pkStateGraph != null && !this.m_pkStateGraph.Start(16))
			{
				base.sgSwitchStates(new BeStateData(16, 0));
				return;
			}
		}
		else
		{
			base.sgSwitchStates(new BeStateData(16, 0));
		}
		base.ClearPhaseDeleteAudio();
		this.sgStarted = true;
	}

	// Token: 0x060170FA RID: 94458 RVA: 0x00712DC4 File Offset: 0x007111C4
	public void RecordOriginPosition()
	{
		this.originPos = base.GetPosition();
	}

	// Token: 0x060170FB RID: 94459 RVA: 0x00712DD4 File Offset: 0x007111D4
	private void CheckDistance()
	{
		if (this.distance > 0 && Mathf.Abs(base.GetPosition().x - this.originPos.x) >= this.distance)
		{
			this.DoDie();
		}
	}

	// Token: 0x060170FC RID: 94460 RVA: 0x00712E2C File Offset: 0x0071122C
	private void CheckLifeTime(int time)
	{
		if (this.lifeTime > 0 && time >= this.lifeTime)
		{
			this.DoDie();
		}
	}

	// Token: 0x060170FD RID: 94461 RVA: 0x00712E4C File Offset: 0x0071124C
	private void CheckAttackCount()
	{
		if (this.totoalHitCount <= 0)
		{
			if (this.attackCountExceedPlayExtDead)
			{
				this.playExtDead = true;
			}
			this.DoDie();
		}
	}

	// Token: 0x060170FE RID: 94462 RVA: 0x00712E78 File Offset: 0x00711278
	public void InitRotation(int initDegree)
	{
		this.center = base.GetOwner().GetPosition();
		this.isRotation = true;
		VInt2 a = new VInt2(this.center.x, this.center.y);
		VInt2 b = new VInt2(base.GetPosition().x, base.GetPosition().y);
		this.radius = this.ConverK2W((a - b).magnitude);
		this.degree = initDegree * 100;
	}

	// Token: 0x060170FF RID: 94463 RVA: 0x00712F03 File Offset: 0x00711303
	public void SetPosition(VInt3 rkPos, bool immediate = false, bool showLog = true)
	{
		if (this.data != null && this.data.IsTouchGround > 0)
		{
			rkPos.z = VInt.Float2VIntValue(0.01f);
		}
		base.SetPosition(rkPos, immediate, showLog, false);
	}

	// Token: 0x06017100 RID: 94464 RVA: 0x00712F3C File Offset: 0x0071133C
	public int FormatDegree(int degree)
	{
		while (degree < 0)
		{
			degree += 36000;
		}
		while (degree > 36000)
		{
			degree -= 36000;
		}
		return degree;
	}

	// Token: 0x06017101 RID: 94465 RVA: 0x00712F70 File Offset: 0x00711370
	public void UpdateRotation()
	{
		if (!this.isRotation)
		{
			return;
		}
		VInt3 position = base.GetPosition();
		this.degree = this.FormatDegree(this.degree);
		VInt3 vint = new VInt3(1f, 0f, 0f);
		VFactor vfactor = this.DegreeToRadian(this.degree);
		VInt3 rkPos = vint.RotateZ(ref vfactor);
		rkPos.NormalizeTo(this.ConverW2K(this.radius));
		if (this.isFollowRotate)
		{
			this.center = base.GetOwner().GetPosition();
		}
		rkPos.x = this.center.x + rkPos.x;
		rkPos.y = this.center.y + rkPos.y;
		rkPos.z = position.z;
		this.SetPosition(rkPos, false, true);
		this.degree += this.rotateSpeed;
		this.radius += this.moveSpeed;
		base.SetFace(false, false, false);
	}

	// Token: 0x06017102 RID: 94466 RVA: 0x00713079 File Offset: 0x00711479
	public sealed override void OnDead()
	{
	}

	// Token: 0x06017103 RID: 94467 RVA: 0x0071307B File Offset: 0x0071147B
	public sealed override bool TryAddBuff(EffectTable hurtData, BeEntity target = null, int duration = 0, bool useBuffAni = true, bool finishDelete = false, bool finishDeleteAll = false)
	{
		return this.owner != null && this.owner.TryAddBuff(hurtData, target, 0, true, false, false);
	}

	// Token: 0x06017104 RID: 94468 RVA: 0x0071309B File Offset: 0x0071149B
	public sealed override bool TryAddEntity(EffectTable hurtData, VInt3 pos, int triggeredLevel = 1)
	{
		return this.owner != null && !this.owner.IsDead() && this.owner.TryAddEntity(hurtData, pos, this.triggerSkillLevel);
	}

	// Token: 0x06017105 RID: 94469 RVA: 0x007130D0 File Offset: 0x007114D0
	public sealed override bool TrySummon(EffectTable hurtData)
	{
		bool flag = false;
		if (this.owner != null && !this.owner.IsDead())
		{
			flag = this.owner.TrySummon(hurtData);
			if (flag)
			{
				List<BeActor> list = ListPool<BeActor>.Get();
				this.owner.CurrentBeScene.GetSummonBySummoner(list, this.owner as BeActor, true, false);
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].GetEntityData().MonsterIDEqual(hurtData.SummonID))
					{
						list[i].SetPosition(base.GetPosition(), false, true, false);
						list[i].SetFace(base.GetFace(), false, true);
					}
				}
				ListPool<BeActor>.Release(list);
			}
		}
		return flag;
	}

	// Token: 0x06017106 RID: 94470 RVA: 0x00713198 File Offset: 0x00711598
	public sealed override bool _canAttackedEntity(BeEntity pkEntity, int hitType = 1)
	{
		bool flag = base._canAttackedEntity(pkEntity, hitType);
		return (pkEntity.GetOwner() == null || pkEntity.GetOwner().IsDeadOrRemoved() || !pkEntity.GetOwner().stateController.IsChaosState() || !flag || this.owner != pkEntity.GetOwner()) && flag;
	}

	// Token: 0x06017107 RID: 94471 RVA: 0x007131F8 File Offset: 0x007115F8
	protected override void OnCollide()
	{
		if (this.onCollideDie)
		{
			this.DoDie();
		}
	}

	// Token: 0x06017108 RID: 94472 RVA: 0x0071320B File Offset: 0x0071160B
	protected override void OnXInBlock()
	{
		if (this.onXInBlockDie)
		{
			this.DoDie();
		}
	}

	// Token: 0x06017109 RID: 94473 RVA: 0x00713220 File Offset: 0x00711620
	protected override void ChangeXForce(int[] xForce, BeEntity target, BeEntity bullet, bool face)
	{
		if (this.changForceBehindOther)
		{
			if (face)
			{
				if (bullet.GetPosition().x > target.GetPosition().x)
				{
					xForce[0] = -xForce[0];
				}
			}
			else if (bullet.GetPosition().x < target.GetPosition().x)
			{
				xForce[0] = -xForce[0];
			}
		}
	}

	// Token: 0x040109AA RID: 68010
	public int m_fLifes;

	// Token: 0x040109AB RID: 68011
	public ProjectType m_eType;

	// Token: 0x040109AC RID: 68012
	public int hurtType;

	// Token: 0x040109AD RID: 68013
	public float forcex;

	// Token: 0x040109AE RID: 68014
	public float forcey;

	// Token: 0x040109AF RID: 68015
	public float hurtTime;

	// Token: 0x040109B0 RID: 68016
	public ShockInfo targetShockInfo;

	// Token: 0x040109B1 RID: 68017
	public ShockInfo sceneShockInfo;

	// Token: 0x040109B2 RID: 68018
	public bool isHitFloat;

	// Token: 0x040109B3 RID: 68019
	public float hitFloatForceY;

	// Token: 0x040109B4 RID: 68020
	public bool isHurtPause;

	// Token: 0x040109B5 RID: 68021
	public float hurtPauseIime;

	// Token: 0x040109B6 RID: 68022
	public CrypticInt32 hurtID;

	// Token: 0x040109B7 RID: 68023
	public List<int> attachHurts = new List<int>();

	// Token: 0x040109B8 RID: 68024
	public List<int> hurtAddBuffs = new List<int>();

	// Token: 0x040109B9 RID: 68025
	public VInt3 originPos;

	// Token: 0x040109BA RID: 68026
	public VInt distance = 0;

	// Token: 0x040109BB RID: 68027
	public bool hitThrough;

	// Token: 0x040109BC RID: 68028
	public CrypticInt32 totoalHitCount = 1;

	// Token: 0x040109BD RID: 68029
	public int lifeTime;

	// Token: 0x040109BE RID: 68030
	public bool needSetFace = true;

	// Token: 0x040109BF RID: 68031
	public int triggerSkillLevel;

	// Token: 0x040109C0 RID: 68032
	public VRate hitThroughFactor = VRate.zero;

	// Token: 0x040109C1 RID: 68033
	public int delayDead;

	// Token: 0x040109C2 RID: 68034
	public bool markDead;

	// Token: 0x040109C3 RID: 68035
	public bool hitGroundClick;

	// Token: 0x040109C4 RID: 68036
	public bool attackCountExceedPlayExtDead;

	// Token: 0x040109C5 RID: 68037
	public bool playExtDead;

	// Token: 0x040109C6 RID: 68038
	public VInt3 center;

	// Token: 0x040109C7 RID: 68039
	public bool isRotation;

	// Token: 0x040109C8 RID: 68040
	public int rotateSpeed;

	// Token: 0x040109C9 RID: 68041
	public int moveSpeed;

	// Token: 0x040109CA RID: 68042
	public bool isFollowRotate;

	// Token: 0x040109CB RID: 68043
	public ObjectTable data;

	// Token: 0x040109CC RID: 68044
	public TargetChooseType targetChooseType;

	// Token: 0x040109CD RID: 68045
	public LinearLogicTrial trail;

	// Token: 0x040109CE RID: 68046
	private int degree;

	// Token: 0x040109CF RID: 68047
	private int radius;

	// Token: 0x040109D0 RID: 68048
	public ProjectileDeadType projectileDeadType;

	// Token: 0x040109D1 RID: 68049
	public bool onCollideDie;

	// Token: 0x040109D2 RID: 68050
	public bool onXInBlockDie;

	// Token: 0x040109D3 RID: 68051
	public bool changForceBehindOther;

	// Token: 0x040109D4 RID: 68052
	private bool m_CanAttackEnemyAndFriend;

	// Token: 0x040109D5 RID: 68053
	private Vector3 lastPos;
}
