using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001DBE RID: 7614
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Mishushi_Action_node4 : Action
	{
		// Token: 0x06012534 RID: 75060 RVA: 0x00559CF0 File Offset: 0x005580F0
		public Action_bt_APC_APC_Mishushi_Action_node4()
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
			item.skillID = 9740;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012535 RID: 75061 RVA: 0x00559D80 File Offset: 0x00558180
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF28 RID: 48936
		private List<Input> method_p0;

		// Token: 0x0400BF29 RID: 48937
		private bool method_p1;
	}
}
