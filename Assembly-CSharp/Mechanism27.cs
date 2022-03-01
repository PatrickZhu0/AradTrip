using System;
using System.Collections.Generic;
using ProtoTable;

// Token: 0x020043D7 RID: 17367
public class Mechanism27 : BeMechanism
{
	// Token: 0x06018186 RID: 98694 RVA: 0x0077CC5E File Offset: 0x0077B05E
	public Mechanism27(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018187 RID: 98695 RVA: 0x0077CC74 File Offset: 0x0077B074
	public override void OnInit()
	{
		int count = this.data.ValueB.Count;
		for (int i = 0; i < count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueB[i], 1, true);
			if (valueFromUnionCell > 0)
			{
				this.buffInfoIds.Add(valueFromUnionCell);
			}
		}
		this.needRebindAttach = (TableManager.GetValueFromUnionCell(this.data.ValueC[0], 1, true) != 0);
	}

	// Token: 0x06018188 RID: 98696 RVA: 0x0077CCFC File Offset: 0x0077B0FC
	public static int GetMonsterId(int masterIdOfOwner, MechanismTable data)
	{
		if (data == null)
		{
			return 0;
		}
		int num = 0;
		if (masterIdOfOwner > 0)
		{
			num = masterIdOfOwner % 10 - 1;
		}
		int count = data.ValueA.Count;
		if (num < 0 || num > count - 1)
		{
			return 0;
		}
		return TableManager.GetValueFromUnionCell(data.ValueA[num], 1, true);
	}

	// Token: 0x06018189 RID: 98697 RVA: 0x0077CD54 File Offset: 0x0077B154
	public override void OnStart()
	{
		if (base.owner == null)
		{
			return;
		}
		BeEntityData entityData = base.owner.GetEntityData();
		if (entityData == null)
		{
			return;
		}
		if (base.owner.IsDead())
		{
			return;
		}
		this.selectedMonsterId = Mechanism27.GetMonsterId(entityData.monsterID, this.data);
		UnitTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UnitTable>(this.selectedMonsterId, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return;
		}
		entityData.overHeadHeight = (float)tableItem.overHeadHeight / (float)GlobalLogic.VALUE_1000;
		entityData.buffOriginHeight = (float)tableItem.buffOriginHeight / (float)GlobalLogic.VALUE_1000;
		entityData.hitID = tableItem.HitSkillID;
		entityData.hitIDRand = tableItem.HitSkillRand;
		base.owner.ChangeModel(tableItem, false, this.needRebindAttach);
		BeBuffManager buffController = base.owner.buffController;
		if (buffController == null)
		{
			return;
		}
		int count = this.buffInfoIds.Count;
		for (int i = 0; i < count; i++)
		{
			int buffInfoID = this.buffInfoIds[i];
			buffController.TryAddBuff(buffInfoID, null, false, null, 0);
		}
	}

	// Token: 0x0601818A RID: 98698 RVA: 0x0077CE70 File Offset: 0x0077B270
	public override void OnFinish()
	{
		if (base.owner == null)
		{
			return;
		}
		if (base.owner.IsDead())
		{
			return;
		}
		base.owner.TriggerEvent(BeEventType.onChangeModelFinish, null);
		UnitTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UnitTable>(this.selectedMonsterId, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return;
		}
		base.owner.ChangeSkill(tableItem);
	}

	// Token: 0x040115E6 RID: 71142
	private List<int> buffInfoIds = new List<int>();

	// Token: 0x040115E7 RID: 71143
	private int selectedMonsterId;

	// Token: 0x040115E8 RID: 71144
	private bool needRebindAttach;
}
