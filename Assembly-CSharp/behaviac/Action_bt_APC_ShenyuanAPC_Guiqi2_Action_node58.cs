using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E58 RID: 7768
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Guiqi2_Action_node58 : Action
	{
		// Token: 0x0601265D RID: 75357 RVA: 0x0056059C File Offset: 0x0055E99C
		public Action_bt_APC_ShenyuanAPC_Guiqi2_Action_node58()
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
			item.skillID = 9733;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601265E RID: 75358 RVA: 0x0056062C File Offset: 0x0055EA2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C044 RID: 49220
		private List<Input> method_p0;

		// Token: 0x0400C045 RID: 49221
		private bool method_p1;
	}
}
