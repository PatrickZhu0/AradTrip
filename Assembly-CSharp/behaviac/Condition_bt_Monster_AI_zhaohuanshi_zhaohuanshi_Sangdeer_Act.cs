using System;

namespace behaviac
{
	// Token: 0x02003FEA RID: 16362
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node4 : Condition
	{
		// Token: 0x0601673A RID: 91962 RVA: 0x006CB686 File Offset: 0x006C9A86
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node4()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601673B RID: 91963 RVA: 0x006CB69C File Offset: 0x006C9A9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF8B RID: 65419
		private float opl_p0;
	}
}
