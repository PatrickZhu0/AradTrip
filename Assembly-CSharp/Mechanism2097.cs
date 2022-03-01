using System;
using System.Collections.Generic;
using GamePool;
using UnityEngine;

// Token: 0x0200439C RID: 17308
public class Mechanism2097 : BeMechanism
{
	// Token: 0x06017FF6 RID: 98294 RVA: 0x0076FE5C File Offset: 0x0076E25C
	public Mechanism2097(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017FF7 RID: 98295 RVA: 0x0076FE88 File Offset: 0x0076E288
	public override void OnInit()
	{
		if (this.m_MonsterID != null)
		{
			this.m_MonsterID.Clear();
		}
		else
		{
			this.m_MonsterID = new List<int>();
		}
		for (int i = 0; i < this.data.ValueA.Length; i++)
		{
			this.m_MonsterID.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		this.m_TargetBuffID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.m_MoveSpeed = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.m_MoveSpeed = ((this.m_MoveSpeed != 0) ? (this.m_MoveSpeed * 10) : GlobalLogic.VALUE_10000);
		if (this.data.ValueD.Count > 0)
		{
			this.m_NeedSetFace = (TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true) == 1);
		}
		if (this.data.ValueE.Count > 0)
		{
			this.m_MoveTime = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		}
		if (!string.IsNullOrEmpty(this.data.StringValueA[0]))
		{
			this.m_EffectAsset.m_AssetPath = this.data.StringValueA[0];
			if (this.data.ValueF.Count > 3)
			{
				this.m_EffectTime = TableManager.GetValueFromUnionCell(this.data.ValueF[3], this.level, true);
			}
			if (this.data.ValueF.Count > 2)
			{
				this.m_EffectOffset = new VInt3(TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true), TableManager.GetValueFromUnionCell(this.data.ValueF[1], this.level, true), TableManager.GetValueFromUnionCell(this.data.ValueF[2], this.level, true));
			}
			if (this.data.ValueF.Count > 4)
			{
				this.mEffectScale = TableManager.GetValueFromUnionCell(this.data.ValueF[4], this.level, true);
			}
		}
	}

	// Token: 0x06017FF8 RID: 98296 RVA: 0x00770140 File Offset: 0x0076E540
	public override void OnStart()
	{
		this.startMove = false;
		this.moveTime = 0;
		if (base.owner != null && base.owner.CurrentBeScene != null)
		{
			this.TryDoMoveTo();
		}
	}

	// Token: 0x06017FF9 RID: 98297 RVA: 0x00770174 File Offset: 0x0076E574
	public override void OnUpdate(int deltaTime)
	{
		if (this.startMove)
		{
			this.moveTime += deltaTime;
			if (this.moveTime > this.moveTimeAcc && base.owner != null)
			{
				base.owner.buffController.RemoveBuff(this.attachBuff);
			}
		}
	}

	// Token: 0x06017FFA RID: 98298 RVA: 0x007701CC File Offset: 0x0076E5CC
	public override void OnFinish()
	{
		if (base.owner != null && base.owner.CurrentBeScene != null && base.owner.CurrentBeScene.IsInBlockPlayer(base.owner.GetPosition()))
		{
			VInt3 rkPos = BeAIManager.FindStandPositionNew(base.owner.GetPosition(), base.owner.CurrentBeScene, base.owner.GetFace(), false, 40);
			base.owner.SetPosition(rkPos, false, true, false);
		}
	}

