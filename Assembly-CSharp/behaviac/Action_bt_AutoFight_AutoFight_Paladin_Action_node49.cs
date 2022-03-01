using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002792 RID: 10130
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Action_node49 : Action
	{
		// Token: 0x06013864 RID: 79972 RVA: 0x005D24B4 File Offset: 0x005D08B4
		public Action_bt_AutoFight_AutoFight_Paladin_Action_node49()
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

		// Token: 0x06013865 RID: 79973 RVA: 0x005D2544 File Offset: 0x005D0944
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2C3 RID: 53955
		private List<Input> method_p0;

		// Token: 0x0400D2C4 RID: 53956
		private bool method_p1;
	}
}
