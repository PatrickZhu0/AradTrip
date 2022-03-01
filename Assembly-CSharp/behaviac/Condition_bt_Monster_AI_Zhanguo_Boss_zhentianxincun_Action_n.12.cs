using System;

namespace behaviac
{
	// Token: 0x02003ECC RID: 16076
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node19 : Condition
	{
		// Token: 0x06016515 RID: 91413 RVA: 0x006C0195 File Offset: 0x006BE595
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node19()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06016516 RID: 91414 RVA: 0x006C01A8 File Offset: 0x006BE5A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD4B RID: 64843
		private float opl_p0;
	}
}
