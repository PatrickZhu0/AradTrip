using System;

namespace behaviac
{
	// Token: 0x02003FD1 RID: 16337
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node12 : Condition
	{
		// Token: 0x0601670A RID: 91914 RVA: 0x006CA506 File Offset: 0x006C8906
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node12()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601670B RID: 91915 RVA: 0x006CA51C File Offset: 0x006C891C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF5C RID: 65372
		private float opl_p0;
	}
}
