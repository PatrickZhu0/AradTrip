using System;

namespace behaviac
{
	// Token: 0x02001FC5 RID: 8133
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node9 : Action
	{
		// Token: 0x06012927 RID: 76071 RVA: 0x00571449 File Offset: 0x0056F849
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2517;
		}

		// Token: 0x06012928 RID: 76072 RVA: 0x00571463 File Offset: 0x0056F863
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C31A RID: 49946
		private int method_p0;
	}
}
