using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200282A RID: 10282
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node74 : Action
	{
		// Token: 0x06013992 RID: 80274 RVA: 0x005D8E58 File Offset: 0x005D7258
		public Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node74()
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
			item.skillID = 3708;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013993 RID: 80275 RVA: 0x005D8EE8 File Offset: 0x005D72E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3EA RID: 54250
		private List<Input> method_p0;

		// Token: 0x0400D3EB RID: 54251
		private bool method_p1;
	}
}
