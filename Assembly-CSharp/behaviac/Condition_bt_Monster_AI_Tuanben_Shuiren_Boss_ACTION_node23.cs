using System;

namespace behaviac
{
	// Token: 0x02003B5F RID: 15199
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node23 : Condition
	{
		// Token: 0x06015E73 RID: 89715 RVA: 0x0069DCA6 File Offset: 0x0069C0A6
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node23()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015E74 RID: 89716 RVA: 0x0069DCB8 File Offset: 0x0069C0B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F73E RID: 63294
		private int opl_p0;
	}
}
