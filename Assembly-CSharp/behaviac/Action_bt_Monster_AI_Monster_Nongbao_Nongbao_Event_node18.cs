using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020036E3 RID: 14051
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node18 : Action
	{
		// Token: 0x060155DC RID: 87516 RVA: 0x006721A8 File Offset: 0x006705A8
		public Action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node18()
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
			item.skillID = 20389;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060155DD RID: 87517 RVA: 0x00672238 File Offset: 0x00670638
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFAF RID: 61359
		private List<Input> method_p0;

		// Token: 0x0400EFB0 RID: 61360
		private bool method_p1;
	}
}
