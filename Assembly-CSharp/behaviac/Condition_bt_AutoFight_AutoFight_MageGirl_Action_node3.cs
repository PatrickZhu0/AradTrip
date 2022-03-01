using System;

namespace behaviac
{
	// Token: 0x02002682 RID: 9858
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node3 : Condition
	{
		// Token: 0x06013648 RID: 79432 RVA: 0x005C6505 File Offset: 0x005C4905
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node3()
		{
			this.opl_p0 = 2111;
		}

		// Token: 0x06013649 RID: 79433 RVA: 0x005C6518 File Offset: 0x005C4918
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D09C RID: 53404
		private int opl_p0;
	}
}
