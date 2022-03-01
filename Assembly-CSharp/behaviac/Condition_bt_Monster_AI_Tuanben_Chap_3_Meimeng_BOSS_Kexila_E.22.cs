using System;

namespace behaviac
{
	// Token: 0x02003982 RID: 14722
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node25 : Condition
	{
		// Token: 0x06015ADB RID: 88795 RVA: 0x0068BB21 File Offset: 0x00689F21
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node25()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015ADC RID: 88796 RVA: 0x0068BB30 File Offset: 0x00689F30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 6000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F47D RID: 62589
		private int opl_p0;
	}
}
