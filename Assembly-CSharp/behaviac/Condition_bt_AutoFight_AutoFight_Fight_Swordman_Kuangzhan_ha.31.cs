using System;

namespace behaviac
{
	// Token: 0x0200238F RID: 9103
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node60 : Condition
	{
		// Token: 0x06013085 RID: 77957 RVA: 0x005A143A File Offset: 0x0059F83A
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node60()
		{
			this.opl_p0 = 0.72f;
		}

		// Token: 0x06013086 RID: 77958 RVA: 0x005A1450 File Offset: 0x0059F850
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA9C RID: 51868
		private float opl_p0;
	}
}
