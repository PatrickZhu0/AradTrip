using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E1B RID: 7707
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Tiantangmanbuzhe_Action_node20 : Action
	{
		// Token: 0x060125E7 RID: 75239 RVA: 0x0055DAC8 File Offset: 0x0055BEC8
		public Action_bt_APC_APC_Tiantangmanbuzhe_Action_node20()
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
			item.skillID = 8014;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060125E8 RID: 75240 RVA: 0x0055DB58 File Offset: 0x0055BF58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFD0 RID: 49104
		private List<Input> method_p0;

		// Token: 0x0400BFD1 RID: 49105
		private bool method_p1;
	}
}
