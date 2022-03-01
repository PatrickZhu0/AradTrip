using System;

namespace behaviac
{
	// Token: 0x02004022 RID: 16418
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node6 : Condition
	{
		// Token: 0x060167A5 RID: 92069 RVA: 0x006CDB0F File Offset: 0x006CBF0F
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node6()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060167A6 RID: 92070 RVA: 0x006CDB24 File Offset: 0x006CBF24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFF2 RID: 65522
		private float opl_p0;
	}
}
