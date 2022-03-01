using System;

namespace behaviac
{
	// Token: 0x02002B6D RID: 11117
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node9 : Condition
	{
		// Token: 0x06013FE7 RID: 81895 RVA: 0x006012F1 File Offset: 0x005FF6F1
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node9()
		{
			this.opl_p0 = 42770021;
		}

		// Token: 0x06013FE8 RID: 81896 RVA: 0x00601304 File Offset: 0x005FF704
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9F8 RID: 55800
		private int opl_p0;
	}
}
