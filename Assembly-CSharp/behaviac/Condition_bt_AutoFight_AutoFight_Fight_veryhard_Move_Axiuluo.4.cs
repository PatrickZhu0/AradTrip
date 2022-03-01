using System;

namespace behaviac
{
	// Token: 0x02002479 RID: 9337
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node6 : Condition
	{
		// Token: 0x06013240 RID: 78400 RVA: 0x005AE44A File Offset: 0x005AC84A
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node6()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013241 RID: 78401 RVA: 0x005AE460 File Offset: 0x005AC860
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC5D RID: 52317
		private float opl_p0;
	}
}
