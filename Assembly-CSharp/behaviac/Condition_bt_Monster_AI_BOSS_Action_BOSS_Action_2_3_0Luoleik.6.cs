using System;

namespace behaviac
{
	// Token: 0x02002F58 RID: 12120
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node11 : Condition
	{
		// Token: 0x0601477F RID: 83839 RVA: 0x00628B8F File Offset: 0x00626F8F
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node11()
		{
			this.opl_p0 = 5313;
		}

		// Token: 0x06014780 RID: 83840 RVA: 0x00628BA4 File Offset: 0x00626FA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0EE RID: 57582
		private int opl_p0;
	}
}
