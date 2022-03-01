using System;

namespace behaviac
{
	// Token: 0x02002789 RID: 10121
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node4 : Condition
	{
		// Token: 0x06013852 RID: 79954 RVA: 0x005D2103 File Offset: 0x005D0503
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node4()
		{
			this.opl_p0 = 3508;
		}

		// Token: 0x06013853 RID: 79955 RVA: 0x005D2118 File Offset: 0x005D0518
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2B2 RID: 53938
		private int opl_p0;
	}
}
