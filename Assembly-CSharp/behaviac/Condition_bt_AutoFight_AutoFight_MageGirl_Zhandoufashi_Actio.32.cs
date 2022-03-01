using System;

namespace behaviac
{
	// Token: 0x0200272A RID: 10026
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node60 : Condition
	{
		// Token: 0x06013796 RID: 79766 RVA: 0x005CD12F File Offset: 0x005CB52F
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node60()
		{
			this.opl_p0 = 2310;
		}

		// Token: 0x06013797 RID: 79767 RVA: 0x005CD144 File Offset: 0x005CB544
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1F0 RID: 53744
		private int opl_p0;
	}
}
