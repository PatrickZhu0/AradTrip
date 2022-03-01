using System;

namespace behaviac
{
	// Token: 0x02002790 RID: 10128
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node47 : Condition
	{
		// Token: 0x06013860 RID: 79968 RVA: 0x005D2425 File Offset: 0x005D0825
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node47()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x06013861 RID: 79969 RVA: 0x005D2438 File Offset: 0x005D0838
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2C1 RID: 53953
		private float opl_p0;
	}
}
