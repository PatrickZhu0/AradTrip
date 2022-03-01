using System;

namespace behaviac
{
	// Token: 0x02004007 RID: 16391
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node8 : Condition
	{
		// Token: 0x06016772 RID: 92018 RVA: 0x006CC79B File Offset: 0x006CAB9B
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node8()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 1200;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x06016773 RID: 92019 RVA: 0x006CC7D0 File Offset: 0x006CABD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFC0 RID: 65472
		private int opl_p0;

		// Token: 0x0400FFC1 RID: 65473
		private int opl_p1;

		// Token: 0x0400FFC2 RID: 65474
		private int opl_p2;

		// Token: 0x0400FFC3 RID: 65475
		private int opl_p3;
	}
}
