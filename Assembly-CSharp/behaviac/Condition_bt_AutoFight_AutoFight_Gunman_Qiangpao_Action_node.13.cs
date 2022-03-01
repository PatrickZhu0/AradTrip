using System;

namespace behaviac
{
	// Token: 0x0200264E RID: 9806
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node2 : Condition
	{
		// Token: 0x060135E1 RID: 79329 RVA: 0x005C3C11 File Offset: 0x005C2011
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node2()
		{
			this.opl_p0 = 0.05f;
		}

		// Token: 0x060135E2 RID: 79330 RVA: 0x005C3C24 File Offset: 0x005C2024
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D032 RID: 53298
		private float opl_p0;
	}
}
