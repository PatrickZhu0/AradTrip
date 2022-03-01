using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F8A RID: 8074
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node25 : Action
	{
		// Token: 0x060128B4 RID: 75956 RVA: 0x0056E31C File Offset: 0x0056C71C
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node25()
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
			item.skillID = 2507;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060128B5 RID: 75957 RVA: 0x0056E3AC File Offset: 0x0056C7AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2A6 RID: 49830
		private List<Input> method_p0;

		// Token: 0x0400C2A7 RID: 49831
		private bool method_p1;
	}
}
