using System;

namespace behaviac
{
	// Token: 0x020023E1 RID: 9185
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node11 : Condition
	{
		// Token: 0x06013124 RID: 78116 RVA: 0x005A7698 File Offset: 0x005A5A98
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node11()
		{
			this.opl_p0 = 0.58f;
		}

		// Token: 0x06013125 RID: 78117 RVA: 0x005A76AC File Offset: 0x005A5AAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB51 RID: 52049
		private float opl_p0;
	}
}