	// Token: 0x06017FFB RID: 98299 RVA: 0x00770250 File Offset: 0x0076E650
	private void TryDoMoveTo()
	{
		BeActor beActor = this.FindAMoveTarget();
		if (beActor != null)
		{
			VInt3 toPos = beActor.GetPosition();
			if (this.m_NeedSetFace)
			{
				int num = toPos.x - base.owner.GetPosition().x;
				if (num > 0)
				{
					base.owner.SetFace(false, false, false);
				}
				else if (num < 0)
				{
					base.owner.SetFace(true, false, false);
				}
			}
			if (!string.IsNullOrEmpty(this.m_EffectAsset.m_AssetPath))
			{
				EffectsFrames effectsFrames = new EffectsFrames();
				effectsFrames.localPosition = new Vector3((float)this.m_EffectOffset.x / 10000f, (float)this.m_EffectOffset.y / 10000f, (float)this.m_EffectOffset.z / 10000f);
				effectsFrames.localScale *= (float)this.mEffectScale / 1000f;
				if (base.owner.CurrentBeScene != null && base.owner.CurrentBeScene.currentGeScene != null)
				{
					base.owner.CurrentBeScene.currentGeScene.CreateEffect(this.m_EffectAsset, effectsFrames, (float)this.m_EffectTime / 1000f, new Vec3((float)toPos.x / 10000f, (float)toPos.y / 10000f, 0f), 1f, 1f, false, false);
				}
			}
			VInt3 lhs = beActor.GetPosition() - base.owner.GetPosition();
			int num2 = lhs.magnitude * GlobalLogic.VALUE_1000 / this.m_MoveSpeed;
			num2 = ((num2 != 0) ? num2 : 1);
			if (this.m_MoveTime > 0 && this.m_MoveTime < num2)
			{
				toPos = base.owner.GetPosition() + lhs * this.m_MoveTime / (float)num2;
				num2 = this.m_MoveTime;
			}
			this.startMove = true;
			this.moveTimeAcc = num2;
			base.owner.actionManager.StopAll();
			BeMoveTo action = BeMoveTo.Create(base.owner, num2, base.owner.GetPosition(), toPos, true, null, false);
			base.owner.actionManager.RunAction(action);
		}
	}

	// Token: 0x06017FFC RID: 98300 RVA: 0x0077049C File Offset: 0x0076E89C
	private BeActor FindAMoveTarget()
	{
		BeActor result = null;
		GetMosterByIDListFilter getMosterByIDListFilter = new GetMosterByIDListFilter();
		getMosterByIDListFilter.monsterIdList = this.m_MonsterID;
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindTargets(list, base.owner, true, getMosterByIDListFilter);
		this.FindPlayerByBuff(this.m_TargetBuffID, list);
		if (list.Count > 1)
		{
			result = list[base.FrameRandom.InRange(0, list.Count)];
		}
		else if (list.Count == 1)
		{
			result = list[0];
		}
		ListPool<BeActor>.Release(list);
		return result;
	}

	// Token: 0x06017FFD RID: 98301 RVA: 0x00770530 File Offset: 0x0076E930
	private void FindPlayerByBuff(int buffID, List<BeActor> aList)
	{
		if (base.owner.CurrentBeBattle != null && base.owner.CurrentBeBattle.dungeonPlayerManager != null)
		{
			List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				if (allPlayers[i].playerActor != null && allPlayers[i].playerActor.buffController != null && allPlayers[i].playerActor.buffController.HasBuffByID(buffID) != null)
				{
					aList.Add(allPlayers[i].playerActor);
				}
			}
		}
	}

	// Token: 0x04011487 RID: 70791
	protected List<int> m_MonsterID = new List<int>();

	// Token: 0x04011488 RID: 70792
	protected int m_TargetBuffID;

	// Token: 0x04011489 RID: 70793
	protected int m_MoveSpeed;

	// Token: 0x0401148A RID: 70794
	protected bool m_NeedSetFace;

	// Token: 0x0401148B RID: 70795
	protected int m_MoveTime;

	// Token: 0x0401148C RID: 70796
	protected DAssetObject m_EffectAsset;

	// Token: 0x0401148D RID: 70797
	protected int m_EffectTime = 3000;

	// Token: 0x0401148E RID: 70798
	protected VInt3 m_EffectOffset;

	// Token: 0x0401148F RID: 70799
	protected int mEffectScale = 1000;

	// Token: 0x04011490 RID: 70800
	protected bool startMove;

	// Token: 0x04011491 RID: 70801
	protected int moveTime;

	// Token: 0x04011492 RID: 70802
	protected int moveTimeAcc;
}
