using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020043F3 RID: 17395
public class Mechanism52 : BeMechanism
{
	// Token: 0x06018249 RID: 98889 RVA: 0x007822FC File Offset: 0x007806FC
	public Mechanism52(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601824A RID: 98890 RVA: 0x00782308 File Offset: 0x00780708
	public override void OnInit()
	{
		this.angle = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.rTime = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.orientation = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.distance = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		this.interval = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
		int diffID = base.owner.CurrentBeBattle.dungeonManager.GetDungeonDataManager().id.diffID;
		this.attackId = TableManager.GetValueFromUnionCell(this.data.ValueG[diffID], this.level, true);
		VFactor vfactor = VFactor.pi * (long)valueFromUnionCell / 180L;
		this.minDot = IntMath.cos(vfactor.nom, vfactor.den);
		this.targets = new List<BeActor>();
		this.dicHurtCD = new Dictionary<BeActor, int>();
	}

	// Token: 0x0601824B RID: 98891 RVA: 0x00782490 File Offset: 0x00780890
	public override void OnStart()
	{
		this.angleAcc = new VFactor(0L);
		if (this.orientation == 0)
		{
			this.realDir = base.FrameRandom.InRange(0, 2) * 2 - 1;
		}
		else
		{
			this.realDir = this.orientation;
		}
		this.startDir = ((!base.owner.GetFace()) ? VInt3.right : (-VInt3.right));
		this.rotateTimer = 0;
		this.rotateEnd = false;
		this.ownerTrans = base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Charactor).transform;
	}

	// Token: 0x0601824C RID: 98892 RVA: 0x00782534 File Offset: 0x00780934
	private void FindTargets()
	{
		this.targets.Clear();
		base.owner.CurrentBeScene.FindTargets(this.targets, base.owner, VInt.Float2VIntValue(100f), false, null);
		for (int i = 0; i < this.targets.Count; i++)
		{
			BeActor beActor = this.targets[i];
			if (beActor != null && !this.dicHurtCD.ContainsKey(beActor))
			{
				this.dicHurtCD.Add(beActor, 0);
			}
		}
	}

	// Token: 0x0601824D RID: 98893 RVA: 0x007825C8 File Offset: 0x007809C8
	public override void OnUpdate(int deltaTime)
	{
		if (!this.rotateEnd && base.owner != null)
		{
			if (this.rotateTimer < this.rTime)
			{
				this.rotateTimer += deltaTime;
				this.angleAcc = new VFactor((long)(this.rotateTimer * this.angle * this.realDir), (long)this.rTime);
				VFactor vfactor = VFactor.pi * this.angleAcc / 180L;
				VInt3 vint = this.startDir.RotateY(ref vfactor);
				vint.y = vint.z;
				vint.z = 0;
				this.findTargetsTimer -= deltaTime;
				if (this.findTargetsTimer <= 0)
				{
					this.FindTargets();
					this.findTargetsTimer = 300;
				}
				for (int i = 0; i < this.targets.Count; i++)
				{
					BeActor beActor = this.targets[i];
					if (beActor != null && !beActor.IsDead())
					{
						Dictionary<BeActor, int> dictionary;
						BeActor key;
						(dictionary = this.dicHurtCD)[key = beActor] = dictionary[key] + deltaTime;
						if (this.dicHurtCD[beActor] > this.interval)
						{
							VInt3 vint2 = beActor.GetPosition() - base.owner.GetPosition();
							if (vint2.magnitude < this.distance)
							{
								VInt3 lhs = vint2.NormalizeTo(10000);
								VInt3 rhs = vint.NormalizeTo(10000);
								VFactor a = new VFactor((long)VInt3.Dot(lhs, rhs), (long)(GlobalLogic.VALUE_10000 * GlobalLogic.VALUE_10000));
								if (a >= this.minDot)
								{
									VInt3 position = base.owner.GetPosition();
									position.z += VInt.one.i;
									base.owner._onHurtEntity(beActor, position, this.attackId);
									this.dicHurtCD[beActor] = 0;
								}
							}
						}
					}
				}
				if (this.ownerTrans != null)
				{
					this.ownerTrans.eulerAngles = Vector3.up * this.angleAcc.single;
				}
			}
			else
			{
				this.rotateEnd = true;
				if (this.ownerTrans != null)
				{
					this.ownerTrans.eulerAngles = Vector3.zero;
				}
			}
		}
	}

	// Token: 0x0601824E RID: 98894 RVA: 0x00782828 File Offset: 0x00780C28
	public void Stop()
	{
		this.rotateEnd = true;
		if (this.targets != null)
		{
			this.targets.Clear();
		}
		if (this.dicHurtCD != null)
		{
			this.dicHurtCD.Clear();
		}
		if (this.ownerTrans != null)
		{
			this.ownerTrans.eulerAngles = Vector3.zero;
		}
	}

	// Token: 0x0601824F RID: 98895 RVA: 0x00782889 File Offset: 0x00780C89
	public override void OnFinish()
	{
		this.Stop();
		this.targets = null;
		this.dicHurtCD = null;
	}

	// Token: 0x0401169E RID: 71326
	public int rTime;

	// Token: 0x0401169F RID: 71327
	public int orientation;

	// Token: 0x040116A0 RID: 71328
	private int angle;

	// Token: 0x040116A1 RID: 71329
	private int distance;

	// Token: 0x040116A2 RID: 71330
	private int interval;

	// Token: 0x040116A3 RID: 71331
	private int attackId;

	// Token: 0x040116A4 RID: 71332
	public bool rotateEnd;

	// Token: 0x040116A5 RID: 71333
	private VFactor minDot;

	// Token: 0x040116A6 RID: 71334
	private VFactor angleAcc;

	// Token: 0x040116A7 RID: 71335
	private VInt3 startDir;

	// Token: 0x040116A8 RID: 71336
	private int realDir;

	// Token: 0x040116A9 RID: 71337
	private int rotateTimer;

	// Token: 0x040116AA RID: 71338
	private List<BeActor> targets;

	// Token: 0x040116AB RID: 71339
	private Dictionary<BeActor, int> dicHurtCD;

	// Token: 0x040116AC RID: 71340
	private int findTargetsTimer;

	// Token: 0x040116AD RID: 71341
	private Transform ownerTrans;
}
