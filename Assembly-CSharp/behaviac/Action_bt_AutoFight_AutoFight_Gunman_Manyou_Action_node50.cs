using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002630 RID: 9776
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node50 : Action
	{
		// Token: 0x060135A6 RID: 79270 RVA: 0x005C1A30 File Offset: 0x005BFE30
		public Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node50()
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
			item.skillID = 1005;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060135A7 RID: 79271 RVA: 0x005C1AC0 File Offset: 0x005BFEC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFF4 RID: 53236
		private List<Input> method_p0;

		// Token: 0x0400CFF5 RID: 53237
		private bool method_p1;
	}
}
