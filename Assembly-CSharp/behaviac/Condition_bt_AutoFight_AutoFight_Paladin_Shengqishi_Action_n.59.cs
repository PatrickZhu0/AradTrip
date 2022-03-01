using System;

namespace behaviac
{
	// Token: 0x02002860 RID: 10336
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node97 : Condition
	{
		// Token: 0x060139FE RID: 80382 RVA: 0x005DA5A1 File Offset: 0x005D89A1
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node97()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060139FF RID: 80383 RVA: 0x005DA5B4 File Offset: 0x005D89B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D458 RID: 54360
		private float opl_p0;
	}
}
