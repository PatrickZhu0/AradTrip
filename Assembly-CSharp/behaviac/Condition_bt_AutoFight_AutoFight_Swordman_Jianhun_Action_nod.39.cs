using System;

namespace behaviac
{
	// Token: 0x02002938 RID: 10552
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node50 : Condition
	{
		// Token: 0x06013BA6 RID: 80806 RVA: 0x005E5293 File Offset: 0x005E3693
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node50()
		{
			this.opl_p0 = 1913;
		}

		// Token: 0x06013BA7 RID: 80807 RVA: 0x005E52A8 File Offset: 0x005E36A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D60C RID: 54796
		private int opl_p0;
	}
}
