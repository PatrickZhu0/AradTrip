using System;

namespace behaviac
{
	// Token: 0x02003ECB RID: 16075
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node18 : Condition
	{
		// Token: 0x06016513 RID: 91411 RVA: 0x006C011A File Offset: 0x006BE51A
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node18()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06016514 RID: 91412 RVA: 0x006C0150 File Offset: 0x006BE550
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD47 RID: 64839
		private int opl_p0;

		// Token: 0x0400FD48 RID: 64840
		private int opl_p1;

		// Token: 0x0400FD49 RID: 64841
		private int opl_p2;

		// Token: 0x0400FD4A RID: 64842
		private int opl_p3;
	}
}
