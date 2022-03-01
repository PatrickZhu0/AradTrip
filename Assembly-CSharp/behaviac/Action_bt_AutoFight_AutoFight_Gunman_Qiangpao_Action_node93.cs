using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002642 RID: 9794
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node93 : Action
	{
		// Token: 0x060135C9 RID: 79305 RVA: 0x005C36F0 File Offset: 0x005C1AF0
		public Action_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node93()
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
			item.skillID = 1015;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060135CA RID: 79306 RVA: 0x005C3780 File Offset: 0x005C1B80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D017 RID: 53271
		private List<Input> method_p0;

		// Token: 0x0400D018 RID: 53272
		private bool method_p1;
	}
}
