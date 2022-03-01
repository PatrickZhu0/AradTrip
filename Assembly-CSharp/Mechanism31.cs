using System;
using System.Collections.Generic;

// Token: 0x020043DD RID: 17373
public class Mechanism31 : BeMechanism
{
	// Token: 0x060181A7 RID: 98727 RVA: 0x0077DDF9 File Offset: 0x0077C1F9
	public Mechanism31(int mid, int lv) : base(mid, lv)
	{
		this.m_MonserLevel = lv;
	}

	// Token: 0x060181A8 RID: 98728 RVA: 0x0077DE34 File Offset: 0x0077C234
	public override void OnInit()
	{
		this.m_MonsterId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
			if (valueFromUnionCell > 0)
			{
				this.m_BuffIdList.Add(valueFromUnionCell);
			}
		}
		for (int j = 0; j < this.data.ValueC.Count; j++)
		{
			int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.data.ValueC[j], this.level, true);
			if (valueFromUnionCell2 > 0)
			{
				this.m_BuffInfoIdList.Add(valueFromUnionCell2);
			}
		}
		if (this.data.ValueD.Length > 0)
		{
			this.m_needChangePos = (TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true) == 0);
		}
		if (this.data.ValueE.Length > 0)
		{
			this.m_needPassDoor = (TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true) != 0);
		}
	}

	// Token: 0x060181A9 RID: 98729 RVA: 0x0077DFAB File Offset: 0x0077C3AB
	public override void OnStart()
	{
		this.DoAction();
	}

	// Token: 0x060181AA RID: 98730 RVA: 0x0077DFB4 File Offset: 0x0077C3B4
	protected void DoAction()
	{
		int camp = (base.owner.m_iCamp != 0) ? 0 : 1;
		this.m_Monster = base.owner.CurrentBeScene.SummonMonster(this.m_MonsterId, base.owner.GetPosition(), camp, null, false, this.m_MonserLevel, true, 0, false, false);
		if (this.m_Monster != null)
		{
			if (this.m_Monster.IsDead() && base.owner.CurrentBeScene.state >= BeSceneState.onBulletTime)
			{
				return;
			}
			if (this.m_MonsterStateHandle != null)
			{
				this.m_MonsterStateHandle.Remove();
			}
			this.m_MonsterStateHandle = this.m_Monster.RegisterEvent(BeEventType.onDead, delegate(object[] args)
			{
				this.RemoveFunction();
			});
		}
		if (this.m_needPassDoor)
		{
			if (this.m_passDoorHandle != null)
			{
				this.m_passDoorHandle.Remove();
			}
			this.m_passDoorHandle = base.owner.RegisterEvent(BeEventType.onStartPassDoor, new BeEventHandle.Del(this.onStartPassDoor));
		}
		this.AddBuffInfoToOwner();
		if (this.m_OwnerDeadHandle != null)
		{
			this.m_OwnerDeadHandle.Remove();
		}
		this.m_OwnerDeadHandle = base.owner.RegisterEvent(BeEventType.onDead, delegate(object[] args)
		{
			if (this.m_Monster != null && !this.m_Monster.IsDead())
			{
				this.m_Monster.DoDead(false);
			}
		});
		this.m_OrigionOPos = this.m_Monster.GetPosition();
		if (this.m_needChangePos)
		{
			base.owner.SetPosition(new VInt3(this.m_OrigionOPos.x, this.m_OrigionOPos.y, -10 * VInt.one.i), false, true, false);
		}
	}

	// Token: 0x060181AB RID: 98731 RVA: 0x0077E143 File Offset: 0x0077C543
	private void onStartPassDoor(object[] args)
	{
		if (this.m_Monster != null && !this.m_Monster.IsDead())
		{
			this.RemoveFunction();
		}
	}

	// Token: 0x060181AC RID: 98732 RVA: 0x0077E168 File Offset: 0x0077C568
	protected void AddBuffInfoToOwner()
	{
		for (int i = 0; i < this.m_BuffInfoIdList.Count; i++)
		{
			base.owner.buffController.TryAddBuff(this.m_BuffInfoIdList[i], null, false, null, 0);
		}
	}

	// Token: 0x060181AD RID: 98733 RVA: 0x0077E1B4 File Offset: 0x0077C5B4
	protected void RemoveFunction()
	{
		for (int i = 0; i < this.m_BuffIdList.Count; i++)
		{
			base.owner.buffController.RemoveBuff(this.m_BuffIdList[i], 0, 0);
		}
		base.owner.SetPosition(this.m_OrigionOPos, false, true, false);
	}

	// Token: 0x04011608 RID: 71176
	protected int m_MonsterId;

	// Token: 0x04011609 RID: 71177
	protected List<int> m_BuffInfoIdList = new List<int>();

	// Token: 0x0401160A RID: 71178
	protected List<int> m_BuffIdList = new List<int>();

	// Token: 0x0401160B RID: 71179
	protected BeActor m_Monster;

	// Token: 0x0401160C RID: 71180
	protected VInt3 m_OrigionOPos = VInt3.zero;

	// Token: 0x0401160D RID: 71181
	protected BeEventHandle m_MonsterStateHandle;

	// Token: 0x0401160E RID: 71182
	protected BeEventHandle m_OwnerDeadHandle;

	// Token: 0x0401160F RID: 71183
	protected BeEventHandle m_passDoorHandle;

	// Token: 0x04011610 RID: 71184
	protected int m_MonserLevel;

	// Token: 0x04011611 RID: 71185
	private bool m_needChangePos = true;

	// Token: 0x04011612 RID: 71186
	private bool m_needPassDoor;
}
