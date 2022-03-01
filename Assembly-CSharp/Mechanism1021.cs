using System;
using ProtoTable;

// Token: 0x0200425D RID: 16989
public class Mechanism1021 : BeMechanism
{
	// Token: 0x0601781D RID: 96285 RVA: 0x0073B653 File Offset: 0x00739A53
	public Mechanism1021(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601781E RID: 96286 RVA: 0x0073B65D File Offset: 0x00739A5D
	public override void OnInit()
	{
		base.OnInit();
		this.resID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x0601781F RID: 96287 RVA: 0x0073B690 File Offset: 0x00739A90
	public override void OnStart()
	{
		this.curWeaponItemID = base.owner.GetWeaponID();
		base.OnStart();
		ResTable tableItem = Singleton<TableManager>.instance.GetTableItem<ResTable>(this.resID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return;
		}
		JobTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<JobTable>(base.owner.professionID, string.Empty, string.Empty);
		if (tableItem2 == null)
		{
			return;
		}
		if (base.owner.attachmentproxy != null)
		{
			base.owner.attachmentproxy.SetShowFashionWeapon(tableItem.ModelPath, tableItem2.DefaultWeaponPath);
			base.owner.attachmentproxy.Update(0f);
		}
	}

	// Token: 0x06017820 RID: 96288 RVA: 0x0073B73E File Offset: 0x00739B3E
	public override void OnFinish()
	{
		base.OnFinish();
		this.ResetWeaponModel();
	}

	// Token: 0x06017821 RID: 96289 RVA: 0x0073B74C File Offset: 0x00739B4C
	public override void OnDead()
	{
		base.OnDead();
		this.ResetWeaponModel();
	}

	// Token: 0x06017822 RID: 96290 RVA: 0x0073B75C File Offset: 0x00739B5C
	private void ResetWeaponModel()
	{
		JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(base.owner.professionID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return;
		}
		ItemTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ItemTable>(this.curWeaponItemID, string.Empty, string.Empty);
		if (base.owner.attachmentproxy != null)
		{
			if (base.owner.m_cpkCurEntityActionInfo != null)
			{
				string currentActionName = base.owner.m_cpkEntityInfo.GetCurrentActionName();
				if (base.owner.m_cpkEntityInfo.HasAction(currentActionName))
				{
					base.owner.m_cpkCurEntityActionInfo = base.owner.m_cpkEntityInfo._vkActionsMap[currentActionName];
					base.owner.attachmentproxy.Init(base.owner.m_cpkCurEntityActionInfo);
				}
			}
			if (tableItem2 == null)
			{
				base.owner.attachmentproxy.SetShowFashionWeapon(tableItem.DefaultWeaponPath, tableItem.DefaultWeaponPath);
				base.owner.attachmentproxy.Update(0f);
				return;
			}
			ResTable tableItem3 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem2.ResID, string.Empty, string.Empty);
			if (tableItem3 == null)
			{
				return;
			}
			base.owner.attachmentproxy.SetShowFashionWeapon(tableItem3.ModelPath, tableItem.DefaultWeaponPath);
			base.owner.attachmentproxy.Update(0f);
		}
	}

	// Token: 0x04010E50 RID: 69200
	private int resID;

	// Token: 0x04010E51 RID: 69201
	private int curWeaponItemID;
}
