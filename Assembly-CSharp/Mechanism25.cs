using System;
using System.Collections.Generic;

// Token: 0x020043D3 RID: 17363
public class Mechanism25 : BeMechanism
{
	// Token: 0x06018174 RID: 98676 RVA: 0x0077BFBE File Offset: 0x0077A3BE
	public Mechanism25(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018175 RID: 98677 RVA: 0x0077BFEC File Offset: 0x0077A3EC
	public override void OnInit()
	{
		this.skillID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this.addBuffIDList1.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
		for (int j = 0; j < this.data.ValueC.Count; j++)
		{
			this.addBuffIDList2.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[j], this.level, true));
		}
	}

	// Token: 0x06018176 RID: 98678 RVA: 0x0077C0C0 File Offset: 0x0077A4C0
	public override void OnStart()
	{
		BeActor master = base.owner.GetOwner() as BeActor;
		if (master == null || master.IsDeadOrRemoved())
		{
			return;
		}
		this.handleA = master.RegisterEvent(BeEventType.onHPChange, delegate(object[] args)
		{
			if (master.GetEntityData().GetHP() <= 0)
			{
				bool flag = this.owner.UseSkill(this.skillID, false);
				if (flag)
				{
					master.GetEntityData().SetHP(1);
					master.SetIsDead(false);
					for (int i = 0; i < this.addBuffIDList1.Count; i++)
					{
						master.buffController.TryAddBuff(this.addBuffIDList1[i], GlobalLogic.VALUE_2000, this.level);
					}
					master.buffController.TryAddBuff(2, GlobalLogic.VALUE_2000, 1);
					master.delayCaller.DelayCall(GlobalLogic.VALUE_100, delegate
					{
						master.m_pkGeActor.SyncHPBar();
					}, 0, 0, false);
					master.delayCaller.DelayCall(GlobalLogic.VALUE_1000, delegate
					{
						for (int j = 0; j < this.addBuffIDList2.Count; j++)
						{
							master.buffController.TryAddBuff(this.addBuffIDList2[j], GlobalLogic.VALUE_2000, this.level);
						}
					}, 0, 0, false);
					int ms = 500;
					if (master != null && !master.IsDead())
					{
						master.m_pkGeActor.ChangeAction("Anim_Daodi", 1f, false, true, false);
						master.delayCaller.DelayCall(ms, delegate
						{
							if (master != null && !master.IsDead() && master.sgGetCurrentState() == 0)
							{
								master.m_pkGeActor.ChangeAction("Anim_Idle02", 1f, true, true, false);
							}
						}, 0, 0, false);
					}
				}
			}
		});
	}

	// Token: 0x040115CD RID: 71117
	private int skillID = 9506;

	// Token: 0x040115CE RID: 71118
	private List<int> addBuffIDList1 = new List<int>();

	// Token: 0x040115CF RID: 71119
	private List<int> addBuffIDList2 = new List<int>();
}
