using System;

namespace behaviac
{
	// Token: 0x0200237C RID: 9084
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node37 : Condition
	{
		// Token: 0x0601305F RID: 77919 RVA: 0x005A0BEE File Offset: 0x0059EFEE
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node37()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013060 RID: 77920 RVA: 0x005A0C04 File Offset: 0x0059F004
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA73 RID: 51827
		private float opl_p0;
	}
}
