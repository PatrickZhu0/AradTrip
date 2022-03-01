using System;

namespace behaviac
{
	// Token: 0x020040AB RID: 16555
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node22 : Condition
	{
		// Token: 0x060168AF RID: 92335 RVA: 0x006D377A File Offset: 0x006D1B7A
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node22()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060168B0 RID: 92336 RVA: 0x006D3790 File Offset: 0x006D1B90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100F6 RID: 65782
		private float opl_p0;
	}
}
