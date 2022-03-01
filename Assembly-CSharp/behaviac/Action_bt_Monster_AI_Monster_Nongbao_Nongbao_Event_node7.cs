using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020036D8 RID: 14040
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node7 : Action
	{
		// Token: 0x060155C6 RID: 87494 RVA: 0x00671CEC File Offset: 0x006700EC
		public Action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node7()
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
			item.skillID = 20349;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060155C7 RID: 87495 RVA: 0x00671D7C File Offset: 0x0067017C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF97 RID: 61335
		private List<Input> method_p0;

		// Token: 0x0400EF98 RID: 61336
		private bool method_p1;
	}
}
