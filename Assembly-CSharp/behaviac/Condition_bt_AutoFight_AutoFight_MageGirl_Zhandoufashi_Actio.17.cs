using System;

namespace behaviac
{
	// Token: 0x02002716 RID: 10006
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node6 : Condition
	{
		// Token: 0x0601376E RID: 79726 RVA: 0x005CC8AB File Offset: 0x005CACAB
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node6()
		{
			this.opl_p0 = 2306;
		}

		// Token: 0x0601376F RID: 79727 RVA: 0x005CC8C0 File Offset: 0x005CACC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1C8 RID: 53704
		private int opl_p0;
	}
}
