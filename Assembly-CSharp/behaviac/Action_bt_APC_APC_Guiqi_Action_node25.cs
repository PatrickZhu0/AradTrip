using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D3D RID: 7485
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Guiqi_Action_node25 : Action
	{
		// Token: 0x0601243C RID: 74812 RVA: 0x00553B18 File Offset: 0x00551F18
		public Action_bt_APC_APC_Guiqi_Action_node25()
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
			item.skillID = 7090;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601243D RID: 74813 RVA: 0x00553BA8 File Offset: 0x00551FA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE2E RID: 48686
		private List<Input> method_p0;

		// Token: 0x0400BE2F RID: 48687
		private bool method_p1;
	}
}
