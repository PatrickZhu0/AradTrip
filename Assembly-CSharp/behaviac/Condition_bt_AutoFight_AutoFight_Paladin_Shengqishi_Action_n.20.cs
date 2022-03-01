using System;

namespace behaviac
{
	// Token: 0x0200282C RID: 10284
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node19 : Condition
	{
		// Token: 0x06013996 RID: 80278 RVA: 0x005D8F7D File Offset: 0x005D737D
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node19()
		{
			this.opl_p0 = 0.65f;
		}

		// Token: 0x06013997 RID: 80279 RVA: 0x005D8F90 File Offset: 0x005D7390
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3F0 RID: 54256
		private float opl_p0;
	}
}
