using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020023CF RID: 9167
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node2 : Action
	{
		// Token: 0x06013104 RID: 78084 RVA: 0x005A5960 File Offset: 0x005A3D60
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 8;
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
			item2.delay = 700;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = true;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 3;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			Input item3 = default(Input);
			item3.delay = 1400;
			item3.moveInSkillState = false;
			item3.moveKeepDistance = 0;
			item3.PKRobotComboCheck = false;
			item3.pressTime = 0;
			item3.randomChangeDirection = false;
			item3.skillID = 4;
			item3.specialChoice = 0;
			this.method_p0.Add(item3);
			Input item4 = default(Input);
			item4.delay = 250;
			item4.moveInSkillState = false;
			item4.moveKeepDistance = 0;
			item4.PKRobotComboCheck = true;
			item4.pressTime = 0;
			item4.randomChangeDirection = false;
			item4.skillID = 1503;
			item4.specialChoice = 0;
			this.method_p0.Add(item4);
			Input item5 = default(Input);
			item5.delay = 800;
			item5.moveInSkillState = false;
			item5.moveKeepDistance = 0;
			item5.PKRobotComboCheck = true;
			item5.pressTime = 0;
			item5.randomChangeDirection = false;
			item5.skillID = 1509;
			item5.specialChoice = 0;
			this.method_p0.Add(item5);
			Input item6 = default(Input);
			item6.delay = 900;
			item6.moveInSkillState = false;
			item6.moveKeepDistance = 0;
			item6.PKRobotComboCheck = true;
			item6.pressTime = 0;
			item6.randomChangeDirection = false;
			item6.skillID = 3;
			item6.specialChoice = 0;
			this.method_p0.Add(item6);
			Input item7 = default(Input);
			item7.delay = 1400;
			item7.moveInSkillState = false;
			item7.moveKeepDistance = 0;
			item7.PKRobotComboCheck = false;
			item7.pressTime = 0;
			item7.randomChangeDirection = false;
			item7.skillID = 4;
			item7.specialChoice = 0;
			this.method_p0.Add(item7);
			Input item8 = default(Input);
			item8.delay = 200;
			item8.moveInSkillState = false;
			item8.moveKeepDistance = 0;
			item8.PKRobotComboCheck = false;
			item8.pressTime = 0;
			item8.randomChangeDirection = false;
			item8.skillID = 1606;
			item8.specialChoice = 0;
			this.method_p0.Add(item8);
			this.method_p1 = true;
		}

		// Token: 0x06013105 RID: 78085 RVA: 0x005A5C68 File Offset: 0x005A4068
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB38 RID: 52024
		private List<Input> method_p0;

		// Token: 0x0400CB39 RID: 52025
		private bool method_p1;
	}
}
