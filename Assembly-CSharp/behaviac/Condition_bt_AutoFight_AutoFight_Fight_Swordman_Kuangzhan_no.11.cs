using System;

namespace behaviac
{
	// Token: 0x020023EC RID: 9196
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node26 : Condition
	{
		// Token: 0x06013138 RID: 78136 RVA: 0x005A7B88 File Offset: 0x005A5F88
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node26()
		{
			this.opl_p0 = 0.45f;
		}

		// Token: 0x06013139 RID: 78137 RVA: 0x005A7B9C File Offset: 0x005A5F9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB64 RID: 52068
		private float opl_p0;
	}
}
