using System;

namespace behaviac
{
	// Token: 0x02004073 RID: 16499
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node22 : Condition
	{
		// Token: 0x06016844 RID: 92228 RVA: 0x006D0F43 File Offset: 0x006CF343
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_DestinationSelect_node22()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x06016845 RID: 92229 RVA: 0x006D0F78 File Offset: 0x006CF378
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401008E RID: 65678
		private int opl_p0;

		// Token: 0x0401008F RID: 65679
		private int opl_p1;

		// Token: 0x04010090 RID: 65680
		private int opl_p2;

		// Token: 0x04010091 RID: 65681
		private int opl_p3;
	}
}
