using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E15 RID: 15893
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node19 : Action
	{
		// Token: 0x060163B3 RID: 91059 RVA: 0x006B86EC File Offset: 0x006B6AEC
		public Action_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node19()
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
			item.skillID = 7237;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060163B4 RID: 91060 RVA: 0x006B877C File Offset: 0x006B6B7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC1B RID: 64539
		private List<Input> method_p0;

		// Token: 0x0400FC1C RID: 64540
		private bool method_p1;
	}
}
