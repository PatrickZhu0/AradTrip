using System;

namespace behaviac
{
	// Token: 0x02002854 RID: 10324
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node92 : Condition
	{
		// Token: 0x060139E6 RID: 80358 RVA: 0x005DA085 File Offset: 0x005D8485
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node92()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060139E7 RID: 80359 RVA: 0x005DA098 File Offset: 0x005D8498
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D440 RID: 54336
		private float opl_p0;
	}
}
