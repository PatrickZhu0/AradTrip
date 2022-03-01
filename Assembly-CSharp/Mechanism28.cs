using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020043D8 RID: 17368
public class Mechanism28 : BeMechanism
{
	// Token: 0x0601818B RID: 98699 RVA: 0x0077CED8 File Offset: 0x0077B2D8
	public Mechanism28(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601818C RID: 98700 RVA: 0x0077CF3C File Offset: 0x0077B33C
	public override void OnInit()
	{
		this.m_RebornState = Mechanism28.RebornState.Start;
		this.m_MonsterId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_DelayTime = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.m_RebornTime = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.m_HpRate = (float)TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x0601818D RID: 98701 RVA: 0x0077CFF4 File Offset: 0x0077B3F4
	public override void OnStart()
	{
		base.owner.StartSpellBar(eDungeonCharactorBar.Buff, this.m_RebornTime, true, this.m_Text, false);
		base.owner.CurrentBeScene.FindActorById(this.m_MonsterList, this.m_MonsterId);
		this.m_MonsterCount = this.m_MonsterList.Count;
		for (int i = 0; i < this.m_MonsterList.Count; i++)
		{
			BeActor beActor = this.m_MonsterList[i];
			beActor.buffController.TryAddBuff(2, GlobalLogic.VALUE_1500, 1);
			VInt3 item = this._SetFakeMonsetPos(i, beActor);
			this.m_TargetPos.Add(item);
		}
		base.owner.delayCaller.DelayCall(this.m_DelayTime, delegate
		{
			this._MoveBack();
		}, 0, 0, false);
		base.owner.delayCaller.DelayCall(this.m_RebornTime, delegate
		{
			List<BeActor> list = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.FindActorById(list, this.m_MonsterId);
			if (list.Count > 0)
			{
				this.m_RebornState = Mechanism28.RebornState.Reborning;
				this._RemoveMonster();
				int healValue = (int)((float)base.owner.GetEntityData().battleData.maxHp * this.m_HpRate / (float)GlobalLogic.VALUE_1000 * (float)list.Count / (float)this.m_MonsterCount);
				base.owner.DoHeal(healValue, true);
				base.owner.protectManager.SetEnable(true);
				if (base.owner.HasAction("Getup"))
				{
					base.owner.PlayAction("Getup", 1f);
				}
				base.owner.StopSpellBar(eDungeonCharactorBar.Buff, true);
			}
			else
			{
				base.owner.StopSpellBar(eDungeonCharactorBar.Buff, true);
				base.owner.buffController.RemoveBuff(2, 0, 0);
				base.owner.DoDead(false);
			}
			ListPool<BeActor>.Release(list);
		}, 0, 0, false);
	}

	// Token: 0x0601818E RID: 98702 RVA: 0x0077D0E9 File Offset: 0x0077B4E9
	public override void OnFinish()
	{
		this.m_MonsterList.Clear();
		this.m_RebornState = Mechanism28.RebornState.End;
	}

	// Token: 0x0601818F RID: 98703 RVA: 0x0077D100 File Offset: 0x0077B500
	protected void _RemoveMonster()
	{
		for (int i = 0; i < this.m_MonsterList.Count; i++)
		{
			if (this.m_MonsterList[i] != null && !this.m_MonsterList[i].IsDead())
			{
				this.m_MonsterList[i].DoDead(false);
			}
		}
	}

	// Token: 0x06018190 RID: 98704 RVA: 0x0077D164 File Offset: 0x0077B564
	protected VInt3 _SetFakeMonsetPos(int index, BeActor actor)
	{
		BeScene currentBeScene = base.owner.CurrentBeScene;
		int num = this.m_MonsterCount / 2;
		int i = currentBeScene.logicXSize.y - currentBeScene.logicXSize.x;
		int i2 = currentBeScene.logicZSize.y - currentBeScene.logicZSize.x;
		int num2 = index + 1;
		int x;
		int y;
		if (num2 % 2 != 0)
		{
			x = currentBeScene.logicXSize.x + i * VFactor.NewVFactor((long)((num2 + 1) / 2), (long)(num + 1));
			y = currentBeScene.logicZSize.x + i2 * VFactor.NewVFactor(1L, 6L);
		}
		else
		{
			x = currentBeScene.logicXSize.x + i * VFactor.NewVFactor((long)(num2 / 2), (long)(num + 1));
			y = currentBeScene.logicZSize.x + i2 * VFactor.NewVFactor(5L, 6L);
		}
		VInt3 result = new VInt3(x, y, actor.GetPosition().z);
		return result;
	}

	// Token: 0x06018191 RID: 98705 RVA: 0x0077D26C File Offset: 0x0077B66C
	private void _moveTo(BeActor actor, VInt3 targetPos)
	{
		if (actor == null || actor.IsDead())
		{
			return;
		}
		VInt3 vint = targetPos - actor.GetPosition();
		actor.ResetMoveCmd();
		if (this.m_MoveBackFlag)
		{
			actor.speedConfig = new VInt3(7 * VInt.one.i, 7 * VInt.one.i, 0);
		}
		else
		{
			actor.speedConfig = new VInt3(4 * VInt.one.i, 4 * VInt.one.i, 0);
		}
		if (vint.x > VInt.half)
		{
			actor.ModifyMoveCmd(0, true);
		}
		else if (vint.x < -VInt.half)
		{
			actor.ModifyMoveCmd(1, true);
		}
		if (vint.y > VInt.half)
		{
			actor.ModifyMoveCmd(2, true);
		}
		else if (vint.y < -VInt.half)
		{
			actor.ModifyMoveCmd(3, true);
		}
	}

	// Token: 0x06018192 RID: 98706 RVA: 0x0077D3A4 File Offset: 0x0077B7A4
	protected void _MoveBack()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindActorById(list, this.m_MonsterId);
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] != null && !list[i].IsDead())
			{
				list[i].buffController.TryAddBuff(2, 5000, 1);
			}
		}
		this.m_MoveBackFlag = true;
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06018193 RID: 98707 RVA: 0x0077D42C File Offset: 0x0077B82C
	private void _Move(int delta)
	{
		if (this.m_TargetPos.Count == this.m_MonsterList.Count)
		{
			for (int i = 0; i < this.m_MonsterList.Count; i++)
			{
				if (!this.m_MoveBackFlag)
				{
					this._moveTo(this.m_MonsterList[i], this.m_TargetPos[i]);
				}
				else
				{
					this._moveTo(this.m_MonsterList[i], base.owner.GetPosition());
				}
			}
		}
	}

	// Token: 0x06018194 RID: 98708 RVA: 0x0077D4BC File Offset: 0x0077B8BC
	private bool _HaveMonsterAlive()
	{
		if (this.m_MonsterList.Count <= 0)
		{
			return true;
		}
		for (int i = 0; i < this.m_MonsterList.Count; i++)
		{
			if (!this.m_MonsterList[i].IsDead())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06018195 RID: 98709 RVA: 0x0077D514 File Offset: 0x0077B914
	public override void OnUpdate(int delta)
	{
		base.OnUpdate(delta);
		if (this.m_RebornState == Mechanism28.RebornState.Start && !this._HaveMonsterAlive())
		{
			base.owner.StopSpellBar(eDungeonCharactorBar.Buff, true);
			base.owner.buffController.RemoveBuff(2, 0, 0);
			base.owner.DoDead(false);
		}
		this._Move(delta);
	}

	// Token: 0x040115E9 RID: 71145
	protected int m_MonsterId = 2630011;

	// Token: 0x040115EA RID: 71146
	protected int m_DelayTime = 5000;

	// Token: 0x040115EB RID: 71147
	protected int m_RebornTime = 6000;

	// Token: 0x040115EC RID: 71148
	protected string m_Text = "复活中...";

	// Token: 0x040115ED RID: 71149
	protected float m_HpRate = 100f;

	// Token: 0x040115EE RID: 71150
	protected Mechanism28.RebornState m_RebornState;

	// Token: 0x040115EF RID: 71151
	protected int m_MonsterCount;

	// Token: 0x040115F0 RID: 71152
	protected List<BeActor> m_MonsterList = new List<BeActor>();

	// Token: 0x040115F1 RID: 71153
	protected List<VInt3> m_TargetPos = new List<VInt3>();

	// Token: 0x040115F2 RID: 71154
	protected bool m_MoveBackFlag;

	// Token: 0x020043D9 RID: 17369
	protected enum RebornState
	{
		// Token: 0x040115F4 RID: 71156
		Start,
		// Token: 0x040115F5 RID: 71157
		Reborning,
		// Token: 0x040115F6 RID: 71158
		End
	}
}
