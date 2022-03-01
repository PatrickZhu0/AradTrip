using System;

namespace behaviac
{
	// Token: 0x02001E61 RID: 7777
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node50 : Condition
	{
		// Token: 0x0601266E RID: 75374 RVA: 0x00561247 File Offset: 0x0055F647
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node50()
		{
			this.opl_p0 = 9715;
		}

		// Token: 0x0601266F RID: 75375 RVA: 0x0056125C File Offset: 0x0055F65C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C056 RID: 49238
		private int opl_p0;
	}
}
