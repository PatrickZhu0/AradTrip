using System;

namespace behaviac
{
	// Token: 0x0200249B RID: 9371
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node3 : Condition
	{
		// Token: 0x06013282 RID: 78466 RVA: 0x005AF6E5 File Offset: 0x005ADAE5
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node3()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06013283 RID: 78467 RVA: 0x005AF6F8 File Offset: 0x005ADAF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC99 RID: 52377
		private float opl_p0;
	}
}
