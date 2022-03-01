using System;

namespace behaviac
{
	// Token: 0x020027F4 RID: 10228
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node82 : Condition
	{
		// Token: 0x06013927 RID: 80167 RVA: 0x005D5C01 File Offset: 0x005D4001
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node82()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06013928 RID: 80168 RVA: 0x005D5C14 File Offset: 0x005D4014
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D387 RID: 54151
		private float opl_p0;
	}
}
