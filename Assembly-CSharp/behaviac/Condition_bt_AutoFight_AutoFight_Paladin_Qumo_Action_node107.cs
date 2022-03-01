using System;

namespace behaviac
{
	// Token: 0x02002804 RID: 10244
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node107 : Condition
	{
		// Token: 0x06013947 RID: 80199 RVA: 0x005D62D1 File Offset: 0x005D46D1
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node107()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013948 RID: 80200 RVA: 0x005D62E4 File Offset: 0x005D46E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3A7 RID: 54183
		private float opl_p0;
	}
}
