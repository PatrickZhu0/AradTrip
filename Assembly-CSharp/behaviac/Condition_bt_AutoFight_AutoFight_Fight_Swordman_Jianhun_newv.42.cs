using System;

namespace behaviac
{
	// Token: 0x020022E7 RID: 8935
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Event_node11 : Condition
	{
		// Token: 0x06012F48 RID: 77640 RVA: 0x00599E2B File Offset: 0x0059822B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Event_node11()
		{
			this.opl_p0 = 10001;
		}

		// Token: 0x06012F49 RID: 77641 RVA: 0x00599E40 File Offset: 0x00598240
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C959 RID: 51545
		private int opl_p0;
	}
}
