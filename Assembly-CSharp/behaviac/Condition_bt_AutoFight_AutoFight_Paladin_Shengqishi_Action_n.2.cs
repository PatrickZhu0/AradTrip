using System;

namespace behaviac
{
	// Token: 0x02002814 RID: 10260
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node47 : Condition
	{
		// Token: 0x06013966 RID: 80230 RVA: 0x005D85BB File Offset: 0x005D69BB
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node47()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013967 RID: 80231 RVA: 0x005D85D0 File Offset: 0x005D69D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3C5 RID: 54213
		private float opl_p0;
	}
}
