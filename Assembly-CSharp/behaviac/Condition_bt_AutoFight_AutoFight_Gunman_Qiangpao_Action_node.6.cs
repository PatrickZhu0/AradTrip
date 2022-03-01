using System;

namespace behaviac
{
	// Token: 0x02002644 RID: 9796
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node97 : Condition
	{
		// Token: 0x060135CD RID: 79309 RVA: 0x005C3815 File Offset: 0x005C1C15
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node97()
		{
			this.opl_p0 = 0.05f;
		}

		// Token: 0x060135CE RID: 79310 RVA: 0x005C3828 File Offset: 0x005C1C28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D01D RID: 53277
		private float opl_p0;
	}
}
