using System;

namespace behaviac
{
	// Token: 0x0200247D RID: 9341
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node3 : Condition
	{
		// Token: 0x06013248 RID: 78408 RVA: 0x005AE5BD File Offset: 0x005AC9BD
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Axiuluo_node3()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06013249 RID: 78409 RVA: 0x005AE5D0 File Offset: 0x005AC9D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC64 RID: 52324
		private float opl_p0;
	}
}
