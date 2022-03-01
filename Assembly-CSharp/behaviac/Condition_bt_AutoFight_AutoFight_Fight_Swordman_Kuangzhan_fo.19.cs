using System;

namespace behaviac
{
	// Token: 0x0200234F RID: 9039
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node40 : Condition
	{
		// Token: 0x0601300B RID: 77835 RVA: 0x0059EA43 File Offset: 0x0059CE43
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node40()
		{
			this.opl_p0 = 1512;
		}

		// Token: 0x0601300C RID: 77836 RVA: 0x0059EA58 File Offset: 0x0059CE58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA22 RID: 51746
		private int opl_p0;
	}
}
