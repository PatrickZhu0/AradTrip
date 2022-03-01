using System;

namespace behaviac
{
	// Token: 0x0200283C RID: 10300
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node14 : Condition
	{
		// Token: 0x060139B6 RID: 80310 RVA: 0x005D964D File Offset: 0x005D7A4D
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node14()
		{
			this.opl_p0 = 0.55f;
		}

		// Token: 0x060139B7 RID: 80311 RVA: 0x005D9660 File Offset: 0x005D7A60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D410 RID: 54288
		private float opl_p0;
	}
}
