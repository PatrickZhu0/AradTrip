using System;

namespace behaviac
{
	// Token: 0x02002F71 RID: 12145
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node63 : Condition
	{
		// Token: 0x060147B0 RID: 83888 RVA: 0x00629E67 File Offset: 0x00628267
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node63()
		{
			this.opl_p0 = 5543;
		}

		// Token: 0x060147B1 RID: 83889 RVA: 0x00629E7C File Offset: 0x0062827C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E11D RID: 57629
		private int opl_p0;
	}
}
