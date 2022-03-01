using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020036DC RID: 14044
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node3 : Action
	{
		// Token: 0x060155CE RID: 87502 RVA: 0x00671EA0 File Offset: 0x006702A0
		public Action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node3()
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
			item.skillID = 20387;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060155CF RID: 87503 RVA: 0x00671F30 File Offset: 0x00670330
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFA0 RID: 61344
		private List<Input> method_p0;

		// Token: 0x0400EFA1 RID: 61345
		private bool method_p1;
	}
}
