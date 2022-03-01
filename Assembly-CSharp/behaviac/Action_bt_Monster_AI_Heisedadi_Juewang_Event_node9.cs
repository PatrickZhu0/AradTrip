using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003482 RID: 13442
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Juewang_Event_node9 : Action
	{
		// Token: 0x0601514D RID: 86349 RVA: 0x0065A26C File Offset: 0x0065866C
		public Action_bt_Monster_AI_Heisedadi_Juewang_Event_node9()
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
			item.skillID = 6213;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601514E RID: 86350 RVA: 0x0065A2FC File Offset: 0x006586FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA4E RID: 59982
		private List<Input> method_p0;

		// Token: 0x0400EA4F RID: 59983
		private bool method_p1;
	}
}
