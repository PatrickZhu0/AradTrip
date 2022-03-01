using System;

namespace behaviac
{
	// Token: 0x02002798 RID: 10136
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node13 : Condition
	{
		// Token: 0x06013870 RID: 79984 RVA: 0x005D278D File Offset: 0x005D0B8D
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node13()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013871 RID: 79985 RVA: 0x005D27A0 File Offset: 0x005D0BA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2D1 RID: 53969
		private float opl_p0;
	}
}
