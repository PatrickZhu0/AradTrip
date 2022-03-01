using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020029C5 RID: 10693
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node58 : Action
	{
		// Token: 0x06013CBE RID: 81086 RVA: 0x005EB640 File Offset: 0x005E9A40
		public Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node58()
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
			item.skillID = 1810;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013CBF RID: 81087 RVA: 0x005EB6D0 File Offset: 0x005E9AD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D72C RID: 55084
		private List<Input> method_p0;

		// Token: 0x0400D72D RID: 55085
		private bool method_p1;
	}
}
