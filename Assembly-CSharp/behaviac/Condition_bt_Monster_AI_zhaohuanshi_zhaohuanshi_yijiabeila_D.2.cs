using System;

namespace behaviac
{
	// Token: 0x0200400F RID: 16399
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node6 : Condition
	{
		// Token: 0x06016781 RID: 92033 RVA: 0x006CCF57 File Offset: 0x006CB357
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node6()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06016782 RID: 92034 RVA: 0x006CCF8C File Offset: 0x006CB38C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFCF RID: 65487
		private int opl_p0;

		// Token: 0x0400FFD0 RID: 65488
		private int opl_p1;

		// Token: 0x0400FFD1 RID: 65489
		private int opl_p2;

		// Token: 0x0400FFD2 RID: 65490
		private int opl_p3;
	}
}
