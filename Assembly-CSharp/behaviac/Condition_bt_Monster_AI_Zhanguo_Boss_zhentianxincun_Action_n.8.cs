using System;

namespace behaviac
{
	// Token: 0x02003EC7 RID: 16071
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node13 : Condition
	{
		// Token: 0x0601650B RID: 91403 RVA: 0x006BFF66 File Offset: 0x006BE366
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node13()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601650C RID: 91404 RVA: 0x006BFF9C File Offset: 0x006BE39C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD3F RID: 64831
		private int opl_p0;

		// Token: 0x0400FD40 RID: 64832
		private int opl_p1;

		// Token: 0x0400FD41 RID: 64833
		private int opl_p2;

		// Token: 0x0400FD42 RID: 64834
		private int opl_p3;
	}
}
