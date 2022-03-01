using System;

namespace behaviac
{
	// Token: 0x02003EC5 RID: 16069
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node11 : Condition
	{
		// Token: 0x06016507 RID: 91399 RVA: 0x006BFE73 File Offset: 0x006BE273
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node11()
		{
			this.opl_p0 = 7295;
		}

		// Token: 0x06016508 RID: 91400 RVA: 0x006BFE88 File Offset: 0x006BE288
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD3C RID: 64828
		private int opl_p0;
	}
}
