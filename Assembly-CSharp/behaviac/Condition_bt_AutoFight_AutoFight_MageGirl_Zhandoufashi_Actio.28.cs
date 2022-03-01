using System;

namespace behaviac
{
	// Token: 0x02002725 RID: 10021
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node54 : Condition
	{
		// Token: 0x0601378C RID: 79756 RVA: 0x005CCF35 File Offset: 0x005CB335
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node54()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601378D RID: 79757 RVA: 0x005CCF48 File Offset: 0x005CB348
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1E7 RID: 53735
		private float opl_p0;
	}
}
