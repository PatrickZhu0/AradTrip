using System;

namespace behaviac
{
	// Token: 0x02002B3D RID: 11069
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node15 : Condition
	{
		// Token: 0x06013F88 RID: 81800 RVA: 0x005FED9A File Offset: 0x005FD19A
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node15()
		{
			this.opl_p0 = 42770021;
		}

		// Token: 0x06013F89 RID: 81801 RVA: 0x005FEDB0 File Offset: 0x005FD1B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9AE RID: 55726
		private int opl_p0;
	}
}
