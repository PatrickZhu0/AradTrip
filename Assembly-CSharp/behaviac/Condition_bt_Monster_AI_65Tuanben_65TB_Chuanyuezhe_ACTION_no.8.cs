using System;

namespace behaviac
{
	// Token: 0x02002B44 RID: 11076
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node45 : Condition
	{
		// Token: 0x06013F96 RID: 81814 RVA: 0x005FF0A9 File Offset: 0x005FD4A9
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node45()
		{
			this.opl_p0 = 42770021;
		}

		// Token: 0x06013F97 RID: 81815 RVA: 0x005FF0BC File Offset: 0x005FD4BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9BC RID: 55740
		private int opl_p0;
	}
}
