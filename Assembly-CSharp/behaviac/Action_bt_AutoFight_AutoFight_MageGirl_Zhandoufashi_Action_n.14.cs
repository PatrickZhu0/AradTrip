using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200273B RID: 10043
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node20 : Action
	{
		// Token: 0x060137B8 RID: 79800 RVA: 0x005CD848 File Offset: 0x005CBC48
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node20()
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
			item.skillID = 2009;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060137B9 RID: 79801 RVA: 0x005CD8D8 File Offset: 0x005CBCD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D211 RID: 53777
		private List<Input> method_p0;

		// Token: 0x0400D212 RID: 53778
		private bool method_p1;
	}
}
