using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001ED7 RID: 7895
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_Action_node36 : Action
	{
		// Token: 0x06012753 RID: 75603 RVA: 0x005663C4 File Offset: 0x005647C4
		public Action_bt_AutoFight_AutoFight_Fightergirl_Action_node36()
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
			item.skillID = 3117;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012754 RID: 75604 RVA: 0x00566454 File Offset: 0x00564854
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C144 RID: 49476
		private List<Input> method_p0;

		// Token: 0x0400C145 RID: 49477
		private bool method_p1;
	}
}
