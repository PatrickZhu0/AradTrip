using System;

namespace behaviac
{
	// Token: 0x02002B3B RID: 11067
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node10 : Condition
	{
		// Token: 0x06013F84 RID: 81796 RVA: 0x005FECA7 File Offset: 0x005FD0A7
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node10()
		{
			this.opl_p0 = 21858;
		}

		// Token: 0x06013F85 RID: 81797 RVA: 0x005FECBC File Offset: 0x005FD0BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9AB RID: 55723
		private int opl_p0;
	}
}
