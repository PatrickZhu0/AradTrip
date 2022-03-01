using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200284A RID: 10314
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node11 : Action
	{
		// Token: 0x060139D2 RID: 80338 RVA: 0x005D9BF8 File Offset: 0x005D7FF8
		public Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node11()
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
			item.skillID = 3705;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060139D3 RID: 80339 RVA: 0x005D9C88 File Offset: 0x005D8088
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D42A RID: 54314
		private List<Input> method_p0;

		// Token: 0x0400D42B RID: 54315
		private bool method_p1;
	}
}
