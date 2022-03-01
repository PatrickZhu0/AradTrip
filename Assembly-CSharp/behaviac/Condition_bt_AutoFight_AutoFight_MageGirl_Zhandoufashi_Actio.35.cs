using System;

namespace behaviac
{
	// Token: 0x0200272E RID: 10030
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node65 : Condition
	{
		// Token: 0x0601379E RID: 79774 RVA: 0x005CD2E3 File Offset: 0x005CB6E3
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node65()
		{
			this.opl_p0 = 2312;
		}

		// Token: 0x0601379F RID: 79775 RVA: 0x005CD2F8 File Offset: 0x005CB6F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1F8 RID: 53752
		private int opl_p0;
	}
}
