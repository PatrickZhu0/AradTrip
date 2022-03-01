using System;

namespace behaviac
{
	// Token: 0x02003FF2 RID: 16370
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node14 : Condition
	{
		// Token: 0x0601674A RID: 91978 RVA: 0x006CB9EE File Offset: 0x006C9DEE
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node14()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601674B RID: 91979 RVA: 0x006CBA04 File Offset: 0x006C9E04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF9B RID: 65435
		private float opl_p0;
	}
}
