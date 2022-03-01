using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002E45 RID: 11845
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node212 : Action
	{
		// Token: 0x06014567 RID: 83303 RVA: 0x0061AEFC File Offset: 0x006192FC
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node212()
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
			item.skillID = 21629;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014568 RID: 83304 RVA: 0x0061AF8C File Offset: 0x0061938C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEF9 RID: 57081
		private List<Input> method_p0;

		// Token: 0x0400DEFA RID: 57082
		private bool method_p1;
	}
}
