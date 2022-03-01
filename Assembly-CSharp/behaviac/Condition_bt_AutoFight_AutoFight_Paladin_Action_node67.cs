using System;

namespace behaviac
{
	// Token: 0x02002794 RID: 10132
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node67 : Condition
	{
		// Token: 0x06013868 RID: 79976 RVA: 0x005D25D9 File Offset: 0x005D09D9
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node67()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x06013869 RID: 79977 RVA: 0x005D25EC File Offset: 0x005D09EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2C9 RID: 53961
		private float opl_p0;
	}
}
