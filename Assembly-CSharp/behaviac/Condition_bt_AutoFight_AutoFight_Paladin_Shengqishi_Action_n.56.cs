using System;

namespace behaviac
{
	// Token: 0x0200285C RID: 10332
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node107 : Condition
	{
		// Token: 0x060139F6 RID: 80374 RVA: 0x005DA3ED File Offset: 0x005D87ED
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node107()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060139F7 RID: 80375 RVA: 0x005DA400 File Offset: 0x005D8800
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D450 RID: 54352
		private float opl_p0;
	}
}
