using System;

namespace behaviac
{
	// Token: 0x0200200C RID: 8204
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node44 : Action
	{
		// Token: 0x060129B4 RID: 76212 RVA: 0x005741D9 File Offset: 0x005725D9
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node44()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2507;
		}

		// Token: 0x060129B5 RID: 76213 RVA: 0x005741F3 File Offset: 0x005725F3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3A8 RID: 50088
		private int method_p0;
	}
}
