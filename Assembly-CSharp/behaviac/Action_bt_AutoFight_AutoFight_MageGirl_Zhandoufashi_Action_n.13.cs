using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002737 RID: 10039
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node27 : Action
	{
		// Token: 0x060137B0 RID: 79792 RVA: 0x005CD694 File Offset: 0x005CBA94
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node27()
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
			item.skillID = 2301;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060137B1 RID: 79793 RVA: 0x005CD724 File Offset: 0x005CBB24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D209 RID: 53769
		private List<Input> method_p0;

		// Token: 0x0400D20A RID: 53770
		private bool method_p1;
	}
}
