using System;

namespace behaviac
{
	// Token: 0x020022D9 RID: 8921
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node19 : Condition
	{
		// Token: 0x06012F2D RID: 77613 RVA: 0x005985E9 File Offset: 0x005969E9
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node19()
		{
			this.opl_p0 = 1506;
		}

		// Token: 0x06012F2E RID: 77614 RVA: 0x005985FC File Offset: 0x005969FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C944 RID: 51524
		private int opl_p0;
	}
}
