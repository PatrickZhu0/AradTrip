using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E24 RID: 7716
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Tiantangmanbuzhe_Action_node14 : Action
	{
		// Token: 0x060125F9 RID: 75257 RVA: 0x0055DEA4 File Offset: 0x0055C2A4
		public Action_bt_APC_APC_Tiantangmanbuzhe_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 2000;
			item.randomChangeDirection = false;
			item.skillID = 8011;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060125FA RID: 75258 RVA: 0x0055DF38 File Offset: 0x0055C338
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFE4 RID: 49124
		private List<Input> method_p0;

		// Token: 0x0400BFE5 RID: 49125
		private bool method_p1;
	}
}
