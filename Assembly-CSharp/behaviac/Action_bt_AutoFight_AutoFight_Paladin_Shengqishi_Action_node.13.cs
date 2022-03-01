using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002846 RID: 10310
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node26 : Action
	{
		// Token: 0x060139CA RID: 80330 RVA: 0x005D9A44 File Offset: 0x005D7E44
		public Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node26()
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
			item.skillID = 3711;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060139CB RID: 80331 RVA: 0x005D9AD4 File Offset: 0x005D7ED4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D422 RID: 54306
		private List<Input> method_p0;

		// Token: 0x0400D423 RID: 54307
		private bool method_p1;
	}
}
