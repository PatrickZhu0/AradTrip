using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002301 RID: 8961
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node15 : Action
	{
		// Token: 0x06012F7B RID: 77691 RVA: 0x0059B070 File Offset: 0x00599470
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 12;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 1503;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 300;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = true;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 3;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			Input item3 = default(Input);
			item3.delay = 1050;
			item3.moveInSkillState = false;
			item3.moveKeepDistance = 0;
			item3.PKRobotComboCheck = false;
			item3.pressTime = 0;
			item3.randomChangeDirection = false;
			item3.skillID = 4;
			item3.specialChoice = 0;
			this.method_p0.Add(item3);
			Input item4 = default(Input);
			item4.delay = 450;
			item4.moveInSkillState = false;
			item4.moveKeepDistance = 0;
			item4.PKRobotComboCheck = true;
			item4.pressTime = 0;
			item4.randomChangeDirection = false;
			item4.skillID = 1503;
			item4.specialChoice = 0;
			this.method_p0.Add(item4);
			Input item5 = default(Input);
			item5.delay = 580;
			item5.moveInSkillState = false;
			item5.moveKeepDistance = 0;
			item5.PKRobotComboCheck = true;
			item5.pressTime = 0;
			item5.randomChangeDirection = false;
			item5.skillID = 1901;
			item5.specialChoice = 0;
			this.method_p0.Add(item5);
			Input item6 = default(Input);
			item6.delay = 350;
			item6.moveInSkillState = false;
			item6.moveKeepDistance = 0;
			item6.PKRobotComboCheck = true;
			item6.pressTime = 0;
			item6.randomChangeDirection = false;
			item6.skillID = 1902;
			item6.specialChoice = 0;
			this.method_p0.Add(item6);
			Input item7 = default(Input);
			item7.delay = 350;
			item7.moveInSkillState = false;
			item7.moveKeepDistance = 0;
			item7.PKRobotComboCheck = true;
			item7.pressTime = 0;
			item7.randomChangeDirection = false;
			item7.skillID = 1903;
			item7.specialChoice = 0;
			this.method_p0.Add(item7);
			Input item8 = default(Input);
			item8.delay = 400;
			item8.moveInSkillState = false;
			item8.moveKeepDistance = 0;
			item8.PKRobotComboCheck = true;
			item8.pressTime = 0;
			item8.randomChangeDirection = false;
			item8.skillID = 1907;
			item8.specialChoice = 0;
			this.method_p0.Add(item8);
			Input item9 = default(Input);
			item9.delay = 450;
			item9.moveInSkillState = false;
			item9.moveKeepDistance = 0;
			item9.PKRobotComboCheck = true;
			item9.pressTime = 0;
			item9.randomChangeDirection = false;
			item9.skillID = 1503;
			item9.specialChoice = 0;
			this.method_p0.Add(item9);
			Input item10 = default(Input);
			item10.delay = 300;
			item10.moveInSkillState = false;
			item10.moveKeepDistance = 0;
			item10.PKRobotComboCheck = true;
			item10.pressTime = 0;
			item10.randomChangeDirection = false;
			item10.skillID = 3;
			item10.specialChoice = 0;
			this.method_p0.Add(item10);
			Input item11 = default(Input);
			item11.delay = 1050;
			item11.moveInSkillState = false;
			item11.moveKeepDistance = 0;
			item11.PKRobotComboCheck = false;
			item11.pressTime = 0;
			item11.randomChangeDirection = false;
			item11.skillID = 4;
			item11.specialChoice = 0;
			this.method_p0.Add(item11);
			Input item12 = default(Input);
			item12.delay = 500;
			item12.moveInSkillState = false;
			item12.moveKeepDistance = 0;
			item12.PKRobotComboCheck = false;
			item12.pressTime = 0;
			item12.randomChangeDirection = false;
			item12.skillID = 1511;
			item12.specialChoice = 0;
			this.method_p0.Add(item12);
			this.method_p1 = true;
		}

		// Token: 0x06012F7C RID: 77692 RVA: 0x0059B4ED File Offset: 0x005998ED
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C996 RID: 51606
		private List<Input> method_p0;

		// Token: 0x0400C997 RID: 51607
		private bool method_p1;
	}
}
