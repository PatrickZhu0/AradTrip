using System;

namespace behaviac
{
	// Token: 0x020036CE RID: 14030
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongxiao_node2 : Condition
	{
		// Token: 0x060155B3 RID: 87475 RVA: 0x006716C7 File Offset: 0x0066FAC7
		public Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongxiao_node2()
		{
			this.opl_p0 = 0.35f;
		}

		// Token: 0x060155B4 RID: 87476 RVA: 0x006716DC File Offset: 0x0066FADC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF87 RID: 61319
		private float opl_p0;
	}
}
