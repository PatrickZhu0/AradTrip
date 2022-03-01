using System;

namespace behaviac
{
	// Token: 0x02002349 RID: 9033
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node33 : Condition
	{
		// Token: 0x06012FFF RID: 77823 RVA: 0x0059E7E8 File Offset: 0x0059CBE8
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node33()
		{
			this.opl_p0 = 0.26f;
		}

		// Token: 0x06013000 RID: 77824 RVA: 0x0059E7FC File Offset: 0x0059CBFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA16 RID: 51734
		private float opl_p0;
	}
}
