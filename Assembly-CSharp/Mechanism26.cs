using System;
using System.Collections.Generic;
using Battle;
using GamePool;
using UnityEngine;

// Token: 0x020043D4 RID: 17364
public class Mechanism26 : BeMechanism
{
	// Token: 0x06018177 RID: 98679 RVA: 0x0077C384 File Offset: 0x0077A784
	public Mechanism26(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018178 RID: 98680 RVA: 0x0077C424 File Offset: 0x0077A824
	public override void OnInit()
	{
		this.chainEffect = this.data.StringValueA[0];
		this.chainMaxCount = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.chainMaxDistance = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true), GlobalLogic.VALUE_1000);
		this.hurtID = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.attackCount = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x06018179 RID: 98681 RVA: 0x0077C4F4 File Offset: 0x0077A8F4
	public override void OnStart()
	{
		this.OnFinish();
		this.stat = Mechanism26.ChainStat.CHAINING;
		BeActor beActor = this.FindTarget(base.owner.GetPosition(), true);
		if (beActor != null)
		{
			this.AddChain(base.owner, beActor);
			base.owner.delayCaller.DelayCall(this.CHAIN_NEXT_INTERVAL, delegate
			{
				this.ChainNext();
			}, 0, 0, false);
		}
		else
		{
			GeEffectEx geEffectEx = base.owner.m_pkGeActor.CreateEffect(this.chainEffect, null, (float)this.attackDuration / (float)GlobalLogic.VALUE_1000, Vec3.zero, 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
			GameObject rootNode = geEffectEx.GetRootNode();
			bool flag = false;
			GameObject attachGameObject = this.GetAttachGameObject(base.owner, this.strNode, ref flag);
			GeUtility.AttachTo(rootNode, attachGameObject, false);
			if (flag)
			{
				Vector3 position = geEffectEx.GetPosition();
				position.z += this.defaultHeight.scalar;
				geEffectEx.SetPosition(position);
			}
			this.stat = Mechanism26.ChainStat.FINISH;
		}
	}

	// Token: 0x0601817A RID: 98682 RVA: 0x0077C5F8 File Offset: 0x0077A9F8
	public override void OnUpdate(int deltaTime)
	{
		this.delayCaller.Update(deltaTime);
		if (this.stat == Mechanism26.ChainStat.FINISH)
		{
			this.stat = Mechanism26.ChainStat.OVER;
			base.owner.delayCaller.DelayCall(this.delay, delegate
			{
				this.Clear();
			}, 0, 0, false);
		}
	}

	// Token: 0x0601817B RID: 98683 RVA: 0x0077C64C File Offset: 0x0077AA4C
	protected void GetCurrentTargets(List<BeActor> list)
	{
		list.Clear();
		for (int i = 0; i < this.targetList.Count; i++)
		{
			list.Add(this.targetList[i].target);
		}
	}

	// Token: 0x0601817C RID: 98684 RVA: 0x0077C698 File Offset: 0x0077AA98
	protected void ChainNext()
	{
		if (this.targetList.Count >= this.chainMaxCount || this.targetList.Count <= 0)
		{
			this.stat = Mechanism26.ChainStat.FINISH;
			return;
		}
		BeActor beActor = this.FindTarget(this.targetList[this.targetList.Count - 1].target.GetPosition(), false);
		if (beActor != null)
		{
			this.AddChain(this.targetList[this.targetList.Count - 1].target, beActor);
			this.delayCaller.DelayCall(this.CHAIN_NEXT_INTERVAL, delegate
			{
				this.ChainNext();
			}, 0, 0, false);
		}
		else
		{
			this.stat = Mechanism26.ChainStat.FINISH;
		}
	}

	// Token: 0x0601817D RID: 98685 RVA: 0x0077C75C File Offset: 0x0077AB5C
	protected BeActor FindTarget(VInt3 pos, bool first = false)
	{
		if (first)
		{
			return base.owner.CurrentBeScene.FindNearestRangeTarget(pos, base.owner, this.chainMaxDistance, null);
		}
		List<BeActor> list = ListPool<BeActor>.Get();
		this.GetCurrentTargets(list);
		BeActor result = base.owner.CurrentBeScene.FindNearestRangeTarget(pos, base.owner, this.chainMaxDistance, list);
		ListPool<BeActor>.Release(list);
		return result;
	}

	// Token: 0x0601817E RID: 98686 RVA: 0x0077C7C4 File Offset: 0x0077ABC4
	protected GameObject GetAttachGameObject(BeActor actor, string nodeName, ref bool noStrNode)
	{
		if (actor == null || actor.m_pkGeActor == null)
		{
			return null;
		}
		GameObject gameObject = actor.m_pkGeActor.GetAttachNode(nodeName);
		if (gameObject == null)
		{
			noStrNode = true;
			gameObject = actor.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root);
		}
		return gameObject;
	}

