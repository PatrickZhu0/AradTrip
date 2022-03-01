using System;

namespace behaviac
{
	// Token: 0x02003B4B RID: 15179
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node12 : Condition
	{
		// Token: 0x06015E4B RID: 89675 RVA: 0x0069D636 File Offset: 0x0069BA36
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node12()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015E4C RID: 89676 RVA: 0x0069D648 File Offset: 0x0069BA48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 3;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F71B RID: 63259
		private int opl_p0;
	}
}
