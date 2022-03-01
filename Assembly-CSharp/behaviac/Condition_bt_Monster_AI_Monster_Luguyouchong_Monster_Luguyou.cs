using System;

namespace behaviac
{
	// Token: 0x020036C5 RID: 14021
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node2 : Condition
	{
		// Token: 0x060155A2 RID: 87458 RVA: 0x006710AF File Offset: 0x0066F4AF
		public Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node2()
		{
			this.opl_p0 = 0.35f;
		}

		// Token: 0x060155A3 RID: 87459 RVA: 0x006710C4 File Offset: 0x0066F4C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF76 RID: 61302
		private float opl_p0;
	}
}
