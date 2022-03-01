using System;

namespace behaviac
{
	// Token: 0x0200332F RID: 13103
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node8 : Condition
	{
		// Token: 0x06014EC3 RID: 85699 RVA: 0x0064DD8D File Offset: 0x0064C18D
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node8()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = 20000;
			this.opl_p2 = 20000;
			this.opl_p3 = 20000;
		}

		// Token: 0x06014EC4 RID: 85700 RVA: 0x0064DDC4 File Offset: 0x0064C1C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7A8 RID: 59304
		private int opl_p0;

		// Token: 0x0400E7A9 RID: 59305
		private int opl_p1;

		// Token: 0x0400E7AA RID: 59306
		private int opl_p2;

		// Token: 0x0400E7AB RID: 59307
		private int opl_p3;
	}
}
