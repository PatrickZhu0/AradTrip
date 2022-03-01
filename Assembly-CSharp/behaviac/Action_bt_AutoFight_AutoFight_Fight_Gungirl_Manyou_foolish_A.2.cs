using System;

namespace behaviac
{
	// Token: 0x02001FEC RID: 8172
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node4 : Action
	{
		// Token: 0x06012974 RID: 76148 RVA: 0x0057328D File Offset: 0x0057168D
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2518;
		}

		// Token: 0x06012975 RID: 76149 RVA: 0x005732A7 File Offset: 0x005716A7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C368 RID: 50024
		private int method_p0;
	}
}
