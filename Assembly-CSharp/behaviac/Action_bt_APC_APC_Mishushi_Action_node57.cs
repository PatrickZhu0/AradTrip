using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001DC2 RID: 7618
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Mishushi_Action_node57 : Action
	{
		// Token: 0x0601253C RID: 75068 RVA: 0x00559EA4 File Offset: 0x005582A4
		public Action_bt_APC_APC_Mishushi_Action_node57()
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
			item.skillID = 9743;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601253D RID: 75069 RVA: 0x00559F34 File Offset: 0x00558334
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF30 RID: 48944
		private List<Input> method_p0;

		// Token: 0x0400BF31 RID: 48945
		private bool method_p1;
	}
}
