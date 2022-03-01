using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020021E9 RID: 8681
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node10 : Action
	{
		// Token: 0x06012D5F RID: 77151 RVA: 0x0058B5CC File Offset: 0x005899CC
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node10()
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
			item.skillID = 1007;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012D60 RID: 77152 RVA: 0x0058B65C File Offset: 0x00589A5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C752 RID: 51026
		private List<Input> method_p0;

		// Token: 0x0400C753 RID: 51027
		private bool method_p1;
	}
}
