using System;

namespace behaviac
{
	// Token: 0x02002431 RID: 9265
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node67 : Condition
	{
		// Token: 0x060131BA RID: 78266 RVA: 0x005AA6FF File Offset: 0x005A8AFF
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node67()
		{
			this.opl_p0 = 1607;
		}

		// Token: 0x060131BB RID: 78267 RVA: 0x005AA714 File Offset: 0x005A8B14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBE4 RID: 52196
		private int opl_p0;
	}
}
