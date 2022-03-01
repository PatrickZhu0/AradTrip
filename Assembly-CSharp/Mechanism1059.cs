using System;

// Token: 0x02004283 RID: 17027
public class Mechanism1059 : BeMechanism
{
	// Token: 0x060178F4 RID: 96500 RVA: 0x00740632 File Offset: 0x0073EA32
	public Mechanism1059(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060178F5 RID: 96501 RVA: 0x0074066C File Offset: 0x0073EA6C
	public override void OnInit()
	{
		base.OnInit();
		this.attrTypeIndex = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.attrValThreshold = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true), GlobalLogic.VALUE_10);
		this.attrValAddVal = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true), GlobalLogic.VALUE_10);
		this.buffId = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x060178F6 RID: 96502 RVA: 0x00740734 File Offset: 0x0073EB34
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner == null || base.owner.buffController == null || base.owner.GetEntityData() == null || base.owner.GetEntityData().battleData == null)
		{
			return;
		}
		this.CheckAndDoBuff();
		this.handleA = base.owner.RegisterEvent(BeEventType.onAttrChange, new BeEventHandle.Del(this.onAttributeChange));
	}

	// Token: 0x060178F7 RID: 96503 RVA: 0x007407AD File Offset: 0x0073EBAD
	public override void OnFinish()
	{
		base.OnFinish();
		this.RemoveBuff();
	}

	// Token: 0x060178F8 RID: 96504 RVA: 0x007407BC File Offset: 0x0073EBBC
	private void onAttributeChange(object[] args)
	{
		AttributeType attributeType = (AttributeType)args[0];
		int i = 0;
		while (i < this.attrTypes.Length)
		{
			if (this.attrTypes[i] == attributeType)
			{
				if (i == this.attrTypeIndex)
				{
					break;
				}
				return;
			}
			else
			{
				i++;
			}
		}
		this.CheckAndDoBuff();
	}

	// Token: 0x060178F9 RID: 96505 RVA: 0x00740814 File Offset: 0x0073EC14
	private void CheckAndDoBuff()
	{
		if (this.attrTypeIndex < 0 || this.attrTypeIndex >= this.attrTypes.Length || this.attrValAddVal <= 0)
		{
			return;
		}
		int attributeValue = base.owner.GetEntityData().GetAttributeValue(this.attrTypes[this.attrTypeIndex]);
		if (attributeValue > this.attrValThreshold)
		{
			int num = attributeValue - this.attrValThreshold.i;
			int num2 = num / this.attrValAddVal.i;
			int buffCountByID = base.owner.buffController.GetBuffCountByID(this.buffId);
			int num3 = Math.Abs(num2 - buffCountByID);
			if (num2 > buffCountByID)
			{
				for (int i = 0; i < num3; i++)
				{
					base.owner.buffController.TryAddBuff(this.buffId, -1, 1);
				}
			}
			else if (num3 > 0)
			{
				base.owner.buffController.RemoveBuff(this.buffId, num3, 0);
			}
		}
		else
		{
			base.owner.buffController.RemoveBuff(this.buffId, 0, 0);
		}
	}

	// Token: 0x060178FA RID: 96506 RVA: 0x0074093D File Offset: 0x0073ED3D
	private void RemoveBuff()
	{
		base.owner.buffController.RemoveBuff(this.buffId, 0, 0);
	}

	// Token: 0x04010EDD RID: 69341
	private int attrTypeIndex;

	// Token: 0x04010EDE RID: 69342
	private VInt attrValThreshold = VInt.zero;

	// Token: 0x04010EDF RID: 69343
	private VInt attrValAddVal = VInt.zero;

	// Token: 0x04010EE0 RID: 69344
	private int buffId;

	// Token: 0x04010EE1 RID: 69345
	private readonly AttributeType[] attrTypes = new AttributeType[]
	{
		AttributeType.baseAtk,
		AttributeType.baseInt,
		AttributeType.baseSta,
		AttributeType.baseSpr
	};
}
