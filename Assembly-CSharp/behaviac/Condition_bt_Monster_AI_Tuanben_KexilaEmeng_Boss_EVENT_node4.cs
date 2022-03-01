using System;

namespace behaviac
{
	// Token: 0x02003A00 RID: 14848
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node4 : Condition
	{
		// Token: 0x06015BCE RID: 89038 RVA: 0x00690CFA File Offset: 0x0068F0FA
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node4()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015BCF RID: 89039 RVA: 0x00690D0C File Offset: 0x0068F10C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 40000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4FA RID: 62714
		private int opl_p0;
	}
}
