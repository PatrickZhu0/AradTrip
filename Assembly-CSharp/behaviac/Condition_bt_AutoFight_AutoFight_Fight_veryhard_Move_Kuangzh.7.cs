using System;

namespace behaviac
{
	// Token: 0x02002497 RID: 9367
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node12 : Condition
	{
		// Token: 0x0601327A RID: 78458 RVA: 0x005AF5B5 File Offset: 0x005AD9B5
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node12()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x0601327B RID: 78459 RVA: 0x005AF5C8 File Offset: 0x005AD9C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC92 RID: 52370
		private float opl_p0;
	}
}
