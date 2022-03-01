using System;
using System.Collections.Generic;
using Battle;
using UnityEngine;

// Token: 0x02004377 RID: 17271
public class Mechanism2063 : BeMechanism
{
	// Token: 0x06017EE8 RID: 98024 RVA: 0x00768E98 File Offset: 0x00767298
	public Mechanism2063(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017EE9 RID: 98025 RVA: 0x00768F00 File Offset: 0x00767300
	public override void OnInit()
	{
		base.OnInit();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.swordEntityIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		this.lightEntityId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.useSkillId = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.completeCount = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x06017EEA RID: 98026 RVA: 0x00768FDC File Offset: 0x007673DC
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		this.curCompleteCount = 0;
		this.mUpdateTimeAcc = 0;
		this.sceneHandleA = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.onAddEntity, new BeEventHandle.Del(this.RegisterEntityCreate));
		this.GetAttachObj(null);
		this.handleB = base.owner.RegisterEvent(BeEventType.onChangeModelFinish, new BeEventHandle.Del(this.GetAttachObj));
	}

	// Token: 0x06017EEB RID: 98027 RVA: 0x00769058 File Offset: 0x00767458
	private void GetAttachObj(object[] args = null)
	{
		this.attachTrans = null;
		if (base.owner == null || base.owner.m_pkGeActor == null)
		{
			return;
		}
		this.attachTrans = base.owner.m_pkGeActor.GetAttachNode("[actor]OrignBuff").transform;
	}

	// Token: 0x06017EEC RID: 98028 RVA: 0x007690A8 File Offset: 0x007674A8
	public override void OnUpdateGraphic(int deltaTime)
	{
		base.OnUpdateGraphic(deltaTime);
		this.UpdateSwordEffect(deltaTime);
	}

	// Token: 0x06017EED RID: 98029 RVA: 0x007690B8 File Offset: 0x007674B8
	private void RegisterEntityCreate(object[] args)
	{
		BeEntity beEntity = args[0] as BeEntity;
		if (beEntity == null)
		{
			return;
		}
		if (!this.swordEntityIdList.Contains(beEntity.m_iResID))
		{
			return;
		}
		this.handleA = beEntity.RegisterEvent(BeEventType.onHitOther, delegate(object[] args1)
		{
			if (this.isOver)
			{
				return;
			}
			BeActor beActor = args1[0] as BeActor;
			if (beActor == null)
			{
				return;
			}
			if (beActor.professionID == 0)
			{
				return;
			}
			this.CreateLightEntity(beActor);
			this.curCompleteCount++;
			this.AddSwordEffect();
			if (this.curCompleteCount >= this.completeCount)
			{
				this.CounterOver();
			}
		});
	}

	// Token: 0x06017EEE RID: 98030 RVA: 0x00769108 File Offset: 0x00767508
	private void CreateLightEntity(BeActor player)
	{
		VInt3 position = player.GetPosition();
		position.z = GlobalLogic.VALUE_10000;
		BeProjectile beProjectile = base.owner.AddEntity(this.lightEntityId, position, 1, 0) as BeProjectile;
		if (beProjectile == null)
		{
			return;
		}
		FollowTarget followTarget = new FollowTarget();
		followTarget.StartPoint = beProjectile.GetPosition();
		beProjectile.ClearMoveSpeed(7);
		VInt3 position2 = base.owner.GetPosition();
		position2.z = followTarget.StartPoint.z;
		followTarget.EndPoint = position2;
		followTarget.MoveSpeed = this.lightEntitySpeed;
		followTarget.nearReove = true;
		followTarget.Init();
		beProjectile.trail = followTarget;
		followTarget.owner = beProjectile;
		followTarget.target = base.owner;
	}

