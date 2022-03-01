using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D30 RID: 7472
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Guiqi_Action_node15 : Action
	{
		// Token: 0x06012422 RID: 74786 RVA: 0x00552F50 File Offset: 0x00551350
		public Action_bt_APC_APC_Guiqi_Action_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 9;
			Input item = default(Input);
			item.delay = 100;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 7097;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 800;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 7093;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			Input item3 = default(Input);
			item3.delay = 300;
			item3.moveInSkillState = false;
			item3.moveKeepDistance = 0;
			item3.PKRobotComboCheck = false;
			item3.pressTime = 0;
			item3.randomChangeDirection = false;
			item3.skillID = 7094;
			item3.specialChoice = 0;
			this.method_p0.Add(item3);
			Input item4 = default(Input);
			item4.delay = 300;
			item4.moveInSkillState = false;
			item4.moveKeepDistance = 0;
			item4.PKRobotComboCheck = false;
			item4.pressTime = 0;
			item4.randomChangeDirection = false;
			item4.skillID = 7095;
			item4.specialChoice = 0;
			this.method_p0.Add(item4);
			Input item5 = default(Input);
			item5.delay = 300;
			item5.moveInSkillState = false;
			item5.moveKeepDistance = 0;
			item5.PKRobotComboCheck = false;
			item5.pressTime = 0;
			item5.randomChangeDirection = false;
			item5.skillID = 7096;
			item5.specialChoice = 0;
			this.method_p0.Add(item5);
			Input item6 = default(Input);
			item6.delay = 300;
			item6.moveInSkillState = false;
			item6.moveKeepDistance = 0;
			item6.PKRobotComboCheck = false;
			item6.pressTime = 0;
			item6.randomChangeDirection = false;
			item6.skillID = 7097;
			item6.specialChoice = 0;
			this.method_p0.Add(item6);
			Input item7 = default(Input);
			item7.delay = 400;
			item7.moveInSkillState = false;
			item7.moveKeepDistance = 0;
			item7.PKRobotComboCheck = false;
			item7.pressTime = 0;
			item7.randomChangeDirection = false;
			item7.skillID = 7086;
			item7.specialChoice = 0;
			this.method_p0.Add(item7);
			Input item8 = default(Input);
			item8.delay = 300;
			item8.moveInSkillState = false;
			item8.moveKeepDistance = 0;
			item8.PKRobotComboCheck = false;
			item8.pressTime = 0;
			item8.randomChangeDirection = false;
			item8.skillID = 7087;
			item8.specialChoice = 0;
			this.method_p0.Add(item8);
			Input item9 = default(Input);
			item9.delay = 300;
			item9.moveInSkillState = false;
			item9.moveKeepDistance = 0;
			item9.PKRobotComboCheck = false;
			item9.pressTime = 0;
			item9.randomChangeDirection = false;
			item9.skillID = 7088;
			item9.specialChoice = 0;
			this.method_p0.Add(item9);
			this.method_p1 = false;
		}

		// Token: 0x06012423 RID: 74787 RVA: 0x005532C7 File Offset: 0x005516C7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE12 RID: 48658
		private List<Input> method_p0;

		// Token: 0x0400BE13 RID: 48659
		private bool method_p1;
	}
}
