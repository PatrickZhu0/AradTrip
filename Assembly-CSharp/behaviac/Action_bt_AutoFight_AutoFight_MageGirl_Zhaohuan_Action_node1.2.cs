using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002772 RID: 10098
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node19 : Action
	{
		// Token: 0x06013825 RID: 79909 RVA: 0x005D04D8 File Offset: 0x005CE8D8
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node19()
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
			item.skillID = 2005;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013826 RID: 79910 RVA: 0x005D0568 File Offset: 0x005CE968
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D285 RID: 53893
		private List<Input> method_p0;

		// Token: 0x0400D286 RID: 53894
		private bool method_p1;
	}
}
