using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200285A RID: 10330
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node104 : Action
	{
		// Token: 0x060139F2 RID: 80370 RVA: 0x005DA2C8 File Offset: 0x005D86C8
		public Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node104()
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
			item.skillID = 3509;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060139F3 RID: 80371 RVA: 0x005DA358 File Offset: 0x005D8758
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D44A RID: 54346
		private List<Input> method_p0;

		// Token: 0x0400D44B RID: 54347
		private bool method_p1;
	}
}
