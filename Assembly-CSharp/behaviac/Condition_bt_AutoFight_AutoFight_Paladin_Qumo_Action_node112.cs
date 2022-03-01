using System;

namespace behaviac
{
	// Token: 0x0200280C RID: 10252
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node112 : Condition
	{
		// Token: 0x06013957 RID: 80215 RVA: 0x005D6639 File Offset: 0x005D4A39
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node112()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x06013958 RID: 80216 RVA: 0x005D664C File Offset: 0x005D4A4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3B7 RID: 54199
		private float opl_p0;
	}
}
