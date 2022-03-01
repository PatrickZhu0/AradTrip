using System;

namespace behaviac
{
	// Token: 0x0200403E RID: 16446
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node15 : Condition
	{
		// Token: 0x060167DB RID: 92123 RVA: 0x006CEBDA File Offset: 0x006CCFDA
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node15()
		{
			this.opl_p0 = 0.35f;
		}

		// Token: 0x060167DC RID: 92124 RVA: 0x006CEBF0 File Offset: 0x006CCFF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010026 RID: 65574
		private float opl_p0;
	}
}
