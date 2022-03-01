using System;

namespace behaviac
{
	// Token: 0x02002374 RID: 9076
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node26 : Condition
	{
		// Token: 0x06013050 RID: 77904 RVA: 0x005A0898 File Offset: 0x0059EC98
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node26()
		{
			this.opl_p0 = 0.74f;
		}

		// Token: 0x06013051 RID: 77905 RVA: 0x005A08AC File Offset: 0x0059ECAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA67 RID: 51815
		private float opl_p0;
	}
}
