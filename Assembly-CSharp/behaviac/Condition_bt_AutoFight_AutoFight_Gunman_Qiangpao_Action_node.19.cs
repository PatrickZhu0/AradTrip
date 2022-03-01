using System;

namespace behaviac
{
	// Token: 0x02002657 RID: 9815
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node59 : Condition
	{
		// Token: 0x060135F3 RID: 79347 RVA: 0x005C3FB1 File Offset: 0x005C23B1
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node59()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x060135F4 RID: 79348 RVA: 0x005C3FC4 File Offset: 0x005C23C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D044 RID: 53316
		private float opl_p0;
	}
}
