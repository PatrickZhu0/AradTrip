using System;
using System.Collections.Generic;

// Token: 0x0200430F RID: 17167
public class Mechanism137 : BeMechanism
{
	// Token: 0x06017C06 RID: 97286 RVA: 0x00753CAB File Offset: 0x007520AB
	public Mechanism137(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C07 RID: 97287 RVA: 0x00753CC0 File Offset: 0x007520C0
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.list.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		this.time = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017C08 RID: 97288 RVA: 0x00753D43 File Offset: 0x00752143
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.OnChangeEffectTime, delegate(object[] args)
		{
			int item = (int)args[0];
			if (this.list.Contains(item))
			{
				int[] array = args[1] as int[];
				array[0] = this.time;
			}
		});
	}

	// Token: 0x0401113E RID: 69950
	private List<int> list = new List<int>();

	// Token: 0x0401113F RID: 69951
	private int time;
}
