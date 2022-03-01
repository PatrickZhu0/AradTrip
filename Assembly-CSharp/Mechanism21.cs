using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x0200439D RID: 17309
public class Mechanism21 : BeMechanism
{
	// Token: 0x06017FFE RID: 98302 RVA: 0x007705E4 File Offset: 0x0076E9E4
	public Mechanism21(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017FFF RID: 98303 RVA: 0x00770668 File Offset: 0x0076EA68
	public override void OnInit()
	{
		this.hurtBuffID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		if (this.data.ValueB.Count > 0)
		{
			this.mRemoveBuffFlag = (TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true) != 0);
		}
	}

	// Token: 0x06018000 RID: 98304 RVA: 0x007706E8 File Offset: 0x0076EAE8
	public override void OnStart()
	{
		this.effect = base.owner.m_pkGeActor.CreateEffect("Effects/Monster_Zuiezhiyan/Prefab/Eff_xuechi", "[actor]origin", 9999999f, Vec3.zero, 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
	}

	// Token: 0x06018001 RID: 98305 RVA: 0x0077072D File Offset: 0x0076EB2D
	public override void OnUpdate(int deltaTime)
	{
		this.UpdateSize();
		this.UpdateCheckRange(deltaTime);
	}

	// Token: 0x06018002 RID: 98306 RVA: 0x0077073C File Offset: 0x0076EB3C
	public override void OnFinish()
	{
		if (this.effect != null)
		{
			base.owner.m_pkGeActor.DestroyEffect(this.effect);
			this.effect = null;
		}
		if (this.mRemoveBuffFlag)
		{
			this.RemoveAllDamageBuff();
		}
	}

	// Token: 0x06018003 RID: 98307 RVA: 0x00770778 File Offset: 0x0076EB78
	protected void RemoveAllDamageBuff()
	{
		for (int i = 0; i < this.inRangers.Count; i++)
		{
			this.OutRange(this.inRangers[i]);
		}
		this.inRangers.Clear();
	}

	// Token: 0x06018004 RID: 98308 RVA: 0x007707C0 File Offset: 0x0076EBC0
	private void UpdateSize()
	{
		VInt3 position = base.owner.GetPosition();
		VInt3 position2 = base.owner.GetPosition();
		VInt b = this.radiusSpeed.i * this.speed;
		int i = VInt.half.i;
		bool flag = false;
		bool flag2 = base.owner.GetPosition().y + this.radius > base.owner.CurrentBeScene.logicZSize.y + i;
		bool flag3 = base.owner.GetPosition().y - this.radius < base.owner.CurrentBeScene.logicZSize.x - i;
		bool flag4 = base.owner.GetPosition().x - this.radius < base.owner.CurrentBeScene.logicXSize.x - i;
		bool flag5 = base.owner.GetPosition().x + this.radius > base.owner.CurrentBeScene.logicXSize.y + i;
		if (!flag2 || !flag3 || !flag4 || !flag5)
		{
			this.radius += b;
		}
		if (!flag2 || !flag3)
		{
			flag = true;
			this.scalez += this.speed.single;
		}
		if (flag2 && !flag3)
		{
			position2.y -= b.i;
		}
		if (!flag2 && flag3)
		{
			position2.y += b.i;
		}
		if (!flag4 || !flag5)
		{
			flag = true;
			this.scalex += this.speed.single;
		}
		if (flag4 && !flag5)
		{
			position2.x += b.i;
		}
		if (!flag4 && flag5)
		{
			position2.x -= b.i;
		}
		if (position != position2)
		{
			base.owner.SetPosition(position2, false, true, false);
		}
		if (flag && this.effect != null)
		{
			this.effect.SetScale(this.scalex, 1f, this.scalez);
		}
	}

	// Token: 0x06018005 RID: 98309 RVA: 0x00770A70 File Offset: 0x0076EE70
	private void UpdateCheckRange(int deltaTime)
	{
		this.timeAcc += deltaTime;
		if (this.timeAcc > this.checkInterval)
		{
			this.timeAcc -= this.checkInterval;
			List<BeActor> list = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.FindTargets(list, base.owner, this.radius - VInt.half, false, null);
			for (int i = 0; i < this.inRangers.Count; i++)
			{
				if (!list.Contains(this.inRangers[i]))
				{
					this.OutRange(this.inRangers[i]);
					this.inRangers.RemoveAt(i);
					i--;
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				if (!this.inRangers.Contains(list[j]))
				{
					this.inRangers.Add(list[j]);
					this.InRange(list[j]);
				}
			}
			for (int k = 0; k < this.inRangers.Count; k++)
			{
				this.InRange(this.inRangers[k]);
			}
			ListPool<BeActor>.Release(list);
		}
	}

	// Token: 0x06018006 RID: 98310 RVA: 0x00770BB8 File Offset: 0x0076EFB8
	private void InRange(BeActor actor)
	{
		if (this.hurtBuffID > 0 && !actor.IsDead() && actor.buffController.HasBuffByID(this.hurtBuffID) == null)
		{
			actor.buffController.TryAddBuff(this.hurtBuffID, int.MaxValue, this.level);
		}
	}

	// Token: 0x06018007 RID: 98311 RVA: 0x00770C14 File Offset: 0x0076F014
	private void OutRange(BeActor actor)
	{
		if (this.hurtBuffID > 0)
		{
			actor.buffController.RemoveBuff(this.hurtBuffID, 0, 0);
		}
	}

	// Token: 0x04011493 RID: 70803
	private VInt radius = VInt.one.i * 2;

	// Token: 0x04011494 RID: 70804
	private VInt radiusSpeed = VInt.Float2VIntValue(2.06f);

	// Token: 0x04011495 RID: 70805
	private VFactor speed = new VFactor(4L, 10000L);

	// Token: 0x04011496 RID: 70806
	private GeEffectEx effect;

	// Token: 0x04011497 RID: 70807
	private float scalex = 1f;

	// Token: 0x04011498 RID: 70808
	private float scalez = 1f;

	// Token: 0x04011499 RID: 70809
	private int timeAcc;

	// Token: 0x0401149A RID: 70810
	private int checkInterval = 500;

	// Token: 0x0401149B RID: 70811
	private int hurtBuffID;

	// Token: 0x0401149C RID: 70812
	protected List<BeActor> inRangers = new List<BeActor>();

	// Token: 0x0401149D RID: 70813
	protected bool mRemoveBuffFlag;
}
