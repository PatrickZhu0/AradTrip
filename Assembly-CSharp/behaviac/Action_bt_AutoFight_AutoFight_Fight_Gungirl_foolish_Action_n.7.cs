using System;

namespace behaviac
{
	// Token: 0x02001F9D RID: 8093
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node19 : Action
	{
		// Token: 0x060128D9 RID: 75993 RVA: 0x0056F361 File Offset: 0x0056D761
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2509;
		}

		// Token: 0x060128DA RID: 75994 RVA: 0x0056F37B File Offset: 0x0056D77B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2CC RID: 49868
		private int method_p0;
	}
}
