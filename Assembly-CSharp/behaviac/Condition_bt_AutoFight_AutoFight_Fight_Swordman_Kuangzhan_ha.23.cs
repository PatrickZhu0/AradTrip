using System;

namespace behaviac
{
	// Token: 0x02002385 RID: 9093
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node48 : Condition
	{
		// Token: 0x06013071 RID: 77937 RVA: 0x005A1012 File Offset: 0x0059F412
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node48()
		{
			this.opl_p0 = 0.72f;
		}

		// Token: 0x06013072 RID: 77938 RVA: 0x005A1028 File Offset: 0x0059F428
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA86 RID: 51846
		private float opl_p0;
	}
}
