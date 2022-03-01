using System;

namespace behaviac
{
	// Token: 0x02001E02 RID: 7682
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Swordman_test_Action_node17 : Condition
	{
		// Token: 0x060125B7 RID: 75191 RVA: 0x0055C866 File Offset: 0x0055AC66
		public Condition_bt_APC_APC_Swordman_test_Action_node17()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x060125B8 RID: 75192 RVA: 0x0055C87C File Offset: 0x0055AC7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFA5 RID: 49061
		private int opl_p0;
	}
}
