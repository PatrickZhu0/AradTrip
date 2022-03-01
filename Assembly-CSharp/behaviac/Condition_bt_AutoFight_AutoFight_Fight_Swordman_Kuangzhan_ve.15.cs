using System;

namespace behaviac
{
	// Token: 0x02002422 RID: 9250
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node34 : Condition
	{
		// Token: 0x0601319D RID: 78237 RVA: 0x005AA0B7 File Offset: 0x005A84B7
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node34()
		{
			this.opl_p0 = 1608;
		}

		// Token: 0x0601319E RID: 78238 RVA: 0x005AA0CC File Offset: 0x005A84CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBC6 RID: 52166
		private int opl_p0;
	}
}
