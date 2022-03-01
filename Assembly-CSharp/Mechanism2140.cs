using System;
using GameClient;

// Token: 0x020043CA RID: 17354
public class Mechanism2140 : BeMechanism
{
	// Token: 0x06018132 RID: 98610 RVA: 0x0077A253 File Offset: 0x00778653
	public Mechanism2140(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018133 RID: 98611 RVA: 0x0077A260 File Offset: 0x00778660
	public override void OnInit()
	{
		this.mAddValue = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		if (this.data.ValueB.Count > 0)
		{
			this.mMonsterID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		}
	}

	// Token: 0x06018134 RID: 98612 RVA: 0x0077A2D3 File Offset: 0x007786D3
	public override void OnStart()
	{
		this.DoValueChange();
	}

	// Token: 0x06018135 RID: 98613 RVA: 0x0077A2DC File Offset: 0x007786DC
	protected void DoValueChange()
	{
		if (base.owner != null)
		{
			if (this.mMonsterID == 0)
			{
				base.owner.TriggerEventNew(BeEventType.onMechanism2139ValueChange, new EventParam
				{
					m_Int = this.mAddValue
				});
			}
			else if (base.owner.CurrentBeScene != null)
			{
				BeActor beActor = base.owner.CurrentBeScene.FindMonsterByID(this.mMonsterID);
				if (beActor != null)
				{
					beActor.TriggerEventNew(BeEventType.onMechanism2139ValueChange, new EventParam
					{
						m_Int = this.mAddValue
					});
				}
			}
		}
	}

	// Token: 0x0401158F RID: 71055
	protected int mAddValue;

	// Token: 0x04011590 RID: 71056
	protected int mMonsterID;
}
