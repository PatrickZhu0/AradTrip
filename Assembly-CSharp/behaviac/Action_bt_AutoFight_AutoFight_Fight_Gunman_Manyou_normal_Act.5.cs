using System;

namespace behaviac
{
	// Token: 0x02002184 RID: 8580
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node14 : Action
	{
		// Token: 0x06012C98 RID: 76952 RVA: 0x00586791 File Offset: 0x00584B91
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1005;
		}

		// Token: 0x06012C99 RID: 76953 RVA: 0x005867AB File Offset: 0x00584BAB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C68C RID: 50828
		private int method_p0;
	}
}
