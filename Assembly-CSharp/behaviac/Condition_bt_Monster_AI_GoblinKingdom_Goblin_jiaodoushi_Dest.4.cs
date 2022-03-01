using System;

namespace behaviac
{
	// Token: 0x02003337 RID: 13111
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node11 : Condition
	{
		// Token: 0x06014ED2 RID: 85714 RVA: 0x0064E1FD File Offset: 0x0064C5FD
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node11()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 6000;
			this.opl_p2 = 6000;
			this.opl_p3 = 6000;
		}

		// Token: 0x06014ED3 RID: 85715 RVA: 0x0064E234 File Offset: 0x0064C634
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7B8 RID: 59320
		private int opl_p0;

		// Token: 0x0400E7B9 RID: 59321
		private int opl_p1;

		// Token: 0x0400E7BA RID: 59322
		private int opl_p2;

		// Token: 0x0400E7BB RID: 59323
		private int opl_p3;
	}
}
