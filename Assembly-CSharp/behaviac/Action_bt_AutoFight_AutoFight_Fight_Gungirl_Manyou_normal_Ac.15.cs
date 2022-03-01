using System;

namespace behaviac
{
	// Token: 0x02002058 RID: 8280
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node39 : Action
	{
		// Token: 0x06012A4A RID: 76362 RVA: 0x00577C55 File Offset: 0x00576055
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node39()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2519;
		}

		// Token: 0x06012A4B RID: 76363 RVA: 0x00577C6F File Offset: 0x0057606F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C43E RID: 50238
		private int method_p0;
	}
}
