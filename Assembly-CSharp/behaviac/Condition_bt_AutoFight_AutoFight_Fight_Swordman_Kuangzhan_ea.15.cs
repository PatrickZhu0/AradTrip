using System;

namespace behaviac
{
	// Token: 0x0200231A RID: 8986
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node34 : Condition
	{
		// Token: 0x06012FA7 RID: 77735 RVA: 0x0059C563 File Offset: 0x0059A963
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node34()
		{
			this.opl_p0 = 1608;
		}

		// Token: 0x06012FA8 RID: 77736 RVA: 0x0059C578 File Offset: 0x0059A978
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9BE RID: 51646
		private int opl_p0;
	}
}
