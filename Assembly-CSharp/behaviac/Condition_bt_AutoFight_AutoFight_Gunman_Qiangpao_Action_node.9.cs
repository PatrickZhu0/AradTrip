using System;

namespace behaviac
{
	// Token: 0x02002649 RID: 9801
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node103 : Condition
	{
		// Token: 0x060135D7 RID: 79319 RVA: 0x005C3A0B File Offset: 0x005C1E0B
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node103()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x060135D8 RID: 79320 RVA: 0x005C3A20 File Offset: 0x005C1E20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D028 RID: 53288
		private float opl_p0;
	}
}
