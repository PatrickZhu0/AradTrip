using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020042B4 RID: 17076
public class Mechanism1122 : BeMechanism
{
	// Token: 0x060179F5 RID: 96757 RVA: 0x00746FAB File Offset: 0x007453AB
	public Mechanism1122(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060179F6 RID: 96758 RVA: 0x00746FD8 File Offset: 0x007453D8
	public override void OnInit()
	{
		this.m_HurtIdList.Clear();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.m_HurtIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		if (this.data.ValueB.Count > 0)
		{
			this.m_BuffInfoId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		}
		this.m_TeleportDis = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x060179F7 RID: 96759 RVA: 0x007470AF File Offset: 0x007454AF
	public override void OnStart()
	{
		base.OnStart();
		this.InitData();
	}

	// Token: 0x060179F8 RID: 96760 RVA: 0x007470C0 File Offset: 0x007454C0
	protected void InitData()
	{
		this.m_CurFace = base.owner.GetFace();
		this.m_Pos = base.owner.GetPosition();
		this.handleA = base.owner.RegisterEvent(BeEventType.onHitOtherAfterHurt, new BeEventHandle.Del(this.OnHitOtherAfterHurt));
	}

	// Token: 0x060179F9 RID: 96761 RVA: 0x00747110 File Offset: 0x00745510
	private void OnHitOtherAfterHurt(object[] args)
	{
		int item = (int)args[1];
		if (!this.m_HurtIdList.Contains(item))
		{
			return;
		}
		BeActor beActor = (BeActor)args[0];
		if (beActor == null || beActor.IsDead())
		{
			return;
		}
		if (beActor.isAbsorb)
		{
			return;
		}
		if (beActor.buffController == null || beActor.buffController.HaveBatiBuff() || beActor.buffController.HasBuffByID(50) != null)
		{
			return;
		}
		if (beActor.stateController == null || !beActor.stateController.HasBornAbility(BeAbilityType.FALLGROUND) || !beActor.stateController.HasBornAbility(BeAbilityType.FLOAT))
		{
			return;
		}
		if (beActor.protectManager != null && beActor.protectManager.IsInGroundProtect())
		{
			return;
		}
		if (this.m_BuffInfoId > 0 && !beActor.stateController.HasBuffState(BeBuffStateType.FROZEN) && !beActor.stateController.HasBuffState(BeBuffStateType.STONE))
		{
			beActor.buffController.TryAddBuff(this.m_BuffInfoId, null, false, null, 0);
		}
		this.MoveTo(beActor);
	}

	// Token: 0x060179FA RID: 96762 RVA: 0x0074722C File Offset: 0x0074562C
	private void MoveTo(BeActor target)
	{
		VInt3 position = target.GetPosition();
		int i = Mathf.Abs((!this.m_CurFace) ? (this.m_Pos.x - position.x) : (position.x - this.m_Pos.x));
		if (i > this.m_TeleportDis)
		{
			return;
		}
		int dur = 200;
		VInt3 pos = this.m_Pos;
		pos.x += ((!this.m_CurFace) ? this.m_TeleportDis.i : (-this.m_TeleportDis.i));
		pos.y = position.y;
		if (this.m_Pos.z > 0)
		{
			pos.z = 0;
		}
		BeActionActorFilter beActionActorFilter = new BeActionActorFilter();
		beActionActorFilter.Init(true, true, true, true, true);
		BeMoveTo action = BeMoveTo.Create(target, dur, position, pos, false, beActionActorFilter, false);
		target.actionManager.RunAction(action);
	}

	// Token: 0x04010FA1 RID: 69537
	private HashSet<int> m_HurtIdList = new HashSet<int>();

	// Token: 0x04010FA2 RID: 69538
	private int m_BuffInfoId;

	// Token: 0x04010FA3 RID: 69539
	private VInt m_TeleportDis = 0;

	// Token: 0x04010FA4 RID: 69540
	protected bool m_CurFace;

	// Token: 0x04010FA5 RID: 69541
	protected VInt3 m_Pos = VInt3.zero;
}
