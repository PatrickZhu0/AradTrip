using System;
using System.Collections.Generic;

// Token: 0x0200428D RID: 17037
public class Mechanism1068 : BeMechanism
{
	// Token: 0x06017927 RID: 96551 RVA: 0x007417CB File Offset: 0x0073FBCB
	public Mechanism1068(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017928 RID: 96552 RVA: 0x007417E8 File Offset: 0x0073FBE8
	private Mechanism1068.targetUnit GetOneTargetUnit()
	{
		if (this.mTargetList == null)
		{
			this.mTargetList = new List<Mechanism1068.targetUnit>();
		}
		for (int i = 0; i < this.mTargetList.Count; i++)
		{
			if (this.mTargetList[i] != null && this.mTargetList[i].mDirty)
			{
				return this.mTargetList[i];
			}
		}
		Mechanism1068.targetUnit targetUnit = new Mechanism1068.targetUnit();
		this.mTargetList.Add(targetUnit);
		return targetUnit;
	}

	// Token: 0x06017929 RID: 96553 RVA: 0x00741870 File Offset: 0x0073FC70
	private void UpdateTargetList(int deltaTime)
	{
		if (this.mTargetList == null)
		{
			return;
		}
		int num = 0;
		for (int i = 0; i < this.mTargetList.Count; i++)
		{
			if (this.mTargetList[i] != null && !this.mTargetList[i].mDirty)
			{
				num++;
				if (this.mTargetList[i].tagCD > 0)
				{
					this.mTargetList[i].tagCD -= deltaTime;
					if (this.mTargetList[i].tagCD < 0)
					{
						this.mTargetList[i].Reset();
					}
				}
				if (this.mTargetList[i].tagDuration > 0)
				{
					this.mTargetList[i].tagDuration -= deltaTime;
					if (this.mTargetList[i].tagDuration < 0)
					{
						this.mTargetList[i].Reset();
					}
				}
			}
		}
		if (this.mTargetList.Count - num > this.reduceMul)
		{
			List<Mechanism1068.targetUnit> list = new List<Mechanism1068.targetUnit>(num);
			for (int j = 0; j < this.mTargetList.Count; j++)
			{
				if (this.mTargetList[j] != null && !this.mTargetList[j].mDirty)
				{
					list.Add(this.mTargetList[j]);
				}
			}
			this.mTargetList.Clear();
			this.mTargetList = list;
		}
	}

	// Token: 0x0601792A RID: 96554 RVA: 0x00741A08 File Offset: 0x0073FE08
	private Mechanism1068.targetUnit GetTargetByPid(int pid)
	{
		if (this.mTargetList == null)
		{
			return null;
		}
		for (int i = 0; i < this.mTargetList.Count; i++)
		{
			if (this.mTargetList[i] != null && !this.mTargetList[i].mDirty && this.mTargetList[i].pid == pid)
			{
				return this.mTargetList[i];
			}
		}
		return null;
	}

	// Token: 0x0601792B RID: 96555 RVA: 0x00741A8C File Offset: 0x0073FE8C
	public override void OnInit()
	{
		this.mTagCount = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.mUnTagCount = TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true);
		this.mHurtId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.mTagBuffDuration = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.mCDBuffIdDuration = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		if (valueFromUnionCell == 0)
		{
			this.reduceMul = 20;
		}
		else
		{
			this.reduceMul = valueFromUnionCell;
		}
	}

	// Token: 0x0601792C RID: 96556 RVA: 0x00741B9E File Offset: 0x0073FF9E
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onAfterFinalDamageNew, delegate(object[] args1)
		{
			BeActor beActor = args1[1] as BeActor;
			int num = (int)args1[2];
			if (beActor == null || num == this.mHurtId)
			{
				return;
			}
			Mechanism1068.targetUnit targetUnit = this.GetTargetByPid(beActor.GetPID());
			if (targetUnit != null)
			{
				if (targetUnit.tagCD <= 0)
				{
					targetUnit.tagCount++;
					if (targetUnit.tagCount >= this.mUnTagCount)
					{
						targetUnit.tagCount = 0;
						targetUnit.tagDuration = 0;
						targetUnit.tagCD = this.mCDBuffIdDuration;
						base.owner.DoAttackTo(beActor, this.mHurtId, false, true);
					}
					else
					{
						targetUnit.tagDuration = this.mTagBuffDuration;
					}
				}
			}
			else
			{
				targetUnit = this.GetOneTargetUnit();
				targetUnit.pid = beActor.GetPID();
				targetUnit.tagCount = 1;
				targetUnit.tagDuration = this.mTagBuffDuration;
				targetUnit.deadEventHandle = beActor.RegisterEvent(BeEventType.onDead, delegate(object[] args2)
				{
					if (args2 == null || args2.Length < 3)
					{
						return;
					}
					BeActor beActor2 = args2[2] as BeActor;
					if (beActor2 != null)
					{
						Mechanism1068.targetUnit targetByPid = this.GetTargetByPid(beActor2.GetPID());
						if (targetByPid != null)
						{
							targetByPid.Reset();
						}
					}
				});
				targetUnit.mDirty = false;
			}
		});
	}

	// Token: 0x0601792D RID: 96557 RVA: 0x00741BBF File Offset: 0x0073FFBF
	public override void OnUpdate(int deltaTime)
	{
		this.UpdateTargetList(deltaTime);
	}

	// Token: 0x0601792E RID: 96558 RVA: 0x00741BC8 File Offset: 0x0073FFC8
	public override void OnFinish()
	{
		if (this.mTargetList != null)
		{
			for (int i = 0; i < this.mTargetList.Count; i++)
			{
				if (this.mTargetList[i] != null)
				{
					this.mTargetList[i].Reset();
				}
			}
			this.mTargetList.Clear();
		}
	}

	// Token: 0x04010EFC RID: 69372
	private int mTagCount;

	// Token: 0x04010EFD RID: 69373
	private int mUnTagCount = 100;

	// Token: 0x04010EFE RID: 69374
	private int mHurtId;

	// Token: 0x04010EFF RID: 69375
	private int mTagBuffDuration;

	// Token: 0x04010F00 RID: 69376
	private int mCDBuffIdDuration;

	// Token: 0x04010F01 RID: 69377
	private List<Mechanism1068.targetUnit> mTargetList = new List<Mechanism1068.targetUnit>();

	// Token: 0x04010F02 RID: 69378
	private int reduceMul;

	// Token: 0x0200428E RID: 17038
	private class targetUnit
	{
		// Token: 0x06017932 RID: 96562 RVA: 0x00741D78 File Offset: 0x00740178
		public void Reset()
		{
			this.pid = -1;
			this.tagCount = 0;
			this.tagDuration = 0;
			this.tagCD = 0;
			if (this.deadEventHandle != null)
			{
				this.deadEventHandle.Remove();
				this.deadEventHandle = null;
			}
			this.mDirty = true;
		}

		// Token: 0x04010F03 RID: 69379
		public int pid;

		// Token: 0x04010F04 RID: 69380
		public int tagCount;

		// Token: 0x04010F05 RID: 69381
		public int tagDuration;

		// Token: 0x04010F06 RID: 69382
		public int tagCD;

		// Token: 0x04010F07 RID: 69383
		public bool mDirty;

		// Token: 0x04010F08 RID: 69384
		public BeEventHandle deadEventHandle;
	}
}
