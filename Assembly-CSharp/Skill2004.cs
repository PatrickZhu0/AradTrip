using System;
using ProtoTable;

// Token: 0x02004478 RID: 17528
public class Skill2004 : BeSkill
{
	// Token: 0x060185F9 RID: 99833 RVA: 0x0079840C File Offset: 0x0079680C
	public Skill2004(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060185FA RID: 99834 RVA: 0x00798418 File Offset: 0x00796818
	public override void OnInit()
	{
		this.friendBuffID = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.summonMonsterBuffID = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
	}

	// Token: 0x060185FB RID: 99835 RVA: 0x0079846B File Offset: 0x0079686B
	public override void OnStart()
	{
		this.RemoveHandler();
		this.handler = base.owner.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
		{
			BeActor beActor = args[0] as BeActor;
			int num = (int)args[1];
			EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(num, string.Empty, string.Empty);
			int buffDuration = 0;
			if (tableItem != null)
			{
				int skillLevel = base.owner.GetSkillLevel(tableItem.SkillID);
				if (BattleMain.IsChijiNeedReplaceHurtId(num, base.battleType))
				{
					ChijiEffectMapTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ChijiEffectMapTable>(num, string.Empty, string.Empty);
					buffDuration = TableManager.GetValueFromUnionCell(tableItem2.AttachBuffTime, skillLevel, true);
				}
				else
				{
					buffDuration = TableManager.GetValueFromUnionCell(tableItem.AttachBuffTime, skillLevel, true);
				}
			}
			if (beActor != null && beActor.m_iCamp == base.owner.m_iCamp)
			{
				if (beActor.GetEntityData().isSummonMonster)
				{
					beActor.buffController.TryAddBuff(this.summonMonsterBuffID, buffDuration, base.level);
				}
				else
				{
					beActor.buffController.TryAddBuff(this.friendBuffID, buffDuration, base.level);
				}
			}
		});
	}

	// Token: 0x060185FC RID: 99836 RVA: 0x00798492 File Offset: 0x00796892
	public override void OnFinish()
	{
		this.RemoveHandler();
	}

	// Token: 0x060185FD RID: 99837 RVA: 0x0079849A File Offset: 0x0079689A
	public override void OnCancel()
	{
		this.RemoveHandler();
	}

	// Token: 0x060185FE RID: 99838 RVA: 0x007984A2 File Offset: 0x007968A2
	private void RemoveHandler()
	{
		if (this.handler != null)
		{
			this.handler.Remove();
			this.handler = null;
		}
	}

	// Token: 0x04011980 RID: 72064
	private int friendBuffID;

	// Token: 0x04011981 RID: 72065
	private int summonMonsterBuffID;

	// Token: 0x04011982 RID: 72066
	private BeEventHandle handler;
}
