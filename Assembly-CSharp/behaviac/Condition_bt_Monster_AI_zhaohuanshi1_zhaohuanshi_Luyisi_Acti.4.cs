using System;

namespace behaviac
{
	// Token: 0x0200407A RID: 16506
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node12 : Condition
	{
		// Token: 0x06016851 RID: 92241 RVA: 0x006D16E2 File Offset: 0x006CFAE2
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node12()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06016852 RID: 92242 RVA: 0x006D16F8 File Offset: 0x006CFAF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401009B RID: 65691
		private float opl_p0;
	}
}
