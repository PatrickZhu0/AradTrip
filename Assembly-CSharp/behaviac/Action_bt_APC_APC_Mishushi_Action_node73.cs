using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001DCE RID: 7630
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Mishushi_Action_node73 : Action
	{
		// Token: 0x06012554 RID: 75092 RVA: 0x0055A3C0 File Offset: 0x005587C0
		public Action_bt_APC_APC_Mishushi_Action_node73()
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
			item.skillID = 9744;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012555 RID: 75093 RVA: 0x0055A450 File Offset: 0x00558850
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF48 RID: 48968
		private List<Input> method_p0;

		// Token: 0x0400BF49 RID: 48969
		private bool method_p1;
	}
}
