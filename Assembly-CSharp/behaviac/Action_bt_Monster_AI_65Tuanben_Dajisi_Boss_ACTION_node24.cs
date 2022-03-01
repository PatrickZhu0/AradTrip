using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002D81 RID: 11649
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node24 : Action
	{
		// Token: 0x060143E4 RID: 82916 RVA: 0x006148E8 File Offset: 0x00612CE8
		public Action_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node24()
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
			item.skillID = 21603;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060143E5 RID: 82917 RVA: 0x00614978 File Offset: 0x00612D78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDB5 RID: 56757
		private List<Input> method_p0;

		// Token: 0x0400DDB6 RID: 56758
		private bool method_p1;
	}
}
