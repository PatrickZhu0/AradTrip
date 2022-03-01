using System;

namespace behaviac
{
	// Token: 0x02003EC8 RID: 16072
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node14 : Condition
	{
		// Token: 0x0601650D RID: 91405 RVA: 0x006BFFE1 File Offset: 0x006BE3E1
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node14()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601650E RID: 91406 RVA: 0x006BFFF4 File Offset: 0x006BE3F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD43 RID: 64835
		private float opl_p0;
	}
}
