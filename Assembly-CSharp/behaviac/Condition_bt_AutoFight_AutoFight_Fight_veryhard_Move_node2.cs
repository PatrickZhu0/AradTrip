using System;

namespace behaviac
{
	// Token: 0x02002470 RID: 9328
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_node2 : Condition
	{
		// Token: 0x0601322F RID: 78383 RVA: 0x005AE04F File Offset: 0x005AC44F
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_node2()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013230 RID: 78384 RVA: 0x005AE064 File Offset: 0x005AC464
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC52 RID: 52306
		private float opl_p0;
	}
}
