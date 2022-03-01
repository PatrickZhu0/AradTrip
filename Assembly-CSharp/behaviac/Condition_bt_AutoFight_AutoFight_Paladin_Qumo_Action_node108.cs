using System;

namespace behaviac
{
	// Token: 0x02002805 RID: 10245
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node108 : Condition
	{
		// Token: 0x06013949 RID: 80201 RVA: 0x005D6317 File Offset: 0x005D4717
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node108()
		{
			this.opl_p0 = 3511;
		}

		// Token: 0x0601394A RID: 80202 RVA: 0x005D632C File Offset: 0x005D472C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3A8 RID: 54184
		private int opl_p0;
	}
}
