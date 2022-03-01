using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020025E8 RID: 9704
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node69 : Action
	{
		// Token: 0x06013517 RID: 79127 RVA: 0x005BDED4 File Offset: 0x005BC2D4
		public Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node69()
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
			item.skillID = 1008;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013518 RID: 79128 RVA: 0x005BDF64 File Offset: 0x005BC364
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF5B RID: 53083
		private List<Input> method_p0;

		// Token: 0x0400CF5C RID: 53084
		private bool method_p1;
	}
}
