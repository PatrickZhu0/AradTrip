using System;

namespace behaviac
{
	// Token: 0x02003B51 RID: 15185
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node19 : Condition
	{
		// Token: 0x06015E57 RID: 89687 RVA: 0x0069D840 File Offset: 0x0069BC40
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node19()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x06015E58 RID: 89688 RVA: 0x0069D850 File Offset: 0x0069BC50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 5;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F726 RID: 63270
		private int opl_p0;
	}
}
