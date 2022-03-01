using System;

namespace behaviac
{
	// Token: 0x02002736 RID: 10038
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node26 : Condition
	{
		// Token: 0x060137AE RID: 79790 RVA: 0x005CD64B File Offset: 0x005CBA4B
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node26()
		{
			this.opl_p0 = 2301;
		}

		// Token: 0x060137AF RID: 79791 RVA: 0x005CD660 File Offset: 0x005CBA60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D208 RID: 53768
		private int opl_p0;
	}
}
