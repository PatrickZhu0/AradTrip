using System;

namespace behaviac
{
	// Token: 0x02002799 RID: 10137
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node14 : Condition
	{
		// Token: 0x06013872 RID: 79986 RVA: 0x005D27D3 File Offset: 0x005D0BD3
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node14()
		{
			this.opl_p0 = 3504;
		}

		// Token: 0x06013873 RID: 79987 RVA: 0x005D27E8 File Offset: 0x005D0BE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2D2 RID: 53970
		private int opl_p0;
	}
}
