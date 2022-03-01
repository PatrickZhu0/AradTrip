using System;

namespace behaviac
{
	// Token: 0x02003EC4 RID: 16068
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node10 : Condition
	{
		// Token: 0x06016505 RID: 91397 RVA: 0x006BFE2D File Offset: 0x006BE22D
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node10()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x06016506 RID: 91398 RVA: 0x006BFE40 File Offset: 0x006BE240
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD3B RID: 64827
		private float opl_p0;
	}
}
