using System;

namespace behaviac
{
	// Token: 0x0200407F RID: 16511
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node18 : Condition
	{
		// Token: 0x0601685B RID: 92251 RVA: 0x006D18DF File Offset: 0x006CFCDF
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node18()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 6000;
			this.opl_p2 = 6000;
			this.opl_p3 = 6000;
		}

		// Token: 0x0601685C RID: 92252 RVA: 0x006D1914 File Offset: 0x006CFD14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100A4 RID: 65700
		private int opl_p0;

		// Token: 0x040100A5 RID: 65701
		private int opl_p1;

		// Token: 0x040100A6 RID: 65702
		private int opl_p2;

		// Token: 0x040100A7 RID: 65703
		private int opl_p3;
	}
}
