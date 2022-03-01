using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E33 RID: 15923
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node11 : Action
	{
		// Token: 0x060163EC RID: 91116 RVA: 0x006B9C68 File Offset: 0x006B8068
		public Action_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node11()
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
			item.skillID = 7226;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060163ED RID: 91117 RVA: 0x006B9CF8 File Offset: 0x006B80F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC4E RID: 64590
		private List<Input> method_p0;

		// Token: 0x0400FC4F RID: 64591
		private bool method_p1;
	}
}
