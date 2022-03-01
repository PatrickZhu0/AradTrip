using System;
using System.Collections.Generic;

// Token: 0x020041D8 RID: 16856
public class DelayCaller : ObjectLeakDitector
{
	// Token: 0x0601742D RID: 95277 RVA: 0x00727321 File Offset: 0x00725721
	private bool CanDelayCallRemove(DelayCallUnit unit)
	{
		return unit.CanRemove();
	}

	// Token: 0x0601742E RID: 95278 RVA: 0x0072732C File Offset: 0x0072572C
	public void Update(int deltaTime)
	{
		bool flag = false;
		for (int i = 0; i < this.trunkList.Count; i++)
		{
			DelayCallUnit delayCallUnit = this.trunkList[i];
			if (delayCallUnit != null)
			{
				delayCallUnit.Update(deltaTime);
				if (delayCallUnit.CanRemove())
				{
					flag = true;
				}
			}
		}
		if (flag)
		{
			this._RecycleUnusedUnit(this.trunkList);
		}
		this.trunkList.AddRange(this.pendingList);
		this.pendingList.Clear();
	}

	// Token: 0x0601742F RID: 95279 RVA: 0x007273B1 File Offset: 0x007257B1
	public void Cancel()
	{
		this._ClearAndRecycleList(this.trunkList);
	}

	// Token: 0x06017430 RID: 95280 RVA: 0x007273BF File Offset: 0x007257BF
	public void StopItem(DelayCallUnitHandle unit)
	{
		unit.SetRemove(true);
	}

	// Token: 0x06017431 RID: 95281 RVA: 0x007273CC File Offset: 0x007257CC
	public DelayCallUnitHandle DelayCall(int ms, DelayCaller.Del del, int repeatcount = 0, int repeattime = 0, bool needCallBeforeClear = false)
	{
		DelayCaller.sHandleId += 1U;
		DelayCallUnit pooledObject = this.m_DelayCallUnitPool.GetPooledObject();
		pooledObject.Init(ms, del, repeatcount, repeattime, needCallBeforeClear);
		pooledObject.id = DelayCaller.sHandleId;
		this.pendingList.Add(pooledObject);
		DelayCallUnitHandle result;
		result.unit = pooledObject;
		result.id = DelayCaller.sHandleId;
		return result;
	}

	// Token: 0x06017432 RID: 95282 RVA: 0x0072742C File Offset: 0x0072582C
	public DelayCallUnitHandle RepeatCall(int ms, DelayCaller.Del del, int repeatcount = 9999999, bool immediate = false)
	{
		if (immediate)
		{
			del();
		}
		DelayCaller.sHandleId += 1U;
		DelayCallUnit pooledObject = this.m_DelayCallUnitPool.GetPooledObject();
		pooledObject.Init(ms, del, repeatcount, ms, false);
		pooledObject.id = DelayCaller.sHandleId;
		this.pendingList.Add(pooledObject);
		DelayCallUnitHandle result;
		result.unit = pooledObject;
		result.id = DelayCaller.sHandleId;
		return result;
	}

	// Token: 0x06017433 RID: 95283 RVA: 0x00727498 File Offset: 0x00725898
	public void Clear()
	{
		for (int i = 0; i < this.trunkList.Count; i++)
		{
			DelayCallUnit delayCallUnit = this.trunkList[i];
			if (!delayCallUnit.CanRemove() && delayCallUnit.NeedCallBeforeClear())
			{
				delayCallUnit.DoCall();
				delayCallUnit.SetRemove(true);
			}
		}
		this._ClearAndRecycleList(this.trunkList);
		this._ClearAndRecycleList(this.pendingList);
	}

	// Token: 0x06017434 RID: 95284 RVA: 0x0072750C File Offset: 0x0072590C
	protected void _ClearAndRecycleList(List<DelayCallUnit> list)
	{
		int i = 0;
		int count = list.Count;
		while (i < count)
		{
			this.m_DelayCallUnitPool.RecyclePooledObject(list[i]);
			list[i].SetRemove(false);
			list[i].id = uint.MaxValue;
			i++;
		}
		list.Clear();
	}

	// Token: 0x06017435 RID: 95285 RVA: 0x00727564 File Offset: 0x00725964
	protected void _RecycleUnusedUnit(List<DelayCallUnit> list)
	{
		for (int i = list.Count - 1; i >= 0; i--)
		{
			DelayCallUnit delayCallUnit = list[i];
			if (this.CanDelayCallRemove(delayCallUnit))
			{
				this.m_DelayCallUnitPool.RecyclePooledObject(delayCallUnit);
				delayCallUnit.SetRemove(false);
				delayCallUnit.id = uint.MaxValue;
				list.RemoveAt(i);
			}
		}
	}

	// Token: 0x04010BCD RID: 68557
	private ClassObjListPool<DelayCallUnit> m_DelayCallUnitPool = new ClassObjListPool<DelayCallUnit>();

	// Token: 0x04010BCE RID: 68558
	private List<DelayCallUnit> trunkList = new List<DelayCallUnit>();

	// Token: 0x04010BCF RID: 68559
	private List<DelayCallUnit> pendingList = new List<DelayCallUnit>();

	// Token: 0x04010BD0 RID: 68560
	private static uint sHandleId;

	// Token: 0x020041D9 RID: 16857
	// (Invoke) Token: 0x06017438 RID: 95288
	public delegate void Del();
}
