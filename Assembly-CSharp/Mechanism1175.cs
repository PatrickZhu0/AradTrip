using System;
using GameClient;

// Token: 0x020042E2 RID: 17122
public class Mechanism1175 : BeMechanism
{
	// Token: 0x06017B14 RID: 97044 RVA: 0x0074D285 File Offset: 0x0074B685
	public Mechanism1175(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B15 RID: 97045 RVA: 0x0074D290 File Offset: 0x0074B690
	public override void OnInit()
	{
		base.OnInit();
		this.m_BuffInfoIdList = new int[this.data.ValueALength];
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.m_BuffInfoIdList[i] = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
		}
	}

	// Token: 0x06017B16 RID: 97046 RVA: 0x0074D304 File Offset: 0x0074B704
	public override void OnStart()
	{
		base.OnStart();
		this.handleNewA = base.owner.RegisterEventNew(BeEventType.onUseMuscleShift, new BeEvent.BeEventHandleNew.Function(this.OnUseMuscleShift));
		this.handleA = base.owner.RegisterEvent(BeEventType.onCastSkillFinish, new BeEventHandle.Del(this.OnSkillEnd));
		this.handleB = base.owner.RegisterEvent(BeEventType.onSkillCancel, new BeEventHandle.Del(this.OnSkillEnd));
	}

	// Token: 0x06017B17 RID: 97047 RVA: 0x0074D374 File Offset: 0x0074B774
	private void OnSkillEnd(object[] args)
	{
		if ((int)args[0] != this.m_NextSkillId)
		{
			return;
		}
		if (this.m_IsAdd)
		{
			this.RemoveBuffs();
			this.m_IsAdd = false;
		}
	}

	// Token: 0x06017B18 RID: 97048 RVA: 0x0074D3A4 File Offset: 0x0074B7A4
	private void RemoveBuffs()
	{
		for (int i = 0; i < this.m_BuffInfoIdList.Length; i++)
		{
			base.owner.buffController.RemoveBuffByBuffInfoID(this.m_BuffInfoIdList[i]);
		}
	}

	// Token: 0x06017B19 RID: 97049 RVA: 0x0074D3E2 File Offset: 0x0074B7E2
	public override void OnFinish()
	{
		base.OnFinish();
		if (this.m_IsAdd)
		{
			this.RemoveBuffs();
			this.m_IsAdd = false;
		}
	}

	// Token: 0x06017B1A RID: 97050 RVA: 0x0074D404 File Offset: 0x0074B804
	private void OnUseMuscleShift(BeEvent.BeEventParam param)
	{
		this.m_NextSkillId = param.m_Int2;
		this.m_IsAdd = true;
		for (int i = 0; i < this.m_BuffInfoIdList.Length; i++)
		{
			base.owner.buffController.TryAddBuffInfo(this.m_BuffInfoIdList[i], base.owner, this.level);
		}
	}

	// Token: 0x04011063 RID: 69731
	private int[] m_BuffInfoIdList;

	// Token: 0x04011064 RID: 69732
	private bool m_IsAdd;

	// Token: 0x04011065 RID: 69733
	private int m_NextSkillId;
}
