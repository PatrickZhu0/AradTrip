using System;

namespace behaviac
{
	// Token: 0x0200296F RID: 10607
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node50 : Condition
	{
		// Token: 0x06013C13 RID: 80915 RVA: 0x005E7D75 File Offset: 0x005E6175
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node50()
		{
			this.opl_p0 = 1607;
		}

		// Token: 0x06013C14 RID: 80916 RVA: 0x005E7D88 File Offset: 0x005E6188
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D679 RID: 54905
		private int opl_p0;
	}
}
