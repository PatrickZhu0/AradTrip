using System;

namespace behaviac
{
	// Token: 0x0200397E RID: 14718
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node23 : Condition
	{
		// Token: 0x06015AD3 RID: 88787 RVA: 0x0068BA15 File Offset: 0x00689E15
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node23()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015AD4 RID: 88788 RVA: 0x0068BA24 File Offset: 0x00689E24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 3000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F477 RID: 62583
		private int opl_p0;
	}
}
