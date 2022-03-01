using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F42 RID: 8002
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node33 : Action
	{
		// Token: 0x06012827 RID: 75815 RVA: 0x0056AC10 File Offset: 0x00569010
		public Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node33()
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
			item.skillID = 3201;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012828 RID: 75816 RVA: 0x0056ACA0 File Offset: 0x005690A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C221 RID: 49697
		private List<Input> method_p0;

		// Token: 0x0400C222 RID: 49698
		private bool method_p1;
	}
}
