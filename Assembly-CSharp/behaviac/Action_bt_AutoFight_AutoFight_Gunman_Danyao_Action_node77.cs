using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020025DC RID: 9692
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node77 : Action
	{
		// Token: 0x060134FF RID: 79103 RVA: 0x005BD95C File Offset: 0x005BBD5C
		public Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node77()
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
			item.skillID = 1009;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013500 RID: 79104 RVA: 0x005BD9EC File Offset: 0x005BBDEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF43 RID: 53059
		private List<Input> method_p0;

		// Token: 0x0400CF44 RID: 53060
		private bool method_p1;
	}
}
