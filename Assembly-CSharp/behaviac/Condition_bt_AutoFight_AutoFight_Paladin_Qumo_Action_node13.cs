using System;

namespace behaviac
{
	// Token: 0x020027BC RID: 10172
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node13 : Condition
	{
		// Token: 0x060138B7 RID: 80055 RVA: 0x005D4429 File Offset: 0x005D2829
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node13()
		{
			this.opl_p0 = 0.35f;
		}

		// Token: 0x060138B8 RID: 80056 RVA: 0x005D443C File Offset: 0x005D283C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D317 RID: 54039
		private float opl_p0;
	}
}
