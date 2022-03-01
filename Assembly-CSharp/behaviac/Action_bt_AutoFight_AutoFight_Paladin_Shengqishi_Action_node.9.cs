using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002836 RID: 10294
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node36 : Action
	{
		// Token: 0x060139AA RID: 80298 RVA: 0x005D9374 File Offset: 0x005D7774
		public Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node36()
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
			item.skillID = 3714;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060139AB RID: 80299 RVA: 0x005D9404 File Offset: 0x005D7804
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D402 RID: 54274
		private List<Input> method_p0;

		// Token: 0x0400D403 RID: 54275
		private bool method_p1;
	}
}
