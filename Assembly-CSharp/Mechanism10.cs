using System;
using System.Collections.Generic;
using GamePool;
using UnityEngine;

// Token: 0x02004247 RID: 16967
public class Mechanism10 : BeMechanism
{
	// Token: 0x06017799 RID: 96153 RVA: 0x00737C98 File Offset: 0x00736098
	public Mechanism10(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601779A RID: 96154 RVA: 0x00737D04 File Offset: 0x00736104
	public override void OnInit()
	{
		this.radius = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
		this.speed = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true), GlobalLogic.VALUE_1000);
		this.sizeChanged = (TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) == 1);
		if (this.data.ValueD.Count > 0)
		{
			this.absorbFlag = (TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true) == 1);
			this.absorbCheckRadius = TableManager.GetValueFromUnionCell(this.data.ValueD[1], this.level, true);
		}
		if (this.data.ValueE.Count > 0)
		{
			this.absorbBuffID = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		}
	}

	// Token: 0x0601779B RID: 96155 RVA: 0x00737E54 File Offset: 0x00736254
	public override void OnStart()
	{
		this.cnt = 0;
		int num = GlobalLogic.VALUE_1000;
		int num2 = GlobalLogic.VALUE_1000;
		for (int i = 0; i < base.owner.MechanismList.Count; i++)
		{
			Mechanism117 mechanism = base.owner.MechanismList[i] as Mechanism117;
			if (mechanism != null)
			{
				num += mechanism.radiusRate;
				num2 += mechanism.speedRate;
			}
		}
		this.radius = this.radius.i * VFactor.NewVFactor(num, GlobalLogic.VALUE_1000);
		this.speed = this.speed.i * VFactor.NewVFactor(num2, GlobalLogic.VALUE_1000);
	}

	// Token: 0x0601779C RID: 96156 RVA: 0x00737F10 File Offset: 0x00736310
	public override void OnUpdate(int deltaTime)
	{
		if (base.owner != null)
		{
			List<BeActor> list = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.FindTargets(list, base.owner, this.radius, false, null);
			for (int i = 0; i < list.Count; i++)
			{
				BeActor beActor = list[i];
				if (beActor.stateController.CanMove() && !beActor.stateController.CanNotAbsorbByBlockHole())
				{
					VInt3 position = base.owner.GetPosition();
					VInt3 position2 = beActor.GetPosition();
					if (this.IsNeedAbsorb(position, position2))
					{
						if (this.HaveAbsorbBuff(beActor))
						{
							VInt2 vint = new VInt2(position.x - position2.x, position.y - position2.y);
							VInt2 vint2 = vint.NormalizeTo(this.speed.i);
							if (beActor.stateController.CanMoveX())
							{
								beActor.extraSpeed.x = vint2.x;
							}
							if (beActor.stateController.CanMoveY())
							{
								beActor.extraSpeed.y = vint2.y;
							}
							if (this.sizeChanged)
							{
								this.ChangeSize(beActor);
							}
						}
					}
				}
			}
			ListPool<BeActor>.Release(list);
		}
	}

	// Token: 0x0601779D RID: 96157 RVA: 0x00738060 File Offset: 0x00736460
	private void ChangeSize(BeActor actor)
	{
		if (!this.actorList.Contains(actor))
		{
			this.actorList.Add(actor);
		}
		this.cnt++;
		actor.m_pkGeActor.SetActorNodeScale(Mathf.Lerp(1f, 0f, 0.03f * (float)this.cnt * this.sizeSpeed));
		VInt3 rkPos = new VInt3(actor.GetPosition().x, actor.GetPosition().y, VInt.Clamp(new VInt(Mathf.Lerp(0f, 1f, 0.03f * (float)this.cnt)), 0, VInt.one).i);
		actor.SetPosition(rkPos, true, true, false);
	}

	// Token: 0x0601779E RID: 96158 RVA: 0x0073812C File Offset: 0x0073652C
	private void ResizeModelScale()
	{
		if (this.sizeChanged)
		{
			for (int i = 0; i < this.actorList.Count; i++)
			{
				this.actorList[i].buffController.TryAddBuff(68, -1, 1);
			}
			base.owner.CurrentBeScene.DelayCaller.DelayCall(this.delayTime, delegate
			{
				for (int j = 0; j < this.actorList.Count; j++)
				{
					if (this.actorList[j] != null)
					{
						this.actorList[j].buffController.RemoveBuff(68, 0, 0);
					}
				}
				for (int k = 0; k < this.actorList.Count; k++)
				{
					if (this.actorList[k] != null && this.actorList[k].m_pkGeActor != null)
					{
						this.actorList[k].m_pkGeActor.ResetActorNodeScale();
					}
				}
				this.actorList.Clear();
			}, 0, 0, false);
		}
	}

	// Token: 0x0601779F RID: 96159 RVA: 0x007381A6 File Offset: 0x007365A6
	public override void OnDead()
	{
		base.OnDead();
		this.ResizeModelScale();
	}

	// Token: 0x060177A0 RID: 96160 RVA: 0x007381B4 File Offset: 0x007365B4
	public override void OnFinish()
	{
		base.OnFinish();
		this.ResizeModelScale();
	}

	// Token: 0x060177A1 RID: 96161 RVA: 0x007381C4 File Offset: 0x007365C4
	protected bool IsNeedAbsorb(VInt3 ownerPos, VInt3 targetPos)
	{
		return !this.absorbFlag || (targetPos - ownerPos).magnitude > this.absorbCheckRadius;
	}

	// Token: 0x060177A2 RID: 96162 RVA: 0x007381FB File Offset: 0x007365FB
	protected bool HaveAbsorbBuff(BeActor target)
	{
		return this.absorbBuffID == 0 || target.buffController.HasBuffByID(this.absorbBuffID) != null;
	}

	// Token: 0x04010DE1 RID: 69089
	private VInt radius = 2 * VInt.one.i;

	// Token: 0x04010DE2 RID: 69090
	private VInt speed = 2 * VInt.one.i;

	// Token: 0x04010DE3 RID: 69091
	private int delayTime = 1200;

	// Token: 0x04010DE4 RID: 69092
	private float sizeSpeed = 5f;

	// Token: 0x04010DE5 RID: 69093
	private bool sizeChanged;

	// Token: 0x04010DE6 RID: 69094
	private int cnt;

	// Token: 0x04010DE7 RID: 69095
	private bool absorbFlag;

	// Token: 0x04010DE8 RID: 69096
	private int absorbCheckRadius;

	// Token: 0x04010DE9 RID: 69097
	private int absorbBuffID;

	// Token: 0x04010DEA RID: 69098
	private List<BeActor> actorList = new List<BeActor>();
}
