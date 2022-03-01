using System;

namespace behaviac
{
	// Token: 0x02001FF0 RID: 8176
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node9 : Action
	{
		// Token: 0x0601297C RID: 76156 RVA: 0x00573429 File Offset: 0x00571829
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2517;
		}

		// Token: 0x0601297D RID: 76157 RVA: 0x00573443 File Offset: 0x00571843
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C370 RID: 50032
		private int method_p0;
	}
}
