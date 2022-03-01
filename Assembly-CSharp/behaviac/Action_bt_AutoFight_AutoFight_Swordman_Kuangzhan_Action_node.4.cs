using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002952 RID: 10578
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node39 : Action
	{
		// Token: 0x06013BD9 RID: 80857 RVA: 0x005E70AC File Offset: 0x005E54AC
		public Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node39()
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
			item.skillID = 1521;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013BDA RID: 80858 RVA: 0x005E713C File Offset: 0x005E553C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D63E RID: 54846
		private List<Input> method_p0;

		// Token: 0x0400D63F RID: 54847
		private bool method_p1;
	}
}
