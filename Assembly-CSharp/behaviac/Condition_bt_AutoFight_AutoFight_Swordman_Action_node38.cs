using System;

namespace behaviac
{
	// Token: 0x0200288A RID: 10378
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node38 : Condition
	{
		// Token: 0x06013A51 RID: 80465 RVA: 0x005DD2E9 File Offset: 0x005DB6E9
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node38()
		{
			this.opl_p0 = 1510;
		}

		// Token: 0x06013A52 RID: 80466 RVA: 0x005DD2FC File Offset: 0x005DB6FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4AB RID: 54443
		private int opl_p0;
	}
}
