using System;

namespace behaviac
{
	// Token: 0x0200284C RID: 10316
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node82 : Condition
	{
		// Token: 0x060139D6 RID: 80342 RVA: 0x005D9D1D File Offset: 0x005D811D
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node82()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060139D7 RID: 80343 RVA: 0x005D9D30 File Offset: 0x005D8130
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D430 RID: 54320
		private float opl_p0;
	}
}
