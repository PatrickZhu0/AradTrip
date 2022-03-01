using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020023A7 RID: 9127
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node31 : Action
	{
		// Token: 0x060130B4 RID: 78004 RVA: 0x005A31C4 File Offset: 0x005A15C4
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node31()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 13;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 1512;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 250;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = true;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 1503;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			Input item3 = default(Input);
			item3.delay = 800;
			item3.moveInSkillState = false;
			item3.moveKeepDistance = 0;
			item3.PKRobotComboCheck = true;
			item3.pressTime = 0;
			item3.randomChangeDirection = false;
			item3.skillID = 1509;
			item3.specialChoice = 0;
			this.method_p0.Add(item3);
			Input item4 = default(Input);
			item4.delay = 800;
			item4.moveInSkillState = false;
			item4.moveKeepDistance = 0;
			item4.PKRobotComboCheck = true;
			item4.pressTime = 0;
			item4.randomChangeDirection = false;
			item4.skillID = 3;
			item4.specialChoice = 0;
			this.method_p0.Add(item4);
			Input item5 = default(Input);
			item5.delay = 1400;
			item5.moveInSkillState = false;
			item5.moveKeepDistance = 0;
			item5.PKRobotComboCheck = false;
			item5.pressTime = 0;
			item5.randomChangeDirection = false;
			item5.skillID = 4;
			item5.specialChoice = 0;
			this.method_p0.Add(item5);
			Input item6 = default(Input);
			item6.delay = 100;
			item6.moveInSkillState = false;
			item6.moveKeepDistance = 0;
			item6.PKRobotComboCheck = true;
			item6.pressTime = 0;
			item6.randomChangeDirection = false;
			item6.skillID = 1503;
			item6.specialChoice = 0;
			this.method_p0.Add(item6);
			Input item7 = default(Input);
			item7.delay = 450;
			item7.moveInSkillState = false;
			item7.moveKeepDistance = 0;
			item7.PKRobotComboCheck = true;
			item7.pressTime = 0;
			item7.randomChangeDirection = false;
			item7.skillID = 3;
			item7.specialChoice = 0;
			this.method_p0.Add(item7);
			Input item8 = default(Input);
			item8.delay = 1400;
			item8.moveInSkillState = false;
			item8.moveKeepDistance = 0;
			item8.PKRobotComboCheck = false;
			item8.pressTime = 0;
			item8.randomChangeDirection = false;
			item8.skillID = 4;
			item8.specialChoice = 0;
			this.method_p0.Add(item8);
			Input item9 = default(Input);
			item9.delay = 300;
			item9.moveInSkillState = false;
			item9.moveKeepDistance = 0;
			item9.PKRobotComboCheck = true;
			item9.pressTime = 0;
			item9.randomChangeDirection = false;
			item9.skillID = 1503;
			item9.specialChoice = 0;
			this.method_p0.Add(item9);
			Input item10 = default(Input);
			item10.delay = 800;
			item10.moveInSkillState = false;
			item10.moveKeepDistance = 0;
			item10.PKRobotComboCheck = true;
			item10.pressTime = 0;
			item10.randomChangeDirection = false;
			item10.skillID = 1509;
			item10.specialChoice = 0;
			this.method_p0.Add(item10);
			Input item11 = default(Input);
			item11.delay = 800;
			item11.moveInSkillState = false;
			item11.moveKeepDistance = 0;
			item11.PKRobotComboCheck = false;
			item11.pressTime = 0;
			item11.randomChangeDirection = false;
			item11.skillID = 3;
			item11.specialChoice = 0;
			this.method_p0.Add(item11);
			Input item12 = default(Input);
			item12.delay = 1400;
			item12.moveInSkillState = false;
			item12.moveKeepDistance = 0;
			item12.PKRobotComboCheck = false;
			item12.pressTime = 0;
			item12.randomChangeDirection = false;
			item12.skillID = 4;
			item12.specialChoice = 0;
			this.method_p0.Add(item12);
			Input item13 = default(Input);
			item13.delay = 300;
			item13.moveInSkillState = false;
			item13.moveKeepDistance = 0;
			item13.PKRobotComboCheck = false;
			item13.pressTime = 0;
			item13.randomChangeDirection = false;
			item13.skillID = 1606;
			item13.specialChoice = 0;
			this.method_p0.Add(item13);
			this.method_p1 = true;
		}

		// Token: 0x060130B5 RID: 78005 RVA: 0x005A3693 File Offset: 0x005A1A93
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CADC RID: 51932
		private List<Input> method_p0;

		// Token: 0x0400CADD RID: 51933
		private bool method_p1;
	}
}
