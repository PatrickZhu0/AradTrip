using System;

namespace behaviac
{
	// Token: 0x02003CD8 RID: 15576
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node93 : Condition
	{
		// Token: 0x06016152 RID: 90450 RVA: 0x006ACA0C File Offset: 0x006AAE0C
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node93()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x06016153 RID: 90451 RVA: 0x006ACA1C File Offset: 0x006AAE1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 5;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA03 RID: 64003
		private int opl_p0;
	}
}
