using System;

namespace behaviac
{
	// Token: 0x02002C31 RID: 11313
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Action_node4 : Condition
	{
		// Token: 0x06014160 RID: 82272 RVA: 0x006081E1 File Offset: 0x006065E1
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Action_node4()
		{
			this.opl_p0 = 20777;
		}

		// Token: 0x06014161 RID: 82273 RVA: 0x006081F4 File Offset: 0x006065F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB28 RID: 56104
		private int opl_p0;
	}
}
