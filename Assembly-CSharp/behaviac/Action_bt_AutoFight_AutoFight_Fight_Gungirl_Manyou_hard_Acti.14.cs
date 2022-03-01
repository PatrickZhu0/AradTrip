using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200202D RID: 8237
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node35 : Action
	{
		// Token: 0x060129F5 RID: 76277 RVA: 0x00575CCC File Offset: 0x005740CC
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node35()
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
			item.skillID = 2512;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060129F6 RID: 76278 RVA: 0x00575D5C File Offset: 0x0057415C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3E8 RID: 50152
		private List<Input> method_p0;

		// Token: 0x0400C3E9 RID: 50153
		private bool method_p1;
	}
}
