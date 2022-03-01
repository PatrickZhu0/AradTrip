using System;

namespace behaviac
{
	// Token: 0x02003CCD RID: 15565
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node43 : Condition
	{
		// Token: 0x0601613C RID: 90428 RVA: 0x006AC72F File Offset: 0x006AAB2F
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node43()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x0601613D RID: 90429 RVA: 0x006AC744 File Offset: 0x006AAB44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 1000;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9EE RID: 63982
		private int opl_p0;
	}
}
