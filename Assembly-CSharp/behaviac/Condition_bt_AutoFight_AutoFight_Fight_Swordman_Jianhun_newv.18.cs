using System;

namespace behaviac
{
	// Token: 0x020022C5 RID: 8901
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node35 : Condition
	{
		// Token: 0x06012F05 RID: 77573 RVA: 0x005971A7 File Offset: 0x005955A7
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node35()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x06012F06 RID: 77574 RVA: 0x005971BC File Offset: 0x005955BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C918 RID: 51480
		private int opl_p0;
	}
}
