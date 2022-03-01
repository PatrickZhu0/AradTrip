using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002C9B RID: 11419
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node25 : Action
	{
		// Token: 0x0601422D RID: 82477 RVA: 0x0060BF90 File Offset: 0x0060A390
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node25()
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
			item.skillID = 20754;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601422E RID: 82478 RVA: 0x0060C020 File Offset: 0x0060A420
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBE7 RID: 56295
		private List<Input> method_p0;

		// Token: 0x0400DBE8 RID: 56296
		private bool method_p1;
	}
}
