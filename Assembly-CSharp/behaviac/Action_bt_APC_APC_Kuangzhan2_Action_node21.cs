using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D82 RID: 7554
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Kuangzhan2_Action_node21 : Action
	{
		// Token: 0x060124BF RID: 74943 RVA: 0x00556C2C File Offset: 0x0055502C
		public Action_bt_APC_APC_Kuangzhan2_Action_node21()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 7;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 9715;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 500;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 9711;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			Input item3 = default(Input);
			item3.delay = 300;
			item3.moveInSkillState = false;
			item3.moveKeepDistance = 0;
			item3.PKRobotComboCheck = false;
			item3.pressTime = 0;
			item3.randomChangeDirection = false;
			item3.skillID = 9712;
			item3.specialChoice = 0;
			this.method_p0.Add(item3);
			Input item4 = default(Input);
			item4.delay = 300;
			item4.moveInSkillState = false;
			item4.moveKeepDistance = 0;
			item4.PKRobotComboCheck = false;
			item4.pressTime = 0;
			item4.randomChangeDirection = false;
			item4.skillID = 9713;
			item4.specialChoice = 0;
			this.method_p0.Add(item4);
			Input item5 = default(Input);
			item5.delay = 200;
			item5.moveInSkillState = false;
			item5.moveKeepDistance = 0;
			item5.PKRobotComboCheck = false;
			item5.pressTime = 0;
			item5.randomChangeDirection = false;
			item5.skillID = 9714;
			item5.specialChoice = 0;
			this.method_p0.Add(item5);
			Input item6 = default(Input);
			item6.delay = 500;
			item6.moveInSkillState = false;
			item6.moveKeepDistance = 0;
			item6.PKRobotComboCheck = false;
			item6.pressTime = 0;
			item6.randomChangeDirection = false;
			item6.skillID = 9717;
			item6.specialChoice = 0;
			this.method_p0.Add(item6);
			Input item7 = default(Input);
			item7.delay = 1000;
			item7.moveInSkillState = false;
			item7.moveKeepDistance = 0;
			item7.PKRobotComboCheck = false;
			item7.pressTime = 0;
			item7.randomChangeDirection = false;
			item7.skillID = 9718;
			item7.specialChoice = 0;
			this.method_p0.Add(item7);
			this.method_p1 = false;
		}

		// Token: 0x060124C0 RID: 74944 RVA: 0x00556EE7 File Offset: 0x005552E7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEA9 RID: 48809
		private List<Input> method_p0;

		// Token: 0x0400BEAA RID: 48810
		private bool method_p1;
	}
}
