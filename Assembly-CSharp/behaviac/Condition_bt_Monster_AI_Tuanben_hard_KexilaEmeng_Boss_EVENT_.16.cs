using System;

namespace behaviac
{
	// Token: 0x02003BE8 RID: 15336
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node26 : Condition
	{
		// Token: 0x06015F7D RID: 89981 RVA: 0x006A304F File Offset: 0x006A144F
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node26()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015F7E RID: 89982 RVA: 0x006A3060 File Offset: 0x006A1460
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F819 RID: 63513
		private int opl_p0;
	}
}
