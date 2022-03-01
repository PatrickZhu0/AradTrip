using System;

namespace behaviac
{
	// Token: 0x020027FC RID: 10236
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node92 : Condition
	{
		// Token: 0x06013937 RID: 80183 RVA: 0x005D5F69 File Offset: 0x005D4369
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node92()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013938 RID: 80184 RVA: 0x005D5F7C File Offset: 0x005D437C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D397 RID: 54167
		private float opl_p0;
	}
}
