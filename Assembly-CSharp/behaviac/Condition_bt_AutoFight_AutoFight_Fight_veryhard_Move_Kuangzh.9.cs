using System;

namespace behaviac
{
	// Token: 0x02002499 RID: 9369
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node14 : Condition
	{
		// Token: 0x0601327E RID: 78462 RVA: 0x005AF675 File Offset: 0x005ADA75
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Kuangzhan_node14()
		{
			this.opl_p0 = 1609;
		}

		// Token: 0x0601327F RID: 78463 RVA: 0x005AF688 File Offset: 0x005ADA88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC97 RID: 52375
		private int opl_p0;
	}
}
