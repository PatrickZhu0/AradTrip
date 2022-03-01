using System;

namespace behaviac
{
	// Token: 0x02003D4C RID: 15692
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node57 : Condition
	{
		// Token: 0x0601622E RID: 90670 RVA: 0x006B0C73 File Offset: 0x006AF073
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node57()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x0601622F RID: 90671 RVA: 0x006B0C84 File Offset: 0x006AF084
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 2;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA90 RID: 64144
		private int opl_p0;
	}
}
