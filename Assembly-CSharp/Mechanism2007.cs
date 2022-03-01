using System;
using System.Collections.Generic;
using Battle;
using GamePool;
using UnityEngine;

// Token: 0x0200433D RID: 17213
public class Mechanism2007 : BeMechanism
{
	// Token: 0x06017D27 RID: 97575 RVA: 0x0075BFA6 File Offset: 0x0075A3A6
	public Mechanism2007(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017D28 RID: 97576 RVA: 0x0075BFDB File Offset: 0x0075A3DB
	public override void OnInit()
	{
		this.buffID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x06017D29 RID: 97577 RVA: 0x0075C008 File Offset: 0x0075A408
	public override void OnStart()
	{
		base.OnStart();
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindMonsterByID(list, this.BossID, true);
		if (list.Count > 0)
		{
			this.target = list[0];
			this.AddChain(this.target);
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06017D2A RID: 97578 RVA: 0x0075C065 File Offset: 0x0075A465
	public void RemoveChain()
	{
		if (this.target != null)
		{
			this.target.buffController.RemoveBuff(this.buffID, 0, 0);
			this.ClearEffect();
		}
	}

	// Token: 0x06017D2B RID: 97579 RVA: 0x0075C090 File Offset: 0x0075A490
	public override void OnFinish()
	{
		base.OnFinish();
		this.RemoveChain();
	}

	// Token: 0x06017D2C RID: 97580 RVA: 0x0075C0A0 File Offset: 0x0075A4A0
	protected void AddChain(BeActor toActor)
	{
		this.effect = base.owner.m_pkGeActor.CreateEffect(this.chainEffect, null, 99999f, Vec3.zero, 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
		GameObject rootNode = this.effect.GetRootNode();
		bool flag = false;
		GameObject attachGameObject = this.GetAttachGameObject(base.owner, "[actor]Body", ref flag);
		GeUtility.AttachTo(rootNode, attachGameObject, false);
		if (flag)
		{
			Vector3 position = this.effect.GetPosition();
			position.z += this.defaultHeight.scalar;
			this.effect.SetPosition(position);
		}
		ComCommonBind componentInChildren = rootNode.GetComponentInChildren<ComCommonBind>();
		if (componentInChildren != null)
		{
			LightningChain com = componentInChildren.GetCom<LightningChain>("lcScript");
			if (com != null)
			{
				GameObject attachNode = toActor.m_pkGeActor.GetAttachNode("[actor]Orign");
				if (attachNode != null)
				{
					if (this.node == null)
					{
						this.node = new GameObject("Node");
					}
					Utility.AttachTo(this.node, attachNode, false);
					this.node.transform.localPosition = new Vector3(0f, 1f, 0f);
					com.target = this.node;
					com.ForceUpdate();
				}
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
		toActor.buffController.TryAddBuff(this.buffID, -1, this.level);
	}

	// Token: 0x06017D2D RID: 97581 RVA: 0x0075C2A5 File Offset: 0x0075A6A5
	protected GameObject GetAttachGameObject(BeActor actor, string nodeName, ref bool noStrNode)
	{
		this.attachRoot = actor.m_pkGeActor.GetAttachNode(nodeName);
		if (this.attachRoot == null)
		{
			noStrNode = true;
			this.attachRoot = actor.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root);
		}
		return this.attachRoot;
	}

	// Token: 0x06017D2E RID: 97582 RVA: 0x0075C2E8 File Offset: 0x0075A6E8
	private void ClearEffect()
	{
		if (this.effect != null)
		{
			GameObject rootNode = this.effect.GetRootNode();
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
			base.owner.m_pkGeActor.DestroyEffect(this.effect);
		}
		if (this.node != null)
		{
			Object.Destroy(this.node);
			this.node = null;
		}
	}

	// Token: 0x04011249 RID: 70217
	private string chainEffect = "Effects/Monster_HMZD_zhenshou/Prefab/Eff_hmzd_zhenshou_shouhulian";

	// Token: 0x0401124A RID: 70218
	private GameObject attachRoot;

	// Token: 0x0401124B RID: 70219
	private int buffID;

	// Token: 0x0401124C RID: 70220
	private VInt defaultHeight = VInt.Float2VIntValue(1.5f);

	// Token: 0x0401124D RID: 70221
	private BeActor target;

	// Token: 0x0401124E RID: 70222
	private GeEffectEx effect;

	// Token: 0x0401124F RID: 70223
	private int BossID = 30770021;

	// Token: 0x04011250 RID: 70224
	private GameObject node;
}
