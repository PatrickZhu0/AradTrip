using System;

namespace behaviac
{
	// Token: 0x020036C9 RID: 14025
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node7 : Condition
	{
		// Token: 0x060155AA RID: 87466 RVA: 0x00671265 File Offset: 0x0066F665
		public Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node7()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060155AB RID: 87467 RVA: 0x00671278 File Offset: 0x0066F678
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF7E RID: 61310
		private float opl_p0;
	}
}
