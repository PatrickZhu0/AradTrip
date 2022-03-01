using System;

namespace behaviac
{
	// Token: 0x020027A4 RID: 10148
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node28 : Condition
	{
		// Token: 0x06013888 RID: 80008 RVA: 0x005D2CA9 File Offset: 0x005D10A9
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node28()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013889 RID: 80009 RVA: 0x005D2CBC File Offset: 0x005D10BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2E9 RID: 53993
		private float opl_p0;
	}
}
