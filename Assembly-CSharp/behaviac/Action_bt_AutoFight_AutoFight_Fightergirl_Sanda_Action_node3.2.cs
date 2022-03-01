using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F4E RID: 8014
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node39 : Action
	{
		// Token: 0x0601283F RID: 75839 RVA: 0x0056B194 File Offset: 0x00569594
		public Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node39()
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
			item.skillID = 3204;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012840 RID: 75840 RVA: 0x0056B224 File Offset: 0x00569624
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C239 RID: 49721
		private List<Input> method_p0;

		// Token: 0x0400C23A RID: 49722
		private bool method_p1;
	}
}
