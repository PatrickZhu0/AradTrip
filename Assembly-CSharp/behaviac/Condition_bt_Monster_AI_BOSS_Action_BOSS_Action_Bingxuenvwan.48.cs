using System;

namespace behaviac
{
	// Token: 0x02002FA9 RID: 12201
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node61 : Condition
	{
		// Token: 0x06014820 RID: 84000 RVA: 0x0062B46B File Offset: 0x0062986B
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node61()
		{
			this.opl_p0 = 5531;
		}

		// Token: 0x06014821 RID: 84001 RVA: 0x0062B480 File Offset: 0x00629880
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E180 RID: 57728
		private int opl_p0;
	}
}
