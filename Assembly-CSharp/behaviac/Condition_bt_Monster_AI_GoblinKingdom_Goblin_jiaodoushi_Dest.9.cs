using System;

namespace behaviac
{
	// Token: 0x0200333F RID: 13119
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node18 : Condition
	{
		// Token: 0x06014EE2 RID: 85730 RVA: 0x0064E449 File Offset: 0x0064C849
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node18()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1000;
		}

		// Token: 0x06014EE3 RID: 85731 RVA: 0x0064E480 File Offset: 0x0064C880
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7C6 RID: 59334
		private int opl_p0;

		// Token: 0x0400E7C7 RID: 59335
		private int opl_p1;

		// Token: 0x0400E7C8 RID: 59336
		private int opl_p2;

		// Token: 0x0400E7C9 RID: 59337
		private int opl_p3;
	}
}
