using System;

namespace behaviac
{
	// Token: 0x020027D4 RID: 10196
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node38 : Condition
	{
		// Token: 0x060138E7 RID: 80103 RVA: 0x005D4E61 File Offset: 0x005D3261
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node38()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x060138E8 RID: 80104 RVA: 0x005D4E74 File Offset: 0x005D3274
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D347 RID: 54087
		private float opl_p0;
	}
}
