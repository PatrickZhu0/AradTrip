using System;

namespace behaviac
{
	// Token: 0x02002402 RID: 9218
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node54 : Condition
	{
		// Token: 0x06013163 RID: 78179 RVA: 0x005A8516 File Offset: 0x005A6916
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node54()
		{
			this.opl_p0 = 0.45f;
		}

		// Token: 0x06013164 RID: 78180 RVA: 0x005A852C File Offset: 0x005A692C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB8E RID: 52110
		private float opl_p0;
	}
}
