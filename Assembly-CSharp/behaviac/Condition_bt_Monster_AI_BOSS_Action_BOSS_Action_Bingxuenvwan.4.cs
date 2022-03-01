using System;

namespace behaviac
{
	// Token: 0x02002F72 RID: 12146
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node5 : Condition
	{
		// Token: 0x060147B2 RID: 83890 RVA: 0x00629EAF File Offset: 0x006282AF
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node5()
		{
			this.opl_p0 = 5543;
		}

		// Token: 0x060147B3 RID: 83891 RVA: 0x00629EC4 File Offset: 0x006282C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E11E RID: 57630
		private int opl_p0;
	}
}
