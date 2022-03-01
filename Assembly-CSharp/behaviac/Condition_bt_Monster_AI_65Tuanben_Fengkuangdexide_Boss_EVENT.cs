using System;

namespace behaviac
{
	// Token: 0x02002EF0 RID: 12016
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node52 : Condition
	{
		// Token: 0x060146B8 RID: 83640 RVA: 0x00624A4F File Offset: 0x00622E4F
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node52()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x060146B9 RID: 83641 RVA: 0x00624A60 File Offset: 0x00622E60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 15300;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E032 RID: 57394
		private int opl_p0;
	}
}
