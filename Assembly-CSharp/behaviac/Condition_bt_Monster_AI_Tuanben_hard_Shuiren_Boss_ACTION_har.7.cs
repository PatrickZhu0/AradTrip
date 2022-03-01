using System;

namespace behaviac
{
	// Token: 0x02003D45 RID: 15685
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node12 : Condition
	{
		// Token: 0x06016220 RID: 90656 RVA: 0x006B0A26 File Offset: 0x006AEE26
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node12()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06016221 RID: 90657 RVA: 0x006B0A38 File Offset: 0x006AEE38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 3;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA84 RID: 64132
		private int opl_p0;
	}
}
