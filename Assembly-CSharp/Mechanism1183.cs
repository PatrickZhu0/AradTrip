using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x020042EC RID: 17132
public class Mechanism1183 : BeMechanism
{
	// Token: 0x06017B45 RID: 97093 RVA: 0x0074E418 File Offset: 0x0074C818
	public Mechanism1183(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B46 RID: 97094 RVA: 0x0074E422 File Offset: 0x0074C822
	public override void OnInit()
	{
		this.mReduceDamagePercent = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x06017B47 RID: 97095 RVA: 0x0074E44C File Offset: 0x0074C84C
	public override void OnStart()
	{
		this._RegisterEvent();
	}

	// Token: 0x06017B48 RID: 97096 RVA: 0x0074E454 File Offset: 0x0074C854
	private void _RegisterEvent()
	{
		this.handleNewA = base.owner.RegisterEventNew(BeEventType.onChangeHurtValue, new BeEvent.BeEventHandleNew.Function(this.OnChangeHurtValue));
	}

	// Token: 0x06017B49 RID: 97097 RVA: 0x0074E478 File Offset: 0x0074C878
	protected void OnChangeHurtValue(BeEvent.BeEventParam param)
	{
		int num = 0;
		int num2 = param.m_Int;
		int @int = param.m_Int2;
		List<int> list = param.m_Obj as List<int>;
		List<int> list2 = param.m_Obj2 as List<int>;
		if (list != null && list2 != null && list.Count == 0)
		{
			list.AddRange(list2);
		}
		int num3;
		if (list != null && list2 != null && list.Count == list2.Count)
		{
			for (int i = 0; i < list.Count; i++)
			{
				num2 -= list[i];
				num3 = IntMath.Double2Int((double)this.mReduceDamagePercent / (double)GlobalLogic.VALUE_1000 * (double)list[i]);
				num += num3;
				List<int> list3;
				int index;
				(list3 = list2)[index = i] = list3[index] - num3;
			}
		}
		num3 = IntMath.Double2Int((double)this.mReduceDamagePercent / (double)GlobalLogic.VALUE_1000 * (double)num2);
		num += num3;
		param.m_Int2 -= num;
		if (param.m_Int2 < 0)
		{
			param.m_Int2 = 0;
			for (int j = 0; j < list2.Count; j++)
			{
				list2[j] = 0;
			}
		}
	}

	// Token: 0x04011084 RID: 69764
	protected int mReduceDamagePercent;
}
