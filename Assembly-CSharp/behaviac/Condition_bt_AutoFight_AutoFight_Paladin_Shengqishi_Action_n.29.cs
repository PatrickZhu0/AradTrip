using System;

namespace behaviac
{
	// Token: 0x02002838 RID: 10296
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node39 : Condition
	{
		// Token: 0x060139AE RID: 80302 RVA: 0x005D9499 File Offset: 0x005D7899
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node39()
		{
			this.opl_p0 = 0.55f;
		}

		// Token: 0x060139AF RID: 80303 RVA: 0x005D94AC File Offset: 0x005D78AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D408 RID: 54280
		private float opl_p0;
	}
}
