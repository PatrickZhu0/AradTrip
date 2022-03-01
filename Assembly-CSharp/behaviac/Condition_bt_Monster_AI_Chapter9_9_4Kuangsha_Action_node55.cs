using System;

namespace behaviac
{
	// Token: 0x0200316C RID: 12652
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node55 : Condition
	{
		// Token: 0x06014B6F RID: 84847 RVA: 0x0063D168 File Offset: 0x0063B568
		public Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node55()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06014B70 RID: 84848 RVA: 0x0063D178 File Offset: 0x0063B578
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 1000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4E9 RID: 58601
		private int opl_p0;
	}
}
