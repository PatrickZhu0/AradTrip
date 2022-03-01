using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002852 RID: 10322
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node89 : Action
	{
		// Token: 0x060139E2 RID: 80354 RVA: 0x005D9F60 File Offset: 0x005D8360
		public Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node89()
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
			item.skillID = 3504;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060139E3 RID: 80355 RVA: 0x005D9FF0 File Offset: 0x005D83F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D43A RID: 54330
		private List<Input> method_p0;

		// Token: 0x0400D43B RID: 54331
		private bool method_p1;
	}
}
