using System;

namespace behaviac
{
	// Token: 0x02002EC2 RID: 11970
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node53 : Action
	{
		// Token: 0x0601465E RID: 83550 RVA: 0x0062249F File Offset: 0x0062089F
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node53()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x0601465F RID: 83551 RVA: 0x006224B5 File Offset: 0x006208B5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StartTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFCE RID: 57294
		private int method_p0;
	}
}
