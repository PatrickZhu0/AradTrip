using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x020042E1 RID: 17121
public class Mechanism1174 : BeMechanism
{
	// Token: 0x06017B0F RID: 97039 RVA: 0x0074D168 File Offset: 0x0074B568
	public Mechanism1174(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B10 RID: 97040 RVA: 0x0074D174 File Offset: 0x0074B574
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onChangeMagicElement, new BeEventHandle.Del(this._OnChangeMagicElement));
		this.handleNewA = base.owner.RegisterEventNew(BeEventType.onChangeMagicElementList, new BeEvent.BeEventHandleNew.Function(this._OnChangeMagicElementList));
	}

	// Token: 0x06017B11 RID: 97041 RVA: 0x0074D1CC File Offset: 0x0074B5CC
	private void _OnChangeMagicElement(object[] args)
	{
		MagicElementType maxMagicType = this.GetMaxMagicType();
		if (maxMagicType == MagicElementType.NONE)
		{
			return;
		}
		int[] array = (int[])args[0];
		array[0] = (int)maxMagicType;
	}

	// Token: 0x06017B12 RID: 97042 RVA: 0x0074D1F4 File Offset: 0x0074B5F4
	private void _OnChangeMagicElementList(BeEvent.BeEventParam param)
	{
		MagicElementType maxMagicType = this.GetMaxMagicType();
		if (maxMagicType == MagicElementType.NONE)
		{
			return;
		}
		List<int> list = (List<int>)param.m_Obj;
		if (!list.Contains((int)maxMagicType))
		{
			list.Add((int)maxMagicType);
		}
	}

	// Token: 0x06017B13 RID: 97043 RVA: 0x0074D230 File Offset: 0x0074B630
	private MagicElementType GetMaxMagicType()
	{
		MagicElementType result = MagicElementType.NONE;
		int num = 0;
		for (int i = 1; i < 5; i++)
		{
			int num2 = base.owner.attribute.battleData.magicElementsAttack[i];
			if (num2 > num)
			{
				num = num2;
				result = (MagicElementType)i;
			}
		}
		return result;
	}
}
