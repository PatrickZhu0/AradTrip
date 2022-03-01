using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020025E4 RID: 9700
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node82 : Action
	{
		// Token: 0x0601350F RID: 79119 RVA: 0x005BDCC4 File Offset: 0x005BC0C4
		public Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node82()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 2;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 1006;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 1300;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 2509;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x06013510 RID: 79120 RVA: 0x005BDDB0 File Offset: 0x005BC1B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF53 RID: 53075
		private List<Input> method_p0;

		// Token: 0x0400CF54 RID: 53076
		private bool method_p1;
	}
}
