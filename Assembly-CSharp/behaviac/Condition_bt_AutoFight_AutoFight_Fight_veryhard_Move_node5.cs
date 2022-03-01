using System;

namespace behaviac
{
	// Token: 0x02002472 RID: 9330
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_node5 : Condition
	{
		// Token: 0x06013233 RID: 78387 RVA: 0x005AE0C1 File Offset: 0x005AC4C1
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_node5()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013234 RID: 78388 RVA: 0x005AE0D4 File Offset: 0x005AC4D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC54 RID: 52308
		private float opl_p0;
	}
}
