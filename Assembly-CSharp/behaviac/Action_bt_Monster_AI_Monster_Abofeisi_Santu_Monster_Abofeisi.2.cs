using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020035E9 RID: 13801
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Abofeisi_Santu_Monster_Abofeisi_Santu_Event_node27 : Action
	{
		// Token: 0x060153FA RID: 87034 RVA: 0x00667A8C File Offset: 0x00665E8C
		public Action_bt_Monster_AI_Monster_Abofeisi_Santu_Monster_Abofeisi_Santu_Event_node27()
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
			item.skillID = 5417;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060153FB RID: 87035 RVA: 0x00667B1C File Offset: 0x00665F1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDB5 RID: 60853
		private List<Input> method_p0;

		// Token: 0x0400EDB6 RID: 60854
		private bool method_p1;
	}
}
