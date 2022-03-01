using System;

namespace behaviac
{
	// Token: 0x02002004 RID: 8196
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node34 : Action
	{
		// Token: 0x060129A4 RID: 76196 RVA: 0x00573D95 File Offset: 0x00572195
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2512;
		}

		// Token: 0x060129A5 RID: 76197 RVA: 0x00573DAF File Offset: 0x005721AF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C398 RID: 50072
		private int method_p0;
	}
}
