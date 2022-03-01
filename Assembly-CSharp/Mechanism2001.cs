using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02004335 RID: 17205
public class Mechanism2001 : BeMechanism
{
	// Token: 0x06017CD6 RID: 97494 RVA: 0x007599C0 File Offset: 0x00757DC0
	public Mechanism2001(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017CD7 RID: 97495 RVA: 0x00759A0C File Offset: 0x00757E0C
	public override void OnInit()
	{
		base.OnInit();
		this.effectId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this.radiusList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
		for (int j = 0; j < this.data.ValueC.Count; j++)
		{
			this.addXForceList.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[j], this.level, true));
		}
		for (int k = 0; k < this.data.ValueD.Count; k++)
		{
			this.addFloatXForceList.Add(TableManager.GetValueFromUnionCell(this.data.ValueD[k], this.level, true));
		}
	}

	// Token: 0x06017CD8 RID: 97496 RVA: 0x00759B31 File Offset: 0x00757F31
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
		{
			BeActor target = (BeActor)args[0];
			int num = (int)args[1];
			if (target != null && !this.targetList.Contains(target.GetPID()) && this.effectId == num)
			{
				this.targetList.Add(target.GetPID());
				BeEventHandle item = target.RegisterEvent(BeEventType.onChangeXRate, delegate(object[] args1)
				{
					int num2 = (int)args1[0];
					if (this.effectId == num2)
					{
						int[] array = (int[])args1[1];
						array[0] = this.GetXForce(target, false);
					}
				});
				this.handleList.Add(item);
				BeEventHandle item2 = target.RegisterEvent(BeEventType.onChangeFloatXForce, delegate(object[] args2)
				{
					int num2 = (int)args2[0];
					if (this.effectId == num2)
					{
						int[] array = (int[])args2[1];
						array[0] = this.GetXForce(target, true);
					}
				});
				this.handleList.Add(item2);
			}
		});
	}

	// Token: 0x06017CD9 RID: 97497 RVA: 0x00759B52 File Offset: 0x00757F52
	public override void OnFinish()
	{
		this.targetList.Clear();
		this.RemoveHandle();
	}

	// Token: 0x06017CDA RID: 97498 RVA: 0x00759B68 File Offset: 0x00757F68
	protected void RemoveHandle()
	{
		for (int i = 0; i < this.handleList.Count; i++)
		{
			this.handleList[i].Remove();
			this.handleList[i] = null;
		}
		this.handleList.Clear();
	}

	// Token: 0x06017CDB RID: 97499 RVA: 0x00759BBC File Offset: 0x00757FBC
	protected int GetXForce(BeEntity pkEntity, bool isFloat)
	{
		int num = 0;
		if (pkEntity == null)
		{
			return num;
		}
		int magnitude = (pkEntity.GetPosition() - base.owner.GetPosition()).magnitude;
		int num2 = Mathf.Abs(magnitude);
		for (int i = 0; i < this.radiusList.Count; i++)
		{
			int num3 = (i != 0) ? (this.radiusList[i - 1] * GlobalLogic.VALUE_10) : 0;
			if (num2 > num3 && num2 <= this.radiusList[i] * GlobalLogic.VALUE_10)
			{
				if (!isFloat)
				{
					num = this.addXForceList[i];
				}
				else
				{
					num = this.addFloatXForceList[i];
				}
			}
		}
		return (magnitude <= 0) ? (-num) : num;
	}

	// Token: 0x040111FD RID: 70141
	protected int effectId;

	// Token: 0x040111FE RID: 70142
	protected List<int> radiusList = new List<int>();

	// Token: 0x040111FF RID: 70143
	protected List<int> addXForceList = new List<int>();

	// Token: 0x04011200 RID: 70144
	protected List<int> addFloatXForceList = new List<int>();

	// Token: 0x04011201 RID: 70145
	protected List<int> targetList = new List<int>();

	// Token: 0x04011202 RID: 70146
	protected List<BeEventHandle> handleList = new List<BeEventHandle>();
}
