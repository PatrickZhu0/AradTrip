using System;

namespace behaviac
{
	// Token: 0x02001FFC RID: 8188
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node24 : Action
	{
		// Token: 0x06012994 RID: 76180 RVA: 0x005739AD File Offset: 0x00571DAD
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2513;
		}

		// Token: 0x06012995 RID: 76181 RVA: 0x005739C7 File Offset: 0x00571DC7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C388 RID: 50056
		private int method_p0;
	}
}
