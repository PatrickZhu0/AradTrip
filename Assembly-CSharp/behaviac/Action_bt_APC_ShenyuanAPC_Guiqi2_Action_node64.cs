using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E54 RID: 7764
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Guiqi2_Action_node64 : Action
	{
		// Token: 0x06012655 RID: 75349 RVA: 0x005603E8 File Offset: 0x0055E7E8
		public Action_bt_APC_ShenyuanAPC_Guiqi2_Action_node64()
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
			item.skillID = 9734;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012656 RID: 75350 RVA: 0x00560478 File Offset: 0x0055E878
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C03C RID: 49212
		private List<Input> method_p0;

		// Token: 0x0400C03D RID: 49213
		private bool method_p1;
	}
}
