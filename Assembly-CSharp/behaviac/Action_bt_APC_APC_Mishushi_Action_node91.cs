using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001DCA RID: 7626
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Mishushi_Action_node91 : Action
	{
		// Token: 0x0601254C RID: 75084 RVA: 0x0055A20C File Offset: 0x0055860C
		public Action_bt_APC_APC_Mishushi_Action_node91()
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
			item.skillID = 9741;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601254D RID: 75085 RVA: 0x0055A29C File Offset: 0x0055869C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF40 RID: 48960
		private List<Input> method_p0;

		// Token: 0x0400BF41 RID: 48961
		private bool method_p1;
	}
}
