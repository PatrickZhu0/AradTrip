using System;

namespace behaviac
{
	// Token: 0x020032E0 RID: 13024
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node30 : Condition
	{
		// Token: 0x06014E2E RID: 85550 RVA: 0x0064AF7B File Offset: 0x0064937B
		public Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node30()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x06014E2F RID: 85551 RVA: 0x0064AF90 File Offset: 0x00649390
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E70F RID: 59151
		private float opl_p0;
	}
}
