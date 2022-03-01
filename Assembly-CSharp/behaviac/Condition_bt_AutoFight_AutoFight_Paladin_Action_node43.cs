using System;

namespace behaviac
{
	// Token: 0x020027B0 RID: 10160
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node43 : Condition
	{
		// Token: 0x060138A0 RID: 80032 RVA: 0x005D3221 File Offset: 0x005D1621
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node43()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060138A1 RID: 80033 RVA: 0x005D3234 File Offset: 0x005D1634
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D301 RID: 54017
		private float opl_p0;
	}
}
