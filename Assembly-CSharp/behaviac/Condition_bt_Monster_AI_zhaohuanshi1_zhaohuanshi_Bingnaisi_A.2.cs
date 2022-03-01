using System;

namespace behaviac
{
	// Token: 0x02004023 RID: 16419
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node7 : Condition
	{
		// Token: 0x060167A7 RID: 92071 RVA: 0x006CDB57 File Offset: 0x006CBF57
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node7()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060167A8 RID: 92072 RVA: 0x006CDB8C File Offset: 0x006CBF8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFF3 RID: 65523
		private int opl_p0;

		// Token: 0x0400FFF4 RID: 65524
		private int opl_p1;

		// Token: 0x0400FFF5 RID: 65525
		private int opl_p2;

		// Token: 0x0400FFF6 RID: 65526
		private int opl_p3;
	}
}
