using System;

namespace behaviac
{
	// Token: 0x02003586 RID: 13702
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node14 : Condition
	{
		// Token: 0x0601533E RID: 86846 RVA: 0x00663DCF File Offset: 0x006621CF
		public Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node14()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 2500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x0601533F RID: 86847 RVA: 0x00663E04 File Offset: 0x00662204
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECFF RID: 60671
		private int opl_p0;

		// Token: 0x0400ED00 RID: 60672
		private int opl_p1;

		// Token: 0x0400ED01 RID: 60673
		private int opl_p2;

		// Token: 0x0400ED02 RID: 60674
		private int opl_p3;
	}
}
