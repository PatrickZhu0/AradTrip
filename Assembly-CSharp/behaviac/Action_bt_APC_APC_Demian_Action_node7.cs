using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D00 RID: 7424
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Demian_Action_node7 : Action
	{
		// Token: 0x060123C5 RID: 74693 RVA: 0x00550AB8 File Offset: 0x0054EEB8
		public Action_bt_APC_APC_Demian_Action_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 3;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 8004;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 600;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 3;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			Input item3 = default(Input);
			item3.delay = 2000;
			item3.moveInSkillState = false;
			item3.moveKeepDistance = 0;
			item3.PKRobotComboCheck = false;
			item3.pressTime = 0;
			item3.randomChangeDirection = false;
			item3.skillID = 4;
			item3.specialChoice = 0;
			this.method_p0.Add(item3);
			this.method_p1 = false;
		}

		// Token: 0x060123C6 RID: 74694 RVA: 0x00550BF8 File Offset: 0x0054EFF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDBB RID: 48571
		private List<Input> method_p0;

		// Token: 0x0400BDBC RID: 48572
		private bool method_p1;
	}
}
