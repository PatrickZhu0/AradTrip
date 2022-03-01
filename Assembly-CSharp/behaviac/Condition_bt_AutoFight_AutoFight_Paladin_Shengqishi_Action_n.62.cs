using System;

namespace behaviac
{
	// Token: 0x02002864 RID: 10340
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node112 : Condition
	{
		// Token: 0x06013A06 RID: 80390 RVA: 0x005DA755 File Offset: 0x005D8B55
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node112()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x06013A07 RID: 80391 RVA: 0x005DA768 File Offset: 0x005D8B68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D460 RID: 54368
		private float opl_p0;
	}
}
