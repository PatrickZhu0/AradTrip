using System;

namespace behaviac
{
	// Token: 0x02001FF4 RID: 8180
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node14 : Action
	{
		// Token: 0x06012984 RID: 76164 RVA: 0x005735C5 File Offset: 0x005719C5
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2504;
		}

		// Token: 0x06012985 RID: 76165 RVA: 0x005735DF File Offset: 0x005719DF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C378 RID: 50040
		private int method_p0;
	}
}
