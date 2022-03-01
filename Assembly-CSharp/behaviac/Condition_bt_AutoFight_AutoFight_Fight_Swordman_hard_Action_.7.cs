using System;

namespace behaviac
{
	// Token: 0x0200229F RID: 8863
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node15 : Condition
	{
		// Token: 0x06012EBB RID: 77499 RVA: 0x00595127 File Offset: 0x00593527
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node15()
		{
			this.opl_p0 = 1505;
		}

		// Token: 0x06012EBC RID: 77500 RVA: 0x0059513C File Offset: 0x0059353C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8C6 RID: 51398
		private int opl_p0;
	}
}
