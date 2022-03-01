using System;

namespace behaviac
{
	// Token: 0x02003EBE RID: 16062
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node3 : Condition
	{
		// Token: 0x060164F9 RID: 91385 RVA: 0x006BFB80 File Offset: 0x006BDF80
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node3()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060164FA RID: 91386 RVA: 0x006BFBB4 File Offset: 0x006BDFB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD2B RID: 64811
		private int opl_p0;

		// Token: 0x0400FD2C RID: 64812
		private int opl_p1;

		// Token: 0x0400FD2D RID: 64813
		private int opl_p2;

		// Token: 0x0400FD2E RID: 64814
		private int opl_p3;
	}
}