	// Token: 0x06017EEF RID: 98031 RVA: 0x007691C0 File Offset: 0x007675C0
	private void AddSwordEffect()
	{
		Vec3 zero = Vec3.zero;
		GeEffectEx geEffectEx = base.owner.m_pkGeActor.CreateEffect(this.swordEffectPath, "[actor]Orign", 999999f, zero, 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
		if (geEffectEx != null)
		{
			GeUtility.AttachTo(geEffectEx.GetRootNode(), base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Transform), false);
			this.swordEffectList.Add(geEffectEx);
			this.AdjustEffectPos();
		}
	}

	// Token: 0x06017EF0 RID: 98032 RVA: 0x00769238 File Offset: 0x00767638
	private void AdjustEffectPos()
	{
		float num = 360f / (float)this.swordEffectList.Count;
		for (int i = 0; i < this.swordEffectList.Count; i++)
		{
			float num2 = num * (float)i;
			float num3 = this.rotateRadius * Mathf.Cos(num2 * 3.14f / 180f);
			float num4 = this.rotateRadius * Mathf.Sin(num2 * 3.14f / 180f);
			this.swordEffectList[i].SetLocalPosition(new Vector3(num3, 1.5f, num4));
		}
	}

	// Token: 0x06017EF1 RID: 98033 RVA: 0x007692CC File Offset: 0x007676CC
	private void UpdateSwordEffect(int deltaTime)
	{
		if (this.attachTrans == null)
		{
			return;
		}
		this.mUpdateTimeAcc += deltaTime;
		if (this.mUpdateTimeAcc <= this.mUpdateInterval)
		{
			return;
		}
		this.mUpdateTimeAcc -= this.mUpdateInterval;
		for (int i = 0; i < this.swordEffectList.Count; i++)
		{
			this.swordEffectList[i].GetRootNode().transform.RotateAround(this.attachTrans.position, this.attachTrans.forward, this.rotateSpeed * (float)this.mUpdateInterval * 0.001f);
		}
	}

	// Token: 0x06017EF2 RID: 98034 RVA: 0x0076937F File Offset: 0x0076777F
	private void CounterOver()
	{
		this.isOver = true;
		base.owner.delayCaller.DelayCall(2000, delegate
		{
			if (!base.owner.IsDead())
			{
				this.isOver = false;
				this.curCompleteCount = 0;
				this.ClearAllEffect();
				base.owner.UseSkill(this.useSkillId, true);
			}
		}, 0, 0, false);
	}

	// Token: 0x06017EF3 RID: 98035 RVA: 0x007693B0 File Offset: 0x007677B0
	private void ClearAllEffect()
	{
		for (int i = 0; i < this.swordEffectList.Count; i++)
		{
			base.owner.m_pkGeActor.DestroyEffect(this.swordEffectList[i]);
		}
		this.swordEffectList.Clear();
	}

	// Token: 0x040113B3 RID: 70579
	private List<int> swordEntityIdList = new List<int>();

	// Token: 0x040113B4 RID: 70580
	private int lightEntityId;

	// Token: 0x040113B5 RID: 70581
	private int useSkillId;

	// Token: 0x040113B6 RID: 70582
	private int completeCount = 6;

	// Token: 0x040113B7 RID: 70583
	private float rotateRadius = 1f;

	// Token: 0x040113B8 RID: 70584
	private float rotateSpeed = 20f;

	// Token: 0x040113B9 RID: 70585
	private string swordEffectPath = "Effects/Monster_TB02/Prefab/Eff_Monster_TB02_Meimeng_Feiyujian_05";

	// Token: 0x040113BA RID: 70586
	private List<GeEffectEx> swordEffectList = new List<GeEffectEx>(6);

	// Token: 0x040113BB RID: 70587
	private int curCompleteCount;

	// Token: 0x040113BC RID: 70588
	private bool isOver;

	// Token: 0x040113BD RID: 70589
	private int lightEntitySpeed = 5000;

	// Token: 0x040113BE RID: 70590
	private Transform attachTrans;

	// Token: 0x040113BF RID: 70591
	private int mUpdateInterval = 70;

	// Token: 0x040113C0 RID: 70592
	private int mUpdateTimeAcc;
}
