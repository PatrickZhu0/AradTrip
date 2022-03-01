using System;

namespace behaviac
{
	// Token: 0x0200230B RID: 8971
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node13 : Condition
	{
		// Token: 0x06012F8C RID: 77708 RVA: 0x0059BEB3 File Offset: 0x0059A2B3
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node13()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x06012F8D RID: 77709 RVA: 0x0059BEC8 File Offset: 0x0059A2C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9A6 RID: 51622
		private int opl_p0;
	}
}
