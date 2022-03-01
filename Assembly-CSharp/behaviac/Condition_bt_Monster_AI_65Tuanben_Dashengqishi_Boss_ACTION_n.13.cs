using System;

namespace behaviac
{
	// Token: 0x02002D9B RID: 11675
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node45 : Condition
	{
		// Token: 0x06014417 RID: 82967 RVA: 0x00615C3D File Offset: 0x0061403D
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node45()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x06014418 RID: 82968 RVA: 0x00615C4C File Offset: 0x0061404C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 2;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDDF RID: 56799
		private int opl_p0;
	}
}
