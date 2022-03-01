using System;

namespace behaviac
{
	// Token: 0x02002335 RID: 9013
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node7 : Condition
	{
		// Token: 0x06012FDB RID: 77787 RVA: 0x0059DF5F File Offset: 0x0059C35F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node7()
		{
			this.opl_p0 = 1609;
		}

		// Token: 0x06012FDC RID: 77788 RVA: 0x0059DF74 File Offset: 0x0059C374
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9F4 RID: 51700
		private int opl_p0;
	}
}
