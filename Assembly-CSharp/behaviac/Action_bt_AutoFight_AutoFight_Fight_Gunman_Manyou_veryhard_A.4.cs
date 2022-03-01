using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020021A9 RID: 8617
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node10 : Action
	{
		// Token: 0x06012CE1 RID: 77025 RVA: 0x00588440 File Offset: 0x00586840
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node10()
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
			item.skillID = 1101;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012CE2 RID: 77026 RVA: 0x005884D0 File Offset: 0x005868D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6D4 RID: 50900
		private List<Input> method_p0;

		// Token: 0x0400C6D5 RID: 50901
		private bool method_p1;
	}
}
