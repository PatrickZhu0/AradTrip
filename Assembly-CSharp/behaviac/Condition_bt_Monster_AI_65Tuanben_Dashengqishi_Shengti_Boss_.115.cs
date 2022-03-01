using System;

namespace behaviac
{
	// Token: 0x02002E97 RID: 11927
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node22 : Condition
	{
		// Token: 0x06014609 RID: 83465 RVA: 0x00620C86 File Offset: 0x0061F086
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node22()
		{
			this.opl_p0 = 3;
		}

		// Token: 0x0601460A RID: 83466 RVA: 0x00620C98 File Offset: 0x0061F098
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 65000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF89 RID: 57225
		private int opl_p0;
	}
}
