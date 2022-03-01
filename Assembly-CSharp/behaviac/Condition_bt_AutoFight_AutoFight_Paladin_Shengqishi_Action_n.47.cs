using System;

namespace behaviac
{
	// Token: 0x02002850 RID: 10320
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node87 : Condition
	{
		// Token: 0x060139DE RID: 80350 RVA: 0x005D9ED1 File Offset: 0x005D82D1
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node87()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060139DF RID: 80351 RVA: 0x005D9EE4 File Offset: 0x005D82E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D438 RID: 54328
		private float opl_p0;
	}
}
