using System;

namespace behaviac
{
	// Token: 0x02002068 RID: 8296
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node9 : Action
	{
		// Token: 0x06012A69 RID: 76393 RVA: 0x00578F69 File Offset: 0x00577369
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2517;
		}

		// Token: 0x06012A6A RID: 76394 RVA: 0x00578F83 File Offset: 0x00577383
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C45D RID: 50269
		private int method_p0;
	}
}
