using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020024BC RID: 9404
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Action_node39 : Action
	{
		// Token: 0x060132C3 RID: 78531 RVA: 0x005B0C78 File Offset: 0x005AF078
		public Action_bt_AutoFight_AutoFight_Gungirl_Action_node39()
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
			item.skillID = 2522;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060132C4 RID: 78532 RVA: 0x005B0D08 File Offset: 0x005AF108
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCDD RID: 52445
		private List<Input> method_p0;

		// Token: 0x0400CCDE RID: 52446
		private bool method_p1;
	}
}
