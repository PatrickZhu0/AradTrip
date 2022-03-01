using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020025C4 RID: 9668
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node87 : Action
	{
		// Token: 0x060134CF RID: 79055 RVA: 0x005BCF8C File Offset: 0x005BB38C
		public Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node87()
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
			item.skillID = 1005;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060134D0 RID: 79056 RVA: 0x005BD01C File Offset: 0x005BB41C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF0B RID: 53003
		private List<Input> method_p0;

		// Token: 0x0400CF0C RID: 53004
		private bool method_p1;
	}
}
