using System;

namespace behaviac
{
	// Token: 0x0200332C RID: 13100
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node7 : Condition
	{
		// Token: 0x06014EBD RID: 85693 RVA: 0x0064DCA1 File Offset: 0x0064C0A1
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node7()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = 20000;
			this.opl_p2 = 20000;
			this.opl_p3 = 20000;
		}

		// Token: 0x06014EBE RID: 85694 RVA: 0x0064DCD8 File Offset: 0x0064C0D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7A2 RID: 59298
		private int opl_p0;

		// Token: 0x0400E7A3 RID: 59299
		private int opl_p1;

		// Token: 0x0400E7A4 RID: 59300
		private int opl_p2;

		// Token: 0x0400E7A5 RID: 59301
		private int opl_p3;
	}
}
