using System;

namespace behaviac
{
	// Token: 0x02003FB2 RID: 16306
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node51 : Condition
	{
		// Token: 0x060166CE RID: 91854 RVA: 0x006C8633 File Offset: 0x006C6A33
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node51()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060166CF RID: 91855 RVA: 0x006C8668 File Offset: 0x006C6A68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF20 RID: 65312
		private int opl_p0;

		// Token: 0x0400FF21 RID: 65313
		private int opl_p1;

		// Token: 0x0400FF22 RID: 65314
		private int opl_p2;

		// Token: 0x0400FF23 RID: 65315
		private int opl_p3;
	}
}
