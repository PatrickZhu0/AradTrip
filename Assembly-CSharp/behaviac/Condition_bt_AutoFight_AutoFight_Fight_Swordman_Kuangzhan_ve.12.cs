using System;

namespace behaviac
{
	// Token: 0x0200241D RID: 9245
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node27 : Condition
	{
		// Token: 0x06013194 RID: 78228 RVA: 0x005A9E9B File Offset: 0x005A829B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node27()
		{
			this.opl_p0 = 1604;
		}

		// Token: 0x06013195 RID: 78229 RVA: 0x005A9EB0 File Offset: 0x005A82B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBBE RID: 52158
		private int opl_p0;
	}
}
