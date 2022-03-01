using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F4A RID: 8010
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node66 : Action
	{
		// Token: 0x06012837 RID: 75831 RVA: 0x0056AF80 File Offset: 0x00569380
		public Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node66()
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
			item.skillID = 3200;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 200;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 3203;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x06012838 RID: 75832 RVA: 0x0056B06C File Offset: 0x0056946C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C231 RID: 49713
		private List<Input> method_p0;

		// Token: 0x0400C232 RID: 49714
		private bool method_p1;
	}
}
