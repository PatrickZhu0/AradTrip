using System;

namespace behaviac
{
	// Token: 0x02002886 RID: 10374
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node33 : Condition
	{
		// Token: 0x06013A49 RID: 80457 RVA: 0x005DD0DD File Offset: 0x005DB4DD
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node33()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x06013A4A RID: 80458 RVA: 0x005DD0F0 File Offset: 0x005DB4F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4A3 RID: 54435
		private int opl_p0;
	}
}
