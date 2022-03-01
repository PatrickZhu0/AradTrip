using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001FED RID: 8173
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node5 : Action
	{
		// Token: 0x06012976 RID: 76150 RVA: 0x005732BC File Offset: 0x005716BC
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node5()
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
			item.skillID = 2518;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012977 RID: 76151 RVA: 0x0057334C File Offset: 0x0057174C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C369 RID: 50025
		private List<Input> method_p0;

		// Token: 0x0400C36A RID: 50026
		private bool method_p1;
	}
}
