using System;

namespace behaviac
{
	// Token: 0x02003D4B RID: 15691
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node19 : Condition
	{
		// Token: 0x0601622C RID: 90668 RVA: 0x006B0C30 File Offset: 0x006AF030
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node19()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x0601622D RID: 90669 RVA: 0x006B0C40 File Offset: 0x006AF040
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 5;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA8F RID: 64143
		private int opl_p0;
	}
}
