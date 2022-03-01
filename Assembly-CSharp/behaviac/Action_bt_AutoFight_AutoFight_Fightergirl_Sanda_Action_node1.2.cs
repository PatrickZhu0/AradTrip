using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F56 RID: 8022
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node16 : Action
	{
		// Token: 0x0601284F RID: 75855 RVA: 0x0056B504 File Offset: 0x00569904
		public Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node16()
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
			item.skillID = 3008;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012850 RID: 75856 RVA: 0x0056B594 File Offset: 0x00569994
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C249 RID: 49737
		private List<Input> method_p0;

		// Token: 0x0400C24A RID: 49738
		private bool method_p1;
	}
}
