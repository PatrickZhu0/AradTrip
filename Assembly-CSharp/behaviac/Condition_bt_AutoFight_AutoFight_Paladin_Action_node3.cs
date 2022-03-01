using System;

namespace behaviac
{
	// Token: 0x02002788 RID: 10120
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node3 : Condition
	{
		// Token: 0x06013850 RID: 79952 RVA: 0x005D20BB File Offset: 0x005D04BB
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node3()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013851 RID: 79953 RVA: 0x005D20D0 File Offset: 0x005D04D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2B1 RID: 53937
		private float opl_p0;
	}
}
