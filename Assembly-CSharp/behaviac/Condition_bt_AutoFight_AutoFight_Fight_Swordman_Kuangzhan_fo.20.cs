using System;

namespace behaviac
{
	// Token: 0x02002351 RID: 9041
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node44 : Condition
	{
		// Token: 0x0601300F RID: 77839 RVA: 0x0059EB36 File Offset: 0x0059CF36
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node44()
		{
			this.opl_p0 = 0.27f;
		}

		// Token: 0x06013010 RID: 77840 RVA: 0x0059EB4C File Offset: 0x0059CF4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA25 RID: 51749
		private float opl_p0;
	}
}
