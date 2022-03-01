using System;

namespace behaviac
{
	// Token: 0x02003171 RID: 12657
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node7 : Condition
	{
		// Token: 0x06014B79 RID: 84857 RVA: 0x0063D2F8 File Offset: 0x0063B6F8
		public Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node7()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06014B7A RID: 84858 RVA: 0x0063D308 File Offset: 0x0063B708
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 1000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4EE RID: 58606
		private int opl_p0;
	}
}
