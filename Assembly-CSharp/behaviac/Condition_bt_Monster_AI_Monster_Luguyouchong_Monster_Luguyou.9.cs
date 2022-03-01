using System;

namespace behaviac
{
	// Token: 0x020036D2 RID: 14034
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongxiao_node7 : Condition
	{
		// Token: 0x060155BB RID: 87483 RVA: 0x0067187D File Offset: 0x0066FC7D
		public Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongxiao_node7()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060155BC RID: 87484 RVA: 0x00671890 File Offset: 0x0066FC90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF8F RID: 61327
		private float opl_p0;
	}
}
