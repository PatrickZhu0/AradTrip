using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020035B2 RID: 13746
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node7 : Action
	{
		// Token: 0x06015392 RID: 86930 RVA: 0x00665930 File Offset: 0x00663D30
		public Action_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node7()
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
			item.skillID = 5333;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015393 RID: 86931 RVA: 0x006659C0 File Offset: 0x00663DC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED5E RID: 60766
		private List<Input> method_p0;

		// Token: 0x0400ED5F RID: 60767
		private bool method_p1;
	}
}
