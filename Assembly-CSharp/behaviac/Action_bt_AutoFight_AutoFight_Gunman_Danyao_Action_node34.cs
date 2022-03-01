using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020025C0 RID: 9664
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node34 : Action
	{
		// Token: 0x060134C7 RID: 79047 RVA: 0x005BCDD8 File Offset: 0x005BB1D8
		public Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node34()
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
			item.skillID = 1307;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060134C8 RID: 79048 RVA: 0x005BCE68 File Offset: 0x005BB268
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF03 RID: 52995
		private List<Input> method_p0;

		// Token: 0x0400CF04 RID: 52996
		private bool method_p1;
	}
}
