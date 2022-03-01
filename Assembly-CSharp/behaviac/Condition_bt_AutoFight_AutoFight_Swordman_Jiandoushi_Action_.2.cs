using System;

namespace behaviac
{
	// Token: 0x020028E3 RID: 10467
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node7 : Condition
	{
		// Token: 0x06013AFE RID: 80638 RVA: 0x005E1F7B File Offset: 0x005E037B
		public Condition_bt_AutoFight_AutoFight_Swordman_Jiandoushi_Action_node7()
		{
			this.opl_p0 = 4014;
		}

		// Token: 0x06013AFF RID: 80639 RVA: 0x005E1F90 File Offset: 0x005E0390
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D562 RID: 54626
		private int opl_p0;
	}
}
