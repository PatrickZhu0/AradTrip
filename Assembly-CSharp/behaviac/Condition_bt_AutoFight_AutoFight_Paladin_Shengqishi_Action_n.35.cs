using System;

namespace behaviac
{
	// Token: 0x02002840 RID: 10304
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node29 : Condition
	{
		// Token: 0x060139BE RID: 80318 RVA: 0x005D9801 File Offset: 0x005D7C01
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node29()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060139BF RID: 80319 RVA: 0x005D9814 File Offset: 0x005D7C14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D418 RID: 54296
		private float opl_p0;
	}
}
