using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001EE0 RID: 7904
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_Action_node10 : Action
	{
		// Token: 0x06012765 RID: 75621 RVA: 0x00566794 File Offset: 0x00564B94
		public Action_bt_AutoFight_AutoFight_Fightergirl_Action_node10()
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
			item.skillID = 3007;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012766 RID: 75622 RVA: 0x00566824 File Offset: 0x00564C24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C158 RID: 49496
		private List<Input> method_p0;

		// Token: 0x0400C159 RID: 49497
		private bool method_p1;
	}
}
