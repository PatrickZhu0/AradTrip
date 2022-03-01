using System;

namespace behaviac
{
	// Token: 0x02003370 RID: 13168
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_zibaohong_Event_node4 : Condition
	{
		// Token: 0x06014F3E RID: 85822 RVA: 0x006501AD File Offset: 0x0064E5AD
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_zibaohong_Event_node4()
		{
			this.opl_p0 = 5697;
		}

		// Token: 0x06014F3F RID: 85823 RVA: 0x006501C0 File Offset: 0x0064E5C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E806 RID: 59398
		private int opl_p0;
	}
}
