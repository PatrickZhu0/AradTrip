using System;

namespace behaviac
{
	// Token: 0x0200402C RID: 16428
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node16 : Condition
	{
		// Token: 0x060167B9 RID: 92089 RVA: 0x006CDF39 File Offset: 0x006CC339
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node16()
		{
			this.opl_p0 = 5355;
		}

		// Token: 0x060167BA RID: 92090 RVA: 0x006CDF4C File Offset: 0x006CC34C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010007 RID: 65543
		private int opl_p0;
	}
}
