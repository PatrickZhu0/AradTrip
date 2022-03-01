using System;

namespace behaviac
{
	// Token: 0x02002F1A RID: 12058
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node36 : Condition
	{
		// Token: 0x0601470A RID: 83722 RVA: 0x00626455 File Offset: 0x00624855
		public Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node36()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x0601470B RID: 83723 RVA: 0x00626464 File Offset: 0x00624864
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 1;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E082 RID: 57474
		private int opl_p0;
	}
}
