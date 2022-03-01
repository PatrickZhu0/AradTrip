using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020024B8 RID: 9400
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Action_node34 : Action
	{
		// Token: 0x060132BB RID: 78523 RVA: 0x005B0AC4 File Offset: 0x005AEEC4
		public Action_bt_AutoFight_AutoFight_Gungirl_Action_node34()
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
			item.skillID = 2507;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060132BC RID: 78524 RVA: 0x005B0B54 File Offset: 0x005AEF54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCD5 RID: 52437
		private List<Input> method_p0;

		// Token: 0x0400CCD6 RID: 52438
		private bool method_p1;
	}
}
