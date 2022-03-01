using System;

namespace behaviac
{
	// Token: 0x020026F7 RID: 9975
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node22 : Condition
	{
		// Token: 0x06013731 RID: 79665 RVA: 0x005CA45D File Offset: 0x005C885D
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node22()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013732 RID: 79666 RVA: 0x005CA470 File Offset: 0x005C8870
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D189 RID: 53641
		private float opl_p0;
	}
}
