using System;

namespace behaviac
{
	// Token: 0x02002692 RID: 9874
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node52 : Condition
	{
		// Token: 0x06013668 RID: 79464 RVA: 0x005C6BD3 File Offset: 0x005C4FD3
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node52()
		{
			this.opl_p0 = 2006;
		}

		// Token: 0x06013669 RID: 79465 RVA: 0x005C6BE8 File Offset: 0x005C4FE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0BC RID: 53436
		private int opl_p0;
	}
}