	// Token: 0x0601817F RID: 98687 RVA: 0x0077C810 File Offset: 0x0077AC10
	protected void AddChain(BeActor fromActor, BeActor toActor)
	{
		GeEffectEx geEffectEx = base.owner.m_pkGeActor.CreateEffect(this.chainEffect, null, 99999f, Vec3.zero, 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
		GameObject rootNode = geEffectEx.GetRootNode();
		bool flag = false;
		GameObject attachGameObject = this.GetAttachGameObject(fromActor, this.strNode, ref flag);
		GeUtility.AttachTo(rootNode, attachGameObject, false);
		if (flag)
		{
			Vector3 position = geEffectEx.GetPosition();
			position.z += this.defaultHeight.scalar;
			geEffectEx.SetPosition(position);
		}
		ComCommonBind componentInChildren = rootNode.GetComponentInChildren<ComCommonBind>();
		if (componentInChildren != null)
		{
			LightningChain com = componentInChildren.GetCom<LightningChain>("lcScript");
			if (com != null)
			{
				bool flag2 = false;
				com.target = this.GetAttachGameObject(toActor, this.strNode, ref flag2);
				com.ForceUpdate();
			}
			GameObject gameObject = componentInChildren.GetGameObject("goNodeA");
			if (gameObject != null)
			{
				OffsetChange offsetChange = gameObject.GetComponent<OffsetChange>();
				if (offsetChange == null)
				{
					offsetChange = gameObject.AddComponent<OffsetChange>();
					offsetChange.LoopCount = 0f;
					offsetChange.AStartTime = 0f;
					offsetChange.AXSpeed = -5f;
					offsetChange.AYSpeed = 0f;
					offsetChange.BStartTime = 0f;
					offsetChange.BXSpeed = 0f;
					offsetChange.BYSpeed = 0f;
				}
			}
		}
		int ms = IntMath.Float2Int((float)this.attackDuration / (float)this.attackCount);
		if (this.attackCount <= 1)
		{
			VInt3 position2 = toActor.GetPosition();
			position2.z += VInt.one.i;
			base.owner._onHurtEntity(toActor, position2, this.hurtID);
		}
		else
		{
			this.delayCaller.RepeatCall(ms, delegate
			{
				VInt3 position3 = toActor.GetPosition();
				position3.z += VInt.one.i;
				this.owner._onHurtEntity(toActor, position3, this.hurtID);
			}, this.attackCount, true);
		}
		BeEventHandle handle = toActor.RegisterEvent(BeEventType.onDead, delegate(object[] args)
		{
			int[] array = (int[])args[0];
			if (!(bool)args[1])
			{
				array[0] = 1;
			}
		});
		Mechanism26.ChainTarget item = default(Mechanism26.ChainTarget);
		item.effect = geEffectEx;
		item.target = toActor;
		item.handle = handle;
		this.targetList.Add(item);
	}

	// Token: 0x06018180 RID: 98688 RVA: 0x0077CA7F File Offset: 0x0077AE7F
	public override void OnFinish()
	{
		this.delayCaller.Clear();
		this.Clear();
	}

	// Token: 0x06018181 RID: 98689 RVA: 0x0077CA94 File Offset: 0x0077AE94
	protected void Clear()
	{
		for (int i = 0; i < this.targetList.Count; i++)
		{
			Mechanism26.ChainTarget chainTarget = this.targetList[i];
			chainTarget.handle.Remove();
			try
			{
				GeEffectEx effect = chainTarget.effect;
				GameObject rootNode = effect.GetRootNode();
				if (rootNode != null)
				{
					ComCommonBind componentInChildren = rootNode.GetComponentInChildren<ComCommonBind>();
					if (componentInChildren != null)
					{
						LightningChain com = componentInChildren.GetCom<LightningChain>("lcScript");
						com.target = null;
						com.SetVertexCount(0);
					}
				}
				base.owner.m_pkGeActor.DestroyEffect(effect);
			}
			catch (Exception ex)
			{
			}
			if (chainTarget.target.GetLifeState() == 2)
			{
				if (chainTarget.target.IsDead() || (chainTarget.target.GetEntityData() != null && chainTarget.target.GetEntityData().GetHP() <= 0))
				{
					chainTarget.target.DoDead(false);
				}
			}
		}
		this.targetList.Clear();
	}

	// Token: 0x040115D0 RID: 71120
	private int chainMaxCount = 7;

	// Token: 0x040115D1 RID: 71121
	private string chainEffect;

	// Token: 0x040115D2 RID: 71122
	private VInt chainMaxDistance = VInt.one.i * 5;

	// Token: 0x040115D3 RID: 71123
	private int hurtID = 15000;

	// Token: 0x040115D4 RID: 71124
	private int attackCount = 4;

	// Token: 0x040115D5 RID: 71125
	private int attackDuration = GlobalLogic.VALUE_1000;

	// Token: 0x040115D6 RID: 71126
	private int CHAIN_NEXT_INTERVAL = GlobalLogic.VALUE_100;

	// Token: 0x040115D7 RID: 71127
	private int delay = 800;

	// Token: 0x040115D8 RID: 71128
	private string strNode = "[actor]Body";

	// Token: 0x040115D9 RID: 71129
	private VInt defaultHeight = VInt.Float2VIntValue(0.8f);

	// Token: 0x040115DA RID: 71130
	private Mechanism26.ChainStat stat;

	// Token: 0x040115DB RID: 71131
	private List<Mechanism26.ChainTarget> targetList = new List<Mechanism26.ChainTarget>();

	// Token: 0x040115DC RID: 71132
	private new DelayCaller delayCaller = new DelayCaller();

	// Token: 0x020043D5 RID: 17365
	private enum ChainStat
	{
		// Token: 0x040115DF RID: 71135
		NONE,
		// Token: 0x040115E0 RID: 71136
		CHAINING,
		// Token: 0x040115E1 RID: 71137
		FINISH,
		// Token: 0x040115E2 RID: 71138
		OVER
	}

	// Token: 0x020043D6 RID: 17366
	private struct ChainTarget
	{
		// Token: 0x040115E3 RID: 71139
		public BeActor target;

		// Token: 0x040115E4 RID: 71140
		public GeEffectEx effect;

		// Token: 0x040115E5 RID: 71141
		public BeEventHandle handle;
	}
}
