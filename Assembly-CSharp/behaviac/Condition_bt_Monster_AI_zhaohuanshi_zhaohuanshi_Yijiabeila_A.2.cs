using System;

namespace behaviac
{
	// Token: 0x02003FFF RID: 16383
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node3 : Condition
	{
		// Token: 0x06016762 RID: 92002 RVA: 0x006CC433 File Offset: 0x006CA833
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node3()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 1200;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06016763 RID: 92003 RVA: 0x006CC468 File Offset: 0x006CA868
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFB0 RID: 65456
		private int opl_p0;

		// Token: 0x0400FFB1 RID: 65457
		private int opl_p1;

		// Token: 0x0400FFB2 RID: 65458
		private int opl_p2;

		// Token: 0x0400FFB3 RID: 65459
		private int opl_p3;
	}
}
