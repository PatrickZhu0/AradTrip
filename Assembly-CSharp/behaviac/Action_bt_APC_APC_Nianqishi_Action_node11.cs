using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001DE2 RID: 7650
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Nianqishi_Action_node11 : Action
	{
		// Token: 0x0601257A RID: 75130 RVA: 0x0055B2C0 File Offset: 0x005596C0
		public Action_bt_APC_APC_Nianqishi_Action_node11()
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
			item.skillID = 9703;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601257B RID: 75131 RVA: 0x0055B350 File Offset: 0x00559750
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF6A RID: 49002
		private List<Input> method_p0;

		// Token: 0x0400BF6B RID: 49003
		private bool method_p1;
	}
}
