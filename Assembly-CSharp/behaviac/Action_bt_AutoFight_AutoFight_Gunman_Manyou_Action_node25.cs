using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002606 RID: 9734
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node25 : Action
	{
		// Token: 0x06013552 RID: 79186 RVA: 0x005C0738 File Offset: 0x005BEB38
		public Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node25()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = true;
			item.moveKeepDistance = 3;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 1102;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013553 RID: 79187 RVA: 0x005C07C8 File Offset: 0x005BEBC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF9E RID: 53150
		private List<Input> method_p0;

		// Token: 0x0400CF9F RID: 53151
		private bool method_p1;
	}
}
