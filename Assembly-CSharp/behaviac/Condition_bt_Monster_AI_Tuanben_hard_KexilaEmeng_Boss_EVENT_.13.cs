using System;

namespace behaviac
{
	// Token: 0x02003BE3 RID: 15331
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node49 : Condition
	{
		// Token: 0x06015F73 RID: 89971 RVA: 0x006A2EEC File Offset: 0x006A12EC
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node49()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x06015F74 RID: 89972 RVA: 0x006A2EFC File Offset: 0x006A12FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 1;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F810 RID: 63504
		private int opl_p0;
	}
}
