using System;
using System.Collections.Generic;
using GamePool;
using UnityEngine;

// Token: 0x020044C3 RID: 17603
public class Skill3210 : BeSkill
{
	// Token: 0x060187DC RID: 100316 RVA: 0x007A505C File Offset: 0x007A345C
	public Skill3210(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060187DD RID: 100317 RVA: 0x007A50CC File Offset: 0x007A34CC
	public override void OnPostInit()
	{
		this.number = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.intervel = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		this.radius = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true), GlobalLogic.VALUE_1000);
		this.backDis = this.radius.i / 2;
		this.height = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x060187DE RID: 100318 RVA: 0x007A5194 File Offset: 0x007A3594
	public override void OnStart()
	{
		this.ModifySkillParam();
		this.lastPos = base.owner.GetPosition();
		this.tempPos = VInt3.zero;
		this.timer = 0;
		this.count = this.number;
		this.hitOther = false;
		this.hitList.Clear();
		this.handle1 = base.owner.RegisterEvent(BeEventType.onCollide, delegate(object[] args)
		{
			BeActor beActor = args[0] as BeActor;
			if (beActor != null)
			{
				this.hitOther = true;
				this.timer = this.intervel;
			}
		});
		this.handle2 = base.owner.RegisterEvent(BeEventType.onChangeHitEffect, delegate(object[] args)
		{
			int num = (int)args[0];
			if (num == this.effectId)
			{
				string[] array = (string[])args[1];
				array[0] = this.hitEffectPath;
			}
		});
	}

	// Token: 0x060187DF RID: 100319 RVA: 0x007A522C File Offset: 0x007A362C
	private void ModifySkillParam()
	{
		int num = GlobalLogic.VALUE_1000;
		for (int i = 0; i < base.owner.MechanismList.Count; i++)
		{
			Mechanism127 mechanism = base.owner.MechanismList[i] as Mechanism127;
			if (mechanism != null)
			{
				this.number += mechanism.attackNum;
				num += mechanism.radiusRate;
			}
		}
		if (num != GlobalLogic.VALUE_1000)
		{
			this.radius = this.radius.i * VFactor.NewVFactor(num, GlobalLogic.VALUE_1000);
			this.backDis = this.radius.i / 2;
		}
	}

