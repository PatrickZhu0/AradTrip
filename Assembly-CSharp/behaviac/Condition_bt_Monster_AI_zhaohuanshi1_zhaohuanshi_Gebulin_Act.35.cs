using System;

namespace behaviac
{
	// Token: 0x02004063 RID: 16483
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node61 : Condition
	{
		// Token: 0x06016825 RID: 92197 RVA: 0x006CFB77 File Offset: 0x006CDF77
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node61()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06016826 RID: 92198 RVA: 0x006CFBAC File Offset: 0x006CDFAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401006F RID: 65647
		private int opl_p0;

		// Token: 0x04010070 RID: 65648
		private int opl_p1;

		// Token: 0x04010071 RID: 65649
		private int opl_p2;

		// Token: 0x04010072 RID: 65650
		private int opl_p3;
	}
}
