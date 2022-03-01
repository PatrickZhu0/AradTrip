using System;

namespace behaviac
{
	// Token: 0x02002DC3 RID: 11715
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node1 : Condition
	{
		// Token: 0x06014465 RID: 83045 RVA: 0x006178AA File Offset: 0x00615CAA
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node1()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06014466 RID: 83046 RVA: 0x006178BC File Offset: 0x00615CBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE27 RID: 56871
		private int opl_p0;
	}
}