	// Token: 0x060187E0 RID: 100320 RVA: 0x007A52E4 File Offset: 0x007A36E4
	private void RestoreSkillParam()
	{
		this.number = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.radius = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true), GlobalLogic.VALUE_1000);
		this.backDis = this.radius.i / 2;
	}

	// Token: 0x060187E1 RID: 100321 RVA: 0x007A535C File Offset: 0x007A375C
	private void FindNextTarget()
	{
		List<BeActor> targets = this.GetTargets();
		if (targets.Count == 0)
		{
			this.count = 0;
			return;
		}
		if (targets.Count == 1 && this.hitList.Count >= 1 && targets[0].Equals(this.hitList[this.hitList.Count - 1]))
		{
			if (this.count == 1)
			{
				return;
			}
			VInt3 position = targets[0].GetPosition();
			position.z = 0;
			VInt3 vint = this.lastPos - position;
			VInt3 vint2;
			if (this.tempPos == VInt3.zero || (this.tempPos - base.owner.GetPosition()).magnitude > this.radius.i)
			{
				vint2 = base.owner.GetPosition() + vint.NormalizeTo(this.backDis.i);
			}
			else
			{
				vint2 = this.tempPos;
			}
			this.lastPos = base.owner.GetPosition();
			base.owner.SetPosition(vint2, false, true, false);
			this.tempPos = vint2;
			base.owner.SetFace(vint2.x > this.lastPos.x, false, false);
			this.hitList.Clear();
			((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteSkill(this.pose2);
			this.CreateTrailEffect(vint2, this.lastPos, 3800);
		}
		else
		{
			BeActor beActor = null;
			int num = int.MaxValue;
			for (int i = 0; i < targets.Count; i++)
			{
				int num2 = this.hitList.IndexOf(targets[i]);
				if (num2 == -1)
				{
					beActor = targets[i];
					break;
				}
				if (num2 < num)
				{
					num = num2;
				}
			}
			if (beActor == null)
			{
				if (this.hitList.Count <= num)
				{
					return;
				}
				beActor = this.hitList[num];
				this.hitList.RemoveAt(num);
			}
			this.RefleshHitList();
			this.hitList.Add(beActor);
			VInt3 position2 = beActor.GetPosition();
			VInt3 position3 = beActor.GetPosition();
			position3.z = 0;
			position3.x -= 7000;
			int magnitude = (base.owner.GetPosition() - position3).magnitude;
			VInt3 position4 = beActor.GetPosition();
			position4.z = 0;
			position4.x += 7000;
			int magnitude2 = (base.owner.GetPosition() - position4).magnitude;
			this.lastPos = base.owner.GetPosition();
			if (magnitude < magnitude2)
			{
				position2.x -= GlobalLogic.VALUE_1000;
				base.owner.SetPosition(position3, false, true, false);
				base.owner.SetFace(false, false, false);
				this.CreateTrailEffect(position3, this.lastPos, 6600);
			}
			else
			{
				position2.x += GlobalLogic.VALUE_1000;
				base.owner.SetPosition(position4, false, true, false);
				base.owner.SetFace(true, false, false);
				this.CreateTrailEffect(position4, this.lastPos, 6600);
			}
			position2.z = VInt.one.i;
			base.owner._onHurtEntity(beActor, position2, this.effectId);
			((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteSkill(this.pose1);
		}
	}

	// Token: 0x060187E2 RID: 100322 RVA: 0x007A5718 File Offset: 0x007A3B18
	private void RefleshHitList()
	{
		for (int i = this.hitList.Count - 1; i >= 0; i--)
		{
			if (this.hitList[i].IsDead())
			{
				this.hitList.RemoveAt(i);
			}
		}
	}

	// Token: 0x060187E3 RID: 100323 RVA: 0x007A5768 File Offset: 0x007A3B68
	private List<BeActor> GetTargets()
	{
		List<BeActor> list = new List<BeActor>();
		List<BeActor> list2 = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindTargets(list2, base.owner, this.radius, false, null);
		for (int i = 0; i < list2.Count; i++)
		{
			BeActor beActor = list2[i];
			if (beActor != null && !beActor.IsDead() && beActor.GetPosition().z < this.height.i && !beActor.stateController.HasBuffState(BeBuffStateType.INVINCIBLE) && !base.owner.CurrentBeScene.IsInBlockPlayer(beActor.GetPosition()))
			{
				list.Add(beActor);
			}
		}
		ListPool<BeActor>.Release(list2);
		list.Sort(delegate(BeActor a, BeActor b)
		{
			int magnitude = (base.owner.GetPosition() - a.GetPosition()).magnitude;
			int magnitude2 = (base.owner.GetPosition() - b.GetPosition()).magnitude;
			if (magnitude != magnitude2)
			{
				return magnitude.CompareTo(magnitude2);
			}
			return a.GetPID().CompareTo(b.GetPID());
		});
		return list;
	}

	// Token: 0x060187E4 RID: 100324 RVA: 0x007A583C File Offset: 0x007A3C3C
	private void CreateTrailEffect(VInt3 start, VInt3 end, int zOffset)
	{
		if (this.count == this.number)
		{
			return;
		}
		start.z += zOffset;
		end.z += zOffset;
		start.y -= 3300;
		end.y -= 3300;
		Vector3 vector = end.vector3 - start.vector3;
		float num = Vector3.Angle(Vector3.left, vector);
		float y = Vector3.Cross(Vector3.left, vector).normalized.y;
		if (y != 0f)
		{
			num *= y;
		}
		if (80f < num && num <= 90f)
		{
			num = 80f;
		}
		else if (90f < num && num < 100f)
		{
			num = 100f;
		}
		else if (-90f <= num && num < -80f)
		{
			num = -80f;
		}
		else if (-100f < num && num < -90f)
		{
			num = -100f;
		}
		int magnitude = (start - end).magnitude;
		string effectPath;
		if (magnitude > 32000)
		{
			effectPath = this.effectPath1;
		}
		else if (magnitude > 16000)
		{
			effectPath = this.effectPath2;
		}
		else
		{
			effectPath = this.effectPath3;
		}
		GeEffectEx geEffectEx = base.owner.CurrentBeScene.currentGeScene.CreateEffect(effectPath, 0.2f, start.vec3, 1f, 1f, false, false);
		geEffectEx.GetRootNode().transform.eulerAngles = Vector3.up * num;
	}

	// Token: 0x060187E5 RID: 100325 RVA: 0x007A5A04 File Offset: 0x007A3E04
	public override void OnUpdate(int iDeltime)
	{
		if (!this.hitOther)
		{
			return;
		}
		if (this.count <= 0)
		{
			return;
		}
		this.timer += iDeltime;
		if (this.timer >= this.intervel)
		{
			this.FindNextTarget();
			this.timer = 0;
			this.count--;
		}
	}

	// Token: 0x060187E6 RID: 100326 RVA: 0x007A5A64 File Offset: 0x007A3E64
	public override void OnCancel()
	{
		this.Release();
	}

	// Token: 0x060187E7 RID: 100327 RVA: 0x007A5A6C File Offset: 0x007A3E6C
	public override void OnFinish()
	{
		this.Release();
	}

	// Token: 0x060187E8 RID: 100328 RVA: 0x007A5A74 File Offset: 0x007A3E74
	private void Release()
	{
		VInt3 vint = base.owner.GetPosition();
		if (base.owner.CurrentBeScene.IsInBlockPlayer(vint))
		{
			vint = BeAIManager.FindStandPositionNew(base.owner.GetPosition(), base.owner.CurrentBeScene, base.owner.GetFace(), false, 50);
			base.owner.SetPosition(vint, false, true, false);
		}
		this.RestoreSkillParam();
		this.RemoveHandles();
	}

	// Token: 0x060187E9 RID: 100329 RVA: 0x007A5AE8 File Offset: 0x007A3EE8
	private void RemoveHandles()
	{
		if (this.handle1 != null)
		{
			this.handle1.Remove();
			this.handle1 = null;
		}
		if (this.handle2 != null)
		{
			this.handle2.Remove();
			this.handle2 = null;
		}
	}

	// Token: 0x04011AB5 RID: 72373
	private int number;

	// Token: 0x04011AB6 RID: 72374
	private int intervel;

	// Token: 0x04011AB7 RID: 72375
	private VInt radius;

	// Token: 0x04011AB8 RID: 72376
	private VInt backDis;

	// Token: 0x04011AB9 RID: 72377
	private VInt height;

	// Token: 0x04011ABA RID: 72378
	private int pose1 = 32103;

	// Token: 0x04011ABB RID: 72379
	private int pose2 = 32104;

	// Token: 0x04011ABC RID: 72380
	private int effectId = 32100;

	// Token: 0x04011ABD RID: 72381
	private string effectPath1 = "Effects/Hero_Sanda/Eff_Sanda_shandianzhiwu/Prefab/Eff_Sanda_shandianzhiwu_shunyi";

	// Token: 0x04011ABE RID: 72382
	private string effectPath2 = "Effects/Hero_Sanda/Eff_Sanda_shandianzhiwu/Prefab/Eff_Sanda_shandianzhiwu_shunyi02";

	// Token: 0x04011ABF RID: 72383
	private string effectPath3 = "Effects/Hero_Sanda/Eff_Sanda_shandianzhiwu/Prefab/Eff_Sanda_shandianzhiwu_shunyi03";

	// Token: 0x04011AC0 RID: 72384
	private string hitEffectPath = "Effects/Hero_Sanda/Eff_Sanda_shandianzhiwu/Prefab/Eff_Sanda_shandianzhiwu_beiji";

	// Token: 0x04011AC1 RID: 72385
	private VInt3 lastPos;

	// Token: 0x04011AC2 RID: 72386
	private VInt3 tempPos;

	// Token: 0x04011AC3 RID: 72387
	private int timer;

	// Token: 0x04011AC4 RID: 72388
	private int count;

	// Token: 0x04011AC5 RID: 72389
	private bool hitOther;

	// Token: 0x04011AC6 RID: 72390
	private BeEventHandle handle1;

	// Token: 0x04011AC7 RID: 72391
	private BeEventHandle handle2;

	// Token: 0x04011AC8 RID: 72392
	private List<BeActor> hitList = new List<BeActor>();
}
