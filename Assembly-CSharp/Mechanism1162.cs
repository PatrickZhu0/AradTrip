using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020042D7 RID: 17111
public class Mechanism1162 : BeMechanism
{
	// Token: 0x06017AD5 RID: 96981 RVA: 0x0074C2A5 File Offset: 0x0074A6A5
	public Mechanism1162(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017AD6 RID: 96982 RVA: 0x0074C2D0 File Offset: 0x0074A6D0
	public override void OnInit()
	{
		base.OnInit();
		this._time = TableManager.GetValueFromUnionCell((!BattleMain.IsModePvP(base.battleType)) ? this.data.ValueA[1] : this.data.ValueA[0], this.level, true);
		this._buffIdList.Clear();
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this._buffIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
	}

	// Token: 0x06017AD7 RID: 96983 RVA: 0x0074C38A File Offset: 0x0074A78A
	public override void OnStart()
	{
		base.OnStart();
		this._state = Mechanism1162.LifeState.None;
		this._RegisterEvent();
	}

	// Token: 0x06017AD8 RID: 96984 RVA: 0x0074C39F File Offset: 0x0074A79F
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this._UpdateBaoZouState(deltaTime);
	}

	// Token: 0x06017AD9 RID: 96985 RVA: 0x0074C3AF File Offset: 0x0074A7AF
	private void _RegisterEvent()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onHPChange, new BeEventHandle.Del(this._OnHPChange));
	}

	// Token: 0x06017ADA RID: 96986 RVA: 0x0074C3D0 File Offset: 0x0074A7D0
	private void _UpdateBaoZouState(int deltaTime)
	{
		if (this._state != Mechanism1162.LifeState.BaoZou)
		{
			return;
		}
		this._curTime += deltaTime;
		if (this._curTime >= this._time)
		{
			this._state = Mechanism1162.LifeState.WillDead;
			base.owner.DoDead(false);
		}
	}

	// Token: 0x06017ADB RID: 96987 RVA: 0x0074C41C File Offset: 0x0074A81C
	private void _OnHPChange(object[] args)
	{
		if (this._state != Mechanism1162.LifeState.None)
		{
			return;
		}
		int hp = base.owner.GetEntityData().GetHP();
		if (hp > 0)
		{
			return;
		}
		this._state = Mechanism1162.LifeState.BaoZou;
		base.owner.buffController.RemoveAllAbnormalBuff();
		this._AddEquipBuffInfo();
		this._AddBuff();
		base.owner.GetEntityData().SetHP(1);
		base.owner.SetIsDead(false);
	}

	// Token: 0x06017ADC RID: 96988 RVA: 0x0074C490 File Offset: 0x0074A890
	private void _AddBuff()
	{
		for (int i = 0; i < this._buffIdList.Count; i++)
		{
			base.owner.buffController.TryAddBuff(this._buffIdList[i], this._time, 1);
		}
	}

	// Token: 0x06017ADD RID: 96989 RVA: 0x0074C4E0 File Offset: 0x0074A8E0
	private void _AddEquipBuffInfo()
	{
		BeActor topOwner = base.GetTopOwner();
		if (topOwner == null)
		{
			return;
		}
		List<BeMechanism> list = ListPool<BeMechanism>.Get();
		topOwner.GetMechanismsByIndex(list, this._equipMechanismIndex);
		for (int i = 0; i < list.Count; i++)
		{
			Mechanism2105 mechanism = list[i] as Mechanism2105;
			if (mechanism != null)
			{
				base.owner.buffController.TryAddBuffInfo(mechanism.AddBuffInfoIdList[i], topOwner, this.level);
			}
		}
		ListPool<BeMechanism>.Release(list);
	}

	// Token: 0x04011044 RID: 69700
	private int _time = 5000;

	// Token: 0x04011045 RID: 69701
	private List<int> _buffIdList = new List<int>();

	// Token: 0x04011046 RID: 69702
	private int _curTime;

	// Token: 0x04011047 RID: 69703
	private Mechanism1162.LifeState _state;

	// Token: 0x04011048 RID: 69704
	private int _equipMechanismIndex = 2105;

	// Token: 0x020042D8 RID: 17112
	private enum LifeState
	{
		// Token: 0x0401104A RID: 69706
		None,
		// Token: 0x0401104B RID: 69707
		BaoZou,
		// Token: 0x0401104C RID: 69708
		WillDead
	}
}
