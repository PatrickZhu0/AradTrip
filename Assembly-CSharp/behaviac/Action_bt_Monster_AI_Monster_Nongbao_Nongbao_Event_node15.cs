using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020036E0 RID: 14048
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node15 : Action
	{
		// Token: 0x060155D6 RID: 87510 RVA: 0x00672054 File Offset: 0x00670454
		public Action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node15()
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
			item.skillID = 20388;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060155D7 RID: 87511 RVA: 0x006720E4 File Offset: 0x006704E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFA9 RID: 61353
		private List<Input> method_p0;

		// Token: 0x0400EFAA RID: 61354
		private bool method_p1;
	}
}
