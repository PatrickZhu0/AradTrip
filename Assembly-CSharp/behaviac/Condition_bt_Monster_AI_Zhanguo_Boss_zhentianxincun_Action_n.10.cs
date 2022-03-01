using System;

namespace behaviac
{
	// Token: 0x02003EC9 RID: 16073
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node0 : Condition
	{
		// Token: 0x0601650F RID: 91407 RVA: 0x006C0027 File Offset: 0x006BE427
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node0()
		{
			this.opl_p0 = 7296;
		}

		// Token: 0x06016510 RID: 91408 RVA: 0x006C003C File Offset: 0x006BE43C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD44 RID: 64836
		private int opl_p0;
	}
}
