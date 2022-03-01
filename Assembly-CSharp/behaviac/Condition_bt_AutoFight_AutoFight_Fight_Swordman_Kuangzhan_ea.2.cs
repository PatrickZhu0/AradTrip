using System;

namespace behaviac
{
	// Token: 0x02002305 RID: 8965
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node7 : Condition
	{
		// Token: 0x06012F81 RID: 77697 RVA: 0x0059BC93 File Offset: 0x0059A093
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node7()
		{
			this.opl_p0 = 1609;
		}

		// Token: 0x06012F82 RID: 77698 RVA: 0x0059BCA8 File Offset: 0x0059A0A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C99B RID: 51611
		private int opl_p0;
	}
}
