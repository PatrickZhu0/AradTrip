using System;

namespace behaviac
{
	// Token: 0x02003EC3 RID: 16067
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node8 : Condition
	{
		// Token: 0x06016503 RID: 91395 RVA: 0x006BFDB2 File Offset: 0x006BE1B2
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node8()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06016504 RID: 91396 RVA: 0x006BFDE8 File Offset: 0x006BE1E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD37 RID: 64823
		private int opl_p0;

		// Token: 0x0400FD38 RID: 64824
		private int opl_p1;

		// Token: 0x0400FD39 RID: 64825
		private int opl_p2;

		// Token: 0x0400FD3A RID: 64826
		private int opl_p3;
	}
}
