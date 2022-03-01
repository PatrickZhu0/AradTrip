using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003425 RID: 13349
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node10 : Action
	{
		// Token: 0x06015099 RID: 86169 RVA: 0x00656938 File Offset: 0x00654D38
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node10()
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
			item.skillID = 6224;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601509A RID: 86170 RVA: 0x006569C8 File Offset: 0x00654DC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E96A RID: 59754
		private List<Input> method_p0;

		// Token: 0x0400E96B RID: 59755
		private bool method_p1;
	}
}
