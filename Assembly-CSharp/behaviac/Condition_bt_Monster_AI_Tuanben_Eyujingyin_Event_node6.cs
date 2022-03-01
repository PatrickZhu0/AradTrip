using System;

namespace behaviac
{
	// Token: 0x02003991 RID: 14737
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Eyujingyin_Event_node6 : Condition
	{
		// Token: 0x06015AF7 RID: 88823 RVA: 0x0068CCF0 File Offset: 0x0068B0F0
		public Condition_bt_Monster_AI_Tuanben_Eyujingyin_Event_node6()
		{
			this.opl_p0 = 21038;
		}

		// Token: 0x06015AF8 RID: 88824 RVA: 0x0068CD04 File Offset: 0x0068B104
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F492 RID: 62610
		private int opl_p0;
	}
}
