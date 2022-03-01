using System;
using System.Collections.Generic;

// Token: 0x02004265 RID: 16997
public class Mechanism1029 : BeMechanism
{
	// Token: 0x0601784F RID: 96335 RVA: 0x0073C4AA File Offset: 0x0073A8AA
	public Mechanism1029(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017850 RID: 96336 RVA: 0x0073C4CC File Offset: 0x0073A8CC
	public override void OnInit()
	{
		base.OnInit();
		this.type = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.buffTypes = new int[this.data.ValueB.Length];
		for (int i = 0; i < this.buffTypes.Length; i++)
		{
			this.buffTypes[i] = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
		}
		this.rates = new int[this.data.ValueC.Length];
		this.addLevels = new int[this.data.ValueC.Length];
		for (int j = 0; j < this.rates.Length; j++)
		{
			this.rates[j] = TableManager.GetValueFromUnionCell(this.data.ValueC[j], this.level, true);
			this.addLevels[j] = TableManager.GetValueFromUnionCell(this.data.ValueC[j], this.level, true);
		}
	}

	// Token: 0x06017851 RID: 96337 RVA: 0x0073C608 File Offset: 0x0073AA08
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onBeforeHit, delegate(object[] args)
		{
			BeActor beActor = (BeActor)args[0];
			if (beActor != null && !this.targetList.Contains(beActor.GetPID()))
			{
				if (this.type == 0)
				{
					BeEventHandle item = beActor.RegisterEvent(BeEventType.onBuffBeforePostInit, delegate(object[] args1)
					{
						BeBuff beBuff = args1[0] as BeBuff;
						int num = Array.IndexOf<int>(this.buffTypes, (int)beBuff.buffType);
						if (beBuff != null && num != -1 && this.type == 0)
						{
							BeBuff beBuff2 = beBuff;
							beBuff2.buffAttack *= VFactor.one + VFactor.NewVFactor(this.rates[num], 1000);
						}
					});
					this.handleList.Add(item);
				}
				else
				{
					BeEventHandle item2 = beActor.RegisterEvent(BeEventType.OnChangeAbnormalBuffLevel, delegate(object[] args1)
					{
						int[] array = args1[0] as int[];
						int value = (int)args1[1];
						int num = Array.IndexOf<int>(this.buffTypes, value);
						if (array != null && num != -1 && this.type == 1)
						{
							array[0] = this.addLevels[num];
						}
					});
					this.handleList.Add(item2);
				}
				this.targetList.Add(beActor.GetPID());
			}
		});
	}

	// Token: 0x06017852 RID: 96338 RVA: 0x0073C62F File Offset: 0x0073AA2F
	public override void OnFinish()
	{
		this.targetList.Clear();
		this.RemoveHandle();
	}

	// Token: 0x06017853 RID: 96339 RVA: 0x0073C644 File Offset: 0x0073AA44
	protected void RemoveHandle()
	{
		for (int i = 0; i < this.handleList.Count; i++)
		{
			this.handleList[i].Remove();
			this.handleList[i] = null;
		}
		this.handleList.Clear();
	}

	// Token: 0x04010E66 RID: 69222
	private int type;

	// Token: 0x04010E67 RID: 69223
	private int[] buffTypes;

	// Token: 0x04010E68 RID: 69224
	private int[] rates;

	// Token: 0x04010E69 RID: 69225
	private int[] addLevels;

	// Token: 0x04010E6A RID: 69226
	protected List<int> targetList = new List<int>();

	// Token: 0x04010E6B RID: 69227
	protected List<BeEventHandle> handleList = new List<BeEventHandle>();
}
