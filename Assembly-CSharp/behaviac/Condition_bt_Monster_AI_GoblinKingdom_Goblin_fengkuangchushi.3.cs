using System;

namespace behaviac
{
	// Token: 0x02003318 RID: 13080
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node8 : Condition
	{
		// Token: 0x06014E97 RID: 85655 RVA: 0x0064D091 File Offset: 0x0064B491
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node8()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 6000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06014E98 RID: 85656 RVA: 0x0064D0C8 File Offset: 0x0064B4C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E785 RID: 59269
		private int opl_p0;

		// Token: 0x0400E786 RID: 59270
		private int opl_p1;

		// Token: 0x0400E787 RID: 59271
		private int opl_p2;

		// Token: 0x0400E788 RID: 59272
		private int opl_p3;
	}
}
