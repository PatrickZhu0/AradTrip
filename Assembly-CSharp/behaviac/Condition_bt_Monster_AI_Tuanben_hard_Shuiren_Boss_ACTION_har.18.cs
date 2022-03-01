using System;

namespace behaviac
{
	// Token: 0x02003D5B RID: 15707
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node2 : Condition
	{
		// Token: 0x0601624C RID: 90700 RVA: 0x006B111F File Offset: 0x006AF51F
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node2()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x0601624D RID: 90701 RVA: 0x006B1130 File Offset: 0x006AF530
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 5;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAA9 RID: 64169
		private int opl_p0;
	}
}
