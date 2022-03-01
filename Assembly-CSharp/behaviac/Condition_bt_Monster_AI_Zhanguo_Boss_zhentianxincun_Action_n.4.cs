using System;

namespace behaviac
{
	// Token: 0x02003EC1 RID: 16065
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node4 : Condition
	{
		// Token: 0x060164FF RID: 91391 RVA: 0x006BFCBF File Offset: 0x006BE0BF
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node4()
		{
			this.opl_p0 = 7294;
		}

		// Token: 0x06016500 RID: 91392 RVA: 0x006BFCD4 File Offset: 0x006BE0D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD34 RID: 64820
		private int opl_p0;
	}
}
