using System;

namespace behaviac
{
	// Token: 0x0200234A RID: 9034
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node34 : Condition
	{
		// Token: 0x06013001 RID: 77825 RVA: 0x0059E82F File Offset: 0x0059CC2F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node34()
		{
			this.opl_p0 = 1608;
		}

		// Token: 0x06013002 RID: 77826 RVA: 0x0059E844 File Offset: 0x0059CC44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA17 RID: 51735
		private int opl_p0;
	}
}
