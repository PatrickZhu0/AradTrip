using System;

namespace behaviac
{
	// Token: 0x0200309E RID: 12446
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node22 : Condition
	{
		// Token: 0x06014A00 RID: 84480 RVA: 0x00635AAB File Offset: 0x00633EAB
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node22()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06014A01 RID: 84481 RVA: 0x00635AE0 File Offset: 0x00633EE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E35C RID: 58204
		private int opl_p0;

		// Token: 0x0400E35D RID: 58205
		private int opl_p1;

		// Token: 0x0400E35E RID: 58206
		private int opl_p2;

		// Token: 0x0400E35F RID: 58207
		private int opl_p3;
	}
}
