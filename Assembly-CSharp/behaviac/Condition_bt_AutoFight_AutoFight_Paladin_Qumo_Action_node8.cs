using System;

namespace behaviac
{
	// Token: 0x020027B8 RID: 10168
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node8 : Condition
	{
		// Token: 0x060138AF RID: 80047 RVA: 0x005D4275 File Offset: 0x005D2675
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node8()
		{
			this.opl_p0 = 0.35f;
		}

		// Token: 0x060138B0 RID: 80048 RVA: 0x005D4288 File Offset: 0x005D2688
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D30F RID: 54031
		private float opl_p0;
	}
}
