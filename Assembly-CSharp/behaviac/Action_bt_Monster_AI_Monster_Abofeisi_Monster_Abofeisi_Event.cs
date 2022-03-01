using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020035DB RID: 13787
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node5 : Action
	{
		// Token: 0x060153DF RID: 87007 RVA: 0x00667334 File Offset: 0x00665734
		public Action_bt_Monster_AI_Monster_Abofeisi_Monster_Abofeisi_Event_Abofeisi_node5()
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
			item.skillID = 5413;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060153E0 RID: 87008 RVA: 0x006673C4 File Offset: 0x006657C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDA0 RID: 60832
		private List<Input> method_p0;

		// Token: 0x0400EDA1 RID: 60833
		private bool method_p1;
	}
}
