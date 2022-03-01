using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002826 RID: 10278
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node54 : Action
	{
		// Token: 0x0601398A RID: 80266 RVA: 0x005D8CBC File Offset: 0x005D70BC
		public Action_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node54()
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
			item.skillID = 3704;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601398B RID: 80267 RVA: 0x005D8D4C File Offset: 0x005D714C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3E3 RID: 54243
		private List<Input> method_p0;

		// Token: 0x0400D3E4 RID: 54244
		private bool method_p1;
	}
}
