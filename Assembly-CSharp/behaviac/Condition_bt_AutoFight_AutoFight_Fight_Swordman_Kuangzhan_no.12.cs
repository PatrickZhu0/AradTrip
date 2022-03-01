using System;

namespace behaviac
{
	// Token: 0x020023ED RID: 9197
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node27 : Condition
	{
		// Token: 0x0601313A RID: 78138 RVA: 0x005A7BCF File Offset: 0x005A5FCF
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node27()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x0601313B RID: 78139 RVA: 0x005A7BE4 File Offset: 0x005A5FE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB65 RID: 52069
		private int opl_p0;
	}
}
