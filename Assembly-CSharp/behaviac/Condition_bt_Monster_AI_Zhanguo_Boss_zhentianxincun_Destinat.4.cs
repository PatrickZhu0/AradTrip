using System;

namespace behaviac
{
	// Token: 0x02003ED4 RID: 16084
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node11 : Condition
	{
		// Token: 0x06016524 RID: 91428 RVA: 0x006C0A59 File Offset: 0x006BEE59
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_DestinationSelect_node11()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 6000;
			this.opl_p2 = 6000;
			this.opl_p3 = 6000;
		}

		// Token: 0x06016525 RID: 91429 RVA: 0x006C0A90 File Offset: 0x006BEE90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD59 RID: 64857
		private int opl_p0;

		// Token: 0x0400FD5A RID: 64858
		private int opl_p1;

		// Token: 0x0400FD5B RID: 64859
		private int opl_p2;

		// Token: 0x0400FD5C RID: 64860
		private int opl_p3;
	}
}
