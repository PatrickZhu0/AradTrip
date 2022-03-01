using System;

namespace behaviac
{
	// Token: 0x020023DD RID: 9181
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node7 : Condition
	{
		// Token: 0x0601311D RID: 78109 RVA: 0x005A751B File Offset: 0x005A591B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node7()
		{
			this.opl_p0 = 1609;
		}

		// Token: 0x0601311E RID: 78110 RVA: 0x005A7530 File Offset: 0x005A5930
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB4A RID: 52042
		private int opl_p0;
	}
}
