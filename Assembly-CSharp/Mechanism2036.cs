using System;

// Token: 0x0200435B RID: 17243
public class Mechanism2036 : BeMechanism
{
	// Token: 0x06017E02 RID: 97794 RVA: 0x00761D28 File Offset: 0x00760128
	public Mechanism2036(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017E03 RID: 97795 RVA: 0x00761D54 File Offset: 0x00760154
	public override void OnInit()
	{
		base.OnInit();
		this.buffIDCondition = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.srcAttrID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.factor = VFactor.NewVFactor(valueFromUnionCell, GlobalLogic.VALUE_1000);
		this.desAttrID = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.needRemove = (TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true) != 0);
	}

	// Token: 0x06017E04 RID: 97796 RVA: 0x00761E47 File Offset: 0x00760247
	public override void OnFinish()
	{
		base.OnFinish();
		if (!this.needRemove)
		{
			return;
		}
		this._RemoveEffect();
	}

	// Token: 0x06017E05 RID: 97797 RVA: 0x00761E64 File Offset: 0x00760264
	private void _RemoveEffect()
	{
		if (this.desAttrID < 0 || this.desAttrID >= this.attrTypes.Length)
		{
			Logger.LogErrorFormat("onRemoveBuff mechanism id {0} desAttrID  is out of Range {1}", new object[]
			{
				this.mechianismID,
				this.srcAttrID
			});
			return;
		}
		AttributeType at = this.attrTypes[this.srcAttrID];
		int attributeValue = base.owner.attribute.GetAttributeValue(at);
		AttributeType at2 = this.attrTypes[this.desAttrID];
		int attributeValue2 = base.owner.attribute.GetAttributeValue(at2);
		base.owner.attribute.SetAttributeValue(at2, (attributeValue2 >= this.totalAddValue) ? (attributeValue2 - this.totalAddValue) : 0, false);
		this.totalAddValue = 0;
	}

	// Token: 0x06017E06 RID: 97798 RVA: 0x00761F30 File Offset: 0x00760330
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
		{
			BeBuff beBuff = args[0] as BeBuff;
			if (beBuff == null || beBuff.buffID != this.buffIDCondition)
			{
				return;
			}
			if (base.owner == null || base.owner.buffController == null)
			{
				return;
			}
			if (base.owner.buffController.GetBuffCountByID(beBuff.buffID) > 1)
			{
				return;
			}
			if (this.srcAttrID < 0 || this.srcAttrID >= this.attrTypes.Length)
			{
				Logger.LogErrorFormat("mechanism id {0} srcAttrID  is out of Range {1}", new object[]
				{
					this.mechianismID,
					this.srcAttrID
				});
				return;
			}
			AttributeType attributeType = this.attrTypes[this.srcAttrID];
			int i = base.owner.attribute.GetAttributeValue(attributeType);
			if (attributeType == AttributeType.maxHp)
			{
				i = base.owner.attribute.GetMaxHP() * GlobalLogic.VALUE_1000;
			}
			else if (attributeType == AttributeType.maxMp)
			{
				i = base.owner.attribute.GetMaxMP() * GlobalLogic.VALUE_1000;
			}
			if (this.desAttrID < 0 || this.desAttrID >= this.attrTypes.Length)
			{
				Logger.LogErrorFormat("mechanism id {0} desAttrID  is out of Range {1}", new object[]
				{
					this.mechianismID,
					this.srcAttrID
				});
				return;
			}
			AttributeType at = this.attrTypes[this.desAttrID];
			int attributeValue = base.owner.attribute.GetAttributeValue(at);
			int num = i * this.factor;
			this.totalAddValue += num;
			base.owner.attribute.SetAttributeValue(at, attributeValue + num, false);
		});
		this.handleB = base.owner.RegisterEvent(BeEventType.onRemoveBuff, delegate(object[] args)
		{
			int num = (int)args[0];
			if (base.owner == null || base.owner.buffController == null)
			{
				return;
			}
			if (num != this.buffIDCondition)
			{
				return;
			}
			if (base.owner.buffController.GetBuffCountByID(num) > 1)
			{
				return;
			}
			this._RemoveEffect();
		});
	}

	// Token: 0x040112EA RID: 70378
	private int buffIDCondition;

	// Token: 0x040112EB RID: 70379
	private int srcAttrID;

	// Token: 0x040112EC RID: 70380
	private VFactor factor = VFactor.zero;

	// Token: 0x040112ED RID: 70381
	private int desAttrID;

	// Token: 0x040112EE RID: 70382
	private int totalAddValue;

	// Token: 0x040112EF RID: 70383
	private int addCount;

	// Token: 0x040112F0 RID: 70384
	private bool needRemove;

	// Token: 0x040112F1 RID: 70385
	private AttributeType[] attrTypes = new AttributeType[]
	{
		AttributeType.baseAtk,
		AttributeType.baseInt,
		AttributeType.baseSta,
		AttributeType.baseSpr,
		AttributeType.maxHp,
		AttributeType.maxMp
	};
}
