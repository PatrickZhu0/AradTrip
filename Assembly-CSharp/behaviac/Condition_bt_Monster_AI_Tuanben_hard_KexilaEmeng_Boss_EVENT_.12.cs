using System;

namespace behaviac
{
	// Token: 0x02003BE0 RID: 15328
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node79 : Condition
	{
		// Token: 0x06015F6D RID: 89965 RVA: 0x006A2E3E File Offset: 0x006A123E
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node79()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x06015F6E RID: 89966 RVA: 0x006A2E50 File Offset: 0x006A1250
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 2000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F80C RID: 63500
		private int opl_p0;
	}
}
