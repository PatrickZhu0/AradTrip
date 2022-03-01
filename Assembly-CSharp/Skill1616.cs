using System;
using System.Collections.Generic;
using GamePool;
using ProtoTable;

// Token: 0x02004462 RID: 17506
public class Skill1616 : BeSkill
{
	// Token: 0x0601852A RID: 99626 RVA: 0x007933BC File Offset: 0x007917BC
	public Skill1616(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601852B RID: 99627 RVA: 0x00793414 File Offset: 0x00791814
	public override void OnInit()
	{
		this.buffID = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.rangeRadius = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		BuffTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(this.buffID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			this.overlayMax = tableItem.OverlayLimit;
		}
		this.buffLevelAdd = TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true);
		this.bleedBuffID = TableManager.GetValueFromUnionCell(this.skillData.ValueE[0], base.level, true);
	}

	// Token: 0x0601852C RID: 99628 RVA: 0x007934DC File Offset: 0x007918DC
	public override void OnPostInit()
	{
		this.skillState.SetRunning();
		for (int i = 0; i < this.skillData.ValueC.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.skillData.ValueC[i], base.level, true);
			BeSkill skill = base.owner.GetSkill(valueFromUnionCell);
			if (skill != null)
			{
				BuffInfoData buffInfoData = new BuffInfoData();
				buffInfoData.buffID = this.bleedBuffID;
				buffInfoData.level = this.buffLevelAdd;
				skill.buffEnhanceList.Add(this.buffID, buffInfoData);
			}
		}
	}

	// Token: 0x0601852D RID: 99629 RVA: 0x00793580 File Offset: 0x00791980
	private bool CheckCanRemove(BeActor item)
	{
		if (item.IsDead() || item.GetDistance(base.owner) > VInt.NewVInt(this.rangeRadius, GlobalLogic.VALUE_1000).i || item.buffController.HasBuffByType(BuffType.BLEEDING) == null)
		{
			base.owner.buffController.RemoveBuff(base.owner.buffController.HasBuffByID(this.buffID));
			return true;
		}
		return false;
	}

	// Token: 0x0601852E RID: 99630 RVA: 0x007935FC File Offset: 0x007919FC
	public override void OnUpdate(int iDeltime)
	{
		this.timeAcc += iDeltime;
		if (this.timeAcc >= this.CHECK_INTERVAL)
		{
			this.timeAcc -= this.CHECK_INTERVAL;
			this.inRangers.RemoveAll(new Predicate<BeActor>(this.CheckCanRemove));
			List<BeActor> list = ListPool<BeActor>.Get();
			List<BeActor> list2 = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.FindTargets(list2, base.owner, VInt.NewVInt(this.rangeRadius, GlobalLogic.VALUE_1000), false, null);
			for (int i = 0; i < list2.Count; i++)
			{
				if (!list2[i].IsDead() && list2[i].buffController.HasBuffByType(BuffType.BLEEDING) != null)
				{
					list.Add(list2[i]);
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				if (!this.inRangers.Contains(list[j]) && this.inRangers.Count < this.overlayMax)
				{
					this.inRangers.Add(list[j]);
					base.owner.buffController.TryAddBuff(this.buffID, -1, base.level);
				}
			}
			ListPool<BeActor>.Release(list2);
			ListPool<BeActor>.Release(list);
		}
	}

	// Token: 0x040118D5 RID: 71893
	private int rangeRadius = 4000;

	// Token: 0x040118D6 RID: 71894
	private int buffID = 161601;

	// Token: 0x040118D7 RID: 71895
	private int overlayMax = 5;

	// Token: 0x040118D8 RID: 71896
	private int buffLevelAdd = 2;

	// Token: 0x040118D9 RID: 71897
	private int bleedBuffID = 5;

	// Token: 0x040118DA RID: 71898
	private int timeAcc;

	// Token: 0x040118DB RID: 71899
	private int CHECK_INTERVAL = GlobalLogic.VALUE_1000;

	// Token: 0x040118DC RID: 71900
	private List<BeActor> inRangers = new List<BeActor>();
}
