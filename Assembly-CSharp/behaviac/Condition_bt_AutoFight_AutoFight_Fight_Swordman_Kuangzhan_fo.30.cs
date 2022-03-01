using System;

namespace behaviac
{
	// Token: 0x0200235D RID: 9053
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node57 : Condition
	{
		// Token: 0x06013027 RID: 77863 RVA: 0x0059F07B File Offset: 0x0059D47B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node57()
		{
			this.opl_p0 = 1511;
		}

		// Token: 0x06013028 RID: 77864 RVA: 0x0059F090 File Offset: 0x0059D490
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA40 RID: 51776
		private int opl_p0;
	}
}
