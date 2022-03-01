using System;
using System.Collections.Generic;

// Token: 0x0200438A RID: 17290
public class Mechanism2082 : BeMechanism
{
	// Token: 0x06017F98 RID: 98200 RVA: 0x0076D750 File Offset: 0x0076BB50
	public Mechanism2082(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017F99 RID: 98201 RVA: 0x0076D768 File Offset: 0x0076BB68
	public override void OnInit()
	{
		if (this.data.ValueA.Count != this.data.ValueB.Count)
		{
			return;
		}
		this.mBuffDic.Clear();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
			int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
			this.mBuffDic.Add(valueFromUnionCell, valueFromUnionCell2);
		}
	}

	// Token: 0x06017F9A RID: 98202 RVA: 0x0076D81F File Offset: 0x0076BC1F
	public override void OnStart()
	{
		if (base.owner == null)
		{
			return;
		}
		this.handleA = base.owner.RegisterEvent(BeEventType.AbnormalBuffHurt, delegate(object[] args)
		{
			BeBuff buff = (BeBuff)args[0];
			int num = this.GetBuffDamagePercent(buff);
			if (num < 0)
			{
				return;
			}
			int[] array = args[1] as int[];
			int num2 = array[0];
			num2 *= VFactor.one - VFactor.NewVFactor(num, GlobalLogic.VALUE_1000);
			array[0] = num2;
		});
	}

	// Token: 0x06017F9B RID: 98203 RVA: 0x0076D850 File Offset: 0x0076BC50
	private CrypticInt32 GetBuffDamagePercent(BeBuff buff)
	{
		for (int i = 0; i < buff.buffData.StateChange.Count; i++)
		{
			int key = buff.buffData.StateChange[i];
			if (this.mBuffDic.ContainsKey(key))
			{
				return this.mBuffDic[key];
			}
		}
		return -1;
	}

	// Token: 0x04011432 RID: 70706
	private Dictionary<int, CrypticInt32> mBuffDic = new Dictionary<int, CrypticInt32>();
}
