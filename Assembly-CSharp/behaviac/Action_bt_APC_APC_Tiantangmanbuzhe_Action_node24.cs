using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E1F RID: 7711
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Tiantangmanbuzhe_Action_node24 : Action
	{
		// Token: 0x060125EF RID: 75247 RVA: 0x0055DC7C File Offset: 0x0055C07C
		public Action_bt_APC_APC_Tiantangmanbuzhe_Action_node24()
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
			item.skillID = 8013;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060125F0 RID: 75248 RVA: 0x0055DD0C File Offset: 0x0055C10C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFD8 RID: 49112
		private List<Input> method_p0;

		// Token: 0x0400BFD9 RID: 49113
		private bool method_p1;
	}
}
