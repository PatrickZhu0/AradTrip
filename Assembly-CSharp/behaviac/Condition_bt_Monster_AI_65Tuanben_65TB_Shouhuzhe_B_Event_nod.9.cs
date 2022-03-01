using System;

namespace behaviac
{
	// Token: 0x02002C72 RID: 11378
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node17 : Condition
	{
		// Token: 0x060141DD RID: 82397 RVA: 0x0060A867 File Offset: 0x00608C67
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node17()
		{
			this.opl_p0 = 20781;
		}

		// Token: 0x060141DE RID: 82398 RVA: 0x0060A87C File Offset: 0x00608C7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBA0 RID: 56224
		private int opl_p0;
	}
}
