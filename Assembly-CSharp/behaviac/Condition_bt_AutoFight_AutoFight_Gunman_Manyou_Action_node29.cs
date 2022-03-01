using System;

namespace behaviac
{
	// Token: 0x02002609 RID: 9737
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node29 : Condition
	{
		// Token: 0x06013558 RID: 79192 RVA: 0x005C08A5 File Offset: 0x005BECA5
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node29()
		{
			this.opl_p0 = 1104;
		}

		// Token: 0x06013559 RID: 79193 RVA: 0x005C08B8 File Offset: 0x005BECB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFA5 RID: 53157
		private int opl_p0;
	}
}
