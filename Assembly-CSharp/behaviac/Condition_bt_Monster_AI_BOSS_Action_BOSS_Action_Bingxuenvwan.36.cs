using System;

namespace behaviac
{
	// Token: 0x02002F9A RID: 12186
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node46 : Condition
	{
		// Token: 0x06014802 RID: 83970 RVA: 0x0062AE77 File Offset: 0x00629277
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node46()
		{
			this.opl_p0 = 5547;
		}

		// Token: 0x06014803 RID: 83971 RVA: 0x0062AE8C File Offset: 0x0062928C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E165 RID: 57701
		private int opl_p0;
	}
}
