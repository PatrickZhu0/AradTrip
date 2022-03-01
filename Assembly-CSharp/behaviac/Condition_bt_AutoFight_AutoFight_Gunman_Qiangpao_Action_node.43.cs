using System;

namespace behaviac
{
	// Token: 0x02002676 RID: 9846
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node41 : Condition
	{
		// Token: 0x06013631 RID: 79409 RVA: 0x005C4D19 File Offset: 0x005C3119
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node41()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013632 RID: 79410 RVA: 0x005C4D2C File Offset: 0x005C312C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D085 RID: 53381
		private float opl_p0;
	}
}
