using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003436 RID: 13366
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node66 : Action
	{
		// Token: 0x060150BA RID: 86202 RVA: 0x00657188 File Offset: 0x00655588
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node66()
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
			item.skillID = 6221;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060150BB RID: 86203 RVA: 0x00657218 File Offset: 0x00655618
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E98D RID: 59789
		private List<Input> method_p0;

		// Token: 0x0400E98E RID: 59790
		private bool method_p1;
	}
}
