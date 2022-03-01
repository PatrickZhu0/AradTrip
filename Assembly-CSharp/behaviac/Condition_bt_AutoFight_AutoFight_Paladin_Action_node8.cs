using System;

namespace behaviac
{
	// Token: 0x0200278C RID: 10124
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node8 : Condition
	{
		// Token: 0x06013858 RID: 79960 RVA: 0x005D2271 File Offset: 0x005D0671
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node8()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06013859 RID: 79961 RVA: 0x005D2284 File Offset: 0x005D0684
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2B9 RID: 53945
		private float opl_p0;
	}
}
