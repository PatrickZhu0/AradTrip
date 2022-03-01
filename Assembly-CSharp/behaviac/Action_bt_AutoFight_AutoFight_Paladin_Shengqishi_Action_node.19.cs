using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200285E RID: 10334
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node109 : Action
	{
		// Token: 0x060139FA RID: 80378 RVA: 0x005DA47C File Offset: 0x005D887C
		public Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node109()
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
			item.skillID = 3511;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060139FB RID: 80379 RVA: 0x005DA50C File Offset: 0x005D890C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D452 RID: 54354
		private List<Input> method_p0;

		// Token: 0x0400D453 RID: 54355
		private bool method_p1;
	}
}
