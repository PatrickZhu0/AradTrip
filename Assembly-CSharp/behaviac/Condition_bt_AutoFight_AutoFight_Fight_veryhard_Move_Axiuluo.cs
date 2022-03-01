using System;

namespace behaviac
{
	// Token: 0x02002475 RID: 9333
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node19 : Condition
	{
		// Token: 0x06013238 RID: 78392 RVA: 0x005AE2D9 File Offset: 0x005AC6D9
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node19()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013239 RID: 78393 RVA: 0x005AE2EC File Offset: 0x005AC6EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC56 RID: 52310
		private float opl_p0;
	}
}
