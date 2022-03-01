using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020035DF RID: 13791
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node10 : Action
	{
		// Token: 0x060153E7 RID: 87015 RVA: 0x006674CC File Offset: 0x006658CC
		public Action_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node10()
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

		// Token: 0x060153E8 RID: 87016 RVA: 0x0066755C File Offset: 0x0066595C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDA7 RID: 60839
		private List<Input> method_p0;

		// Token: 0x0400EDA8 RID: 60840
		private bool method_p1;
	}
}
