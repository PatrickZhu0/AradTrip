using System;

namespace behaviac
{
	// Token: 0x0200407E RID: 16510
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node17 : Condition
	{
		// Token: 0x06016859 RID: 92249 RVA: 0x006D1896 File Offset: 0x006CFC96
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node17()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601685A RID: 92250 RVA: 0x006D18AC File Offset: 0x006CFCAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100A3 RID: 65699
		private float opl_p0;
	}
}
