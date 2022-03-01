using System;

namespace behaviac
{
	// Token: 0x020028EE RID: 10478
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node44 : Condition
	{
		// Token: 0x06013B13 RID: 80659 RVA: 0x005E2401 File Offset: 0x005E0801
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node44()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013B14 RID: 80660 RVA: 0x005E2414 File Offset: 0x005E0814
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D577 RID: 54647
		private float opl_p0;
	}
}
