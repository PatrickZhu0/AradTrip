using System;

namespace behaviac
{
	// Token: 0x0200407C RID: 16508
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node14 : Condition
	{
		// Token: 0x06016855 RID: 92245 RVA: 0x006D17A5 File Offset: 0x006CFBA5
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node14()
		{
			this.opl_p0 = 5023;
		}

		// Token: 0x06016856 RID: 92246 RVA: 0x006D17B8 File Offset: 0x006CFBB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100A0 RID: 65696
		private int opl_p0;
	}
}
