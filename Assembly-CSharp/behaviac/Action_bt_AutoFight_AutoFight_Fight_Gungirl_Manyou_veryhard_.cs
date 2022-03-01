using System;

namespace behaviac
{
	// Token: 0x02002064 RID: 8292
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node4 : Action
	{
		// Token: 0x06012A61 RID: 76385 RVA: 0x00578DCD File Offset: 0x005771CD
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2518;
		}

		// Token: 0x06012A62 RID: 76386 RVA: 0x00578DE7 File Offset: 0x005771E7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C455 RID: 50261
		private int method_p0;
	}
}
