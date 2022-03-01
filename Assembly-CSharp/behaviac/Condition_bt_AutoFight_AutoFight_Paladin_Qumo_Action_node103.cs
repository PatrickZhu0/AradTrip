using System;

namespace behaviac
{
	// Token: 0x02002801 RID: 10241
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node103 : Condition
	{
		// Token: 0x06013941 RID: 80193 RVA: 0x005D6163 File Offset: 0x005D4563
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node103()
		{
			this.opl_p0 = 3509;
		}

		// Token: 0x06013942 RID: 80194 RVA: 0x005D6178 File Offset: 0x005D4578
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3A0 RID: 54176
		private int opl_p0;
	}
}
