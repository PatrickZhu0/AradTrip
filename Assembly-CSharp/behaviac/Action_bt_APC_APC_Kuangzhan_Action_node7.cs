using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001DB4 RID: 7604
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Kuangzhan_Action_node7 : Action
	{
		// Token: 0x06012521 RID: 75041 RVA: 0x005592B0 File Offset: 0x005576B0
		public Action_bt_APC_APC_Kuangzhan_Action_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 6;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 7106;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 800;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 7102;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			Input item3 = default(Input);
			item3.delay = 350;
			item3.moveInSkillState = false;
			item3.moveKeepDistance = 0;
			item3.PKRobotComboCheck = false;
			item3.pressTime = 0;
			item3.randomChangeDirection = false;
			item3.skillID = 7103;
			item3.specialChoice = 0;
			this.method_p0.Add(item3);
			Input item4 = default(Input);
			item4.delay = 350;
			item4.moveInSkillState = false;
			item4.moveKeepDistance = 0;
			item4.PKRobotComboCheck = false;
			item4.pressTime = 0;
			item4.randomChangeDirection = false;
			item4.skillID = 7104;
			item4.specialChoice = 0;
			this.method_p0.Add(item4);
			Input item5 = default(Input);
			item5.delay = 350;
			item5.moveInSkillState = false;
			item5.moveKeepDistance = 0;
			item5.PKRobotComboCheck = false;
			item5.pressTime = 0;
			item5.randomChangeDirection = false;
			item5.skillID = 7105;
			item5.specialChoice = 0;
			this.method_p0.Add(item5);
			Input item6 = default(Input);
			item6.delay = 350;
			item6.moveInSkillState = false;
			item6.moveKeepDistance = 0;
			item6.PKRobotComboCheck = false;
			item6.pressTime = 0;
			item6.randomChangeDirection = false;
			item6.skillID = 7108;
			item6.specialChoice = 0;
			this.method_p0.Add(item6);
			this.method_p1 = false;
		}

		// Token: 0x06012522 RID: 75042 RVA: 0x0055950E File Offset: 0x0055790E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF11 RID: 48913
		private List<Input> method_p0;

		// Token: 0x0400BF12 RID: 48914
		private bool method_p1;
	}
}
