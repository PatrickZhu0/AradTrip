using System;

namespace behaviac
{
	// Token: 0x020023F2 RID: 9202
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node34 : Condition
	{
		// Token: 0x06013143 RID: 78147 RVA: 0x005A7DEB File Offset: 0x005A61EB
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node34()
		{
			this.opl_p0 = 1608;
		}

		// Token: 0x06013144 RID: 78148 RVA: 0x005A7E00 File Offset: 0x005A6200
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB6D RID: 52077
		private int opl_p0;
	}
}
