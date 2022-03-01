using System;

namespace behaviac
{
	// Token: 0x02002493 RID: 9363
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node6 : Condition
	{
		// Token: 0x06013272 RID: 78450 RVA: 0x005AF432 File Offset: 0x005AD832
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node6()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013273 RID: 78451 RVA: 0x005AF448 File Offset: 0x005AD848
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC8B RID: 52363
		private float opl_p0;
	}
}
