using System;

namespace behaviac
{
	// Token: 0x02002808 RID: 10248
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node97 : Condition
	{
		// Token: 0x0601394F RID: 80207 RVA: 0x005D6485 File Offset: 0x005D4885
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node97()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013950 RID: 80208 RVA: 0x005D6498 File Offset: 0x005D4898
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3AF RID: 54191
		private float opl_p0;
	}
}
