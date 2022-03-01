using System;

namespace behaviac
{
	// Token: 0x02002800 RID: 10240
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node102 : Condition
	{
		// Token: 0x0601393F RID: 80191 RVA: 0x005D611D File Offset: 0x005D451D
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node102()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013940 RID: 80192 RVA: 0x005D6130 File Offset: 0x005D4530
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D39F RID: 54175
		private float opl_p0;
	}
}
