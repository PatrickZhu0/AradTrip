using System;

namespace behaviac
{
	// Token: 0x02002526 RID: 9510
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node57 : Condition
	{
		// Token: 0x06013395 RID: 78741 RVA: 0x005B633B File Offset: 0x005B473B
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node57()
		{
			this.opl_p0 = 2608;
		}

		// Token: 0x06013396 RID: 78742 RVA: 0x005B6350 File Offset: 0x005B4750
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDB8 RID: 52664
		private int opl_p0;
	}
}
