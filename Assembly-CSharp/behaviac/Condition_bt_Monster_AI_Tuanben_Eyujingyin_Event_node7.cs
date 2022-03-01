using System;

namespace behaviac
{
	// Token: 0x02003992 RID: 14738
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Eyujingyin_Event_node7 : Condition
	{
		// Token: 0x06015AF9 RID: 88825 RVA: 0x0068CD37 File Offset: 0x0068B137
		public Condition_bt_Monster_AI_Tuanben_Eyujingyin_Event_node7()
		{
			this.opl_p0 = 21038;
		}

		// Token: 0x06015AFA RID: 88826 RVA: 0x0068CD4C File Offset: 0x0068B14C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F493 RID: 62611
		private int opl_p0;
	}
}
