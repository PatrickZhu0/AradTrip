using System;

namespace behaviac
{
	// Token: 0x0200268A RID: 9866
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node13 : Condition
	{
		// Token: 0x06013658 RID: 79448 RVA: 0x005C686B File Offset: 0x005C4C6B
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node13()
		{
			this.opl_p0 = 2009;
		}

		// Token: 0x06013659 RID: 79449 RVA: 0x005C6880 File Offset: 0x005C4C80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0AC RID: 53420
		private int opl_p0;
	}
}
