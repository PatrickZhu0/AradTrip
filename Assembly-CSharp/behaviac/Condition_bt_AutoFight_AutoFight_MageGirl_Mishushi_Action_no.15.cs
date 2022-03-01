using System;

namespace behaviac
{
	// Token: 0x020026C2 RID: 9922
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node60 : Condition
	{
		// Token: 0x060136C7 RID: 79559 RVA: 0x005C8E01 File Offset: 0x005C7201
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node60()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060136C8 RID: 79560 RVA: 0x005C8E14 File Offset: 0x005C7214
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D11F RID: 53535
		private float opl_p0;
	}
}
