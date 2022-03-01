using System;

namespace behaviac
{
	// Token: 0x02003626 RID: 13862
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node14 : Condition
	{
		// Token: 0x06015470 RID: 87152 RVA: 0x0066A2BB File Offset: 0x006686BB
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node14()
		{
			this.opl_p0 = 5429;
		}

		// Token: 0x06015471 RID: 87153 RVA: 0x0066A2D0 File Offset: 0x006686D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE2A RID: 60970
		private int opl_p0;
	}
}
