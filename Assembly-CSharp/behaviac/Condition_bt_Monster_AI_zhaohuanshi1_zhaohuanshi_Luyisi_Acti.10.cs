using System;

namespace behaviac
{
	// Token: 0x02004082 RID: 16514
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node6 : Condition
	{
		// Token: 0x06016861 RID: 92257 RVA: 0x006D1A4A File Offset: 0x006CFE4A
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node6()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06016862 RID: 92258 RVA: 0x006D1A60 File Offset: 0x006CFE60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100AB RID: 65707
		private float opl_p0;
	}
}
