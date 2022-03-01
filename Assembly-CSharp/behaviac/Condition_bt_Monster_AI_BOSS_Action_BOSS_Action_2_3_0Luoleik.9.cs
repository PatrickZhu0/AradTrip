using System;

namespace behaviac
{
	// Token: 0x02002F5C RID: 12124
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node16 : Condition
	{
		// Token: 0x06014787 RID: 83847 RVA: 0x00628D43 File Offset: 0x00627143
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node16()
		{
			this.opl_p0 = 5050;
		}

		// Token: 0x06014788 RID: 83848 RVA: 0x00628D58 File Offset: 0x00627158
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0F6 RID: 57590
		private int opl_p0;
	}
}
