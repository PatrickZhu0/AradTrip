using System;
using System.Collections.Generic;

// Token: 0x020043A0 RID: 17312
public class Mechanism2105 : BeMechanism
{
	// Token: 0x06018011 RID: 98321 RVA: 0x00770F79 File Offset: 0x0076F379
	public Mechanism2105(int id, int level) : base(id, level)
	{
	}

	// Token: 0x1700200C RID: 8204
	// (get) Token: 0x06018012 RID: 98322 RVA: 0x00770F8E File Offset: 0x0076F38E
	public List<int> AddBuffInfoIdList
	{
		get
		{
			return this._addBuffInfoIdList;
		}
	}

	// Token: 0x06018013 RID: 98323 RVA: 0x00770F98 File Offset: 0x0076F398
	public override void OnInit()
	{
		base.OnInit();
		this._addBuffInfoIdList.Clear();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this._addBuffInfoIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
	}

	// Token: 0x040114A3 RID: 70819
	private List<int> _addBuffInfoIdList = new List<int>();
}
