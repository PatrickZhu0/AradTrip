using System;
using System.Collections.Generic;

// Token: 0x020042ED RID: 17133
public class Mechanism1184 : BeMechanism
{
	// Token: 0x06017B4A RID: 97098 RVA: 0x0074E5BC File Offset: 0x0074C9BC
	public Mechanism1184(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B4B RID: 97099 RVA: 0x0074E618 File Offset: 0x0074CA18
	public override void OnInit()
	{
		this.mAddAttriRate = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this.mChangeAttriList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
		for (int j = 0; j < this.data.ValueC.Count; j++)
		{
			this.mGetAttriPercentList.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[j], this.level, true));
		}
		for (int k = 0; k < this.data.ValueD.Count; k++)
		{
			this.mSelfLimitPercentList.Add(TableManager.GetValueFromUnionCell(this.data.ValueD[k], this.level, true));
		}
		this.mAddAttriUpdateTime = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		this.mCdBuffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
		this.mCdBuffInfoTime = TableManager.GetValueFromUnionCell(this.data.ValueF[1], this.level, true);
		this.mAddAttriUpdateTimeAcc = this.mAddAttriUpdateTime;
	}

	// Token: 0x06017B4C RID: 97100 RVA: 0x0074E7BB File Offset: 0x0074CBBB
	public override void OnStart()
	{
		this.CheckData();
		this._RegistEvent();
	}

	// Token: 0x06017B4D RID: 97101 RVA: 0x0074E7C9 File Offset: 0x0074CBC9
	public override void OnUpdate(int deltaTime)
	{
		if (this.mAddAttriUpdateTimeAcc < this.mAddAttriUpdateTime && this.mAddAttriUpdateTimeAcc + deltaTime >= this.mAddAttriUpdateTime)
		{
			this.RestoreAllChangeAttri();
		}
		this.mAddAttriUpdateTimeAcc += deltaTime;
	}

	// Token: 0x06017B4E RID: 97102 RVA: 0x0074E803 File Offset: 0x0074CC03
	public override void OnFinish()
	{
		this.mAddAttriUpdateTimeAcc = 0;
		this.RestoreAllChangeAttri();
	}

	// Token: 0x06017B4F RID: 97103 RVA: 0x0074E812 File Offset: 0x0074CC12
	private void CheckData()
	{
		if (this.mChangeAttriList.Count != this.mGetAttriPercentList.Count || this.mChangeAttriList.Count != this.mSelfLimitPercentList.Count)
		{
			base.Finish();
		}
	}

	// Token: 0x06017B50 RID: 97104 RVA: 0x0074E850 File Offset: 0x0074CC50
	private void _RegistEvent()
	{
		if (base.owner != null)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onBeforeHit, new BeEventHandle.Del(this.OnHitOtherEvent));
		}
	}

	// Token: 0x06017B51 RID: 97105 RVA: 0x0074E87C File Offset: 0x0074CC7C
	private void OnHitOtherEvent(object[] args)
	{
		if (this.mAddAttriRate <= (int)base.FrameRandom.Range1000())
		{
			return;
		}
		BeEntity beEntity = args[0] as BeEntity;
		if (beEntity == null || beEntity.attribute == null)
		{
			return;
		}
		if (base.owner == null || base.owner.attribute == null || base.owner.buffController == null)
		{
			return;
		}
		if (this.mAddAttriUpdateTimeAcc < this.mAddAttriUpdateTime || base.owner.buffController.HasBuffByID(this.mCdBuffInfoID) != null)
		{
			return;
		}
		this.mAddAttriUpdateTimeAcc = 0;
		base.owner.buffController.TryAddBuff(this.mCdBuffInfoID, this.mCdBuffInfoTime, 1);
		for (int i = 0; i < this.mChangeAttriList.Count; i++)
		{
			AttributeType at = this.attrTypes[this.mChangeAttriList[i]];
			int num = beEntity.attribute.GetAttributeValue(at) * this.mGetAttriPercentList[i] / GlobalLogic.VALUE_1000;
			int num2 = base.owner.attribute.GetAttributeValue(at) * this.mSelfLimitPercentList[i] / GlobalLogic.VALUE_1000;
			num = (int)IntMath.Clamp((long)num, (long)num, (long)num2);
			base.owner.attribute.SetAttributeValue(at, num, true);
			this.changeAttrData[this.mChangeAttriList[i]] += num;
		}
	}

	// Token: 0x06017B52 RID: 97106 RVA: 0x0074E9EC File Offset: 0x0074CDEC
	private void RestoreAllChangeAttri()
	{
		for (int i = 0; i < this.changeAttrData.Length; i++)
		{
			AttributeType at = this.attrTypes[i];
			base.owner.attribute.SetAttributeValue(at, -this.changeAttrData[i], true);
			this.changeAttrData[i] = 0;
		}
	}

	// Token: 0x04011085 RID: 69765
	protected int mAddAttriRate;

	// Token: 0x04011086 RID: 69766
	protected List<int> mChangeAttriList = new List<int>();

	// Token: 0x04011087 RID: 69767
	protected List<int> mGetAttriPercentList = new List<int>();

	// Token: 0x04011088 RID: 69768
	protected List<int> mSelfLimitPercentList = new List<int>();

	// Token: 0x04011089 RID: 69769
	protected int mAddAttriUpdateTime;

	// Token: 0x0401108A RID: 69770
	protected int mAddAttriUpdateTimeAcc;

	// Token: 0x0401108B RID: 69771
	protected int mCdBuffInfoID;

	// Token: 0x0401108C RID: 69772
	protected int mCdBuffInfoTime;

	// Token: 0x0401108D RID: 69773
	private AttributeType[] attrTypes = new AttributeType[]
	{
		AttributeType.baseAtk,
		AttributeType.baseInt,
		AttributeType.baseSta,
		AttributeType.baseSpr
	};

	// Token: 0x0401108E RID: 69774
	private int[] changeAttrData = new int[4];
}
