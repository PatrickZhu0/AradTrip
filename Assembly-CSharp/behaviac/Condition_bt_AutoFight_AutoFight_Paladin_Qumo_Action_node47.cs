using System;

namespace behaviac
{
	// Token: 0x020027E8 RID: 10216
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node47 : Condition
	{
		// Token: 0x0601390F RID: 80143 RVA: 0x005D56E5 File Offset: 0x005D3AE5
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node47()
		{
			this.opl_p0 = 0.05f;
		}

		// Token: 0x06013910 RID: 80144 RVA: 0x005D56F8 File Offset: 0x005D3AF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D36F RID: 54127
		private float opl_p0;
	}
}
