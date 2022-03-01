using System;
using System.Collections.Generic;
using ProtoTable;

// Token: 0x0200445E RID: 17502
public class Skill1612 : BeSkill
{
	// Token: 0x06018519 RID: 99609 RVA: 0x00792C50 File Offset: 0x00791050
	public Skill1612(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601851A RID: 99610 RVA: 0x00792C68 File Offset: 0x00791068
	public override void OnInit()
	{
		base.OnInit();
		this.buffInfos.Clear();
		this.buffEffectID = ((!BattleMain.IsModePvP(base.battleType)) ? TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true) : TableManager.GetValueFromUnionCell(this.skillData.ValueA[1], base.level, true));
		for (int i = 0; i < 3; i++)
		{
			UnionCell ucell = null;
			IList<UnionCell> value = null;
			if (i == 0)
			{
				ucell = this.skillData.ValueB[0];
				value = this.skillData.ValueC;
			}
			else if (i == 1)
			{
				ucell = this.skillData.ValueD[0];
				value = this.skillData.ValueE;
			}
			else if (i == 2)
			{
				ucell = this.skillData.ValueF[0];
				value = this.skillData.ValueG;
			}
			Skill1612._tmpBuffInfo item = default(Skill1612._tmpBuffInfo);
			item.skillIDs = BeSkill.GetEffectSkills(value, base.level);
			item.buffID = TableManager.GetValueFromUnionCell(ucell, base.level, true);
			this.buffInfos.Add(item);
		}
	}

	// Token: 0x0601851B RID: 99611 RVA: 0x00792DA4 File Offset: 0x007911A4
	public override void OnStart()
	{
		base.OnStart();
		this.DoEffect();
	}

	// Token: 0x0601851C RID: 99612 RVA: 0x00792DB4 File Offset: 0x007911B4
	public void DoEffect()
	{
		if (base.owner != null)
		{
			EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(this.buffEffectID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				int valueFromUnionCell;
				if (BattleMain.IsChijiNeedReplaceHurtId(this.buffEffectID, base.battleType))
				{
					ChijiEffectMapTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ChijiEffectMapTable>(this.buffEffectID, string.Empty, string.Empty);
					valueFromUnionCell = TableManager.GetValueFromUnionCell(tableItem2.AttachBuffTime, base.level, true);
				}
				else
				{
					valueFromUnionCell = TableManager.GetValueFromUnionCell(tableItem.AttachBuffTime, base.level, true);
				}
				base.owner.buffController.TryAddBuff(tableItem.BuffID, valueFromUnionCell, base.level);
				for (int i = 0; i < this.buffInfos.Count; i++)
				{
					Skill1612._tmpBuffInfo tmpBuffInfo = this.buffInfos[i];
					base.owner.buffController.AddBuffForSkill(tmpBuffInfo.buffID, base.level, valueFromUnionCell, tmpBuffInfo.skillIDs);
				}
			}
		}
	}

	// Token: 0x040118C3 RID: 71875
	private int buffEffectID;

	// Token: 0x040118C4 RID: 71876
	private List<Skill1612._tmpBuffInfo> buffInfos = new List<Skill1612._tmpBuffInfo>();

	// Token: 0x0200445F RID: 17503
	private struct _tmpBuffInfo
	{
		// Token: 0x040118C5 RID: 71877
		public List<int> skillIDs;

		// Token: 0x040118C6 RID: 71878
		public int buffID;
	}
}
