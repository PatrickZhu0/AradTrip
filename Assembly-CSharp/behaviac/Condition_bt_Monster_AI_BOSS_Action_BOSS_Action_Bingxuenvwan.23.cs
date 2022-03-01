using System;

namespace behaviac
{
	// Token: 0x02002F8A RID: 12170
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node67 : Condition
	{
		// Token: 0x060147E2 RID: 83938 RVA: 0x0062A83B File Offset: 0x00628C3B
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node67()
		{
			this.opl_p0 = 5545;
		}

		// Token: 0x060147E3 RID: 83939 RVA: 0x0062A850 File Offset: 0x00628C50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E149 RID: 57673
		private int opl_p0;
	}
}
