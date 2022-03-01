using System;

namespace behaviac
{
	// Token: 0x02002568 RID: 9576
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node2 : Condition
	{
		// Token: 0x06013418 RID: 78872 RVA: 0x005B97DE File Offset: 0x005B7BDE
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node2()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013419 RID: 78873 RVA: 0x005B97F4 File Offset: 0x005B7BF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE3E RID: 52798
		private float opl_p0;
	}
}
