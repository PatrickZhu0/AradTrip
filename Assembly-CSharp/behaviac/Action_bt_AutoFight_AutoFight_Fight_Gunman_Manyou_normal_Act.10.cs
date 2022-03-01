using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200218D RID: 8589
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node25 : Action
	{
		// Token: 0x06012CAA RID: 76970 RVA: 0x00586BA8 File Offset: 0x00584FA8
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node25()
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
			item.skillID = 1013;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 1500;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 3;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			Input item3 = default(Input);
			item3.delay = 1500;
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

		// Token: 0x06012CAB RID: 76971 RVA: 0x00586CE8 File Offset: 0x005850E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C69D RID: 50845
		private List<Input> method_p0;

		// Token: 0x0400C69E RID: 50846
		private bool method_p1;
	}
}
