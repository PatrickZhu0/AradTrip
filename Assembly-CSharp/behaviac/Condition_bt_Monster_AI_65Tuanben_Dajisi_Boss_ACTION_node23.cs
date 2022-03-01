using System;

namespace behaviac
{
	// Token: 0x02002D80 RID: 11648
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node23 : Condition
	{
		// Token: 0x060143E2 RID: 82914 RVA: 0x0061486B File Offset: 0x00612C6B
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node23()
		{
			this.opl_p0 = 11000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060143E3 RID: 82915 RVA: 0x006148A0 File Offset: 0x00612CA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDB1 RID: 56753
		private int opl_p0;

		// Token: 0x0400DDB2 RID: 56754
		private int opl_p1;

		// Token: 0x0400DDB3 RID: 56755
		private int opl_p2;

		// Token: 0x0400DDB4 RID: 56756
		private int opl_p3;
	}
}
