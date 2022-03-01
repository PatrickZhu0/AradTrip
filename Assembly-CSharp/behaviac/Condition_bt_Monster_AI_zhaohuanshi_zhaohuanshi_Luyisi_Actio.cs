using System;

namespace behaviac
{
	// Token: 0x02003FCD RID: 16333
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node8 : Condition
	{
		// Token: 0x06016702 RID: 91906 RVA: 0x006CA353 File Offset: 0x006C8753
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node8()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06016703 RID: 91907 RVA: 0x006CA368 File Offset: 0x006C8768
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF54 RID: 65364
		private float opl_p0;
	}
}
