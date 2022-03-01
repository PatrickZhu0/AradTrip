using System;

namespace behaviac
{
	// Token: 0x02001F79 RID: 8057
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node29 : Condition
	{
		// Token: 0x06012892 RID: 75922 RVA: 0x0056D9F5 File Offset: 0x0056BDF5
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node29()
		{
			this.opl_p0 = 2504;
		}

		// Token: 0x06012893 RID: 75923 RVA: 0x0056DA08 File Offset: 0x0056BE08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C285 RID: 49797
		private int opl_p0;
	}
}
