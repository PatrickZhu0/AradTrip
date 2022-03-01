using System;

namespace behaviac
{
	// Token: 0x02004024 RID: 16420
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node8 : Condition
	{
		// Token: 0x060167A9 RID: 92073 RVA: 0x006CDBD1 File Offset: 0x006CBFD1
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node8()
		{
			this.opl_p0 = 5354;
		}

		// Token: 0x060167AA RID: 92074 RVA: 0x006CDBE4 File Offset: 0x006CBFE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFF7 RID: 65527
		private int opl_p0;
	}
}
