using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020020B5 RID: 8373
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node25 : Action
	{
		// Token: 0x06012B01 RID: 76545 RVA: 0x0057C7B4 File Offset: 0x0057ABB4
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node25()
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

		// Token: 0x06012B02 RID: 76546 RVA: 0x0057C844 File Offset: 0x0057AC44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4F4 RID: 50420
		private List<Input> method_p0;

		// Token: 0x0400C4F5 RID: 50421
		private bool method_p1;
	}
}
