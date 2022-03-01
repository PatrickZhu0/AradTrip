using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003419 RID: 13337
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Action_node15 : Action
	{
		// Token: 0x06015083 RID: 86147 RVA: 0x00655F5C File Offset: 0x0065435C
		public Action_bt_Monster_AI_Heisedadi_Huimie_Action_node15()
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
			item.skillID = 6223;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015084 RID: 86148 RVA: 0x00655FEC File Offset: 0x006543EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E958 RID: 59736
		private List<Input> method_p0;

		// Token: 0x0400E959 RID: 59737
		private bool method_p1;
	}
}
