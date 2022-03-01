using System;

namespace behaviac
{
	// Token: 0x020022E3 RID: 8931
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Event_node6 : Condition
	{
		// Token: 0x06012F40 RID: 77632 RVA: 0x00599C93 File Offset: 0x00598093
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Event_node6()
		{
			this.opl_p0 = 1515;
		}

		// Token: 0x06012F41 RID: 77633 RVA: 0x00599CA8 File Offset: 0x005980A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C952 RID: 51538
		private int opl_p0;
	}
}
