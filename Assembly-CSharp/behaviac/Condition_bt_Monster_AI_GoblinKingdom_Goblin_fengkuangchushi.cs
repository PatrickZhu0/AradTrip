using System;

namespace behaviac
{
	// Token: 0x02003315 RID: 13077
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node6 : Condition
	{
		// Token: 0x06014E91 RID: 85649 RVA: 0x0064CFA2 File Offset: 0x0064B3A2
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node6()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 6000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06014E92 RID: 85650 RVA: 0x0064CFD8 File Offset: 0x0064B3D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E77F RID: 59263
		private int opl_p0;

		// Token: 0x0400E780 RID: 59264
		private int opl_p1;

		// Token: 0x0400E781 RID: 59265
		private int opl_p2;

		// Token: 0x0400E782 RID: 59266
		private int opl_p3;
	}
}
