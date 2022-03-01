using System;

namespace behaviac
{
	// Token: 0x02002315 RID: 8981
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node27 : Condition
	{
		// Token: 0x06012F9E RID: 77726 RVA: 0x0059C347 File Offset: 0x0059A747
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node27()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x06012F9F RID: 77727 RVA: 0x0059C35C File Offset: 0x0059A75C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9B6 RID: 51638
		private int opl_p0;
	}
}
