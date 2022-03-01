using System;

namespace behaviac
{
	// Token: 0x02004033 RID: 16435
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node8 : Condition
	{
		// Token: 0x060167C6 RID: 92102 RVA: 0x006CE57F File Offset: 0x006CC97F
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node8()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060167C7 RID: 92103 RVA: 0x006CE5B4 File Offset: 0x006CC9B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010011 RID: 65553
		private int opl_p0;

		// Token: 0x04010012 RID: 65554
		private int opl_p1;

		// Token: 0x04010013 RID: 65555
		private int opl_p2;

		// Token: 0x04010014 RID: 65556
		private int opl_p3;
	}
}
