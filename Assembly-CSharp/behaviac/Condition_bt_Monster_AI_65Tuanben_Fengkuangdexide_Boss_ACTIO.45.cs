using System;

namespace behaviac
{
	// Token: 0x02002EEB RID: 12011
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node25 : Condition
	{
		// Token: 0x060146B0 RID: 83632 RVA: 0x006234EF File Offset: 0x006218EF
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node25()
		{
			this.opl_p0 = 9000;
			this.opl_p1 = 1800;
			this.opl_p2 = 2400;
			this.opl_p3 = 2400;
		}

		// Token: 0x060146B1 RID: 83633 RVA: 0x00623524 File Offset: 0x00621924
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E02B RID: 57387
		private int opl_p0;

		// Token: 0x0400E02C RID: 57388
		private int opl_p1;

		// Token: 0x0400E02D RID: 57389
		private int opl_p2;

		// Token: 0x0400E02E RID: 57390
		private int opl_p3;
	}
}
