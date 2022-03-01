using System;

namespace behaviac
{
	// Token: 0x02002B77 RID: 11127
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node18 : Condition
	{
		// Token: 0x06013FFB RID: 81915 RVA: 0x0060159B File Offset: 0x005FF99B
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node18()
		{
			this.opl_p0 = 42770021;
		}

		// Token: 0x06013FFC RID: 81916 RVA: 0x006015B0 File Offset: 0x005FF9B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA06 RID: 55814
		private int opl_p0;
	}
}
