using System;

namespace behaviac
{
	// Token: 0x02003EC0 RID: 16064
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node6 : Condition
	{
		// Token: 0x060164FD RID: 91389 RVA: 0x006BFC78 File Offset: 0x006BE078
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node6()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060164FE RID: 91390 RVA: 0x006BFC8C File Offset: 0x006BE08C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD33 RID: 64819
		private float opl_p0;
	}
}
