using System;
using System.Collections.Generic;
using GamePool;
using ProtoTable;

// Token: 0x02004486 RID: 17542
public class Skill2104 : BeSkill
{
	// Token: 0x06018622 RID: 99874 RVA: 0x00798EFA File Offset: 0x007972FA
	public Skill2104(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018623 RID: 99875 RVA: 0x00798F04 File Offset: 0x00797304
	public override void OnInit()
	{
		this.eid_owner = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.eid_summonMonster = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		this.eid_summonBattleBuff = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
	}

	// Token: 0x06018624 RID: 99876 RVA: 0x00798F7A File Offset: 0x0079737A
	public override void OnStart()
	{
		if (this.IsAlreadyCasted())
		{
			this.CancelSkill();
		}
		else
		{
			this.DoWork();
		}
	}

	// Token: 0x06018625 RID: 99877 RVA: 0x00798F98 File Offset: 0x00797398
	private void DoWork()
	{
		if (this.eid_owner > 0)
		{
			EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(this.eid_owner, string.Empty, string.Empty);
			if (tableItem != null)
			{
				base.owner.TryAddBuff(tableItem, null, 0, true, false, false);
				BeBuff beBuff = base.owner.buffController.HasBuffByID(tableItem.BuffID);
				if (beBuff != null)
				{
					beBuff.RegisterEvent(BeEventType.onBuffFinish, delegate(object[] args)
					{
						this.CancelSkill();
					});
				}
			}
		}
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.GetSummonBySummoner(list, base.owner, false, false);
		if (this.eid_summonMonster > 0 && list.Count > 0)
		{
			EffectTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(this.eid_summonMonster, string.Empty, string.Empty);
			for (int i = 0; i < list.Count; i++)
			{
				this.AddBuff(list[i], tableItem2);
			}
		}
		ListPool<BeActor>.Release(list);
		this.handler = base.owner.RegisterEvent(BeEventType.onHit, delegate(object[] args)
		{
			List<BeActor> list2 = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.GetSummonBySummoner(list2, base.owner, false, false);
			if (this.eid_summonBattleBuff > 0 && list2.Count > 0)
			{
				EffectTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(this.eid_summonBattleBuff, string.Empty, string.Empty);
				for (int j = 0; j < list2.Count; j++)
				{
					int valueFromUnionCell;
					if (BattleMain.IsChijiNeedReplaceHurtId(this.eid_summonBattleBuff, base.battleType))
					{
						ChijiEffectMapTable tableItem4 = Singleton<TableManager>.instance.GetTableItem<ChijiEffectMapTable>(this.eid_summonBattleBuff, string.Empty, string.Empty);
						valueFromUnionCell = TableManager.GetValueFromUnionCell(tableItem4.AttachBuffTime, base.level, true);
					}
					else
					{
						valueFromUnionCell = TableManager.GetValueFromUnionCell(tableItem3.AttachBuffTime, base.level, true);
					}
					list2[j].buffController.TryAddBuff(tableItem3.BuffID, valueFromUnionCell, base.level);
				}
			}
			ListPool<BeActor>.Release(list2);
		});
		this.handler2 = base.owner.RegisterEvent(BeEventType.onSummon, delegate(object[] args)
		{
			BeActor beActor = args[0] as BeActor;
			EffectTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(this.eid_summonMonster, string.Empty, string.Empty);
			if (beActor != null && tableItem3 != null)
			{
				this.AddBuff(beActor, tableItem3);
			}
		});
		this.handler3 = base.owner.RegisterEvent(BeEventType.onDead, delegate(object[] args)
		{
			this.CancelSkill();
		});
	}

	// Token: 0x06018626 RID: 99878 RVA: 0x007990FC File Offset: 0x007974FC
	public void AddBuff(BeActor summon, EffectTable data)
	{
		int valueFromUnionCell;
		if (BattleMain.IsChijiNeedReplaceHurtId(data.ID, base.battleType))
		{
			ChijiEffectMapTable tableItem = Singleton<TableManager>.instance.GetTableItem<ChijiEffectMapTable>(data.ID, string.Empty, string.Empty);
			valueFromUnionCell = TableManager.GetValueFromUnionCell(tableItem.AttachBuffTime, base.level, true);
		}
		else
		{
			valueFromUnionCell = TableManager.GetValueFromUnionCell(data.AttachBuffTime, base.level, true);
		}
		summon.buffController.TryAddBuff(data.BuffID, valueFromUnionCell, base.level);
		BeBuff beBuff = summon.buffController.HasBuffByID(data.BuffID);
		if (beBuff != null)
		{
			summon.aiManager.SetForceFollow(true);
			summon.RegisterEvent(BeEventType.onBuffFinish, delegate(object[] args)
			{
				int num = (int)args[0];
				if (num == data.BuffID)
				{
					summon.aiManager.SetForceFollow(false);
				}
			});
			summon.RegisterEvent(BeEventType.onRemoveBuff, delegate(object[] args)
			{
				int num = (int)args[0];
				if (num == data.BuffID)
				{
					summon.aiManager.SetForceFollow(false);
				}
			});
		}
	}

	// Token: 0x06018627 RID: 99879 RVA: 0x00799218 File Offset: 0x00797618
	private bool IsAlreadyCasted()
	{
		EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(this.eid_owner, string.Empty, string.Empty);
		return tableItem != null && base.owner.buffController.HasBuffByID(tableItem.BuffID) != null;
	}

	// Token: 0x06018628 RID: 99880 RVA: 0x00799264 File Offset: 0x00797664
	private void CancelSkill()
	{
		EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(this.eid_owner, string.Empty, string.Empty);
		if (tableItem != null)
		{
			base.owner.buffController.RemoveBuff(tableItem.BuffID, 0, 0);
		}
		tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(this.eid_summonMonster, string.Empty, string.Empty);
		if (tableItem != null)
		{
			EffectTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(this.eid_summonMonster, string.Empty, string.Empty);
			List<BeActor> list = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.GetSummonBySummoner(list, base.owner, false, false);
			for (int i = 0; i < list.Count; i++)
			{
				list[i].buffController.RemoveBuff(tableItem2.BuffID, 0, 0);
			}
			ListPool<BeActor>.Release(list);
		}
		this.RemoveHandler();
	}

	// Token: 0x06018629 RID: 99881 RVA: 0x00799344 File Offset: 0x00797744
	private void RemoveHandler()
	{
		if (this.handler != null)
		{
			this.handler.Remove();
			this.handler = null;
		}
		if (this.handler2 != null)
		{
			this.handler2.Remove();
			this.handler2 = null;
		}
		if (this.handler3 != null)
		{
			this.handler3.Remove();
			this.handler3 = null;
		}
	}

	// Token: 0x0401198E RID: 72078
	private int eid_owner;

	// Token: 0x0401198F RID: 72079
	private int eid_summonMonster;

	// Token: 0x04011990 RID: 72080
	private int eid_summonBattleBuff;

	// Token: 0x04011991 RID: 72081
	private BeEventHandle handler;

	// Token: 0x04011992 RID: 72082
	private BeEventHandle handler2;

	// Token: 0x04011993 RID: 72083
	private BeEventHandle handler3;
}
