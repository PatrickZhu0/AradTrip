using System;

namespace behaviac
{
	// Token: 0x02001E6C RID: 7788
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node74 : Condition
	{
		// Token: 0x06012684 RID: 75396 RVA: 0x00561A3F File Offset: 0x0055FE3F
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node74()
		{
			this.opl_p0 = 9719;
		}

		// Token: 0x06012685 RID: 75397 RVA: 0x00561A54 File Offset: 0x0055FE54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C06D RID: 49261
		private int opl_p0;
	}
}
