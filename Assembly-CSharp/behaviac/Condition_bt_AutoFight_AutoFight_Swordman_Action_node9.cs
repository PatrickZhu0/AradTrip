using System;

namespace behaviac
{
	// Token: 0x0200287E RID: 10366
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node9 : Condition
	{
		// Token: 0x06013A39 RID: 80441 RVA: 0x005DCD79 File Offset: 0x005DB179
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node9()
		{
			this.opl_p0 = 1808;
		}

		// Token: 0x06013A3A RID: 80442 RVA: 0x005DCD8C File Offset: 0x005DB18C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D493 RID: 54419
		private int opl_p0;
	}
}
