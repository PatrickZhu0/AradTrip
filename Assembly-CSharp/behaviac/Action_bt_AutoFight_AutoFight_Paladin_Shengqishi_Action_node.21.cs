using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002866 RID: 10342
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node114 : Action
	{
		// Token: 0x06013A0A RID: 80394 RVA: 0x005DA7E4 File Offset: 0x005D8BE4
		public Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node114()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 2;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 3510;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 470;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 3512;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x06013A0B RID: 80395 RVA: 0x005DA8D0 File Offset: 0x005D8CD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D462 RID: 54370
		private List<Input> method_p0;

		// Token: 0x0400D463 RID: 54371
		private bool method_p1;
	}
}
