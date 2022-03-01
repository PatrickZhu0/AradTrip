using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002638 RID: 9784
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node35 : Action
	{
		// Token: 0x060135B6 RID: 79286 RVA: 0x005C1D98 File Offset: 0x005C0198
		public Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node35()
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
			item.skillID = 1013;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060135B7 RID: 79287 RVA: 0x005C1E28 File Offset: 0x005C0228
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D004 RID: 53252
		private List<Input> method_p0;

		// Token: 0x0400D005 RID: 53253
		private bool method_p1;
	}
}
