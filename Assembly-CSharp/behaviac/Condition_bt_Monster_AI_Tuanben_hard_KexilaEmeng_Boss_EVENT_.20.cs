using System;

namespace behaviac
{
	// Token: 0x02003BEE RID: 15342
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node88 : Condition
	{
		// Token: 0x06015F89 RID: 89993 RVA: 0x006A31E3 File Offset: 0x006A15E3
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node88()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015F8A RID: 89994 RVA: 0x006A31F4 File Offset: 0x006A15F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 3000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F822 RID: 63522
		private int opl_p0;
	}
}
