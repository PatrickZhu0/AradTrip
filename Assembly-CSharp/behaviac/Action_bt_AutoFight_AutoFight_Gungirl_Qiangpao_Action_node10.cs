using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200255F RID: 9567
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node103 : Action
	{
		// Token: 0x06013407 RID: 78855 RVA: 0x005B7BBC File Offset: 0x005B5FBC
		public Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node103()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 2507;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013408 RID: 78856 RVA: 0x005B7C4C File Offset: 0x005B604C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE2D RID: 52781
		private List<Input> method_p0;

		// Token: 0x0400CE2E RID: 52782
		private bool method_p1;
	}
}
