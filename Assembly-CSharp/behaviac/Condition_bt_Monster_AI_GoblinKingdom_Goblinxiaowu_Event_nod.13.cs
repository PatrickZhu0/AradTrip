using System;

namespace behaviac
{
	// Token: 0x020032F4 RID: 13044
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node47 : Condition
	{
		// Token: 0x06014E53 RID: 85587 RVA: 0x0064B535 File Offset: 0x00649935
		public Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node47()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014E54 RID: 85588 RVA: 0x0064B548 File Offset: 0x00649948
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E73E RID: 59198
		private float opl_p0;
	}
}
