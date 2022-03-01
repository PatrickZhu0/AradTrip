using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001EE9 RID: 7913
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_Action_node21 : Action
	{
		// Token: 0x06012777 RID: 75639 RVA: 0x00566B58 File Offset: 0x00564F58
		public Action_bt_AutoFight_AutoFight_Fightergirl_Action_node21()
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
			item.skillID = 3005;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012778 RID: 75640 RVA: 0x00566BE8 File Offset: 0x00564FE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C16B RID: 49515
		private List<Input> method_p0;

		// Token: 0x0400C16C RID: 49516
		private bool method_p1;
	}
}
