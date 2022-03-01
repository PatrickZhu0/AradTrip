using System;

namespace behaviac
{
	// Token: 0x02002464 RID: 9316
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node42 : Condition
	{
		// Token: 0x06013218 RID: 78360 RVA: 0x005AD32F File Offset: 0x005AB72F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node42()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x06013219 RID: 78361 RVA: 0x005AD344 File Offset: 0x005AB744
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC3C RID: 52284
		private int opl_p0;
	}
}
