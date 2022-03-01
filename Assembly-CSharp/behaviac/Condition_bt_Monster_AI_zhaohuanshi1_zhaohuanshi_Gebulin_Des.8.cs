using System;

namespace behaviac
{
	// Token: 0x02004071 RID: 16497
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node18 : Condition
	{
		// Token: 0x06016840 RID: 92224 RVA: 0x006D0E9F File Offset: 0x006CF29F
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06016841 RID: 92225 RVA: 0x006D0ED4 File Offset: 0x006CF2D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010089 RID: 65673
		private int opl_p0;

		// Token: 0x0401008A RID: 65674
		private int opl_p1;

		// Token: 0x0401008B RID: 65675
		private int opl_p2;

		// Token: 0x0401008C RID: 65676
		private int opl_p3;
	}
}
