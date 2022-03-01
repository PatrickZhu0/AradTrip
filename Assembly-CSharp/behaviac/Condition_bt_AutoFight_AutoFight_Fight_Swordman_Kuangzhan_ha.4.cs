using System;

namespace behaviac
{
	// Token: 0x02002369 RID: 9065
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node11 : Condition
	{
		// Token: 0x0601303C RID: 77884 RVA: 0x005A03A8 File Offset: 0x0059E7A8
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node11()
		{
			this.opl_p0 = 0.78f;
		}

		// Token: 0x0601303D RID: 77885 RVA: 0x005A03BC File Offset: 0x0059E7BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA54 RID: 51796
		private float opl_p0;
	}
}
