using System;

namespace behaviac
{
	// Token: 0x02002696 RID: 9878
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node57 : Condition
	{
		// Token: 0x06013670 RID: 79472 RVA: 0x005C6D87 File Offset: 0x005C5187
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node57()
		{
			this.opl_p0 = 2003;
		}

		// Token: 0x06013671 RID: 79473 RVA: 0x005C6D9C File Offset: 0x005C519C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0C4 RID: 53444
		private int opl_p0;
	}
}
