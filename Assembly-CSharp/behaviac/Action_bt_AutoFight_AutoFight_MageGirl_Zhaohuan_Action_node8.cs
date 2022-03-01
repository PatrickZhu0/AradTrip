using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002762 RID: 10082
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node8 : Action
	{
		// Token: 0x06013805 RID: 79877 RVA: 0x005CFE08 File Offset: 0x005CE208
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node8()
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
			item.skillID = 2007;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013806 RID: 79878 RVA: 0x005CFE98 File Offset: 0x005CE298
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D265 RID: 53861
		private List<Input> method_p0;

		// Token: 0x0400D266 RID: 53862
		private bool method_p1;
	}
}
